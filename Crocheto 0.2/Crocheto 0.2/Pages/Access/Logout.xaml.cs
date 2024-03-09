namespace Crocheto_0._2.Pages.Access;

public partial class Logout : ContentPage
{
    public Logout()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await ConfirmLogout();
    }

    private async Task ConfirmLogout()
    {
        var confirm = false;
        Device.BeginInvokeOnMainThread(async () =>
        {
            confirm = await DisplayAlert("Confirm", "¿are you sure you want to close the session?", "Yes", "No");
            if (confirm)
            {
                Application.Current.MainPage = new Login();
            }
        });

    }
}
