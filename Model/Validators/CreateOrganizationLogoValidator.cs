using FluentValidation;
using Organizations.Model.Operations;
using SixLabors.ImageSharp;

namespace Organizations.Model.Validators
{
    public sealed class CreateOrganizationLogoValidator : AbstractValidator<CreateOrganizationLogo>
    {
        public CreateOrganizationLogoValidator()
        {
            RuleFor(x => x.Content)
                .Must(image => Image.Identify(image) != null)
                .WithMessage("Image format is invalid")
                ;
        }
    }
}