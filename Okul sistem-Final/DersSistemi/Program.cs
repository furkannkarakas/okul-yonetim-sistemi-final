using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class Program
{
    private static readonly string ProjectRoot = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));
    private static readonly string DerslerFile = Path.Combine(ProjectRoot, "Dersler.json");
    private static readonly string OgrencilerFile = Path.Combine(ProjectRoot, "Ogrenciler.json");
    private static readonly string OgretimGorevlileriFile = Path.Combine(ProjectRoot, "OgretimGorevlileri.json");

    static void Main(string[] args)
    {
        InitializeFiles();
        ornekVerileriEkle();
        while (true)
        {
            Console.WriteLine("1. Öğrenci Ekle");
            Console.WriteLine("2. Öğretim Görevlisi Ekle");
            Console.WriteLine("3. Ders Ekle");
            Console.WriteLine("4. Ders Kayıt");
            Console.WriteLine("5. Bilgileri Göster");
            Console.WriteLine("6. Çıkış");
            Console.Write("Seçiminiz: ");
            var secim = Console.ReadLine();

            switch (secim)
            {
                case "1":
                    OgrenciEkle();
                    break;
                case "2":
                    OgretimGorevlisiEkle();
                    break;
                case "3":
                    DersEkle();
                    break;
                case "4":
                    DersKayit();
                    break;
                case "5":
                    BilgileriGoster();
                    break;
                case "6":
                    Console.WriteLine("Çıkış yapılıyor...");
                    return;
                default:
                    Console.WriteLine("Geçersiz seçim!");
                    break;
            }
        }
    }

    static void InitializeFiles()
    {
        if (!File.Exists(DerslerFile)) File.WriteAllText(DerslerFile, "[]");
        if (!File.Exists(OgrencilerFile)) File.WriteAllText(OgrencilerFile, "[]");
        if (!File.Exists(OgretimGorevlileriFile)) File.WriteAllText(OgretimGorevlileriFile, "[]");
    }

    static List<T> LoadData<T>(string fileName)
    {
        var json = File.ReadAllText(fileName);
        return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
    }

    static void SaveData<T>(string fileName, List<T> data)
    {
        var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(fileName, json);
    }

    static void OgrenciEkle()
    {
        var ogrenciler = LoadData<Ogrenci>(OgrencilerFile);
        var ogrenci = new Ogrenci();
        Console.Write("Öğrenci Adı: ");
        ogrenci.Isim = Console.ReadLine();
        Console.Write("Öğrenci Numarası: ");
        ogrenci.OgrenciNo = Console.ReadLine();
        ogrenciler.Add(ogrenci);
        SaveData(OgrencilerFile, ogrenciler);
    }

    static void OgretimGorevlisiEkle()
    {
        var ogretimGorevlileri = LoadData<OgretimGorevlisi>(OgretimGorevlileriFile);
        var ogretimGorevlisi = new OgretimGorevlisi();
        Console.Write("Öğretim Görevlisi Adı: ");
        ogretimGorevlisi.Isim = Console.ReadLine();
        Console.Write("Bölüm: ");
        ogretimGorevlisi.Bolum = Console.ReadLine();
        ogretimGorevlileri.Add(ogretimGorevlisi);
        SaveData(OgretimGorevlileriFile, ogretimGorevlileri);
    }

    static void DersEkle()
    {
        var dersler = LoadData<Ders>(DerslerFile);
        var ogretimGorevlileri = LoadData<OgretimGorevlisi>(OgretimGorevlileriFile);

        var ders = new Ders();
        Console.Write("Ders Adı: ");
        ders.DersAdi = Console.ReadLine();
        Console.Write("Kredi: ");
        ders.Kredi = int.Parse(Console.ReadLine());

        Console.WriteLine("Öğretim Görevlileri:");
        for (int i = 0; i < ogretimGorevlileri.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {ogretimGorevlileri[i].Isim}");
        }
        Console.Write("Öğretim Görevlisi Numarasını Seçiniz: ");
        var ogretimGorevlisiIndex = int.Parse(Console.ReadLine()) - 1;
        ders.OgretimGorevlisi = ogretimGorevlileri[ogretimGorevlisiIndex];
        dersler.Add(ders);

        SaveData(DerslerFile, dersler);
    }

    static void DersKayit()
    {
        var ogrenciler = LoadData<Ogrenci>(OgrencilerFile);
        var dersler = LoadData<Ders>(DerslerFile);

        Console.WriteLine("Öğrenciler:");
        for (int i = 0; i < ogrenciler.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {ogrenciler[i].Isim}");
        }
        Console.Write("Öğrenci Numarasını Seçiniz: ");
        var ogrenciIndex = int.Parse(Console.ReadLine()) - 1;

        Console.WriteLine("Dersler:");
        for (int i = 0; i < dersler.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {dersler[i].DersAdi}");
        }
        Console.Write("Ders Numarasını Seçiniz: ");
        var dersIndex = int.Parse(Console.ReadLine()) - 1;

        dersler[dersIndex].OgrenciKaydet(ogrenciler[ogrenciIndex]);
        SaveData(DerslerFile, dersler);
    }

    static void BilgileriGoster()
    {
        Console.WriteLine("Bilgi türünü seçiniz:");
        Console.WriteLine("1. Öğrenci");
        Console.WriteLine("2. Öğretim Görevlisi");
        Console.WriteLine("3. Ders");

        var secim = Console.ReadLine();
        switch (secim)
        {
            case "1":
                foreach (var ogrenci in LoadData<Ogrenci>(OgrencilerFile))
                {
                    ogrenci.BilgiGoster();
                    Console.WriteLine("--------------------");
                }
                break;
            case "2":
                foreach (var ogretimGorevlisi in LoadData<OgretimGorevlisi>(OgretimGorevlileriFile))
                {
                    ogretimGorevlisi.BilgiGoster();
                    Console.WriteLine("--------------------");
                }
                break;
            case "3":
                foreach (var ders in LoadData<Ders>(DerslerFile))
                {
                    ders.BilgiGoster();
                    Console.WriteLine("--------------------");
                }
                break;
            default:
                Console.WriteLine("Geçersiz seçim!");
                break;
        }
    }

    static void ornekVerileriEkle()
    {
        var ogrenciler = LoadData<Ogrenci>(OgrencilerFile);
        var ogretimGorevlileri = LoadData<OgretimGorevlisi>(OgretimGorevlileriFile);
        var dersler = LoadData<Ders>(DerslerFile);

        if (ogrenciler.Count == 0 && ogretimGorevlileri.Count == 0 && dersler.Count == 0)
        {
            ogrenciler.Add(new Ogrenci { Isim = "Furkan", OgrenciNo = "13" });
            ogrenciler.Add(new Ogrenci { Isim = "Arda ", OgrenciNo = "2" });

            ogretimGorevlileri.Add(new OgretimGorevlisi { Isim = "erkan aydın", Bolum = "Bilgisayar Mühendisliği" });
            ogretimGorevlileri.Add(new OgretimGorevlisi { Isim = "Refik tanju sirmen ", Bolum = "programlama" });

            var ders1 = new Ders { DersAdi = "Programlama 1", Kredi = 3, OgretimGorevlisi = ogretimGorevlileri[0] };
            var ders2 = new Ders { DersAdi = "Veri analitiği", Kredi = 4, OgretimGorevlisi = ogretimGorevlileri[1] };

            ders1.OgrenciKaydet(ogrenciler[0]);
            ders2.OgrenciKaydet(ogrenciler[1]);

            dersler.Add(ders1);
            dersler.Add(ders2);

            SaveData(OgrencilerFile, ogrenciler);
            SaveData(OgretimGorevlileriFile, ogretimGorevlileri);
            SaveData(DerslerFile, dersler);
        }
    }
}