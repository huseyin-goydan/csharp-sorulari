// Alan Hesaplama
// Alan Hesaplama
// C# Console uygulaması oluşturarak aşağıdaki gereksinimleri karşılayan uygulamayı yazınız.

// İşlem yapılmak istenen geometrik şekli kullanıcıdan alınmalı (Daire, Üçgen, Kare, Dikdörtgen vb..)
// Seçilen şekle göre, kenar bilgilerin kullanıcıdan alınmalı
// Hesaplanmak istenen boyutu kullanıcıdan alınmalı (Çevre, Alan, Hacim vb..)
// Hesap sonucunu anlaşılır şekilde geri döndürmeli.
// Dikkat Edilmesi Gereken Noktalar :

// Kod tekrarından kaçınılmalı
// Single Responsibility kuralına uygun şekilde, uygulama sınıflara ve metotlara bölünmeli.

using System;

namespace AlanHesaplama
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Geometrik Şekli Seçiniz (Daire, Üçgen, Kare, Dikdörtgen): ");
            string sekil = Console.ReadLine().ToLower();

            Console.WriteLine("Hangi Hesaplama Yapılacak? (alan, çevre): ");
            string hesaplamaTuru = Console.ReadLine().ToLower();

            IHesaplayici hesaplayici = HesaplayiciFactory.SekilOlustur(sekil);
            if (hesaplayici != null)
            {
                double sonuc = hesaplayici.Hesapla(hesaplamaTuru);
                Console.WriteLine($"Hesaplanan {hesaplamaTuru}: {sonuc}");
            }
            else
            {
                Console.WriteLine("Geçersiz giriş!");
            }
        }
    }

    interface IHesaplayici
    {
        double Hesapla(string hesapTuru);
    }

    class Daire : IHesaplayici
    {
        private double yaricap;
        public Daire()
        {
            Console.Write("Yarıçap giriniz: ");
            yaricap = Convert.ToDouble(Console.ReadLine());
        }

        public double Hesapla(string hesapTuru)
        {
            if (hesapTuru == "alan")
                return Math.PI * yaricap * yaricap;
            else if (hesapTuru == "çevre")
                return 2 * Math.PI * yaricap;
            return 0;
        }
    }

    class Kare : IHesaplayici
    {
        private double kenar;
        public Kare()
        {
            Console.Write("Kenar uzunluğunu giriniz: ");
            kenar = Convert.ToDouble(Console.ReadLine());
        }

        public double Hesapla(string hesapTuru)
        {
            if (hesapTuru == "alan")
                return kenar * kenar;
            else if (hesapTuru == "çevre")
                return 4 * kenar;
            return 0;
        }
    }

    class Dikdortgen : IHesaplayici
    {
        private double uzunluk, genislik;
        public Dikdortgen()
        {
            Console.Write("Uzunluğu giriniz: ");
            uzunluk = Convert.ToDouble(Console.ReadLine());
            Console.Write("Genişliği giriniz: ");
            genislik = Convert.ToDouble(Console.ReadLine());
        }

        public double Hesapla(string hesapTuru)
        {
            if (hesapTuru == "alan")
                return uzunluk * genislik;
            else if (hesapTuru == "çevre")
                return 2 * (uzunluk + genislik);
            return 0;
        }
    }

    class Ucgen : IHesaplayici
    {
        private double taban, yukseklik, kenar1, kenar2, kenar3;
        public Ucgen()
        {
            Console.Write("Taban uzunluğunu giriniz: ");
            taban = Convert.ToDouble(Console.ReadLine());
            Console.Write("Yüksekliği giriniz: ");
            yukseklik = Convert.ToDouble(Console.ReadLine());

            Console.Write("1. Kenarı giriniz: ");
            kenar1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("2. Kenarı giriniz: ");
            kenar2 = Convert.ToDouble(Console.ReadLine());
            Console.Write("3. Kenarı giriniz: ");
            kenar3 = Convert.ToDouble(Console.ReadLine());
        }

        public double Hesapla(string hesapTuru)
        {
            if (hesapTuru == "alan")
                return (taban * yukseklik) / 2;
            else if (hesapTuru == "çevre")
                return kenar1 + kenar2 + kenar3;
            return 0;
        }
    }

    class HesaplayiciFactory
    {
        public static IHesaplayici SekilOlustur(string sekil)
        {
            switch (sekil)
            {
                case "daire": return new Daire();
                case "kare": return new Kare();
                case "dikdörtgen": return new Dikdortgen();
                case "üçgen": return new Ucgen();
                default: return null;
            }
        }
    }
}
