using Polročná_práca_2025_Prvý_rok.MapPart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace DaGame.MapPart
{
    internal class MapInAMap
    {
        MapEngine mapEngine;
       
        public MapInAMap(MapEngine mapEngine)
        {
            this.mapEngine = mapEngine;
           
        }
        private int x = 0;
        private int y = 0;

        List<string> currentItems = new List<string>();


        public List<string>  CheckingTheRoomMovment(string direcion)
        {
            Console.WriteLine(direcion);
            return RoomChanger(direcion);

        }

        private List<string> RoomChanger(string direcion)
        {
            List<string> daRoom = new List<string>();
            if (direcion == "up")
            {
                y--;
            }
            else if (direcion == "down")
            {
                y++;
            }
            else if (direcion == "left")
            {
                x--;
            }
            else if (direcion == "right")
            {
                x++;
            }
            
            foreach (var item in mapEngine.DaMap[y][x])
            { daRoom.Add(item); }
            
            return daRoom;
            // i = the y's
            // j = the x's
            // k = the items
        }
    }
}
