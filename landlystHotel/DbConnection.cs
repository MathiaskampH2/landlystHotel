using System.Configuration;

namespace landlystHotel
{
    public static class DbConnection
    {
        public static string Connection()
        {
            string con = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;

            return con;
        }
    }
}
