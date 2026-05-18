using System;
using System.Collections.Generic;
using System.Text;
namespace SigortaQeydiyyat
{
    public class AvtoSigorta : Sigorta
    {
        public int Il { get; set; }

        public AvtoSigorta(int id, string musteriAdSoyad, string telefon, string finKod, string email, int il)
    : base(id, musteriAdSoyad, telefon, finKod, email)
        {
            Il = il;
        }

        public override double qiymethesabla()
        {
            if (Il < 2015) return esasqiymet + 80;
            return esasqiymet + 40;
        }

        public override void MelumatGoster()
        {
            Console.WriteLine($"ID: {Id} | [AVTO] {MusteriAdSoyad} | İl: {Il} | Qiymət: {QiymetHesabla()} AZN | Tel: {Telefon} |Email:{Email}|Finkod:{FinKod}");
        }
    }
}
