using System.ComponentModel.DataAnnotations.Schema;

namespace Healio.Shared
{
	public class T7Pemeriksaan_Diagnosa : BaseModel
	{
		[Key]
		[PrimaryKey]
		public Guid IdDetilPemeriksaan { get; set; } = NewId.NextGuid();
		public Guid? IdPemeriksaan { get; set; }
		public Guid? IdDiagnosa { get; set; }

        //Foreign Field Diagnosa
        public string? Diagnosa_Nama { get; set; }
        public string? Diagnosa_Kode { get; set; }


        [ForeignKey(nameof(T7Pemeriksaan_Diagnosa.IdPemeriksaan))]
		public T6Pemeriksaan? T6Pemeriksaan { get; set; }

		[ForeignKey(nameof(T7Pemeriksaan_Diagnosa.IdDiagnosa))]
		public T0Diagnosa? T0Diagnosa { get; set; }
	}
}
