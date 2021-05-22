using FluentValidation;
using Organizations.Model.Validators;

namespace Organizations.Model.Operations
{
    public sealed class CreateImage
    {
        private CreateImage(byte[] content)
        {
            Content = content;
        }

        public byte[] Content { get; }

        public static CreateImage New(byte[] content)
        {
            var createImage = new CreateImage(content);
            new CreateImageValidator().ValidateAndThrow(createImage);
            return createImage;
        }
    }
}