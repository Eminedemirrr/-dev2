namespace ödev2;

public partial class vücutkitleindeksi: ContentPage
{
    public vücutkitleindeksi()
    {
        InitializeComponent();
        UpdateVki();
    }

    private void OnValueChanged(object sender, ValueChangedEventArgs e)
    {
        UpdateVki();
    }

    private void UpdateVki()
    {
        double kilo = KiloSlider.Value;
        double boy = BoySlider.Value / 100; // cm'yi metreye çeviriyoruz

        // VKİ hesaplama
        double vki = kilo / (boy * boy);
        VkiLabel.Text = vki.ToString("F2");

        // VKİ değerlendirme
        string durum = GetVkiDurumu(vki);
        VkiDurumuLabel.Text = durum;

        // Duruma göre renk değişimi
        VkiDurumuLabel.TextColor = durum.Contains("Obez") ? Colors.Red : Colors.Green;
    }

    private string GetVkiDurumu(double vki)
    {
        if (vki < 16)
            return "İleri Düzeyde Zayıf";
        else if (vki < 16.99)
            return "Orta Düzeyde Zayıf";
        else if (vki < 18.49)
            return "Hafif Düzeyde Zayıf";
        else if (vki < 24.99)
            return "Normal Kilolu";
        else if (vki < 29.99)
            return "Hafif Şiman / Fazla Kilolu";
        else if (vki < 34.99)
            return "1. Derecede Obez";
        else if (vki < 39.99)
            return "2. Derecede Obez";
        else
            return "3. Derecede Obez / Morbid Obez";
    }
}