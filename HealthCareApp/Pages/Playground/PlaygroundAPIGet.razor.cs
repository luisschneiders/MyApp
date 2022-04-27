using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using HealthCareApp.Components.Spinner;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Pages.Playground
{
    public partial class PlaygroundAPIGet : ComponentBase
    {
        [Inject]
        private SpinnerService SpinnerService { get; set; }

        private string _endpoint { get; set; } = String.Empty;
        private string _route { get; set; } = String.Empty;
        private string _languages { get; set; } = String.Empty;
        private int _selectedScope { get; set; }

        private bool _getLanguagesError;
        private bool _isDisabled { get; set; }

        private ComponentMarkup ComponentMarkup { get; set; }
        private List<ComponentMarkup> ComponentMarkupList { get; set; }
        private List<string> Codes { get; set; }

        public PlaygroundAPIGet()
        {
            _endpoint = "https://localhost:7086/";
            _route = "api/v1/Languages";
            _selectedScope = 1;
        }

        protected override void OnInitialized()
        {

            ComponentMarkupList = new List<ComponentMarkup>();

            Codes = new()
            {
                new MarkupString("Endpoint = 'https://localhost:7086/' ").ToString(),
                new MarkupString("Route = 'api/v1/Language' ").ToString(),
            };
            ComponentMarkup = new()
            {
                Title = "Endpoint, route",
                Code = Codes
            };
            ComponentMarkupList.Add(ComponentMarkup);

            Codes = new()
            {
                new MarkupString("dictionary(value=1), translation(value=2), transliteration(value=3)").ToString()
            };
            ComponentMarkup = new()
            {
                Title = "Scope (optional)",
                Code = Codes
            };
            ComponentMarkupList.Add(ComponentMarkup);
        }

        private async Task GetLanguages()
        {
            await Task.Run(() => SpinnerService.ShowSpinner());

            var healthCareApiKey = Environment.GetEnvironmentVariable("HEALTH_CARE_API_KEY");

            var URI = $"{_endpoint}{_route}";

            HttpClient client = new();

            try
            {
                HttpRequestMessage request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(URI),
                };

                request.Headers.Add("Accept", "text/plain");
                request.Headers.Add("User-Agent", "HealthCare App");
                request.Headers.Add("HealthCareAPIKey", healthCareApiKey);

                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    _languages = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    _getLanguagesError = true;
                }
                await Task.Run(() => SpinnerService.HideSpinner());
                await Task.CompletedTask;
            }
            catch (HttpRequestException e)
            {
                await Task.Run(() => SpinnerService.HideSpinner());
                Console.WriteLine("Error: {0}", e.Message);
                _getLanguagesError = true;
            }
            catch (Exception ex)
            {
                await Task.Run(() => SpinnerService.HideSpinner());
                Console.WriteLine("Error: {0}", ex.Message);
                _getLanguagesError = true;
            }
        }

        private async Task GetLanguagesByScope()
        {
            await Task.Run(() => SpinnerService.ShowSpinner());

            var healthCareApiKey = Environment.GetEnvironmentVariable("HEALTH_CARE_API_KEY");

            var URI = $"{_endpoint}{_route}/{_selectedScope}";

            HttpClient client = new ();

            try
            {
                HttpRequestMessage request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(URI),
                };

                request.Headers.Add("Accept", "text/plain");
                request.Headers.Add("User-Agent", "HealthCare App");
                request.Headers.Add("HealthCareAPIKey", healthCareApiKey);

                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    _languages = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    _getLanguagesError = true;
                }
                await Task.Run(() => SpinnerService.HideSpinner());
                await Task.CompletedTask;
            }
            catch (HttpRequestException e)
            {
                await Task.Run(() => SpinnerService.HideSpinner());
                Console.WriteLine("Error: {0}", e.Message);
                _getLanguagesError = true;
            }
            catch (Exception ex)
            {
                await Task.Run(() => SpinnerService.HideSpinner());
                Console.WriteLine("Error: {0}", ex.Message);
                _getLanguagesError = true;
            }
        }
    }
}
