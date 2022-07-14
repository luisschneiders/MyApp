using HealthCareApp.Components.Markup;
using HealthCareApp.Components.Spinner;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Pages.ApiPage
{
    public partial class APIGet : ComponentBase
    {
        [Inject]
        private SpinnerService _spinnerService { get; set; } = default!;

        // Retrieve API keys from user-secrets
        [Inject]
        private IConfiguration _config { get; set; } = default!;

        private ComponentMarkup _componentMarkup { get; set; }
        private List<ComponentMarkup> _componentMarkupList { get; set; }
        private List<string> _codes { get; set; }

        private string _endpoint { get; set; }
        private string _route { get; set; }
        private string _languages { get; set; }
        private int _selectedScope { get; set; }

        private bool _getLanguagesError;
        private bool _isDisabled { get; set; }


        public APIGet()
        {
            _spinnerService = new();
            _componentMarkup = new();
            _componentMarkupList = new List<ComponentMarkup>();
            _codes = new List<string>();

            _endpoint = "https://localhost:7086/";
            _route = "api/v1/Languages";
            _languages = string.Empty;
            _selectedScope = 1;

        }

        protected override void OnInitialized()
        {

            _componentMarkupList = new List<ComponentMarkup>();

            _codes = new()
            {
                new MarkupString("Endpoint = 'https://localhost:7086/' ").ToString(),
                new MarkupString("Route = 'api/v1/Language' ").ToString(),
            };
            _componentMarkup = new()
            {
                Title = "Endpoint, route",
                Code = _codes
            };
            _componentMarkupList.Add(_componentMarkup);

            _codes = new()
            {
                new MarkupString("dictionary(value=1), translation(value=2), transliteration(value=3)").ToString()
            };
            _componentMarkup = new()
            {
                Title = "Scope (optional)",
                Code = _codes
            };
            _componentMarkupList.Add(_componentMarkup);
        }

        private async Task GetLanguages()
        {
            await Task.Run(() => _spinnerService.ShowSpinner());

            var healthCareApiKey = _config["HEALTH_CARE_API_KEY"];

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
                await Task.Run(() => _spinnerService.HideSpinner());
                await Task.CompletedTask;
            }
            catch (HttpRequestException e)
            {
                await Task.Run(() => _spinnerService.HideSpinner());
                Console.WriteLine("Error: {0}", e.Message);
                _getLanguagesError = true;
            }
            catch (Exception ex)
            {
                await Task.Run(() => _spinnerService.HideSpinner());
                Console.WriteLine("Error: {0}", ex.Message);
                _getLanguagesError = true;
            }
        }

        private async Task GetLanguagesByScope()
        {
            await Task.Run(() => _spinnerService.ShowSpinner());

            var healthCareApiKey = _config["HEALTH_CARE_API_KEY"];

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
                await Task.Run(() => _spinnerService.HideSpinner());
                await Task.CompletedTask;
            }
            catch (HttpRequestException e)
            {
                await Task.Run(() => _spinnerService.HideSpinner());
                Console.WriteLine("Error: {0}", e.Message);
                _getLanguagesError = true;
            }
            catch (Exception ex)
            {
                await Task.Run(() => _spinnerService.HideSpinner());
                Console.WriteLine("Error: {0}", ex.Message);
                _getLanguagesError = true;
            }
        }
    }
}
