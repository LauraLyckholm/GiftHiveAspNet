using GiftHive.Common;
using Microsoft.EntityFrameworkCore;

class UserDb(DbContextOptions<UserDb> options) : DbContext(options)
{
    public DbSet<User> Users => Set<User>();
}