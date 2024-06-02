using Healio.Shared;

namespace Healio.Components;

public class uimT6ResepObat : T6ResepObat
{
	public string? Opsi { get;set; }
	public ICollection<uimT7ResepObat>? ListT7ResepObat { get; set; }
}
