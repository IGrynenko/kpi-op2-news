using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using New.Api.Core.Interfaces;
using New.Api.Core.Mapper;
using New.Api.Core.Services;
using News.Database;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddValidatorsFromAssembly(Assembly.GetAssembly(typeof(Program)))
    .AddControllers()
    .AddFluentValidation();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(ArticleProfile).Assembly);

builder.Services.AddDbContext<MainDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("NewsDb")));

builder.Services
    .AddScoped<INewsService, NewsService>()
    .AddScoped<ILoginService, LoginService>()
    .AddScoped<ICategoriesService, CategoriesService>()
    .AddScoped<IAuthorsService, AuthorsService>()
    .AddScoped<ITagsService, TagsService>()
    .AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("AllowReactApp", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(
        opt =>
        {
            opt.RequireHttpsMetadata = false;
            opt.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(builder.Configuration.GetSection("Authentication:Key").Value)
                    ),
                ValidateLifetime = true,
                ValidateAudience = true,
                ValidAudience = builder.Configuration.GetSection("Authentication:Audiance").Value,
                ValidateIssuer = true,
                ValidIssuer = builder.Configuration.GetSection("Authentication:Issuer").Value
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

app.UseCors("AllowReactApp");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
