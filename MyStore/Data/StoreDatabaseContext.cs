using MyStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyStore.Data
{
    public class StoreDatabaseContext : DbContext
    {
        public StoreDatabaseContext() : base("Server=(localdb)\\ProjectsV12;AttachDbFilename=H:\\D\\Curs .Net 2015\\MyProjects\\ProiectFinal\\MyStore.mdf; Integrated Security=Yes;")
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CartProduct> CartProducts { get; set; }
    }
}
