using System.Linq;
using RimWorld;
using Verse;
using VREAndroids; 

namespace ChildSupremacy;

public class ThoughtWorker_Precept_AdultsInFaction : ThoughtWorker_Precept
{
    protected override ThoughtState ShouldHaveThought(Pawn p)
    {
        return Find.WorldPawns.AllPawnsAlive.Any(p => p.Faction == Faction.OfPlayer && p.ageTracker.Adult && !p.IsAndroid());
    }
}