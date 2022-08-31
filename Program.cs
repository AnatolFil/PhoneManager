using Microsoft.EntityFrameworkCore;
using PhoneManager.Models;
using PhoneManager.Models.Interfaces;
using PhoneManager.Models.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IContactRepository, ContactRepository>();
builder.Services.AddTransient<ICallRepository, CallRepository>();
builder.Services.AddTransient<IConferenceContactRepository, ConferenceContactRepository>();
builder.Services.AddTransient<IConferenceRepository, ConferenceRepository>();
builder.Services.AddTransient<IPhoneNumberRepository, PhoneNumberRepository>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDBContext>(x => x.UseSqlServer(connectionString));

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
