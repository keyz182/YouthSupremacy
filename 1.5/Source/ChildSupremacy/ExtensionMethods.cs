using RimWorld;
using Verse;

namespace ChildSupremacy;

public static class ExtensionMethods
{
    public static bool SupremeChild(this Ideo ideo)
    {
        return ideo.HasMeme(ChildSupremacyDefOf.ChildSupremacy);
    }
}