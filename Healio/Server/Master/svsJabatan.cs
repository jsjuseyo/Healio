using bwaPolaris.Server;
using Grpc.Core;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Healio.Server
{
	public class svsJabatan : svpMasterJabatan.svpMasterJabatanBase
    {
        private HealioDbContext _db;
        private readonly svsBaseService _bases;
        public svsJabatan(HealioDbContext db)
        {
            _db = db;
            _bases = new svsBaseService(_db);
        }

        public override async Task<RplJabatan> GetJabatan(RqsJabatan request, ServerCallContext context)
        {
            var dtJabatan = await _db.T0Jabatan.ToListAsync();
            var hasil = new RplJabatan();
            hasil.ListT0Jabatan.AddRange(dtJabatan.Adapt<IEnumerable<RplJabatanById>>());
            return hasil;
        }

        public override async Task<RplWriteJabatan> InsertJabatan(RqsInsertJabatan request, ServerCallContext context)
        {
            var Operator = await _bases.GetOperator(context.RequestHeaders.Get("id")?.Value);

            var data = await _bases.InsertHeader<T0Jabatan>(request.Adapt<T0Jabatan>(), Operator);
            await _db.SaveChangesAsync();


            return new RplWriteJabatan { IsOK = true, Result = "Berhasil" };
        }

        public override async Task<RplWriteJabatan> UpdateJabatan(RqsUpdateJabatan request, ServerCallContext context)
        {
            var Operator = await _bases.GetOperator(context.RequestHeaders.Get("id")?.Value);

            var data = await _bases.UpdateHeader<T0Jabatan>(request.Adapt<T0Jabatan>(), Operator);
            await _db.SaveChangesAsync();

            return new RplWriteJabatan { IsOK = true, Result = "Berhasil" };

        }

        public override async Task<RplWriteJabatan> DeleteJabatan(RqsDeleteJabatan request, ServerCallContext context)
        {
            await _bases.DeleteHeader(request.Adapt<T0Jabatan>());
            await _db.SaveChangesAsync();

            return new RplWriteJabatan { IsOK = true, Result = "Berhasil" };
        }
    }
}
