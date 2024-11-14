namespace ödev2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        // Kredi Hesaplama sayfasına geçiş
        private async void OnKrediHesaplamaClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Kredi_HesaplamaPage());
        }

        // Vücut Kitle İndeksi sayfasına geçiş
        private async void OnVkiClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new vücutkitleindeksi());
        }

        // Renk Seçici sayfasına geçiş
        private async void OnRenkSeciciClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RenkSeciciPage());
        }

        // Yapılacaklar sayfasına geçiş
        private async void OnYapilacaklarClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new YapilacaklarPage());
        }
    }
}