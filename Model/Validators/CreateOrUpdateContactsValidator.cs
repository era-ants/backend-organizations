using FluentValidation;
using Organizations.Model.Operations;

namespace Organizations.Model.Validators
{
    public sealed class CreateOrUpdateContactsValidator : AbstractValidator<CreateOrUpdateContacts>
    {
        public CreateOrUpdateContactsValidator()
        {
            ValidateEmail();
            ValidateSite();
            ValidateInstagram();
            ValidateTelegram();
            ValidateVk();
            ValidatePhoneNumber();
        }

        private void ValidateEmail() => RuleFor(x => x.Email)
            .EmailAddress()
            .When(x => !string.IsNullOrEmpty(x.Email))
            .WithMessage("Specified email is invalid")
        ;

        private void ValidateSite() => RuleFor(x => x.Site)
            .WebsiteLink()
            .When(x => !string.IsNullOrEmpty(x.Site))
            .WithMessage("Specified website link is invalid")
        ;

        private void ValidateVk() => RuleFor(x => x.Vk)
            .WebsiteLink()
            .When(x => !string.IsNullOrEmpty(x.Vk))
            .WithMessage("Specified Vk link is invalid")
        ;
        
        private void ValidateTelegram() => RuleFor(x => x.Telegram)
            .WebsiteLink()
            .When(x => !string.IsNullOrEmpty(x.Telegram))
            .WithMessage("Specified Telegram link is invalid")
        ;
        
        private void ValidateInstagram() => RuleFor(x => x.Instagram)
            .WebsiteLink()
            .When(x => !string.IsNullOrEmpty(x.Instagram))
            .WithMessage("Specified Instagram link is invalid")
        ;

        private void ValidatePhoneNumber() => RuleFor(x => x.PhoneNumber)
            .PhoneNumber()
            .When(x => !string.IsNullOrEmpty(x.PhoneNumber))
            .WithMessage("Specified phone number is invalid")
        ;

    }
}