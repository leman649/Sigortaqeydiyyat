using System;

namespace SigortaQeydiyyat
{
    public class Sigorta
    {
        public int Id { get; set; }
        public string MusteriAdSoyad { get; set; }
        public string Telefon { get; set; }
        public string FinKod { get; set; } 
        public string Email { get; set; }  
        public double Esasqiymet { get; set; } = 100;

        public Sigorta(int id, string musteriAdSoyad, string telefon, string finKod, string email)
        {
            Id = id;
            MusteriAdSoyad = musteriAdSoyad;
            Telefon = telefon;
            FinKod = finKod;
            Email = email;
        }

        public virtual double Qiymethesabla()
        {
            return Esasqiymet;
        }

        public virtual void MelumatGoster()
        {
            Console.WriteLine($"ID: {Id} | Müştəri: {MusteriAdSoyad} | FİN: {FinKod} | Tel: {Telefon} | Email: {Email} | Qiymət: {Qiymethesabla()} AZN");
        }
    }
}
