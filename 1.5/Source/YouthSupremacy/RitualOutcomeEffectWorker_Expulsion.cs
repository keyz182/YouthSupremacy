using System.Collections.Generic;
using RimWorld;
using Verse;

namespace YouthSupremacy;

public class RitualOutcomeEffectWorker_Expulsion : RitualOutcomeEffectWorker_FromQuality
{
    public override bool SupportsAttachableOutcomeEffect => false;

    public RitualOutcomeEffectWorker_Expulsion()
    {
    }

    public RitualOutcomeEffectWorker_Expulsion(RitualOutcomeEffectDef def)
        : base(def)
    {
    }

    public override void Apply(
        float progress,
        Dictionary<Pawn, int> totalPresence,
        LordJob_Ritual jobRitual)
    {
        float quality = this.GetQuality(jobRitual, progress);
        RitualOutcomePossibility outcome = this.GetOutcome(quality, jobRitual);
        LookTargets selectedTarget = (LookTargets)jobRitual.selectedTarget;
        string extraLetterText = (string)null;
        if (jobRitual.Ritual != null)
            this.ApplyAttachableOutcome(totalPresence, jobRitual, outcome, out extraLetterText, ref selectedTarget);
        bool flag = false;
        foreach (Pawn key in totalPresence.Keys)
        {
            if (key.IsSlave)
            {
                Need_Suppression need = key.needs.TryGetNeed<Need_Suppression>();
                if (need != null)
                    need.CurLevel = 1f;
                flag = true;
            }
            else
                this.GiveMemoryToPawn(key, outcome.memory, jobRitual);
        }

        string text = (string)(outcome.description.Formatted((NamedArgument)jobRitual.Ritual.Label).CapitalizeFirst() +
                               "\n\n" + this.OutcomeQualityBreakdownDesc(quality, progress, jobRitual));
        string str = this.def.OutcomeMoodBreakdown(outcome);
        if (!str.NullOrEmpty())
            text = text + "\n\n" + str;
        if (flag)
            text = (string)(text + ("\n\n" + "RitualOutcomeExtraDesc_Execution".Translate()));
        if (extraLetterText != null)
            text = text + "\n\n" + extraLetterText;
        string extraOutcomeDesc;
        this.ApplyDevelopmentPoints(jobRitual.Ritual, outcome, out extraOutcomeDesc);
        if (extraOutcomeDesc != null)
            text = text + "\n\n" + extraOutcomeDesc;
        Find.LetterStack.ReceiveLetter(
            "OutcomeLetterLabel".Translate(outcome.label.Named("OUTCOMELABEL"),
                jobRitual.Ritual.Label.Named("RITUALLABEL")), (TaggedString)text,
            outcome.Positive ? LetterDefOf.RitualOutcomePositive : LetterDefOf.RitualOutcomeNegative, selectedTarget);
    }
}