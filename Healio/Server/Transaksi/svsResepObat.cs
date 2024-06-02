using bwaPolaris.Server;
using Grpc.Core;
using Healio.Components.Transaksi.Pemeriksaan;
using Healio.Shared;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Healio.Server;

public class svsResepObat : svpTransaksiResepObat.svpTransaksiResepObatBase
{
	private HealioDbContext _db;
	private readonly svsBaseService _bases;
	public svsResepObat(HealioDbContext db)
	{
		_db = db;
		_bases = new svsBaseService(_db);
	}

	public override async Task<RplResepObat> GetResepObat(RqsResepObat request, ServerCallContext context)
	{
		var dtResepObat = await _db.T6ResepObat.Where(x => x.Status == "Belum Dilayani").OrderBy(x => x.WaktuInsert).ToListAsync();
		var hasil = new RplResepObat();
		hasil.ListT6ResepObat.AddRange(dtResepObat.Adapt<IEnumerable<RplResepObatById>>());
		return hasil;
	}

	public override async Task<RplResepObat> GetResepObatByIdPemeriksaan(RqsResepObatByIdPemeriksaan request, ServerCallContext context)
	{
		var dtResepObat = await _db.T6ResepObat.Where(x => x.IdPemeriksaan == Guid.Parse(request.IdPemeriksaan)).OrderBy(x => x.WaktuInsert).ToListAsync();
		var hasil = new RplResepObat();
		hasil.ListT6ResepObat.AddRange(dtResepObat.Adapt<IEnumerable<RplResepObatById>>());
		return hasil;
	}

	public override async Task<RplDetilResepObatById> GetDetilResepObatById(RqsDetilResepObatById request, ServerCallContext context)
	{
		var dtResepObat = await _db.T7ResepObat.Where(x => x.IdResepObat == Guid.Parse(request.IdResepObat)).ToListAsync();
		var hasil = new RplDetilResepObatById();
		hasil.ListT7ResepObat.AddRange(dtResepObat.Adapt<IEnumerable<PtmDetilResepObat>>());
		return hasil;
	}
	public override async Task<RplDetilResepObatById> GetDetilResepObatByIdPasien(RqsResepObatByIdPasien request, ServerCallContext context)
	{
		var dtResepObat = await _db.T7ResepObat.Where(x => x.T6ResepObat.IdPasien == Guid.Parse(request.IdPasien)).ToListAsync();
		var hasil = new RplDetilResepObatById();
		hasil.ListT7ResepObat.AddRange(dtResepObat.Adapt<IEnumerable<PtmDetilResepObat>>());
		return hasil;
	}

	public async Task<string> GenerateIdTransaksi()
	{
		var kodeTahunBulan = DateTime.Now.ToString("yyMM");
		string sequenceGenerated = await GetSequenceTerbaruIdTransaksi(kodeTahunBulan);

		var idTransaksiGenerated = $"RO-{kodeTahunBulan}-{sequenceGenerated}";
		return idTransaksiGenerated;
	}

	public async Task<string> GetSequenceTerbaruIdTransaksi(string kodeTahunBulan)
	{
		var idTransaksiTerakhir = await _db.Set<T6ResepObat>()
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

	public override async Task<RplWriteResepObat> InsertResepObat(RqsInsertResepObat request, ServerCallContext context)
	{
        var Operator = await _bases.GetOperator(context.RequestHeaders.Get("id")?.Value);

        var dtResepObat = request.Adapt<T6ResepObat>();
		dtResepObat.Status = "Belum Dilayani";
		dtResepObat.NoTransaksi = await GenerateIdTransaksi();
		await _bases.InsertHeader<T6ResepObat>(dtResepObat, Operator);

		await _bases.UpdateDetil<T7ResepObat>(request.ListT7ResepObat.Adapt<IEnumerable<T7ResepObat>>(), Operator, "IdDetilResepObat", "IdResepObat", request.IdResepObat);

		await _db.SaveChangesAsync();
		return new RplWriteResepObat { IsOK = true, Result = "Berhasil" };
	}

	public override async Task<RplWriteResepObat> UpdateResepObat(RqsUpdateResepObat request, ServerCallContext context)
	{
        var Operator = await _bases.GetOperator(context.RequestHeaders.Get("id")?.Value);

        var dtResepObat = request.Adapt<T6ResepObat>();

		await _bases.UpdateHeader<T6ResepObat>(dtResepObat, Operator);

		await _bases.UpdateDetil<T7ResepObat>(request.ListT7ResepObat.Adapt<IEnumerable<T7ResepObat>>(), Operator, "IdDetilResepObat", "IdResepObat", request.IdResepObat);

		await _db.SaveChangesAsync();
		return new RplWriteResepObat { IsOK = true, Result = "Berhasil" };
	}

	public override async Task<RplWriteResepObat> DeleteResepObat(RqsDeleteResepObat request, ServerCallContext context)
	{
		await _bases.DeleteHeader(request.Adapt<T6ResepObat>());
		_db.T7ResepObat.RemoveRange(request.ListT7ResepObat.Adapt<IList<T7ResepObat>>());
		await _db.SaveChangesAsync();

		return new RplWriteResepObat { IsOK = true, Result = "Berhasil" };
	}


}
