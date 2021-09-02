using Commander.Models;
using Microsoft.EntityFrameworkCore;

namespace Commander.Data
{
    public class AbcisContext : DbContext
    {
        public AbcisContext(DbContextOptions<AbcisContext> opt) : base(opt)
        {

        }
        public DbSet<AbcisCommand> Commands { get; set; }
    }
}