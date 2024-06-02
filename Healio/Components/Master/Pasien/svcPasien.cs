using bwaPolaris.Components;
using Healio.Shared;
using Mapster;
using static bwaHealio.Shared.svpMasterPasien;

namespace Healio.Components;

public class svcPasien
{
	private svpMasterPasienClient _client { get; set; }
	private svcBaseService _bases { get; set; }
	public svcPasien(svcBaseService bases)
	{
		_bases = bases;
		_client = new svpMasterPasienClient(ClientChannel);
        Headers = new() { { "ID", _bases.User.IdUser.ToString() } };

    }

    public async Task<List<T0Pasien>> GetPasien()
	{
		var request = new RqsPasien();
		var reply = _client.GetPasien(request, Headers);
		return reply.ListT0Pasien.Adapt<List<T0Pasien>>();
	}

	public async Task<bool> InsertPasien(T0Pasien data)
	{
		var request = data.Adapt<RqsInsertPasien>();
		var reply = await _client.InsertPasienAsync(request, Headers);
		return reply.IsOK;
	}

	public async Task<bool> UpdatePasien(T0Pasien data)
	{
		var request = data.Adapt<RqsUpdatePasien>();
		var reply = await _client.UpdatePasienAsync(request, Headers);
		return reply.IsOK;
	}

	public async Task<bool> DeletePasien(T0Pasien data)
	{
		var request = data.Adapt<RqsDeletePasien>();
		var reply = await _client.DeletePasienAsync(request, Headers);
		return reply.IsOK;
	}
}
