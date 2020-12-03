using System.CodeDom;
using System.Collections.Generic;

namespace landlystHotelWebApp.Classes
{
    public static class HotelManager
    {
        public static List<Room> GetAllRooms()
        {
            return ServerManager.GetAllRooms();
        }

        public static List<TotalPrices> GeTotalPrice(int roomNumber)
        {
            return ServerManager.TotalPrice(roomNumber);
        }
    }
}