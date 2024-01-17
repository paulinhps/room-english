using System.IO.Compression;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.AspNetCore.ResponseCompression;
using RoomsEnglish.Api.AccountContext;
using RoomsEnglish.Infraestructure.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfraestructureServices();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();

// Api Request Compression
builder.Services.AddResponseCompression(options =>
    options.Providers.Add<GzipCompressionProvider>()
);
builder.Services.Configure<GzipCompressionProviderOptions>(options =>
    options.Level = CompressionLevel.Optimal
);

builder.Services.Configure<JsonOptions>(options =>
    options.SerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
);

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

//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();
app.UseRouting();

app.UseResponseCompression();

//TODO: Refactor this controllers from MinimalApi Endpoints
app.MapControllers();

app.MapAuthEndpoints();

app.Run();
