using GiftHive.Common.Models;
using Microsoft.EntityFrameworkCore;

class GiftDb(DbContextOptions<GiftDb> options) : DbContext(options)
{
    public DbSet<Gift> Gifts => Set<Gift>();
}