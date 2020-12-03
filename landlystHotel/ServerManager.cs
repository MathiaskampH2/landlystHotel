using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Security.Cryptography.X509Certificates;
using landlystHotelWebApp.Classes;

namespace landlystHotelWebApp.Classes
{
    public static class ServerManager
    {
        private static string con = DbConnection.connection();

        private static SqlDataReader rdr = null;

        public static List<Room> GetAllRooms()
        {
            List<Room> rooms = new List<Room>();

            using (SqlConnection connection = new SqlConnection(con))

            {
                try
                {
                    connection.Open();

                    SqlCommand sql =
                        new SqlCommand(
                            "select roomNumber, hotelNumber, floorLevel, price, reserved, condition from room",
                            connection);
                    rdr = sql.ExecuteReader();

                    while (rdr.Read())
                    {
                        int roomNumber = (int) rdr["RoomNumber"];

                        int hotelNumber = (int) rdr["hotelNumber"];

                        byte floorLevel = Convert.ToByte(rdr["floorLevel"]);

                        decimal price = (decimal) rdr["price"];

                        byte reserved = Convert.ToByte(rdr["reserved"]);

                        string condition = (string) rdr["condition"];

                        Room r = new Room()
                        {
                            RoomNumber = roomNumber, HotelNumber = hotelNumber, FloorLevel = floorLevel, Price = price,
                            Reserved = reserved, Condition = condition
                        };

                        rooms.Add(r);
                    }
                }

                finally
                {
                    if (connection != null)
                    {
                        connection.Close();
                    }

                    if (rdr != null)
                    {
                        rdr.Close();
                    }
                }
            }

            return rooms;
        }

        public static List<TotalPrices> TotalPrice(int roomNumber)
        {
            List<TotalPrices> prices = new List<TotalPrices>();

            using (SqlConnection connection = new SqlConnection(con))

            {
                try
                {
                    connection.Open();

                    SqlCommand sql = new SqlCommand("sp_GetRoomPrice", connection);
                    sql.CommandType = CommandType.StoredProcedure;
                    sql.Parameters.Add(new SqlParameter("@roomNumber", roomNumber));
                    rdr = sql.ExecuteReader();
                    while (rdr.Read())
                    {
                        decimal totalPrice = (decimal)rdr["totalprice"];
                        TotalPrices totalPrices = new TotalPrices()
                        {
                            TotalPrice = totalPrice
                        };

                        prices.Add(totalPrices);

                    }

                }
                finally
                {
                    if (connection != null)
                    {
                        connection.Close();
                    }

                    if (rdr != null)
                    {
                        rdr.Close();
                    }

                }

            }
            return prices;
        }
    }
}