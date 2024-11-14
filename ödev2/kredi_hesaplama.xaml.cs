namespace ödev2;

public partial class Kredi_HesaplamaPage : ContentPage
{
    public Kredi_HesaplamaPage()
    {
        InitializeComponent();
    }

    private void OnHesaplaClicked(object sender, EventArgs e)
    {
        try
        {
            // Kredi Tutarı, Faiz Oranı ve Vade bilgilerini alıyoruz.
            double krediTutari = Convert.ToDouble(KrediTutariEntry.Text);
            double faizOrani = Convert.ToDouble(FaizOraniEntry.Text);
            int vade = Convert.ToInt32(VadeEntry.Text);

            // Faiz oranları (KKDF ve BSMV) belirtilmiş olduğu gibi
            double kkdf = 0.15;  // İhtiyaç kredisi için KKDF %15
            double bsmv = 0.10;  // İhtiyaç kredisi için BSMV %10
            double brutFaiz = (faizOrani + faizOrani * bsmv + faizOrani * kkdf) / 100;

            // Aylık taksit hesaplama formülü
            double aylikTaksit = (Math.Pow(1 + brutFaiz, vade) * brutFaiz) / (Math.Pow(1 + brutFaiz, vade) - 1) * krediTutari;

            // Toplam ödeme ve toplam faiz hesaplaması
            double toplamOdeme = aylikTaksit * vade;
            double toplamFaiz = toplamOdeme - krediTutari;

            // Sonuçları ekranda gösterme
            AylikTaksitLabel.Text = $"₺{aylikTaksit:F2}";
            ToplamOdemeLabel.Text = $"₺{toplamOdeme:F2}";
            ToplamFaizLabel.Text = $"₺{toplamFaiz:F2}";
        }
        catch (Exception ex)
        {
            // Hataları yakalama ve kullanıcıya bildirme
            DisplayAlert("Hata", "Lütfen geçerli bir değer giriniz.", "Tamam");
        }
    }

    private async void GoToVucutKitleIndeksiPage(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//VucutKitleIndeksiPage");
    }
}
