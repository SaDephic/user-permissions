using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using user_permissions;

var builder = WebApplication.CreateBuilder(args);

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

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//migraion
/*using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<DataContext>();
    db.Database.Migrate();
}*/

app.Run();

