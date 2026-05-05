using System;

namespace NutikasTransport
{
    // 1. ELEKTRIAUTO - Kasutab akut
    public class Elektriauto : Soiduk
    {
        public Elektriauto(string mark, double aku) : base(mark, aku) { }
        public override void ArvutaKulu(double km) => KutuseTase -= (km * 0.15);
        public override void Liigu(double km)
        {
            if (KutuseTase <= 0) { Console.WriteLine("Aku on tühi! Palun lae autot."); return; }
            AlustaSoitu();
            ArvutaKulu(km);
            RegistreeriSoit(km);
            Console.WriteLine($"{Mark} suriseb teel. Aku jääk: {Math.Round(KutuseTase, 1)}%");
            PeataSoit();
        }
    }

    // 2. VEOAUTO - Arvestab koorma kaalu
    public class Veoauto : Soiduk
    {
        public double Koorem { get; set; }
        public Veoauto(string mark, double kutus, double kg) : base(mark, kutus) { Koorem = kg; }
        public override void ArvutaKulu(double km) => KutuseTase -= (km * 0.4) + (Koorem * 0.01);
        public override void Liigu(double km)
        {
            AlustaSoitu();
            ArvutaKulu(km);
            RegistreeriSoit(km);
            Console.WriteLine($"{Mark} vedas {Koorem}kg raskust. Kütuse jääk: {Math.Round(KutuseTase, 1)}%");
            PeataSoit();
        }
    }

    // 3. MOOTORRATAS - Lihtne ja efektiivne
    public class Mootorratas : Soiduk
    {
        public Mootorratas(string mark, double kutus) : base(mark, kutus) { }
        public override void ArvutaKulu(double km) => KutuseTase -= (km * 0.06);
        public override void Liigu(double km)
        {
            AlustaSoitu();
            ArvutaKulu(km);
            RegistreeriSoit(km);
            Console.WriteLine($"{Mark} läbis vahemaa kiirelt. Kütus: {Math.Round(KutuseTase, 1)}%");
            PeataSoit();
        }
    }

    // 4. BUSS - Arvestab reisijate arvu
    public class Buss : Soiduk
    {
        public int Reisijad { get; set; }
        public Buss(string mark, double kutus, int inims) : base(mark, kutus) { Reisijad = inims; }
        public override void ArvutaKulu(double km) => KutuseTase -= (km * 0.25) + (Reisijad * 0.05);
        public override void Liigu(double km)
        {
            AlustaSoitu();
            ArvutaKulu(km);
            RegistreeriSoit(km);
            Console.WriteLine($"{Mark} pardal oli {Reisijad} reisijat. Kütus: {Math.Round(KutuseTase, 1)}%");
            PeataSoit();
        }
    }
}