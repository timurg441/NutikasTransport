using System;
using System.Collections.Generic;
using System.Text;

namespace NutikasTransport
{
    public class Elektriauto : Soiduk
    {
        public Elektriauto(string mark, double aku) : base(mark, aku) { }
        public override void ArvutaKulu(double km) => KutuseTase -= (km * 0.12);
        public override void Liigu(double km)
        {
            if (KutuseTase <= 0) { Console.WriteLine("Aku on tühi!"); return; }
            AlustaSoitu();
            Kiirenda(60);
            ArvutaKulu(km);
            RegistreeriSoit(km);
            Console.WriteLine($"{Mark} suriseb teel. Aku jääk: {Math.Round(KutuseTase, 1)}%");
            PeataSoit();
        }
    }
}
