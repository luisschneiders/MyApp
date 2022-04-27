using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using HealthCareApp.Components.Spinner;
using HealthCareApp.Services;
using LabelLibrary.Models;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Pages.Playground
{
    public partial class PlaygroundAPIPost : ComponentBase
    {
        [Inject]
        private LabelService LabelService { get; set; }

        [Inject]
        private SpinnerService SpinnerService { get; set; }

        private ComponentMarkup _componentMarkup { get; set; }
        private LabelMop _labelMop { get; set; }

        private List<ComponentMarkup> _componentMarkupList { get; set; }
        private List<string> _codes { get; set; }

        private string _labelString { get; set; }
        private string _endpoint { get; set; }
        private string _route { get; set; }
        private string _fileName { get; set; }

        private bool _displayValidationMessages { get; set; }
        private bool _labelError { get; set; }

        public PlaygroundAPIPost()
        {
            _labelMop = new();
            _endpoint = "https://localhost:7086/";
            _route = "api/v1/Labels";
        }

        protected override void OnInitialized()
        {

            _componentMarkupList = new List<ComponentMarkup>();

            _codes = new()
            {
                new MarkupString($"Endpoint = '{_endpoint}' ").ToString(),
                new MarkupString($"Route = '{_route}' ").ToString(),
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
            _fileName = String.Empty;
            _labelString = String.Empty;

            await Task.Run(() => SpinnerService.ShowSpinner());

            var timeOut = new DateTime(0001, 1, 1, 23, 00, 00);
            var timeIn = new DateTime(0001, 1, 1, 7, 30, 00);
            _displayValidationMessages = false;

            _labelMop.CompanyName = "Company name";
            _labelMop.Department = "Department";
            _labelMop.Location = "Location";
            _labelMop.TimeOut = timeOut;
            _labelMop.TimeIn = timeIn;
            _labelMop.Quantity = 50;

            HttpResponseMessage responseMessage = await LabelService.CreateLabelMopAsync(_labelMop);

            if ((int)responseMessage.StatusCode == 200)
            {
                var fileName = await LabelService.DisplayLabelMopImageAsync(_labelMop);

                _labelString = await responseMessage.Content.ReadAsStringAsync();

                if (fileName.Length > 0)
                {
                    _fileName = fileName;
                }
            }

            _labelMop = new();

            await Task.Run(() => SpinnerService.HideSpinner());
            await Task.CompletedTask;

        }

        private async Task HandleInvalidSubmitAsync()
        {
            await Task.FromResult(_displayValidationMessages = true);
            await Task.CompletedTask;
        }

    }
}
