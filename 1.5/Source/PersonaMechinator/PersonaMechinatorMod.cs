using Verse;
using UnityEngine;
using HarmonyLib;

namespace PersonaMechinator;

public class PersonaMechinatorMod : Mod
{
    public static Settings settings;

    public PersonaMechinatorMod(ModContentPack content) : base(content)
    {
        Log.Message("Hello world from PersonaMechinator");

        // initialize settings
        settings = GetSettings<Settings>();
#if DEBUG
        Harmony.DEBUG = true;
#endif
        Harmony harmony = new Harmony("keyz182.rimworld.PersonaMechinator.main");	
        harmony.PatchAll();
    }

    public override void DoSettingsWindowContents(Rect inRect)
    {
        base.DoSettingsWindowContents(inRect);
        settings.DoWindowContents(inRect);
    }

    public override string SettingsCategory()
    {
        return "PersonaMechinator_SettingsCategory".Translate();
    }
}
