using ECommerce_App.Model;
using ECommerce_App.ViewModel;
using System.Collections.ObjectModel;
using System.Net.Http.Json;

namespace ECommerce_App.Pages;

public partial class ProductListPage : ContentPage
{
    public ObservableCollection<Printer> Printers { get; set; } = new();

    public ProductListPage()
	{
		InitializeComponent();
        BindingContext = this;
        LoadPrintersForProduct();
    }

    private async void LoadPrintersForProduct()
    {
        try
        {
            using HttpClient client = new();
            var printers = await client.GetFromJsonAsync<List<Printer>>("https://677e067b94bde1c1252a17b3.mockapi.io/api/p1/printers/");
            if (printers != null)
            {
                Printers.Clear();
                foreach (var printer in printers)
                {
                    Printers.Add(printer);
                }
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Failed to fetch data: {ex.Message}", "OK");
        }
    }

    private async void OnProductClicked(object sender, EventArgs e)
    {
        Button button = sender as Button;
        if (button?.BindingContext is Printer selectedPrinter)
        {
            var cardViewModel = new CardViewModel(); // Create the CardViewModel instance here
            await Navigation.PushAsync(new ProductDetailsPage(selectedPrinter, cardViewModel));
        }
    }
    private void OnSearchBarTextChanged(object sender, TextChangedEventArgs e)
    {
        var searchTerm = e.NewTextValue?.ToLower() ?? string.Empty;

        if (string.IsNullOrEmpty(searchTerm))
        {
            LoadPrintersForProduct();
        }
        else
        {
            var filteredPrinters = Printers.Where(p =>
                p.Name.ToLower().Contains(searchTerm) ||
                p.Description.ToLower().Contains(searchTerm)).ToList();

            Printers.Clear();
            foreach (var printer in filteredPrinters)
            {
                Printers.Add(printer);
            }
        }
    }
    private async void OnBackProductButton(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//MainPage");
    }

}