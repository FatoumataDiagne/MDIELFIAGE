using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDIELFIAGE
{
    internal class DBScolaire : DbContext
    {
        public DBScolaire() : base("connectionIAGE")
        {

        }
        public DbSet<Classe> Classe { get; set; }
        public DbSet<Etudiant> Etudiant { get; set; }


    }
}
