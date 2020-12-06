using System;
using System.Collections.Generic;

namespace landlystHotel
{
    class Program
    {
        static void Main(string[] args)
        {
            #region testData


            //List<Room> rooms = HotelManager.GetAllRooms();

            //foreach (Room room in rooms)
            //{
            //    Console.WriteLine(room.RoomNumber);
            //}
            //Console.Write("Enter the room number that you want to use :");
            //int userRoomNumber = int.Parse(Console.ReadLine());

            //List<TotalPrices> totalPrice = HotelManager.GeTotalPrice(userRoomNumber);

            //foreach (TotalPrices price in totalPrice)
            //{
            //    Console.WriteLine(price.TotalPrice);
            //}


            //List<Features> features = HotelManager.GetRoomFeatures(userRoomNumber);

            //foreach (Features feature in features)
            //{
            //    Console.WriteLine(feature.Description);
            //}

            #endregion


            Gui gui = new Gui();
            gui.PrintGui();

            bool start = false;

            while (!start)
            {
                int userChooseMenu = int.Parse(Console.ReadLine());

                switch (userChooseMenu)
                {
                    case 1:
                        Console.Clear();
                        Console.Write("first name :");
                        string fName = Console.ReadLine();
                        Console.Clear();
                        Console.Write("last name :");
                        string lName = Console.ReadLine();
                        Console.Clear();
                        Console.Write("zipcode :");
                        int zipCode = int.Parse(Console.ReadLine());
                        Console.Clear();
                        Console.Write("address :");
                        string address = Console.ReadLine();
                        Console.Clear();
                        Console.Write("phone number :");
                        string phoneNumber = Console.ReadLine();

                        Console.Clear();
                        Console.Write("email :");
                        string email = Console.ReadLine();
                        Console.Clear();
                        HotelManager.CreateCustomer(fName, lName, zipCode, address, phoneNumber, email);
                        gui.PrintGui();
                        break;
                    case 2:
                        Console.Clear();
                        Console.Write("Phone number :");
                        string resPhoneNumber = Console.ReadLine();
                        Console.Write("Room Number :");
                        int roomNumber = int.Parse(Console.ReadLine());
                        Console.Clear();

                        Console.Write("check in date format : yyyy-mm-dd :");
                        string userCheckInDate = Console.ReadLine();
                        Console.Clear();
                        DateTime checkInDate;
                        DateTime.TryParse(userCheckInDate, out checkInDate);

                        Console.Clear();
                        Console.Write("check out date format : yyyy-mm-dd :");
                        string userCheckOutDate = Console.ReadLine();
                        Console.Clear();
                        DateTime checkOutDate;
                        DateTime.TryParse(userCheckOutDate, out checkOutDate);
                        HotelManager.CreateReservation(resPhoneNumber, roomNumber, checkInDate, checkOutDate);
                        gui.PrintGui();
                        break;


                    case 3:
                        start = true;
                        break;
                }
            }
        }
    }
}