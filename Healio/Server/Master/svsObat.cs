using bwaPolaris.Server;
using Grpc.Core;
using Healio.Shared;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Healio.Server;

public class svsObat : svpMasterObat.svpMasterObatBase
{
	private HealioDbContext _db;
	private readonly svsBaseService _bases;
	public svsObat(HealioDbContext db)
	{
		_db = db;
		_bases = new svsBaseService(_db);
	}

	public override async Task<RplObat> GetObat(RqsObat request, ServerCallContext context)
	{
		var dtObat = await _db.T0Obat.ToListAsync();
		var hasil = new RplObat();
		hasil.ListT0Obat.AddRange(dtObat.Adapt<IEnumerable<RplObatById>>());
		return hasil;
	}

	public override async Task<RplWriteObat> InsertObat(RqsInsertObat request, ServerCallContext context)
	{
        var Operator = await _bases.GetOperator(context.RequestHeaders.Get("id")?.Value);

        var data = await _bases.InsertHeader<T0Obat>(request.Adapt<T0Obat>(), Operator);
		await _db.SaveChangesAsync();


		return new RplWriteObat { IsOK = true, Result = "Berhasil" };
	}

	public override async Task<RplWriteObat> UpdateObat(RqsUpdateObat request, ServerCallContext context)
	{
        var Operator = await _bases.GetOperator(context.RequestHeaders.Get("id")?.Value);

        var data = await _bases.UpdateHeader<T0Obat>(request.Adapt<T0Obat>(), Operator);
		await _db.SaveChangesAsync();

		return new RplWriteObat { IsOK = true, Result = "Berhasil" };

	}

	public override async Task<RplWriteObat> DeleteObat(RqsDeleteObat request, ServerCallContext context)
	{
		await _bases.DeleteHeader(request.Adapt<T0Obat>());
		await _db.SaveChangesAsync();

		return new RplWriteObat { IsOK = true, Result = "Berhasil" };
	}
}
