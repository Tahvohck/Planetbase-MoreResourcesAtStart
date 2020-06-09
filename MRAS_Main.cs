using Planetbase;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Tahvohck_Mods
{
    public class MRAS_Main : Planet
    {
        [LoaderOptimization(LoaderOptimization.NotSpecified)]
        public static void Init()
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
