namespace GiftHive.Common;
public class Gift
{
    public int HiveId { get; set; }
    public string GiftName { get; set; } = string.Empty; // Detta motsvarar gift i gamla apit
    public bool IsBought { get; set; } // Detta motsvarar bought i gamla apit
    // public string[]? Tags { get; set; }
    // public DateTime Date { get; set; }
}