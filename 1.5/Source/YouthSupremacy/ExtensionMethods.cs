using RimWorld;
using Verse;

namespace YouthSupremacy;

public static class ExtensionMethods
{
    public static bool SupremeChild(this Ideo ideo)
    {
        return ideo.HasMeme(YouthSupremacyDefOf.YouthSupremacy);
    }
}