using bwaPolaris.Components;
using Mapster;
using static bwaHealio.Shared.svpTransaksiPemeriksaan;

namespace Healio.Components;

public class svcPemeriksaan
{
	private svpTransaksiPemeriksaanClient _client { get; set; }
	private svcBaseService _bases { get; set; }
	public svcPemeriksaan(svcBaseService bases)
	{
		_bases = bases;
		_client = new svpTransaksiPemeriksaanClient(ClientChannel);
        Headers = new() { { "ID", _bases.User.IdUser.ToString() } };

    }

    public async Task<List<uimT6Pemeriksaan>> GetPemeriksaan()
	{
		var request = new RqsPemeriksaan();
		var reply = _client.GetPemeriksaan(request, Headers);
		var data = reply.ListT6Pemeriksaan.Adapt<List<uimT6Pemeriksaan>>();
		return data;
	}
	public async Task<List<uimT7Pemeriksaan_Diagnosa>> GetDetilPemeriksaan_DiagnosaByIdPasien(Guid idPasien)
	{
		var request = new RqsDetilPemeriksaanByIdPasien { IdPasien = idPasien.ToString()};
		var reply = _client.GetDetilPemeriksaanDiagnosaByIdPasien(request, Headers);
		var data = reply.ListT7PemeriksaanDiagnosa.Adapt<List<uimT7Pemeriksaan_Diagnosa>>();
		return data;
	}

	public async Task<List<uimT7Pemeriksaan_Tindakan>> GetDetilPemeriksaan_TindakanByIdPasien(Guid idPasien)
	{
		var request = new RqsDetilPemeriksaanByIdPasien { IdPasien = idPasien.ToString() };
		var reply = _client.GetDetilPemeriksaanTindakanByIdPasien(request, Headers);
		var data = reply.ListT7PemeriksaanTindakan.Adapt<List<uimT7Pemeriksaan_Tindakan>>();
		return data;
	}

	public async Task<bool> InsertPemeriksaan(uimT6Pemeriksaan data)
	{
		var request = data.Adapt<RqsInsertPemeriksaan>();
		var reply = await _client.InsertPemeriksaanAsync(request, Headers);
		return reply.IsOK;
	}

	public async Task<bool> UpdatePemeriksaan(uimT6Pemeriksaan data)
	{
		var request = data.Adapt<RqsUpdatePemeriksaan>();
		var reply = await _client.UpdatePemeriksaanAsync(request, Headers);
		return reply.IsOK;
	}

}
