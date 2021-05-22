using System;
using Organizations.Model.Operations;

namespace Organizations.Model
{
    public sealed class OrganizationLogo
    {
        private OrganizationLogo(Guid guid, byte[] image)
        {
            Guid = guid;
            Image = image;
        }

        public Guid Guid { get; }
        
        public byte[] Image { get; }

        public static OrganizationLogo New(CreateOrganizationLogo createLogo) => new(
            Guid.NewGuid(), createLogo.Content);
    }
}