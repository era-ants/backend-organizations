using FluentValidation;
using Organizations.Model.Validators;

namespace Organizations.Model.Operations
{
    public sealed class CreateOrUpdateContacts
    {
        public CreateOrUpdateContacts(
            string actualAddress,
            string actualGeoPosition,
            string? phoneNumber, 
            string? email, 
            string? site, 
            string? telegram,
            string? instagram, 
            string? vk)
        {
            ActualAddress = actualAddress;
            ActualGeoPosition = actualGeoPosition;
            Email = email;
            Site = site;
            Telegram = telegram;
            Instagram = instagram;
            Vk = vk;
            PhoneNumber = phoneNumber;
            new CreateOrUpdateContactsValidator().ValidateAndThrow(this);
        }

        public string ActualAddress { get; }

        public string ActualGeoPosition { get; }

        public string? PhoneNumber { get; }

        public string? Email { get; }

        public string? Site { get; }

        public string? Telegram { get; }

        public string? Instagram { get; }

        public string? Vk { get; }
    }
}