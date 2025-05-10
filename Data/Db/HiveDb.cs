using GiftHive.Common;
using Microsoft.EntityFrameworkCore;

class HiveDb(DbContextOptions<HiveDb> options) : DbContext(options)
{
    public DbSet<Hive> Hives => Set<Hive>();
}