using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using LabelLibrary.Models;
using Newtonsoft.Json;

namespace HealthCareApp.Services
{
    public class LabelService
    {

        private string _endpoint { get; set; }
        private string _route { get; set; }
        private string _uri { get; set; }
        private string _filePath { get; set; }

        public LabelService()
        {
            _endpoint = "https://localhost:7086/";
            _route = "api/v1/Labels";
            _uri = $"{_endpoint}{_route}";
            _filePath = "./wwwroot/images/";
        }

        public async Task<HttpResponseMessage> CreateLabelMopAsync(LabelMop labelMop)
        {
            var healthCareApiKey = Environment.GetEnvironmentVariable("HEALTH_CARE_API_KEY");

            using (var httpClient = new HttpClient())
            {
                try
                {
                    httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
                    httpClient.DefaultRequestHeaders.Add("User-Agent", "HealthCare App");
                    httpClient.DefaultRequestHeaders.Add("HealthCareAPIKey", healthCareApiKey);

                    var queryString = new StringContent(JsonConvert.SerializeObject(labelMop), UnicodeEncoding.UTF8, "application/json");

                    var httpResponse = await httpClient.PostAsync(new Uri(_uri), queryString);

                    var labelString = await httpResponse.Content.ReadAsStringAsync();

                    if (httpResponse.IsSuccessStatusCode)
                    {
                        return httpResponse;
                    }
                    else
                    {
                        return httpResponse;
                    }
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("Error: {0}", e.Message);
                    return null;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: {0}", ex.Message);
                    return null;
                }
            };
        }

        public async Task<string> DisplayLabelMopImageAsync(LabelMop labelMop)
        {
            var healthCareApiKey = Environment.GetEnvironmentVariable("HEALTH_CARE_API_KEY");

            using (var httpClient = new HttpClient())
            {
                try
                {
                    httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
                    httpClient.DefaultRequestHeaders.Add("User-Agent", "HealthCare App");
                    httpClient.DefaultRequestHeaders.Add("HealthCareAPIKey", healthCareApiKey);

                    var queryString = new StringContent(JsonConvert.SerializeObject(labelMop), UnicodeEncoding.UTF8, "application/json");

                    var httpResponse = httpClient.GetAsync(_uri).Result;

                    if (httpResponse.IsSuccessStatusCode)
                    {
                        Guid guid = Guid.NewGuid();

                        var stream = httpResponse.Content.ReadAsStreamAsync().Result;
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

                        return null;
                    }
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("Error: {0}", e.Message);
                    await Task.CompletedTask;
                    return e.Message;
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
