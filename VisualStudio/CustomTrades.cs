using Il2CppTLD.Trader;
using ExpandedTradingFramework.Framework;
using Random = UnityEngine.Random;

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

        private static readonly string[] AnyPills =
        [
            "GEAR_BottlePainkillers",
            "GEAR_BottleAntibiotics",
            "GEAR_BottleCaffeine",
            "GEAR_BottleVitaminC",
            "GEAR_WaterPurificationTablets",
            "GEAR_PainkillerIbuprofen",
            "GEAR_SleepingPills",
        ];

        private static readonly string[] CupsOfCoffee =
        [
            "GEAR_CoffeeCup",
            "GEAR_CoffeeCupSugar",
            "GEAR_CoffeeTin",
        ];

        private static readonly string[] HerbalTea =
        [
            "GEAR_GreenTeaPackage",
            "GEAR_GreenTeaCup",
            "GEAR_GreenTeaCupSugar",
            "GEAR_GreenTeaCupJam"
        ];

        internal static readonly CustomTradeDefinition[] Trades =
            [
                TradeCigarettes_Marlboro(),
                TradeBandageBlueprint(),
                TradeCigarettes_Old(),
                TradeSleepingPills(),
                TradeAnabiotics(),
                TradeIbuprofen(),
                TradeMorphine(),
                TradeSugar(),
                TradeFAK(),
            
                TradeIncreaseTrust()
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
        private static CustomTradeDefinition TradeCigarettes_Old()
        {
            return new CustomTradeDefinition
            {
                Id = "MOD_Cigarettes_Old",
                Enabled = true,
                Description = "Stalker Aids And Supplements - Cigarettes.",
                IsSpecialRequest = false,
                SelectionMode = CustomTradeSelectionMode.DrawPool,
                DrawPool = CustomTradeDrawPool.Rare,
                MinTrust = 250,
                MaxPerTrade = 3,
                Repeatable = true,
                CostItems =
                [
                    CategoryAmountAlt("Any Pills", AnyPills, 6, CustomTradeIcon.CustomIcon("StalkerAidsAndSupplements.Resources.Icons.Ico_AnyPill.png")),
                    CategoryAmountAlt("Cups of Coffee", CupsOfCoffee, 2, CustomTradeIcon.CustomIcon("StalkerAidsAndSupplements.Resources.Icons.Ico_AnyCoffee.png")),
                    PotableWater(1f)
                ],
                DisplayReward = CustomTradeDisplay.Gear("GEAR_CigarettePackOld", 1),
                Reward = CustomTradeReward.Gear("GEAR_CigarettePackOld", 1, CustomRewardStacking.Auto)
            };
        }
        private static CustomTradeDefinition TradeCigarettes_Marlboro()
        {
            return new CustomTradeDefinition
            {
                Id = "MOD_Cigarettes_Marlboro",
                Enabled = true,
                Description = "Stalker Aids And Supplements - Cigarettes.",
                IsSpecialRequest = false,
                SelectionMode = CustomTradeSelectionMode.DrawPool,
                DrawPool = CustomTradeDrawPool.Rare,
                MinTrust = 200,
                MaxPerTrade = 3,
                Repeatable = true,
                CostItems =
                [
                    CategoryAmountAlt("Any Pills", AnyPills, 6, CustomTradeIcon.CustomIcon("StalkerAidsAndSupplements.Resources.Icons.Ico_AnyPill.png")),
                    CategoryAmountAlt("Cups of Coffee", CupsOfCoffee, 2, CustomTradeIcon.CustomIcon("StalkerAidsAndSupplements.Resources.Icons.Ico_AnyCoffee.png")),
                    PotableWater(1f)
                ],
                DisplayReward = CustomTradeDisplay.Gear("GEAR_CigarettePackMarlboro", 1),
                Reward = CustomTradeReward.Gear("GEAR_CigarettePackMarlboro", 1, CustomRewardStacking.Auto)
            };
        }
        private static CustomTradeDefinition TradeIbuprofen()
        {
            return new CustomTradeDefinition
            {
                Id = "MOD_Ibuprofen",
                Enabled = true,
                Description = "Stalker Aids And Supplements - Ibuprofen.",
                IsSpecialRequest = false,
                SelectionMode = CustomTradeSelectionMode.DrawPool,
                DrawPool = CustomTradeDrawPool.Rare,
                MinTrust = 250,
                MaxPerTrade = 3,
                Repeatable = true,
                CostItems =
                [
                    CategoryAmount("Harvestable Plants", HarvestablePlants, 12, CategoryIcon.AnyHarvestPlant),
                    CategoryAmountAlt("Any Pills", AnyPills, 8, CustomTradeIcon.CustomIcon("StalkerAidsAndSupplements.Resources.Icons.Ico_AnyPill.png")),
                    GearAmount("GEAR_HeavyBandage", 3)
                ],
                DisplayReward = CustomTradeDisplay.Gear("GEAR_PainkillerIbuprofen", 1),
                Reward = CustomTradeReward.Gear("GEAR_PainkillerIbuprofen", 1, CustomRewardStacking.Auto)
            };
        }
        private static CustomTradeDefinition TradeSleepingPills()
        {
            return new CustomTradeDefinition
            {
                Id = "MOD_SleepingPills",
                Enabled = true,
                Description = "Stalker Aids And Supplements - Sleeping Pills.",
                IsSpecialRequest = false,
                SelectionMode = CustomTradeSelectionMode.DrawPool,
                DrawPool = CustomTradeDrawPool.Rare,
                MinTrust = 150,
                MaxPerTrade = 3,
                Repeatable = true,
                CostItems =
                [
                    CategoryAmount("Harvestable Plants", HarvestablePlants, 8, CategoryIcon.AnyHarvestPlant),
                    CategoryAmountAlt("Any Pills", AnyPills, 4, CustomTradeIcon.CustomIcon("StalkerAidsAndSupplements.Resources.Icons.Ico_AnyPill.png")),
                    CategoryAmountAlt("Cups of Herbal Tea", HerbalTea, 2, CustomTradeIcon.CustomIcon("StalkerAidsAndSupplements.Resources.Icons.Ico_AnyGreenTea.png")),
                ],
                DisplayReward = CustomTradeDisplay.Gear("GEAR_SleepingPills", 1),
                Reward = CustomTradeReward.Gear("GEAR_SleepingPills", 1, CustomRewardStacking.Auto)
            };
        }
        private static CustomTradeDefinition TradeSugar()
        {
            return new CustomTradeDefinition
            {
                Id = "MOD_Sugar",
                Enabled = true,
                Description = "Stalker Aids And Supplements - Sugar.",
                IsSpecialRequest = false,
                SelectionMode = CustomTradeSelectionMode.DrawPool,
                DrawPool = CustomTradeDrawPool.Common,
                MinTrust = 75,
                MaxPerTrade = 10,
                Repeatable = true,
                CostItems =
                [
                    CategoryAmount("Harvestable Plants", HarvestablePlants, 12, CategoryIcon.AnyHarvestPlant),
                    PotableWater(1.5f)
                ],
                DisplayReward = CustomTradeDisplay.Gear("GEAR_SugarA", 1),
                Reward = CustomTradeReward.Gear("GEAR_SugarA", 1, CustomRewardStacking.Auto)
            };
        }
        private static CustomTradeDefinition TradeMorphine()
        {
            return new CustomTradeDefinition
            {
                Id = "MOD_Morphine",
                Enabled = true,
                Description = "Stalker Aids And Supplements - Morphine Vial.",
                IsSpecialRequest = false,
                SelectionMode = CustomTradeSelectionMode.DrawPool,
                DrawPool = CustomTradeDrawPool.ExtraRare,
                MinTrust = 350,
                MaxPerTrade = 1,
                Repeatable = true,
                CostItems =
                [
                    CategoryAmountAlt("Any Pills", AnyPills, 18, CustomTradeIcon.CustomIcon("StalkerAidsAndSupplements.Resources.Icons.Ico_AnyPill.png")),
                    GearAmount("GEAR_Cloth", 6),
                    Antiseptic(0.5f)
                ],
                DisplayReward = CustomTradeDisplay.Gear("GEAR_PainkillerMorphineVial", 1),
                Reward = CustomTradeReward.Gear("GEAR_PainkillerMorphineVial", 1, CustomRewardStacking.Auto)
            };
        }
        private static CustomTradeDefinition TradeFAK()
        {
            return new CustomTradeDefinition
            {
                Id = "MOD_FirstAidKit",
                Enabled = true,
                Description = "Stalker Aids And Supplements - First Aid Kit.",
                IsSpecialRequest = false,
                SelectionMode = CustomTradeSelectionMode.DrawPool,
                DrawPool = CustomTradeDrawPool.ExtraRare,
                MinTrust = 450,
                MaxPerTrade = 1,
                Repeatable = true,
                CostItems =
                [
                    CategoryAmountAlt("Any Pills", AnyPills, 24, CustomTradeIcon.CustomIcon("StalkerAidsAndSupplements.Resources.Icons.Ico_AnyPill.png")),
                    GearAmount("GEAR_BarkTinder", 8),
                    GearAmount("GEAR_PtarmiganFeathers", 2),
                    Antiseptic(0.5f)
                ],
                DisplayReward = CustomTradeDisplay.Gear("GEAR_FirstAidKitPainkiller", 1),
                Reward = CustomTradeReward.Gear("GEAR_FirstAidKitPainkiller", 1, CustomRewardStacking.Auto)
            };
        }
        private static CustomTradeDefinition TradeAnabiotics()
        {
            return new CustomTradeDefinition
            {
                Id = "MOD_Anabiotics",
                Enabled = true,
                Description = "Stalker Aids And Supplements - Anabiotics.",
                IsSpecialRequest = false,
                SelectionMode = CustomTradeSelectionMode.DrawPool,
                DrawPool = CustomTradeDrawPool.ExtraRare,
                MinTrust = 475,
                MaxPerTrade = 1,
                Repeatable = true,
                CostItems =
                [
                    CategoryAmountAlt("Any Pills", AnyPills, 18, CustomTradeIcon.CustomIcon("StalkerAidsAndSupplements.Resources.Icons.Ico_AnyPill.png")),
                    GearAmount("GEAR_EmergencyStim", 1),
                    Antiseptic(0.5f)
                ],
                DisplayReward = CustomTradeDisplay.Gear("GEAR_Anabiotics", 1),
                Reward = CustomTradeReward.Gear("GEAR_Anabiotics", 1, CustomRewardStacking.Auto)
            };
        }
        private static CustomTradeDefinition TradeBandageBlueprint()
        {
            return new CustomTradeDefinition
            {
                Id = "MOD_BandageBlueprint",
                Enabled = true,
                Description = "Stalker Aids And Supplements - Burdock Dressing Blueprint.",
                IsSpecialRequest = false,
                SelectionMode = CustomTradeSelectionMode.DrawPool,
                DrawPool = CustomTradeDrawPool.AlwaysShown,
                MinTrust = 350,
                MaxPerTrade = 1,
                Repeatable = false,
                CostItems =
                [
                    GearAmount("GEAR_BurdockPrepared", 6),
                    GearAmount("GEAR_CookingOil", 2),
                    GearAmount("GEAR_CarBattery", 1),
                    Kerosene(3)
                ],
                DisplayReward = CustomTradeDisplay.Gear("GEAR_NoteNaturalBandage", 1),
                Reward = CustomTradeReward.Gear("GEAR_NoteNaturalBandage", 1, CustomRewardStacking.Auto)
            };
        }
        private static CustomTradeDefinition TradeIncreaseTrust()
        {
            return new CustomTradeDefinition
            {
                Id = "MOD_TrustIncrease",
                Enabled = true,
                IsSpecialRequest = true,
                SelectionMode = CustomTradeSelectionMode.DrawPool,
                DrawPool = CustomTradeDrawPool.AlwaysShown,
                MinTrust = 50,
                MaxPerTrade = 1,
                Repeatable = false,
                SpecialRequest = new CustomSpecialRequestDisplay
                {
                    Title = "Sweet tooth",
                    Description = "Sutherland seems quite grumpy.",
                    RequirementText = "Bring something sweet to cheer up Sutherland.",
                    HideRequirementIcon = true,
                    JournalTitle = "Sweet Tooth",
                    JournalDescription = "Bring something sweet to cheer up Sutherland.",
                    JournalTips = [""]
                },
                CostItems =
                [
                    GearAmount("GEAR_RosehipJam", 10)
                ],
                DisplayReward = CustomTradeDisplay.Gear("GEAR_RosehipJam"),
                Reward = CustomTradeReward.None(),
                OnCompleted = context =>
                {
                    TraderManager trader = GameManager.GetTraderManager();
                    if (trader == null) return;

                    int roll = Random.RandomRangeInt(50, 150);
                    trader.AddTrust(roll);
                }
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
        private static CustomTradeItem CategoryAmount(string categoryName, string[] gearNames, int amount, CategoryIcon categoryIcon)
        {
            return new CustomTradeItem
            {
                ExchangeType = ExchangeItemType.CategoryAmount,
                CategoryName = categoryName,
                CategoryGearNames = gearNames,
                CategoryIcon = categoryIcon,
                Amount = amount
            };
        }
        private static CustomTradeItem GearAmount(string gearName, int amount, CustomTradeIcon displayIcon = null)
        {
            return new CustomTradeItem
            {
                ExchangeType = ExchangeItemType.GearAmount,
                GearName = gearName,
                Amount = amount,
                DisplayIcon = displayIcon ?? CustomTradeIcon.None()
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
        private static CustomTradeItem Antiseptic(float liters)
        {
            return new CustomTradeItem
            {
                ExchangeType = ExchangeItemType.Liquid,
                LiquidKind = CustomLiquidKind.Antiseptic,
                LiquidLiters = liters
            };
        }
        private static CustomTradeItem Kerosene(float liters)
        {
            return new CustomTradeItem
            {
                ExchangeType = ExchangeItemType.Liquid,
                LiquidKind = CustomLiquidKind.Kerosene,
                LiquidLiters = liters
            };
        }
    }
}
