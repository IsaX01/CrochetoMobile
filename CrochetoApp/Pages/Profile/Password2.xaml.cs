using CrochetoApp.Pages.Access;

namespace CrochetoApp.Pages.Profile;

public partial class Password2 : ContentPage
{
	public Password2()
	{
		InitializeComponent();
	}

    private void profileBack(object sender, EventArgs e)
    {
        Application.Current.MainPage = new Login();
    }
}