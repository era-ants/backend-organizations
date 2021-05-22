using System;
using System.Collections.Generic;

namespace Organizations.DataTransfer
{
    public sealed class OrganizationFullDto
    {
        public Guid Guid { get; set; }
        
        public double Rating { get; set; }
        
        public int OrganizationCategoryId { get; set; }
        
        public int OrganizationTypeId { get; set; }
        
        public Guid ContactsGuid { get; set; }
        
        public ContactsFullDto Contacts { get; set; }
        
        public string LegalName { get; set; }
        
        public string LegalAddress { get; set; }
        
        public string TIN { get; set; }
        
        public string ActualName { get; set; }
        
        public Guid LogoGuid { get; set; }

        public List<Guid> ImagesGuids { get; set; }
    }
}