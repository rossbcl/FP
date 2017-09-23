using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication
{
    public class FPContext : DbContext
    {
        public DbSet<Count> Counts { get; set; }

        public FPContext()
        {
            Database.SetInitializer<FPContext>(null);
        }
    }

    public class Count
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int CountValue { get; set; }
    }

}