using ECommerce_App.Model;
using ECommerce_App.Pages;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace ECommerce_App;

public partial class MainPage : ContentPage
{
    public ObservableCollection<Printer> Printers { get; set; }

    public ObservableCollection<Product>? Products { get; set; }
    public MainPage()
    {
        InitializeComponent();
        Printers = new ObservableCollection<Printer>();
        BindingContext = this;

        LoadPrintersAsync();
    }

    private async Task LoadPrintersAsync()
    {
        string apiUrl = "https://677e067b94bde1c1252a17b3.mockapi.io/api/p1/printers";

        try
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetStringAsync(apiUrl);
                var printers = JsonConvert.DeserializeObject<List<Printer>>(response);

                // Clear existing items and add fetched ones
                Printers.Clear();
                foreach (var printer in printers)
                {
                    Printers.Add(printer);
                }
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Failed to load printers: {ex.Message}", "OK");
        }
    }
    private async void OnBrowseProductsClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ProductListPage());
    }

    private async void OnSeeAllTapped(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//ProductList");
    }
}
