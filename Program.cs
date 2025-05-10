using GiftHive.Common;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddSingleton<IMongoClient, MongoClient>(sp =>
// {
//     var connectionString = builder.Configuration.GetConnectionString("MongoDb");
//     return new MongoClient(connectionString);
// });
// builder.Services.AddScoped(sp =>
// {
//     var client = sp.GetRequiredService<IMongoClient>();
//     return client.GetDatabase("GiftHiveAspNetDb");
// });

builder.Services.AddDbContext<HiveDb>(options => options.UseInMemoryDatabase("Hives"));
builder.Services.AddDbContext<UserDb>(options => options.UseInMemoryDatabase("Users"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();

app.MapGet("/hives", async (HiveDb db) => await db.Hives.ToListAsync());

app.MapGet("/hives/{UserId}", async (int UserId, HiveDb db) => await db.Hives.FindAsync(UserId) is Hive hive ? Results.Ok(hive) : Results.NotFound());

app.MapGet("/users", async (UserDb db) =>
{
    var users = await db.Users.ToListAsync();
    return Results.Ok(users);
});

app.MapPost("/hives", async (Hive hive, HiveDb db) =>
{
    db.Hives.Add(hive);
    await db.SaveChangesAsync();

    return Results.Created($"/hives/{hive.Id}", hive);
});

app.MapPost("/register", async (User user, UserDb db) =>
{
    db.Users.Add(user);
    await db.SaveChangesAsync();

    return Results.Created($"/users/{user.Id}", user);
});

// app.MapGet("/gifts/bought", async (HiveDb db) => await db.Gifts.Where(gift => gift.IsBought).ToListAsync());
app.Run();
