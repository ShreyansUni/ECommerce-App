using ECommerce_App.Model;
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
        LoadPrinters();
    }

    private async void LoadPrinters()
    {
        try
        {
            using HttpClient client = new();
            var printers = await client.GetFromJsonAsync<List<Printer>>("https://677e067b94bde1c1252a17b3.mockapi.io/api/p1/printers/");
            foreach (var printer in printers)
            {
                Printers.Add(printer);
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }
    }

    private async void OnProductClicked(object sender, EventArgs e)
    {
        Button button = sender as Button;
        Printer selectedPrinter = button?.BindingContext as Printer;
        if (selectedPrinter != null)
        {
            await Navigation.PushAsync(new ProductDetailsPage(selectedPrinter));
        }
    }

    //private void OnSearchBarTextChanged(object sender, TextChangedEventArgs e)
    //{
    //    var searchTerm = e.NewTextValue?.ToLower() ?? string.Empty;

    //    // Filter Printers
    //    var filteredPrinters = Printers.Where(p => p.name.ToLower().Contains(searchTerm) || p.Description.ToLower().Contains(searchTerm)).ToList();

    //    // Update the ObservableCollection
    //    Printers.Clear();
    //    foreach (var printer in filteredPrinters)
    //    {
    //        Printers.Add(printer);
    //    }
    //}
    private void OnSearchBarTextChanged(object sender, TextChangedEventArgs e)
    {
        var searchTerm = e.NewTextValue?.ToLower() ?? string.Empty;

        if (string.IsNullOrEmpty(searchTerm))
        {
            // When search term is cleared, reset the collection to original list
            Printers.Clear();
            foreach (var printer in Printers) // Assuming you have a list that holds the unfiltered printers.
            {
                Printers.Add(printer);
            }
        }
        else
        {
            // Filter Printers based on search term
            var filteredPrinters = Printers.Where(p => p.name.ToLower().Contains(searchTerm) || p.Description.ToLower().Contains(searchTerm)).ToList();

            // Update the ObservableCollection
            Printers.Clear();
            foreach (var printer in filteredPrinters)
            {
                Printers.Add(printer);
            }
        }
    }

}