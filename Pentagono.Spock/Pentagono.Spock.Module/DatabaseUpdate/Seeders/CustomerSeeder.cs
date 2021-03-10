using Pentagono.Spock.Module.BusinessObjects;
using System.Linq;

namespace Pentagono.Spock.Module.DatabaseUpdate.Seeders
{
    class CustomerSeeder : Seeder
    {
        public CustomerSeeder(Updater updater) : base(updater) { }

        public override void Run()
        {
            bool isPopulated = (from c in Query<Customer>() select c).Any();

            if (!isPopulated)
            {
                new Customer(Session)
                {
                   DocumentNumber = "5467453",
                   Name = "Pamela Acosta Fernandez",
//                   Lastname = "Acosta Fernandez",
                   PhoneNumber = "70931468",
                   Email = Customer.PACOSTA_EMAIL,
                   HomeAddress = "Av. Beni, entre 4to y 5to anillo. Condominio Santa María",
                   Notes = "Ninguna."
                };
            }
        }
    }
}
