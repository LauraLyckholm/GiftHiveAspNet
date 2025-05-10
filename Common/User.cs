using System.ComponentModel.DataAnnotations;

namespace GiftHive.Common;

public class User
{
    [Key]
    public int Id { get; set; }
    public required string UserName { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public string? AccessToken { get; set; } = GenerateAccessToken();
    public Hive[]? Hives { get; set; }
    public Gift[]? Gifts { get; set; }
    // public string[]? SharedHives { get; set; }

    private static string GenerateAccessToken()
    {
        Console.WriteLine("Generating access token");
        return Guid.NewGuid().ToString();
    }
}
