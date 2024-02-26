namespace CrochetoApp.Pages.Profile;

public partial class Profile : ContentPage
{
	public Profile()
	{
		InitializeComponent();
	}

    private void newPassword(object sender, EventArgs e)
    {
        Application.Current.MainPage = new Password();
    }
}