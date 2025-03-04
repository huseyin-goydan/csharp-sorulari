// ATM Uygulaması
// ATM uygulaması
// Uygulama ilk çalıştığında kullanıcıdan yamak istediği işlemi öğrenmelidir. Bunlar ATM üzerinden yapılabilecek temem işlemledir. Para çekme, para yatırma, ödeme yapma vs.. İsteğe bağlı olarak genişletilebilir. Öncelikle ATM ye giriş yapan kullanıcın sistemde kayıtlı bir kullanıcı olduğundan emin olunmalıdır.

// Uygulamada bir de gün sonu seçeneği olmalıdır. Gün sonu alınmak istendiğinde, gün içerisinde yapılan transaction ların logları ve fraud olabilecek yani hatalı giriş denemeleri log gösterilmelidir. Aynı client'ın bilgisayarında belirlenen bir lokasyona EOD_Tarih(DDMMYYY formatında).txt adında bir dosyaya yazılmalıdır.

// Kullanılması gereken teknikler:

// Dosyaya Yazma
// Dosyadan Okuma
// İşlem listesi pre-defined olarak kullanılabilir.

using System;
using System.Collections.Generic;
using System.IO;

namespace ATMApp
{
    class Program
    {
        static Dictionary<string, string> users = new Dictionary<string, string>()
        {
            { "ahmet", "1234" },
            { "mehmet", "5678" }
        };

        static Dictionary<string, decimal> balances = new Dictionary<string, decimal>()
        {
            { "ahmet", 1000 },
            { "mehmet", 2000 }
        };

        static List<string> transactionLogs = new List<string>();
        static List<string> fraudLogs = new List<string>();

        static void Main(string[] args)
        {
            Console.WriteLine("-- ATM Uygulamasına Hoş Geldiniz --");

            string currentUser = Login();
            if (currentUser == null)
            {
                Console.WriteLine("Çok fazla hatalı giriş! ATM kapatılıyor.");
                return;
            }

            while (true)
            {
                Console.WriteLine("\n İşlemler:");
                Console.WriteLine("1 - Para Çekme");
                Console.WriteLine("2 - Para Yatırma");
                Console.WriteLine("3 - Ödeme Yap");
                Console.WriteLine("4 - Gün Sonu (EOD)");
                Console.WriteLine("5 - Çıkış");

                Console.Write("Seçiminizi yapınız: ");
                string secim = Console.ReadLine();

                switch (secim)
                {
                    case "1":
                        Withdraw(currentUser);
                        break;
                    case "2":
                        Deposit(currentUser);
                        break;
                    case "3":
                        Payment(currentUser);
                        break;
                    case "4":
                        EndOfDay();
                        return;
                    case "5":
                        Console.WriteLine("Çıkış yapılıyor...");
                        return;
                    default:
                        Console.WriteLine("Geçersiz seçim!");
                        break;
                }
            }
        }

        static string Login()
        {
            int wrongAttempts = 0;
            while (wrongAttempts < 3)
            {
                Console.Write("\nKullanıcı Adınızı Giriniz: ");
                string username = Console.ReadLine();

                Console.Write("Şifrenizi Giriniz: ");
                string password = Console.ReadLine();

                if (users.ContainsKey(username) && users[username] == password)
                {
                    Console.WriteLine($"Giriş Başarılı! Hoş geldiniz, {username}.");
                    return username;
                }

                wrongAttempts++;
                Console.WriteLine("Hatalı giriş! Tekrar deneyin.");

                fraudLogs.Add($"{DateTime.Now} - Fraud Giriş: Kullanıcı {username}");
            }
            return null;
        }

        static void Withdraw(string user)
        {
            Console.Write("Çekmek istediğiniz miktarı giriniz: ");
            decimal amount = Convert.ToDecimal(Console.ReadLine());

            if (amount > balances[user])
            {
                Console.WriteLine("Yetersiz bakiye!");
                return;
            }

            balances[user] -= amount;
            string log = $"{DateTime.Now} - {user} {amount} TL çekti. Kalan Bakiye: {balances[user]} TL";
            transactionLogs.Add(log);
            Console.WriteLine($"Para çekme işlemi başarılı. Kalan Bakiye: {balances[user]} TL");
        }

        static void Deposit(string user)
        {
            Console.Write("Yatırmak istediğiniz miktarı giriniz: ");
            decimal amount = Convert.ToDecimal(Console.ReadLine());

            balances[user] += amount;
            string log = $"{DateTime.Now} - {user} {amount} TL yatırdı. Yeni Bakiye: {balances[user]} TL";
            transactionLogs.Add(log);
            Console.WriteLine($"Para yatırma işlemi başarılı. Yeni Bakiye: {balances[user]} TL");
        }

        static void Payment(string user)
        {
            Console.Write("Ödeme yapmak istediğiniz miktarı giriniz: ");
            decimal amount = Convert.ToDecimal(Console.ReadLine());

            if (amount > balances[user])
            {
                Console.WriteLine("Yetersiz bakiye!");
                return;
            }

            balances[user] -= amount;
            string log = $"{DateTime.Now} - {user} {amount} TL ödeme yaptı. Kalan Bakiye: {balances[user]} TL";
            transactionLogs.Add(log);
            Console.WriteLine($"Ödeme işlemi başarılı. Kalan Bakiye: {balances[user]} TL");
        }

        static void EndOfDay()
        {
            string fileName = $"EOD_{DateTime.Now:ddMMyyyy}.txt";
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.WriteLine("Gün Sonu (EOD) Raporu\n");

                writer.WriteLine("İşlem Logları:");
                foreach (var log in transactionLogs)
                {
                    writer.WriteLine(log);
                }

                writer.WriteLine("\nFraud (Hatalı Giriş) Logları:");
                foreach (var log in fraudLogs)
                {
                    writer.WriteLine(log);
                }
            }

            Console.WriteLine($"Gün sonu raporu oluşturuldu: {fileName}");
        }
    }
}
