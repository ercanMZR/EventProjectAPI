using EventProjectWeb.DTO.Artist;
using EventProjectWeb.DTO.Category;
using EventProjectWeb.DTO.City;
using EventProjectWeb.DTO.Customer;
using EventProjectWeb.Model.ORM;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers().AddFluentValidation();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<EventProjectContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddValidatorsFromAssemblyContaining<CreateArtistRequestDTO>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateArtistRequestDTO>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateCityRequestDTO>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateCityRequestDTO>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateCustomerRequestDTO>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateCustomerRequestDTO>();  
builder.Services.AddValidatorsFromAssemblyContaining<CreateCategoryRequestDTO>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateCategoryRequestDto>();


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidIssuer = "meliisaademir@gmail.com",
        ValidAudience ="melisa.demir@gmail.com",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes
        ("EventApiAuthKeyPasswordsasdafaafafadaf")),
        ValidateLifetime=true,
        ClockSkew = TimeSpan.Zero

    });
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", policy =>
    {
        policy.WithOrigins("http://localhost:3000") // React uygulamanýzýn çalýþtýðý yerel geliþtirme URL'si
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});



var app = builder.Build();

app.UseCors("AllowSpecificOrigin");
app.UseStaticFiles();

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
