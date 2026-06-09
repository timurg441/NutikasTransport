using System;
using System.Collections.Generic;
using System.Text;

namespace NutikasTransport
{
    public class Mootorratas : Soiduk
    {
        public Mootorratas(string mark, double kutus) : base(mark, kutus) { }
        public override void ArvutaKulu(double km) => KutuseTase -= (km * 0.07);
        public override void Liigu(double km)
        {
            AlustaSoitu();
            Kiirenda(90);
            ArvutaKulu(km);
            RegistreeriSoit(km);
            Console.WriteLine($"{Mark} vuras sihtkohta. Kütus: {Math.Round(KutuseTase, 1)}%");
            PeataSoit();
        }
    }
}
