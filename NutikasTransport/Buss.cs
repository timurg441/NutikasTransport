using System;
using System.Collections.Generic;
using System.Text;

namespace NutikasTransport
{
    public class Buss : Soiduk
    {
        public int Reisijad { get; set; }

        public Buss(string mark, double kutus) : base(mark, kutus) { }

        public override void ArvutaKulu(double km) => KutuseTase -= (km * 0.25) + (Reisijad * 0.06);

        public override void Liigu(double km)
        {
            AlustaSoitu();
            Kiirenda(50);
            ArvutaKulu(km);
            RegistreeriSoit(km);
            Console.WriteLine($"{Mark} pardal oli {Reisijad} reisijat. Kütus: {Math.Round(KutuseTase, 1)}%");
            PeataSoit();
        }
    }
}
