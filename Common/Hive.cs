using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GiftHive.Common;

public class Hive
{
    [Key]
    public int Id { get; set; }
    public required string HiveName { get; set; }

    [ForeignKey("User")]
    public required int UserId { get; set; }
    public User User { get; set; } = null!;
    public Gift[]? Gifts { get; set; }
    // public string SharedWith {get; set;}  
}