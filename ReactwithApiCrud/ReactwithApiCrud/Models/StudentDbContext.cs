using Microsoft.EntityFrameworkCore;

namespace ReactwithApiCrud.Models
{
    public class StudentDbContext : DbContext
    {
        //ctor oluştur
        public StudentDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Student> Student { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-PBFD0LU;  database=reactwithApiCrud; integrated security=true; TrustServerCertificate=true");
           // optionsBuilder.UseSqlServer("StudentDbContext");

            base.OnConfiguring(optionsBuilder);

        }
    }
}
