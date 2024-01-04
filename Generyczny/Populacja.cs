using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generyczny
{
    public class Populacja
    {
        private Random random = new Random();

        private List<int[]> trasy = new List<int[]>();

        private int k1, k2;

        public int epoki;

        private int[] dane = { 1, 2, 3, 4, 5, 6, 7 };

        /*
         1 - Bydgoszcz
         2 - Inowrocław
         3 - Toruń
         4 - Włocławek
         5 - Grudziądz
         6 - Nakło nad Notecią
         7 - Chełmno
         */

        public string log = "";

        private void TrasyInfo()
        {
            log = log + "==============================" + Environment.NewLine;
            for (int i =0; i < trasy.Count; i++)
            {
                log = log + "Trasa " + (i + 1).ToString() + ":" + Environment.NewLine;
                log = log + Trasa.GetAllCites(trasy[i]) + Environment.NewLine;
            }
        }


        public Populacja()
        {
            //incjalizacja
            for (int i=0;i<8;i++)
            {
                int[] z = dane;
                for (int j=0;j<21;j++)
                {
                    int i1 = random.Next(0, 7);
                    int i2 = random.Next(0, 7);
                    int t = z[i1];
                    z[i1] = z[i2];
                    z[i2] = t;
                }
                trasy.Add(z.ToArray());
            }
            TrasyInfo();
        }

        public int[] Run()
        {
            int[] best = new int[7];
            int size = int.MaxValue;
            //algorytm
            for (int j = 0; j < epoki; j++)
            {
                log = log + Environment.NewLine + Environment.NewLine;
                log = log + "==============================" + Environment.NewLine;
                log = log + "Epoka: " + (j+1).ToString()  + Environment.NewLine;

                List<int[]> noweTrasy = new List<int[]>();
                for (int i = 0; i < 8; i++)
                {
                    Selection();
                    noweTrasy.Add(Multiplication());
                }
                trasy = new List<int[]>(noweTrasy);
                TrasyInfo();

                foreach (int[] trasa in trasy)
                {
                    if (Trasa.GetAllRoad(trasa) < size)
                    {
                        best = trasa;
                        size = Trasa.GetAllRoad(trasa);
                    }
                }
                log = log + Environment.NewLine + "Zwycięzca: " + Environment.NewLine;
                log = log + Trasa.GetAllCites(best) + Environment.NewLine;
            }

            //zwracanie najlepszego
            return best;
        }

        public void Selection()
        {
            k1 = Losuj();
            k2 = Losuj();
        }

        private int Losuj()
        {
            int[] kandydaci = new int[4] {
               random.Next(0, trasy.Count),
               random.Next(0, trasy.Count),
               random.Next(0, trasy.Count),
               random.Next(0, trasy.Count) };
            int best = 0;
            int size = int.MaxValue;
            for (int i =0; i < kandydaci.Length; i++)
            {
                if (Trasa.GetAllRoad(trasy[kandydaci[i]]) < size)
                {
                    best = kandydaci[i];
                    size = Trasa.GetAllRoad(trasy[kandydaci[i]]);
                }
            }

            return best;
        }

        private int[,] Swap(int[] c1, int[] c2)
        {
            int[,] mapping = new int[2, 3];
            for (int i = 0; i < 3; i++)
            {
                mapping[0, i] = c1[i + 4];
                mapping[1, i] = c2[i + 4];
            }
            int[] temp = c1.Clone() as  int[];
            temp[0] = 0;
            temp[1] = 0;
            temp[2] = 0;
            temp[3] = 0;
            c1[4] = c2[4];
            c1[5] = c2[5];
            c1[6] = c2[6];
            c2[4] = temp[4];
            c2[5] = temp[5];
            c2[6] = temp[6];
            return mapping;
        }

        public int[] Mapping(int[] kan, int[,] map)
        {
            map = Sort(map);
            map = map.Clone() as int[,];
            kan = kan.Clone() as int[];

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (map[0, j] == kan[i])
                    {
                        kan[i] = map[1, j];
                    }
                    else
                    if (map[1, j] == kan[i])
                    {
                        kan[i] = map[0, j];
                    }                    
                }
            }
            return kan;
        }

        public int[] Multiplication()
        {
            int[] kan1 = trasy[k1].Clone() as int[];
            int[] kan2 = trasy[k2].Clone() as int[];
            int[,] map = Swap(kan1, kan2);
            kan1 = Mapping(kan1, map);
            kan2 = Mapping(kan2, map);

            if (Trasa.GetAllRoad(kan1) > Trasa.GetAllRoad(kan2))
                return Mutacja(kan1);
            else
                return Mutacja(kan2);
        }

        private int[] Mutacja(int[] kan)
        {
            if (random.Next(0, 1000) < 10)
            {
                if (random.Next(0, 1) == 1)
                {
                    int gen = kan[3];
                    kan[3] = kan[5];
                    kan[5] = gen;
                }
                else
                {
                    int gen = kan[6];
                    kan[6] = kan[5];
                    kan[5] = gen;
                }
            }

            return kan;
        }


        public int[,] Sort(int[,] map)
        {
            int[,] mapping = { { 0, 0, 0 }, { 0, 0, 0 } };
            int[,] temp = map.Clone() as int[,];

            int maps = 0;
            int old_maps = 0;

            for (int i = 0; i < 3; i++)
            {
                if (temp[0, i] > 0)
                {
                    mapping[0, maps] = temp[0, i];
                    bool swapping = false;
                    for (int j = 0; j < 3; j++)
                    {
                        if (temp[1, i] == temp[0, j])
                        {
                            for (int k = 0; k < maps; k++)
                            {
                                if (mapping[0, k] == temp[1, i])
                                {
                                    mapping[0, maps] = 0;
                                    old_maps = maps;
                                    swapping = true;
                                    maps = k;
                                    mapping[0, maps] = temp[0, i];
                                    break;
                                }
                            }
                            if (!swapping)
                            {
                                temp[0, j] = 0;
                            }
                            mapping[1, maps] = temp[1, j];
                            break;
                        }
                    }
                    if (mapping[1, maps] == 0)
                    {
                        mapping[1, maps] = temp[1, i];
                    }
                    if (swapping)
                    {
                        maps = old_maps;
                    }
                    else
                    {
                        //temp[0, i] = 0;
                        maps++;
                    }
                }
            }
            return mapping;
        }
    }
}
