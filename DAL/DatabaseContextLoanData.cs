using Microsoft.EntityFrameworkCore;
using PrjLcApi.Models;

namespace PrjLcApi.DAL
{
    public class DatabaseContextLoanData : DbContext
    {
        public DatabaseContextLoanData(DbContextOptions<DatabaseContextLoanData> options) : base(options) { }

        public DbSet<LoanData> LoanData { get; set; }   
    }
}
