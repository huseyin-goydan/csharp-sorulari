// Karakter Değiştirme
// Algoritma
// Verilen string ifade içerisindeki ilk ve son karakterin yerini değiştirip tekrar ekrana yazdıran console uygulamasını yazınız.

// Örnek: Input: Merhaba Hello Algoritma x

// Output: aerhabM oellH algoritmA x


using System;

namespace KarakterDegistirme
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("String Giriniz : ");
            string input = Console.ReadLine();
            Karakter karakter = new Karakter();
            Console.WriteLine(karakter.Degistir(input));
        }
    }

    class Karakter
    {
        public string Degistir(string str)
        {
            if (str.Length > 1)
            {
                return str[str.Length - 1] + str.Substring(1, str.Length - 2) + str[0];
            }
            return str;
        }
    }
}