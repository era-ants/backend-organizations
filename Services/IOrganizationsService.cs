using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Organizations.DataTransfer;
using Organizations.Model;

namespace Organizations.Services
{
    public interface IOrganizationsService
    {
        Task<IEnumerable<OrganizationFullDto>> GetAllAsync();

        Task<OrganizationFullDto> GetByGuidAsync(Guid guid);

        Task<Guid> RegisterOrganizationAsync(Organization organization);

        Task<bool> CheckIfImageGuidExists(Guid guid);

        Task<byte[]> GetImageAsync(Guid imageGuid);

        Task<bool> CheckIfLogoGuidExists(Guid guid);

        Task<byte[]> GetLogoAsync(Guid logoGuid);
    }
}