namespace Crocheto_0._2.Pages.Profile;

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