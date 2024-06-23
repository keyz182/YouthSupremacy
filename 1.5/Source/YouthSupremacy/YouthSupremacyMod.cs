using Verse;
using UnityEngine;
using HarmonyLib;

namespace YouthSupremacy;

public class YouthSupremacyMod : Mod
{
    public static Settings settings;

    public YouthSupremacyMod(ModContentPack content) : base(content)
    {
        Log.Message("Hello world from YouthSupremacy");

        // initialize settings
        settings = GetSettings<Settings>();
#if DEBUG
        Harmony.DEBUG = true;
#endif
        Harmony harmony = new Harmony("keyz182.rimworld.YouthSupremacy.main");	
        harmony.PatchAll();
    }

    public override void DoSettingsWindowContents(Rect inRect)
    {
        base.DoSettingsWindowContents(inRect);
        settings.DoWindowContents(inRect);
    }

    public override string SettingsCategory()
    {
        return "YouthSupremacy_SettingsCategory".Translate();
    }
}
