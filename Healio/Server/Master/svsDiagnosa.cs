global using bwaHealio.Shared;
using bwaPolaris.Server;
using Grpc.Core;
using Healio.Shared;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Healio.Server
{
	public class svsDiagnosa : svpMasterDiagnosa.svpMasterDiagnosaBase
	{
		private HealioDbContext _db;
		private readonly svsBaseService _bases;
		public svsDiagnosa(HealioDbContext db)
		{
			_db = db;
			_bases = new svsBaseService(_db);
		}

		public override async Task<RplDiagnosa> GetDiagnosa(RqsDiagnosa request, ServerCallContext context)
		{
			var dtDiagnosa = await _db.T0Diagnosa.ToListAsync();
			var hasil = new RplDiagnosa();
			hasil.ListT0Diagnosa.AddRange(dtDiagnosa.Adapt<IEnumerable<RplDiagnosaById>>());
			return hasil;
		}

		public override async Task<RplWriteDiagnosa> InsertDiagnosa(RqsInsertDiagnosa request, ServerCallContext context)
		{
            var Operator = await _bases.GetOperator(context.RequestHeaders.Get("id")?.Value);
            var data = await _bases.InsertHeader<T0Diagnosa>(request.Adapt<T0Diagnosa>(), Operator);
			await _db.SaveChangesAsync();


			return new RplWriteDiagnosa { IsOK = true, Result = "Berhasil" };
		}

		public override async Task<RplWriteDiagnosa> UpdateDiagnosa(RqsUpdateDiagnosa request, ServerCallContext context)
		{
            var Operator = await _bases.GetOperator(context.RequestHeaders.Get("id")?.Value);

            var data = await _bases.UpdateHeader<T0Diagnosa>(request.Adapt<T0Diagnosa>(), Operator);
			await _db.SaveChangesAsync();

			return new RplWriteDiagnosa { IsOK = true, Result = "Berhasil" };

		}

		public override async Task<RplWriteDiagnosa> DeleteDiagnosa(RqsDeleteDiagnosa request, ServerCallContext context)
		{
			await _bases.DeleteHeader(request.Adapt<T0Diagnosa>());
			await _db.SaveChangesAsync();

			return new RplWriteDiagnosa { IsOK = true, Result = "Berhasil" };
		}
	}
}
