using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using Organizations.Model.Validators;

namespace Organizations.Model.Operations
{
    public sealed class CreateOrganization
    {
        private CreateOrganization(
            Guid guid, 
            OrganizationType type, 
            CreateOrUpdateContacts contacts, 
            string legalName, 
            string legalAddress,
            string actualName,
            string tin,
            CreateOrganizationLogo logo, 
            IEnumerable<CreateImage> images)
        {
            Guid = guid;
            Type = type;
            Contacts = contacts;
            LegalName = legalName;
            LegalAddress = legalAddress;
            ActualName = actualName;
            TIN = tin;
            Logo = logo;
            Images = images.ToArray();
        }

        public Guid Guid { get; }
        
        public OrganizationType Type { get; }
        
        public CreateOrUpdateContacts Contacts { get; }
        
        public string LegalName { get; }
        
        public string LegalAddress { get; }
        
        public string ActualName { get; }
        
        public string TIN { get; }
        public CreateOrganizationLogo Logo { get; }
        public IEnumerable<CreateImage> Images { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="contacts"></param>
        /// <param name="legalName"></param>
        /// <param name="legalAddress"></param>
        /// <param name="actualName"></param>
        /// <param name="actualAddress"></param>
        /// <param name="actualGeoPosition"></param>
        /// <exception cref="ValidationException"></exception>
        public static CreateOrganization New(
            OrganizationType type,
            CreateOrUpdateContacts contacts,
            string legalName,
            string legalAddress,
            string actualName,
            string tin,
            CreateOrganizationLogo logo,
            IEnumerable<CreateImage> images)
        {
            var createOrganization = new CreateOrganization(
                Guid.NewGuid(), 
                type,
                contacts,
                legalName,
                legalAddress,
                actualName,
                tin,
                logo,
                images);
            new CreateOrganizationValidator().ValidateAndThrow(createOrganization);
            return createOrganization;
        }
    }
}