// Karakter Tersten Yazdırma
// Algoritma
// Verilen string ifade içerisindeki karakterleri bir önceki karakter ile yer değiştiren console uygulamasını yazınız.

// Örnek: Input: Merhaba Hello Question

// Output: erhabaM elloH uestionQ

using System;

namespace KarakterTerstenYazdirma
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("String Giriniz : ");
            string input = Console.ReadLine();
            Karakter karakter = new Karakter();
            Console.WriteLine(karakter.TerstenYaz(input));
        }
    }

    class Karakter
    {
        public string TerstenYaz(string str)
        {
            string[] kelimeler = str.Split(' '); // Cümleyi kelimelere ayır
            for (int k = 0; k < kelimeler.Length; k++)
            {
                if (kelimeler[k].Length > 1) // Eğer kelime tek harfli değilse işlem yap
                {
                    kelimeler[k] = kelimeler[k].Substring(1) + kelimeler[k][0];
                }
            }
            return string.Join(" ", kelimeler); // İşlenmiş kelimeleri birleştir
        }
    }
}
