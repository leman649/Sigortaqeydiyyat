using System;
using System.Collections.Generic;
using System.Text;

namespace SigortaQeydiyyat
{
    public class SaglamliqSigorta : Sigorta
    {
        public int Yas { get; set; }

        public SaglamliqSigorta(int id, string musteriAdSoyad, string telephone, string finKod, string email, int yas)
     : base(id, musteriAdSoyad, telephone, finKod, email)
        {
            Yas = yas;
        }

        public override double QiymetHesabla()
        {
            if (Yas > 50) return Esasqiymet + 120;
            return Esasqiymet + 30;
        }

        public override void MelumatGoster()
        {
            Console.WriteLine($"ID: {Id} | [SAĞLAMLIQ] {MusteriAdSoyad} | Yaş: {Yas} | Qiymət: {QiymetHesabla()} AZN | Tel: {Telefon} |Email:{Email}|Finkod:{FinKod}");
        }
    }
}