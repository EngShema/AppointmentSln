using Shered.Models;
using Microsoft.EntityFrameworkCore;

namespace Appointment.DAL.Data
{
    public class PostgreDBContext : DbContext
    {
        public PostgreDBContext(DbContextOptions<PostgreDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public virtual DbSet<AppointmentModel> Appointments { get; set; }
    }
}