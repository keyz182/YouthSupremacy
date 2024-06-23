using Verse;
using UnityEngine;
using HarmonyLib;

namespace ChildSupremacy;

public class ChildSupremacyMod : Mod
{
    public static Settings settings;

    public ChildSupremacyMod(ModContentPack content) : base(content)
    {
        Log.Message("Hello world from ChildSupremacy");

        // initialize settings
        settings = GetSettings<Settings>();
#if DEBUG
        Harmony.DEBUG = true;
#endif
        Harmony harmony = new Harmony("keyz182.rimworld.ChildSupremacy.main");	
        harmony.PatchAll();
    }

    public override void DoSettingsWindowContents(Rect inRect)
    {
        base.DoSettingsWindowContents(inRect);
        settings.DoWindowContents(inRect);
    }

    public override string SettingsCategory()
    {
        return "ChildSupremacy_SettingsCategory".Translate();
    }
}
