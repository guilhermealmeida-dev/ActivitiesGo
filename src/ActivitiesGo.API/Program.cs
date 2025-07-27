using ActivitiesGo.InfraData.Context;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();

        builder.Services.AddHttpsRedirection(options =>
        {
            options.HttpsPort = 7285;
        });

        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<AplicationContext>(options =>
        {
            options.UseSqlServer(
                builder.Configuration.GetConnectionString("Default"),
                o => o.MigrationsAssembly("ActivitiesGo.InfraData")
            );
        });

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthorization();

        app.UseHttpsRedirection();

        app.MapControllers();

        app.Run();
    }
}