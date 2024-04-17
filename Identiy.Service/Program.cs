using IdentityService.Application.Command.UserRegister;
using IdentityService.Application.Dtos;
using IdentityService.Application.Extensions;
using MediatR;
using Polly;
using Polly.Extensions.Http;
using Polly.Retry;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddGrpc();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationServices();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        corsbuilder =>
        {
            corsbuilder.WithOrigins("*")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin();
        });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();
app.UseAuthorization();

app.MapControllers();

app.Run();

