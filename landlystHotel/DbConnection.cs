using System.Configuration;
using System.Data.SqlClient;
using System.Runtime.Remoting.Messaging;

namespace landlystHotelWebApp.Classes
{
    public static class DbConnection
    {
        public static string connection()
        { 
            string con = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;

            return con;
        }
    }
}
