using System;

namespace Organizations.DataTransfer
{
    public sealed class ContactsFullDto
    {
        public Guid Guid { get; set; }

        public string ActualAddress { get; set; }
        
        public string ActualGeoPosition { get; set; }

        public string? Email { get; set; }
        
        public string? Site { get; set; }
        
        public string? Telegram { get; set; }
        
        public string? Instagram { get; set; }
        
        public string? Vk { get; set; }
        
        public string? PhoneNumber { get; set; }
    }
}