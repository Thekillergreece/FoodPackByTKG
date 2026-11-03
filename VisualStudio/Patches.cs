using Il2CppTLD.Gear;
using Il2CppTLD.IntBackedUnit;

namespace TKG
{
    internal class Patches
    {
        //-----------------------------------------CookingTextures----------------------------------------//

        [HarmonyPatch(typeof(GearItem), nameof(GearItem.Awake))]
        internal class CookingPotMaterials
        {
            private static void Postfix(GearItem __instance)
            {
                if (__instance == null) return;

                string name = __instance.name;

                Cookable cookable = __instance.gameObject.GetComponent<Cookable>();
                if (cookable == null) return;

                if (name.Contains("GEAR_CannedChili") || name.Contains("GEAR_CannedChiliOpened"))
                {
                    cookable.m_CookingPotMaterialsList = new Material[1] { Utilities.ChilliLiquidMaterial() };
                }
                if (name.Contains("GEAR_CannedSpaghetti") || name.Contains("GEAR_CannedSpaghettiOpened"))
                {
                    cookable.m_CookingPotMaterialsList = new Material[1] { Utilities.SpaghettiLiquidMaterial() };
                }
                if (name.Contains("GEAR_CannedStew") || name.Contains("GEAR_CannedStewOpened"))
                {
                    cookable.m_CookingPotMaterialsList = new Material[1] { Utilities.StewLiquidMaterial() };
                }
                if (name.Contains("GEAR_SoyRamen") || name.Contains("GEAR_SoyRamenCooked"))
                {
                    cookable.m_CookingPotMaterialsList = new Material[1] { Utilities.RamenLiquidMaterial() };
                }
                if (name.Contains("GEAR_CupNoodles") || name.Contains("GEAR_CupNoodlesOpen"))
                {
                    cookable.m_CookingPotMaterialsList = new Material[1] { Utilities.NoodlesLiquidMaterial() };
                }
                if (name.Contains("GEAR_HotCocoaBag") || name.Contains("GEAR_HotCocoaBox") || name.Contains("GEAR_HotCocoaCup"))
                {
                    cookable.m_CookingPotMaterialsList = new Material[1] { Utilities.CoffeeLiquidMaterial() };
                }
            }
        }
        //-----------------------------------------CookingTextures END----------------------------------------//

        //-----------------------------------------Buffs/Debuffs----------------------------------------//
        [HarmonyPatch(typeof(GearItem), nameof(GearItem.Awake))]
        internal class FoodBuffs
        {
            private static void Postfix(GearItem __instance)
            {
                if (__instance == null) return;

                string name = __instance.name;

                if (name.Contains("GEAR_CookedToastedSandwich"))
                {
                    FoodMaxStatBuff foodbuff = __instance.gameObject.GetComponent<FoodMaxStatBuff>() ?? __instance.gameObject.AddComponent<FoodMaxStatBuff>();
                    if (foodbuff == null) return;

                    foodbuff.m_TimeActiveHours = 3;
                    foodbuff.m_Stat = FoodMaxStatBuff.StatType.Stamina;
                    foodbuff.m_CanStack = true;
                    foodbuff.m_Buff = 10;
                }
                if (name.Contains("GEAR_CookedApplePie"))
                {
                    CausesHeadacheDebuff headache = __instance.gameObject.GetComponent<CausesHeadacheDebuff>() ?? __instance.gameObject.AddComponent<CausesHeadacheDebuff>();
                    if (headache == null) return;

                    FoodMaxStatBuff foodbuff = __instance.gameObject.GetComponent<FoodMaxStatBuff>() ?? __instance.gameObject.AddComponent<FoodMaxStatBuff>();
                    if (foodbuff == null) return;

                    headache.m_CausesHeadacheThreshold = 0.5f;
                    headache.m_HeadacheSettings = Utilities.HeadacheData;
                    Utilities.HeadacheData.m_HeadacheDurationHours = 0.33f;

                    foodbuff.m_TimeActiveHours = 3;
                    foodbuff.m_Stat = FoodMaxStatBuff.StatType.Stamina;
                    foodbuff.m_CanStack = true;
                    foodbuff.m_Buff = 10;
                }
                if (name.Contains("GEAR_CookedPierogi"))
                {
                    FoodMaxStatBuff foodbuff = __instance.gameObject.GetComponent<FoodMaxStatBuff>() ?? __instance.gameObject.AddComponent<FoodMaxStatBuff>();
                    if (foodbuff == null) return;

                    foodbuff.m_TimeActiveHours = 3;
                    foodbuff.m_Stat = FoodMaxStatBuff.StatType.Condition;
                    foodbuff.m_CanStack = false;
                    foodbuff.m_Buff = 10;

                }
                if (name.Contains("GEAR_CookedPoutine"))
                {
                    IngestedCarryCapacityBuff carrybuff = __instance.gameObject.GetComponent<IngestedCarryCapacityBuff>() ?? __instance.gameObject.AddComponent<IngestedCarryCapacityBuff>();
                    if (carrybuff == null) return;

                    FoodMaxStatBuff foodbuff = __instance.gameObject.GetComponent<FoodMaxStatBuff>() ?? __instance.gameObject.AddComponent<FoodMaxStatBuff>();
                    if (foodbuff == null) return;

                    carrybuff.m_CarryCapacityChange = ItemWeight.FromKilograms(3);
                    carrybuff.m_CarryCapacityBuffDurationInHours = 3;

                    foodbuff.m_TimeActiveHours = 1;
                    foodbuff.m_Stat = FoodMaxStatBuff.StatType.Stamina;
                    foodbuff.m_CanStack = true;
                    foodbuff.m_Buff = -15;
                }
                if (name.Contains("GEAR_CookedSkilletPizza"))
                {
                    IngestedCarryCapacityBuff carrybuff = __instance.gameObject.GetComponent<IngestedCarryCapacityBuff>() ?? __instance.gameObject.AddComponent<IngestedCarryCapacityBuff>();
                    if (carrybuff == null) return;

                    FoodMaxStatBuff foodbuff = __instance.gameObject.GetComponent<FoodMaxStatBuff>() ?? __instance.gameObject.AddComponent<FoodMaxStatBuff>();
                    if (foodbuff == null) return;

                    carrybuff.m_CarryCapacityChange = ItemWeight.FromKilograms(3);
                    carrybuff.m_CarryCapacityBuffDurationInHours = 3;

                    foodbuff.m_TimeActiveHours = 1;
                    foodbuff.m_Stat = FoodMaxStatBuff.StatType.Stamina;
                    foodbuff.m_CanStack = true;
                    foodbuff.m_Buff = -15;
                }
            }
        }
        // ----------------------------------------Buffs/Debuffs END----------------------------------------//
    }
}
