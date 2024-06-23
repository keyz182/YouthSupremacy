using RimWorld;
using Verse;

namespace YouthSupremacy;

[DefOf]
public static class YouthSupremacyDefOf
{
    // Remember to annotate any Defs that require a DLC as needed e.g.
    // [MayRequireBiotech]
    // public static GeneDef YourPrefix_YourGeneDefName;

    public static IncidentDef OrphanWandersIn;
    public static PawnKindDef Orphan;
    public static MemeDef YouthSupremacy;
    public static JobDef Expel;
    public static TaleDef ExpelledAdult;
    public static XenotypeDef MechCaretaker;
    
    static YouthSupremacyDefOf() => DefOfHelper.EnsureInitializedInCtor(typeof(YouthSupremacyDefOf));
}
