using System;
using RimWorld;
using Verse;
using VREAndroids; 

namespace ChildSupremacy;

public class RitualStage_InteractWithAdult : RitualStage
{
    public override TargetInfo GetSecondFocus(LordJob_Ritual ritual)
    {
        return (TargetInfo) (Thing) ritual.assignments.Participants.FirstOrDefault<Pawn>((Predicate<Pawn>) (p => p.ageTracker.AgeBiologicalYears >= 18 && !p.IsAndroid()));
    }
}