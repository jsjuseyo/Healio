using System.ComponentModel.DataAnnotations.Schema;

namespace Healio.Shared
{
	public class T7ResepObat : BaseModel
	{
		[Key]
		[PrimaryKey]
		public Guid IdDetilResepObat { get; set; } = NewId.NextGuid();
		public Guid? IdResepObat { get; set; }
		public Guid? IdObat { get; set; }
		public string? Dosis { get; set; }
		public string? Frekuensi { get; set; }
		public string? Durasi { get; set; }
		public int? Jumlah { get; set; }
		public decimal? Total { get; set; }

		//Foreign Field Obat
        public string? Obat_Nama { get; set; }
        public string? Obat_Kode { get; set; }
        public decimal? Obat_Harga { get; set; }

        [ForeignKey(nameof(T7ResepObat.IdResepObat))]
		public T6ResepObat? T6ResepObat { get; set; }

		[ForeignKey(nameof(T7ResepObat.IdObat))]
		public T0Obat? T0Obat { get; set; }
	}
}
