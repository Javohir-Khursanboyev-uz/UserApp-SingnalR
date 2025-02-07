using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using Serilog;
using UserApp_SingnalR.Api.Helpers;
using UserApp_SingnalR.DataAcces.DbContexts;
using UserApp_SingnalR.Service.Mappers;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);

// 🔹 Serilog konfiguratsiyasi
builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

// 🔹 Xizmatlarni (services) qo‘shish
builder.Services.AddControllers(options =>
    options.Conventions.Add(new RouteTokenTransformerConvention(new ConfigurationApiUrlName())));

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddExceptionHandlers();
builder.Services.AddProblemDetails();
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddHttpContextAccessor();
builder.Services.AddValidators();
builder.Services.AddServices();

// 🔹 Swagger sozlamalari
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 🔹 Middleware konfiguratsiyasi
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();

app.MapControllers();

app.Run();
