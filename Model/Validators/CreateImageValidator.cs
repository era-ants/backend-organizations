using FluentValidation;
using Organizations.Model.Operations;

namespace Organizations.Model.Validators
{
    public sealed class CreateImageValidator : AbstractValidator<CreateImage>
    {
        public CreateImageValidator()
        {
            RuleFor(x => x.Content)
                .Must(image => SixLabors.ImageSharp.Image.Identify(image) != null)
                .WithMessage("Image format is unrecognized")
                ;
        }
    }
}