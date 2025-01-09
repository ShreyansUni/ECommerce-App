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

    public ObservableCollection<Product> Products { get; set; }
    public MainPage()
    {
        InitializeComponent();
        //BindingContext = this;
        //LoadPrinters();
        Printers = new ObservableCollection<Printer>();
        BindingContext = this;

        LoadPrintersAsync();
        //    Printers = new ObservableCollection<Printer>
        //    {
        //        new Printer{name = "Printer 1", Description = "High-speed printer", PrinterType="Portable", Rate="10000"},
        //        new Printer{name = "Printer 2", Description = "Compact design", PrinterType="Portable", Rate="20000"}
        //    };
        //    Products = new ObservableCollection<Product>
        //{
        //    new Product { Image = "printer1.jpg", Name = "Watch", Price = "$40" },
        //    new Product { Image = "printer2.jpg", Name = "Nike Shoes", Price = "$430" },
        //    new Product { Image = "printer3.jpg", Name = "Airpods", Price = "$333" }
        //};
        //    BindingContext = this;
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

    //private async void OnProductTapped(object sender, EventArgs e)
    //{
    //    // Assuming you have a product ID or some other property to pass to the product list page
    //    var product = (sender as Frame).BindingContext as Product;

    //    // Navigate to Product List page
    //    await Navigation.PushAsync(new ProductListPage());
    //}


    //private async void LoadPrinters()
    //{
    //    try
    //    {
    //        using HttpClient client = new();
    //        var printers = await client.GetFromJsonAsync<List<Printer>>("https://677e067b94bde1c1252a17b3.mockapi.io/api/p1/printers/");
    //        if(printers != null)
    //        {
    //            foreach(var printer in printers)
    //            {
    //                printers.Add(printer);
    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        await DisplayAlert("Error",ex.Message,"Ok");
    //    }
    //}

    //private void OnBrowseProductsClicked(object sender, EventArgs e)
    //{
    //    CurrentPage = Children[1]; // Navigate to Product List tab
    //}

    //private async void OnProductClicked(object sender, EventArgs e)
    //{
    //    Button button = sender as Button;
    //    Printer selectedPrinter = button?.BindingContext as Printer;
    //    if (selectedPrinter != null)
    //    {
    //        await DisplayAlert("Product Details",
    //            $"Name: {selectedPrinter.name}\nDescription: {selectedPrinter.Description}\nType: {selectedPrinter.PrinterType}\nRate: {selectedPrinter.Rate}",
    //            "OK");
    //    }
    //}
}
