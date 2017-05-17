using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geldautomaat
{
    class Program
    {
        public static bool giveBool(string question)
        {
            while (true)
            {
                Console.Write(question);
                string Answer = Console.ReadLine().ToLower();

                if (Answer == "ja" || Answer == "nee")
                {
                    if (Answer == "ja") { return true; }

                    else { return false; }

                }
                Console.WriteLine("Antwoord met Ja of Nee");
            }
        }

        public static double giveDouble(string question, bool saldo)
        {
            double Double;
            while (true)
            {
                Console.WriteLine(question);

                try
                {
                    Double = double.Parse(Console.ReadLine());

                    if (!saldo)
                    {
                        if (Double < 0)
                        {
                            Console.WriteLine("Voer een positief bedrag in");
                        }

                        else
                        {
                            return Double;
                        }
                    }

                    else
                    {
                        return Double;
                    }

                }

                catch { Console.WriteLine("Voer een bedrag in"); }
            }

        }

        static void Main(string[] args)
        {

            bool geldopnemen = true;

            while (geldopnemen)
            {

                string GeenGeldOpnemen = "Geen geld voor jou";
                string GeldOpgenomen = "Hier is je geld";
                Rekening rekening = new Rekening(giveDouble("Saldo?", true), giveDouble("Hoeveel euro mag je rood staan?", false));
                Automaat automaat = new Automaat(giveBool("Automaat aan?"), giveDouble("Opnamelimiet?", false), giveDouble("Vooraadlimiet?", false));

                double OpnameHoeveelheid = giveDouble("Hoeveel opnemen?", false);
                double nieuwsaldo = (rekening.Saldo - OpnameHoeveelheid);

                if (!automaat.InBedrijf)
                {
                    Console.WriteLine("Automaat is uit");
                    Console.WriteLine(GeenGeldOpnemen);

                }

                else if (OpnameHoeveelheid > automaat.Opnamelimiet)
                {
                    Console.WriteLine("Over opname limiet");
                    Console.WriteLine(GeenGeldOpnemen);
                }

                else if (OpnameHoeveelheid > automaat.VooraadLimiet)
                {
                    Console.WriteLine("Niet genoeg geld op vooraad");
                    Console.WriteLine(GeenGeldOpnemen);
                }



                else if (nieuwsaldo >= 0)
                {
                    Console.WriteLine("Oud Saldo" + rekening.Saldo);
                    rekening.Saldo = nieuwsaldo;
                    Console.WriteLine(GeldOpgenomen);
                    Console.WriteLine("Nieuw Saldo" + rekening.Saldo);
                }

                else if (nieuwsaldo < 0)
                {
                    if (rekening.kredietlimiet + nieuwsaldo >= 0)
                    {
                        Console.WriteLine("Oud Saldo" + rekening.Saldo);
                        rekening.Saldo = nieuwsaldo;
                        Console.WriteLine(GeldOpgenomen);
                        Console.WriteLine("Nieuw Saldo" + rekening.Saldo);
                    }

                    else
                    {
                        Console.WriteLine("Over kredietlimiet");
                        Console.WriteLine(GeenGeldOpnemen);
                    }
                }
            }
        }
    }
}
