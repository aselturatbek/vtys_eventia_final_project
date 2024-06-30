using System.Data.Entity;

namespace eventia_database.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Users> Users { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>().HasKey(u => u.UserID); // UserID alanını anahtar olarak belirtin
            // Diğer konfigürasyonlar buraya eklenebilir
        }
        public DbSet<Event> Event { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Review> Review { get; set; }
        public DbSet<Attendance> Attendance { get; set; }
        // Diğer DbSet'ler buraya eklenebilir (ör. Category, Review, Attendance vb.).

        public ApplicationDbContext() : base("name=dbcontext")
        {
        }
    }

}