using System.ComponentModel.DataAnnotations;

namespace GiftHive.Common;
public class Gift
{
    [Key]
    public int Id { get; set; }
    public required string GiftName { get; set; } // Detta motsvarar gift i gamla apit
    public int HiveId { get; set; }
    public bool IsBought { get; set; } // Detta motsvarar bought i gamla apit
    public string[]? Tags { get; set; }
    public DateTime Date { get; set; }
}