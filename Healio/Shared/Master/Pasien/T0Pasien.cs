

namespace Healio.Shared
{
	public class T0Pasien : BaseModel
	{
		[Key]
		[PrimaryKey]
		public Guid IdPasien { get; set; } = NewId.NextGuid();
		[Required]
		public string? Nama { get; set; }
		[Required]
		public string? NIK { get; set; }
		[Required]
		public string? Alamat { get; set; }
		[Required]
		public string? NoTelepon { get; set; }
		public string? JenisKelamin { get; set; }
		public string? Pekerjaan { get; set; }
		public string? AlergiObat { get; set; }
		public string? Kode { get; set; }

	}
}
