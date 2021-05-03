using System.Runtime.InteropServices;
using Ceviri.Models;
using Microsoft.EntityFrameworkCore;

namespace Ceviri.Data
{
    public class CeviriContext : DbContext
    {
        public CeviriContext(DbContextOptions<CeviriContext> options)
    : base(options)

        { 

        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Support> Supports { get; set; }
        public DbSet<Supporter> Supporters { get; set; }
        public DbSet<Translate> Translates { get; set; }
        public DbSet<Translator> Translators { get; set; }
        }
}
