using DesafioMottu.Models;
using Microsoft.EntityFrameworkCore;

namespace DesafioMottu.Data
{
    public class ChallengeDbContext : DbContext
    {
        public DbSet<DeliveryManModel> DeliveryMans { get; set; }
        public DbSet<MotorcycleModel> Motorcycles { get; set; }
        public DbSet<OrderModel> Orders { get; set; }
        public DbSet<RentalModel> Rentals { get; set; }
        public DbSet<UserAdminModel> UserAdmins { get; set; }

        // Adicione outras DbSet para outras entidades, se necessário

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Server=localhost;Port=5542;Database=ChallengeMottu;User Id=postgres;Password=mysecretpassword;");
            }
        }
    }
}

