using System;

namespace SigortaQeydiyyat
{
    class Program
    {
        static Sigortameneceri insuranceController = new Sigortameneceri();

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            bool davamEdilsin = true;

            while (davamEdilsin)
            {
                Console.Clear();
                Console.WriteLine("SIĞORTA QEYDİYYAT SİSTEMİ ");
                Console.WriteLine("1. Yeni Sığorta Qeydiyyatı");
                Console.WriteLine("2. Sığorta Qeydiyyatını Sil");
                Console.WriteLine("3. Bütün Sığorta Siyahısı");
                Console.WriteLine("4. Çıxış");
                Console.Write("\nSeçiminiz: ");

                string secim = Console.ReadLine();

                if (secim == "1")
                {
                    Console.Clear();

                    string ad = "";
                    while (true)
                    {
                        Console.Write("Müştərinin Ad Soyadı: ");
                        ad = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(ad))
                        {
                            Console.WriteLine("XƏTA: Ad boş buraxıla bilməz!\n");
                            continue;
                        }
                        bool ancaqHerfdir = true;
                        foreach (char c in ad)
                        {
                            if (!char.IsLetter(c) && !char.IsWhiteSpace(c)) { ancaqHerfdir = false; break; }
                        }
                        if (ancaqHerfdir) break;
                        else Console.WriteLine("XƏTA: Ad Soyad daxilində rəqəm və ya simvol ola bilməz!\n");
                    }

                 
                    string fin = "";
                    while (true)
                    {
                        Console.Write("Müştərinin FİN Kodu (7 simvol): ");
                        fin = Console.ReadLine()?.Trim();
                        if (fin.Length == 7) break;
                        Console.WriteLine("XƏTA: FİN kod dəqiq 7 simvoldan ibarət olmalıdır!\n");
                    }

                   
                    string tel = "";
                    while (true)
                    {
                        Console.Write("Telefonu (Ancaq rəqəmlər): ");
                        tel = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(tel)) { Console.WriteLine("XƏTA: Telefon boş buraxıla bilməz!\n"); continue; }
                        bool ancaqReqemdir = true;
                        foreach (char c in tel) { if (!char.IsDigit(c)) { ancaqReqemdir = false; break; } }
                        if (ancaqReqemdir) break;
                        else Console.WriteLine("XƏTA: Telefon nömrəsində hərf və ya simvol ola bilməz!\n");
                    }

                    
                    string email = "";
                    while (true)
                    {
                        Console.Write("E-poçt Ünvanı (Email): ");
                        email = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(email) && email.Contains("@")) break;
                        Console.WriteLine("XƏTA: Düzgün email ünvanı daxil edin (Məsələn: musteri@mail.com)!\n");
                    }

                    string nov = "";
                    while (nov != "1" && nov != "2" && nov != "3")
                    {
                        Console.WriteLine("\nSığorta növünü seçin:");
                        Console.WriteLine("1 - Avto Sığorta");
                        Console.WriteLine("2 - Sağlamlıq Sığortası");
                        Console.WriteLine("3 - Əmlak Sığortası");
                        Console.Write("Seçiminiz (1, 2 və ya 3): ");
                        nov = Console.ReadLine();
                    }

                  
                    double xususiDeyer = 0;
                    if (nov == "1")
                    {
                        while (true)
                        {
                            Console.Write("Avtomobilin istehsal ilini daxil edin (məs: 2020): ");
                            if (int.TryParse(Console.ReadLine(), out int il) && il > 1900 && il <= DateTime.Now.Year + 1) { xususiDeyer = il; break; }
                            Console.WriteLine("XƏTA: Düzgün il daxil edin!\n");
                        }
                    }
                    else if (nov == "2")
                    {
                        while (true)
                        {
                            Console.Write("Müştərinin yaşını daxil edin: ");
                            if (int.TryParse(Console.ReadLine(), out int yas) && yas > 0 && yas < 120) { xususiDeyer = yas; break; }
                            Console.WriteLine("XƏTA: Düzgün yaş daxil edin!\n");
                        }
                    }
                    else if (nov == "3")
                    {
                        while (true)
                        {
                            Console.Write("Əmlakın sahəsini daxil edin (m²): ");
                            if (double.TryParse(Console.ReadLine(), out double sahe) && sahe > 0) { xususiDeyer = sahe; break; }
                            Console.WriteLine("XƏTA: Düzgün sahə dəyəri daxil edin!\n");
                        }
                    }

                    insuranceController.SigortaVer(ad, tel, fin, email, nov, xususiDeyer);
                    Gozle();
                }
                else if (secim == "2")
                {
                    Console.Clear();
                    Console.Write("Sığortası silinəcək Müştərinin Ad Soyadı: ");
                    string ad = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(ad)) insuranceController.SigortaSil(ad);
                    Gozle();
                }
                else if (secim == "3")
                {
                    Console.Clear();
                    insuranceController.SiyahiniGoster();
                    Gozle();
                }
                else if (secim == "4")
                {
                    davamEdilsin = false;
                }
            }
        }

        static void Gozle()
        {
            Console.WriteLine("\nDavam etmək üçün Enter-ə basın...");
            Console.ReadLine();
        }
    }
}