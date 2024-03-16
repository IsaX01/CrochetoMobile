using Crocheto_0._2.Services;
using Crocheto_0._2.ViewsModels;
using System.Diagnostics;
using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;


namespace Crocheto_0._2.Pages.Access;

public partial class Login : ContentPage
{ 
    public LoginViewModel LoginViewModel { get; set; }
    public Login()
    {
        InitializeComponent();
        BindingContext = new LoginViewModel();
        Debug.WriteLine("hOla carAMBola12");
    }

    public async Task<bool> StoreToken(string token)
    {
        await SecureStorage.SetAsync("AuthToken", token);
        return true;
    }

    public async Task<bool> StoreUserId(string userId)
    {
        await SecureStorage.SetAsync("UserId", userId);
        return true;
    }

    public async Task<bool> StoreIsAdmin(bool IsAdmin)
    {
        await SecureStorage.SetAsync("IsAdmin", IsAdmin.ToString());
        return true;
    }


    private async void OnLoginClicked(object sender, EventArgs e)
    {
        var loginViewModel = BindingContext as LoginViewModel;

        if (loginViewModel == null)
        {
            Debug.WriteLine("LoginViewModel is null");
            return;
        }

        loginViewModel.IsLoading = true;
        Debug.WriteLine($"Email: {loginViewModel.Email}, Password: {loginViewModel.Password}");

        var authService = new AuthService();
        if (authService == null)
        {
            Debug.WriteLine("authService is null");
            return;
        }

        var userDTO = await authService.Login(loginViewModel);
        if (userDTO == null)
        {
            loginViewModel.IsLoading = false;
            _ = DisplayAlert("Error", "Invalid credentials", "OK");
            return;
        }

        Debug.WriteLine($"UserDTO: {userDTO.Rol}, {userDTO.Id}, {userDTO.Token}, {userDTO.HasFingerprintRegistered}");

        if (userDTO != null)
        {
            await StoreToken(userDTO.Token);
            await StoreUserId(userDTO.Id);

            var IsAdmin = false;
            if(userDTO.Rol == "User")
            {
                IsAdmin = false;
            }else if(userDTO.Rol == "Admin")
            {
                IsAdmin = true;
            }

            await StoreIsAdmin(IsAdmin);

            // Verificar si el usuario tiene una huella dactilar registrada
            if (userDTO.HasFingerprintRegistered == false && await CrossFingerprint.Current.IsAvailableAsync(true))
            {
                var result = await DisplayAlert("FingerPrint", "¿Do you want register fingerprint to future logins?", "Yes", "No");
                if (result)
                {
                    var request = new AuthenticationRequestConfiguration("Prove your fingerprint", "We need to verify your identity") { AllowAlternativeAuthentication = false };
                    var authResult = await CrossFingerprint.Current.AuthenticateAsync(request);
                    if (authResult.Authenticated)
                    {
                        // Guardar que el usuario ha registrado su huella dactilar
                        userDTO.HasFingerprintRegistered = true;
                        await authService.UpdateUser(userDTO);
                    }
                    else
                    {
                        // El usuario canceló o la autenticación falló
                    }
                }
            }

            // Ejemplo: Navegar a página principal para administradores
            if (userDTO.Rol == "Admin")
            {
                Application.Current.MainPage = new AdminAppShell();
            }
            // Ejemplo: Navegar a página principal para usuarios
            else
            {
                Application.Current.MainPage = new UserAppShell();
            }
        }
        else
        {
            _ = DisplayAlert("Error", "Invalid credentials", "OK");
        }
        loginViewModel.IsLoading = false;
    }


    private async void OnFingerprintLoginClicked(object sender, EventArgs e)
    {
      var loginViewModel = BindingContext as LoginViewModel;
   
      if (loginViewModel == null)
      {
        Debug.WriteLine("LoginViewModel is null");
        return;
      }

      loginViewModel.IsLoading = true;
      Debug.WriteLine($"Email: {loginViewModel.Email}, Password: {loginViewModel.Password}");

      var authService = new AuthService();
      if (authService == null)
      {
        Debug.WriteLine("authService is null");
        return;
      }

      var userDTO = await authService.Login(loginViewModel);
      if (userDTO == null || !userDTO.HasFingerprintRegistered)
      {
        loginViewModel.IsLoading = false;
        _ = DisplayAlert("Error", "This user doesn`t have a fingerprint register", "OK");
        return;
      }

      var request = new AuthenticationRequestConfiguration("Prove your fingerprint", "We need to verify your identity") { AllowAlternativeAuthentication = false };
      var authResult = await CrossFingerprint.Current.AuthenticateAsync(request);
      if (authResult.Authenticated)
      {
        // Ejemplo: Navegar a página principal para administradores
        if (userDTO.Rol == "Admin")
        {
          Application.Current.MainPage = new AdminAppShell();
        }
        // Ejemplo: Navegar a página principal para usuarios
        else
        {
          Application.Current.MainPage = new UserAppShell();
        }
      }
      else
      {
        _ = DisplayAlert("Error", "The fingerprint register doesn`t match", "OK");
      }
      loginViewModel.IsLoading = false;
    }


    private void SignUpClick(object sender, EventArgs e)
    {
        Application.Current.MainPage = new SignUp();
    }

    private void NewPassword(object sender, EventArgs e)
    {
        Application.Current.MainPage = new Profile.Password2();
    }

}