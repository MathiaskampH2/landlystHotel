using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace landlystHotel
{
    public static class ServerManager
    {
        private static readonly string Con = DbConnection.Connection();

        private static SqlDataReader rdr = null;

        public static List<Room> GetAllRooms()
        {
            List<Room> rooms = new List<Room>();

            using (SqlConnection connection = new SqlConnection(Con))

            {
                try
                {
                    connection.Open();

                    SqlCommand sql = new SqlCommand("select * from room", connection);
                    rdr = sql.ExecuteReader();

                    while (rdr.Read())
                    {
                        int roomNumber = (int) rdr["RoomNumber"];

                        int hotelNumber = (int) rdr["hotelNumber"];

                        byte floorLevel = Convert.ToByte(rdr["floorLevel"]);

                        decimal price = (decimal) rdr["price"];

                        byte reserved = Convert.ToByte(rdr["reserved"]);

                        string condition = (string) rdr["condition"];

                        Room r = new Room(roomNumber, hotelNumber, floorLevel, price, reserved, condition);

                        rooms.Add(r);
                    }
                }

                finally
                {
                    connection?.Close();

                    rdr?.Close();
                }
            }

            return rooms;
        }

        public static List<TotalPrices> TotalPrice(int roomNumber)
        {
            List<TotalPrices> prices = new List<TotalPrices>();

            using (SqlConnection connection = new SqlConnection(Con))

            {
                try
                {
                    connection.Open();

                    SqlCommand sql = new SqlCommand("sp_GetRoomPrice", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    sql.Parameters.Add(new SqlParameter("@roomNumber", roomNumber));
                    rdr = sql.ExecuteReader();
                    while (rdr.Read())
                    {
                        decimal totalPrice = (decimal) rdr["totalprice"];
                        TotalPrices totalPrices = new TotalPrices(totalPrice);

                        prices.Add(totalPrices);
                    }
                }
                finally
                {
                    connection?.Close();

                    rdr?.Close();
                }
            }

            return prices;
        }


        public static List<Features> GetRoomFeatures(int roomNumber)
        {
            List<Features> features = new List<Features>();

            using (SqlConnection connection = new SqlConnection(Con))

            {
                try
                {
                    connection.Open();

                    SqlCommand sql = new SqlCommand("sp_GetRoomFeatures", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    sql.Parameters.Add(new SqlParameter("@roomNumber", roomNumber));
                    rdr = sql.ExecuteReader();
                    while (rdr.Read())
                    {
                        string description = (string) rdr["description"];

                        Features feature = new Features(description);
                        features.Add(feature);
                    }
                }
                finally
                {
                    connection?.Close();

                    rdr?.Close();
                }
            }

            return features;
        }

        public static List<Reservation> CreateReservation (string phoneNumber, int roomNumber, DateTime checkInDate, DateTime checkOutDate, int daysToStay, decimal totalPrice)
        {
            List<Reservation> reservations = new List<Reservation>();

            List<TotalPrices> totPrices =  TotalPrice(roomNumber);

            string totPrice = string.Concat(totPrices);


            using (SqlConnection connection = new SqlConnection(Con))

            {
                try
                {
                    connection.Open();

                    SqlCommand sql = new SqlCommand("sp_insertReservation", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    sql.Parameters.Add(new SqlParameter("@custPhoneNumber", phoneNumber));
                    sql.Parameters.Add(new SqlParameter("@roomNumber", roomNumber));
                    sql.Parameters.Add(new SqlParameter("@checkInDate", checkInDate));
                    sql.Parameters.Add(new SqlParameter("@checkOutDate", checkOutDate));
                    sql.Parameters.Add(new SqlParameter("@daysToStay", daysToStay));
                    sql.Parameters.Add(new SqlParameter("@totalprice", totalPrice));

                    rdr = sql.ExecuteReader();
                    while (rdr.Read())
                    {
                        string custPhoneNumber = (string)rdr["custPhoneNumber"];
                        string description = (string)rdr["description"];
                        string description = (string)rdr["description"];
                        string description = (string)rdr["description"];
                        string description = (string)rdr["description"];
                        string description = (string)rdr["description"];

                        Reservation reservation = new Reservation(phoneNumber, roomNumber, checkInDate, checkOutDate, daysToStay, totalPrice);
                        reservations.Add(reservation);
                    }
                }
                finally
                {
                    connection?.Close();

                    rdr?.Close();
                }
            }

            return reservations;
        }
    }
}