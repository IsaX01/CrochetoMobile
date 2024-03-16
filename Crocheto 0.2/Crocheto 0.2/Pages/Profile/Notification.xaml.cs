namespace Crocheto_0._2.Pages.Profile;

public partial class Notification : ContentPage
{
	public Notification()
	{
		InitializeComponent();
	}

    private async void profileBack(object sender, EventArgs e)
    {
        var appShell = new UserAppShell();
        await appShell.GoToAsync("//homeaccount");
        Application.Current.MainPage = appShell;
    }
}