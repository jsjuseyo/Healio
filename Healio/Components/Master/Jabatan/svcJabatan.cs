global using static Polaris.Utility.modVariabel;
using bwaPolaris.Components;
using Mapster;
using static bwaPolaris.Shared.svpMasterJabatan;

namespace Healio.Components
{
	public class svcJabatan
	{
		private svpMasterJabatanClient _client { get; set; }
		private svcBaseService _bases { get; set; }
		public svcJabatan(svcBaseService bases)
		{
			_bases = bases;
			_client = new svpMasterJabatanClient(ClientChannel);
            Headers = new() { { "ID", _bases.User.IdUser.ToString() } };
        }

        public async Task<List<T0Jabatan>> GetJabatan()
		{
			var request = new RqsJabatan();
			var reply = _client.GetJabatan(request, Headers);
			return reply.ListT0Jabatan.Adapt<List<T0Jabatan>>();
		}



		public async Task<bool> InsertJabatan(T0Jabatan data)
		{
			var request = data.Adapt<RqsInsertJabatan>();
			var reply = await _client.InsertJabatanAsync(request, Headers);
			return reply.IsOK;
		}

		public async Task<bool> UpdateJabatan(T0Jabatan data)
		{
			var request = data.Adapt<RqsUpdateJabatan>();
			var reply = await _client.UpdateJabatanAsync(request, Headers);
			return reply.IsOK;
		}

		public async Task<bool> DeleteJabatan(T0Jabatan data)
		{
			var request = data.Adapt<RqsDeleteJabatan>();
			var reply = await _client.DeleteJabatanAsync(request, Headers);
			return reply.IsOK;
		}
	}
}
