using Application.Contracts;
using Application.Services;
using Domain.Contracts;
using Domain.Entities;
using Infraestructure.Persistence.Context;
using Infrastructure.Persistence.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("allOrigins", policyBuilder =>
    {
        policyBuilder.AllowAnyOrigin();
        policyBuilder.AllowAnyHeader();
        policyBuilder.AllowAnyMethod();
    });
});


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services
builder.Services.AddScoped<IEventServices, EventServices>();
builder.Services.AddScoped<IGroupServices, GroupsServices>();
builder.Services.AddScoped<IAuthServices, AuthServices>();

// Add repos
builder.Services.AddScoped<IRepository<Group>, GroupsRepository>();
builder.Services.AddScoped<IRepository<Event>, EventsRepository>();

builder.Services.AddDbContext<DatabaseContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("WebApiDatabase")));

var app = builder.Build();

// Apply migrations
using (var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
{
    var dbContext = serviceScope.ServiceProvider.GetService<DatabaseContext>();
    if (dbContext == null) Console.WriteLine("Unable to establish connection to db");
    dbContext?.Database.Migrate();
}

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.UseCors("allOrigins");

app.MapControllers();

app.Run();
