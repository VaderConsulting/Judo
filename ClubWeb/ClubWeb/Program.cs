using ClubWeb.Data;
using ClubWeb.Services;
using Microsoft.EntityFrameworkCore;

namespace ClubWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder Builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            Builder.Services.AddRazorPages();
            Builder.Services.AddServerSideBlazor();

            // Add Entity Framework Core
            string ConnectionString = Builder.Configuration.GetConnectionString("DefaultConnection") 
                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            Builder.Services.AddDbContext<ApplicationDbContext>(Options =>
                Options.UseSqlServer(ConnectionString));

            // Add application services
            Builder.Services.AddSingleton<IOrgUnitService, OrgUnitService>();

            WebApplication App = Builder.Build();

            // Configure the HTTP request pipeline.
            if (!App.Environment.IsDevelopment())
            {
                App.UseExceptionHandler("/Error");
                App.UseHsts();
            }

            App.UseHttpsRedirection();
            App.UseStaticFiles();
            App.UseRouting();

            App.MapRazorPages();
            App.MapBlazorHub();
            App.MapFallbackToPage("/_Host");

            App.Run();
        }
    }
}

