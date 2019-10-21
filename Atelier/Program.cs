using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            int nbSaisie = 0;
            int valeur = 0;
            
            Console.WriteLine("entrez votre nombre");
            nbSaisie = Convert.ToInt32(Console.ReadLine());
            valeur = nbSaisie;
            for(int i=1; i <= nbSaisie; i++)
            {
                valeur = valeur*i;
            }
            Console.WriteLine("valeur=" +valeur);
            Console.ReadKey();
        }
    }
}
