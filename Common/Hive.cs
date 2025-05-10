using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GiftHive.Common;

public class Hive
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public ObjectId Id { get; set; }
    public required string HiveName { get; set; }

    [ForeignKey("User")]
    public required int UserId { get; set; }
    public User User { get; set; } = null!;
    public Gift[]? Gifts { get; set; }
    // public string SharedWith {get; set;}  
}