global using FastEndpoints;
using WebAPI;
using WebAPI.Core.Extentions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFastEndpoints();
builder.Services.AddNpgsql<CardinarDbContext>("Host=localhost;Port=5432;Username=postgres;Password=6002;Database=cardinar;");
builder.Services.AddAuth();
builder.Services.AddSwagger();

var app = builder.Build();
app.UseFastEndpoints();
app.UseAuthentication();
app.UseAuthorization();

app.UseOpenApi();
app.UseSwaggerUi(opts => opts.Path = "/swagger/{documentName}");

app.Run();