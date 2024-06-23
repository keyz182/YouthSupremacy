using System;
using RimWorld;
using Verse;
using VREAndroids; 

namespace YouthSupremacy;

public class RitualStage_InteractWithAdult : RitualStage
{
    public override TargetInfo GetSecondFocus(LordJob_Ritual ritual)
    {
        return (TargetInfo) (Thing) ritual.assignments.Participants.FirstOrDefault<Pawn>((Predicate<Pawn>) (p => p.ageTracker.AgeBiologicalYears >= YouthSupremacyMod.settings.maxAge && !p.IsAndroid()));
    }
}