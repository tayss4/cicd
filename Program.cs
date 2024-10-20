using AutoMapper;
using Fiap.Web.Trafego.Data.Contexts;
using Fiap.Web.Trafego.Logging;
using Fiap.Web.Trafego.Models;
using Fiap.Web.Trafego.ViewModel;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

#region INICIALIZANDO O BANCO DE DADOS
var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");
builder.Services.AddDbContext<DatabaseContext>(
    opt => opt.UseOracle(connectionString).EnableSensitiveDataLogging(true)
);
#endregion

#region Registro IServceCollection
builder.Services.AddSingleton<ICustomLogger, MockLogger>();
#endregion

#region AutoMapper
var mapperConfig = new AutoMapper.MapperConfiguration(c => {
    c.AllowNullCollections = true;
    c.AllowNullDestinationValues = true;

    c.CreateMap<Cruzamento, CruzamentoCreateViewModel>();
    c.CreateMap<CruzamentoCreateViewModel, Cruzamento>();

    c.CreateMap<Registro, RegistroCreateViewModel>();
    c.CreateMap<RegistroCreateViewModel, Registro>();

    c.CreateMap<Previsao, PrevisaoCreateViewModel>();
    c.CreateMap<PrevisaoCreateViewModel, Previsao>();

    c.CreateMap<HorarioPico, HorarioPicoCreateViewModel>();
    c.CreateMap<HorarioPicoCreateViewModel, HorarioPico>();
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
#endregion...

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
