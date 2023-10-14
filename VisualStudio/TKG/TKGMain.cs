using Il2Cpp;
using MelonLoader;
using TKG.Utilities;
using UnityEngine;

namespace TKG
{
    public class TKGMain : MelonMod
    {
        public static bool loadedCookingTex { get; set; }
        private static List<string> cookableGear { get; } = new List<string>();
        public static Material? vanillaLiquidMaterial { get; set; }

        public static Material? InstantiateLiquidMaterial()
        {
            if (vanillaLiquidMaterial == null)
            {
                // Ensure each component is NOT null before operating with it
                GearItem gi = GearItem.LoadGearItemPrefab("GEAR_CoffeeCup");
                if (gi == null) return null;

                GameObject go = gi.gameObject;
                if (go == null) return null;

                Cookable cookable = go.GetComponent<Cookable>();
                if (cookable == null) return null;

                vanillaLiquidMaterial = new Material(cookable.m_CookingPotMaterialsList[0]);
                vanillaLiquidMaterial.name = "Liquid";
            }

            return new Material(vanillaLiquidMaterial);
        }

        public override void OnSceneWasInitialized(int buildIndex, string sceneName)
        {
            if (!SceneUtilities.IsScenePlayable(sceneName)) return;

            if (!loadedCookingTex) // adding pot cooking textures
            {
                cookableGear.Add("CannedChiliOpened"); // case-sensitive
                cookableGear.Add("CannedChili");
                cookableGear.Add("CannedSpaghetti");
                cookableGear.Add("CannedSpaghettiOpened");
                cookableGear.Add("CannedStew");
                cookableGear.Add("CannedStewOpened");
                cookableGear.Add("RiceRaw");
                cookableGear.Add("SoyRamen");
                cookableGear.Add("SoyRamenCooked");
                cookableGear.Add("CupNoodles");
                cookableGear.Add("CupNoodlesOpen");

                Material? potMat;
                GameObject potGear;

                for (int i = 0; i < cookableGear.Count; i++)
                {
                    GearItem _ = GearItem.LoadGearItemPrefab("GEAR_" + cookableGear[i]);
                    if (_ == null) continue;

                    potGear = _.gameObject;
                    if (potGear == null) continue;

                    Texture tex = potGear.transform.GetChild(0).GetComponent<MeshRenderer>().material.mainTexture;
                    if (tex == null) continue;

                    potMat = InstantiateLiquidMaterial();

                    if (potMat != null)
                    {
                        potMat.name = ("CKN_" + cookableGear[i] + "_MAT");

                        potMat.mainTexture = tex;
                        potMat.SetTexture("_Main_texture2", tex);

                        potGear.GetComponent<Cookable>().m_CookingPotMaterialsList = new Material[1] { potMat };

                        loadedCookingTex = true;
                    }
                }
                base.OnSceneWasInitialized(buildIndex, sceneName);
            }
        }
    }
}
