using OtoYedekParca.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace OtoYedekParca.Dataaccess.Concrete.Contexts
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {

        public DbSet<Marka> Markalar { get; set; }
        public DbSet<Tip> Tipler { get; set; }
        public DbSet<Model> Modeller { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ServerVersion version = new MySqlServerVersion(new Version(8, 0, 30));
            // optionsBuilder.UseMySql(@"Server=fet.com.tr;Port=3306;Database=fetcomtr_katalog2;Uid=fetcomtr_katalog2;Pwd=UmutPro123!;", version);
            optionsBuilder.UseMySql(@"Server=localhost;Port=3306;Database=otoparca;Uid=root;Pwd=1525354555;", version);
        }

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            base.OnModelCreating(modelBuilder);
        }
    }
}