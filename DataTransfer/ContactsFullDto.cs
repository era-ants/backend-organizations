using System;

namespace Organizations.DataTransfer
{
    /// <summary>
    ///     Контактные данные организации
    /// </summary>
    public sealed class ContactsFullDto
    {
        /// <summary>
        ///     Guid контактных данных
        /// </summary>
        public Guid Guid { get; set; }

        /// <summary>
        ///     Фактический адрес организации
        /// </summary>
        public string ActualAddress { get; set; }

        /// <summary>
        ///     Геопозиция организации (результат геокодирования <see cref="ActualAddress" />)
        /// </summary>
        public string ActualGeoPosition { get; set; }

        /// <summary>
        ///     Email организации
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        ///     Веб-сайт организации
        /// </summary>
        public string? Site { get; set; }

        public string? Telegram { get; set; }

        public string? Instagram { get; set; }

        public string? Vk { get; set; }

        /// <summary>
        ///     Телефонный номер организации
        /// </summary>
        public string? PhoneNumber { get; set; }
    }
}