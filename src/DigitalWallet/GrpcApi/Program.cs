using GrpcApi.Services;
using FluentValidation;
using GrpcApi.Interceptors;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();
builder.Services.AddGrpc(
    options =>
    {
        options.Interceptors.Add<ValidationInterceptor>();
    } ).AddJsonTranscoding();

builder.Services.AddGrpcSwagger();
builder.Services.AddSwaggerGen();
builder.Services.AddGrpcReflection();
builder.Services.AddValidatorsFromAssemblyContaining(typeof(Program));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapGrpcReflectionService();
}

app.MapGrpcService<WalletService>();

app.Run();