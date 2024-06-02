using bwaPolaris.Server;
using Grpc.Core;
using Healio.Shared;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Healio.Server
{
	public class svsPemeriksaan : svpTransaksiPemeriksaan.svpTransaksiPemeriksaanBase
	{
		private HealioDbContext _db;
		private readonly svsBaseService _bases;
		public svsPemeriksaan(HealioDbContext db)
		{
			_db = db;
			_bases = new svsBaseService(_db);
		}

		public override async Task<RplPemeriksaan> GetPemeriksaan(RqsPemeriksaan request, ServerCallContext context)
		{
			var dtPemeriksaan = await _db.T6Pemeriksaan.Where(x => x.StatusPemeriksaan == "Belum Diperiksa").OrderBy(x =>x.WaktuInsert).ToListAsync();
			var hasil = new RplPemeriksaan();
			hasil.ListT6Pemeriksaan.AddRange(dtPemeriksaan.Adapt<IEnumerable<RplPemeriksaanById>>());
			return hasil;
		}

		public override async Task<RplPemeriksaan> GetPemeriksaanBelumLunas(RqsPemeriksaan request, ServerCallContext context)
		{
			var dtPemeriksaan = await _db.T6Pemeriksaan.Where(x => x.StatusPemeriksaan == "Selesai" && x.StatusPembayaran == "Belum Bayar").OrderBy(x => x.WaktuInsert).ToListAsync();
			var hasil = new RplPemeriksaan();
			hasil.ListT6Pemeriksaan.AddRange(dtPemeriksaan.Adapt<IEnumerable<RplPemeriksaanById>>());
			return hasil;
		}

		public override async Task<RplDetilPemeriksaanDiagnosaById> GetDetilPemeriksaanDiagnosaById(RqsPemeriksaanById request, ServerCallContext context)
		{
			var dtPemeriksaan = await _db.T7Pemeriksaan_Diagnosa.Where(x => x.IdPemeriksaan == Guid.Parse(request.IdPemeriksaan)).ToListAsync();
			var hasil = new RplDetilPemeriksaanDiagnosaById();
			hasil.ListT7PemeriksaanDiagnosa.AddRange(dtPemeriksaan.Adapt<IEnumerable<PtmDetilPemeriksaanDiagnosa>>());
			return hasil;
		}

		public override async Task<RplDetilPemeriksaanTindakanById> GetDetilPemeriksaanTindakanById(RqsPemeriksaanById request, ServerCallContext context)
		{
			var dtPemeriksaan = await _db.T7Pemeriksaan_Tindakan.Where(x => x.IdPemeriksaan == Guid.Parse(request.IdPemeriksaan)).ToListAsync();
			var hasil = new RplDetilPemeriksaanTindakanById();
			hasil.ListT7PemeriksaanTindakan.AddRange(dtPemeriksaan.Adapt<IEnumerable<PtmDetilPemeriksaanTindakan>>());
			return hasil;
		}
		public override async Task<RplDetilPemeriksaanDiagnosaById> GetDetilPemeriksaanDiagnosaByIdPasien(RqsDetilPemeriksaanByIdPasien request, ServerCallContext context)
		{
			var dtPemeriksaan = await _db.T7Pemeriksaan_Diagnosa.Where(x => x.T6Pemeriksaan.IdPasien == Guid.Parse(request.IdPasien)).ToListAsync();
			var hasil = new RplDetilPemeriksaanDiagnosaById();
			hasil.ListT7PemeriksaanDiagnosa.AddRange(dtPemeriksaan.Adapt<IEnumerable<PtmDetilPemeriksaanDiagnosa>>());
			return hasil;
		}

		public override async Task<RplDetilPemeriksaanTindakanById> GetDetilPemeriksaanTindakanByIdPasien(RqsDetilPemeriksaanByIdPasien request, ServerCallContext context)
		{
			var dtPemeriksaan = await _db.T7Pemeriksaan_Tindakan.Where(x => x.T6Pemeriksaan.IdPasien == Guid.Parse(request.IdPasien)).ToListAsync();
			var hasil = new RplDetilPemeriksaanTindakanById();
			hasil.ListT7PemeriksaanTindakan.AddRange(dtPemeriksaan.Adapt<IEnumerable<PtmDetilPemeriksaanTindakan>>());
			return hasil;
		}

		public async Task<string> GenerateIdTransaksi()
		{
			var kodeTahunBulan = DateTime.Now.ToString("yyMM");
			string sequenceGenerated = await GetSequenceTerbaruIdTransaksi(kodeTahunBulan);

			var idTransaksiGenerated = $"PM-{kodeTahunBulan}-{sequenceGenerated}";
			return idTransaksiGenerated;
		}

		public async Task<string> GetSequenceTerbaruIdTransaksi(string kodeTahunBulan)
		{
			var idTransaksiTerakhir = await _db.Set<T6Pemeriksaan>()
										.Select(d => d.NoTransaksi)
										.OrderByDescending(t => t)
										.FirstOrDefaultAsync();

			if (idTransaksiTerakhir is null)
			{
				return "0001";
			}

			var stringSequenceTerakhir = idTransaksiTerakhir.Substring(idTransaksiTerakhir.Length - 4);
			var intSequence = int.Parse(stringSequenceTerakhir);
			return (intSequence + 1).ToString().PadLeft(4, '0');

		}

		public override async Task<RplWritePemeriksaan> InsertPemeriksaan(RqsInsertPemeriksaan request, ServerCallContext context)
		{
            var Operator = await _bases.GetOperator(context.RequestHeaders.Get("id")?.Value);

            var dtPemeriksaan = request.Adapt<T6Pemeriksaan>();
			dtPemeriksaan.StatusPemeriksaan = "Belum Diperiksa";
			dtPemeriksaan.StatusPembayaran = "Belum Bayar";
			dtPemeriksaan.TanggalPemeriksaan = DateTime.Now;
			dtPemeriksaan.NoTransaksi = await GenerateIdTransaksi();

			//Perlu auto input ke master pasien jika pasien belum pernah periksa
			await _bases.InsertHeader<T6Pemeriksaan>(dtPemeriksaan, Operator);

			await _db.SaveChangesAsync();
			return new RplWritePemeriksaan { IsOK = true, Result = "Berhasil" };
		}

		public override async Task<RplWritePemeriksaan> UpdatePemeriksaan(RqsUpdatePemeriksaan request, ServerCallContext context)
		{
            var Operator = await _bases.GetOperator(context.RequestHeaders.Get("id")?.Value);
            var data = request.Adapt<T6Pemeriksaan>();
			if(data.Keterangan is not null || !string.IsNullOrWhiteSpace(data.Keterangan))
			{
				data.StatusPemeriksaan = "Selesai";
			}
			 await _bases.UpdateHeader<T6Pemeriksaan>(data, Operator);

			//Untuk update detil
			await _bases.UpdateDetil<T7Pemeriksaan_Diagnosa>(request.ListT7PemeriksaanDiagnosa.Adapt<IEnumerable<T7Pemeriksaan_Diagnosa>>(), Operator, "IdDetilPemeriksaan", "IdPemeriksaan", request.IdPemeriksaan);
			await _bases.UpdateDetil<T7Pemeriksaan_Tindakan>(request.ListT7PemeriksaanTindakan.Adapt<IEnumerable<T7Pemeriksaan_Tindakan>>(), Operator, "IdDetilPemeriksaan", "IdPemeriksaan", request.IdPemeriksaan);


			await _db.SaveChangesAsync();

			return new RplWritePemeriksaan { IsOK = true, Result = "Berhasil" };
		}

		public override async Task<RplWritePemeriksaan> DeletePemeriksaan(RqsDeletePemeriksaan request, ServerCallContext context)
		{
			await _bases.DeleteHeader(request.Adapt<T6Pemeriksaan>());
			_db.T7Pemeriksaan_Diagnosa.RemoveRange(request.ListT7PemeriksaanDiagnosa.Adapt<IList<T7Pemeriksaan_Diagnosa>>());
			_db.T7Pemeriksaan_Tindakan.RemoveRange(request.ListT7PemeriksaanTindakan.Adapt<IList<T7Pemeriksaan_Tindakan>>());
			await _db.SaveChangesAsync();

			return new RplWritePemeriksaan { IsOK = true, Result = "Berhasil" };
		}
	}
}
