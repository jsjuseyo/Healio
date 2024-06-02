namespace Healio.Shared
{
	public class T0Tindakan : BaseModel
	{
		[Key]
		[PrimaryKey]
		public Guid IdTindakan { get; set; } = NewId.NextGuid();
		[Required]
		public string? Nama { get; set; }
		public string? Kode { get; set; }
		public decimal? Harga { get; set; }
	}
}
