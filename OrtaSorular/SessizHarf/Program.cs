// Sessiz Harf
// Algoritma
// Verilen string ifade içerisinde yanyana 2 tane sessiz varsa ekrana true, yoksa false yazdıran console uygulamasını yazınız.

// Örnek: Input: Merhaba Umut Arya

// Output: True False True


using System;

namespace SessizHarf
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("String Giriniz : ");
            string input = Console.ReadLine();
            Sessiz sessiz = new Sessiz();
            Console.WriteLine(sessiz.Harf(input));
        }
    }

    class Sessiz
    {
        public string Harf(string str)
        {
            for (int i = 0; i < str.Length - 1; i++)
            {
                if (SessizHarf(str[i]) && SessizHarf(str[i + 1]))
                {
                    return "True";
                }
            }
            return "False";
        }

        public bool SessizHarf(char c)
        {
            return "bcdfghjklmnpqrstvwxyz".Contains(c.ToString().ToLower());
        }
    }
}