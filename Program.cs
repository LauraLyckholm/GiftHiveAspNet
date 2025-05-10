using GiftHive;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<HiveDb>(options => options.UseInMemoryDatabase("Gifts"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();

app.MapGet("/hives", async (HiveDb db) => await db.Hives.ToListAsync());

// app.MapGet("/hives/{UserId}", async (int UserId, HiveDb db) => await db.Hives.FindAsync(UserId) is Gift gift ? Results.Ok(gift) : Results.NotFound());

// app.MapGet("/gifts/bought", async (HiveDb db) => await db.Gifts.Where(gift => gift.IsBought).ToListAsync());
app.Run();
