using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice_2
{
    class Program
    {
        static Random generateurNb = new Random();
        static void generateur(ref int nb)
        {
         
            nb = (int)generateurNb.Next(1, 10000);
        }
        static void TrouverMax(ref int[] tabvaleur)
        {
            int plusGrand = 0;
            for (int i = 0; i < tabvaleur.Length; i++)
            {

                if (tabvaleur[i] > plusGrand)
                {
                    plusGrand = tabvaleur[i];
                }
            }
            Console.WriteLine("le plus grand nombre est: " + plusGrand);
            Console.ReadKey();
        }
        static void TrouverMin(ref int[] tabvaleur)
        {
            int plusPetit = 100000;
            for (int i = 0; i < tabvaleur.Length; i++)
            {

                if (tabvaleur[i] <= plusPetit)
                {
                    plusPetit = tabvaleur[i];

                }
            }
            Console.WriteLine("le plus petit nombre est: " + plusPetit);
            Console.ReadKey();

        }
        static void Trouverlenb(ref int[] tabvaleur)
        {
            int nbsaisie = 0;
            bool nbsaisieOK = false;
            int cpt = 0;
            nbsaisie = Convert.ToInt32(Console.ReadLine());
            while (nbsaisieOK == false && cpt < tabvaleur.Length)
            {
                if (nbsaisie == tabvaleur[cpt])
                {
                    nbsaisieOK = true;
                    Console.WriteLine("votre chiffre est dans le tableau");
                    Console.ReadKey();
                }
                else
                {
                    cpt++;
                }
            }
        }
        static void TrouverMoy(ref int[] tabvaleur)
        {
            int moyenne = 0;
            for (int i = 0; i < tabvaleur.Length; i++)
            {
                moyenne = tabvaleur[i] + moyenne;
            }
            moyenne = moyenne / tabvaleur.Length;
            Console.WriteLine("La moyenne est de "+moyenne);
            Console.ReadKey();
        }
        static void Main(string[] args)
        {
            int valeur = 0;
            int i = 0;
            int choix = 0;
            int[] tabvaleur = new int[300];
            bool fermeture = false;
            for ( i = 0;  i < tabvaleur.Length; i++ )
            {
                generateur(ref valeur);
                tabvaleur[i] = valeur;
            }
            while (fermeture == false)
            {
                Console.WriteLine("Bienvenu");
                Console.WriteLine("1.Trouvez le plus grand nombre");
                Console.WriteLine("2.Trouvez le plus petit nombre");
                Console.WriteLine("3.Verifier si le nombre saisi existe dans le tableau");
                Console.WriteLine("4.Faire la moyenne");
                Console.WriteLine("5.Quitter le programme");
                choix = Convert.ToInt32(Console.ReadLine());
                switch (choix)
                {
                    case 1:
                        TrouverMax(ref tabvaleur); break;
                    case 2:
                        TrouverMin(ref tabvaleur); break;
                    case 3:
                        Trouverlenb(ref tabvaleur); break;
                    case 4:
                        TrouverMoy(ref tabvaleur); break;
                    case 5:
                        fermeture = true;
                        Console.WriteLine("Aurevoir");break;
                }
            }
            Console.ReadKey();
        }
    }
}
