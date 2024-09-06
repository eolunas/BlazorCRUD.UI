using BlazorCRUD.Components;
using BlazorCRUD.Interfaces;
using BlazorCRUD.Services;
using System.Data.SqlClient;
using System.Data;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Servicios adicionales:
builder.Services.AddScoped<IFilmService, FilmService>();

// Cadena de conexion a BD:
var connectionString = builder.Configuration.GetConnectionString("SqlConnection");
builder.Services.AddSingleton<IDbConnection>(sp => new SqlConnection(connectionString));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
