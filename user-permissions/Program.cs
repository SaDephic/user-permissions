using IO.Swagger.Models;
using user_permissions.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (DataContext db = new DataContext())
{
    // пересоздадим базу данных
    db.Database.EnsureDeleted();
    db.Database.EnsureCreated();

    // добавляем начальные данные
    UserRole microsoft = new UserRole { Id = "1", UserLogin = "A", _UserRole = "R" };
    UserRole google = new UserRole { Id = "1", UserLogin = "A", _UserRole = "L" };
    db.Users.AddRange(microsoft, google);

    UserPermissions perm1 = new UserPermissions { UserRole = "R", Permissions = { "1", "2" } };
    UserPermissions perm2 = new UserPermissions { UserRole = "R", Permissions = { "3", "4" } };
    db.Permissions.AddRange(perm1, perm2);

    db.SaveChanges();
}

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
