using PrjLcApi.Models;
using PrjLcApi.DAL;

namespace PrjLcApi.Services
{
    public class LoanDataServices
    {
        private readonly IDbHelper idbHelper;
 
        public LoanDataServices(DatabaseContextLoanData context)
        {
            DatabaseContextLoanData _context;

            _context = context;
            this.idbHelper = new DbHelperLoanData(_context);
        }

        public void PostData(LoanData lData)
        {
             idbHelper.Post<LoanData>(lData);
        }
    }
}
