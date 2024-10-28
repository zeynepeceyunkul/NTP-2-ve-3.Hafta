using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrtMedyan
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> sayilar = new List<int>(); // Pozitif tam sayıların saklanacağı liste
            int giris; // sayi girişi için değişken

            Console.WriteLine("Pozitif tam sayılar girin, çıkmak için 0 girin."); // Kullanıcıdan isteme

            while (true)
            {
                giris = int.Parse(Console.ReadLine()); // Girilen sayıları int'e çevirir

                if (giris == 0) // Girilen sayı sıfırsa döngüden çıkar
                    break;

                if (giris > 0) // Girilen sayı pozitifse listeye eklenir
                    sayilar.Add(giris); 
            }

            if (sayilar.Count == 0) // Eğer hiç sayı girilmemişse listenin boş olduğu yazdırılır
            {  
                Console.Write("Liste boş.");
                Console.ReadKey();
                return; // ve biter
                
            }

            double ortalama = sayilar.Average(); // Girilen sayıların ortalaması hesaplanır

            sayilar.Sort(); // Sayılar küçükten büyüğe sıralanır
            double medyan; // medyan değerini yazdıracağımız değişken
            int sayi = sayilar.Count; // Eleman sayısını gösteren değişken

            if (sayi % 2 == 0) // // Eğer eleman sayısı çiftse 
            {
                medyan = (sayilar[sayi / 2 - 1] + sayilar[sayi / 2]) / 2.0; // Ortadaki iki sayının ortalamsı alınır
            }
            else // tekse
                medyan = (sayilar[sayi / 2]); // ortadaki eleman alınır

            Console.WriteLine("Ortalama: " + ortalama); // Ortalama yazdırılır
            Console.WriteLine("Medyan: " + medyan); // Medyan yazdırılır
            Console.ReadKey();
        }
    }
}
