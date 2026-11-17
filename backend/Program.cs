using backend.Data;
using backend.Repositories;
using backend.Services;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();


builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<DbconnectionMedicos>();

builder.Services.AddScoped<PacienteRepository>();

builder.Services.AddScoped<PacienteService>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy => policy
        .WithOrigins("http://localhost:4200")
        .AllowAnyHeader()
        .AllowAnyMethod());
});

var app = builder.Build();


app.UseHttpsRedirection();

app.UseAuthorization();


app.UseSwagger();
app.UseSwaggerUI();

app.UseCors();

app.MapControllers();

app.Run();
