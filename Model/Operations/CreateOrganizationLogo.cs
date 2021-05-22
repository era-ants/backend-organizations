using FluentValidation;
using Organizations.Model.Validators;

namespace Organizations.Model.Operations
{
    public sealed class CreateOrganizationLogo
    {
        private CreateOrganizationLogo(byte[] content)
        {
            Content = content;
        }

        public byte[] Content { get; }

        public static CreateOrganizationLogo New(byte[] content)
        {
            var createLogo = new CreateOrganizationLogo(content);
            new CreateOrganizationLogoValidator().ValidateAndThrow(createLogo);
            return createLogo;
        }
    }
}