using System.Numerics;
using System.Threading;
using Polročná_práca_2025_Prvý_rok.FightingPart;
using Polročná_práca_2025_Prvý_rok.MapPart;

VisualMap visualMap = new VisualMap();
Player player = new Player();
Monster monster = new Monster(100, 5);
engine engine = new engine();

engine.Play(player, monster);
visualMap.DaVisualMap();