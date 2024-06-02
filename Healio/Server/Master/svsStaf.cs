using bwaPolaris.Server;
using bwaPolaris.Shared;
using Grpc.Core;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Syncfusion.Blazor;

namespace Healio.Server
{
    public class svsStaf : svpMasterStaf.svpMasterStafBase
    {
        private HealioDbContext _db;
        private readonly svsBaseService _bases;
        public svsStaf(HealioDbContext db)
        {
            _db = db;
            _bases = new svsBaseService(_db);
        }

        public override async Task<RplStaf> GetStaf(RqsStaf request, ServerCallContext context)
        {
            var dtStaf = await _db.T1Staf.ToListAsync();
            var hasil = new RplStaf();
            hasil.ListT1Staf.AddRange(dtStaf.Adapt<IEnumerable<RplStafById>>());
            return hasil;
        }

		public override async Task<RplStaf> GetStafByJabatan(RqsStafByJabatan request, ServerCallContext context)
		{
			var hasil = new RplStaf();
			var dtJabatan = _db.T0Jabatan.FirstOrDefault(x => x.Jabatan == request.Jabatan);
            if(dtJabatan is not null)
            {
				var data = (from jabatan in _db.T5Jabatan_Staf
							join staf in _db.T1Staf on jabatan.IdStaf equals staf.IdStaf
							where jabatan.IdJabatan == dtJabatan.IdJabatan
							select new { staf = staf }).ToList();
				foreach (var item in data)
				{
					hasil.ListT1Staf.Add(item.staf.Adapt<RplStafById>());
				}
			}
			return hasil;

		}

		public override async Task<RplT5Jabatan_StafById> GetT5Jabatan_StafById(RqsStafById request, ServerCallContext context)
		{
			try
			{
				var data = await _db.T5Jabatan_Staf.Where(e => e.IdStaf == Guid.Parse(request.IdStaf)).ToListAsync();
				var dataReply = data.Adapt<IEnumerable<PtmT5Jabatan_Staf>>();
				var hasil = new RplT5Jabatan_StafById();
				hasil.ListT5JabatanStaf.AddRange(dataReply);
				return hasil;
			}
			catch (Exception ex)
			{
				throw ex;
			}

		}

		public override async Task<RplWriteStaf> InsertStaf(RqsInsertStaf request, ServerCallContext context)
        {
            var Operator = await _bases.GetOperator(context.RequestHeaders.Get("id")?.Value);

            var data = await _bases.InsertHeader<T1Staf>(request.Adapt<T1Staf>(), Operator);
			await _bases.InsertDetil<T5Jabatan_Staf>(request.ListT5JabatanStaf.Adapt<IEnumerable<T5Jabatan_Staf>>(), Operator);

			await _db.SaveChangesAsync();


            return new RplWriteStaf { IsOK = true, Result = "Berhasil" };
        }

        public override async Task<RplWriteStaf> UpdateStaf(RqsUpdateStaf request, ServerCallContext context)
        {
            var Operator = await _bases.GetOperator(context.RequestHeaders.Get("id")?.Value);

            var data = await _bases.UpdateHeader<T1Staf>(request.Adapt<T1Staf>(), Operator);

			//Untuk update detil
			await _bases.UpdateDetil<T5Jabatan_Staf>(request.ListT5JabatanStaf.Adapt<IEnumerable<T5Jabatan_Staf>>(), Operator, "IdJabatanStaf", "IdStaf", data.IdStaf.ToString());
			await _bases.UpdateDetil<T9Privileges>(request.ListT9Privileges.Adapt<IEnumerable<T9Privileges>>(), Operator, "IdKonfigurasiAkses", "IdUser", data.Kode);


			await _db.SaveChangesAsync();

            return new RplWriteStaf { IsOK = true, Result = "Berhasil" };

        }

        public override async Task<RplWriteStaf> DeleteStaf(RqsDeleteStaf request, ServerCallContext context)
        {
            await _bases.DeleteHeader(request.Adapt<T1Staf>());
            await _db.SaveChangesAsync();

            return new RplWriteStaf { IsOK = true, Result = "Berhasil" };
        }
    }
}
