// Voting Uygulaması
// Voting Uygulaması
// Uygulama çalıştığında pre-defined olarak belirlenen kategoriler oylamaya sunulmak üzere listelenmelidir. Yalnızca sisemde kayırlı olan kullanıcılar oy verebilir. Oylama sırasında öncelikle kullanıcının username'i istenmelidir. Eğer sistemde kayıtlı değilse kayıt olmasına imkan sağlanmalı ve kaldığı yerden oylamaya devam edebilmelidir. Kategoriler isteğe bağlı olarak belirlenebilir.

// Bazı Örnek Kategoriler: Film Kategorileri Tech Stack Kategorileri Spor Kategorileri

// Son olarak uygulama sonlandırılırken, Voting sonuçları hem rakamsal hem de yüzdesel olarak gösterilmelidir.

// Kullanılması gereken teknikler:

// Kategoriler pre-defined kullanılabilir.


using System;
using System.Collections.Generic;
using System.Linq;

namespace VotingApp
{
    class Program
    {
        static Dictionary<string, int> categories = new Dictionary<string, int>()
        {
            { "Film", 0 },
            { "Teknoloji", 0 },
            { "Spor", 0 }
        };

        static HashSet<string> registeredUsers = new HashSet<string>();
        static Dictionary<string, string> userVotes = new Dictionary<string, string>();

        static void Main(string[] args)
        {
            Console.WriteLine("⚡ Voting Uygulamasına Hoş Geldiniz! ⚡");

            while (true)
            {
                Console.Write("\nKullanıcı adınızı giriniz: ");
                string username = Console.ReadLine().Trim();

                if (!registeredUsers.Contains(username))
                {
                    Console.WriteLine("Kullanıcı bulunamadı! Kayıt oluşturuluyor...");
                    registeredUsers.Add(username);
                }

                if (userVotes.ContainsKey(username))
                {
                    Console.WriteLine("Zaten oy verdiniz! Tekrar oy kullanamazsınız.");
                    continue;
                }

                Console.WriteLine("\n📌 Kategoriler:");
                foreach (var category in categories.Keys)
                {
                    Console.WriteLine($"- {category}");
                }

                Console.Write("\nOy vermek istediğiniz kategoriyi seçiniz: ");
                string vote = Console.ReadLine().Trim();

                if (categories.ContainsKey(vote))
                {
                    categories[vote]++;
                    userVotes[username] = vote;
                    Console.WriteLine($"✅ {username} adlı kullanıcı, {vote} kategorisine oy verdi!\n");
                }
                else
                {
                    Console.WriteLine("❌ Hatalı kategori seçimi! Tekrar deneyin.\n");
                }

                Console.Write("Başka bir kullanıcı oy vermek ister mi? (E/H): ");
                string devam = Console.ReadLine().Trim().ToUpper();
                if (devam != "E")
                {
                    break;
                }
            }

            ShowResults();
        }

        static void ShowResults()
        {
            int totalVotes = categories.Values.Sum();

            Console.WriteLine("\n📊 Oylama Sonuçları:");
            foreach (var category in categories)
            {
                double percentage = (totalVotes == 0) ? 0 : ((double)category.Value / totalVotes) * 100;
                Console.WriteLine($"- {category.Key}: {category.Value} oy (%{percentage:F2})");
            }
        }
    }
}
