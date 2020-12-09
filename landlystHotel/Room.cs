using System.Collections.Generic;
using System.Text;

namespace landlystHotel
{
    public class Room
    {
        public int RoomNum { get; set; }

        public decimal RoomPrice { get; set; }

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