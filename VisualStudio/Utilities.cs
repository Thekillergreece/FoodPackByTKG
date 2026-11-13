using Il2CppTLD.Gear;
using UnityEngine.AddressableAssets;

namespace TKG
{
    internal static class Utilities
    {
        public static HeadacheData HeadacheData = Addressables.LoadAssetAsync<GameObject>("GEAR_CookedPieRoseHip").WaitForCompletion().gameObject.GetComponent<CausesHeadacheDebuff>().m_HeadacheSettings;
        public static GameObject Liquid = Addressables.LoadAssetAsync<GameObject>("GEAR_CoffeeCup").WaitForCompletion();

        public static Texture2D Texture(string textureName)
        {
            return Main.TKGAssetBundle.LoadAsset<Texture2D>(textureName);
        }

        public static Material LiquidMaterial(string textureName)
        {
            Material liquid = new Material(Liquid.gameObject.GetComponent<Cookable>().m_CookingPotMaterialsList[0]);
            liquid.SetTexture("_Main_texture2", Texture(textureName));
            return liquid;
        }

        public static Material ChilliLiquidMaterial() => LiquidMaterial("T_Chilli_CKN");
        public static Material CoffeeLiquidMaterial() => LiquidMaterial("T_Coffee_CKN");
        public static Material NoodlesLiquidMaterial() => LiquidMaterial("T_Noodles_CKN");
        public static Material RamenLiquidMaterial() => LiquidMaterial("T_Ramen_CKN");
        public static Material SpaghettiLiquidMaterial() => LiquidMaterial("T_Spaghetti_CKN");
        public static Material StewLiquidMaterial() => LiquidMaterial("T_Stew_CKN");

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