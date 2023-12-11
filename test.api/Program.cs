using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using test.api.data;
using test.api.Mappings;
using test.api.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//my services
//builder.Services.AddDbContext<walksDbContext>(options => 
//    options.UseSqlServer(builder.Configuration.GetConnectionString("testConnectionString"))
//    );
builder.Services.AddDbContext<walksDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("testConnectionString"), sqlServerOptions =>
    {
        sqlServerOptions.EnableRetryOnFailure();
    });
});
builder.Services.AddDbContext<walksAuthDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("authConnectionString"), sqlServerOptions =>
    {
        sqlServerOptions.EnableRetryOnFailure();
    });
});

builder.Services.AddScoped<IRegionRepository, SQLregionRepository>();
builder.Services.AddScoped<IWalkRepository, SQLwalkRepository>();
builder.Services.AddAutoMapper(typeof(AuthoMapperProfile));

builder.Services.AddIdentityCore<IdentityUser>()
    .AddRoles<IdentityRole>()
    .AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>("walks")
    .AddEntityFrameworkStores<walksAuthDbContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequiredLength = 6;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
});

//auth
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
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

app.Run();
