using FluentValidation;
using Organizations.Model.Operations;

namespace Organizations.Model.Validators
{
    public sealed class CreateOrganizationLogoValidator : AbstractValidator<CreateOrganizationLogo>
    {
        public CreateOrganizationLogoValidator()
        {
            RuleFor(x => x.Content)
                .Must(image => SixLabors.ImageSharp.Image.Identify(image) != null)
                .WithMessage("Image format is invalid")
                ;
        }
    }
}