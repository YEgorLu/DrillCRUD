global using Microsoft.EntityFrameworkCore;
using DrillCRUD.Data;
using DrillCRUD.MappingProfiles;
using DrillCRUD.Services.DrillBlockPointService;
using DrillCRUD.Services.DrillBlockService;
using DrillCRUD.Services.HolePointService;
using DrillCRUD.Services.HoleService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(StandardMappingProfile));
builder.Services.AddDbContext<DataContext>();
builder.Services.AddScoped<IHoleService, HoleService>();
builder.Services.AddScoped<IDrillBlockService, DrillBlockService>();
builder.Services.AddScoped<IDrillBlockPointService, DrillBlockPointService>();
builder.Services.AddScoped<IHolePointService, HolePointService>();


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

app.Run();
