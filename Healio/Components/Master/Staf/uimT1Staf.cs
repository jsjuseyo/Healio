using bwaPolaris.Shared;

namespace Healio.Components
{
	public class uimT1Staf : T1Staf
	{
		public ICollection<T5Jabatan_Staf>? ListT5Jabatan_Staf { get; set; }

		public ICollection<T9Privileges>? ListT9Privileges { get; set; }
	}
}
