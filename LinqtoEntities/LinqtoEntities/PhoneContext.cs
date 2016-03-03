using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace LinqtoEntities
{
    class PhoneContext : DbContext
    {
        static PhoneContext()
        {
            Database.SetInitializer(new MyContextInitializer());
        }
        public PhoneContext()
            :base("DefaultConnection")
        { }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Country> Countries { get; set; }
    }
}
