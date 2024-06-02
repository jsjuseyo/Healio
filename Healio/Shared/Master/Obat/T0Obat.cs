
namespace Healio.Shared
{
	public class T0Obat : BaseModel
	{
		[Key]
		[PrimaryKey]
		public Guid IdObat { get; set; } = NewId.NextGuid();
		[Required]
		public string? Nama { get; set; }
		public string? Kode { get; set; }
		public decimal? Harga { get; set; }
	}
}
