using System;
using System.IO;
using System.Threading.Tasks;
using Organizations.Model.Operations;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Png;

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

        public static async Task<OrganizationImage> NewAsync(CreateImage createImage)
        {
            await using var memoryStream = new MemoryStream();
            Image.Load(createImage.Content).SaveAsync(memoryStream, new PngEncoder());
            return new OrganizationImage(
                Guid.NewGuid(), createImage.Content);
        }
    }
}