namespace Crocheto_0._2.Pages.Home;

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