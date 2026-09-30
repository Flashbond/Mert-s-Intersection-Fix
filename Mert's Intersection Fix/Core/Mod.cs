using Colossal.IO.AssetDatabase;
using Game;
using Game.Modding;
using Game.SceneFlow;
using HarmonyLib;
using MertsIntersectionFix.Settings;

namespace MertsIntersectionFix.Core
{
    public class Mod : IMod
    {
        #region 1. CORE SYSTEMS & SETTINGS
        private Harmony m_Harmony;
        public static IntersectionFixSettings settings;
        #endregion

        #region 2. MOD LIFECYCLE (IMod)

        public void OnLoad(UpdateSystem updateSystem)
        {
            settings = new IntersectionFixSettings(this);

            settings.RegisterInOptionsUI();
            settings.RegisterKeyBindings();

            AssetDatabase.global.LoadSettings(nameof(Settings), settings, new IntersectionFixSettings(this));

            var lm = GameManager.instance.localizationManager;
            lm.AddSource("en-US", new LocaleEN(settings));

            m_Harmony = new Harmony("com.MertsIntersectionFix");
            m_Harmony.PatchAll();

            ModRuntime.Log("Intersection Fix loaded.");
        }

        public void OnDispose()
        {
            m_Harmony?.UnpatchAll("com.MertsIntersectionFix");
            settings?.UnregisterInOptionsUI();
            settings = null;
        }
        #endregion
    }
}