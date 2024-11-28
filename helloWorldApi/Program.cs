using helloWorldApi.Data;
using helloWorldApi.Models;
using Microsoft.AspNetCore.Identity;

using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

// Add services to the container.

builder.Services.AddControllers();

var strComn = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(strComn));

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
    {
        new OpenApiSecurityScheme
        {
        Reference = new OpenApiReference
            {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"
            },
            Scheme = "oauth2",
            Name = "Bearer",
            In = ParameterLocation.Header,

        },
        new List<string>()
        }
    });
});

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();
builder.Services.AddIdentityApiEndpoints<IdentityUser>( options =>
{
    options.SignIn.RequireConfirmedEmail = false;
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 10;
    options.Password.RequireUppercase = true;
}).AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.MapGroup("/user").MapIdentityApi<IdentityUser>();

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthorization();
app.UseCors("AllowAll");

app.MapControllers();

app.Run();