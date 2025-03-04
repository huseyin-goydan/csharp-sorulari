// Ortalama Hesaplama
// Ortalama Hesaplama
// Kulanıcıdan alınan derinliğe göre fibonacci serisindeki rakamların ortalamasını alıp ekrana yazdıran uygulamayı yazınız.

// Dikkat Edilmesi Gereken Noktalar :

// Kod tekrarından kaçınılmalı
// Single Responsibility kuralına uygun şekilde, uygulama sınıflara ve metotlara bölünmeli.


using System;

namespace OrtalamaHesaplama
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Derinlik Giriniz : ");
            int derinlik = Convert.ToInt32(Console.ReadLine());
            Fibonacci fibonacci = new Fibonacci();
            Console.WriteLine(fibonacci.OrtalamaHesapla(derinlik));
        }
    }

    class Fibonacci
    {
        public double OrtalamaHesapla(int derinlik)
        {
            double toplam = 0;
            for (int i = 0; i < derinlik; i++)
            {
                toplam += FibonacciHesapla(i);
            }
            return toplam / derinlik;
        }

        private double FibonacciHesapla(int n)
        {
            if (n == 0)
                return 0;
            if (n == 1)
                return 1;
            return FibonacciHesapla(n - 1) + FibonacciHesapla(n - 2);
        }
    }
}
