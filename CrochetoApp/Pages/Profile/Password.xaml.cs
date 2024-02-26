namespace CrochetoApp.Pages.Profile;

public partial class Password : ContentPage
{
	public Password()
	{
		InitializeComponent();
	}

    private void profileBack(object sender, EventArgs e)
    {
        Application.Current.MainPage = new UserAppShell();
    }
}