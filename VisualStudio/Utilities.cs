using Il2CppTLD.Gear;
using UnityEngine.AddressableAssets;

namespace TKG
{
    internal static class Utilities
    {
        public static HeadacheData HeadacheData = Addressables.LoadAssetAsync<GameObject>("GEAR_CookedPieRoseHip").WaitForCompletion().gameObject.GetComponent<CausesHeadacheDebuff>().m_HeadacheSettings;
        public static GameObject Liquid = Addressables.LoadAssetAsync<GameObject>("GEAR_CoffeeCup").WaitForCompletion();

        public static Material ChilliLiquidMaterial()
        {
            Texture2D LiquidTexture = Main.TKGAssetBundle.LoadAsset<Texture2D>("T_Chilli_CKN");
            Material LiquidMaterial = new Material(Liquid.gameObject.GetComponent<Cookable>().m_CookingPotMaterialsList[0]);
            LiquidMaterial.SetTexture("_Main_texture2", LiquidTexture);
            return LiquidMaterial;
        }
        public static Material CoffeeLiquidMaterial()
        {
            Texture2D LiquidTexture = Main.TKGAssetBundle.LoadAsset<Texture2D>("T_Coffee_CKN");
            Material LiquidMaterial = new Material(Liquid.gameObject.GetComponent<Cookable>().m_CookingPotMaterialsList[0]);
            LiquidMaterial.SetTexture("_Main_texture2", LiquidTexture);
            return LiquidMaterial;
        }
        public static Material NoodlesLiquidMaterial()
        {
            Texture2D LiquidTexture = Main.TKGAssetBundle.LoadAsset<Texture2D>("T_Noodles_CKN");
            Material LiquidMaterial = new Material(Liquid.gameObject.GetComponent<Cookable>().m_CookingPotMaterialsList[0]);
            LiquidMaterial.SetTexture("_Main_texture2", LiquidTexture);
            return LiquidMaterial;
        }
        public static Material RamenLiquidMaterial()
        {
            Texture2D LiquidTexture = Main.TKGAssetBundle.LoadAsset<Texture2D>("T_Ramen_CKN");
            Material LiquidMaterial = new Material(Liquid.gameObject.GetComponent<Cookable>().m_CookingPotMaterialsList[0]);
            LiquidMaterial.SetTexture("_Main_texture2", LiquidTexture);
            return LiquidMaterial;
        }
        public static Material SpaghettiLiquidMaterial()
        {
            Texture2D LiquidTexture = Main.TKGAssetBundle.LoadAsset<Texture2D>("T_Spaghetti_CKN");
            Material LiquidMaterial = new Material(Liquid.gameObject.GetComponent<Cookable>().m_CookingPotMaterialsList[0]);
            LiquidMaterial.SetTexture("_Main_texture2", LiquidTexture);
            return LiquidMaterial;
        }
        public static Material StewLiquidMaterial()
        {
            Texture2D LiquidTexture = Main.TKGAssetBundle.LoadAsset<Texture2D>("T_Stew_CKN");
            Material LiquidMaterial = new Material(Liquid.gameObject.GetComponent<Cookable>().m_CookingPotMaterialsList[0]);
            LiquidMaterial.SetTexture("_Main_texture2", LiquidTexture);
            return LiquidMaterial;
        }

        public static AssetBundle LoadFromStream(string name)
        {
            using (Stream? stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(name))
            {
                MemoryStream memory = new((int)stream.Length);
                stream!.CopyTo(memory);
                Il2CppSystem.IO.MemoryStream memoryStream = new(memory.ToArray());
                return AssetBundle.LoadFromStream(memoryStream);
            }
        }
    }
}