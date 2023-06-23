using ItemDataApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ItemDataApi.Data;

public class ItemContext : DbContext
{
    public ItemContext(DbContextOptions<ItemContext> opts) : base(opts)
    {
        
    }

    public DbSet<Item> Items { get; set; }
}