using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using WebApi.Contexts;
using WebApi.Helpers.Repositories;
using WebApi.Helpers.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Contexts

builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("Data")));

#endregion

#region Services

builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<CategoryService>();

#endregion

#region Repositories

builder.Services.AddScoped<ProductRepo>();
builder.Services.AddScoped<CategoryRepo>();

#endregion

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();


