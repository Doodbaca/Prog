using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Le31
{

  
    class Program
    {
        static Random generateurNb = new Random();
        public struct Joueur
        {
            public string nom;
            public int nbVie;
            public Carte[] tabCarte;
            public int totalCarte;
            public Joueur(string _nom, int _nbVie) : this()
            {
                nom = _nom;
                nbVie = _nbVie;
                tabCarte = new Carte[3];

            }
        }
        public enum Sorte { Coeur = 1, Pique = 2, Carreau = 3, Trèfle = 4 };

        public struct Carte
        {
            public bool carteUtiliser;
            public Sorte sorteCarte;
            public int valeurCarte;
            public int valeurAfficher;
            public string NomCarte;

            public Carte(Sorte _sorteCarte, int _valeurCarte,bool carteUtiliser) : this()
            {
                sorteCarte = _sorteCarte;
                valeurAfficher = _valeurCarte;
                carteUtiliser = false;
            }
        }

        public struct Pioche
        {
            public Carte[] tabpioche;


            public Pioche(int nbcarte) : this()
            {
                int cpt = 1;
                tabpioche = new Carte[52];
                for (int i = 0; i <= 12; i++)
                {
                    tabpioche[i].valeurAfficher=cpt;
                    tabpioche[i].sorteCarte = (Sorte) 1;
                    ValeurCarte(tabpioche[i].valeurAfficher, ref tabpioche[i].valeurCarte);
                    cpt++;

                }
                cpt = 1;
                for (int i = 13; i <= 25; i++)
                {
                    tabpioche[i].valeurAfficher = cpt;
                    tabpioche[i].sorteCarte = (Sorte)2;
                    cpt++;
                    ValeurCarte(tabpioche[i].valeurAfficher, ref tabpioche[i].valeurCarte);

                }
                cpt = 1;
                for (int i = 26; i <= 38; i++)
                {
                    tabpioche[i].valeurAfficher = cpt;
                    tabpioche[i].sorteCarte = (Sorte)3;
                    ValeurCarte(tabpioche[i].valeurAfficher, ref tabpioche[i].valeurCarte);
                    cpt++;

                }
                cpt = 1;
                for (int i = 39; i <= 51 ; i++)
                {
                    tabpioche[i].valeurAfficher = cpt;
                    tabpioche[i].sorteCarte = (Sorte)4;
                    ValeurCarte(tabpioche[i].valeurAfficher, ref tabpioche[i].valeurCarte);
                    cpt++;

                }
            }
        }
        static void ChangerNomCarte(ref Pioche pioche)
        {
            for (int i =0; i<51; i++)
            {
                if (pioche.tabpioche[i].valeurAfficher == 1)
                {
                    pioche.tabpioche[i].NomCarte = "as";
                }
                else if (pioche.tabpioche[i].valeurAfficher ==11 )
                {
                    pioche.tabpioche[i].NomCarte = "Valet";
                }
                else if (pioche.tabpioche[i].valeurAfficher == 12)
                {
                    pioche.tabpioche[i].NomCarte = "Reine";
                }
                else if (pioche.tabpioche[i].valeurAfficher == 13)
                {
                    pioche.tabpioche[i].NomCarte = "Roi";
                }
                if (pioche.tabpioche[i].valeurAfficher > 1 && pioche.tabpioche[i].valeurAfficher < 11)
                {
                    pioche.tabpioche[i].NomCarte = pioche.tabpioche[i].valeurAfficher.ToString();
                }
            }
        }
        static void ValeurCarte (int valeurAfficher, ref int valeurCarte)
        {
            valeurCarte = 0;
            if (valeurAfficher == 1)
            {
                valeurCarte = 11;
            }
            else if (valeurAfficher > 1 && valeurAfficher < 11)
            {
                valeurCarte = valeurAfficher;
            }
            else if (valeurAfficher >= 11)
            {
                valeurCarte = 10;
            }
        }
        static void CalculCarte(Carte[] tabCarte, ref int total)
        {
            total = 0;
            for (int i = 0; i < tabCarte.Length; i++)
            {
                total += tabCarte[i].valeurCarte;
            }
        }
        static Carte PiochezCarte(ref Pioche pioche)
        {
            Carte cartepiocher = new Carte();
            bool carteValide = false;
            int alea = 0;
            while (carteValide == false)
            {
                alea = generateurNb.Next(0, 52);
                if (pioche.tabpioche[alea].carteUtiliser == false)
                {
                    cartepiocher = pioche.tabpioche[alea];
                    pioche.tabpioche[alea].carteUtiliser = true;
                    cartepiocher.carteUtiliser = true;
                    carteValide = true;
                }
            }
            return cartepiocher;
        }
        static void Afficher (string message)
        {
            Console.WriteLine(message);
        }
        static void ResetPioche(Pioche pioche)
        {
            for(int i=0; i<52; i++)
            {
                pioche.tabpioche[i].carteUtiliser = false;
            }
        }
        static void Main(string[] args)
        {
            Joueur monJoueur1 = new Joueur("Joe", 3);
            Joueur ordi = new Joueur("Ordi", 3);
            Pioche pioche = new Pioche(52);
            int nbJoueur = 0;
            ChangerNomCarte(ref pioche);
            bool win = false;
            Joueur[] tabJoueur;
            int total = 0;
            int choix = 0;
            int total2 = 0;
            bool findeManche = false;
            Carte carteCentre;
            Carte carteCopie;
            



            /*Console.WriteLine(" Combien de joueurs ");
            nbJoueur = Convert.ToInt32( Console.ReadLine() );
            tabJoueur = new Joueur[nbJoueur];*/
            Afficher("Bienvenu Dans le jeu du 31");

        
            while (win == false)
            {
                findeManche = false;
                ResetPioche(pioche);
                for (int i = 0; i < 3; i++)
                {
                    monJoueur1.tabCarte[i] = PiochezCarte(ref pioche);
                    ordi.tabCarte[i] = PiochezCarte(ref pioche);
                }
                CalculCarte(monJoueur1.tabCarte, ref total);
                monJoueur1.totalCarte = total;
                CalculCarte(ordi.tabCarte, ref total2);
                ordi.totalCarte = total2;
                Afficher("Voila vos carte joueur 1");
                for (int i = 0; i <= 2; i++)
                {
                    Afficher(+i + ".carte");
                    Afficher(monJoueur1.tabCarte[i].NomCarte + " de " + monJoueur1.tabCarte[i].sorteCarte.ToString());
                }
                Console.ReadKey();
                Afficher("Voila vos carte joueur 2");
                for (int i = 0; i <= 2; i++)
                {
                    Afficher(+i + ".carte");
                    Afficher(ordi.tabCarte[i].NomCarte + " de " + ordi.tabCarte[i].sorteCarte.ToString());

                }
                carteCentre = PiochezCarte(ref pioche);
                Console.ReadKey();
                while ( findeManche == false)
                {
                    Afficher("carte du centre");
                    Afficher(carteCentre.NomCarte + " de " + carteCentre.sorteCarte);
                    Console.ReadKey();
                    Afficher("A votre tour Joueur 1");
                    Console.WriteLine(total);
                    Afficher("1-piochez une carte");
                    Afficher("2-Recuperer la carte du centre et la remplacer avec une autre carte");
                    if (total >= 21)
                    {
                        Afficher("3-Toquez ");
                    }
                    choix = Convert.ToInt32(Console.ReadLine());
                    if (choix == 1)
                    {
                        Afficher("Choissisez la carte a changer");
                        for (int i = 0; i <= 2; i++)
                        {
                            Afficher(+i + "-" + monJoueur1.tabCarte[i].NomCarte + " de " + monJoueur1.tabCarte[i].sorteCarte.ToString());
                        }
                        choix = Convert.ToInt32(Console.ReadLine());
                        if (choix == 0)
                        {
                            carteCentre = monJoueur1.tabCarte[0];
                            monJoueur1.tabCarte[0] = PiochezCarte(ref pioche);
                            Afficher("voici votre nouvelle carte");
                            Afficher(monJoueur1.tabCarte[0].NomCarte + " de " + monJoueur1.tabCarte[0].sorteCarte.ToString());
                        }
                        else if (choix == 1)
                        {
                            carteCentre = monJoueur1.tabCarte[1];
                            monJoueur1.tabCarte[1] = PiochezCarte(ref pioche);
                            Afficher("voici votre nouvelle carte");
                            Afficher(monJoueur1.tabCarte[1].NomCarte + " de " + monJoueur1.tabCarte[1].sorteCarte.ToString());
                        }
                        else if (choix == 2)
                        {
                            carteCentre = monJoueur1.tabCarte[2];
                            monJoueur1.tabCarte[2] = PiochezCarte(ref pioche);
                            Afficher("voici votre nouvelle carte");
                            Afficher(monJoueur1.tabCarte[2].NomCarte + " de " + monJoueur1.tabCarte[2].sorteCarte.ToString());
                        }
                    }
                    else if (choix == 2)
                    {
                        Afficher("Choissisez la carte a changer");
                        carteCopie = carteCentre;
                        for (int i = 0; i <= 2; i++)
                        {
                            Afficher(+i + "-" + monJoueur1.tabCarte[i].NomCarte + " de " + monJoueur1.tabCarte[i].sorteCarte.ToString());
                        }
                        choix = Convert.ToInt32(Console.ReadLine());
                        if (choix == 0)
                        {
                            carteCentre = monJoueur1.tabCarte[0];
                            monJoueur1.tabCarte[0] = carteCopie;
                            Afficher("voici votre nouvelle carte");
                            Afficher(monJoueur1.tabCarte[0].NomCarte + " de " + monJoueur1.tabCarte[0].sorteCarte.ToString());
                        }
                        else if (choix == 1)
                        {
                            carteCentre = monJoueur1.tabCarte[1];
                            monJoueur1.tabCarte[1] = carteCopie;
                            Afficher("voici votre nouvelle carte");
                            Afficher(monJoueur1.tabCarte[1].NomCarte + " de " + monJoueur1.tabCarte[1].sorteCarte.ToString());
                        }
                        else if (choix == 2)
                        {
                            carteCentre = monJoueur1.tabCarte[2];
                            monJoueur1.tabCarte[2] = carteCopie;
                            Afficher("voici votre nouvelle carte");
                            Afficher(monJoueur1.tabCarte[2].NomCarte + " de " + monJoueur1.tabCarte[2].sorteCarte.ToString());
                        }
                    }
                    else if (choix ==3 && total >= 21)
                    {
                        Afficher("Joueur1 a " + total + "     joueur 2 a " + total2);
                        if (total > total2)
                        {
                            Afficher("joueur 2 a perdu une vie");
                            ordi.nbVie -= 1;
                        }
                        if (total2 > total)
                        {
                            Afficher("joueur 1 a perdu une vie");
                            monJoueur1.nbVie -= 1;
                            
                            
                        }
                        Console.ReadKey();
                        Console.Clear();
                        findeManche = true;
                    }
                    CalculCarte(monJoueur1.tabCarte, ref total);
                    monJoueur1.totalCarte = total;
                    if (findeManche == false)
                    {

                        Afficher("carte du centre");
                        Afficher(carteCentre.NomCarte + " de " + carteCentre.sorteCarte);
                        Console.ReadKey();
                        Afficher("A votre tour Joueur 2");
                        Console.WriteLine(total2);
                        Afficher("1-piochez une carte");
                        Afficher("2-Recuperer la carte du centre et la remplacer avec une autre carte");
                        if (total2 >= 21)
                        {
                            Afficher("3-Toquez ");
                        }
                        choix = Convert.ToInt32(Console.ReadLine());
                        if (choix == 1)
                        {
                            Afficher("Choissisez la carte a changer");
                            for (int i = 0; i <= 2; i++)
                            {
                                Afficher(+i+"-" + ordi.tabCarte[i].NomCarte + " de " + ordi.tabCarte[i].sorteCarte.ToString());
                            }
                            choix = Convert.ToInt32(Console.ReadLine());
                            if (choix == 0)
                            {
                                carteCentre = ordi.tabCarte[0];
                                ordi.tabCarte[0] = PiochezCarte(ref pioche);
                                Afficher("voici votre nouvelle carte");
                                Afficher(ordi.tabCarte[0].NomCarte + " de " + ordi.tabCarte[0].sorteCarte.ToString());
                            }
                            else if (choix == 1)
                            {
                                carteCentre = ordi.tabCarte[1];
                                ordi.tabCarte[1] = PiochezCarte(ref pioche);
                                Afficher("voici votre nouvelle carte");
                                Afficher(ordi.tabCarte[1].NomCarte + " de " + ordi.tabCarte[1].sorteCarte.ToString());
                            }
                            else if (choix == 2)
                            {
                                carteCentre = ordi.tabCarte[2];
                                ordi.tabCarte[2] = PiochezCarte(ref pioche);
                                Afficher("voici votre nouvelle carte");
                                Afficher(ordi.tabCarte[2].NomCarte + " de " + ordi.tabCarte[2].sorteCarte.ToString());
                            }
                        }
                        else if (choix == 2)
                        {
                            Afficher("Choissisez la carte a changer");
                            carteCopie = carteCentre;
                            for (int i = 0; i <= 2; i++)
                            {
                                Afficher(+i + "-" + ordi.tabCarte[i].NomCarte + " de " + ordi.tabCarte[i].sorteCarte.ToString());
                            }
                            choix = Convert.ToInt32(Console.ReadLine());
                            if (choix == 0)
                            {
                                carteCentre = ordi.tabCarte[0];
                                ordi.tabCarte[0] = carteCopie;
                                Afficher("voici votre nouvelle carte");
                                Afficher(ordi.tabCarte[0].NomCarte + " de " + ordi.tabCarte[0].sorteCarte.ToString());
                            }
                            else if (choix == 1)
                            {
                                carteCentre = ordi.tabCarte[1];
                                ordi.tabCarte[1] = carteCopie;
                                Afficher("voici votre nouvelle carte");
                                Afficher(ordi.tabCarte[1].NomCarte + " de " + ordi.tabCarte[1].sorteCarte.ToString());
                            }
                            else if (choix == 2)
                            {
                                carteCentre = ordi.tabCarte[2];
                                ordi.tabCarte[2] = carteCopie;
                                Afficher("voici votre nouvelle carte");
                                Afficher(ordi.tabCarte[2].NomCarte + " de " + ordi.tabCarte[2].sorteCarte.ToString());
                            }
                        }
                        else if (choix == 3 && total >= 21)
                        {
                            Afficher("Joueur1 a " + total + "     joueur 2 a " + total2);
                            if (total > total2)
                            {
                                Afficher("joueur 2 a perdu une vie");
                                ordi.nbVie -= 1;
                            }
                            if (total2 > total)
                            {
                                Afficher("joueur 1 a perdu une vie");
                                monJoueur1.nbVie -= 1;


                            }
                            
                            Console.ReadKey();
                            Console.Clear();
                            findeManche = true;
                        }
                        CalculCarte(ordi.tabCarte, ref total2);
                        ordi.totalCarte = total2;
                    }
                    if(monJoueur1.nbVie == 0)
                    {
                        win = true;
                        Afficher("joueur 2 a gagner");
                    }
                    else if (ordi.nbVie == 0)
                    {
                        win = true;
                        Afficher("joueur 1 a gagner");
                    }
                    Console.ReadKey();

                }
            }
                





            Console.ReadKey();
            
        }
    }
}
