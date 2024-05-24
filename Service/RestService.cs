using BVND115.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BVND115.Service
{
    public class RestService
    {
        HttpClient _client;
        JsonSerializerOptions _serializerOptions;

        public List<BacSi> Items { get; private set; }
        public string kiemtra {  get; private set; }
        public RestService()
        {
            _client = new HttpClient();
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }
        public async Task<List<BacSi>> RefreshDataAsync( List<BacSi>Ite )
        {
            Items = new List<BacSi>();

            Uri uri = new Uri(string.Format("https://97e2983b0b494145b8cf6d3d1a5fdc4a.api.mockbin.io/", string.Empty));
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    kiemtra = content;
                    Items = JsonSerializer.Deserialize<List<BacSi>>(content, _serializerOptions);
                    /*                    Items = JsonConvert.DeserializeObject<List<BacSi>>(content);*/
                }
            }
            catch (Exception ex)
            {
            }

            return Items;
        }
    }
}
