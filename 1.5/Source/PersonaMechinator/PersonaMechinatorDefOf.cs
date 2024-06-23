using RimWorld;
using Verse;

namespace PersonaMechinator;

[DefOf]
public static class PersonaMechinatorDefOf
{
    // Remember to annotate any Defs that require a DLC as needed e.g.
    // [MayRequireBiotech]
    // public static GeneDef YourPrefix_YourGeneDefName;
    
    static PersonaMechinatorDefOf() => DefOfHelper.EnsureInitializedInCtor(typeof(PersonaMechinatorDefOf));
}
