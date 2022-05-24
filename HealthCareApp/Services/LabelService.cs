using System.Text;
using LabelLibrary.Models;
using Newtonsoft.Json;

namespace HealthCareApp.Services
{
    public class LabelService
    {
        // Retrieve API keys from user-secrets
        private readonly IConfiguration _config;

        private string _endpoint { get; set; }
        private string _route { get; set; }
        private string _uri { get; set; }
        private string _filePath { get; set; }

        public LabelService(IConfiguration configuration)
        {
            _endpoint = "https://localhost:7086/";
            _route = "api/v1/Labels";
            _uri = $"{_endpoint}{_route}";
            _filePath = "./wwwroot/images/";
            _config = configuration;
        }

        public async Task<HttpResponseMessage> CreateLabelMopAsync(LabelMop labelMop)
        {

            var healthCareApiKey = _config["HEALTH_CARE_API_KEY"];

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
                httpClient.DefaultRequestHeaders.Add("User-Agent", "HealthCare App");
                httpClient.DefaultRequestHeaders.Add("HealthCareAPIKey", healthCareApiKey);

                var queryString = new StringContent(JsonConvert.SerializeObject(labelMop), UnicodeEncoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(new Uri(_uri), queryString);

                return response;
            };
        }

        public async Task<string> DisplayLabelMopImageAsync(LabelMop labelMop)
        {

            var healthCareApiKey = _config["HEALTH_CARE_API_KEY"];

            using (var httpClient = new HttpClient())
            {
                try
                {
                    httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
                    httpClient.DefaultRequestHeaders.Add("User-Agent", "HealthCare App");
                    httpClient.DefaultRequestHeaders.Add("HealthCareAPIKey", healthCareApiKey);

                    var queryString = new StringContent(JsonConvert.SerializeObject(labelMop), UnicodeEncoding.UTF8, "application/json");

                    var response = httpClient.GetAsync(_uri).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        Guid guid = Guid.NewGuid();

                        var stream = response.Content.ReadAsStreamAsync().Result;
                        var fileName = $"label-{guid}.png";

                        DirectoryInfo info = new DirectoryInfo(_filePath);

                        if (!info.Exists)
                        {
                            info.Create();
                        }

                        string path = Path.Combine(_filePath, fileName);

                        FileStream fileStream = new(path, FileMode.CreateNew, FileAccess.ReadWrite);

                        stream.CopyTo(fileStream);
                        stream.Close();

                        fileStream.Close();

                        await Task.CompletedTask;

                        return fileName;
                    }
                    else
                    {
                        await Task.CompletedTask;

                        return response.StatusCode.ToString();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: {0}", ex.Message);
                    await Task.CompletedTask;
                    return ex.Message;
                }
            }
        }
    }
}
