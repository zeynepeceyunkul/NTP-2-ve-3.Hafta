using System;
using System.Collections.Generic;

class Program
{
    // Fibonacci dizisini önceden hesaplayıp saklayacağız
    static List<int> fibonacciList = new List<int>();

    static void Main()
    {
        // Şifreli mesaj
        string sifreliMesaj = "şifrelenmişMesaj";

        // Orijinal mesajı tutacak değişken
        string orijinalMesaj = MesajiCoz(sifreliMesaj);

        // Çözülen orijinal mesajı ekrana yazdır
        Console.WriteLine("Orijinal Mesaj: " + orijinalMesaj);
    }

    // Şifreli mesajı çözmek için ana metod
    static string MesajiCoz(string sifreliMesaj)
    {
        // Fibonacci dizisini, şifreli mesajın uzunluğu kadar elemanla önceden hesapla
        FibonacciOlustur(sifreliMesaj.Length);

        // Çözülen karakterleri tutmak için bir liste
        List<char> orijinalKarakterler = new List<char>();

        // Şifreli mesajdaki her karakter için çözme işlemi yapılır
        for (int i = 0; i < sifreliMesaj.Length; i++)
        {
            int pozisyon = i + 1; // Karakter pozisyonu 1'den başlar
            int sifreliAscii = sifreliMesaj[i]; // Şifrelenmiş ASCII değeri

            // Adım 1: Mod işlemini tersine çevir
            int modSonucu;
            if (AsalMi(pozisyon)) // Pozisyon asal ise
            {
                // Asal pozisyonlarda mod 100 kullanılmıştır, bunu tersine çevir
                modSonucu = sifreliAscii + (sifreliAscii < 100 ? 100 : 0); // İlk 100 içinde ise 100 ekleriz
            }
            else
            {
                // Diğer pozisyonlarda mod 256 kullanılmıştır, bunu tersine çevir
                modSonucu = sifreliAscii + (sifreliAscii < 256 ? 256 : 0);
            }

            // Adım 2: Fibonacci ile bölme işlemini tersine çevir
            int orijinalAscii = modSonucu / fibonacciList[i]; // ASCII değeri geri hesaplanır

            // ASCII değerden karaktere dönüştür
            orijinalKarakterler.Add((char)orijinalAscii);
        }

        // Çözülen karakterleri birleştirerek orijinal mesajı oluştur
        return new string(orijinalKarakterler.ToArray());
    }

    // Fibonacci dizisini oluştur
    static void FibonacciOlustur(int uzunluk)
    {
        // Fibonacci dizisini başlat
        fibonacciList.Add(1);
        fibonacciList.Add(1);

        // Gerekli uzunlukta Fibonacci sayıları üret
        for (int i = 2; i < uzunluk; i++)
        {
            fibonacciList.Add(fibonacciList[i - 1] + fibonacciList[i - 2]);
        }
    }

    // Asal sayı kontrol fonksiyonu
    static bool AsalMi(int sayi)
    {
        // 1'den küçük sayılar asal değildir
        if (sayi <= 1) return false;

        // 2 ve 3 sayıları asaldır
        if (sayi <= 3) return true;

        // 2 veya 3 ile bölünebilen sayılar asal değildir
        if (sayi % 2 == 0 || sayi % 3 == 0) return false;

        // 5'ten başlayarak sayının kareköküne kadar kontrol et
        for (int i = 5; i * i <= sayi; i += 6)
        {
            if (sayi % i == 0 || sayi % (i + 2) == 0)
                return false;
        }

        return true; // Tüm koşullardan geçerse asaldır
    }
}
