using System;
using System.Collections.Generic;

namespace PolinomIslemleri
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Polinomları örnekteki gibi girin: 2x^2 + 3x - 5\nÇıkmak için 'exit' yazabilirsiniz."); // Kullanıcıdan polinom girişi alınır

            while (true)
            {
                // İlk polinom alınır
                Console.Write("Birinci polinomu girin: ");
                string giris1 = Console.ReadLine();
                if (giris1.ToLower() == "exit") break; // Kullanıcı 'exit' yazarsa döngüden çıkar

                // İkinci polinom alınır
                Console.Write("İkinci polinomu girin: ");
                string giris2 = Console.ReadLine();
                if (giris2.ToLower() == "exit") break; // Kullanıcı 'exit' yazarsa döngüden çıkar

                try
                {
                    // Girilen polinomları analiz eder ve bir Dictionary'e aktarır
                    Dictionary<int, int> polinom1 = ParsePolinom(giris1);
                    Dictionary<int, int> polinom2 = ParsePolinom(giris2);

                    // Polinomları toplar
                    Dictionary<int, int> toplam = PolinomTopla(polinom1, polinom2);
                    Console.WriteLine("\nPolinomların toplamı: " + PolinomToString(toplam));

                    // Polinomları çıkarır
                    Dictionary<int, int> fark = PolinomCikar(polinom1, polinom2);
                    Console.WriteLine("Polinomların farkı: " + PolinomToString(fark));
                }
                catch (Exception ex) // Geçersiz işlemleri yakalayıp hata mesajı verir
                {
                    Console.WriteLine("Geçersiz bir giriş yaptınız, lütfen tekrar deneyin. Hata: " + ex.Message);
                }
                Console.WriteLine();
            }
        }

        // Polinomu analiz eder ve terimleri bir Dictionary'e aktarır
        static Dictionary<int, int> ParsePolinom(string polinom)
        {
            var terimler = new Dictionary<int, int>(); // Polinom terimlerini saklamak için
            polinom = polinom.Replace(" ", "").Replace("-", "+-");
            string[] parcala = polinom.Split('+');

            foreach (var parca in parcala)
            {
                if (string.IsNullOrEmpty(parca)) continue; // Boş parça varsa atlar

                // Varsayılan değerler
                int katsayi = 1;
                int us = 0;

                // Eğer parça yalnızca bir sabit sayıysa
                if (!parca.Contains("x"))
                {
                    katsayi = int.Parse(parca); // Sabit sayıyı katsayı olarak atar
                }
                else
                {
                    // Katsayı ve üs değerlerini ayırır
                    int xIndex = parca.IndexOf("x");
                    if (xIndex > 0)
                        katsayi = int.Parse(parca.Substring(0, xIndex)); // Katsayıyı alır
                    else if (xIndex == 0)
                        katsayi = 1;

                    if (parca.Contains("^"))
                        us = int.Parse(parca.Substring(xIndex + 2)); // Üs değerini alır
                    else
                        us = 1;
                }

                if (terimler.ContainsKey(us)) // Terimi Dictionary'e ekler 
                    terimler[us] += katsayi; // Eğer terim zaten varsa katsayıyı toplar
                else
                    terimler[us] = katsayi; // Yeni terim ekler
            }
            return terimler;
        }

        // İki polinomu toplar
        static Dictionary<int, int> PolinomTopla(Dictionary<int, int> p1, Dictionary<int, int> p2)
        {
            var sonuc = new Dictionary<int, int>(p1); // İlk polinomu kopyalar
            foreach (var terim in p2) // İkinci polinomun terimlerini ekler
            {
                if (sonuc.ContainsKey(terim.Key))
                    sonuc[terim.Key] += terim.Value; // Eğer terim zaten varsa, katsayıyı toplar
                else
                    sonuc[terim.Key] = terim.Value; // Yeni terim ekler
            }
            return sonuc;
        }

        // İki polinomu çıkarır
        static Dictionary<int, int> PolinomCikar(Dictionary<int, int> p1, Dictionary<int, int> p2)
        {
            var sonuc = new Dictionary<int, int>(p1); // İlk polinomu kopyalar
            foreach (var terim in p2) // İkinci polinomun terimlerini çıkarır
            {
                if (sonuc.ContainsKey(terim.Key))
                    sonuc[terim.Key] -= terim.Value; // Eğer terim zaten varsa, katsayıyı çıkar
                else
                    sonuc[terim.Key] = -terim.Value; // Negatif katsayı ile yeni terim ekler
            }
            return sonuc;
        }

        // Dictionary formatındaki polinomu string formatına çevirir
        static string PolinomToString(Dictionary<int, int> polinom)
        {
            var sonuc = "";
            foreach (var terim in polinom) // Her terimi kontrol eder 
            {
                if (terim.Value == 0) continue; // Katsayı 0 ise atlar

                // Katsayıyı belirler
                string katsayi = terim.Value > 0 && sonuc != "" ? "+" + terim.Value : terim.Value.ToString();
                // Üs değerini belirler
                string us = terim.Key > 1 ? "x^" + terim.Key : terim.Key == 1 ? "x" : "";

                sonuc += katsayi + us;
            }
            return sonuc == "" ? "0" : sonuc; // Eğer sonuç stringi boşsa "0" döndürür
        }
    }
}
