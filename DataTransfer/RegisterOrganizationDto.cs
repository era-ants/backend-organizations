using System.Collections.Generic;

namespace Organizations.DataTransfer
{
    /// <summary>
    ///     Регистрация организации в системе
    /// </summary>
    public sealed class RegisterOrganizationDto
    {
        /// <summary>
        ///     Id типа организации
        ///     <see cref="OrganizationTypeId" /> / 100 == <see cref="OrganizationCategoryId" />
        ///     101 - Транспортная компания;
        ///     201 - Музей; 202 - Экскурсии; 203 - Театр; 204 - Библиотека; 205 - Парк; 206 - Дом/дворец/центр культуры;
        ///     207 - Планетарий;
        ///     301 - Кафе; 302 - Ресторан; 303 - Бар; 304 - Столовая;
        ///     401 - Администрация
        /// </summary>
        public int OrganizationTypeId { get; set; }

        /// <summary>
        ///     Контактные данные организации
        /// </summary>
        public ContactsFullDto Contacts { get; set; }

        /// <summary>
        ///     Юридическое название организации
        /// </summary>
        public string LegalName { get; set; }

        /// <summary>
        ///     Юридический адрес организации
        /// </summary>
        public string LegalAddress { get; set; }

        /// <summary>
        ///     ИНН организации
        /// </summary>
        public string TIN { get; set; }

        /// <summary>
        ///     Фактическое название организации
        /// </summary>
        public string ActualName { get; set; }

        /// <summary>
        ///     Логотип организации
        /// </summary>
        public byte[]? Logo { get; set; }

        /// <summary>
        ///     Изображения организации
        /// </summary>
        public List<byte[]>? Images { get; set; }
    }
}