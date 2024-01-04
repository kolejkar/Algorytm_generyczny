using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 Macierz:

      0  42  46 106  76  30  47
     42   0  36  65 104  68 101
     46  36   0  58  65  81  44
    106  65  58   0 116 137 113
     76 104  65 116   0 104  35
     30  68  81 137 104   0  79
     47 101  44 113  35  79   0
     
     */

namespace Generyczny
{
    public class Trasa
    {
        private static int[,] road = new int[7,7] {
            { 0, 42, 46, 106, 76, 30, 47 },
            { 42, 0, 36, 65, 104, 68, 101 },
            { 46, 36, 0, 58, 65, 81, 44 },
            { 106, 65, 58, 0, 116, 137, 113 },
            { 76, 104, 65, 116, 0, 104, 35, },
            { 30, 68, 81, 137, 104, 0, 79 },
            { 47, 101, 44, 113, 35, 79, 0 }
        };

        public static int GetRoad(int a, int b)
        {
            return road[a - 1, b - 1];
        }

        public static int GetAllRoad(int[] cites)
        {
            int sum = 0;
            for (int i =1; i < cites.Length; i++)
            {
                sum = sum + GetRoad(cites[i - 1], cites[i]);
            }
            return sum;
        }

        public static string GetAllCites(int[] cites)
        {
            string tekst = "Kolejność miast na trasie:" + Environment.NewLine;
            for (int i=0; i< cites.Length;i++)
            {
                switch(cites[i])
                {
                    case 1: tekst = tekst +"-> Bydgoszcz "; break;
                    case 2: tekst = tekst + "-> Inowrocław"; break;
                    case 3: tekst = tekst + "-> Toruń"; break;
                    case 4: tekst = tekst + "-> Włocławek"; break;
                    case 5: tekst = tekst + "-> Grudziądz"; break;
                    case 6: tekst = tekst + "-> Nakło nad Notecią"; break;
                    case 7: tekst = tekst + "-> Chełmno"; break;
                }
            }
            return tekst + Environment.NewLine + "Odległość: "+GetAllRoad(cites)+" km";
        }
    }
}
