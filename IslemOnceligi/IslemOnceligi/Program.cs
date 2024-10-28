using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IslemOnceligi
{
    class Program
    {
        static void Main(string[] args)
        {
            // Matematiksel işlem girişi alırız
            Console.WriteLine("Bir matematiksel ifade girin, örnek: 5 + 8 *6 / (3 + 4)^2"); 
            string giris = Console.ReadLine();

            

            Console.WriteLine("\nİşlem adımları:"); 

            // İşlem adımlarının açıklandığı değişken
            string açıklama = IslemOnceligiVeAciklama(giris);

            Console.WriteLine(açıklama); 
            Console.ReadKey();


        }

        static string IslemOnceligiVeAciklama(string ifade) // İşelm önceliği ve işlemlerin açıklamasını barındıran metot
        {
            try
            {
                DataTable dt = new DataTable(); // Böyle bir matematiksel işlem için de kullanılabilir
                dt.Columns.Add("ifade", typeof(string), ifade); // Girilen ifadeyi "ifade" adlı sütunda string şeklinde saklar

                string açıklama="";

                açıklama += "1. Parantez içindeki işlemler çözülür: "+ ParantezCoz(ifade); // Parantez önceliği

                açıklama += "\n2. Üslü işlemler çözülür: "+ UsCoz(ifade); // Üslü ifade önceliği (DataTable ifadesi '^' işaretini üs olarak algılayamıyor.)

                açıklama += "\n3. Çarpma-Bölme işlemi çözülür: "+ CarpmaBolmeCoz(ifade); // Çarpma Bölme Önceliği

                açıklama += "\n4. Toplama-Çıkarma işlemi çözülür: "+ ToplamaCıkarmaCoz(ifade); // Toplama Çıkarma Önceliği

                object sonuc = dt.Compute(ifade, "");
                açıklama += "\nSonuç: " + sonuc; // Sonuç işlem adımlarının açıklandığı açıklama ifadesine atanıyor

                return açıklama; // açıklamayı döndürüyor
            }
            catch(Exception ex) // Herhangi bir karakter hatası varsa onu kısa bir mesaj olarak yazdırıp programı bitiriyot
            {
                return "Bir hata oluştu: " + ex.Message;
            }

        }
        
        // İşelm önceliklerinin metotları tanımlanıyor
        static string ParantezCoz(string ifade) 
        {
            return ifade;
           
        }
        static string UsCoz(string ifade)
        {
            var powerRegex = new Regex(@"(\d+(\.\d+)?\s*\^\s*\d+(\.\d+)?)"); // Yukarıdaki yorum satırında da dediğim gibi '^' ifadesi üs olarak algılanmıyor bu yüzden yapay zekadan o işareti Math.Pow fonksiyonuna çevirip hesaplayacağı şekilde bir kod bloğu yazmasını istedim fakat hala hata veriyor.

            while (powerRegex.IsMatch(ifade))
            {
                var match = powerRegex.Match(ifade);
                string[] parts = match.Value.Split('^');
                double baseNumber = Convert.ToDouble(parts[0]);
                double exponent = Convert.ToDouble(parts[1]);
                double powerResult = Math.Pow(baseNumber, exponent);

                ifade = ifade.Replace(match.Value, powerResult.ToString());
            }


            return ifade;
        }
        static string CarpmaBolmeCoz(string ifade)
        {
            return ifade;
        }
        static string ToplamaCıkarmaCoz(string ifade)
        {
            return ifade;
        }
    }
}
