using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen2MathieuBienvenu
{
    class Program
    {
        public struct Vaisseau
        {
            public int Attaque;
            public int Valeurrareter;
            public string rareter;
            public int vie;
            public int prix;
            
            public Vaisseau(int _vie):this()
            {
                
            }
        }
        static Random generateurNb = new Random();

        static void AfficherVaisseau (Vaisseau[] tabvente)
        {
            for (int i=0; i < 20; i++)
            {
                Console.WriteLine(i + ".Vaisseau");
                Console.WriteLine("Rareter :" + tabvente[i].rareter);
                Console.WriteLine("Vie: " + tabvente[i].vie + "    Attaque : " + tabvente[i].Attaque+"     prix : "+tabvente[i].prix);
            }
        }
        static void AfficherPlusdeATK(Vaisseau[] tabventes)
        {
            int ATKplus = 0;
            int vaisseau = 0;
            for (int i = 0; i < 20; i++)
            {
                if (ATKplus < tabventes[i].Attaque)
                {
                    ATKplus = tabventes[i].Attaque;
                    vaisseau = i;
                }

            }
            Console.WriteLine(vaisseau + ".vaisseau a " + ATKplus + "de degats");
        }
        static void checkLEG(Vaisseau[] tabventes)
        {
            bool check = false;
            
            int cpt = 0;
            while (check == false && cpt < 20)
            {
                if (tabventes[cpt].Valeurrareter == 4)
                {
                    Console.WriteLine("Il y a un legendaire a la place "+cpt);
                    check = true;
                }
                cpt++;
            }
            if (check == false)
            {
                Console.WriteLine("Aucun vaisseau legendaire");
            }
        }
        static void CalculerMoy(Vaisseau[] tabventes)
        {
            int moyPrix = 0;
            for (int i = 0; i < 20; i++)
            {
                moyPrix += tabventes[i].prix;
            }
            moyPrix = moyPrix / 20;
            Console.WriteLine("La moyenne de prix est de "+moyPrix);
        }
        static void AfficherMenu()
        {
            Console.WriteLine("1.Afficher la liste des Vaisseau");
            Console.WriteLine("2.Trouver si il y a un vaiseau legendaire");
            Console.WriteLine("3-Trouver le vaisseau ave le plus Attaque");
            Console.WriteLine("4.Afficher la moyenne des prix");
            Console.WriteLine("5.Quitter le programme");
        }
        static void Main(string[] args)
        {
            bool quitter = false;
            Vaisseau[] tabvente = new Vaisseau[20];
            int choix = 0;
            for (int i = 0; i < 20; i++)
            {
                tabvente[i].Valeurrareter = generateurNb.Next(1, 20);

              if (tabvente[i].Valeurrareter < 7)
                {
                    tabvente[i].Attaque = generateurNb.Next(20, 41);
                        tabvente[i].vie = generateurNb.Next(100, 150);
                        tabvente[i].prix = 2000;
                        tabvente[i].rareter ="Commun" ;

                }
              else if (tabvente[i].Valeurrareter >=7 && tabvente[i].Valeurrareter < 12)
                {
                    tabvente[i].Attaque = generateurNb.Next(23, 50);
                                            tabvente[i].vie = generateurNb.Next(140, 250);
                                            tabvente[i].prix = 4500;
                                            tabvente[i].rareter = "Rare";
                }

          
              else if (tabvente[i].Valeurrareter >= 12 && tabvente[i].Valeurrareter < 17)
            {
                    tabvente[i].Attaque = generateurNb.Next(65, 75);
                    tabvente[i].vie = generateurNb.Next(200, 600);
                    tabvente[i].prix = 8000;
                    tabvente[i].rareter = "Epique";
                }
            
              else if (tabvente[i].Valeurrareter >= 17 && tabvente[i].Valeurrareter <= 19)
            {
                    tabvente[i].Attaque = generateurNb.Next(90, 110);
                    tabvente[i].vie = generateurNb.Next(550, 2000);
                    tabvente[i].prix = 20000;
                    tabvente[i].rareter = "Legendaire";
                }
                
            }
            while(quitter == false)
            {
                AfficherMenu();
                choix = Convert.ToInt32(Console.ReadLine());
                switch (choix)
                {
                    case 1: AfficherVaisseau(tabvente);break;
                    case 2: checkLEG(tabvente); break;
                    case 3: AfficherPlusdeATK(tabvente); break;
                    case 4: CalculerMoy(tabvente); break;
                    case 5: quitter=true; break;
                }
                Console.ReadKey();
            }

        }
    }
}
