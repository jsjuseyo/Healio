using bwaPolaris.Data;
using Healio.Shared;
using Microsoft.EntityFrameworkCore;

namespace Healio.Server
{
    public class HealioDbContext : PolarisDbContext
    {
        public HealioDbContext(DbContextOptions<HealioDbContext> options) : base(options) { }

		public DbSet<T0Pasien> T0Pasien { get; set; }
		public DbSet<T0Diagnosa> T0Diagnosa { get; set; }
		public DbSet<T0Tindakan> T0Tindakan { get; set; }
		public DbSet<T0Obat> T0Obat { get; set; }
		public DbSet<T6Pemeriksaan> T6Pemeriksaan { get; set; }
		public DbSet<T6ResepObat> T6ResepObat { get; set; }
		public DbSet<T7Pemeriksaan_Diagnosa> T7Pemeriksaan_Diagnosa { get; set; }
		public DbSet<T7Pemeriksaan_Tindakan> T7Pemeriksaan_Tindakan { get; set; }
		public DbSet<T7ResepObat> T7ResepObat { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
