using System;
using System.Collections.Generic;
using System.Text;
namespace SigortaQeydiyyat
{
    public class EmlakSigorta : Sigorta
    {
        public double Sahe { get; set; }

        public EmlakSigorta(int id, string musteriAdSoyad, string telefon, string finKod, string email, double sahe)
    : base(id, musteriAdSoyad, telefon, finKod, email)
        {
            Sahe = sahe;
        }
       

        public override double Qiymethesabla()
        {
            return esasqiymet + (Sahe * 0.5);
        }

        public override void MelumatGoster()
        {
            Console.WriteLine($"ID: {Id} | [ƏMLAK] {MusteriAdSoyad} | Sahə: {Sahe} m² | Qiymət: {Qiymethesabla()} AZN | Tel: {Telefon}|Email:{Email}|Finkod: {FinKod}");
        }
    }
}
