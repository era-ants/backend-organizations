using System;
using Organizations.Model.Operations;

namespace Organizations.Model
{
    public sealed class OrganizationImage
    {
        private OrganizationImage(Guid guid, byte[] content)
        {
            Guid = guid;
            Content = content;
        }

        public Guid Guid { get; }
        
        public byte[] Content { get; }

        public static OrganizationImage New(CreateImage createImage) => new(
            Guid.NewGuid(), createImage.Content);
    }
}