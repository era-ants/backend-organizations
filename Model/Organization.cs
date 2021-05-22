using System;
using System.Collections.Generic;
using System.Linq;
using Organizations.Model.Operations;

namespace Organizations.Model
{
    public sealed class Organization
    {
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
        /// ИНН организации
        /// </summary>
        public string TIN { get; }
        
        public string ActualName { get; }
        
        public OrganizationLogo? Logo { get; }

        private readonly List<OrganizationImage> _images;

        public IEnumerable<OrganizationImage> Images => _images;

        public static Organization New(CreateOrganization createOrganization) => new(
            createOrganization.Guid,
            createOrganization.Type,
            Contacts.New(createOrganization.Contacts),
            createOrganization.LegalName,
            createOrganization.LegalAddress,
            createOrganization.ActualName,
            createOrganization.TIN,
            OrganizationLogo.New(createOrganization.Logo),
            createOrganization.Images.Select(OrganizationImage.New));
    }
}