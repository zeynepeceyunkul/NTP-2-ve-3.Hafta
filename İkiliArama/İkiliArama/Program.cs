using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Bir dizi tam sayı girin:(virgülle ayırarak) "); // Kullanıcıdan tam sayıları alır
        string input = Console.ReadLine(); // Kullanıcının girdiği veriyi alır
        string[] parts = input.Split(',');  // Virgülle ayrılmış halde böler
        int[] numbers = Array.ConvertAll(parts, int.Parse); // String dizisini tam sayı dizisine dönüştürür


        Array.Sort(numbers); // Diziyi küçükten büyüğe doğru sıralar
        Console.WriteLine("Sıralanmış dizi: " + string.Join(", ", numbers));

        
        Console.Write("Aramak istediğiniz sayıyı girin: "); // Kullanıcıdan aranacak sayıyı alır
        int target = int.Parse(Console.ReadLine());

       
        bool found = BinarySearch(numbers, target); // İkili arama ile sayının dizide olup olmadığını kontrol eder

        // Sonucu ekrana yazdırır
        if (found)
            Console.WriteLine($"{target} dizide mevcut.");

        else
            Console.WriteLine($"{target} dizide mevcut değil.");
        Console.ReadKey();
    }

    // İkili arama algoritması ile dizide arama yapan metot
    static bool BinarySearch(int[] array, int target)
    {
        // Başlangıç ve bitiş indekslerini belirler
        int left = 0;
        int right = array.Length - 1;

        // Sol indeks sağa eşit ya da sağdan küçük olduğu sürece devam eder
        while (left <= right)
        {
            // Orta noktayı hesaplar
            int middle = (left + right) / 2;

            // Eğer orta noktadaki eleman hedef sayıya eşitse, sayıyı bulur
            if (array[middle] == target)
                return true;

            // Eğer hedef sayı ortadaki elemandan büyükse, arama aralığını sağ tarafa kaydırır
            else if (array[middle] < target)
                left = middle + 1;

            // Eğer hedef sayı ortadaki elemandan küçükse, arama aralığını sol tarafa kaydırır
            else
                right = middle - 1;
        }

        return false;
    }
}

