using Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// IoC
// builder.Services.AddTransient<UserRepository>();
// builder.Services.AddTransient<UserRepositoryMariaDB>();
builder.Services.AddScoped<IUserRepository, UserRepositoryMariaDB>();

// Add services to the container.

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
