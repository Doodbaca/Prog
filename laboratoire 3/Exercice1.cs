using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercie_1
{
    class Exercise1
    {
        static void AfficherNbMot(string phrase)
        {
            string[] tabmot = phrase.Split(' ');
            Console.WriteLine("il y a "+tabmot.Length+"mots");
        }
        static void AfficherMenu()
        {
            Console.WriteLine("1 - Afficher le nombre de mots dans la phrase");
            Console.WriteLine("2 - Afficher combien de fois chaque lettre apparaît ");
            Console.WriteLine("3 - Afficher la lettre qui apparaît le plus souvent");
            Console.WriteLine("4 - Encoder la phrase en utilisant une clé et un verrou");
            Console.WriteLine("5 - Quitter sans mon avis, non");
        }
        static void Affichernblettre(string phrase)
        {
            int[] tabNombre = new int[26];

            for (int i = 0; i < phrase.Length; i++)
            {
                int valeurIndiceLettre = 0;
                valeurIndiceLettre = (int)(phrase[i] - 97);

                if (valeurIndiceLettre >= 0 && valeurIndiceLettre < 26)
                    tabNombre[valeurIndiceLettre]++;
            }
            for (int i = 0; i < tabNombre.Length; i++)
            {
                
                char  valeurIndiceLettre;
                valeurIndiceLettre = (char)(i + 97);
                if (tabNombre[i] > 0)
                {
                    Console.WriteLine("Il y a " + tabNombre[i] + "  " + valeurIndiceLettre);
                }
            }
        }
        static void AfficherLePlus(string phrase)
        {
            int[] tabNombre = new int[26];
            int plusgrand = 0;
            char plusgrandLettre =' ';

            for (int i = 0; i < phrase.Length; i++)
            {
                int valeurIndiceLettre = 0;
                valeurIndiceLettre = (int)(phrase[i] - 97);

                if (valeurIndiceLettre >= 0 && valeurIndiceLettre < 26)
                    tabNombre[valeurIndiceLettre]++;
            }
            for (int i = 0; i < tabNombre.Length; i++)
            {
                
                char valeurIndiceLettre;
                valeurIndiceLettre = (char)(i + 97);
                if (tabNombre[i] > plusgrand)
                {
                    plusgrand = tabNombre[i];
                    plusgrandLettre = valeurIndiceLettre;
                }
            }
            Console.WriteLine("La lettre la plus grande est " + plusgrandLettre + " au nombre de " + plusgrand + " fois ");
        }
        static void EncoderPhrase(string phrase)
        {
            string phraseKrypter = phrase;
            string nouveauMessage = "";
            for (int i = 0; i < phraseKrypter.Length; i++)
            {
                int valeurAscii = (int)phraseKrypter[i];
                nouveauMessage += Char.ConvertFromUtf32(valeurAscii +2 );
            }
            Console.WriteLine(nouveauMessage);
        }
        static void Main(string[] args)
        {
            Boolean quitter = false;
            Console.WriteLine("Ecrivez votre Phrase");
            string phrase =Convert.ToString(Console.ReadLine());
            int choix = 0;
            while (quitter == false)
            {
                AfficherMenu();
                choix = Convert.ToInt32(Console.ReadLine());
                switch (choix)
                {
                    case 1: AfficherNbMot(phrase);break;
                    case 2: Affichernblettre(phrase); break;
                    case 3: AfficherLePlus(phrase); break;
                    case 4: EncoderPhrase(phrase); break;
                    case 5: quitter = true; break;
                }
                Console.ReadKey();
            }
        }
    }
}
