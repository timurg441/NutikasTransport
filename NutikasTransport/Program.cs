using System;
using System.Collections.Generic;

namespace NutikasTransport
{
    class Program
    {
        static void Main(string[] args)
        {
            // Eestikeelsete tähtede toetus konsoolis
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // POLÜMORFISM: Hoiame erinevaid sõidukeid ühes nimekirjas
            List<Soiduk> parkla = new List<Soiduk>
            {
                new Elektriauto("Tesla Model S", 100),
                new Veoauto("Volvo FH16", 100, 5000),
                new Mootorratas("Yamaha R1", 100),
                new Buss("Tallinna Linnabuss", 100, 40)
            };

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n======= NUTIKAS TRANSPORT 2.0 =======");
                Console.ResetColor();

                // Kuvame nimekirja koos kütuse tasemega
                for (int i = 0; i < parkla.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {parkla[i].Mark.PadRight(20)} | Kütus: {Math.Round(parkla[i].KutuseTase, 1)}%");
                }
                Console.WriteLine("9. Kuva pargi üldstatistika");
                Console.WriteLine("0. Välju");
                Console.Write("\nVali sõiduk või tegevus: ");

                if (int.TryParse(Console.ReadLine(), out int valik))
                {
                    if (valik == 0) break;

                    if (valik == 9)
                    {
                        Soiduk.KuvaPargiStatistika();
                        continue;
                    }

                    if (valik > 0 && valik <= parkla.Count)
                    {
                        var masin = parkla[valik - 1];
                        Console.WriteLine($"\n--- {masin.Mark} ---");
                        Console.WriteLine("1. Sõida sihtkohta");
                        Console.WriteLine("2. Tangi / Lae");
                        Console.Write("Valik: ");

                        string tegevus = Console.ReadLine();

                        if (tegevus == "1")
                        {
                            Console.Write("Sisesta vahemaa (km): ");
                            if (double.TryParse(Console.ReadLine(), out double km))
                            {
                                masin.Liigu(km);
                            }
                            else Console.WriteLine("Viga: Vale vahemaa formaat!");
                        }
                        else if (tegevus == "2")
                        {
                            masin.Tangi();
                        }
                    }
                    else Console.WriteLine("Viga: Sellist valikut pole!");
                }
            }
            Console.WriteLine("Programm suletakse. Turvalist teed!");
        }
    }
}