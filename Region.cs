using System;
using System.Collections.Generic;

class Region {

    private string regionName {get; set;}
    public int population {get;}
    public bool isInfected{get; set;}
    public int timeSinceFirstInfected{get; set;}
    
    public List<Region> connected;

    public Region(string region ,bool defaultInfected = false) {
        regionName = region;
        isInfected = defaultInfected;
        timeSinceFirstInfected = 0;
    }

    static public int Infected(Region origin, int timeHasBeenInfected) {
        int pA = origin.population;
        return (double) (pA) / (1 + (pA - 1) * (Math.Exp((-1) * (0.25) * timeHasBeenInfected)));
    } 

}