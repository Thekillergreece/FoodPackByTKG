using Il2CppTLD.Trader;
using ExpandedTradingFramework.Framework;

namespace StalkerAidsAndSupplementsMod.Trades
{
    internal static class CustomTrades
    {
        private static readonly string[] HarvestablePlants =
        [
            "GEAR_MapleSapling",
            "GEAR_BirchSapling",
            "GEAR_BarkTinder",
            "GEAR_Burdock",
            "GEAR_OldMansBeardHarvested",
            "GEAR_ReishiMushroom",
            "GEAR_RoseHip",
            "GEAR_CattailStalk",
            "GEAR_Acorn"
        ];

        private static readonly string[] AnyTinder =
        [
            "GEAR_Tinder",
            "GEAR_BarkTinder",
            "GEAR_CattailStalk",
            "GEAR_CashBundle",
            "GEAR_Newsprint",
            "GEAR_NewsprintRoll",
            "GEAR_PaperStack",
            "GEAR_CatTailTinder",
        ];

        private static readonly string[] AnyPills =
        [
            "GEAR_BottlePainkillers",
            "GEAR_BottleAntibiotics",
            "GEAR_BottleVitaminC",
            "GEAR_BottleCaffeine",
            "GEAR_WaterPurificationTablets",
        ];

        private static readonly string[] AnyRawAnimalMeat =
        [
            "GEAR_RawMeatRabbit",
            "GEAR_RawMeatDeer",
            "GEAR_RawMeatWolf",
            "GEAR_RawMeatBear",
            "GEAR_RawMeatCougar",
            "GEAR_RawMeatPtarmigan",
            "GEAR_RawMeatCougar",
        ];

        private static readonly string[] AnyRawFishMeat =
[
            "GEAR_RawGoldeye",
            "GEAR_RawCohoSalmon",
            "GEAR_RawLakeWhiteFish",
            "GEAR_RawSmallmouthBass",
            "GEAR_RawBurbot",
            "GEAR_RawRedIrishLord",
            "GEAR_RawRockfish",
            "GEAR_RawRainbowTrout",
        ];

        private static readonly string[] AnyLogWood =
        [
            "GEAR_HardWood",
            "GEAR_SoftWood",
            "GEAR_Firelog",
        ];

        private static readonly string[] AnyAccelerant =
        [
            "GEAR_Accelerant",
            "GEAR_GunPowderCan",
            "GEAR_LampFuel",
            "GEAR_LampFuelFull",
            "GEAR_JerryCanRusty",
        ];

        private static readonly string[] AnyTreatmentMedicine =
        [
            "GEAR_BottleAntibiotics",
            "GEAR_BottlePainkillers",
            "GEAR_HeavyBandage",
            "GEAR_BurdockTea",
            "GEAR_BirchBarkTea",
            "GEAR_EmergencyStim",
            "GEAR_ReishiTea",
            "GEAR_RoseHipTea",
        ];

        private static readonly string[] CupsOfCoffee =
        [
            "GEAR_CoffeeCup",
            "GEAR_CoffeeTin",
            "GEAR_HotCocoaBox",
        ];

        private static readonly string[] HerbalTea =
        [
            "GEAR_GreenTeaPackage",
            "GEAR_GreenTeaCup",
        ];

        internal static readonly CustomTradeDefinition[] Trades =
            [
                TradeCheese_Package(),
                TradeRedWine_Bottle(),
                TradeNanaimoBar(),
                TradeSpam(),
                TradeSleepSoup(),

            ];

        internal static CustomTradeDefinition[] GetEnabledTrades()
        {
            {
                List<CustomTradeDefinition> enabledTrades = [];
                for (int i = 0; i < Trades.Length; i++)
                {
                    CustomTradeDefinition trade = Trades[i];
                    if (trade != null && trade.Enabled) enabledTrades.Add(trade);
                }
                return [.. enabledTrades];
            }
        }
        // Trades List Starting Here
        //______________________________________________________________________________________________________________
        private static CustomTradeDefinition TradeCheese_Package()
        {
            return new CustomTradeDefinition
            {
                Id = "MOD_Cheese_Package",
                Enabled = true,
                Description = "Individually wrapped and satisfying to peel apart.",
                IsSpecialRequest = false,
                SelectionMode = CustomTradeSelectionMode.DrawPool,
                DrawPool = CustomTradeDrawPool.Common,
                MinTrust = 50,
                MaxPerTrade = 10,
                Repeatable = true,
                CostItems =
                [
                    CategoryAmountAlt("Any Pills", AnyPills, 3),
                    CategoryAmountAlt("Herbal Tea", HerbalTea, 2),
                    PotableWater(1f)
                ],
                DisplayReward = CustomTradeDisplay.Gear("GEAR_CheesePackage", 1),
                Reward = CustomTradeReward.Gear("GEAR_CheesePackage", 1, CustomRewardStacking.Auto)
            };
        }

