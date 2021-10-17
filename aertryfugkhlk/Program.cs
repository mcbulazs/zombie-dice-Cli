using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aertryfugkhlk
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] piros = new char[] { 'a', 'l', 'l', 's', 's', 's' };
            char[] sarga = new char[] { 'a', 'a', 'l', 'l', 's', 's' };
            char[] zold = new char[] { 'a', 'a', 'a', 'l', 'l', 's' };
            List<char[]> minden = new List<char[]>();
            for (int i = 0; i < 13; i++)
            {
                if (i < 3)
                {
                    minden.Add(piros);
                }
                else if (i < 7)
                {
                    minden.Add(sarga);
                }
                else
                {
                    minden.Add(zold);
                }
            }
            //console
            //elso dobas
            Console.WriteLine("a jatek elkezdesehez nyomj meg egy gombot");
            Console.ReadKey();
            Console.WriteLine("elso dobas");
            Random r = new Random();
            List<char> eddigi = new List<char>();
            bool akar = true;
            int z = 6;
            int s = 4;
            int p = 3;
            while (akar)
            {
                for (int i = 0; i < 3; i++)
                {
                    int x = r.Next(0, minden.Count());
                    int oldal = r.Next(0, 6);
                    if (minden[x][oldal] == 's')
                    {
                        Console.Write("shoutgun ");
                        if (minden[x] == zold)
                        {
                            z--;
                        }
                        else if (minden[x] == sarga)
                        {
                            s--;
                        }
                        else if (minden[x] == piros)
                        {
                            p--;
                        }
                        eddigi.Add(minden[x][oldal]);
                        minden.RemoveAt(x);
                    }
                    else if (minden[x][oldal] == 'a')
                    {
                        Console.Write("agy ");
                        if (minden[x] == zold)
                        {
                            z--;
                        }
                        else if (minden[x] == sarga)
                        {
                            s--;
                        }
                        else if (minden[x] == piros)
                        {
                            p--;
                        }
                        eddigi.Add(minden[x][oldal]);
                        minden.RemoveAt(x);
                    }
                    else
                    {
                        Console.Write("lab(ujradobsz)");
                    }                  
                }
                Console.WriteLine();
                eddigi.GroupBy(X => X).ToList().ForEach(x => Console.WriteLine(x.Key + " " + x.Count()));
                Console.WriteLine("Kiment szinek:\npiros:{0} sarga:{1} zold:{2} {3}", 3 - p, 4 - s, 6 - z, minden.Count());
                if (eddigi.Count(x => x == 's') >= 3)
                {
                    Console.WriteLine("vesztettel");
                    break;
                }
                Console.WriteLine("Akarsz tovább játszani? y/n");
                string yn = Console.ReadLine();
                if (yn == "n")
                {
                    Console.WriteLine("osszpontjaid szama: " + eddigi.Count(x => x == 'a'));
                    break;
                }
                if (minden.Count()==1)
                {
                    Console.WriteLine("elerted a maxium dobasi lehetoseget \npontjaid szama: {0}",eddigi.Count(x=>x == 'a') );
                    break;
                }
                Console.Clear();
            }
            Console.ReadKey();
        }
    }
}
