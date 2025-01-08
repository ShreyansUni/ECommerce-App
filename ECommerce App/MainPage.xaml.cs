using ECommerce_App.Model;
using ECommerce_App.Pages;
using System.Collections.ObjectModel;
using System.Net.Http.Json;

namespace ECommerce_App;

public partial class MainPage : ContentPage
{
    public ObservableCollection<Printer> Printers { get; set; }
    public MainPage()
    {
        InitializeComponent();
        //BindingContext = this;
        //LoadPrinters();
        Printers = new ObservableCollection<Printer>
        {
            new Printer{name = "Printer 1", Description = "High-speed printer", PrinterType="Portable", Rate="10000"},
            new Printer{name = "Printer 2", Description = "Compact design", PrinterType="Portable", Rate="20000"}
        };
        BindingContext = this;
    }

    private async void OnBrowseProductsClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ProductListPage());
    }

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
