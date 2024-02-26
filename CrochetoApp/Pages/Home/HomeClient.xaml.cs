namespace CrochetoApp.Pages.Home;

public partial class HomeClient : ContentPage
{
	public HomeClient()
	{
		InitializeComponent();

	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

        RecentButton.Command.Execute(null);
    }
    

}