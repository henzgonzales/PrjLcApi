using Microsoft.EntityFrameworkCore;

namespace PrjLcApi.DAL
{
    public class DbHelperLoanData : IDbHelper
    {
        public readonly DatabaseContextLoanData _context;

        public DbHelperLoanData(DatabaseContextLoanData context)
        {
            this._context = context;
        }

        /// <summary>
        /// Gets the data from the database, accepts generic object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public async Task<List<T>> Get<T>() where T : class
        {
            _ = new List<T>();
            List<T>? list;
            try
            {
                list = await _context.Set<T>().ToListAsync();
            }
            catch (Exception)
            {
#pragma warning disable S112 // General or reserved exceptions should never be thrown
                throw new System.Exception();
#pragma warning restore S112 // General or reserved exceptions should never be thrown
            }

            return list;
        }

        /// <summary>
        /// Handles data insertion to the database, accepts generic object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public void Post<T>(T obj) where T : class
        {
            try
            {
                _context.Set<T>().Add(obj);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
#pragma warning disable S112 // General or reserved exceptions should never be thrown
                throw new Exception(ex.Message);
#pragma warning restore S112 // General or reserved exceptions should never be thrown
            }
        }
    }
}
