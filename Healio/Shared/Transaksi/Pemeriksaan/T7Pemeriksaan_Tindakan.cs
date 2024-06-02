using System.ComponentModel.DataAnnotations.Schema;

namespace Healio.Shared
{
	public class T7Pemeriksaan_Tindakan : BaseModel
	{
		[Key]
		[PrimaryKey]
		public Guid IdDetilPemeriksaan { get; set; } = NewId.NextGuid();
		public Guid? IdPemeriksaan { get; set; }
		public Guid? IdTindakan { get; set; }

		//Foreign Field Tindakan
		public string? Tindakan_Nama { get; set; }
		public string? Tindakan_Kode { get; set; }
		public decimal? Tindakan_Harga { get; set; }


		[ForeignKey(nameof(T7Pemeriksaan_Tindakan.IdPemeriksaan))]
		public T6Pemeriksaan? T6Pemeriksaan { get; set; }

		[ForeignKey(nameof(T7Pemeriksaan_Tindakan.IdTindakan))]
		public T0Tindakan? T0Tindakan { get; set; }
	}
}
