using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("server=.;database=ConstructionDB;integrated security=true;");
            optionsBuilder.UseSqlServer("server=77.245.159.10\\MSSQLSERVER2019;database=ConstructionDB;user=ConstructionDB;password=Yunus6565*");

        }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SpecialProduct> SpecialProducts { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Mail> Mails { get; set; }

    }
}
