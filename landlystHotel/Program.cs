using System;
using System.Collections.Generic;

namespace landlystHotel
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
            Console.Write("Enter the room number that you want to use :");
            int userRoomNumber = int.Parse(Console.ReadLine());

            List<TotalPrices> totalPrice = HotelManager.GeTotalPrice(userRoomNumber);

            foreach (TotalPrices price in totalPrice)
            {
                Console.WriteLine(price.TotalPrice);
            }


            //List<Features> features = HotelManager.GetRoomFeatures(userRoomNumber);

            //foreach (Features feature in features)
            //{
            //    Console.WriteLine(feature.Description);
            //}


        }
    }
}