using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2A.Entities.AppContext
{
    class AppDBContext:DbContext
    {
        public AppDBContext() : base("conn")
        {

        }
        public DbSet<Dosis> Doses { get; set; }
        public DbSet<Persona> Personas { get; set; }
    }
}
