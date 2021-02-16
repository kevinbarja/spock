using Pentagono.Spock.Module.BusinessObjects;
using System.Linq;

namespace Pentagono.Spock.Module.DatabaseUpdate.Seeders
{
    class CitySeeder : Seeder
    {
        public CitySeeder(Updater updater) : base(updater) { }

        public override void Run()
        {
            bool isPopulated = (from c in Query<City>() select c).Any();

            if (!isPopulated)
            {
                new City(Session)
                {
                    Code = "SC",
                    Name = "Santa Cruz"
                };
                new City(Session)
                {
                    Code = "CH",
                    Name = "Chuquisaca"
                };
                new City(Session)
                {
                    Code = "LP",
                    Name = "La Paz"
                };
                new City(Session)
                {
                    Code = "CB",
                    Name = "Cochabamba"
                };
                new City(Session)
                {
                    Code = "OR",
                    Name = "Oruro"
                };
                new City(Session)
                {
                    Code = "PT",
                    Name = "Potosí"
                };
                new City(Session)
                {
                    Code = "TJ",
                    Name = "Tarija"
                };
                new City(Session)
                {
                    Code = "BE",
                    Name = "Beni"
                };
                new City(Session)
                {
                    Code = "PD",
                    Name = "Pando"
                };
            }
        }
    }
}
