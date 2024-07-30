using AspNetCoreRateLimit;
using AspNetCoreRateLimit.Redis;
using CurrencyAPI.Data;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CurrencyContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection"));
});
builder.Services.AddHttpClient("RestAPI", x =>
{
    x.BaseAddress = new Uri("https://api.freecurrencyapi.com/");
});
builder.Services.AddMemoryCache();
builder.Services.Configure<IpRateLimitOptions>(builder.Configuration.GetSection("IpRateLimiting"));
builder.Services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
builder.Services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
builder.Services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
builder.Services.AddSingleton<IProcessingStrategy, AsyncKeyLockProcessingStrategy>();
builder.Services.AddInMemoryRateLimiting();

//var redisOptions = ConfigurationOptions.Parse(builder.Configuration["ConnectionStrings:Redis"]);
//builder.Services.AddSingleton<IConnectionMultiplexer>(provider => ConnectionMultiplexer.Connect(redisOptions));
//builder.Services.AddRedisRateLimiting();


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
