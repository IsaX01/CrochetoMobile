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
            Debug.WriteLine("Debole", login);

            var emailPair = new KeyValuePair<string, string>("email", login?.Email);
            var passwordPair = new KeyValuePair<string, string>("password", login?.Password);

            var formUrlEncodedContent = new FormUrlEncodedContent(new[] { emailPair, passwordPair });

            Debug.WriteLine("wurbo", formUrlEncodedContent);

            try
            {
                var response = await _httpClient.PostAsync("/login", formUrlEncodedContent);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<UserDTO>(json);
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return null;
        }


    }
}
