using bwaPolaris.Components;
using Healio.Shared;
using Mapster;
using static bwaHealio.Shared.svpMasterDiagnosa;

namespace Healio.Components
{
	public class svcDiagnosa
	{
		private svpMasterDiagnosaClient _client { get; set; }
		private svcBaseService _bases { get; set; }
		public svcDiagnosa(svcBaseService bases)
		{
			_bases = bases;
			_client = new svpMasterDiagnosaClient(ClientChannel);
            Headers = new() { { "ID", _bases.User.IdUser.ToString() } };
        }

        public async Task<List<T0Diagnosa>> GetDiagnosa()
		{
			var request = new RqsDiagnosa();
			var reply = _client.GetDiagnosa(request, Headers);
			return reply.ListT0Diagnosa.Adapt<List<T0Diagnosa>>();
		}



		public async Task<bool> InsertDiagnosa(T0Diagnosa data)
		{
			var request = data.Adapt<RqsInsertDiagnosa>();
			var reply = await _client.InsertDiagnosaAsync(request, Headers);
			return reply.IsOK;
		}

		public async Task<bool> UpdateDiagnosa(T0Diagnosa data)
		{
			var request = data.Adapt<RqsUpdateDiagnosa>();
			var reply = await _client.UpdateDiagnosaAsync(request, Headers);
			return reply.IsOK;
		}

		public async Task<bool> DeleteDiagnosa(T0Diagnosa data)
		{
			var request = data.Adapt<RqsDeleteDiagnosa>();
			var reply = await _client.DeleteDiagnosaAsync(request, Headers);
			return reply.IsOK;
		}
	}
}
