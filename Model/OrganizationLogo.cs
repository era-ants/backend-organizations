using System;
using System.IO;
using System.Threading.Tasks;
using Organizations.Model.Operations;
using SixLabors.ImageSharp.Formats.Png;

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

        public static async Task<OrganizationLogo> NewAsync(CreateOrganizationLogo createLogo)
        {
            await using var memoryStream = new MemoryStream();
            await SixLabors.ImageSharp.Image.Load(createLogo.Content).SaveAsync(memoryStream, new PngEncoder());
            return new OrganizationLogo(
                Guid.NewGuid(), memoryStream.GetBuffer());
        }
    }
}