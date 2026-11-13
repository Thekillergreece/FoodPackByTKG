using ExpandedTradingFramework.Framework;
using StalkerAidsAndSupplementsMod.Trades;

namespace TKG
{
	internal class Main : MelonMod
	{
        private static AssetBundle? assetBundle;
        internal static AssetBundle TKGAssetBundle
        {
            get => assetBundle ?? throw new System.NullReferenceException(nameof(assetBundle));
        }
        public override void OnInitializeMelon()
        {
            assetBundle = Utilities.LoadFromStream("FoodPackByTKG.Resources.Assets.tkgassets");

            CustomTradeDefinition[] enabledTrades = CustomTrades.GetEnabledTrades();
            CustomTradeRegistry.RegisterExternalTrades(enabledTrades);
        }
    }
}
