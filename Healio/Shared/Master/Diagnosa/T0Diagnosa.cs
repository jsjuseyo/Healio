global using bwaPolaris.Shared;
global using MassTransit;
global using SQLite;
global using System.ComponentModel.DataAnnotations;

namespace Healio.Shared
{
	public class T0Diagnosa : BaseModel
	{
		[Key]
		[PrimaryKey]
		public Guid IdDiagnosa{ get; set; } = NewId.NextGuid();
		[Required]
		public string? Nama { get; set; }
		public string? Kode { get; set; }
	}
}
