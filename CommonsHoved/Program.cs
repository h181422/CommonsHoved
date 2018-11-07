using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonsHoved
{
    class Program
    {
        static void Main(string[] args)
        {
            //Lager en ny fil eller overskriver eksisterende filer
            Commons.SkrivTilFil("ele124.txt", new string[] {"Første linje", "Andre linje", "Tredje Linje","Fjerde linje"});
            //Skriver videre på en eksisterende fil
            Commons.SkrivTilFil("ele124.txt", new string[] {"nest siste linje", "Siste linje" }, true);
            //Spør bruker etter filnavn, åpner deretter filen om den finnes
            bool fileFound = false;
            while (!fileFound)
            {
                Console.WriteLine("Skriv inn navn på fil (inkludert plassering)");
                string[] test = Commons.LesFraFil(Console.ReadLine(), ref fileFound, 1);
                if(!fileFound)
                    Console.WriteLine(test[0]);
                else
                {
                    foreach (string linje in test)
                    {
                        Console.WriteLine(linje);
                    }
                }
            }

            //Lager en fil for koden under
            Commons.SkrivTilFil("tall.txt", new string[] { "1 2,4", "2 4,3", "3 5,7" });
            //Åpner en fil, leser linje for linje, og deler deretter opp hver linje og konverterer dem til tall.
            string[] a = Commons.LesFraFil("tall.txt");
            double gjennomsnitt = 0;
            foreach(string s in a)
            {
                string[] ord = s.Split(' ');
                int i = Convert.ToInt32(ord[0]);
                double d = Convert.ToDouble(ord[1]);
                Console.WriteLine(i + " " + d);
                //Vi kan nå bruke i og d slik som vi ønsker. f.eks til å finne gjennomsnittet av d:
                gjennomsnitt += d;
            }
            gjennomsnitt /= a.Length;
            Console.WriteLine("Gjennomsnittet er: " + gjennomsnitt);
          
            //Tester å hente en int fra brukeren vha. commons klassen
            Console.WriteLine("Skriv inn antall elever: ");
            Console.WriteLine("Du skrev inn {0}", Commons.GetIntConsole("Feil! Antall elever må være et heltall!\nPrøv igjen:", minValue:0));


            Console.WriteLine("Trykk hvilken som helst tast for å avslutte.");
            Console.ReadKey();
        }
    }
}
