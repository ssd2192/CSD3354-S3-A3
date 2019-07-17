using System;
using System.Collections.Generic;
using System.IO;

namespace _739379_10_7_2019
{
    class JournalEntry
    {
        public JournalEntry(string note, int dist)
        {
            villageName = note; distanceTraveled = dist;
            HowFarToGetBack = distanceTraveled;
        }
        public int HowFarToGetBack = 0;
        private string villageName;
        private int distanceTraveled;
        public int getDistanceWalked() { return distanceTraveled; }
        public string getVillageName() { return villageName; }
    }

    class Hugi
    {
        private static JournalEntry je;
        public static bool FoundAstrilde = false;

        public static List<JournalEntry> HugiJournal = new List<JournalEntry>();

        public static int CalculateDistanceWalked()
        {
            int DistanceWalked = 0;
            // walk over the List and add the distances
            foreach (var je in HugiJournal)
            {
                Console.WriteLine(" {0}  --   {1} *** --- {2} ", je.getDistanceWalked(), je.getVillageName(), je.HowFarToGetBack);
                DistanceWalked += je.getDistanceWalked() + je.HowFarToGetBack;
            }
            return DistanceWalked;
        }
    }

    class CountrySide
    {
        static void Main()
        {
            CountrySide a = new CountrySide();
            a.Run();
            Console.ReadKey();
        }

        // Create the LinkedList to reflect the Map in the PowerPoint Instructions
        Village Maeland;
        Village Helmholtz;
        Village Alst;
        Village Wessig;
        Village Badden;
        Village Uster;
        Village Schvenig;

        public void TraverseVillages(Village CurrentVillage)
        {
            if (Hugi.FoundAstrilde) return;
            Hugi.HugiJournal.Add(new JournalEntry(CurrentVillage.VillageName, CurrentVillage.distanceFromPreviousVillage));
            try
            {
                Console.WriteLine("I am in {0}", CurrentVillage.VillageName);

                if (CurrentVillage.isAstrildgeHere)
                {
                    Console.WriteLine("I found Dear Astrildge in {0}", CurrentVillage.VillageName);
                    Console.WriteLine("**** FEELING HAPPY!!! ******");
                    Console.WriteLine("Astrilde, I walked {0} vika to find you. Will you marry me?", Hugi.CalculateDistanceWalked());
                    Hugi.FoundAstrilde = true;
                }

                TraverseVillages(CurrentVillage.west);
                TraverseVillages(CurrentVillage.east);

            }
            catch (NullReferenceException) { }

            

        }

        public void Run()
        {
            Alst = new Village("Alst", false);
            Schvenig = new Village("Schvenig", false);
            Wessig = new Village("Wessig", false);
            // TO DO: Complete this section
            Maeland = new Village("Maeland", false);
            Helmholtz = new Village("Helmholtz", false);
            Uster = new Village("Uster", false);
            Badden = new Village("badden", false);

            Alst.VillageSetup(0, Schvenig, Wessig);
            Schvenig.VillageSetup(14, Maeland, Helmholtz);
            // TO DO: Complete this section
            Maeland.VillageSetup(9, null, Helmholtz);
            Helmholtz.VillageSetup(28, null, null);
            Wessig.VillageSetup(19, Uster, Badden);
            Uster.VillageSetup(28, null, null);
            Badden.VillageSetup(11, null, null);

            this.TraverseVillages(Alst);
            this.Announcement();
            Console.ReadLine();





        }

        public void Announcement()
        {
            try
            {
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                using (StreamReader sr = new StreamReader("c:/area51/annoucement.txt"))
                {
                    string line;

                    // Read and display lines from the file until 
                    // the end of the file is reached. 
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
    }

    class Village
    {
        // http://www.vikinganswerlady.com/measurement.shtml

        public Village(string _villageName, bool _isAHere)
        {
            isAstrildgeHere = _isAHere;
            VillageName = _villageName;
        }
        public void VillageSetup(int _prevVillageDist, Village _westVillage, Village _eastVillage)
        {
            east = _eastVillage;
            west = _westVillage;
            distanceFromPreviousVillage = _prevVillageDist;
        }

        public Village west;
        public Village east;
        public string VillageName;
        public int distanceFromPreviousVillage;
        public bool isAstrildgeHere;
    }
}
