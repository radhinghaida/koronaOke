using System;
using System.Collections.Generic;

namespace koronaOke {

    class ProgramUtama {

        static void Main (string[] args) {
            
            
            List<Region> Regions = readFile.getRegions();
            List<Connection> Connections = readFile.getConnections(Regions);

            Queue<Connection> queueConnection = new Queue<Connection>();

            Console.Write("T : ");
            int timeNow = Convert.ToInt32(Console.ReadLine());

            // Get First Infected Region and their neighbours to be pushed into queue
            foreach (Connection aCon in Connections) {
                
                if (aCon.origin.isInfected) { // Found first infected region
                    string regionFirstInfectedName = aCon.origin.regionName;
                    
                    foreach(Connection infCon in Connections) { // Pushing all the infected connection into queue
                        
                        if (string.Compare(regionFirstInfectedName,infCon.origin.regionName) == 0) {
                            queueConnection.Enqueue(infCon);
                        }

                    }
                    break;
                }

            }


            do {
                
                Console.WriteLine("Queue Status :");
                Console.Write("[");
                foreach (Connection qCon in queueConnection) {
                    Console.Write("{0} -> {1} ", qCon.origin.regionName, qCon.target.regionName);
                }
                Console.Write("]");
                Console.WriteLine("");

                Connection currentCon = queueConnection.Dequeue();
                // Test for Dequeue
                //Console.WriteLine("Dequeue Connection from {0} to {1} with status has been Exe : {3}", currentCon.origin, currentCon.target, currentCon.hasBeenExecuted);
                Console.WriteLine("Checking from {0} to {1}", currentCon.origin.regionName, currentCon.target.regionName);
                Console.WriteLine("Success Rate : {0}", Connection.S(currentCon,timeNow));
                Console.WriteLine("");
                

                // End of Test

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

                    
                    
                    foreach(Connection iterCon in Connections) {
                        
                        int sameRegion = string.Compare(iterCon.origin.regionName,currentCon.target.regionName);

                        if (!(iterCon.hasBeenExecuted) && (sameRegion == 0)) {
                            queueConnection.Enqueue(iterCon);
                        }

                    }

                }

                currentCon.hasBeenExecuted = true;

            } while (queueConnection.Count > 0);

            Console.WriteLine("");

            foreach(Region aRegion in Regions) {
                
                if (aRegion.isInfected) {
                    Console.WriteLine("Region : {0} has been infected since day {1}", aRegion.regionName, aRegion.timeSinceFirstInfected);
                }
                else {
                    Console.WriteLine("Region : {0} is safe,  T({0}) : {1}", aRegion.regionName, aRegion.timeSinceFirstInfected);
                }

            }
            


        }
        
    }

}