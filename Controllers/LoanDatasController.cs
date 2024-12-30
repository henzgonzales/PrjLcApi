using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrjLcApi.Models;
using PrjLcApi.Services;
using PrjLcApi.DAL;
using PrjLcApi.BL;

namespace PrjLcApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanDatasController : ControllerBase
    {
        private readonly DatabaseContextLoanData _context;
        private readonly LoanDataServices _loanDataServices;

        public LoanDatasController(DatabaseContextLoanData context)
        {
            _context = context;
            _loanDataServices = new LoanDataServices(_context);
        }

        // GET: api/LoanDatas/5
        [HttpGet("GetLoanData/{propertyvalue}/{loanamount}")]
        public async Task<List<LoanData>> GetLoanData(string propertyvalue, string loanamount)
        {
            _ = new List<LoanData>();
            LoanDataBL blLoanData = new();
            LoanData lData = new();
            List<LoanData> list;
            try
            {
                string sLvr = blLoanData.GetLvr(Convert.ToDecimal(propertyvalue), Convert.ToDecimal(loanamount));

                lData.PropertyValue = Convert.ToDecimal(propertyvalue);
                lData.LoanAmount = Convert.ToDecimal(loanamount);
                lData.Lvr = sLvr;

                _loanDataServices.PostData(lData);

                string sql = "select top 1 * from loandata order by id desc";
                list = await _context.LoanData.FromSqlRaw(sql).ToListAsync();
            }

            catch (Exception ex)
            {
#pragma warning disable S112 // General or reserved exceptions should never be thrown
                throw new Exception(ex.Message);
#pragma warning restore S112 // General or reserved exceptions should never be thrown
            }

            return list;
        }
    }
}
