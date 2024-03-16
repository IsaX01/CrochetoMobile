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
    public class CrochetService
    {
        private readonly HttpClient _httpClient;

        public CrochetService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://10.0.2.2:5063");
        }

        public async Task<List<CrochetDTO>> GetAll()
        {
            var response = await _httpClient.GetAsync("/crochets");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Debug.WriteLine($"Cards JSON: {content}");

                try
                {
                    return JsonConvert.DeserializeObject<List<CrochetDTO>>(content);
                }
                catch (JsonException ex)
                {
                    Debug.WriteLine($"Error: {ex.Message}");
                }
            }
            else
            {
                Debug.WriteLine($"Error in HTTP request: {response.StatusCode}");
            }

            return new List<CrochetDTO>();
        }

        public async Task<CrochetDTO> Get(int id)
        {
            var response = await _httpClient.GetAsync($"/api/YourEntity/{id}");
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<CrochetDTO>(content);
        }

        public async Task<CrochetDTO> Create(CrochetNewViewModel crochet)
        {
        var crochetData = new { id = crochet.Id, image = crochet.Image, title = crochet.Title, description = crochet.Description, subtitle = crochet.Subtitle, statustext = crochet.StatusText, pdffile = crochet.PdfFile, userid = crochet.UserId, isadmin = crochet.IsAdmin};

            var json = JsonConvert.SerializeObject(crochetData);
            Debug.WriteLine($"Crochet JSON: {json}");


            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await _httpClient.PostAsync("/crochet/new", content);
                Debug.WriteLine($"Response C JSON: {response}");

                if (response.IsSuccessStatusCode)
                {
                    var responseJson = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine($"Response JSON: {responseJson}");

                    return JsonConvert.DeserializeObject<CrochetDTO>(responseJson);
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return null;
        }

        public async Task<CrochetDTO> Update(int id, CrochetDTO yourEntity)
        {
            var json = JsonConvert.SerializeObject(yourEntity);
            var response = await _httpClient.PutAsync($"/crochet/{id}", new StringContent(json, Encoding.UTF8, "application/json"));
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<CrochetDTO>(content);
        }

        public async Task Delete(int id)
        {
            await _httpClient.DeleteAsync($"/crochet/{id}");
        }
    }
}

