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

        private string Languages { get; set; }
        private bool getLanguagesError;

        private string SelectedScope { get; set; } = "all";

        private ComponentMarkup ComponentMarkup { get; set; }
        private List<ComponentMarkup> ComponentMarkupList { get; set; }
        private List<string> Codes { get; set; }

        protected override void OnInitialized()
        {

            ComponentMarkup = new();
            ComponentMarkupList = new List<ComponentMarkup>();

            Codes = new()
            {
                new MarkupString("Endpoint = 'https://localhost:7086/' ").ToString(),
                new MarkupString("Route = 'api/v1/Language' ").ToString(),
                new MarkupString("Parameter = '?&scope=dictionary' ").ToString()
            };
            ComponentMarkup = new()
            {
                Title = "Endpoint, route, parameter",
                Code = Codes
            };
            ComponentMarkupList.Add(ComponentMarkup);

            Codes = new()
            {
                new MarkupString("dictionary, translation, transliteration or all").ToString()
            };
            ComponentMarkup = new()
            {
                Title = "Scope",
                Code = Codes
            };
            ComponentMarkupList.Add(ComponentMarkup);

        }

        private async Task GetLanguages()
        {
            await Task.Run(() => SpinnerService.ShowSpinner());

            var endpoint = "https://localhost:7086/";
            var route = "api/v1/Language";

            var scope = SelectedScope.ToLower();

            var URI = (scope.Length > 0 && scope != "all") ? $"{endpoint}{route}?&scope={scope}" : $"{endpoint}{route}";

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

                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {

                    var body = await response.Content.ReadAsStringAsync();

                    Languages = body;

                }
                else
                {
                    getLanguagesError = true;
                }
                await Task.Run(() => SpinnerService.HideSpinner());
                await Task.CompletedTask;
            }
            catch (HttpRequestException e)
            {
                await Task.Run(() => SpinnerService.HideSpinner());
                getLanguagesError = true;
            }
            catch (Exception ex)
            {
                await Task.Run(() => SpinnerService.HideSpinner());
                getLanguagesError = true;
            }
        }

    }
}
