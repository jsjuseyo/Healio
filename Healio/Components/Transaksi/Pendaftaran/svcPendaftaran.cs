using bwaPolaris.Components;
using Healio.Shared;
using Mapster;
using static bwaHealio.Shared.svpTransaksiPemeriksaan;

namespace Healio.Components
{
	public class svcPendaftaran
	{
		private svpTransaksiPemeriksaanClient _client { get; set; }
		private svcBaseService _bases { get; set; }
		public svcPendaftaran(svcBaseService bases)
		{
			_bases = bases;
			_client = new svpTransaksiPemeriksaanClient(ClientChannel);
            Headers = new() { { "ID", _bases.User.IdUser.ToString() } };

        }

        public async Task<List<uimPendaftaran>> GetPendaftaran()
		{
			var request = new RqsPemeriksaan();
			var reply = _client.GetPemeriksaan(request, Headers);
			var data = reply.ListT6Pemeriksaan.Adapt<List<uimPendaftaran>>();
			return data;
		}

		public async Task<bool> InsertPendaftaran(uimPendaftaran data)
		{
			var request = data.Adapt<RqsInsertPemeriksaan>();
			var reply = await _client.InsertPemeriksaanAsync(request, Headers);
			return reply.IsOK;
		}

		public async Task<bool> UpdatePendaftaran(uimPendaftaran data)
		{
			var request = data.Adapt<RqsUpdatePemeriksaan>();
			var reply = await _client.UpdatePemeriksaanAsync(request, Headers);
			return reply.IsOK;
		}
	}
}
