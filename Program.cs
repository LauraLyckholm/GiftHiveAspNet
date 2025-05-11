using GiftHive.Common.Models;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace GiftHive
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var mongodbUsername = builder.Configuration["MongoDb:Username"];
            var mongodbPassword = builder.Configuration["MongoDb:Password"];
            var mongodbDatabase = builder.Configuration["MongoDb:Database"];
            var mongodbCluster = builder.Configuration["MongoDb:Cluster"];

            builder.Services.AddSingleton<IMongoClient, MongoClient>(_ =>
            {
                var connectionUri = $"mongodb+srv://{mongodbUsername}:{mongodbPassword}@{mongodbCluster}/?retryWrites=true&w=majority&appName={mongodbDatabase}";
                return new MongoClient(connectionUri);
            });

            builder.Services.AddScoped(sp =>
            {
                var client = sp.GetRequiredService<IMongoClient>();
                return client.GetDatabase(mongodbDatabase);
            });

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();
            var app = builder.Build();

            // ENDPOINTS
            app.MapGet("/hives", async (IMongoDatabase db) =>
            {
                var hivesCollection = db.GetCollection<Hive>("Hives");
                var hives = await hivesCollection.Find(_ => true).ToListAsync();
                return Results.Ok(hives);
            });
            app.MapGet("/hives/{UserId}", async (int UserId, IMongoDatabase db) =>
            {
                var hivesCollection = db.GetCollection<Hive>("Hives");
                var hives = await hivesCollection.Find(hive => hive.UserId == UserId).ToListAsync();
                return Results.Ok(hives);
            });
            app.MapGet("/users", async (IMongoDatabase db) =>
            {
                var usersCollection = db.GetCollection<User>("Users");
                var users = await usersCollection.Find(_ => true).ToListAsync();
                return Results.Ok(users);
            });
            app.MapPost("/register", async (User user, IMongoDatabase db) =>
            {
                var usersCollection = db.GetCollection<User>("Users");
                await usersCollection.InsertOneAsync(user);
                return Results.Created($"/users/{user.Id}", user);
            });
            app.MapPost("/hives", async (Hive hive, IMongoDatabase db) =>
            {
                var hivesCollection = db.GetCollection<Hive>("Hives");
                await hivesCollection.InsertOneAsync(hive);
                return Results.Created($"/hives/{hive.Id}", hive);
            });

            // app.MapGet("/gifts/bought", async (HiveDb db) => await db.Gifts.Where(gift => gift.IsBought).ToListAsync());
            app.Run();
        }
    }
}


