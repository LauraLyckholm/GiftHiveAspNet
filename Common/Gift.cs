using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GiftHive.Common;
public class Gift
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public ObjectId Id { get; set; }
    public required string GiftName { get; set; } // Detta motsvarar gift i gamla apit
    public int HiveId { get; set; }
    public bool IsBought { get; set; } // Detta motsvarar bought i gamla apit
    public string[]? Tags { get; set; }
    public DateTime Date { get; set; }
}