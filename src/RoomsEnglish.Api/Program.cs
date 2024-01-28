using System.IO.Compression;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.AspNetCore.ResponseCompression;
using RoomsEnglish.Api.PlayerContext;
using RoomsEnglish.Infraestructure.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfraestructureServices(builder.Configuration); //camada de infra
builder.Services.AddControllers();//Sai no futuro

// Api Request Compression
builder.Services.AddResponseCompression(options => options.Providers.Add<GzipCompressionProvider>());
builder.Services.Configure<GzipCompressionProviderOptions>(options => options.Level = CompressionLevel.Optimal);

builder.Services.Configure<JsonOptions>(options => options.SerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors();

var app = builder.Build();
app.UseCors(c =>
{
    c.AllowAnyHeader();
    c.AllowAnyMethod();
    c.AllowAnyOrigin();
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseResponseCompression();

//TODO: Refactor this controllers from MinimalApi Endpoints
app.MapControllers();

app.MapAuthEndpoints();

app.Run();
