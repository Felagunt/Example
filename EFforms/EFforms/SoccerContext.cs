using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EFforms
{
    class SoccerContext : DbContext
    {
        public SoccerContext()
            :base("DefaultConnestion")
        { }
        public DbSet<Player> Players { get; set; }
    }
}
