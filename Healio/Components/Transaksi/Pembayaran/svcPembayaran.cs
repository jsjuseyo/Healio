using bwaPolaris.Components;
using Mapster;
using static bwaHealio.Shared.svpTransaksiPemeriksaan;

namespace Healio.Components;

public class svcPembayaran
{
	private svpTransaksiPemeriksaanClient _client { get; set; }
	private svcBaseService _bases { get; set; }
	public svcPembayaran(svcBaseService bases)
	{
		_bases = bases;
		_client = new svpTransaksiPemeriksaanClient(ClientChannel);
        Headers = new() { { "ID", _bases.User.IdUser.ToString() } };

    }

    public async Task<List<uimT6Pemeriksaan>> GetPemeriksaan()
	{
		var request = new RqsPemeriksaan();
		var reply = _client.GetPemeriksaanBelumLunas(request, Headers);
		var data = reply.ListT6Pemeriksaan.Adapt<List<uimT6Pemeriksaan>>();
		return data;
	}
	public async Task<List<uimT7Pemeriksaan_Diagnosa>> GetDetilPemeriksaan_Diagnosa(Guid idPemeriksaan)
	{
		var request = new RqsPemeriksaanById { IdPemeriksaan = idPemeriksaan.ToString() };
		var reply = _client.GetDetilPemeriksaanDiagnosaById(request, Headers);
		var data = reply.ListT7PemeriksaanDiagnosa.Adapt<List<uimT7Pemeriksaan_Diagnosa>>();
		return data;
	}

	public async Task<List<uimT7Pemeriksaan_Tindakan>> GetDetilPemeriksaan_Tindakan(Guid idPemeriksaan)
	{
		var request = new RqsPemeriksaanById { IdPemeriksaan = idPemeriksaan.ToString() };
		var reply = _client.GetDetilPemeriksaanTindakanById(request, Headers);
		var data = reply.ListT7PemeriksaanTindakan.Adapt<List<uimT7Pemeriksaan_Tindakan>>();
		return data;
	}

	public async Task<bool> UpdatePemeriksaan(uimT6Pemeriksaan data)
	{
		var request = data.Adapt<RqsUpdatePemeriksaan>();
		var reply = await _client.UpdatePemeriksaanAsync(request, Headers);
		return reply.IsOK;
	}
}
