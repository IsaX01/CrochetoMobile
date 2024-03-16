namespace Crocheto_0._2.Pages.Profile;

public partial class Languages : ContentPage
{
	public Languages()
	{
		InitializeComponent();
	}

    void OnPickerSelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;

        if (selectedIndex != -1)
        {
            // Get the selected language
            string selectedLanguage = (string)picker.ItemsSource[selectedIndex];

            _ = DisplayAlert("Success", $"Language is change to {selectedLanguage}", "OK");
        }
    }

    private async void profileBack(object sender, EventArgs e)
    {
        var appShell = new UserAppShell();
        await appShell.GoToAsync("//homeaccount");
        Application.Current.MainPage = appShell;
    }
}