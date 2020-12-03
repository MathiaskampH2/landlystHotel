using System.Collections.Generic;

namespace landlystHotel
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

        public static List<Features> GetRoomFeatures(int roomNumber)
        {
            return ServerManager.GetRoomFeatures(roomNumber);
        }
    }
}