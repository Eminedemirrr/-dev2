using Microsoft.Maui.Controls;

namespace ödev2
{
    public partial class HesaplamaButon : ContentPage
    {
        public HesaplamaButon()
        {
            InitializeComponent();
        }

        // Button tıklama olayına bağlanan metod
        private void OnCalculateClicked(object sender, EventArgs e)
        {
            // Kredi hesaplamasını burada gerçekleştirebilirsiniz.
            // Örneğin, kredi tutarı, faiz oranı ve vade bilgilerini alıp
            // aylık taksiti hesaplayabiliriz.

            double creditAmount = double.TryParse(CreditAmountEntry.Text, out creditAmount) ? creditAmount : 0;
            double interestRate = double.TryParse(InterestRateEntry.Text, out interestRate) ? interestRate : 0;
            int term = int.TryParse(TermEntry.Text, out term) ? term : 0;

            if (creditAmount > 0 && interestRate > 0 && term > 0)
            {
                // Basit bir kredi hesaplama örneği: (Faiz oranı yıllık, aylık ödemeyi hesaplayalım)
                double monthlyInterestRate = (interestRate / 100) / 12;
                double monthlyPayment = creditAmount * monthlyInterestRate / (1 - Math.Pow(1 + monthlyInterestRate, -term));
                double totalPayment = monthlyPayment * term;
                double totalInterest = totalPayment - creditAmount;

                // Hesaplama sonuçlarını label'larda göster
                MonthlyPaymentLabel.Text = "₺" + monthlyPayment.ToString("F2");
                TotalPaymentLabel.Text = "₺" + totalPayment.ToString("F2");
                TotalInterestLabel.Text = "₺" + totalInterest.ToString("F2");
            }
            else
            {
                // Hatalı giriş durumunda etiketleri sıfırlayabilirsiniz
                MonthlyPaymentLabel.Text = "₺0.00";
                TotalPaymentLabel.Text = "₺0.00";
                TotalInterestLabel.Text = "₺0.00";
            }
        }
    }
}
