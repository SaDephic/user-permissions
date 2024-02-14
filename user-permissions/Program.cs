using Microsoft.EntityFrameworkCore;
using user_permissions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(o => o.AddPolicy("APIPolicy", corsbuilder =>
{
    corsbuilder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
}));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//use env variables
builder.Configuration.AddEnvironmentVariables();

//service + migraion
builder.Services.AddDbContext<DataContext>(options => options.UseNpgsql(builder.Configuration["DB_STRING"],
        x => x.MigrationsHistoryTable("__user_permissions_efmigrationshistory", "public")
    ));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.UseCors("APIPolicy");

//migraion
using var scope = app.Services.CreateScope();
var db = scope.ServiceProvider.GetRequiredService<DataContext>();
db.Database.Migrate();

app.Run();

