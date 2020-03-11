using System;
using System.IO;
using System.Collections.Generic;

namespace koronaOke
{
    class readFile
    {
        public static int getNumberofRegion()
        {
            string[] lines = File.ReadAllLines("tesRegion.txt");
            string[] lineDibaca = lines[0].Split(' ');
            string numberOfRegion = lineDibaca[0].Trim();
            int number = int.Parse(numberOfRegion);
            return number;
        }

        public static string getFirstInfected()
        {
            string[] lines = File.ReadAllLines("tesRegion.txt");
            string[] lineDibaca = lines[0].Split(' ');
            string first = lineDibaca[1].Trim();
            return first;
        }

        public static List<Region> getRegions()
        {
            string[] lines = File.ReadAllLines("tesRegion.txt");
            List<Region> Regions = new List<Region>();
            string firstInfected = getFirstInfected();
            for (int i = 1; i <= getNumberofRegion(); i++)
            {
                string[] lineDibaca = lines[i].Split(' ');
                string namaRegion = lineDibaca[0].Trim();
                int populasi = int.Parse(lineDibaca[1].Trim());
                bool isInfected = (string.Compare(namaRegion, firstInfected) == 0) ? true : false;
                Region Baru = new Region(namaRegion, populasi, isInfected);
                Regions.Add(Baru);
                // TIME SINCE FIRST INFECTED BUAT YANG PERTAMA INFECTED GIMANA YAH
                // TIME SINCE FIRST INFECTED buat yang pertama bikin 0 juga, tapi  isInfected nya jadi true
            }
            return Regions;
        }

        public static int getJumlahConnection()
        {
            string[] lines = File.ReadAllLines("tesConnection.txt");
            int jumlahConnection = int.Parse(lines[0]);
            return jumlahConnection;
        }

        public static List<Connection> getConnections(List<Region> Regions)
        {
            string[] lines = File.ReadAllLines("tesConnection.txt");
            List<Connection> Connections = new List<Connection>();
            for (int i = 1; i <= getJumlahConnection(); i++)
            {
                string[] lineDibaca = lines[i].Split(' ');
                string asal = lineDibaca[0].Trim();
                string tujuan = lineDibaca[1].Trim();
                double tr = double.Parse(lineDibaca[2].Trim());
                Region origin = new Region();
                Region target = new Region();
                for (int j = 0; j < Regions.Count; j++)
                {
                    if (Regions[j].regionName == asal)
                    {
                        origin = Regions[j];
                    }
                    if (Regions[j].regionName == tujuan)
                    {
                        target = Regions[j];
                    }
                }
                for (int k = 0; k < Regions.Count; k++)
                {
                    if (Regions[k].regionName == asal)
                    {
                        Regions[k].ConnectedTo.Add(target);
                    }
                }
                Connection Baru = new Connection(origin, target, tr);
                Connections.Add(Baru);

            }
            return Connections;
        }

    }
}
