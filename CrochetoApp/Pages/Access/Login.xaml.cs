namespace CrochetoApp.Pages.Access;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}

    void OnSignUpLabelTapped(object sender, EventArgs e)
    {
        Navigation.PushAsync(new SignUp());
    }
}