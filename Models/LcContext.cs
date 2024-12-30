using Microsoft.EntityFrameworkCore;

namespace PrjLcApi.Models
{
    public class LcContext : DbContext
    {
        public LcContext(DbContextOptions<LcContext> options)
        : base(options)
        {
        }

        public DbSet<LoanData> LcItems { get; set; } = null!;






    }
}
