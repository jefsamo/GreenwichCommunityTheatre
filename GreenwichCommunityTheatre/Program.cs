using GreenwichCommunityTheatre.Extensions;
using Serilog;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, services, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration).ReadFrom.Services(services));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDependencies(builder.Configuration);
builder.Services.AddSwagger();

var app = builder.Build();

app.UseSerilogRequestLogging();

app.Use(async (context, next) =>
{
    await next();

    if (context.Response.StatusCode == 401)
    {
        context.Response.ContentType = "application/json";
        var response = new { message = "Unauthenticated", status = 401 };
        await context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
    else if (context.Response.StatusCode == 403)
    {
        context.Response.ContentType = "application/json";
        var response = new { message = "You can not access this resource", status = 403 };
        await context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(p => p.WithOrigins("http://localhost:5173").AllowAnyHeader().AllowAnyMethod().AllowCredentials());

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
