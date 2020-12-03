using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;      

namespace landlystHotelWebApp.Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<Room> rooms = HotelManager.GetAllRooms();

            //foreach (Room room in rooms)
            //{
            //    Console.WriteLine(room.RoomNumber);
            //}

            int userRoomNumber = int.Parse(Console.ReadLine());

            List<TotalPrices> totalPrice = HotelManager.GeTotalPrice(userRoomNumber);

            foreach (TotalPrices price in totalPrice)
            {
                Console.WriteLine(price.TotalPrice);
            }
        }
    }
}                                                                                                                                                                                                                                                                                                                                                                                                                                                             