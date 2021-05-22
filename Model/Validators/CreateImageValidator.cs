using FluentValidation;
using Organizations.Model.Operations;
using SixLabors.ImageSharp;

namespace Organizations.Model.Validators
{
    public sealed class CreateImageValidator : AbstractValidator<CreateImage>
    {
        public CreateImageValidator()
        {
            RuleFor(x => x.Content)
                .Must(image => Image.Identify(image) != null)
                .WithMessage("Image format is unrecognized")
                ;
        }
    }
}