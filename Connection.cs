using System;

namespace koronaOke {

    class Connection {

        public Region origin;
        public Region target;
        public double transferRate;
        public boolean hasBeenExecuted;

        public Connection(Region A, Region B, double rate) {
            origin = A;
            target = B;
            transferRate = rate;
            hasBeenExecuted = false;
        }

        static double S (Connection c, int timeNow) { // To determine if a region can be infected by other region
            int tOrigin = timeNow - c.origin.timeSinceFirstInfected;
            return Region.Infected(c.origin,tA) * c.transferRate;

        }

        static int S (Connection c) {
            int t = (int) 20 / (c.origin.population * c.transferRate);
            t += (1 + c.origin.timeSinceFirstInfected);
            return t; 
        }


    }

}