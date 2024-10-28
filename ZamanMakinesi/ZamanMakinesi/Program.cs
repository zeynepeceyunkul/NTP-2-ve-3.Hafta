using System;
using System.Collections.Generic;

class ZamanMakinesi
{
    static void Main()
    {
        List<string> uygunTarihler = new List<string>();

        int baslangicYili = 2000;
        int bitisYili = 3000;

        DateTime bugun = DateTime.Today;

        for (int yil = baslangicYili; yil <= bitisYili; yil++)
        {
            if (!YilKosuluSaglanir(yil)) continue;

            for (int ay = 1; ay <= 12; ay++)
            {
                if (!AyKosuluSaglanir(ay)) continue;

                int maxGun = DateTime.DaysInMonth(yil, ay);

                for (int gun = 1; gun <= maxGun; gun++)
                {
                    DateTime tarih = new DateTime(yil, ay, gun);

                    if (tarih <= bugun) continue;
                    if (GunAsalMi(gun))
                    {
                        uygunTarihler.Add(tarih.ToString("dd-MM-yyyy"));
                        
                    }
                }
            }
        }

        foreach (var tarih in uygunTarihler)
        {
            Console.WriteLine(tarih);
            
        }

        
    }

    static bool GunAsalMi(int gun)
    {
        if (gun < 2) return false;
        for (int i = 2; i * i <= gun; i++)
        {
            if (gun % i == 0) return false;
        }
        return true;
    }

    static bool AyKosuluSaglanir(int ay)
    {
        int toplam = 0;
        while (ay > 0)
        {
            toplam += ay % 10;
            ay /= 10;
        }
        return toplam % 2 == 0;
    }

    static bool YilKosuluSaglanir(int yil)
    {
        int toplam = 0;
        int yilKopya = yil;
        while (yilKopya > 0)
        {
            toplam += yilKopya % 10;
            yilKopya /= 10;
        }
        return toplam < yil / 4;
    }
}