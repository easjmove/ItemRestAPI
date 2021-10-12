using ItemLibrary;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItemRestAPI.AppDbContext
{
    public class ItemContext : DbContext
    {
        public ItemContext(DbContextOptions<ItemContext> contextOptions) : base(contextOptions)
        {
        }

        public DbSet<Item> Items { get; set; }
    }
}
