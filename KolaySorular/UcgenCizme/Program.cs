// Üçgen Çizme
// Algoritma
// Kullanıcıdan alınan boyut bilgisine göre console'a Üçgen çizen uygulamayı yazınız.

// Dikkat Edilmesi Gereken Noktalar :

// Kod tekrarından kaçınılmalı
// Single Responsibility kuralına uygun şekilde, uygulama sınıflara ve metotlara bölünmeli.

using System;

namespace UcgenCizme
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Boyut Giriniz : ");
            int boyut = Convert.ToInt32(Console.ReadLine());
            Ucgen ucgen = new Ucgen();
            ucgen.Ciz(boyut);
        }
    }

    class Ucgen
    {
        public void Ciz(int boyut)
        {
            for (int i = 0; i < boyut; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
    }
}