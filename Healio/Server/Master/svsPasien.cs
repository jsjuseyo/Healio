using bwaPolaris.Server;
using Grpc.Core;
using Healio.Shared;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Healio.Server
{
	public class svsPasien : svpMasterPasien.svpMasterPasienBase
	{
		private HealioDbContext _db;
		private readonly svsBaseService _bases;
		public svsPasien(HealioDbContext db)
		{
			_db = db;
			_bases = new svsBaseService(_db);
		}

		public override async Task<RplPasien> GetPasien(RqsPasien request, ServerCallContext context)
		{
			var dtPasien = await _db.T0Pasien.ToListAsync();
			var hasil = new RplPasien();
			hasil.ListT0Pasien.AddRange(dtPasien.Adapt<IEnumerable<RplPasienById>>());
			return hasil;
		}

		public override async Task<RplWritePasien> InsertPasien(RqsInsertPasien request, ServerCallContext context)
		{
            var Operator = await _bases.GetOperator(context.RequestHeaders.Get("id")?.Value);

            var data = await _bases.InsertHeader<T0Pasien>(request.Adapt<T0Pasien>(), Operator);
			await _db.SaveChangesAsync();


			return new RplWritePasien { IsOK = true, Result = "Berhasil" };
		}

		public override async Task<RplWritePasien> UpdatePasien(RqsUpdatePasien request, ServerCallContext context)
		{
            var Operator = await _bases.GetOperator(context.RequestHeaders.Get("id")?.Value);

            var data = await _bases.UpdateHeader<T0Pasien>(request.Adapt<T0Pasien>(), Operator);
			await _db.SaveChangesAsync();

			return new RplWritePasien { IsOK = true, Result = "Berhasil" };

		}

		public override async Task<RplWritePasien> DeletePasien(RqsDeletePasien request, ServerCallContext context)
		{
			await _bases.DeleteHeader(request.Adapt<T0Pasien>());
			await _db.SaveChangesAsync();

			return new RplWritePasien { IsOK = true, Result = "Berhasil" };
		}
	}
}
