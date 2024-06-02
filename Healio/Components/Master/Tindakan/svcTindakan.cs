using bwaPolaris.Components;
using Healio.Shared;
using Mapster;
using static bwaHealio.Shared.svpMasterTindakan;

namespace Healio.Components;

public class svcTindakan
{
	private svpMasterTindakanClient _client { get; set; }
	private svcBaseService _bases { get; set; }
	public svcTindakan(svcBaseService bases)
	{
		_bases = bases;
		_client = new svpMasterTindakanClient(ClientChannel);
        Headers = new() { { "ID", _bases.User.IdUser.ToString() } };

    }

    public async Task<List<T0Tindakan>> GetTindakan()
	{
		var request = new RqsTindakan();
		var reply = _client.GetTindakan(request, Headers);
		return reply.ListT0Tindakan.Adapt<List<T0Tindakan>>();
	}



	public async Task<bool> InsertTindakan(T0Tindakan data)
	{
		var request = data.Adapt<RqsInsertTindakan>();
		var reply = await _client.InsertTindakanAsync(request, Headers);
		return reply.IsOK;
	}

	public async Task<bool> UpdateTindakan(T0Tindakan data)
	{
		var request = data.Adapt<RqsUpdateTindakan>();
		var reply = await _client.UpdateTindakanAsync(request, Headers);
		return reply.IsOK;
	}

	public async Task<bool> DeleteTindakan(T0Tindakan data)
	{
		var request = data.Adapt<RqsDeleteTindakan>();
		var reply = await _client.DeleteTindakanAsync(request, Headers);
		return reply.IsOK;
	}
}
