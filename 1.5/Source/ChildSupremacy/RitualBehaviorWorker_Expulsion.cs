using RimWorld;
using Verse;
using VREAndroids; 

namespace ChildSupremacy;

public class RitualBehaviorWorker_Expulsion: RitualBehaviorWorker
{
    public RitualBehaviorWorker_Expulsion()
    {
    }

    public RitualBehaviorWorker_Expulsion(RitualBehaviorDef def)
        : base(def)
    {
    }

    public override void PostCleanup(LordJob_Ritual ritual)
    {
        Pawn warden = ritual.PawnWithRole("expeller");
        Pawn prisoner = ritual.PawnWithRole("adult");
        if (prisoner == null || prisoner.ageTracker.AgeBiologicalYears < 18 || prisoner.IsAndroid())
            return;
        WorkGiver_Warden_TakeToBed.TryTakePrisonerToBed(prisoner, warden);
        prisoner.guest.WaitInsteadOfEscapingFor(1250);
    }
}