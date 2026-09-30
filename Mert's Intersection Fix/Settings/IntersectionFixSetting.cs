using Colossal.IO.AssetDatabase;
using Game.Modding;

namespace MertsIntersectionFix.Settings
{
    [FileLocation("ModsSettings/MertsIntersectionFix/MertsIntersectionFix")]

    public class IntersectionFixSettings : ModSetting
    {

        public IntersectionFixSettings(IMod mod) : base(mod)
        {
        }

        public override void SetDefaults()
        {
          
        }
    }
}