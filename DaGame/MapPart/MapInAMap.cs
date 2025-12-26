using Polročná_práca_2025_Prvý_rok.FightingPart;
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
        public int x = 0;
        public int y = 0;

        List<string> currentItems = new List<string>();
        List<string> bossLocation = new List<string>();


        public List<string>  CheckingTheRoomMovment(string direcion)
        {
            Console.WriteLine(direcion);
            return RoomChanger(direcion);

        }
        public void GettingDaUplodedXandY()
        {
            List<int> DaThings = new List<int>();

            if (mapEngine.firstlyRuniny == false)
            {
               var a = mapEngine.GettingDaXandYForDaRooms();
               
                foreach (var item in a) // the first one is y and the second one is x
                {
                    DaThings.Add(item);
                }
                x = DaThings[0];
                y = DaThings[1];
            }
            else
            {
                Console.WriteLine("Was?");
                
            }
        }
        public void imLosingIt()
        {
            mapEngine.UpdatingDaXandYForDaRooms(x, y);  
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

            if (y.ToString() == bossLocation[0] && x.ToString() == bossLocation[1])
            {
                daRoom.Add("Boss");
                
                if (bossLocation.Contains("up"))
                {
                    daRoom.Add("up");
                }
                if (bossLocation.Contains("down"))
                {
                    daRoom.Add("down");
                }
                if (bossLocation.Contains("left"))
                {
                    daRoom.Add("left");
                }
                if (bossLocation.Contains("right"))
                {
                    daRoom.Add("right");
                }

                daRoom.Add(x.ToString());
                daRoom.Add(y.ToString());

                Console.WriteLine("You can feel the boss is in one of these walls"); ///////////////////// hier, buddy bud!
            }
            else
            {
                daRoom.Add("idk, filler");
                daRoom.Add(x.ToString());
                daRoom.Add(y.ToString());
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

        public void BossChecking()
        {
            Console.WriteLine("y:");
                foreach (var item in bossLocation)
            {
                Console.WriteLine(item);
                
            }
            Console.WriteLine(":x");
                
        }
        public void BossSpawning()
        {

            foreach (var item in mapEngine.DaBossPlacer())
            {
                bossLocation.Add(item);
            }
            
        }
        public void DaMapSaver(int PML)
        {
            mapEngine.DaMapSaver(x, y, PML);
        }
    }
}
