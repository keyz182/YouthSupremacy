using RimWorld;
using Verse;
using Verse.AI;

namespace ChildSupremacy;

public class JobGiver_Expel : ThinkNode_JobGiver
{
    protected override Job TryGiveJob(Pawn pawn)
    {
        Pawn pawn1 = pawn.mindState.duty.focusSecond.Pawn;
        return !pawn.CanReserveAndReach((LocalTargetInfo) (Thing) pawn1, PathEndMode.ClosestTouch, Danger.None) ? (Job) null : JobMaker.MakeJob(ChildSupremacyDefOf.Expel, (LocalTargetInfo) (Thing) pawn1, pawn.mindState.duty.focus);
    }
}
