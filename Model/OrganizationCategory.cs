using System.Collections.Generic;
using System.Linq;

namespace Organizations.Model
{
    public sealed class OrganizationCategory
    {
        private OrganizationCategory(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; }

        public string Name { get; }

        public static OrganizationCategory Transport { get; } = new(1, "Транспорт");

        public static OrganizationCategory Culture { get; } = new(2, "Культура");

        public static OrganizationCategory Food { get; } = new(3, "Поесть");

        public static OrganizationCategory Municipality { get; } = new(4, "Муниципалитет");

        public static IEnumerable<OrganizationCategory> GetAll()
        {
            return new[] {Transport, Culture, Food, Municipality};
        }

        public static OrganizationCategory GetById(int id)
        {
            return GetAll().First(x => x.Id == id);
        }
    }
}