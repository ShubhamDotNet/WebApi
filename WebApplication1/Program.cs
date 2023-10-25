using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Data.NewFolder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ContactsAPIDbContext>(options => options.UseInMemoryDatabase("ContactsDb"));
builder.Services.AddCors(options => { options.AddPolicy("AllowOrigin", builder => { builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod(); }); });

//builder.Services.AddCors(options => { options.AddPolicy("AllowAll", builder => { builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod(); }); });
var app = builder.Build();

//builder.Services.AddConnections();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseDeveloperExceptionPage();
//app.UseCors();
//app.UseRouting();
app.UseCors("AllowOrigin");
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
