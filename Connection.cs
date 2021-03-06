using System;

namespace koronaOke {

    class Connection {

        public Region origin;
        public Region target;
        public double transferRate;
        public bool hasBeenExecuted;

        public Connection(Region A, Region B, double rate) {
            origin = A;
            target = B;
            transferRate = rate;
            hasBeenExecuted = false;
        }

        public static double S (Connection c, int timeNow) { // To determine if a region can be infected by other region
            return Region.Infected(c.origin,timeNow) * c.transferRate;

        }

        public static int S (Connection c) {
            double tInDouble =  Math.Floor(20 / (c.origin.population * c.transferRate));
            int t = (int) tInDouble;
            t += (1 + c.origin.timeSinceFirstInfected);
            return t; 
        }


    }

}