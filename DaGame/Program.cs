using System.Numerics;
using System.Threading;
using DaGame.MapPart;
using Polročná_práca_2025_Prvý_rok.FightingPart;
using Polročná_práca_2025_Prvý_rok.MapPart;

engine engine = new engine();
MapEngine mapEngine = new MapEngine();

VisualMap visualMap = new VisualMap(mapEngine);
//engine.Play(player, monster);
bool itsDead = false;

itsDead = mapEngine.Run();

if (itsDead!)
{ visualMap.DaVisualMap(); }