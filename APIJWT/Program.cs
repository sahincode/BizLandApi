using APIJWT.ProgramConfigurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.ConfigureService(builder.Configuration);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
