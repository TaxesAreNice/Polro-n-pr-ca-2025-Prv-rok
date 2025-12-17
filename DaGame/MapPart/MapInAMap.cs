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
                CheckingDaWalls(direcion);
                y--;

            }
            else if (direcion == "down")
            {
                CheckingDaWalls(direcion);
                y++;
            }
            else if (direcion == "left")
            {
                CheckingDaWalls(direcion);
                x--;
            }
            else if (direcion == "right")
            {
                CheckingDaWalls(direcion);
                x++;
            }
            Console.WriteLine(y);
            Console.WriteLine(x);
            foreach (var item in mapEngine.DaMap[y][x])
            { 
              daRoom.Add(item);
            }
            
            return daRoom;
            // i = the y's
            // j = the x's
            // k = the items
        }
        private void CheckingDaWalls(string direcion)
        {
            int xF = mapEngine.daMapSizeX;
            int yF = mapEngine.daMapSizeY;

            if (direcion == "up" && y == 0)
            {
                y++;
            }
            else if (direcion == "down" && y + 1 == yF)
            {
                y--;
            }
            else if (direcion == "left" && x == 0)
            {
                x++;
            }
            else if (direcion == "right" && x + 1 == xF)
            {
                x--;
            }
        }
    }
}
