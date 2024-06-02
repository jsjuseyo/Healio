using System.ComponentModel.DataAnnotations.Schema;

namespace Healio.Shared
{
	public class T6ResepObat : BaseModel
	{
		[Key]
		[PrimaryKey]
		public Guid IdResepObat { get; set; } = NewId.NextGuid();
		public Guid? IdPemeriksaan { get; set; }
		public Guid? IdDokter { get; set; }
		public Guid? IdPasien { get; set; }
		public DateTime? TanggalResep { get; set; }
		public string? Status { get; set; }
		public decimal? GrandTotal { get; set; }

        //Foreign Field Pemeriksaan
        public string? Referensi_NoPemeriksaan { get; set; }

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

        


        [ForeignKey(nameof(T6ResepObat.IdDokter))]
		public T1Staf? T1Staf_Dokter { get; set; }

		[ForeignKey(nameof(T6ResepObat.IdPasien))]
		public T0Pasien? T0Pasien { get; set; }

		[ForeignKey(nameof(T6ResepObat.IdPemeriksaan))]
		public T6Pemeriksaan? T6Pemeriksaan { get; set; }
	}
}
