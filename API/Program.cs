using System.Reflection;
using API.Extensions;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAutoMapper(Assembly.GetEntryAssembly());
builder.Services.AddAplicacionServices();
// * ----- Llamamos las Cors -----
builder.Services.ConfigureCors();
// Add services to the container.
builder.Services.AddControllers();
// * ----- Inyeccion de Dependencias -----
builder.Services.AddDbContext<TechGuardianContext>(optionsBuilder => 
{
    string ? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// * ----- Usamos las Cors -----
app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
