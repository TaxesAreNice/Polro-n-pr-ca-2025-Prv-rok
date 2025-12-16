using System.Numerics;
using System.Threading;
using DaGame.MapPart;
using Polročná_práca_2025_Prvý_rok.FightingPart;
using Polročná_práca_2025_Prvý_rok.MapPart;

VisualMap visualMap = new VisualMap();
Player player = new Player();
Monster monster = new Monster(100, 5);
engine engine = new engine();
MapEngine mapEngine = new MapEngine();

//engine.Play(player, monster);
//visualMap.DaVisualMap();
mapEngine.Run();

