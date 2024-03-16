using Crocheto_0._2.DTO;
using Crocheto_0._2.ViewsModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crocheto_0._2.Services
{
    public class AuthService
    {
        private readonly HttpClient _httpClient;

        public AuthService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://10.0.2.2:5063"); 
        }

        public async Task<UserDTO> Login(LoginViewModel login)
        {
            var loginData = new { email = login?.Email, password = login?.Password };
            Debug.WriteLine($"Login JSON: {loginData}");

            var json = JsonConvert.SerializeObject(loginData);
            Debug.WriteLine($"Request JSON: {json}");
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await _httpClient.PostAsync("/login", content);
                if (response.IsSuccessStatusCode)
                {
                    var responseJson = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<UserDTO>(responseJson);

                

                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return null;
        }

        public async Task<UserDTO> Register(RegisterViewModel user)
        {
            // Establecer el rol por defecto a "User"
            user.Rol = "User";
            user.SubscriptionType = "Free";

            var userData = new {id = user.Id, name = user?.Name, email = user?.Email, password = user?.Password, rol = user?.Rol, subscriptionType = user?.SubscriptionType, hasfingerprint = user?.HasFingerprintRegistered};
            Debug.WriteLine($"User JSON: {userData}");

            var json = JsonConvert.SerializeObject(userData);
            Debug.WriteLine($"Request JSON: {json}");

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await _httpClient.PostAsync("/register", content);
                if (response.IsSuccessStatusCode)
                {
                    var responseJson = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<UserDTO>(responseJson);
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return null;
        }

        public async Task<UserDTO> UpdateUser(UserDTO user)
        {
            var userData = new { id = user.Id, name = user.Name, email = user.Email, rol = user.Rol, hasFingerprintRegistered = user.HasFingerprintRegistered, subscriptiontype = user.SubscriptionType };
            Debug.WriteLine($"User JSON: {userData}");

            var json = JsonConvert.SerializeObject(userData);
            Debug.WriteLine($"Request JSON: {json}");

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var userId = await SecureStorage.GetAsync("UserId");
                var response = await _httpClient.PutAsync($"/user/{userId}", content);
                if (response.IsSuccessStatusCode)
                {
                    var responseJson = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<UserDTO>(responseJson);
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return null;
        }


        public async Task<UserDTO> GetUserProfile()
        {
            var userId = await SecureStorage.GetAsync("UserId");
            Debug.WriteLine($"UserID JSON: {userId}");

            var response = await _httpClient.GetAsync($"/user/{userId}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<UserDTO>(json);
            }

            return null;
        }





    }
}
