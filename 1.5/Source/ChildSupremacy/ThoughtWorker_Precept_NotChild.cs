using System.Linq;
using RimWorld;
using Verse;
using VREAndroids; 

namespace ChildSupremacy;

public class ThoughtWorker_Precept_NotChild : ThoughtWorker_Precept
{
    protected override ThoughtState ShouldHaveThought(Pawn p)
    {
        return p.ageTracker.AgeBiologicalYears >= 18 && !p.IsAndroid();
    }
}