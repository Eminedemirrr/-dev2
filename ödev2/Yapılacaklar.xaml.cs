using System.Collections.ObjectModel;
using ödev2.Models;


namespace ödev2
{


    public partial class YapilacaklarPage : ContentPage
    {
        public ObservableCollection<ToDoItem> ToDoItems { get; set; } = new ObservableCollection<ToDoItem>();

        public YapilacaklarPage()

        {
            InitializeComponent(); // Bu satırın yeri çok önemli!

            // Diğer başlatma kodları buraya gelebilir
            BindingContext = this;
        }


        private async void OnAddItemClicked(object sender, EventArgs e)
        {
            string result = await DisplayPromptAsync("Not Ekle", "Yeni bir not ekleyin:");
            if (!string.IsNullOrWhiteSpace(result))
            {
                ToDoItems.Add(new ToDoItem { Text = result, IsCompleted = false });
            }
        }

        private async void OnEditItemClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var item = button?.BindingContext as ToDoItem;

            if (item != null)
            {
                string result = await DisplayPromptAsync("Not Düzenle", "Notu düzenleyin:", initialValue: item.Text);
                if (!string.IsNullOrWhiteSpace(result))
                {
                    item.Text = result;
                }
            }
        }

        private void OnDeleteItemClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var item = button?.BindingContext as ToDoItem;

            if (item != null && ToDoItems.Contains(item))
            {
                ToDoItems.Remove(item);
            }
        }
    }
}