namespace PrjLcApi.DAL
{
    public interface IDbHelper
    {
        Task<List<T>> Get<T>() where T : class;
        void Post<T>(T obj) where T : class;
     }
}
