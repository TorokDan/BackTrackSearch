using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisszalepesGyak
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Adatok
            string[][] r = new string[][]
            {
                new string[] {"Miklós", "Klaudia"},
                new string[] {"Miklós", "András"},
                new string[] {"András", "Zsolt"},
                new string[] {"Géza", "Zsolt", "Palika"},
                new string[] {"Géza", "András"},
                new string[] {"Miklós", "Géza"}
            };

            // Megoldást tartalmazó tömb
            string[] eredmeny = new string[r.Length];

            // Segédváltozók
            bool van = false;

            // itt hívjuk meg a keresést
            BTS(r, 0, eredmeny, ref van);

            // Kiiratás
            for (int i = 0; i < eredmeny.Length; i++)
                Console.WriteLine($"{i}. szint megoldása: {eredmeny[i]}");
        }

        static void BTS (string[][] r, int szint, string[] e, ref bool van)
        {
            int i = -1;
            while (!van && i < r[szint].Length - 1)
            {
                i++;
                if (Fk(szint, r[szint][i], e))
                {
                    e[szint] = r[szint][i];
                    if (szint == e.Length - 1)
                        van = true;
                    else
                        BTS(r, szint + 1, e, ref van);
                }
            }
        }
        static bool Fk(int szint, string nev, string[] e)
        {
            bool ok = true;
            for (int i = 0; i < szint; i++)
                if (e[i] == nev)
                    ok = false;
            return ok;
        }
    }
}
