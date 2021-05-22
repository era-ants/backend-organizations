using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Organizations.Model
{
    public sealed class OrganizationType
    {
        private OrganizationType(int subId, string name, OrganizationCategory category)
        {
            Id = category.Id * 100 + subId;
            Name = name;
            Category = category;
        }

        public int Id { get; }

        public string Name { get; }

        public OrganizationCategory Category { get; }

        public static OrganizationType Transport { get; } =
            new(1, "Транспортная компания", OrganizationCategory.Transport);

        public static OrganizationType Museum { get; } = new(1, "Музей", OrganizationCategory.Culture);

        public static OrganizationType Touring { get; } = new(2, "Экскурсии", OrganizationCategory.Culture);

        public static OrganizationType Theater { get; } = new(3, "Театр", OrganizationCategory.Culture);

        public static OrganizationType Library { get; } = new(4, "Библиотека", OrganizationCategory.Culture);

        public static OrganizationType Park { get; } = new(5, "Парк", OrganizationCategory.Culture);

        public static OrganizationType CultureHouse { get; } =
            new(6, "Дом/дворец/центр культуры", OrganizationCategory.Culture);

        public static OrganizationType Planetarium { get; } = new(7, "Планетарий", OrganizationCategory.Culture);

        public static OrganizationType Cafe { get; } = new(1, "Кафе", OrganizationCategory.Food);

        public static OrganizationType Restaraunt { get; } = new(2, "Ресторан", OrganizationCategory.Food);

        public static OrganizationType Bar { get; } = new(3, "Бар", OrganizationCategory.Food);

        public static OrganizationType Dining { get; } = new(4, "Столовая", OrganizationCategory.Food);

        public static OrganizationType Administration { get; } =
            new(1, "Администрация", OrganizationCategory.Municipality);

        public static IEnumerable<OrganizationType> GetAll()
        {
            return typeof(OrganizationType).GetProperties(
                    BindingFlags.Public | BindingFlags.Static)
                .Select(propertyInfo => (OrganizationType) propertyInfo.GetValue(null));
        }

        public static OrganizationType GetById(int id)
        {
            return GetAll().First(x => x.Id == id);
        }
    }
}