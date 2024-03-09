namespace Crocheto_0._2.Pages.Access;

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

        if (username == "user" && password == "12345")
        {
            Application.Current.MainPage = new UserAppShell();

        }
        else if (username == "admin" && password == "12345")
        {
            Application.Current.MainPage = new AdminAppShell();
        }
        else
        {
            DisplayAlert("Error", "Invalid credentials", "OK");
        }
    }

    private void NewPassword(object sender, EventArgs e)
    {
        Application.Current.MainPage = new Profile.Password2();
    }

}