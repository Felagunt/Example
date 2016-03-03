using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace LinqtoEntities
{
    class Phone
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
