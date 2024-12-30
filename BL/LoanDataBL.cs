namespace PrjLcApi.BL
{
    public class LoanDataBL
    {
        public string GetLvr(decimal PropertyValue, decimal LoanAmount)
        {
            string sLvr;
            try
            {
                decimal dLvr = (LoanAmount / PropertyValue);
                sLvr = String.Format("{0:0.00%}", dLvr);
            }
            catch (Exception ex)
            {
#pragma warning disable S112 // General or reserved exceptions should never be thrown
                throw new Exception(ex.Message);
#pragma warning restore S112 // General or reserved exceptions should never be thrown
            }

            return sLvr;
        }
    }
}
