using System;
using System.Collections.Generic;

namespace Organizations.DataTransfer
{
    public sealed class RegisterOrganizationDto
    {
        public Guid Guid { get; set; }
        
        public int OrganizationTypeId { get; set; }
        
        public ContactsFullDto Contacts { get; set; }
        
        public string LegalName { get; set; }
        
        public string LegalAddress { get; set; }
        
        public string TIN { get; set; }
        
        public string ActualName { get; set; }
        
        public byte[]? Logo { get; set; }

        public List<byte[]>? Images { get; set; }
    }
}