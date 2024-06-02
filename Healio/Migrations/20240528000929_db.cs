using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Healio.Migrations
{
    /// <inheritdoc />
    public partial class db : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T0Diagnosa",
                columns: table => new
                {
                    IdDiagnosa = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Keterangan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WaktuInsert = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WaktuProses = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Operator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Synchronise = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T0Diagnosa", x => x.IdDiagnosa);
                });

            migrationBuilder.CreateTable(
                name: "T0Form",
                columns: table => new
                {
                    IdForm = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdParent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Form = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true),
                    HasChild = table.Column<bool>(type: "bit", nullable: false),
                    IsAbleToReadData = table.Column<bool>(type: "bit", nullable: false),
                    IsAbleToAddData = table.Column<bool>(type: "bit", nullable: false),
                    IsAbleToEditData = table.Column<bool>(type: "bit", nullable: false),
                    IsAbleToDeleteData = table.Column<bool>(type: "bit", nullable: false),
                    Keterangan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WaktuInsert = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WaktuProses = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Operator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Synchronise = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T0Form", x => x.IdForm);
                });

            migrationBuilder.CreateTable(
                name: "T0Jabatan",
                columns: table => new
                {
                    IdJabatan = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Jabatan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Keterangan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WaktuInsert = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WaktuProses = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Operator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Synchronise = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T0Jabatan", x => x.IdJabatan);
                });

            migrationBuilder.CreateTable(
                name: "T0Obat",
                columns: table => new
                {
                    IdObat = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Harga = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Keterangan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WaktuInsert = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WaktuProses = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Operator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Synchronise = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T0Obat", x => x.IdObat);
                });

            migrationBuilder.CreateTable(
                name: "T0Pasien",
                columns: table => new
                {
                    IdPasien = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NIK = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Alamat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoTelepon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JenisKelamin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pekerjaan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlergiObat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Keterangan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WaktuInsert = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WaktuProses = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Operator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Synchronise = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T0Pasien", x => x.IdPasien);
                });

            migrationBuilder.CreateTable(
                name: "T0Tindakan",
                columns: table => new
                {
                    IdTindakan = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Harga = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Keterangan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WaktuInsert = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WaktuProses = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Operator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Synchronise = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T0Tindakan", x => x.IdTindakan);
                });

            migrationBuilder.CreateTable(
                name: "T1AtributForm",
                columns: table => new
                {
                    IdAtributForm = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdForm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Field = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TampilRekapitulasi = table.Column<bool>(type: "bit", nullable: false),
                    TampilDetil = table.Column<bool>(type: "bit", nullable: false),
                    CaptionRekapitulasi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CaptionDetil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TampilMobile = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T1AtributForm", x => x.IdAtributForm);
                });

            migrationBuilder.CreateTable(
                name: "T1Staf",
                columns: table => new
                {
                    IdStaf = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TempatLahir = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TanggalLahir = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Alamat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Keterangan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WaktuInsert = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WaktuProses = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Operator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Synchronise = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T1Staf", x => x.IdStaf);
                });

            migrationBuilder.CreateTable(
                name: "T9DataOption",
                columns: table => new
                {
                    IdDataOption = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Entity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataOption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Keterangan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WaktuInsert = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WaktuProses = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Operator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Synchronise = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T9DataOption", x => x.IdDataOption);
                });

            migrationBuilder.CreateTable(
                name: "T9User",
                columns: table => new
                {
                    IdUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Keterangan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WaktuInsert = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WaktuProses = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Operator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Synchronise = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T9User", x => x.IdUser);
                });

            migrationBuilder.CreateTable(
                name: "T5Jabatan_Staf",
                columns: table => new
                {
                    IdJabatanStaf = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdStaf = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdJabatan = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Jabatan = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T5Jabatan_Staf", x => x.IdJabatanStaf);
                    table.ForeignKey(
                        name: "FK_T5Jabatan_Staf_T0Jabatan_IdJabatan",
                        column: x => x.IdJabatan,
                        principalTable: "T0Jabatan",
                        principalColumn: "IdJabatan");
                    table.ForeignKey(
                        name: "FK_T5Jabatan_Staf_T1Staf_IdStaf",
                        column: x => x.IdStaf,
                        principalTable: "T1Staf",
                        principalColumn: "IdStaf");
                });

            migrationBuilder.CreateTable(
                name: "T6Pemeriksaan",
                columns: table => new
                {
                    IdPemeriksaan = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdDokter = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdPasien = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TanggalPemeriksaan = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TujuanPemeriksaan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gejala = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusPemeriksaan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusPembayaran = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GrandTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Dokter_Nama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dokter_TempatLahir = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dokter_TanggalLahir = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Dokter_Alamat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dokter_Kode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dokter_Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pasien_Nama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pasien_NIK = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pasien_Alamat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pasien_NoTelepon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pasien_JenisKelamin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pasien_Pekerjaan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pasien_AlergiObat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoTransaksi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Keterangan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WaktuInsert = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WaktuProses = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Operator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Synchronise = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T6Pemeriksaan", x => x.IdPemeriksaan);
                    table.ForeignKey(
                        name: "FK_T6Pemeriksaan_T0Pasien_IdPasien",
                        column: x => x.IdPasien,
                        principalTable: "T0Pasien",
                        principalColumn: "IdPasien");
                    table.ForeignKey(
                        name: "FK_T6Pemeriksaan_T1Staf_IdDokter",
                        column: x => x.IdDokter,
                        principalTable: "T1Staf",
                        principalColumn: "IdStaf",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T9Privileges",
                columns: table => new
                {
                    IdKonfigurasiAkses = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdUser = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdForm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAbleToReadData = table.Column<bool>(type: "bit", nullable: false),
                    IsAbleToAddData = table.Column<bool>(type: "bit", nullable: false),
                    IsAbleToEditData = table.Column<bool>(type: "bit", nullable: false),
                    IsAbleToDeleteData = table.Column<bool>(type: "bit", nullable: false),
                    Keterangan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WaktuInsert = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WaktuProses = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Operator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Synchronise = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T9Privileges", x => x.IdKonfigurasiAkses);
                    table.ForeignKey(
                        name: "FK_T9Privileges_T9User_IdUser",
                        column: x => x.IdUser,
                        principalTable: "T9User",
                        principalColumn: "IdUser");
                });

            migrationBuilder.CreateTable(
                name: "T6ResepObat",
                columns: table => new
                {
                    IdResepObat = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdPemeriksaan = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdDokter = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdPasien = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TanggalResep = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GrandTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Referensi_NoPemeriksaan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dokter_Nama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dokter_TempatLahir = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dokter_TanggalLahir = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Dokter_Alamat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dokter_Kode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dokter_Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pasien_Nama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pasien_NIK = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pasien_Alamat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pasien_NoTelepon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pasien_JenisKelamin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pasien_Pekerjaan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pasien_AlergiObat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoTransaksi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Keterangan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WaktuInsert = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WaktuProses = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Operator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Synchronise = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T6ResepObat", x => x.IdResepObat);
                    table.ForeignKey(
                        name: "FK_T6ResepObat_T0Pasien_IdPasien",
                        column: x => x.IdPasien,
                        principalTable: "T0Pasien",
                        principalColumn: "IdPasien");
                    table.ForeignKey(
                        name: "FK_T6ResepObat_T1Staf_IdDokter",
                        column: x => x.IdDokter,
                        principalTable: "T1Staf",
                        principalColumn: "IdStaf");
                    table.ForeignKey(
                        name: "FK_T6ResepObat_T6Pemeriksaan_IdPemeriksaan",
                        column: x => x.IdPemeriksaan,
                        principalTable: "T6Pemeriksaan",
                        principalColumn: "IdPemeriksaan");
                });

            migrationBuilder.CreateTable(
                name: "T7Pemeriksaan_Diagnosa",
                columns: table => new
                {
                    IdDetilPemeriksaan = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdPemeriksaan = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdDiagnosa = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Diagnosa_Nama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Diagnosa_Kode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Keterangan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WaktuInsert = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WaktuProses = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Operator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Synchronise = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T7Pemeriksaan_Diagnosa", x => x.IdDetilPemeriksaan);
                    table.ForeignKey(
                        name: "FK_T7Pemeriksaan_Diagnosa_T0Diagnosa_IdDiagnosa",
                        column: x => x.IdDiagnosa,
                        principalTable: "T0Diagnosa",
                        principalColumn: "IdDiagnosa");
                    table.ForeignKey(
                        name: "FK_T7Pemeriksaan_Diagnosa_T6Pemeriksaan_IdPemeriksaan",
                        column: x => x.IdPemeriksaan,
                        principalTable: "T6Pemeriksaan",
                        principalColumn: "IdPemeriksaan");
                });

            migrationBuilder.CreateTable(
                name: "T7Pemeriksaan_Tindakan",
                columns: table => new
                {
                    IdDetilPemeriksaan = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdPemeriksaan = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdTindakan = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Tindakan_Nama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tindakan_Kode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tindakan_Harga = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Keterangan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WaktuInsert = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WaktuProses = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Operator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Synchronise = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T7Pemeriksaan_Tindakan", x => x.IdDetilPemeriksaan);
                    table.ForeignKey(
                        name: "FK_T7Pemeriksaan_Tindakan_T0Tindakan_IdTindakan",
                        column: x => x.IdTindakan,
                        principalTable: "T0Tindakan",
                        principalColumn: "IdTindakan");
                    table.ForeignKey(
                        name: "FK_T7Pemeriksaan_Tindakan_T6Pemeriksaan_IdPemeriksaan",
                        column: x => x.IdPemeriksaan,
                        principalTable: "T6Pemeriksaan",
                        principalColumn: "IdPemeriksaan");
                });

            migrationBuilder.CreateTable(
                name: "T7ResepObat",
                columns: table => new
                {
                    IdDetilResepObat = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdResepObat = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdObat = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Dosis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Frekuensi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Durasi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Jumlah = table.Column<int>(type: "int", nullable: true),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Obat_Nama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Obat_Kode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Obat_Harga = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Keterangan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WaktuInsert = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WaktuProses = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Operator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Synchronise = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T7ResepObat", x => x.IdDetilResepObat);
                    table.ForeignKey(
                        name: "FK_T7ResepObat_T0Obat_IdObat",
                        column: x => x.IdObat,
                        principalTable: "T0Obat",
                        principalColumn: "IdObat");
                    table.ForeignKey(
                        name: "FK_T7ResepObat_T6ResepObat_IdResepObat",
                        column: x => x.IdResepObat,
                        principalTable: "T6ResepObat",
                        principalColumn: "IdResepObat");
                });

            migrationBuilder.CreateIndex(
                name: "IX_T5Jabatan_Staf_IdJabatan",
                table: "T5Jabatan_Staf",
                column: "IdJabatan");

            migrationBuilder.CreateIndex(
                name: "IX_T5Jabatan_Staf_IdStaf",
                table: "T5Jabatan_Staf",
                column: "IdStaf");

            migrationBuilder.CreateIndex(
                name: "IX_T6Pemeriksaan_IdDokter",
                table: "T6Pemeriksaan",
                column: "IdDokter");

            migrationBuilder.CreateIndex(
                name: "IX_T6Pemeriksaan_IdPasien",
                table: "T6Pemeriksaan",
                column: "IdPasien");

            migrationBuilder.CreateIndex(
                name: "IX_T6ResepObat_IdDokter",
                table: "T6ResepObat",
                column: "IdDokter");

            migrationBuilder.CreateIndex(
                name: "IX_T6ResepObat_IdPasien",
                table: "T6ResepObat",
                column: "IdPasien");

            migrationBuilder.CreateIndex(
                name: "IX_T6ResepObat_IdPemeriksaan",
                table: "T6ResepObat",
                column: "IdPemeriksaan");

            migrationBuilder.CreateIndex(
                name: "IX_T7Pemeriksaan_Diagnosa_IdDiagnosa",
                table: "T7Pemeriksaan_Diagnosa",
                column: "IdDiagnosa");

            migrationBuilder.CreateIndex(
                name: "IX_T7Pemeriksaan_Diagnosa_IdPemeriksaan",
                table: "T7Pemeriksaan_Diagnosa",
                column: "IdPemeriksaan");

            migrationBuilder.CreateIndex(
                name: "IX_T7Pemeriksaan_Tindakan_IdPemeriksaan",
                table: "T7Pemeriksaan_Tindakan",
                column: "IdPemeriksaan");

            migrationBuilder.CreateIndex(
                name: "IX_T7Pemeriksaan_Tindakan_IdTindakan",
                table: "T7Pemeriksaan_Tindakan",
                column: "IdTindakan");

            migrationBuilder.CreateIndex(
                name: "IX_T7ResepObat_IdObat",
                table: "T7ResepObat",
                column: "IdObat");

            migrationBuilder.CreateIndex(
                name: "IX_T7ResepObat_IdResepObat",
                table: "T7ResepObat",
                column: "IdResepObat");

            migrationBuilder.CreateIndex(
                name: "IX_T9Privileges_IdUser",
                table: "T9Privileges",
                column: "IdUser");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T0Form");

            migrationBuilder.DropTable(
                name: "T1AtributForm");

            migrationBuilder.DropTable(
                name: "T5Jabatan_Staf");

            migrationBuilder.DropTable(
                name: "T7Pemeriksaan_Diagnosa");

            migrationBuilder.DropTable(
                name: "T7Pemeriksaan_Tindakan");

            migrationBuilder.DropTable(
                name: "T7ResepObat");

            migrationBuilder.DropTable(
                name: "T9DataOption");

            migrationBuilder.DropTable(
                name: "T9Privileges");

            migrationBuilder.DropTable(
                name: "T0Jabatan");

            migrationBuilder.DropTable(
                name: "T0Diagnosa");

            migrationBuilder.DropTable(
                name: "T0Tindakan");

            migrationBuilder.DropTable(
                name: "T0Obat");

            migrationBuilder.DropTable(
                name: "T6ResepObat");

            migrationBuilder.DropTable(
                name: "T9User");

            migrationBuilder.DropTable(
                name: "T6Pemeriksaan");

            migrationBuilder.DropTable(
                name: "T0Pasien");

            migrationBuilder.DropTable(
                name: "T1Staf");
        }
    }
}
