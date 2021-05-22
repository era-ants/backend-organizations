using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Organizations.Model.Operations;

namespace Organizations.Model
{
    public sealed class Organization
    {
        private readonly List<OrganizationImage> _images;

        public Organization(
            Guid guid,
            OrganizationType type,
            Contacts contacts,
            string legalName,
            string legalAddress,
            string actualName,
            string tin,
            OrganizationLogo? logo,
            IEnumerable<OrganizationImage> images)
        {
            Guid = guid;
            Type = type;
            Contacts = contacts;
            LegalName = legalName;
            LegalAddress = legalAddress;
            TIN = tin;
            ActualName = actualName;
            Logo = logo;
            _images = new List<OrganizationImage>(images);
        }

        public Guid Guid { get; }

        public OrganizationType Type { get; }

        public Contacts Contacts { get; }

        public string LegalName { get; }

        public string LegalAddress { get; }

        /// <summary>
        ///     ИНН организации
        /// </summary>
        public string TIN { get; }

        public string ActualName { get; }

        public OrganizationLogo? Logo { get; }

        public IEnumerable<OrganizationImage> Images => _images;

        public static async Task<Organization> NewAsync(CreateOrganization createOrganization)
        {
            var images = new List<OrganizationImage>(createOrganization.Images.Count());
            foreach (var image in createOrganization.Images)
                images.Add(await OrganizationImage.NewAsync(image));
            return new Organization(
                createOrganization.Guid,
                createOrganization.Type,
                Contacts.New(createOrganization.Contacts),
                createOrganization.LegalName,
                createOrganization.LegalAddress,
                createOrganization.ActualName,
                createOrganization.TIN,
                createOrganization.Logo == null ? null : await OrganizationLogo.NewAsync(createOrganization.Logo),
                images);
        }
    }
}