using Colossal.IO.AssetDatabase;
using Game.Modding;

namespace MertsIntersectionFix.Settings
{
    [FileLocation("ModsSettings/MertsIntersectionFix/MertsIntersectionFix")]

    public class IntersectionFix : ModSetting
    {
        public IntersectionFix(IMod mod) : base(mod)
        {
        }

        public override void SetDefaults()
        {
            throw new System.NotImplementedException();
        }
    }
}