using PyPosApi.common.database.context;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using PyPosApi.modules.moduleLogin.model;
using PyPosApi.common.security;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using PyPosApi.modules.moduleArticles.model;
using PyPosApi.common.database.functions;
using Microsoft.AspNetCore.Hosting;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using NLog.Extensions.Logging;

namespace PyPosApi
{
    public class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            //cors
            builder.Services.AddCors(options => {
                options.AddDefaultPolicy(builder => {
                    builder.AllowAnyMethod().AllowAnyOrigin().AllowAnyHeader();
                });
            });

            //builder.WebHost.ConfigureKestrel(options =>
            //{
            //    options.ListenAnyIP(5242); // HTTP
            //    //options.ListenAnyIP(7242, listenOptions =>
            //    //{
            //    //    listenOptions.UseHttps(); // HTTPS
            //    //});
            //});

            //database configuration
            builder.Services.AddDbContext<DatabaseContext>(options =>
            {
                var connectionString = builder.Configuration.GetConnectionString("PyPosDatabase");
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            });

            //add scopes
            builder.Services.AddScoped<LoginRepository>();
            builder.Services.AddScoped<ArticlesRepository>();
            builder.Services.AddScoped<DatabaseContext>();
            builder.Services.AddScoped<DArticle>();
            builder.Services.AddScoped<DClient>();
            builder.Services.AddScoped<DUser>();
            builder.Services.AddTransient<ILoggerFactory, LoggerFactory>();
            builder.Services.AddLogging(log => { 
                log.AddConsole();
                log.AddNLog();
            });

            //jwt configuration
            string secretKey = builder.Configuration.GetValue<string>("JwtSecret");

            builder.Services.AddScoped(provider => {
                return new JwtSecurity(secretKey);
            });

            builder.Services.AddSingleton(new JwtSecurity(secretKey));
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            var app = builder.Build();


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            //cors
            app.UseCors();

            app.Run();
        }


    }



}
