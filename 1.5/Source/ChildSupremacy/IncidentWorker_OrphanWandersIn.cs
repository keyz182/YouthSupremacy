using RimWorld;
using System;
using Verse;

namespace ChildSupremacy;

public class IncidentWorker_OrphanWandersIn : IncidentWorker
{
    
    protected override bool CanFireNowSub(IncidentParms parms)
    {
      if (!base.CanFireNowSub(parms) || !this.TryFindFormerFaction(out Faction _))
        return false;
      Map target = (Map) parms.target;
      return !target.GameConditionManager.ConditionIsActive(GameConditionDefOf.ToxicFallout) && (!ModsConfig.BiotechActive || !target.GameConditionManager.ConditionIsActive(GameConditionDefOf.NoxiousHaze)) && target.mapTemperature.SeasonAcceptableFor(ThingDefOf.Human) && this.TryFindEntryCell(target, out IntVec3 _);
    }

    protected override bool TryExecuteWorker(IncidentParms parms)
    {
      Map target = (Map) parms.target;
      IntVec3 cell;
      Faction formerFaction;
      if (!this.TryFindEntryCell(target, out cell) || !this.TryFindFormerFaction(out formerFaction))
        return false;
      
      Pawn pawn = PawnGenerator.GeneratePawn(new PawnGenerationRequest(ChildSupremacyDefOf.Orphan, formerFaction, developmentalStages: DevelopmentalStage.Child));
      pawn.SetFaction((Faction) null, (Pawn) null);
      GenSpawn.Spawn((Thing) pawn, cell, target);
      TaggedString taggedString1;
      string kindLabel;
      
        taggedString1 = "ChildSupremacy_OrphanedChild".Translate();
        kindLabel = taggedString1.ToString();
        
      string str = kindLabel;
      TaggedString taggedString2 = pawn.DevelopmentalStage.Child() ? "Child".Translate() : "Person".Translate();
      taggedString1 = this.def.letterLabel.Formatted((NamedArgument) str, pawn.Named("PAWN"));
      TaggedString title = taggedString1.CapitalizeFirst();
      taggedString1 = this.def.letterText.Formatted((NamedArgument) pawn.NameShortColored, (NamedArgument) taggedString2, pawn.Named("PAWN"));
      taggedString1 = taggedString1.AdjustedFor(pawn);
      TaggedString text = taggedString1.CapitalizeFirst();
      PawnRelationUtility.TryAppendRelationsWithColonistsInfo(ref text, ref title, pawn);
      this.SendStandardLetter(title, text, this.def.letterDef, parms, (LookTargets) (Thing) pawn);
      return true;
    }

    private bool TryFindEntryCell(Map map, out IntVec3 cell)
    {
      return CellFinder.TryFindRandomEdgeCellWith((Predicate<IntVec3>) (c => map.reachability.CanReachColony(c)), map, CellFinder.EdgeRoadChance_Ignore, out cell);
    }

    private bool TryFindFormerFaction(out Faction formerFaction)
    {
      return Find.FactionManager.TryGetRandomNonColonyHumanlikeFaction(out formerFaction, false, true);
    }
}