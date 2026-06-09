using System;
using System.Collections.Generic;
using System.Text;

namespace NutikasTransport
{
    public class Veoauto : Soiduk
    {
        public double Koorem { get; set; }
        public Veoauto(string mark, double kutus) : base(mark, kutus) { }
        public override void ArvutaKulu(double km) => KutuseTase -= (km * 0.4) + (Koorem * 0.015);
        public override void Liigu(double km)
        {
            AlustaSoitu();
            Kiirenda(40);
            ArvutaKulu(km);
            RegistreeriSoit(km);
            Console.WriteLine($"{Mark} vedas {Koorem}kg koormat. Kütuse jääk: {Math.Round(KutuseTase, 1)}%");
            PeataSoit();
        }
    }
}
