
using Blazored.LocalStorage;
using Blazored.Modal;
using Blazored.SessionStorage;
using Blazored.Toast;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.DataDB;
using Web_Admin_Client.HubsUpdate;
using Web_Client.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddBlazoredToast();


builder.Services.AddLocalization();

builder.Services.AddControllers();

//Add Blazor Modal
builder.Services.AddBlazoredModal();
//Add Blazor Session
builder.Services.AddBlazoredSessionStorage();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<ISanphamService, SanphamService>();



builder.Services.AddDbContext<LV_FashionStoreContext>(option =>
                option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7118/") });

builder.Services.AddBlazoredLocalStorage();

builder.Services.AddCors(options =>
{
    options.AddPolicy(
        "LV_FashionStore",
        builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

builder.Services.AddSignalR();
builder.Services.AddResponseCompression(opts =>
{
    opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
        new[] { "application/octet-stream" });
});

builder.Services.AddScoped<SessionTemp>();
var app =  builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
app.MapControllers();
app.MapFallbackToPage("/_Host");

app.MapBlazorHub();
app.UseResponseCompression();
app.MapHub<BroadcastHub>("/BroadcastHub");

app.Run();
