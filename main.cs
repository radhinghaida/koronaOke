using System;
using System.Collections.Generic;

namespace koronaOke {

    class ProgramUtama {

        static void Main (string[] args) {
            
            string firstRegionInfected;
            int timeNow = Console.ReadLine.ToInt32();
            List<Region> Regions = new List<Region>();

            List<Connection> Connections = new List<Connection>();
            // Anggap udah ada array yang berisi calon Connection

            Queue<Connection> regConnection = new Queue<Connection>();

            

            do {
                
                Connection currentCon = regConnection.Dequeue();

                if (S(currentCon, timeNow) > 1) {

                    if (currentCon.target.isInfected) {

                        if (currentCon.target.timeSinceFirstInfected > S(regConnection)) {
                            currentCon.target.timeSinceFirstInfected = S(regConnection);
                        }

                    }
                    else {
                        currentCon.target.isInfected = true;
                        currentCon.target.timeSinceFirstInfected = S(regConnection);
                    }

                    currentCon.hasBeenExecuted = true;
                    
                    foreach(Connection iterCon in Connections) {
                        
                        int sameRegion = string.Compare(iterCon.origin.regionName,currentCon.origin.regionName);

                        if (!(iterCon.hasBeenExecuted) && (sameRegion == 0)) {
                            regConnection.Enqueue(iterCon);
                        }

                    }

                }

            } while (regConnection.count > 0);
            


        }
        
    }

}