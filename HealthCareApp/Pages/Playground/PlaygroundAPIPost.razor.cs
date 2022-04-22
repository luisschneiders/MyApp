using System;
using System.Collections.Generic;
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
        private List<ComponentMarkup> _componentMarkupList { get; set; }
        private List<string> _codes { get; set; }

        private LabelMop _labelMop { get; set; } = new();

        private bool _displayValidationMessages { get; set; }
        private bool _labelError { get; set; }

        private string _labelString { get; set; }


        protected override void OnInitialized()
        {

            _componentMarkup = new();
            _componentMarkupList = new List<ComponentMarkup>();

            _codes = new()
            {
                new MarkupString("Endpoint = 'https://localhost:7086/' ").ToString(),
                new MarkupString("Route = 'api/v1/Label' ").ToString(),
            };
            _componentMarkup = new()
            {
                Title = "Endpoint, route",
                Code = _codes
            };
            _componentMarkupList.Add(_componentMarkup);

        }

        private async Task HandleValidSubmitAsync()
        {
            var healthCareApiKey = Environment.GetEnvironmentVariable("HEALTH_CARE_API_KEY");
            var endpoint = "https://localhost:7086/";
            var route = "api/v1/Label";

            var URI = $"{endpoint}{route}";

            var timeOut = new DateTime(0001, 1, 1, 23, 00, 00);

            var timeIn = new DateTime(0001, 1, 1, 7, 30, 00);

            _displayValidationMessages = false;

            _labelMop.CompanyName = "Company name";
            _labelMop.Department = "Department";
            _labelMop.Location = "Location";
            _labelMop.TimeOut = timeOut;
            _labelMop.TimeIn = timeIn;
            _labelMop.Quantity = 50;

            using (var httpClient = new HttpClient())
            {
                try
                {
                    httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
                    httpClient.DefaultRequestHeaders.Add("User-Agent", "HealthCare App");
                    httpClient.DefaultRequestHeaders.Add("HealthCareAPIKey", healthCareApiKey);

                    var queryString = new StringContent(JsonConvert.SerializeObject(_labelMop), UnicodeEncoding.UTF8, "application/json");

                    var httpResponse = await httpClient.PostAsync(new Uri(URI), queryString);

                    if (httpResponse.IsSuccessStatusCode)
                    {
                        _labelString = await httpResponse.Content.ReadAsStringAsync();
                    }
                }
                catch (HttpRequestException e)
                {
                    await Task.Run(() => SpinnerService.HideSpinner());
                    System.Diagnostics.Debug.WriteLine(e.Message);
                    Console.WriteLine("Error: {0}", e.Message);
                    _labelError = true;
                }
                catch (Exception ex)
                {
                    await Task.Run(() => SpinnerService.HideSpinner());
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                    Console.WriteLine("Error: {0}", ex.Message);
                    _labelError = true;
                }
            }

            _labelMop = new();

            await Task.CompletedTask;

        }

        private async Task HandleInvalidSubmitAsync()
        {
            await Task.FromResult(_displayValidationMessages = true);
            await Task.CompletedTask;
        }
    }
}
