using System;
using System.Collections.Generic;

namespace koronaOke {

    class ProgramUtama {

        static void Main (string[] args) {
            
            int timeNow = 100;
            List<Region> Regions = new List<Region>();

            List<Connection> Connections = new List<Connection>();
            // Anggap udah ada array yang berisi calon Connection

            Queue<Connection> regConnection = new Queue<Connection>();

            

            do {
                
                Connection currentCon = regConnection.Dequeue();

                if (Connection.S(currentCon, timeNow) > 1) {

                    if (currentCon.target.isInfected) {

                        if (currentCon.target.timeSinceFirstInfected > Connection.S(currentCon)) {
                            currentCon.target.timeSinceFirstInfected = Connection.S(currentCon);
                        }

                    }
                    else {
                        currentCon.target.isInfected = true;
                        currentCon.target.timeSinceFirstInfected = Connection.S(currentCon);
                    }

                    currentCon.hasBeenExecuted = true;
                    
                    foreach(Connection iterCon in Connections) {
                        
                        int sameRegion = string.Compare(iterCon.origin.regionName,currentCon.origin.regionName);

                        if (!(iterCon.hasBeenExecuted) && (sameRegion == 0)) {
                            regConnection.Enqueue(iterCon);
                        }

                    }

                }

            } while (regConnection.Count > 0);
            


        }
        
    }

}