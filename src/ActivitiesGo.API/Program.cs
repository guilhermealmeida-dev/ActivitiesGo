using System.Text;
using ActivitiesGo.API.Configuration;
using ActivitiesGo.API.Middlewares;
using ActivitiesGo.Aplication.Interfaces;
using ActivitiesGo.Aplication.Services;
using ActivitiesGo.InfraData.Context;
using ActivitiesGo.Shared.Config;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.Configure<ApiBehaviorOptions>(options =>
        {
            options.SuppressModelStateInvalidFilter = true;
        });

        // Injeção de dependências
        builder.Services.AddServices();
        builder.Services.AddRepositories();
        builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
        builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();


        var jwtKey = builder.Configuration.GetSection("AppSettings:JwtKey").Value;
        if (string.IsNullOrEmpty(jwtKey))
        {
            throw new Exception("JwtKey não foi definida no appsettings.json!");
        }
        var key = Encoding.UTF8.GetBytes(jwtKey);

        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true
                };
                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        context.Response.StatusCode = 401;
                        context.Response.ContentType = "application/json";
                        return context.Response.WriteAsync(new
                        {
                            message = "Token inválido ou expirado."
                        }.ToString()); // Pode usar JsonSerializer se quiser JSON real
                    },
                    OnChallenge = context =>
                    {
                        context.HandleResponse(); // Evita a resposta padrão do 401
                        context.Response.StatusCode = 401;
                        context.Response.ContentType = "application/json";
                        return context.Response.WriteAsync(new
                        {
                            message = "Necessário autenticação."
                        }.ToString());
                    }
                };
            });



        // Swagger + JWT
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "ActivitiesGo API", Version = "v1" });

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "Insira o token JWT desta forma: Bearer {token}"
            });

            c.OperationFilter<AuthorizeCheckOperationFilter>();
        });

        // Banco de dados
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
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ActivitiesGo API v1");
                c.RoutePrefix = "swagger";
            });
        }


        app.UseCors();
        app.UseMiddleware<ExceptionMiddleware>();

        if (!app.Environment.IsDevelopment())
        {
            app.UseHttpsRedirection();
        }

        app.UseAuthentication();

        app.UseAuthorization();

        app.MapControllers();

        app.UseStaticFiles();

        app.Run();
    }
}
