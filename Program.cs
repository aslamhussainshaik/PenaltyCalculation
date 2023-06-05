using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
// using PenaltyCalculation.Models;
using PenaltyCalculation.Repos;
using PenaltyCalculation.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PenaltyCalculationDBContext>(options => {
    options.UseNpgsql(builder.Configuration["ConnectionStrings:MyConnectionString"]);
});

builder.Services.AddScoped<IPenaltyRepository, PenaltyRepository>();
// builder.Services.AddScoped<IPenaltyRepository, MockPenaltyRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
