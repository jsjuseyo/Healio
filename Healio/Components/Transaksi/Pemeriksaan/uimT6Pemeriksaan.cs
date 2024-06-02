using Healio.Shared;

namespace Healio.Components;

public class uimT6Pemeriksaan : T6Pemeriksaan
{
	public string? Opsi { get; set; }
	[Required]
	public decimal? TinggiBadan { get; set; }
	[Required]
	public decimal? BeratBadan { get; set; }
	[Required]
	public string? TekananDarah { get; set; }
	public ICollection<uimT7Pemeriksaan_Diagnosa>? ListT7PemeriksaanDiagnosa { get; set; }
	public ICollection<uimT7Pemeriksaan_Tindakan>? ListT7PemeriksaanTindakan { get; set; }

}
