using Login.Models;
using Login.Services;

var builder = WebApplication.CreateBuilder(args);
var AllowAnyOrigins = "AllowAnyOrigins";
// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowAnyOrigins,
                      policy =>
                      {
                          policy.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
                      });
});
builder.Services.AddEntityFrameworkSqlite().AddDbContext<ApplicationDbContext>();
builder.Services.AddTransient<DataAccess>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
using (var client = new ApplicationDbContext())
{
    client.Database.EnsureCreated();
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(AllowAnyOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
