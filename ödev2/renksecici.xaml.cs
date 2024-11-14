using System;
using Microsoft.Maui.Controls;

namespace ödev2
{
    public partial class RenkSeciciPage : ContentPage
    {
        public RenkSeciciPage()
        {
            InitializeComponent();
            UpdateColor(); // Varsayılan renk için güncelleme
        }

        // Slider değerleri değiştiğinde çağrılan metod
        private void OnColorSliderChanged(object sender, ValueChangedEventArgs e)
        {
            UpdateColor();
        }

        // Renk güncelleme metodu
        private void UpdateColor()
        {
            // Slider değerlerini al
            int red = (int)RedSlider.Value;
            int green = (int)GreenSlider.Value;
            int blue = (int)BlueSlider.Value;

            // Hexadecimal renk kodunu oluştur
            string hexColor = $"#{red:X2}{green:X2}{blue:X2}";
            ColorCodeEntry.Text = hexColor;

            // BoxView arka plan rengini güncelle
            ColorPreview.Color = Color.FromRgb(red, green, blue);
        }

        // Renk kodunu kopyalama
        private async void OnCopyColorCodeClicked(object sender, EventArgs e)
        {
            await Clipboard.SetTextAsync(ColorCodeEntry.Text);
            await DisplayAlert("Kopyalandı", $"{ColorCodeEntry.Text} kopyalandı!", "OK");
        }

        // Rastgele renk oluşturma
        private void OnRandomColorClicked(object sender, EventArgs e)
        {
            var random = new Random();
            RedSlider.Value = random.Next(0, 256);
            GreenSlider.Value = random.Next(0, 256);
            BlueSlider.Value = random.Next(0, 256);
        }
    }
}