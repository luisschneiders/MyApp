using System;
using AreaLibrary.Models;
using CSharpVitamins;
using DepartmentLibrary.Models;
using HealthCareApp.Components.Modal;
using HealthCareApp.Components.Toast;
using HealthCareApp.Data;
using HealthCareApp.Settings.Enum;
using LabelLibrary.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace HealthCareApp.Pages.BarcodePage
{
	public partial class LabelMopModalAdd : ComponentBase
	{
        [Inject]
        private LabelMopService _labelMopService { get; set; } = default!;

        [Inject]
        private AreaService _areaService { get; set; } = default!;

        [Inject]
        private ToastService _toastService { get; set; }

        [Parameter]
        public EventCallback OnSubmitSuccess { get; set; }

        private Modal _modalAdd { get; set; }

        private Guid _modalAddTarget { get; set; }

        private LabelMop _labelMop { get; set; }

        private List<AreaDto> _areas { get; set; }

        private bool _displayValidationErrorMessages { get; set; }
        private bool _isDisabled { get; set; }

        public LabelMopModalAdd()
		{
            _toastService = new();
            _modalAdd = new();
            _labelMop = new();
            _areas = new List<AreaDto>();
            _isDisabled = true;
        }

        protected override async Task OnInitializedAsync()
        {
            _areas = await _areaService.GetActiveAreasAsync();

            if (_labelMop.AreaId == Guid.Empty)
            {
                _isDisabled = true;
            }

            await Task.CompletedTask;
        }

        private void OnValueChanged(ChangeEventArgs args)
        {
            var valueChanged = args?.Value?.ToString();

            if (string.IsNullOrEmpty(valueChanged) || new Guid(valueChanged) == Guid.Empty) 
            {
                _isDisabled = true;
            }
            else
            {
                _isDisabled = false;
            }
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
            _isDisabled = true;
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
