using ECommerce_App.Model;

namespace ECommerce_App.Pages;

public partial class ProductDetailsPage : ContentPage
{
    public Printer SelectedPrinter { get; set; }

    // Parameterless constructor
    public ProductDetailsPage() : this(null) { }

    // Constructor with Printer parameter
    public ProductDetailsPage(Printer printer)
    {
        InitializeComponent();

        // Set a default Printer if none is provided
        SelectedPrinter = printer ?? new Printer
        {
            Name = "Default Printer",
            Description = "Description not available.",
            PrinterType = "Unknown",
            Rate = 10,
            Img = "printer_placeholder.png"
        };

        BindingContext = SelectedPrinter;
    }

    private async void OnClickedCardButton(object sender, EventArgs e)
    {
            await Navigation.PushAsync(new CardPage());
    }

    private async void OnBackButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();  // This goes back to the previous page
    }
}