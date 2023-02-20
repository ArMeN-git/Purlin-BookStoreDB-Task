using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Purlin.BookStore.BLL;
using Purlin.BookStore.BLL.Interfaces;
using Purlin.BookStore.DAL.Data;
using Purlin.BookStore.DAL.Interfaces;
using Purlin.BookStore.DAL.Repositories;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(x =>
   x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);
var connectionString = "Server=.\\SQLExpress;Database=BookStoreDb;Trusted_Connection=True;TrustServerCertificate=True;";
builder.Services.AddDbContext<BookStoreDbContext>(x => x.UseSqlServer(connectionString));
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IBookRepository, BookRepository>();

builder.Services.AddControllers();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
