using ClientGateway.Interceptors;
using ClientGateway.Services;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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
app.MapGrpcService<OrderService>();

app.Run();