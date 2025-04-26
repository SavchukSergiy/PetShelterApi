using Microsoft.EntityFrameworkCore;
using PetShelterApi.Data;
using PetShelterApi.Repositories;
using PetShelterApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<PetSHelterContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IAnimalRepository, AnimalRepository>();

builder.Services.AddScoped<IAnimalService, AnimalService>();

builder.Services.AddLogging();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}


    app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
