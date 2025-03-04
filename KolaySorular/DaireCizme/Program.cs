// Daire Çizme
// Şekil Çizimi
// Kullanıcıdan alınan yarıçapa göre console'a Daire çizen uygulamayı yazınız.

// Dikkat Edilmesi Gereken Noktalar :

// Kod tekrarından kaçınılmalı
// Single Responsibility kuralına uygun şekilde, uygulama sınıflara ve metotlara bölünmeli.

using System;

namespace DaireCizme
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Yarıçap Giriniz : ");
            int yaricap = Convert.ToInt32(Console.ReadLine());
            Daire daire = new Daire();
            daire.Ciz(yaricap);
        }
    }

    class Daire
    {
        public void Ciz(int yaricap)
        {
            for (int i = 0; i <= 2 * yaricap; i++)
            {
                for (int j = 0; j <= 2 * yaricap; j++)
                {
                    if (Math.Pow(i - yaricap, 2) + Math.Pow(j - yaricap, 2) <= Math.Pow(yaricap, 2))
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}