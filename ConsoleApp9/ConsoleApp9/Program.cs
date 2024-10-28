using System;
using System.Collections.Generic;

class Program
{
    // Kullanılacak sayı ve operatör dizilerini tanımlıyoruz
    static List<string> sayilar = new List<string> { "5", "3", "8", "2" }; // Örnek sayı dizisi
    static List<string> operatorler = new List<string> { "+", "-", "*", "/" }; // Kullanılacak operatörler

    static void Main(string[] args)
    {
        // Sayı dizisi için tüm kombinasyonları oluşturuyoruz
        List<string> ifadeler = IfadeOlustur(sayilar, operatorler, "");

        // Her bir ifadeyi değerlendiriyoruz
        foreach (var ifade in ifadeler)
        {
            double sonuc = IfadeDegerlendir(ifade);
            // Sonuç sıfırdan büyükse yazdırıyoruz
            if (sonuc > 0)
            {
                Console.WriteLine("Geçerli İfade: " + ifade + " = " + sonuc);
                Console.ReadKey();
            }
        }
    }

    // Sayı ve operatör kombinasyonlarını oluşturuyor
    static List<string> IfadeOlustur(List<string> nums, List<string> ops, string mevcut)
    {
        List<string> ifadeler = new List<string>();

        // Eğer geçerli bir ifade oluştuysa ekliyoruz
        if (!string.IsNullOrEmpty(mevcut))
        {
            ifadeler.Add(mevcut);
        }

        // Tüm kombinasyonları deniyoruz
        for (int i = 0; i < nums.Count; i++)
        {
            for (int j = 0; j < ops.Count; j++)
            {
                // Yeni ifade oluşturuyoruz
                string yeniIfade = mevcut + (mevcut.Length > 0 ? ops[j] : "") + nums[i];

                // Geçerli bir ifade oluşturmak için yine çağırıyoruz
                ifadeler.AddRange(IfadeOlustur(ElemanCikar(nums, i), ops, yeniIfade));
            }
        }

        return ifadeler;
    }

    // Belirtilen indeksteki öğeyi diziden çıkarır
    static List<string> ElemanCikar(List<string> liste, int indeks)
    {
        List<string> yeniListe = new List<string>(liste);
        yeniListe.RemoveAt(indeks);
        return yeniListe;
    }

    // İfadeyi değerlendirir
    static double IfadeDegerlendir(string ifade)
    {
        try
        {
            // System.Data.DataTable kullanarak ifadeyi değerlendiriyoruz
            var veriTablosu = new System.Data.DataTable();
            return Convert.ToDouble(veriTablosu.Compute(ifade, string.Empty));
        }
        catch (Exception)
        {
            return double.NaN; // Eğer bir hata oluşursa NaN döner
        }
    }
}
