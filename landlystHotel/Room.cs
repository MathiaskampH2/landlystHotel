using System.Collections.Generic;
using System.Text;

namespace landlystHotel
{
    public class Room
    {
        public int RoomNum { get; set; }

        public decimal RoomPrice { get; set; }
        //public int HotelNumber  { get; set; }
        //public int FloorLevel { get; set; }
        //public decimal Price { get; set; }
        //public int Reserved { get; set; }
        //public string Condition { get; set; }

        public List<RoomAndFeatures> RoomFeatures { get; set; }

        public override string ToString()
        {
            StringBuilder st = new StringBuilder();

            foreach (RoomAndFeatures roomFeature in RoomFeatures)
            {
                st.AppendLine($"{RoomNum} :  {roomFeature.FeatureDescription}");
            }

            return  st.ToString();
        }

    }
}