using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIT.Models
{
    public class Function
    {
        public int ID { get; set; }
    }

    public static class Functions
    {
        public static List<Keyboard> Keyboards { get; set; }
        public static List<LeapMotion> LeapMotions { get; set; }
        public static List<Mouse> Mouses { get; set; }
        public static List<Myo> Myos { get; set; }

        public static void Seed()
        {
            Keyboards = new List<Keyboard>
            {
                new Keyboard { List = "1" },
                new Keyboard { List = "2" },
                new Keyboard { List = "3" }
            };
            int i = 0;
            Keyboards.ForEach(x => x.ID = ++i);

            LeapMotions = new List<LeapMotion>
            {
                new LeapMotion { List = "1" },
                new LeapMotion { List = "2" }
            };
            i = 0;
            LeapMotions.ForEach(x => x.ID = ++i);

            Mouses = new List<Mouse>
            {
                new Mouse { List = "1" },
                new Mouse { List = "2" }
            };
            i = 0;
            Mouses.ForEach(x => x.ID = ++i);

            Myos = new List<Myo>
            {
                new Myo { List = "1" },
                new Myo { List = "2" }
            };
            i = 0;
            Myos.ForEach(x => x.ID = ++i);
        }
    }
}
