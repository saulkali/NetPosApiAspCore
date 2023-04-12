using PyPosApi.common.database.context;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using PyPosApi.modules.moduleLogin.model;
using PyPosApi.modules.moduleRegisterEmploye.model;
using PyPosApi.common.security;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using PyPosApi.modules.moduleArticles.model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//cors
builder.Services.AddCors( options => {
    options.AddDefaultPolicy(builder =>{
        builder.AllowAnyMethod().AllowAnyOrigin().AllowAnyHeader();
    });
});


//database configuration
builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("PyPosDatabase"), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("PyPosDatabase")))
);



//add scopes
builder.Services.AddScoped<LoginRepository>();
builder.Services.AddScoped<RegisterEmployeRepository>();
builder.Services.AddScoped<ArticlesRepository>();

builder.Services.AddScoped<DatabaseContext>();


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

app.UseAuthorization();

app.MapControllers();

//cors
app.UseCors();

app.Run();
