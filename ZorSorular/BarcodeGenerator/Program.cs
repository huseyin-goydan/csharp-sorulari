// Barcode Generator/Reader
// Barcode Generator/Reader
// 3rd party barcode kütüphaneleri kullanarak barcode üreten bunu client'ın bilgisayarında bir lokasyona kaydeden. Daha sonra da barcode'u okuyabilen bir console uygulaması yazınız.

// Kullanılması gereken teknikler:

// Console Application
// Import 3rd Party Library
// Dosyaya Yazma
// Dosyadan Okuma

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using ZXing;

class Program
{
    static void Main()
    {
        Console.WriteLine("Barkod Uygulaması");
        Console.WriteLine("1 - Barkod Üret");
        Console.WriteLine("2 - Barkod Oku");
        Console.Write("Seçiminizi yapınız: ");
        string secim = Console.ReadLine();

        switch (secim)
        {
            case "1":
                GenerateBarcode();
                break;
            case "2":
                ReadBarcode();
                break;
            default:
                Console.WriteLine("Geçersiz seçim!");
                break;
        }
    }

    static void GenerateBarcode()
    {
        Console.Write("Barkod için veri giriniz: ");
        string data = Console.ReadLine();
        string filePath = "barcode.png";

        BarcodeWriter writer = new BarcodeWriter
        {
            Format = BarcodeFormat.CODE_128,
            Options = new ZXing.Common.EncodingOptions
            {
                Height = 150,
                Width = 300
            }
        };

        Bitmap bitmap = writer.Write(data);
        bitmap.Save(filePath, ImageFormat.Png);

        Console.WriteLine($"Barkod oluşturuldu ve {filePath} olarak kaydedildi.");
    }

    static void ReadBarcode()
    {
        string filePath = "barcode.png";
        if (!File.Exists(filePath))
        {
            Console.WriteLine("Barkod dosyası bulunamadı!");
            return;
        }

        BarcodeReader reader = new BarcodeReader();
        Bitmap bitmap = new Bitmap(filePath);
        Result result = reader.Decode(bitmap);

        if (result != null)
        {
            Console.WriteLine($"Barkod Verisi: {result.Text}");
        }
        else
        {
            Console.WriteLine("Barkod okunamadı!");
        }
    }
}
