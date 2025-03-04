// Algoritma
// Algoritma
// Ekrandan girilen n tane integer ikililerin toplamını alan, eğer sayılar birbirinden farklıysa toplamlarını ekrana yazdıran, sayılar aynıysa toplamının karesini ekrana yazdıran console uygulamasını yazınız.

// Örnek Input: 2 3 1 5 2 5 3 3

// Output: 5 6 7 81


using System;

namespace Algoritma
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sayıları Giriniz : ");
            string[] input = Console.ReadLine().Split(' ');
            Algoritma algoritma = new Algoritma();
            algoritma.Toplam(input);
        }
    }

    class Algoritma
    {
        public void Toplam(string[] input)
        {
            for (int i = 0; i < input.Length; i += 2)
            {
                int sayi1 = Convert.ToInt32(input[i]);
                int sayi2 = Convert.ToInt32(input[i + 1]);
                if (sayi1 == sayi2)
                {
                    Console.Write(sayi1 * sayi2 + " ");
                }
                else
                {
                    Console.Write(sayi1 + sayi2 + " ");
                }
            }
        }
    }
}