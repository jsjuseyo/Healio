using bwaPolaris.Components;
using Healio.Shared;
using Mapster;
using static bwaHealio.Shared.svpMasterObat;

namespace Healio.Components;

public class svcObat
{
	private svpMasterObatClient _client { get; set; }
	private svcBaseService _bases { get; set; }
	public svcObat(svcBaseService bases)
	{
		_bases = bases;
		_client = new svpMasterObatClient(ClientChannel);
        Headers = new() { { "ID", _bases.User.IdUser.ToString() } };

    }

    public async Task<List<T0Obat>> GetObat()
	{
		var request = new RqsObat();
		var reply = _client.GetObat(request, Headers);
		return reply.ListT0Obat.Adapt<List<T0Obat>>();
	}



	public async Task<bool> InsertObat(T0Obat data)
	{
		var request = data.Adapt<RqsInsertObat>();
		var reply = await _client.InsertObatAsync(request, Headers);
		return reply.IsOK;
	}

	public async Task<bool> UpdateObat(T0Obat data)
	{
		var request = data.Adapt<RqsUpdateObat>();
		var reply = await _client.UpdateObatAsync(request, Headers);
		return reply.IsOK;
	}

	public async Task<bool> DeleteObat(T0Obat data)
	{
		var request = data.Adapt<RqsDeleteObat>();
		var reply = await _client.DeleteObatAsync(request, Headers);
		return reply.IsOK;
	}
}
