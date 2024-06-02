using bwaPolaris.Components;
using Mapster;
using static bwaHealio.Shared.svpTransaksiResepObat;

namespace Healio.Components;

public class svcResepObat
{
	private svpTransaksiResepObatClient _client { get; set; }
	private svcBaseService _bases { get; set; }
	public svcResepObat(svcBaseService bases)
	{
		_bases = bases;
		_client = new svpTransaksiResepObatClient(ClientChannel);
        Headers = new() { { "ID", _bases.User.IdUser.ToString() } };
    }

    public async Task<List<uimT6ResepObat>> GetResepObat()
	{
		var request = new RqsResepObat();
		var reply = _client.GetResepObat(request, Headers);
		var data = reply.ListT6ResepObat.Adapt<List<uimT6ResepObat>>();
		return data;
	}
	public async Task<List<uimT6ResepObat>> GetResepObatByIdPemeriksaan(Guid idPemeriksaan)
	{
		var request = new RqsResepObatByIdPemeriksaan { IdPemeriksaan = idPemeriksaan.ToString() };
		var reply = _client.GetResepObatByIdPemeriksaan(request, Headers);
		var data = reply.ListT6ResepObat.Adapt<List<uimT6ResepObat>>();
		return data;
	}

	public async Task<List<uimT7ResepObat>> GetDetilResepObat(Guid idResepObat)
	{
		var request = new RqsDetilResepObatById { IdResepObat = idResepObat.ToString() };
		var reply = _client.GetDetilResepObatById(request, Headers);
		var data = reply.ListT7ResepObat.Adapt<List<uimT7ResepObat>>();
		return data;
	}

	public async Task<List<uimT7ResepObat>> GetDetilResepObatByIdPasien(Guid idPasien)
	{
		var request = new RqsResepObatByIdPasien { IdPasien = idPasien.ToString() };
		var reply = _client.GetDetilResepObatByIdPasien(request, Headers);
		var data = reply.ListT7ResepObat.Adapt<List<uimT7ResepObat>>();
		return data;
	}

	public async Task<bool> InsertResepObat(uimT6ResepObat data)
	{
		var request = data.Adapt<RqsInsertResepObat>();
		var reply = await _client.InsertResepObatAsync(request, Headers);
		return reply.IsOK;
	}

	public async Task<bool> UpdateResepObat(uimT6ResepObat data)
	{
		var request = data.Adapt<RqsUpdateResepObat>();
		var reply = await _client.UpdateResepObatAsync(request, Headers);
		return reply.IsOK;
	}

	public async Task<bool> DeleteResepObat(uimT6ResepObat data)
	{
		var request = data.Adapt<RqsDeleteResepObat>();
		var reply = await _client.DeleteResepObatAsync(request, Headers);
		return reply.IsOK;
	}
}
