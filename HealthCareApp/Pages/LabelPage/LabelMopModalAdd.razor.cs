﻿using System;
using CSharpVitamins;
using HealthCareApp.Components.Modal;
using HealthCareApp.Components.Toast;
using HealthCareApp.Data;
using HealthCareApp.Settings.Enum;
using LabelLibrary.Models;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Pages.LabelPage
{
	public partial class LabelMopModalAdd : ComponentBase
	{
        [Inject]
        private LabelMopService _labelMopService { get; set; }

        [Inject]
        private ToastService _toastService { get; set; }

        [Parameter]
        public EventCallback OnSubmitSuccess { get; set; }

        private Modal _modalAdd { get; set; }

        private Guid _modalAddTarget { get; set; }

        private LabelMop _labelMop { get; set; }

        private bool _displayValidationErrorMessages { get; set; }

        public LabelMopModalAdd()
		{
            _toastService = new();
            _modalAdd = new();
            _labelMop = new();
        }

        public async Task OpenModalAddAsync()
        {
            _modalAddTarget = Guid.NewGuid();
            await Task.FromResult(_modalAdd.Open(_modalAddTarget));
            await Task.CompletedTask;
        }

        private async Task HandleValidSubmitAsync()
        {
            _displayValidationErrorMessages = false;

            await _labelMopService.AddLabelMopAsync(_labelMop);
            await OnSubmitSuccess.InvokeAsync();

            _toastService.ShowToast("Label added!", Level.Success);

            await Task.Delay((int)Delay.DataSuccess);

            await CloseModalAddAsync();
            await Task.CompletedTask;
        }

        private async Task HandleInvalidSubmitAsync()
        {
            await Task.FromResult(_displayValidationErrorMessages = true);
            await Task.CompletedTask;
        }

        private async Task CloseModalAddAsync()
        {
            _labelMop = new LabelMop();
            await Task.FromResult(_modalAdd.Close(_modalAddTarget));
            await Task.CompletedTask;
        }

        private async Task GenerateBarcodeAsync()
        {
            ShortGuid sguid = ShortGuid.NewGuid();
            await Task.FromResult(_labelMop.Barcode = sguid);
            await Task.CompletedTask;
        }
    }
}