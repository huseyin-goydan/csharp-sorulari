// Mutlak Kare Alma
// Algoritma
// Ekrandan girilen n tane sayının 67'den küçük yada büyük olduğuna bakan. Küçük olanların farklarının toplamını, büyük ise de farkların mutlak karelerini alarak toplayıp ekrana yazdıran console uygulamasını yazınız.

// Örnek: Input: 56 45 68 77

// Output: 33 101

using System;

namespace MutlakKare
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sayıları Giriniz : ");
            string[] input = Console.ReadLine().Split(' ');
            MutlakKare mutlakKare = new MutlakKare();
            mutlakKare.Toplam(input);
        }
    }

    class MutlakKare
    {
        public void Toplam(string[] input)
        {
            int toplam = 0;
            for (int i = 0; i < input.Length; i++)
            {
                int sayi = Convert.ToInt32(input[i]);
                if (sayi < 67)
                {
                    toplam += 67 - sayi;
                }
                else
                {
                    toplam += (67 - sayi) * (67 - sayi);
                }
            }
            Console.WriteLine(toplam);
        }
    }
}