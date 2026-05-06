using System;
using System.Collections.Generic;

namespace NutikasTransport
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            List<Soiduk> parkla = new List<Soiduk>
            {
                new Elektriauto("Tesla Model S", 100),
                new Veoauto("Volvo FH16", 100),
                new Buss("Tallinna Linnabuss", 100),
                new Mootorratas("Kawasaki Ninja", 100)
            };

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n======= NUTIKAS TRANSPORT =======");
                Console.ResetColor();

                for (int i = 0; i < parkla.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {parkla[i].Mark.PadRight(20)} | Kütus: {Math.Round(parkla[i].KutuseTase, 1)}%");
                }
                Console.WriteLine("9. Kuva pargi üldstatistika");
                Console.WriteLine("0. Välju");
                Console.Write("\nVali sõiduk: ");

                if (int.TryParse(Console.ReadLine(), out int valik))
                {
                    if (valik == 0) break;
                    if (valik == 9) { Soiduk.KuvaPargiStatistika(); continue; }

                    if (valik > 0 && valik <= parkla.Count)
                    {
                        var masin = parkla[valik - 1];
                        Console.WriteLine($"\n--- VALITUD: {masin.Mark} ---");
                        Console.WriteLine("1. Alusta sõitu");
                        Console.WriteLine("2. Tangi / Lae");
                        Console.Write("Sinu valik: ");
                        string tegevus = Console.ReadLine();

                        if (tegevus == "1")
                        {
                            if (masin is Veoauto veoauto)
                            {
                                Console.Write("Sisesta koorma kaal (kg): ");
                                veoauto.Koorem = double.Parse(Console.ReadLine());
                            }
                            else if (masin is Buss buss)
                            {
                                Console.Write("Sisesta reisijate arv: ");
                                buss.Reisijad = int.Parse(Console.ReadLine());
                            }

                            Console.Write("Sisesta vahemaa (km): ");
                            if (double.TryParse(Console.ReadLine(), out double km))
                            {
                                masin.Liigu(km);
                            }
                        }
                        else if (tegevus == "2") masin.Tangi();
                    }
                }
            }
        }
    }
}