using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HealthCareApp.Components.Spinner;
using LabelLibrary.Models;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace HealthCareApp.Pages.Playground
{
    public partial class PlaygroundAPIPost : ComponentBase
    {
        [Inject]
        private SpinnerService SpinnerService { get; set; }

        private ComponentMarkup _componentMarkup { get; set; }
        private LabelMop _labelMop { get; set; }

        private List<ComponentMarkup> _componentMarkupList { get; set; }
        private List<string> _codes { get; set; }

        private string _labelString { get; set; }
        private string _endpoint { get; set; }
        private string _route { get; set; }
        private string _uri { get; set; }
        private string _fileName { get; set; }
        private string _filePath { get; set; }

        private bool _displayValidationMessages { get; set; }
        private bool _labelError { get; set; }

        public PlaygroundAPIPost()
        {
            _labelMop = new();
            _endpoint = "https://localhost:7086/";
            _route = "api/v1/Labels";
            _uri = $"{_endpoint}{_route}";
            _filePath = "./wwwroot/images/";
        }

        protected override void OnInitialized()
        {

            _componentMarkupList = new List<ComponentMarkup>();

            _codes = new()
            {
                new MarkupString("Endpoint = 'https://localhost:7086/' ").ToString(),
                new MarkupString("Route = 'api/v1/Labels' ").ToString(),
            };
            _componentMarkup = new()
            {
                Title = "Endpoint and route",
                Code = _codes
            };
            _componentMarkupList.Add(_componentMarkup);

        }

        private async Task HandleValidSubmitAsync()
        {
            var healthCareApiKey = Environment.GetEnvironmentVariable("HEALTH_CARE_API_KEY");

            var timeOut = new DateTime(0001, 1, 1, 23, 00, 00);

            var timeIn = new DateTime(0001, 1, 1, 7, 30, 00);

            _displayValidationMessages = false;

            _labelMop.CompanyName = "Company name";
            _labelMop.Department = "Department";
            _labelMop.Location = "Location";
            _labelMop.TimeOut = timeOut;
            _labelMop.TimeIn = timeIn;
            _labelMop.Quantity = 50;

            HttpClient httpClient = new HttpClient();

            try
            {
                httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
                httpClient.DefaultRequestHeaders.Add("User-Agent", "HealthCare App");
                httpClient.DefaultRequestHeaders.Add("HealthCareAPIKey", healthCareApiKey);

                var queryString = new StringContent(JsonConvert.SerializeObject(_labelMop), UnicodeEncoding.UTF8, "application/json");

                var httpResponse = await httpClient.PostAsync(new Uri(_uri), queryString);

                if (httpResponse.IsSuccessStatusCode)
                {
                    Guid guid = Guid.NewGuid();

                    _labelString = await httpResponse.Content.ReadAsStringAsync();
                    _fileName = $"label-{guid}.png";

                    DisplayLabelImage(_labelMop, _uri, _filePath, _fileName);
                }
            }
            catch (HttpRequestException e)
            {
                await Task.Run(() => SpinnerService.HideSpinner());
                Console.WriteLine("Error: {0}", e.Message);
                _labelError = true;
            }
            catch (Exception ex)
            {
                await Task.Run(() => SpinnerService.HideSpinner());
                Console.WriteLine("Error: {0}", ex.Message);
                _labelError = true;
            }

            _labelMop = new();

            await Task.CompletedTask;

        }

        private async Task HandleInvalidSubmitAsync()
        {
            await Task.FromResult(_displayValidationMessages = true);
            await Task.CompletedTask;
        }

        private static void DisplayLabelImage(LabelMop labelMop, string uri, string filePath, string fileName)
        {

            var healthCareApiKey = Environment.GetEnvironmentVariable("HEALTH_CARE_API_KEY");

            HttpClient httpClient = new HttpClient();

            try
            {
                httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
                httpClient.DefaultRequestHeaders.Add("User-Agent", "HealthCare App");
                httpClient.DefaultRequestHeaders.Add("HealthCareAPIKey", healthCareApiKey);

                var queryString = new StringContent(JsonConvert.SerializeObject(labelMop), UnicodeEncoding.UTF8, "application/json");

                var httpResponse = httpClient.GetAsync(uri).Result;

                if (httpResponse.IsSuccessStatusCode)
                {


                    var stream = httpResponse.Content.ReadAsStreamAsync().Result;

                    DirectoryInfo info = new DirectoryInfo(filePath);

                    if (!info.Exists)
                    {
                        info.Create();
                    }

                    string path = Path.Combine(filePath, fileName);

                    FileStream fileStream = new(path, FileMode.CreateNew, FileAccess.ReadWrite);

                    stream.CopyTo(fileStream);
                    stream.Close();

                    fileStream.Close();

                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
            }

        }
    }
}
