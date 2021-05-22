using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Npgsql;
using Organizations.DataTransfer;
using Organizations.Model;

namespace Organizations.Services
{
    public sealed class PostgresDbOrganizationsService : IOrganizationsService
    {
        private readonly NpgsqlConnection _connection;

        public PostgresDbOrganizationsService(NpgsqlConnection connection)
        {
            _connection = connection;
        }

        private const string _getOrganizationsSql = @"
SELECT 
       ""Guid"", 
       (""TypeId"" / 100) AS ""OrganizationCategoryId"", 
       ""TypeId"" AS ""OrganizationTypeId"", 
       ""LegalName"", 
       ""LegalAddress"", 
       ""TIN"",
       ""ActualName"", 
       ""OrganizationLogoGuid"",
       ""ContactsGuid""
FROM ""Organization""";

        private const string _getContactsSql = @"
SELECT ""Guid"", 
       ""Email"", 
       ""PhoneNumber"", 
       ""Site"", 
       ""Vk"", 
       ""Telegram"", 
       ""Instagram""
FROM ""Contacts""";

        public async Task<IEnumerable<OrganizationFullDto>> GetAllAsync()
        {
            var organizations = await _connection.QueryAsync<OrganizationFullDto>(_getOrganizationsSql);
            var images = (await _connection.QueryAsync(
                    @"SELECT ""OrganizationGuid"", ""OrganizationImageGuid"" FROM ""JOrganizationImage"""))
                .Select(x => new {OrganizationGuid = (Guid) x.OrganizationGuid, OrganizationImageGuid = (Guid) x.OrganizationImageGuid});
            var contacts = await _connection.QueryAsync<ContactsFullDto>(_getContactsSql);
            foreach (var contactsFullDto in contacts) 
                organizations.First(x => x.ContactsGuid == contactsFullDto.Guid);
            foreach (var group in images.GroupBy(x => x.OrganizationGuid))
                organizations.First(x => x.Guid == group.Key).ImagesGuids = new List<Guid>(group.Select(x => x.OrganizationImageGuid));
            return organizations;
        }

        public async Task<OrganizationFullDto> GetByGuidAsync(Guid guid)
        {
            var organization = await _connection.QueryFirstAsync<OrganizationFullDto>($@"{_getOrganizationsSql}
WHERE ""Guid"" = @Guid", new {Guid = guid});
            organization.Contacts = await _connection.QueryFirstAsync<ContactsFullDto>($@"{_getContactsSql} 
WHERE ""Guid"" = @Guid", new {Guid = organization.ContactsGuid});
            organization.ImagesGuids = (await _connection.QueryAsync<Guid>(@"SELECT ""OrganizationImageGuid""
FROM ""JOrganizationImage""
WHERE ""OrganizationGuid"" = @Guid", new {Guid = guid})).ToList();
            return organization;
        }

        public async Task<Guid> RegisterOrganizationAsync(Organization organization)
        {
            await _connection.OpenAsync();
            await using var transaction = await _connection.BeginTransactionAsync();
            await _connection.ExecuteAsync(@"INSERT INTO ""Contacts"" 
(""Guid"", ""Email"", ""PhoneNumber"", ""Site"", ""Vk"", ""Telegram"", ""Instagram"")
VALUES (@Guid, @Email, @PhoneNumber, @Site, @Vk, @Telegram, @Instagram)", organization.Contacts);
            if (organization.Logo != null)
                await _connection.ExecuteAsync(@"INSERT INTO ""OrganizationLogo""
(""Guid"", ""Content"") VALUES (@Guid, @Content)", organization.Logo);
            await _connection.ExecuteAsync(@"INSERT INTO ""Organization""
(""Guid"", ""OrganizationTypeId"", ""ContactsGuid"", ""LegalName"", ""LegalAddress"",
    ""ActualName"", ""TIN"", ""OrganizationLogoGuid"") 
VALUES (@Guid, @OrganizationTypeId, @ContactsGuid, @LegalName, @LegalAddress, @ActualName,
  @TIN, @OrganizationLogoGuid)", new
            {
                organization.Guid,
                OrganizationTypeId = organization.Type.Id,
                ContactsGuid = organization.Contacts.Guid,
                organization.LegalName,
                organization.LegalAddress,
                organization.ActualName,
                organization.TIN,
                OrganizationLogoGuid = organization.Logo?.Guid
            });
            foreach (var image in organization.Images)
            {
                await _connection.ExecuteAsync(@"INSERT INTO ""OrganizationImage""
(""Guid"", ""Content"") VALUES (@Guid, @Content)", image);
                await _connection.ExecuteAsync(@"INSERT INTO ""JOrganizationImage""
(""OrganizationGuid"", ""OrganizationImageGuid"") VALUES (@Guid, ImageGuid)",
                    new {organization.Guid, ImageGuid = image.Guid});
            }

            return organization.Guid;
        }
    }
}