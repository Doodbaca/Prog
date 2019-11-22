using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_3_exercice3
{

    class Program
    {
        static Random generateurNb = new Random();
        static void AfficherMorpion(char[] tabCase)
        {
            Console.WriteLine(tabCase[0] +" "+ tabCase[1] + " " + tabCase[2]);
            Console.WriteLine(tabCase[3] + " " + tabCase[4] + " " + tabCase[5]);
            Console.WriteLine(tabCase[6] + " " + tabCase[7] + " " + tabCase[8]);
        }
        static void Changementcase(char[] tabCase)
        {
            bool bonchoix = false;
            int choix = 0;
            while (bonchoix == false)
            {
                Console.WriteLine("Entrez le chiffre de la case vous voulez changez");
                choix = Convert.ToInt32(Console.ReadLine());
                if (tabCase[choix] == choix+48)
                {
                    tabCase[choix] = 'X';
                    bonchoix = true;
                }
                else
                {
                    Console.WriteLine("Choix incorect Recommencer");
                }
            }
        }
        static void ChangementcaseOrdi(char[] tabCase)
        {
            bool bonchoix = false;
            int choix = 0;
            while (bonchoix == false)
            {
                choix = generateurNb.Next(0, 9);
                if (tabCase[choix] == choix + 48)
                {
                    tabCase[choix] ='O';
                    bonchoix = true;
                }
                
            }
        }
        static void VerificationTICTACTO(char[] tabcase,ref bool findepartie,string nom,int cpt)
        {

            if (tabcase[0] == tabcase[1] && tabcase[0] == tabcase[2])
            {
                findepartie = true;
                Console.WriteLine(nom + "a gagner");
            }
            else if (tabcase[0] == tabcase[3] && tabcase[0] == tabcase[6])
            {
                findepartie = true;
                Console.WriteLine(nom + "a gagner");
            }
            else if (tabcase[0] == tabcase[4] && tabcase[0] == tabcase[8])
            {
                findepartie = true;
                Console.WriteLine(nom + "a gagner");
            }
            else if (tabcase[3] == tabcase[4] && tabcase[3] == tabcase[5])
            {
                findepartie = true;
                Console.WriteLine(nom + "a gagner");
            }
            else if (tabcase[6] == tabcase[7] && tabcase[6] == tabcase[8])
            {
                findepartie = true;
                Console.WriteLine(nom + "a gagner");
            }
            else if (tabcase[2] == tabcase[4] && tabcase[6] == tabcase[2])
            {
                findepartie = true;
                Console.WriteLine(nom + "a gagner");
            }
            else if (tabcase[2] == tabcase[5] && tabcase[8] == tabcase[2])
            {
                findepartie = true;
                Console.WriteLine(nom + "a gagner");
            }
            else if (tabcase[1] == tabcase[4] && tabcase[1] == tabcase[7])
            {
                findepartie = true;
                Console.WriteLine(nom + "a gagner");
            }
            else if (cpt == 9)
            {
                Console.WriteLine("Egalité");
                findepartie = true;
            }
        }
        static void Rejouer(ref bool rejouer)
        {
            Console.WriteLine("1-rejouer");
            Console.WriteLine("2-quitter");
            int choix = Convert.ToInt32(Console.ReadLine());
            if (choix == 1)
            {
                Console.WriteLine("Allons rejouer alors");
                Console.ReadKey();
            }
            else if (choix == 2)
            {
                rejouer = true;
                Console.WriteLine("Aurevoir");
                Console.ReadKey();
            }
        }
        static void Main(string[] args)
        {
            char[] tabCase = new char[9];
            bool findepartie = false;
            bool rejouer = false;
            int cpt = 0;
            Console.WriteLine("Bonjour, je suis une intelligence artificielle qui tente de gagner");
            Console.ReadKey();
            while (rejouer == false)
            {
                cpt = 0;
                findepartie = false;
                for (int i = 0; i < tabCase.Length; i++)
                {
                    tabCase[i] = (char)(i + 48);
                }
                while (findepartie == false)
                {
                    cpt++;
                    AfficherMorpion(tabCase);
                    Changementcase(tabCase);
                    
                    VerificationTICTACTO(tabCase, ref findepartie, "joueur1",cpt);
                    if (findepartie == false)
                    {
                        cpt++;
                        ChangementcaseOrdi(tabCase);
                        VerificationTICTACTO(tabCase, ref findepartie, "Ordi",cpt);
                    }
                    
                }
                Rejouer(ref rejouer);
            }
        }
    }
}
