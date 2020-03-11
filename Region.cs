using System;
using System.Collections.Generic;

namespace koronaOke {

    class Region {

        public string regionName {get; set;}
        public int population {get;}
        public bool isInfected {get; set;}
        public int timeSinceFirstInfected {get; set;}

        public List<Region> ConnectedTo = new List<Region>(); // Berhasil memek

        public Region()
        {
            population = 0;
            regionName = "noName";
            isInfected = false;
            timeSinceFirstInfected = 0;
        }

        public Region(string region ,int setPopulation , bool defaultInfected = false) {

            population = setPopulation;
            regionName = region;
            isInfected = defaultInfected;
            timeSinceFirstInfected = 0;

        }

        public static double Infected(Region origin, int timeNow) {
            int pA = origin.population;
            int timeHasBeenInfected = timeNow - origin.timeSinceFirstInfected;
            double res = (pA) / (1 + (pA - 1) * (Math.Exp((-1) * (0.25) * timeHasBeenInfected)));
            // double res = timeHasBeenInfected * pA / 20;
            return res;
        }



    }


}