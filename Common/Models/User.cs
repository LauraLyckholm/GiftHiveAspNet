using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GiftHive.Common.Models;

public class User
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public ObjectId Id { get; set; }
    public required string UserName { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public string? AccessToken { get; set; } = GenerateAccessToken();
    public Hive[]? Hives { get; set; }
    public Gift[]? Gifts { get; set; }
    // public string[]? SharedHives { get; set; }

    private static string GenerateAccessToken()
    {
        return Guid.NewGuid().ToString();
    }
}
