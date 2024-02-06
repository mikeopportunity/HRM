using HRM.DAL;
using HRM.Web.Configuration;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<HRMContext>(c =>
//{
//    var connectionString = builder.Configuration.GetConnectionString("HRMModelConnection");
//    c.UseSqlServer(connectionString);
//});

builder.Services.AddDbContext<HRMContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("HRMModelConnection")));

// Add services to the container.
builder.Services.AddCoreServices(builder.Configuration);


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

app.UseAuthorization();

app.MapControllers();


app.Run();
