using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using MelonLoader;
using Il2Cpp;

namespace TKG
{
    internal class PotTexture : MelonMod
    {
        // pot texture
        public static bool loadedCookingTex;
        private static List<string> cookableGear = new List<string>();
        public static Material vanillaLiquidMaterial;

        public static Material InstantiateLiquidMaterial()
        {
            if (!vanillaLiquidMaterial)
            {
                vanillaLiquidMaterial = new Material(GearItem.LoadGearItemPrefab("GEAR_CoffeeCup").gameObject.GetComponent<Cookable>().m_CookingPotMaterialsList[0]);

                vanillaLiquidMaterial.name = "Liquid";
            }

            return new Material(vanillaLiquidMaterial);
        }

        public override void OnSceneWasInitialized(int level, string name)
        {
            if (!loadedCookingTex) // adding pot cooking textures
            {
                cookableGear.Add("RiceRaw"); // case-sensitive
                cookableGear.Add("CannedSpaghetti");
                cookableGear.Add("CannedStew");

                Material potMat;
                GameObject potGear;

                for (int i = 0; i < cookableGear.Count; i++)
                {
                    potGear = GearItem.LoadGearItemPrefab("GEAR_" + cookableGear[i]).gameObject;

                    if (potGear == null) continue;

                    Texture tex = potGear.transform.GetChild(0).GetComponent<MeshRenderer>().material.mainTexture;

                    potMat = InstantiateLiquidMaterial();
                    potMat.name = ("CKN_" + cookableGear[i] + "_MAT");

                    potMat.mainTexture = tex;
                    potMat.SetTexture("_Main_texture2", tex);

                    potGear.GetComponent<Cookable>().m_CookingPotMaterialsList = new Material[1] { potMat };
                    MelonLogger.Msg("for cookableGear.Count " + cookableGear.Count);
                    MelonLogger.Msg("potGear value====================1: " + potGear.name);
                    MelonLogger.Msg("potMat  value====================2: " + potMat.name);
                    MelonLogger.Msg("OnSceneWasInitialized " + level + " " + name);
                    MelonLogger.Msg("InstantiateLiquidMaterial");
                }

                loadedCookingTex = true;
            }
        }
    }

}