        private static CustomTradeDefinition TradeRedWine_Bottle()
        {
            return new CustomTradeDefinition
            {
                Id = "MOD_RedWine_Bottle",
                Enabled = true,
                Description = "A bottle of wine for that big celebration. High quality and very rare.",
                IsSpecialRequest = false,
                SelectionMode = CustomTradeSelectionMode.DrawPool,
                DrawPool = CustomTradeDrawPool.Rare,
                MinTrust = 200,
                MaxPerTrade = 3,
                Repeatable = true,
                CostItems =
                [
                    CategoryAmountAlt("Any Raw Animal Meat", AnyRawAnimalMeat, 5),
                    CategoryAmountAlt("Any Raw Fish Meat", AnyRawFishMeat, 5),
                    PotableWater(3f)
                ],
                DisplayReward = CustomTradeDisplay.Gear("GEAR_RedWineBottle", 1),
                Reward = CustomTradeReward.Gear("GEAR_RedWineBottle", 1, CustomRewardStacking.Auto)
            };
        }

        private static CustomTradeDefinition TradeNanaimoBar()
        {
            return new CustomTradeDefinition
            {
                Id = "MOD_NanaimoBar",
                Enabled = true,
                Description = "A large bar of Nanaimo bar. Very calorie dense.",
                IsSpecialRequest = false,
                SelectionMode = CustomTradeSelectionMode.DrawPool,
                DrawPool = CustomTradeDrawPool.ExtraRare,
                MinTrust = 250,
                MaxPerTrade = 3,
                Repeatable = true,
                CostItems =
                [
                    CategoryAmountAlt("Any Log Wood", AnyLogWood, 12),
                    CategoryAmountAlt("Any Tinder", AnyTinder, 8),
                    PotableWater(3f)
                ],
                DisplayReward = CustomTradeDisplay.Gear("GEAR_NanaimoBar", 1),
                Reward = CustomTradeReward.Gear("GEAR_NanaimoBar", 1, CustomRewardStacking.Auto)
            };
        }

        private static CustomTradeDefinition TradeSpam()
        {
            return new CustomTradeDefinition
            {
                Id = "MOD_Spam",
                Enabled = true,
                Description = "Chopped and canned ham. An acquired taste but cheap, simple, and will do in a pinch.",
                IsSpecialRequest = false,
                SelectionMode = CustomTradeSelectionMode.DrawPool,
                DrawPool = CustomTradeDrawPool.Common,
                MinTrust = 100,
                MaxPerTrade = 10,
                Repeatable = true,
                CostItems =
                [
                    CategoryAmountAlt("Any Accelerant", AnyAccelerant, 2),
                    CategoryAmountAlt("Any Treatment Medicine", AnyTreatmentMedicine, 4),
                    CategoryAmountAlt("Any Log Wood", AnyLogWood, 6),
                    PotableWater(1f)
                ],
                DisplayReward = CustomTradeDisplay.Gear("GEAR_Spam", 1),
                Reward = CustomTradeReward.Gear("GEAR_Spam", 1, CustomRewardStacking.Auto)
            };
        }

        private static CustomTradeDefinition TradeSleepSoup()
        {
            return new CustomTradeDefinition
            {
                Id = "MOD_SleepSoup",
                Enabled = true,
                Description = "Sleep Soup",
                IsSpecialRequest = false,
                SelectionMode = CustomTradeSelectionMode.DrawPool,
                DrawPool = CustomTradeDrawPool.Rare,
                MinTrust = 150,
                MaxPerTrade = 10,
                Repeatable = true,
                CostItems =
                [
                    CategoryAmountAlt("Any Harvestable Plant", HarvestablePlants, 4),
                    CategoryAmountAlt("Any box of Coffee or Hot Cocoa", CupsOfCoffee, 4),
                    CategoryAmountAlt("Any Log Wood", AnyLogWood, 8),
                    PotableWater(2f)
                ],
                DisplayReward = CustomTradeDisplay.Gear("GEAR_SleepSoup", 1),
                Reward = CustomTradeReward.Gear("GEAR_SleepSoup", 1, CustomRewardStacking.Auto)
            };
        }

        // Trade list ends here
        //________________________________________________________________________________
        private static CustomTradeItem CategoryAmountAlt(string categoryName, string[] gearNames, int amount, CustomTradeIcon displayIcon = null)
        {
            return new CustomTradeItem
            {
                ExchangeType = ExchangeItemType.CategoryAmount,
                CategoryName = categoryName,
                CategoryGearNames = gearNames,
                DisplayIcon = displayIcon ?? CustomTradeIcon.None(),
                Amount = amount
            };
        }
        private static CustomTradeItem PotableWater(float liters)
        {
            return new CustomTradeItem
            {
                ExchangeType = ExchangeItemType.Liquid,
                LiquidKind = CustomLiquidKind.PotableWater,
                LiquidLiters = liters
            };
        }
    }
}
