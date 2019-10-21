using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atelier_boucle_2_exerrcie2
{
    class Program
    {
        static Random generateurNb = new Random();
        static void DifficulterFacile (out int nbatrouver)
        {
            nbatrouver = (int)generateurNb.Next(1, 100);
        }
        static void DifficulterMoyen(out int nbatrouver)
        {
            nbatrouver = (int)generateurNb.Next(1, 1000);
        }
        static void DifficulterDifficile(out int nbatrouver)
        {
            nbatrouver = (int)generateurNb.Next(1, 10000);
        }

        static void Main(string[] args)
        {
            int nbatrouver = 0;
            int nbsaisie = 0;
            bool win = false;
            int choix = 0;
            Console.WriteLine("Choissiser la difficulté");
            Console.WriteLine("1-facile");
            Console.WriteLine("2-Moyen");
            Console.WriteLine("3-Difficile");
            choix = Convert.ToInt32(Console.ReadLine());
            if (choix == 1)
            {
                DifficulterFacile(out nbatrouver);
            }
            else if (choix == 2)
            {
                DifficulterMoyen(out nbatrouver);
            }
            else if (choix == 3)
            {
                DifficulterDifficile(out nbatrouver);
            }
            Console.WriteLine(+nbatrouver);
            Console.WriteLine("trouver le bon nombre");
            Console.ReadKey();
            while (win == false)
            {
                nbsaisie = Convert.ToInt32(Console.ReadLine());
                if (nbatrouver < nbsaisie)
                {
                    Console.WriteLine("Plus petit");
                }
                else if (nbatrouver > nbsaisie)
                {
                    Console.WriteLine("Plus Grand");
                }
                else if (nbatrouver == nbsaisie)
                {
                    Console.WriteLine("Bravo vous avez trouver le bon nombre");
                    win = true;
                    Console.ReadKey();
                }
            }
        }
    }
}
