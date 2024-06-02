using bwaPolaris.Components;
using bwaPolaris.Shared;
using Mapster;
using static bwaPolaris.Shared.svpMasterStaf;

namespace Healio.Components
{
    public class svcStaf
    {
        private svpMasterStafClient _client { get; set; }
        private svcBaseService _bases { get; set; }
        public svcStaf(svcBaseService bases)
        {
            _bases = bases;
            _client = new svpMasterStafClient(ClientChannel);
            Headers = new() { { "ID", _bases.User.IdUser.ToString() } };

        }

        public async Task<List<uimT1Staf>> GetStaf()
        {
            var request = new RqsStaf();
            var reply = _client.GetStaf(request, Headers);
            return reply.ListT1Staf.Adapt<List<uimT1Staf>>();
        }

		public async Task<List<uimT1Staf>> GetStafByJabatan(string jabatan)
		{
			var request = new RqsStafByJabatan { Jabatan = jabatan};
			var reply = _client.GetStafByJabatan(request, Headers);
			return reply.ListT1Staf.Adapt<List<uimT1Staf>>();
		}

		public async Task<List<T5Jabatan_Staf>> GetStaf_DetilJabatan(Guid idStaf)
		{
			var request = new RqsStafById { IdStaf = idStaf.ToString() };
			var reply = _client.GetT5Jabatan_StafById(request, Headers);
			return reply.ListT5JabatanStaf.Adapt<List<T5Jabatan_Staf>>();
		}

		public async Task<bool> InsertStaf(uimT1Staf data)
        {
            var request = data.Adapt<RqsInsertStaf>();
            var reply = await _client.InsertStafAsync(request, Headers);
            return reply.IsOK;
        }

        public async Task<bool> UpdateStaf(uimT1Staf data)
        {
            var request = data.Adapt<RqsUpdateStaf>();
            var reply = await _client.UpdateStafAsync(request, Headers);
            return reply.IsOK;
        }

        public async Task<bool> DeleteStaf(uimT1Staf data)
        {
            var request = data.Adapt<RqsDeleteStaf>();
            var reply = await _client.DeleteStafAsync(request, Headers);
            return reply.IsOK;
        }
    }
}
