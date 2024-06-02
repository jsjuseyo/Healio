using System.ComponentModel.DataAnnotations.Schema;

namespace Healio.Shared
{
	public class T6Pemeriksaan : BaseModel
	{
		[Key]
		[PrimaryKey]
		public Guid IdPemeriksaan { get; set; } = NewId.NextGuid();
		[Required]
		public Guid? IdDokter { get; set; }
		public Guid? IdPasien { get; set; }
		public DateTime? TanggalPemeriksaan { get; set; }
		public string? TujuanPemeriksaan { get; set; }
		public string? Gejala { get; set; }
		public string? StatusPemeriksaan { get; set; }
		public string? StatusPembayaran { get; set; }
        public decimal? GrandTotal { get; set; }

        //Foreign Field Dokter
        public string? Dokter_Nama { get; set; }
        public string? Dokter_TempatLahir { get; set; }
        public DateTime? Dokter_TanggalLahir { get; set; }
        public string? Dokter_Alamat { get; set; }
        public string? Dokter_Kode { get; set; }
        public string? Dokter_Email { get; set; }


        //Foreign Field Pasien
        public string? Pasien_Nama { get; set; }
        public string? Pasien_NIK { get; set; }
        public string? Pasien_Alamat { get; set; }
        public string? Pasien_NoTelepon { get; set; }
        public string? Pasien_JenisKelamin { get; set; }
        public string? Pasien_Pekerjaan { get; set; }
        public string? Pasien_AlergiObat { get; set; }
        public string? NoTransaksi { get; set; }

		[ForeignKey(nameof(T6Pemeriksaan.IdDokter))]
		public T1Staf? T1Staf_Dokter { get; set; }

		[ForeignKey(nameof(T6Pemeriksaan.IdPasien))]
		public T0Pasien? T0Pasien { get; set; }
	}
}
