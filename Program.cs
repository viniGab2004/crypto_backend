using crypto.Encryptations;
using crypto.Handler;
using crypto.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<EncryptServices>();
builder.Services.AddScoped<EncryptHandler>();
builder.Services.AddTransient<AESService>();
builder.Services.AddTransient<DESService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
