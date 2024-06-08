using Microsoft.EntityFrameworkCore;
using zadanko.Context;
using zadanko.Repositories;
using zadanko.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddTransient<IClientRepository, ClientRepository>();
builder.Services.AddTransient<IClientService, ClientService>();
builder.Services.AddTransient<IReservationRepository, ReservationRepository>();
builder.Services.AddTransient<IReservationService, ReservationService>();

builder.Services.AddDbContext<BoatRentalDbContext>(opt =>{
    string connString = builder.Configuration.GetConnectionString("DbConnString");
    opt.UseSqlServer(connString);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.Run();
