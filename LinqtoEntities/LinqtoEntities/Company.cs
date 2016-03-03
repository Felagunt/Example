using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace LinqtoEntities
{
    class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }

        public ICollection<Phone> Phones { get; set; }
        public Company()
        {
            Phones = new List<Phone>();
        }
    }
}
