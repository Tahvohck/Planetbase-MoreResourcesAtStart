using HarmonyLib;
using Planetbase;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Tahvohck_Mods
{
    public class MRAS_Main : IMod
    {
        public void Init()
        {
            FileLog.logPath = "./harmony.log";
#if TRACE
            Harmony.DEBUG = true;
#endif
            ZZZ_Modhooker.PreResetEvent += Setup;
            TahvUtil.Log("Mod initialized.");
        }

        public void Update()
        {
            //throw new NotImplementedException();
        }

        public static void Setup(object caller, EventArgs args)
        {
            try {
                Harmony harmony = new Harmony(typeof(MRAS_Main).FullName);
                harmony.PatchAll();
                TahvUtil.Log("Setup complete.");
            } catch (HarmonyException hError) {
                string error =
                    $"Harmony patch failure, try enabling debug." +
                    $"\n  {hError.Message}";
                TahvUtil.Log(error);
            } catch (Exception exGeneric) {
                TahvUtil.Log(
                    $"Generic issue happened. Catching it instead of propagating. Contact Tahvohck." +
                    $"\n  {exGeneric.Message}"
                );
            }
        }
    }


    public class PatchPlanetResources
    {
        public static void Postfix<T>(T __instance) where T : Planet
        {
            __instance.addStartingResource<Metal>(15);
            __instance.addStartingResource<Bioplastic>(15);
            __instance.addStartingResource<MedicalSupplies>(10);
            __instance.addStartingSpecialization<Carrier>(4);
            __instance.addStartingSpecialization<Constructor>(1);
        }
    }


    [HarmonyPatch(typeof(PlanetClassD), MethodType.Constructor)]
    public class PatchPlanet1
    {
        public static void Postfix(PlanetClassD __instance) => PatchPlanetResources.Postfix(__instance);
    }


    [HarmonyPatch(typeof(PlanetClassF), MethodType.Constructor)]
    public class PatchPlanet2
    {
        public static void Postfix(PlanetClassF __instance) => PatchPlanetResources.Postfix(__instance);
    }


    [HarmonyPatch(typeof(PlanetClassM), MethodType.Constructor)]
    public class PatchPlanet3
    {
        public static void Postfix(PlanetClassM __instance) => PatchPlanetResources.Postfix(__instance);
    }


    [HarmonyPatch(typeof(PlanetClassS), MethodType.Constructor)]
    public class PatchPlanet4
    {
        public static void Postfix(PlanetClassS __instance) => PatchPlanetResources.Postfix(__instance);
    }
}
