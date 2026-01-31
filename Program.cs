
using BookShelf.Data;
using BookShelf.MiddleWare;
using BookShelf.Repositories;
using BookShelf.Repositories.Interfaces;
using BookShelf.Services;
using BookShelf.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookShelf
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddOpenApi();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AngularPolicy", policy =>
                {
                    policy.WithOrigins("https://localhost:4200").AllowAnyMethod().AllowAnyHeader();
                });
            });


            builder.Services.AddDbContext<MyDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<ILibriRepository, LibriRepository>();
            builder.Services.AddScoped<ILibriService, LibriService>();

            builder.Services.AddScoped<ICategorieRepository, CategorieRepository>();
            builder.Services.AddScoped<ICategorieService, CategorieService>();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            if (!app.Environment.IsDevelopment())
            {
                app.UseCors("AngularPolicy");
                app.UseMiddleware<AuthenticationMiddleWare>();
            }


            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.MapControllers();

            app.Run();
        }
    }
}
