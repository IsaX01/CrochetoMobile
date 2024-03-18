using Crocheto_0._2.ViewsModels;

namespace Crocheto_0._2.Pages.Maintenances;

public partial class Crochets : ContentPage
{
	public Crochets()
	{
		InitializeComponent();
        BindingContext = new CrochetViewModel();
        MessagingCenter.Subscribe<CrochetViewModel, string>(this, "Error", async (sender, arg) =>
        {
            await DisplayAlert("Error", arg, "OK");
        });
    }

    void OnSearchTextChanged(object sender, TextChangedEventArgs e)
    {
        ((CrochetViewModel)BindingContext).LoadData();
    }
    
    private async void HomeAdmin(object sender, EventArgs e)
    {
        var appShell = new AdminAppShell();
        await appShell.GoToAsync("//homemaintenance");
        Application.Current.MainPage = appShell;
    }


    protected override void OnDisappearing()
    {
        base.OnDisappearing();

        MessagingCenter.Unsubscribe<CrochetViewModel, string>(this, "Error");
    }

}