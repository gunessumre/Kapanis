using System;

public abstract class BaseMakine
{
    public DateTime UretimTarihi { get; set; }
    public string SeriNo { get; set; }
    public string UrunAdi { get; set; }
    public string Aciklama { get; set; }
    public string IsletimSistemi { get; set; }

    public BaseMakine()
    {
        UretimTarihi = DateTime.Now; // Üretim tarihi otomatik olarak atanır.
    }

    public void BilgileriYazdir()
    {
        Console.WriteLine($"Ürün Adı: {UrunAdi}");
        Console.WriteLine($"Üretim Tarihi: {UretimTarihi}");
        Console.WriteLine($"Seri Numarası: {SeriNo}");
        Console.WriteLine($"Açıklama: {Aciklama}");
        Console.WriteLine($"İşletim Sistemi: {IsletimSistemi}");
    }

    public abstract void UrunAdiGetir(); // Soyut metot
}

public class Telefon : BaseMakine
{
    public bool TrLisansliMi { get; set; }

    public Telefon()
    {
        UrunAdi = "Telefon"; // Telefon adı sabit
    }

    public override void UrunAdiGetir()
    {
        Console.WriteLine($"Telefonunuzun adı ---> {UrunAdi}");
    }
}

public class Bilgisayar : BaseMakine
{
    public int UsbGirisSayisi { get; set; }
    public bool BluetoothVarMi { get; set; }

    public Bilgisayar()
    {
        UrunAdi = "Bilgisayar"; // Bilgisayar adı sabit
    }

    public override void UrunAdiGetir()
    {
        Console.WriteLine($"Bilgisayarınızın adı ---> {UrunAdi}");
    }

    // Kapsülleme: Usb giriş sayısı için doğrulama
    public void SetUsbGirisSayisi(int usbSayisi)
    {
        if (usbSayisi == 2 || usbSayisi == 4)
        {
            UsbGirisSayisi = usbSayisi;
        }
        else
        {
            Console.WriteLine("Geçersiz USB giriş sayısı! Değer -1 atanıyor.");
            UsbGirisSayisi = -1;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Telefon üretmek için 1, Bilgisayar üretmek için 2'ye basınız.");
            string secim = Console.ReadLine();

            if (secim == "1")
            {
                Telefon telefon = new Telefon();
                Console.WriteLine("Telefonun seri numarasını giriniz:");
                telefon.SeriNo = Console.ReadLine();
                Console.WriteLine("Telefonun açıklamasını giriniz:");
                telefon.Aciklama = Console.ReadLine();
                Console.WriteLine("Telefonun işletim sistemini giriniz:");
                telefon.IsletimSistemi = Console.ReadLine();
                Console.WriteLine("Telefonunuz Türkiye lisanslı mı? (Evet/Hayır)");
                telefon.TrLisansliMi = Console.ReadLine().ToLower() == "evet";
                telefon.BilgileriYazdir();
                telefon.UrunAdiGetir();
            }
            else if (secim == "2")
            {
                Bilgisayar bilgisayar = new Bilgisayar();
                Console.WriteLine("Bilgisayarın seri numarasını giriniz:");
                bilgisayar.SeriNo = Console.ReadLine();
                Console.WriteLine("Bilgisayarın açıklamasını giriniz:");
                bilgisayar.Aciklama = Console.ReadLine();
                Console.WriteLine("Bilgisayarın işletim sistemini giriniz:");
                bilgisayar.IsletimSistemi = Console.ReadLine();
                Console.WriteLine("Bilgisayarın USB giriş sayısını giriniz (2 veya 4):");
                int usbSayisi = int.Parse(Console.ReadLine());
                bilgisayar.SetUsbGirisSayisi(usbSayisi);
                Console.WriteLine("Bilgisayarınızda Bluetooth var mı? (Evet/Hayır)");
                bilgisayar.BluetoothVarMi = Console.ReadLine().ToLower() == "evet";
                bilgisayar.BilgileriYazdir();
                bilgisayar.UrunAdiGetir();
            }
            else
            {
                Console.WriteLine("Geçersiz seçim! Lütfen tekrar deneyin.");
                continue;
            }

            Console.WriteLine("Başka bir ürün üretmek ister misiniz? (Evet/Hayır)");
            string devam = Console.ReadLine().ToLower();
            if (devam == "hayır")
            {
                Console.WriteLine("İyi günler!");
                break;
            }
        }
    }
}