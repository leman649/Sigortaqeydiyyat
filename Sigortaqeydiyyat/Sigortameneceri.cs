using System;
using System.Collections.Generic;

namespace SigortaQeydiyyat
{
    public class Sigortameneceri
    {
        private List<Sigorta> sigortaDatabase = new List<Sigorta>();
        private int idSaygaci = 1;

        
        public void SigortaVer(string adSoyad, string tel, string finKod, string email, string nov, double xususiDeyer)
        {
            Sigorta yeniSigorta = null;

            if (nov == "1")
            {
                yeniSigorta = new AvtoSigorta(idSaygaci, adSoyad, tel, finKod, email, (int)xususiDeyer);
            }
            else if (nov == "2")
            {
                yeniSigorta = new SaglamliqSigorta(idSaygaci, adSoyad, tel, finKod, email, (int)xususiDeyer);
            }
            else if (nov == "3")
            {
                yeniSigorta = new EmlakSigorta(idSaygaci, adSoyad, tel, finKod, email, xususiDeyer);
            }

            if (yeniSigorta != null)
            {
                sigortaDatabase.Add(yeniSigorta);
                idSaygaci++;
                Console.WriteLine($"\n[Uğurlu]: {adSoyad} üçün sığorta qeydiyyatı tamamlandı!");
            }
        }

        public void SigortaSil(string adSoyad)
        {
            Sigorta silineceksigorta = sigortaDatabase.Find(s => s.MusteriAdSoyad.ToLower() == adSoyad.ToLower());

            if (silineceksigorta!= null)
            {
                sigortaDatabase.Remove(silineceksigorta);
                Console.WriteLine($"\n[Uğurlu]: {adSoyad} adlı şəxsin sığorta qeydiyyatı silindi.");
            }
            else
            {
                Console.WriteLine("\nXƏTA: Bu adda aktiv sığorta qeydiyyatı tapılmadı.");
            }
        }

        public void SiyahiniGoster()
        {
            Console.WriteLine("\nAktiv Sığorta Siyahısı ");
            if (sigortaDatabase.Count == 0) Console.WriteLine("Siyahı boşdur.");
            foreach (var s in sigortaDatabase)
            {
                s.MelumatGoster();
            }
        }
    }
}