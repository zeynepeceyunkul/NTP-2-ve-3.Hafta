using System;

class Labirent
{
    static int[] dX = { 0, 1, 0, -1 };
    static int[] dY = { 1, 0, -1, 0 };
    static int M = 5; // Labirent satır boyutu
    static int N = 5; // Labirent sütun boyutu
    static int[,] yolHaritasiX = new int[M, N]; // Önceki adımlar için X koordinatları
    static int[,] yolHaritasiY = new int[M, N]; // Önceki adımlar için Y koordinatları
    static bool[,] ziyaretEdildi = new bool[M, N]; // Ziyaret edilen hücreleri takip etmek için

    public static void Main()
    {
        if (YolBul(0, 0, M - 1, N - 1))
        {
            Console.WriteLine("Şehre giden yol:");
            int x = M - 1, y = N - 1;
            while (x != 0 || y != 0)
            {
                Console.WriteLine($"({x}, {y})");
                int oncekiX = yolHaritasiX[x, y];
                int oncekiY = yolHaritasiY[x, y];
                x = oncekiX;
                y = oncekiY;
            }
            Console.WriteLine("(0, 0)"); // Başlangıç noktasını ekle
            
        }
        else
        {
            Console.WriteLine("Şehir kayboldu!");

            
        }
        Console.ReadKey();

    }

    static bool YolBul(int startX, int startY, int hedefX, int hedefY)
    {
        // Kuyruk işlemi için sabit boyutlu dizi ve işaretçiler
        int[,] kuyrukX = new int[M * N, 1];
        int[,] kuyrukY = new int[M * N, 1];
        int bas = 0, son = 0;

        kuyrukX[son, 0] = startX;
        kuyrukY[son++, 0] = startY;
        ziyaretEdildi[startX, startY] = true;

        while (bas < son)
        {
            int x = kuyrukX[bas, 0];
            int y = kuyrukY[bas++, 0];

            if (x == hedefX && y == hedefY)
                return true; // Hedefe ulaşıldıysa yol bulundu

            for (int i = 0; i < 4; i++)
            {
                int yeniX = x + dX[i];
                int yeniY = y + dY[i];

                if (GecerliMi(yeniX, yeniY) && !ziyaretEdildi[yeniX, yeniY] && KapıAçılabilirMi(yeniX, yeniY))
                {
                    ziyaretEdildi[yeniX, yeniY] = true;
                    yolHaritasiX[yeniX, yeniY] = x; // Yol haritasına önceki X koordinatını ekle
                    yolHaritasiY[yeniX, yeniY] = y; // Yol haritasına önceki Y koordinatını ekle
                    kuyrukX[son, 0] = yeniX;
                    kuyrukY[son++, 0] = yeniY;
                }
            }
        }

        return false; // Yol bulunamazsa false döndür
    }

    // Hücrenin koordinatlarının geçerli olup olmadığını kontrol eden fonksiyon
    static bool GecerliMi(int x, int y)
    {
        return x >= 0 && x < M && y >= 0 && y < N;
    }

    // Kapının açılabilir olup olmadığını kontrol eden fonksiyon
    static bool KapıAçılabilirMi(int x, int y)
    {
        if (!BasamaklarAsalMi(x) || !BasamaklarAsalMi(y))
            return false;

        int toplam = x + y;
        int carpim = x * y;
        return carpim != 0 && toplam % carpim == 0;
    }

    // Her iki basamağın asal sayı olup olmadığını kontrol eden fonksiyon
    static bool BasamaklarAsalMi(int sayi)
    {
        int birlerBasamagi = sayi % 10;
        int onlarBasamagi = sayi / 10;
        return AsalMi(birlerBasamagi) && AsalMi(onlarBasamagi);
    }

    // Asal sayı kontrolü
    static bool AsalMi(int sayi)
    {
        return sayi == 2 || sayi == 3 || sayi == 5 || sayi == 7;
    }
}
