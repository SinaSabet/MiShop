using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using UserProfile.Presentation.Extensions;
using UserProfile.Presentation.Services;
using UserProfileService.Application.Extensions;
using UserProfileService.Infrastructure;
using UserProfileService.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<UserProfileContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("userprofiledb"),
                builder => builder.MigrationsAssembly(typeof(UserProfileContext).Assembly.FullName)));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.RegisterInfrastructureServices().AddApplicationServices();
builder.Services.AddGrpc();
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
app.MapGrpcService<GetUserGrpcService>();
app.UseCors();
app.UseAuthorization();

app.MapControllers();

app.Run();
