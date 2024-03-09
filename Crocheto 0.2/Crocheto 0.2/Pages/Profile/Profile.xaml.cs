namespace Crocheto_0._2.Pages.Profile;

public partial class Profile : ContentPage
{
    public Profile()
    {
        InitializeComponent();
    }

    private void NewPassword(object sender, EventArgs e)
    {
        Application.Current.MainPage = new Password();
    }
}