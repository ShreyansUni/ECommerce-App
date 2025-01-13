using ECommerce_App.Pages;
using Microsoft.Maui.Devices;

namespace ECommerce_App;

public partial class App : Application
{
    //private readonly List<string> allowedDeviceIdentifiers = new List<string>
    //{
    //    "CPH1893"
    //};
    private LoaderPage _loaderPage;
    public App()
    {
        InitializeComponent();
        _loaderPage = new LoaderPage();

        ShowLoader();

        LoadData();
    }

    private void ShowLoader()
    {
        _loaderPage.IsVisible = true;
        MainPage.Navigation.PushModalAsync(_loaderPage);
    }

    private async void LoadData()
    {
        await Task.Delay(3000); 

        _loaderPage.IsVisible = false;
        await MainPage.Navigation.PopModalAsync();
    }

    //private string GetDeviceIdentifier()
    //{
    //    return DeviceInfo.Model;
    //}

    //private bool IsDeviceAllowed(string deviceIdentifier)
    //{
    //    return allowedDeviceIdentifiers.Contains(deviceIdentifier);
    //}
}
