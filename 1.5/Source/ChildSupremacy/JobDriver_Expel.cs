using System;
using System.Collections.Generic;
using RimWorld;
using Verse;
using Verse.AI;
using Verse.AI.Group;

namespace ChildSupremacy;

public class JobDriver_Expel : JobDriver
{
    private const TargetIndex VictimIndex = TargetIndex.A;
    private const TargetIndex StandingIndex = TargetIndex.B;

    protected Pawn Victim => (Pawn) this.job.GetTarget(TargetIndex.A).Thing;

    public override bool TryMakePreToilReservations(bool errorOnFailed)
    {
        return this.pawn.Reserve((LocalTargetInfo) (Thing) this.Victim, this.job, errorOnFailed: errorOnFailed);
    }

    protected override IEnumerable<Toil> MakeNewToils()
    {
        
            this.AddEndCondition((Func<JobCondition>) (() => this.GetActor().jobs.curJob.GetTarget(TargetIndex.A).Thing.DestroyedOrNull() ? JobCondition.Incompletable : JobCondition.Ongoing));
            Pawn victim = this.Victim;
            yield return Toils_Goto.GotoThing(TargetIndex.B, PathEndMode.OnCell);
            yield return Toils_General.Wait(35);
            Toil expel = ToilMaker.MakeToil(nameof (MakeNewToils));
            expel.initAction = (Action) (() =>
            {
                this.Victim.SetFactionDirect(Find.FactionManager.RandomNonHostileFaction());
                TaleRecorder.RecordTale(ChildSupremacyDefOf.ExpelledAdult, (object) this.pawn, (object) victim);
            });
            expel.defaultCompleteMode = ToilCompleteMode.Instant;
            yield return Toils_Reserve.Release(TargetIndex.A);
            yield return expel;
    }
}
