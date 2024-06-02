using bwaPolaris.Server;
using Grpc.Core;
using Healio.Shared;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Healio.Server;

public class svsTindakan : svpMasterTindakan.svpMasterTindakanBase
{
	private HealioDbContext _db;
	private readonly svsBaseService _bases;
	public svsTindakan(HealioDbContext db)
	{
		_db = db;
		_bases = new svsBaseService(_db);
	}

	public override async Task<RplTindakan> GetTindakan(RqsTindakan request, ServerCallContext context)
	{
		var dtTindakan = await _db.T0Tindakan.ToListAsync();
		var hasil = new RplTindakan();
		hasil.ListT0Tindakan.AddRange(dtTindakan.Adapt<IEnumerable<RplTindakanById>>());
		return hasil;
	}

	public override async Task<RplWriteTindakan> InsertTindakan(RqsInsertTindakan request, ServerCallContext context)
	{
        var Operator = await _bases.GetOperator(context.RequestHeaders.Get("id")?.Value);

        var data = await _bases.InsertHeader<T0Tindakan>(request.Adapt<T0Tindakan>(), Operator);
		await _db.SaveChangesAsync();


		return new RplWriteTindakan { IsOK = true, Result = "Berhasil" };
	}

	public override async Task<RplWriteTindakan> UpdateTindakan(RqsUpdateTindakan request, ServerCallContext context)
	{
        var Operator = await _bases.GetOperator(context.RequestHeaders.Get("id")?.Value);

        var data = await _bases.UpdateHeader<T0Tindakan>(request.Adapt<T0Tindakan>(), Operator);
		await _db.SaveChangesAsync();

		return new RplWriteTindakan { IsOK = true, Result = "Berhasil" };

	}

	public override async Task<RplWriteTindakan> DeleteTindakan(RqsDeleteTindakan request, ServerCallContext context)
	{
		await _bases.DeleteHeader(request.Adapt<T0Tindakan>());
		await _db.SaveChangesAsync();

		return new RplWriteTindakan { IsOK = true, Result = "Berhasil" };
	}
}
