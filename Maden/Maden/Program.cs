using System;

class AsteroidMadenciliği
{
    static void Main(string[] args)
    {
        // Enerji maliyetlerini içeren 2D matris (örnek)
        int[,] enerjiMaliyetleri = {
            { 1, 3, 5, 8 },
            { 2, 1, 1, 6 },
            { 4, 3, 2, 4 },
            { 0, 6, 1, 2 }
        };

        int n = enerjiMaliyetleri.GetLength(0); // Matrisin boyutunu al
        int enAzEnerji = EnAzEnerjiYoluBul(enerjiMaliyetleri, n);

        Console.WriteLine("En az enerji harcayan yol için toplam enerji: " + enAzEnerji);
        Console.ReadKey();
    }

    static int EnAzEnerjiYoluBul(int[,] maliyetler, int n)
    {
        // Enerji harcamalarını saklamak için bir matris oluştur
        int[,] dp = new int[n, n];

        // Başlangıç hücresinin enerji maliyetini ayarla
        dp[0, 0] = maliyetler[0, 0];

        // İlk satır ve sütun için toplam enerji maliyetlerini hesapla
        for (int i = 1; i < n; i++)
        {
            dp[0, i] = dp[0, i - 1] + maliyetler[0, i]; // İlk satır
            dp[i, 0] = dp[i - 1, 0] + maliyetler[i, 0]; // İlk sütun
        }

        // Tüm hücreler için en az enerji maliyetlerini hesapla
        for (int i = 1; i < n; i++)
        {
            for (int j = 1; j < n; j++)
            {
                // Sağa, aşağıya ve çapraz olarak sağa aşağıya hareket edebiliriz
                dp[i, j] = Math.Min(dp[i - 1, j], Math.Min(dp[i, j - 1], dp[i - 1, j - 1])) + maliyetler[i, j];
            }
        }

        // Hedef hücreye (N-1, N-1) ulaşmak için gereken en az enerji
        return dp[n - 1, n - 1];
    }
}

