using Crocheto_0._2.Pages.Access;

namespace Crocheto_0._2.Pages.Profile;

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