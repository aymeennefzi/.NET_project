using Serilog;
using RestfulApi.Configs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Register(builder.Configuration);


// Configuration de Serilog
builder.Host.UseSerilog((ctx, lc) =>
    lc.WriteTo.Console().ReadFrom.Configuration(ctx.Configuration));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();
app.ApplyMigrations();

app.Run();
