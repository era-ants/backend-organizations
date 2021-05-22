using System;
using System.Collections.Generic;

namespace Organizations.DataTransfer
{
    /// <summary>
    ///     Полные данные об организации
    /// </summary>
    public sealed class OrganizationFullDto
    {
        /// <summary>
        ///     Guid организации
        /// </summary>
        public Guid Guid { get; set; }

        /// <summary>
        ///     Пользовательский рейтинг организации от 1 до 5
        /// </summary>
        public double Rating { get; set; }

        /// <summary>
        ///     Id категории организации
        ///     1 - Транспорт; 2 - Культура; 3 - Поесть; 4 - Муниципалитет
        /// </summary>
        public int OrganizationCategoryId { get; set; }

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
        ///     Guid контактных данных
        /// </summary>
        public Guid ContactsGuid { get; set; }

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
        ///     Guid логотипа организации
        /// </summary>
        public Guid LogoGuid { get; set; }

        /// <summary>
        ///     Guid изображений организации
        /// </summary>
        public List<Guid> ImagesGuids { get; set; }
    }
}