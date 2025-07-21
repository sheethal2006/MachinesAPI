using MachinesAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// NOTE: Using in-memory singleton list. In production, this would be replaced by a database.
builder.Services.AddSingleton<MachineRepository>();  // Register the repository as a singleton(dependency injection)
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
