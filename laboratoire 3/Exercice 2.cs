using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_3_exercice_2
{
    class Program
    {
        static string GenererMot()
        {
            string[] tabmot = { "prog", "bonjour", "pixelmon", "pushup", "goto", "anticonstitutionnellement", "intergouvernementalisations", "enfant", "bienvenu" };
            return tabmot[generateurNb.Next(tabmot.Length)];
        }
        static Random generateurNb = new Random();
        static void AfficherMots(char[] tablette)
        {
            for (int i = 0; i < tablette.Length; i++)
            {
                Console.Write(tablette[i]+" ");
            }
            Console.ReadKey();
        }
        static void finDePartie(int cpt, int pendu, ref bool findePartie, string mot,char[] tablette)
        {
            if (cpt == mot.Length)
            {
                Console.WriteLine("vous avez gagner");
                findePartie = true;
                AfficherMots(tablette);
            }
            else if (pendu == 5)
            {
                findePartie = true;
                Console.WriteLine("vous avez perdu");
                Console.WriteLine("le mot etait : " + mot);
            }
        }
        static void verifierLettre(string mot, char lettre,ref char[] tablette, ref int cpt )
        {
            for (int i = 0; i < mot.Length; i++)
            {
                if (lettre == mot[i])
                {
                    tablette[i] = lettre;
                    cpt++;
                }
            }
        }
        static void ChangerLettre(ref char[] tablette)
        {
            for (int i = 0; i < tablette.Length; i++)
            {
                tablette[i] = '_';
            }
        }
        static void Main(string[] args)
        {

            string mot = GenererMot();
            char lettre = ' ';
            int pendu = 0;
            int cptavant = 0;
            int cpt = 0;
            bool findePartie = false;
            char[] tablette = new char[mot.Length];
            ChangerLettre(ref tablette);
            while (findePartie == false)
            {
                AfficherMots(tablette);

                Console.WriteLine("Entrer votre Lettre");
                lettre = Convert.ToChar(Console.ReadLine());
                cptavant = cpt;
                verifierLettre(mot, lettre, ref tablette, ref cpt);
                if (cpt == cptavant)
                {
                    pendu++;
                    Console.WriteLine("le pendu est a " + pendu + "/5");

                }
                finDePartie(cpt, pendu, ref findePartie, mot,tablette);


            }
            Console.ReadKey();
        }
    }
}
