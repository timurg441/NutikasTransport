using System;
using System.Collections.Generic;

namespace NutikasTransport
{
    public abstract class Soiduk : ILiigub
    {
        // Väljad vastavalt ülesandele
        public string Mark { get; protected set; }
        public double Kiirus { get; set; }
        private double kutuseTase;

        // Üldine statistika kogu pargi kohta (Static)
        public static double KokkuLabitudKM { get; private set; }
        public static List<string> SoiduLogi = new List<string>();

        // Valideerimine: kütus peab jääma vahemikku 0-100%
        public double KutuseTase
        {
            get => kutuseTase;
            set => kutuseTase = value < 0 ? 0 : (value > 100 ? 100 : value);
        }

        public Soiduk(string mark, double algKutus)
        {
            Mark = mark;
            KutuseTase = algKutus;
            Kiirus = 0;
        }

        // Meetodid kiiruse muutmiseks
        public void Kiirenda(double lisa) => Kiirus += lisa;
        public void Pidurda(double vahem) => Kiirus = Math.Max(0, Kiirus - vahem);

        // Abstraktne kuluarvutus, mida iga alamklass täidab erinevalt
        public abstract void ArvutaKulu(double km);

        // Meetod kütuse lisamiseks
        public void Tangi()
        {
            KutuseTase = 100;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n[INFO]: {Mark} on nüüd täis laetud/tangitud.");
            Console.ResetColor();
        }

        // Liidese meetodite realiseerimine
        public void AlustaSoitu()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\n[SÜSTEEM]: {Mark} mootor käivitati.");
            Console.ResetColor();
        }

        public void PeataSoit() => Console.WriteLine($"[SÜSTEEM]: {Mark} jõudis sihtkohta ja peatus.");

        // Statistika uuendamine
        protected void RegistreeriSoit(double km)
        {
            KokkuLabitudKM += km;
            SoiduLogi.Add($"{DateTime.Now.ToString("HH:mm")} - {Mark}: {km} km");
        }

        public abstract void Liigu(double km);

        // Staatiline meetod statistika kuvamiseks
        public static void KuvaPargiStatistika()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n--- PARGI ÜLDSTATISTIKA ---");
            Console.WriteLine($"Kõik masinad kokku läbinud: {KokkuLabitudKM} km");
            Console.WriteLine($"Tehtud sõitude arv: {SoiduLogi.Count}");
            if (SoiduLogi.Count > 0) Console.WriteLine("Viimane sõit: " + SoiduLogi[SoiduLogi.Count - 1]);
            Console.ResetColor();
        }
    }
}