﻿// <auto-generated />
using System;
using Healio.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Healio.Migrations
{
    [DbContext(typeof(HealioDbContext))]
    partial class HealioDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Healio.Shared.T0Diagnosa", b =>
                {
                    b.Property<Guid>("IdDiagnosa")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Creator")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Keterangan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Kode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nama")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Operator")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Synchronise")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("WaktuInsert")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("WaktuProses")
                        .HasColumnType("datetime2");

                    b.HasKey("IdDiagnosa");

                    b.ToTable("T0Diagnosa");
                });

            modelBuilder.Entity("Healio.Shared.T0Obat", b =>
                {
                    b.Property<Guid>("IdObat")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Creator")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Harga")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Keterangan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Kode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nama")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Operator")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Synchronise")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("WaktuInsert")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("WaktuProses")
                        .HasColumnType("datetime2");

                    b.HasKey("IdObat");

                    b.ToTable("T0Obat");
                });

            modelBuilder.Entity("Healio.Shared.T0Pasien", b =>
                {
                    b.Property<Guid>("IdPasien")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Alamat")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AlergiObat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Creator")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JenisKelamin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Keterangan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Kode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NIK")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nama")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NoTelepon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Operator")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pekerjaan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Synchronise")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("WaktuInsert")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("WaktuProses")
                        .HasColumnType("datetime2");

                    b.HasKey("IdPasien");

                    b.ToTable("T0Pasien");
                });

            modelBuilder.Entity("Healio.Shared.T0Tindakan", b =>
                {
                    b.Property<Guid>("IdTindakan")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Creator")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Harga")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Keterangan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Kode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nama")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Operator")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Synchronise")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("WaktuInsert")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("WaktuProses")
                        .HasColumnType("datetime2");

                    b.HasKey("IdTindakan");

                    b.ToTable("T0Tindakan");
                });

            modelBuilder.Entity("Healio.Shared.T6Pemeriksaan", b =>
                {
                    b.Property<Guid>("IdPemeriksaan")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Creator")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dokter_Alamat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dokter_Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dokter_Kode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dokter_Nama")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Dokter_TanggalLahir")
                        .HasColumnType("datetime2");

                    b.Property<string>("Dokter_TempatLahir")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gejala")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("GrandTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid?>("IdDokter")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdPasien")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Keterangan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NoTransaksi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Operator")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pasien_Alamat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pasien_AlergiObat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pasien_JenisKelamin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pasien_NIK")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pasien_Nama")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pasien_NoTelepon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pasien_Pekerjaan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StatusPembayaran")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StatusPemeriksaan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Synchronise")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("TanggalPemeriksaan")
                        .HasColumnType("datetime2");

                    b.Property<string>("TujuanPemeriksaan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("WaktuInsert")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("WaktuProses")
                        .HasColumnType("datetime2");

                    b.HasKey("IdPemeriksaan");

                    b.HasIndex("IdDokter");

                    b.HasIndex("IdPasien");

                    b.ToTable("T6Pemeriksaan");
                });

            modelBuilder.Entity("Healio.Shared.T6ResepObat", b =>
                {
                    b.Property<Guid>("IdResepObat")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Creator")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dokter_Alamat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dokter_Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dokter_Kode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dokter_Nama")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Dokter_TanggalLahir")
                        .HasColumnType("datetime2");

                    b.Property<string>("Dokter_TempatLahir")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("GrandTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid?>("IdDokter")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdPasien")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdPemeriksaan")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Keterangan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NoTransaksi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Operator")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pasien_Alamat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pasien_AlergiObat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pasien_JenisKelamin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pasien_NIK")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pasien_Nama")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pasien_NoTelepon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pasien_Pekerjaan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Referensi_NoPemeriksaan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Synchronise")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("TanggalResep")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("WaktuInsert")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("WaktuProses")
                        .HasColumnType("datetime2");

                    b.HasKey("IdResepObat");

                    b.HasIndex("IdDokter");

                    b.HasIndex("IdPasien");

                    b.HasIndex("IdPemeriksaan");

                    b.ToTable("T6ResepObat");
                });

            modelBuilder.Entity("Healio.Shared.T7Pemeriksaan_Diagnosa", b =>
                {
                    b.Property<Guid>("IdDetilPemeriksaan")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Creator")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Diagnosa_Kode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Diagnosa_Nama")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("IdDiagnosa")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdPemeriksaan")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Keterangan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Operator")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Synchronise")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("WaktuInsert")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("WaktuProses")
                        .HasColumnType("datetime2");

                    b.HasKey("IdDetilPemeriksaan");

                    b.HasIndex("IdDiagnosa");

                    b.HasIndex("IdPemeriksaan");

                    b.ToTable("T7Pemeriksaan_Diagnosa");
                });

            modelBuilder.Entity("Healio.Shared.T7Pemeriksaan_Tindakan", b =>
                {
                    b.Property<Guid>("IdDetilPemeriksaan")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Creator")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("IdPemeriksaan")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdTindakan")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Keterangan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Operator")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Synchronise")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Tindakan_Harga")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Tindakan_Kode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tindakan_Nama")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("WaktuInsert")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("WaktuProses")
                        .HasColumnType("datetime2");

                    b.HasKey("IdDetilPemeriksaan");

                    b.HasIndex("IdPemeriksaan");

                    b.HasIndex("IdTindakan");

                    b.ToTable("T7Pemeriksaan_Tindakan");
                });

            modelBuilder.Entity("Healio.Shared.T7ResepObat", b =>
                {
                    b.Property<Guid>("IdDetilResepObat")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Creator")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dosis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Durasi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Frekuensi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("IdObat")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdResepObat")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Jumlah")
                        .HasColumnType("int");

                    b.Property<string>("Keterangan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Obat_Harga")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Obat_Kode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Obat_Nama")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Operator")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Synchronise")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("WaktuInsert")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("WaktuProses")
                        .HasColumnType("datetime2");

                    b.HasKey("IdDetilResepObat");

                    b.HasIndex("IdObat");

                    b.HasIndex("IdResepObat");

                    b.ToTable("T7ResepObat");
                });

            modelBuilder.Entity("bwaPolaris.Shared.T0Form", b =>
                {
                    b.Property<string>("IdForm")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Creator")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Form")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("HasChild")
                        .HasColumnType("bit");

                    b.Property<string>("Icon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdParent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAbleToAddData")
                        .HasColumnType("bit");

                    b.Property<bool>("IsAbleToDeleteData")
                        .HasColumnType("bit");

                    b.Property<bool>("IsAbleToEditData")
                        .HasColumnType("bit");

                    b.Property<bool>("IsAbleToReadData")
                        .HasColumnType("bit");

                    b.Property<string>("Keterangan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Operator")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Synchronise")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("WaktuInsert")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("WaktuProses")
                        .HasColumnType("datetime2");

                    b.HasKey("IdForm");

                    b.ToTable("T0Form");
                });

            modelBuilder.Entity("bwaPolaris.Shared.T0Jabatan", b =>
                {
                    b.Property<Guid>("IdJabatan")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Creator")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Jabatan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Keterangan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Kode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Operator")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Synchronise")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("WaktuInsert")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("WaktuProses")
                        .HasColumnType("datetime2");

                    b.HasKey("IdJabatan");

                    b.ToTable("T0Jabatan");
                });

            modelBuilder.Entity("bwaPolaris.Shared.T1AtributForm", b =>
                {
                    b.Property<long>("IdAtributForm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IdAtributForm"));

                    b.Property<string>("CaptionDetil")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CaptionRekapitulasi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Field")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdForm")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TampilDetil")
                        .HasColumnType("bit");

                    b.Property<bool>("TampilMobile")
                        .HasColumnType("bit");

                    b.Property<bool>("TampilRekapitulasi")
                        .HasColumnType("bit");

                    b.HasKey("IdAtributForm");

                    b.ToTable("T1AtributForm");
                });

            modelBuilder.Entity("bwaPolaris.Shared.T1Staf", b =>
                {
                    b.Property<Guid>("IdStaf")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Alamat")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Creator")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Keterangan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Kode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nama")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Operator")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Synchronise")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("TanggalLahir")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("TempatLahir")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("WaktuInsert")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("WaktuProses")
                        .HasColumnType("datetime2");

                    b.HasKey("IdStaf");

                    b.ToTable("T1Staf");
                });

            modelBuilder.Entity("bwaPolaris.Shared.T5Jabatan_Staf", b =>
                {
                    b.Property<Guid>("IdJabatanStaf")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdJabatan")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdStaf")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Jabatan")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdJabatanStaf");

                    b.HasIndex("IdJabatan");

                    b.HasIndex("IdStaf");

                    b.ToTable("T5Jabatan_Staf");
                });

            modelBuilder.Entity("bwaPolaris.Shared.T9DataOption", b =>
                {
                    b.Property<long>("IdDataOption")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IdDataOption"));

                    b.Property<string>("Creator")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DataOption")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Entity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Keterangan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Operator")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Synchronise")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("WaktuInsert")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("WaktuProses")
                        .HasColumnType("datetime2");

                    b.HasKey("IdDataOption");

                    b.ToTable("T9DataOption");
                });

            modelBuilder.Entity("bwaPolaris.Shared.T9Privileges", b =>
                {
                    b.Property<Guid>("IdKonfigurasiAkses")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Creator")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdForm")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("IdUser")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsAbleToAddData")
                        .HasColumnType("bit");

                    b.Property<bool>("IsAbleToDeleteData")
                        .HasColumnType("bit");

                    b.Property<bool>("IsAbleToEditData")
                        .HasColumnType("bit");

                    b.Property<bool>("IsAbleToReadData")
                        .HasColumnType("bit");

                    b.Property<string>("Keterangan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Operator")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Synchronise")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("WaktuInsert")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("WaktuProses")
                        .HasColumnType("datetime2");

                    b.HasKey("IdKonfigurasiAkses");

                    b.HasIndex("IdUser");

                    b.ToTable("T9Privileges");
                });

            modelBuilder.Entity("bwaPolaris.Shared.T9User", b =>
                {
                    b.Property<Guid>("IdUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Creator")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Keterangan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nama")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Operator")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Synchronise")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("WaktuInsert")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("WaktuProses")
                        .HasColumnType("datetime2");

                    b.HasKey("IdUser");

                    b.ToTable("T9User");
                });

            modelBuilder.Entity("Healio.Shared.T6Pemeriksaan", b =>
                {
                    b.HasOne("bwaPolaris.Shared.T1Staf", "T1Staf_Dokter")
                        .WithMany()
                        .HasForeignKey("IdDokter")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Healio.Shared.T0Pasien", "T0Pasien")
                        .WithMany()
                        .HasForeignKey("IdPasien");

                    b.Navigation("T0Pasien");

                    b.Navigation("T1Staf_Dokter");
                });

            modelBuilder.Entity("Healio.Shared.T6ResepObat", b =>
                {
                    b.HasOne("bwaPolaris.Shared.T1Staf", "T1Staf_Dokter")
                        .WithMany()
                        .HasForeignKey("IdDokter");

                    b.HasOne("Healio.Shared.T0Pasien", "T0Pasien")
                        .WithMany()
                        .HasForeignKey("IdPasien");

                    b.HasOne("Healio.Shared.T6Pemeriksaan", "T6Pemeriksaan")
                        .WithMany()
                        .HasForeignKey("IdPemeriksaan");

                    b.Navigation("T0Pasien");

                    b.Navigation("T1Staf_Dokter");

                    b.Navigation("T6Pemeriksaan");
                });

            modelBuilder.Entity("Healio.Shared.T7Pemeriksaan_Diagnosa", b =>
                {
                    b.HasOne("Healio.Shared.T0Diagnosa", "T0Diagnosa")
                        .WithMany()
                        .HasForeignKey("IdDiagnosa");

                    b.HasOne("Healio.Shared.T6Pemeriksaan", "T6Pemeriksaan")
                        .WithMany()
                        .HasForeignKey("IdPemeriksaan");

                    b.Navigation("T0Diagnosa");

                    b.Navigation("T6Pemeriksaan");
                });

            modelBuilder.Entity("Healio.Shared.T7Pemeriksaan_Tindakan", b =>
                {
                    b.HasOne("Healio.Shared.T6Pemeriksaan", "T6Pemeriksaan")
                        .WithMany()
                        .HasForeignKey("IdPemeriksaan");

                    b.HasOne("Healio.Shared.T0Tindakan", "T0Tindakan")
                        .WithMany()
                        .HasForeignKey("IdTindakan");

                    b.Navigation("T0Tindakan");

                    b.Navigation("T6Pemeriksaan");
                });

            modelBuilder.Entity("Healio.Shared.T7ResepObat", b =>
                {
                    b.HasOne("Healio.Shared.T0Obat", "T0Obat")
                        .WithMany()
                        .HasForeignKey("IdObat");

                    b.HasOne("Healio.Shared.T6ResepObat", "T6ResepObat")
                        .WithMany()
                        .HasForeignKey("IdResepObat");

                    b.Navigation("T0Obat");

                    b.Navigation("T6ResepObat");
                });

            modelBuilder.Entity("bwaPolaris.Shared.T5Jabatan_Staf", b =>
                {
                    b.HasOne("bwaPolaris.Shared.T0Jabatan", "T0Jabatan")
                        .WithMany()
                        .HasForeignKey("IdJabatan");

                    b.HasOne("bwaPolaris.Shared.T1Staf", "T1Staf")
                        .WithMany()
                        .HasForeignKey("IdStaf");

                    b.Navigation("T0Jabatan");

                    b.Navigation("T1Staf");
                });

            modelBuilder.Entity("bwaPolaris.Shared.T9Privileges", b =>
                {
                    b.HasOne("bwaPolaris.Shared.T9User", "T9User")
                        .WithMany("DaftarPrivileges")
                        .HasForeignKey("IdUser");

                    b.Navigation("T9User");
                });

            modelBuilder.Entity("bwaPolaris.Shared.T9User", b =>
                {
                    b.Navigation("DaftarPrivileges");
                });
#pragma warning restore 612, 618
        }
    }
}
