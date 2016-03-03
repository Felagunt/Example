using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace LinqtoEntities
{
    class MyContextInitializer : DropCreateDatabaseAlways<PhoneContext>
    {
        protected override void Seed(PhoneContext db)
        {
            Company c1 = new Company { Name = "Samsung" };
            Company c2 = new Company { Name = "Apple" };
            db.Companies.Add(c1);
            db.Companies.Add(c2);
            db.SaveChanges();
            Country co1 = new Country { Name = "Korea" };
            Country co2 = new Country { Name = "Usa" };
            db.Countries.Add(co1);
            db.Countries.Add(co2);
            db.SaveChanges();

            Phone p1 = new Phone { Name = "Samsung Gelaxy S5", Price = 500, Company = c1 };
            Phone p2 = new Phone { Name = "Samsung Gelaxy S4", Price = 400, Company = c1 };
            Phone p3 = new Phone { Name = "iPhone 6", Price = 1000, Company = c2 };
            Phone p4 = new Phone { Name = "iPhone 5s", Price = 700, Company = c2 };
            db.Phones.AddRange(new List<Phone>() { p1, p2, p3, p4 });
            db.SaveChanges();
        }
    }
}
