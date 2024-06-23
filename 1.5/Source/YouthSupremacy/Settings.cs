using UnityEngine;
using Verse;

namespace YouthSupremacy;

public class Settings : ModSettings
{
    public int maxAge = 18;

    public void DoWindowContents(Rect wrect)
    {
        var options = new Listing_Standard();
        options.Begin(wrect);

        options.Label("Max age for colony pawns:");
        options.IntAdjuster(ref maxAge, 1, 13);
        options.Gap();

        options.End();
    }
    
    public override void ExposeData()
    {
        Scribe_Values.Look(ref maxAge, "maxAge", 18);
    }
}
