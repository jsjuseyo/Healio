using bwaPolaris.Components;
using bwaPolaris;
using Google.Protobuf;
using Mapster;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MudBlazor.Services;
using Syncfusion.Blazor;
using System.Text;
using Google.Protobuf.Collections;
using Healio.Server;
using bwaPolaris.Server;
using Healio.Components;
using Toolbelt.Blazor.Extensions.DependencyInjection;
using Radzen;
using DevExpress.Blazor;

var builder = WebApplication.CreateBuilder(args);

AlamatAPI = "https://localhost:7216/";

var service = builder.Services;
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
service.AddMudServices();
//Register Package
service.AddSyncfusionBlazor();
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzA5ODQ4OUAzMjM0MmUzMDJlMzBSejh3SUxUR2tpQ3pXWW4rVE5OMG02dU5mY1ZHMFJnM2hkQXZmcjFsUUJNPQ==");
service.AddSpeechSynthesis();

//Radzen
service.AddScoped<DialogService>();
service.AddScoped<NotificationService>();
service.AddScoped<TooltipService>();
service.AddScoped<ContextMenuService>();
service.AddScoped<DialogService>();
service.AddScoped<NotificationService>();
service.AddScoped<TooltipService>();
service.AddScoped<ContextMenuService>();

//Dx
service.AddDevExpressBlazor(configure => configure.BootstrapVersion = BootstrapVersion.v5);


//Setting gRPC
service.AddGrpc();
service.AddCors(o => o.AddPolicy("AllowAll", builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader()
           .WithExposedHeaders("Grpc-Status", "Grpc-Message", "Grpc-Encoding", "Grpc-Accept-Encoding");
}));

//Config Mapster
var config = TypeAdapterConfig.GlobalSettings;
config.Default.NameMatchingStrategy(NameMatchingStrategy.Flexible);
config.Default.IgnoreNullValues(true);
config.Default.UseDestinationValue(member => member.SetterModifier == AccessModifier.None &&
                       member.Type.IsGenericType &&
                       member.Type.GetGenericTypeDefinition() == typeof(RepeatedField<>));

config.NewConfig<string, Guid?>()
      .MapWith(src => string.IsNullOrEmpty(src) ? null : Guid.Parse(src));
config.NewConfig<string, DateTimeOffset?>()
      .MapWith(src => string.IsNullOrEmpty(src) ? null : DateTimeOffset.Parse(src));
config.NewConfig<string, DateTime?>()
      .MapWith(src => string.IsNullOrEmpty(src) ? null : DateTime.Parse(src));
config.NewConfig<string, DateOnly?>()
      .MapWith(src => string.IsNullOrEmpty(src) ? null : DateOnly.Parse(src));
config.NewConfig<string, long?>()
      .MapWith(src => string.IsNullOrEmpty(src) ? null : long.Parse(src));
config.NewConfig<string, long>()
      .MapWith(src => string.IsNullOrEmpty(src) ? 0 : long.Parse(src));
config.NewConfig<string, int?>()
      .MapWith(src => string.IsNullOrEmpty(src) ? null : int.Parse(src));
config.NewConfig<string, int>()
      .MapWith(src => string.IsNullOrEmpty(src) ? 0 : int.Parse(src));
config.NewConfig<string, decimal?>()
      .MapWith(src => string.IsNullOrEmpty(src) ? 0 : decimal.Parse(src));
config.NewConfig<string, double?>()
      .MapWith(src => string.IsNullOrEmpty(src) ? null : double.Parse(src));
config.NewConfig<string, bool?>()
      .MapWith(src => string.IsNullOrEmpty(src) ? null : bool.Parse(src));
config.NewConfig<string, ByteString?>()
      .MapWith(src => string.IsNullOrEmpty(src) ? null : ByteString.CopyFrom(src, Encoding.Unicode));
config.NewConfig<string, byte[]?>()
      .MapWith(src => string.IsNullOrEmpty(src) || src == "System.Byte[]" ? null : Encoding.ASCII.GetBytes(src));
config.NewConfig<byte[]?, string>()
      .MapWith(src => src == null ? null : Encoding.UTF8.GetString(src));

//Config Database

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<HealioDbContext>(options =>
    options.UseSqlServer(connectionString));

var optionsBuilder = new DbContextOptionsBuilder<HealioDbContext>();
optionsBuilder.UseSqlServer(connectionString);

ServerDbContext = new HealioDbContext(optionsBuilder.Options);


//Config Auth
ConfigurationManager configuration = builder.Configuration;
var appSettingSection = configuration.GetSection("AppSettings");
builder.Services.Configure<AppSettings>(appSettingSection);

var appSettings = appSettingSection.Get<AppSettings>();
var key = Encoding.UTF8.GetBytes(appSettings.Secret);

//Add JWT Bearer
service.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(x =>
    {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

service.AddAuthorization();


//Register Service Client
service.AddScoped<svcBaseService>();
service.AddScoped<svcLogin>();
service.AddScoped<svcForm>();
service.AddScoped<svcPrivileges>();
service.AddScoped<svcDataOption>();

service.AddScoped<svcJabatan>();
service.AddScoped<svcStaf>();
service.AddScoped<svcDiagnosa>();
service.AddScoped<svcTindakan>();
service.AddScoped<svcObat>();
service.AddScoped<svcPasien>();

//Transaksi
service.AddScoped<svcPendaftaran>();
service.AddScoped<svcPemeriksaan>();
service.AddScoped<svcResepObat>();
service.AddScoped<svcPembayaran>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseCors(x => x
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .SetIsOriginAllowed(origin => true) // allow any origin
                    .AllowCredentials()); // allow credentials
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseGrpcWeb();
app.UseCors();

//Register Service Server
app.MapGrpcService<svsBaseService>().EnableGrpcWeb();
app.MapGrpcService<svsLogin>().EnableGrpcWeb();
app.MapGrpcService<svsForm>().EnableGrpcWeb();
app.MapGrpcService<svsPrivileges>().EnableGrpcWeb();
app.MapGrpcService<svsDataOption>().EnableGrpcWeb();

//Master
app.MapGrpcService<svsJabatan>().EnableGrpcWeb();
app.MapGrpcService<svsStaf>().EnableGrpcWeb();
app.MapGrpcService<svsDiagnosa>().EnableGrpcWeb();
app.MapGrpcService<svsTindakan>().EnableGrpcWeb();
app.MapGrpcService<svsObat>().EnableGrpcWeb();
app.MapGrpcService<svsPasien>().EnableGrpcWeb();

//Transaksi
app.MapGrpcService<svsPemeriksaan>().EnableGrpcWeb();
app.MapGrpcService<svsResepObat>().EnableGrpcWeb();

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<Healio.Components.App>()
    .AddInteractiveServerRenderMode();

app.Run();
