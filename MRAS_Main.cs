using Planetbase;
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Tahvohck_Mods
{
    public class MRAS_Main
    {
        [LoaderOptimization(LoaderOptimization.NotSpecified)]
        public static void Init()
        {
            try {
                TahvohckUtil.FirstUpdate += RunOnce;
            } catch (Exception e) {
                Debug.Log(e.Message);
            }
        }

        public static void RunOnce()
        {
            var typesToChange = new[] {
                typeof(PlanetClassD),
                typeof(PlanetClassF),
                typeof(PlanetClassM),
                typeof(PlanetClassS),
            };
            foreach (Type t in typesToChange) {
                Planet currPlanet = PlanetList.find(t.Name);
                currPlanet.AddStartingResource(PlanetHelper.Metal, 15);
                currPlanet.AddStartingResource(PlanetHelper.Bioplastic, 15);
                currPlanet.AddStartingResource(PlanetHelper.MedicalSupplies, 15);
                currPlanet.AddStartingSpecialization(PlanetHelper.Carrier, 4);
                currPlanet.AddStartingSpecialization(PlanetHelper.Constructor, 1);
            }
        }
    }
}
