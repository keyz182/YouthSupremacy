using RimWorld;
using Verse;

namespace ChildSupremacy;

[DefOf]
public static class ChildSupremacyDefOf
{
    // Remember to annotate any Defs that require a DLC as needed e.g.
    // [MayRequireBiotech]
    // public static GeneDef YourPrefix_YourGeneDefName;

    public static IncidentDef OrphanWandersIn;
    public static PawnKindDef Orphan;
    public static MemeDef ChildSupremacy;
    public static JobDef Expel;
    public static TaleDef ExpelledAdult;
    
    static ChildSupremacyDefOf() => DefOfHelper.EnsureInitializedInCtor(typeof(ChildSupremacyDefOf));
}
