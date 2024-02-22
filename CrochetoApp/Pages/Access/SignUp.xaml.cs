namespace CrochetoApp.Pages.Access;

public partial class SignUp : ContentPage
{
	public SignUp()
	{
		InitializeComponent();
	}

    private void LoginClick(object sender, EventArgs e)
    {
        Application.Current.MainPage = new Login();
    }
}