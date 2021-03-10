using Pentagono.Spock.Module.BusinessObjects;
using System.Linq;

namespace Pentagono.Spock.Module.DatabaseUpdate.Seeders
{
    class EmployeeSeeder : Seeder
    {
        public EmployeeSeeder(Updater updater) : base(updater) { }

        public override void Run()
        {
            bool isPopulated = (from c in Query<Employee>() select c).Any();

            if (!isPopulated)
            {
                new Employee(Session)
                {
                   DocumentNumber = "8935712",
                   Name = "Kevin Eduardo Barja Hoyos",
                   //Lastname = "Barja Hoyos",
                   PhoneNumber = "75632256",
                   Email = "kevinbarja@gmail.com",
                   HomeAddress = "Doble vía a la Guardia KM 6, B/ 13 de Enero, C/ Manantial",
                   WorkEmail = Employee.KBARJA_IMCRUZ_EMAIL,
                   WorkPhone = "70931479"
                };
            }
        }
    }
}
