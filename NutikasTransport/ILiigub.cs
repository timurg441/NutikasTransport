namespace NutikasTransport
{
    // Liides määrab ühise käitumise kõigile sõidukitele
    public interface ILiigub
    {
        void AlustaSoitu();      // Meetod sõidu alustamiseks
        void PeataSoit();        // Meetod sõidu lõpetamiseks
        void Liigu(double km);   // Meetod vahemaa läbimiseks
    }
}