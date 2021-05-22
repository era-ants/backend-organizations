using System;
using Organizations.Model.Operations;

namespace Organizations.Model
{
    /// <summary>
    ///     Данные для связи
    /// </summary>
    public sealed class Contacts
    {
        private Contacts(
            Guid guid,
            string actualAddress,
            string actualGeoPosition,
            string? phoneNumber,
            string? email,
            string? site,
            string? telegram,
            string? instagram,
            string? vk)
        {
            Guid = guid;
            ActualAddress = actualAddress;
            ActualGeoPosition = actualGeoPosition;
            PhoneNumber = phoneNumber;
            Email = email;
            Site = site;
            Telegram = telegram;
            Instagram = instagram;
            Vk = vk;
        }

        public Guid Guid { get; }

        public string ActualAddress { get; private set; }

        public string ActualGeoPosition { get; private set; }

        public string? Email { get; private set; }

        public string? Site { get; private set; }

        public string? Telegram { get; private set; }

        public string? Instagram { get; private set; }

        public string? Vk { get; private set; }

        public string? PhoneNumber { get; private set; }

        public static Contacts New(CreateOrUpdateContacts createContacts)
        {
            return new(
                Guid.NewGuid(),
                createContacts.ActualAddress,
                createContacts.ActualGeoPosition,
                createContacts.PhoneNumber,
                createContacts.Email,
                createContacts.Site,
                createContacts.Telegram,
                createContacts.Instagram,
                createContacts.Vk);
        }

        public void Update(CreateOrUpdateContacts updateContacts)
        {
            ActualAddress = updateContacts.ActualAddress;
            ActualGeoPosition = updateContacts.ActualGeoPosition;
            PhoneNumber = updateContacts.PhoneNumber;
            Email = updateContacts.Email;
            Instagram = updateContacts.Instagram;
            Site = updateContacts.Site;
            Telegram = updateContacts.Telegram;
            Vk = updateContacts.Vk;
        }
    }
}