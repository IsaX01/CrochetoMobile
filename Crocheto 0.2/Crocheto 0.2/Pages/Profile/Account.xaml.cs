using Crocheto_0._2.Services;

namespace Crocheto_0._2.Pages.Profile;

public partial class Account : ContentPage
{
	public Account()
	{
		InitializeComponent();
        GetUserData();

    }

    private async void profileBack(object sender, EventArgs e)
    {
        var appShell = new UserAppShell();
        await appShell.GoToAsync("//homeaccount");
        Application.Current.MainPage = appShell;
    }

    public async void UpdateUserEmailAndUsername(object sender, EventArgs e)
    {
        var authService = new AuthService();
        var user = await authService.GetUserProfile();

        if (user != null)
        {
            user.Email = emailEntry.Text;
            user.Name = userEntry.Text;

            var result = await authService.UpdateUser(user);

            if (result != null)
            {
                await DisplayAlert("Success", "User updated successfully", "OK");
            }
            else
            {
                await DisplayAlert("Error", "Failed to update user", "OK");
            }
        }
        else
        {
            _ = DisplayAlert("Error", "Could not updated user profile data", "OK");
        }
    }



    public async Task GetUserData()
    {
        var authService = new AuthService();
        var user = await authService.GetUserProfile();

        if (user != null)
        {
            userEntry.Text = user.Name;
            emailEntry.Text = user.Email;
            typeEntry.Text = user.Rol;
        }
        else
        {
            _ = DisplayAlert("Error", "Could not load user profile data", "OK");
        }
    }
}