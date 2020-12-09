using System;
using System.Collections;
using System.Collections.Generic;

namespace landlystHotel
{
    class Program
    {
        static void Main(string[] args)
        {


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

                    case 4:
                        //    string num = "42500043";

                        //    Console.WriteLine(ServerManager.CheckIfCustomerExists(num));
                        Console.Write("Insert date in:");
                        string dateInString = "2020-12-03"; // Console.ReadLine();
                        Console.Write("Insert date out:");
                        string dateOutString = "2020-12-03"; // Console.ReadLine();

                        DateTime dateIn = DateTime.Parse(dateInString);
                        DateTime dateOut = DateTime.Parse(dateOutString);

                        List<Room> roomFea = HotelManager.GetRoomsAvailableBasedOnFeatures(dateIn, dateOut);

                        
                        foreach (Room Room in roomFea)
                        {
                            
                            Console.Write(Room.ToString());

                        }

                        break;
                }
            }
        }
    }
}