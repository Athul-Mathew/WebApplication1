var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();  // Required
builder.Services.AddSwaggerGen();           // Required

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();                        // Required
    app.UseSwaggerUI();                      // Required
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
