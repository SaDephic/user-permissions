using IO.Swagger.Models;
using IO.Swagger.Security;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using user_permissions;
using user_permissions.Custom;

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

//???
//builder.Services.AddAuthentication(BearerAuthenticationHandler.SchemeName);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    //parse table user-permission https://docs.google.com/document/d/18PbWWj57ERwNVOLKRe0RZb46ws7IxuYrOqmEJcIRgOg/edit#heading=h.w3lo0zm8p1l4
    //new PermFromXML(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\Permissions\\permission_table.html");
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

//migraion
using var scope = app.Services.CreateScope();
var db = scope.ServiceProvider.GetRequiredService<DataContext>();
db.Database.Migrate();

app.Run();

