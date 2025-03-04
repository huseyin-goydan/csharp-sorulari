// Algoritma
// Algoritma
// Ekrandan bir string bir de sayı alan (aralarında virgül ile), ilgili string ifade içerisinden verilen indexteki karakteri çıkartıp ekrana yazdıran console uygulasını yazınız.

// Örnek: Input: Algoritma,3 Algoritma,5 Algoritma,22 Algoritma,0

// Output: Algritma Algortma Algoritma lgoritma

using System;

namespace Algoritma
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("String ve Index Giriniz : ");
            string[] input = Console.ReadLine().Split(',');
            Algoritma algoritma = new Algoritma();
            Console.WriteLine(algoritma.Cikar(input[0], Convert.ToInt32(input[1])));
        }
    }

    class Algoritma
    {
        public string Cikar(string str, int index)
        {
            return str.Remove(index, 1);
        }
    }
}