using System;

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
            Kiirenda(60); // Demonstreerime kiirendamist
            ArvutaKulu(km);
            RegistreeriSoit(km);
            Console.WriteLine($"{Mark} suriseb teel. Aku jääk: {Math.Round(KutuseTase, 1)}%");
            PeataSoit();
        }
    }

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