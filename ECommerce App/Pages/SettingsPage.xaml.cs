namespace ECommerce_App.Pages;

public partial class SettingsPage : ContentPage
{
	public SettingsPage()
	{
		InitializeComponent();
	}

    private async void OnBackButton(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}