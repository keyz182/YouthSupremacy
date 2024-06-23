using System;
using System.Collections.Generic;
using RimWorld;
using Verse;
using Verse.AI.Group;

namespace YouthSupremacy;

public class StageEndTrigger_PawnExpelled : StageEndTrigger
{
    [NoTranslate]
    public string roleId;

    public override Trigger MakeTrigger(
        LordJob_Ritual ritual,
        TargetInfo spot,
        IEnumerable<TargetInfo> foci,
        RitualStage stage)
    {
        if (ritual.Ritual.behavior.def.roles.FirstOrDefault<RitualRole>((Predicate<RitualRole>) (r => r.id == this.roleId)) == null)
            return (Trigger) null;
        Pawn pawn = ritual.assignments.FirstAssignedPawn(this.roleId);
        return pawn == null ? (Trigger) null : (Trigger) new Trigger_TickCondition((Func<bool>) (() => pawn.Faction != Faction.OfPlayer));
    }

    public override void ExposeData() => Scribe_Values.Look<string>(ref this.roleId, "roleId");
}
