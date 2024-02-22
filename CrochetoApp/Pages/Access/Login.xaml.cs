namespace CrochetoApp.Pages.Access;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}
        
    private void SignUpClick(object sender, EventArgs e)
    {
        Application.Current.MainPage = new SignUp();
    }

    private void EvaluateLogin(object sender, EventArgs e)
    {
        var username = UsernameEntry.Text;
        var password = PasswordEntry.Text;

        if (username == "admin" && password == "12345")
        {
            Application.Current.MainPage = new Pages.Home.HomeClient();
        }
        else
        {
            DisplayAlert("Error", "Invalid credentials", "OK");
        }
    }

}