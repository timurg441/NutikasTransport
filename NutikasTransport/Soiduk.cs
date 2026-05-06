using System;
using System.Collections.Generic;
using System.Threading;

namespace NutikasTransport
{
    public abstract class Soiduk : ILiigub
    {
        public string Mark { get; protected set; }
        public double Kiirus { get; protected set; }
        private double kutuseTase;

        public static double KokkuLabitudKM { get; private set; }
        public static List<string> SoiduLogi = new List<string>();

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

        public void Tangi()
        {
            KutuseTase = 100;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n[INFO]: {Mark} on nüüd täis laetud/tangitud (100%).");
            Console.ResetColor();
        }

        public void Kiirenda(double lisa)
        {
            Kiirus += lisa;
            Console.WriteLine($"[LOGI]: {Mark} kiirendab... Hetkekiirus: {Kiirus} km/h");
        }

        public void Pidurda(double vahem)
        {
            Kiirus = Math.Max(0, Kiirus - vahem);
            Console.WriteLine($"[LOGI]: {Mark} pidurdab... Hetkekiirus: {Kiirus} km/h");
        }

        public abstract void ArvutaKulu(double km);

        public void AlustaSoitu()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\n[SÜSTEEM]: {Mark} mootor käivitatud. Alustame liikumist...");
            Console.ResetColor();
            Thread.Sleep(800);
        }

        public void PeataSoit()
        {
            Pidurda(Kiirus);
            Console.WriteLine($"[SÜSTEEM]: Sihtkoht käes. {Mark} seisab.");
        }

        protected void RegistreeriSoit(double km)
        {
            KokkuLabitudKM += km;
            SoiduLogi.Add($"{DateTime.Now.ToString("HH:mm")} - {Mark}: {km} km");
        }

        public abstract void Liigu(double km);
        public static void KuvaPargiStatistika()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n--- PARGI ÜLDSTATISTIKA ---");
            Console.WriteLine($"Läbitud vahemaa kokku: {KokkuLabitudKM} km");
            Console.WriteLine($"Sõitude ajalugu: {SoiduLogi.Count} kirjet");
            foreach (var log in SoiduLogi) Console.WriteLine($" > {log}");
            Console.ResetColor();
        }
    }
}