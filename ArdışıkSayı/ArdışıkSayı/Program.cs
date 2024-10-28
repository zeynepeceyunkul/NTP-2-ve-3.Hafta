using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArdışıkSayı
{
    class Program
    {
        static void Main(string[] args)
        {
            // Kullanıcıdan tam sayı listesi almak için bir liste tanımlar
            List<int> sayilar = new List<int>();

            Console.WriteLine("Sayıları girin, çıkmak için 0 girin");

            while (true)
            {
                int giris = int.Parse(Console.ReadLine()); // Girişleri int'e çevirir

                if (giris == 0) // Eğer sıfıra eşitse bitirir
                    break;
                sayilar.Add(giris); // Değilse listeye ekler

            }
            sayilar.Sort(); // Sayıları küçükten büyüğe sıralar

            List<String> gruplar = new List<string>(); // Ardışık grupları saklamak için tanımlanan liste

            // Dizide ardışık grupları bulmak için tanımlanan değişkenler
            int start = sayilar[0];
            int end = sayilar[0];

            for(int i = 1; i < sayilar.Count; i++)
            {
                if(sayilar[i]== end + 1) // eğer sayı ardışık ise end'i günceller
                {
                    end = sayilar[i];
                }
                else
                {
                    // Ardışık sayı grubu bulunduğunda, grubu kaydeder ve yeni bir grup başlatır
                    if (start == end)
                        gruplar.Add(start.ToString());

                    else
                        gruplar.Add(start + "-" + end);

                    // Yeni grubun başlangıcını ve sonunu ayarlar
                    start = sayilar[i];
                    end = sayilar[i];
                    
                }
            }

            if (start == end) // Döngü tamamlandığında son grubu da kontrol eder
                gruplar.Add(start.ToString());
            else
                gruplar.Add(start + "-" + end);

            // Ardışık grupları ekrana yazdırır
            Console.WriteLine("Ardışık sayı grupları:");
            foreach (var group in gruplar)
            {
                Console.WriteLine(group);
                Console.ReadKey();
            }


        }
    }
}
