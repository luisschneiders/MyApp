using System;
using AreaLibrary.Models;
using CSharpVitamins;
using DepartmentLibrary.Models;
using EmployeeLibrary.Models;
using HealthCareApp.Components.OffCanvas;
using HealthCareApp.Components.Toast;
using HealthCareApp.Data;
using HealthCareApp.Settings.Enum;
using LabelLibrary.Models;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Pages.BarcodePage
{
    public partial class BarcodeMopOffCanvas : ComponentBase
    {

        [Inject]
        private LabelMopService _labelMopService { get; set; } = default!;

        [Inject]
        private AreaService _areaService { get; set; } = default!;

        [Inject]
        private ToastService _toastService { get; set; }

        [Parameter]
        public EventCallback OnSubmitSuccess { get; set; }

        private OffCanvas _offCanvas { get; set; }
        private Guid _offCanvasTarget { get; set; }

        private LabelMop _labelMop { get; set; }
        private List<AreaDto> _areas { get; set; }

        private ShiftType[] _shiftTypes { get; set; } = default!;
        private OffCanvasViewType _offCanvasViewType { get; set; }
        private string _badgeBackground { get; set; }

        private bool _displayValidationErrorMessages { get; set; }
        private bool _isDisabled { get; set; }
        private bool _recordExists { get; set; }

        public BarcodeMopOffCanvas()
        {
            _toastService = new();
            _offCanvas = new();
            _labelMop = new();
            _areas = new List<AreaDto>();
            _shiftTypes = (ShiftType[])Enum.GetValues(typeof(ShiftType));
            _badgeBackground = Level.Info.ToString().ToLower();
            _displayValidationErrorMessages = false;
            _isDisabled = true;
            _recordExists = true;
        }

        public async Task AddRecordOffCanvasAsync()
        {
            _labelMop = new();

            await Task.FromResult(SetOffCanvasState(OffCanvasViewType.Add, Level.Success));

            await Task.FromResult(_offCanvas.Open(Guid.NewGuid()));
            await Task.CompletedTask;
        }

        private async Task SetOffCanvasState(OffCanvasViewType offCanvasViewType, Level level)
        {
            _offCanvasViewType = offCanvasViewType;
            _badgeBackground = level.ToString().ToLower();

            await Task.CompletedTask;
        }

        private async Task HandleValidSubmitAsync()
        {
            _displayValidationErrorMessages = false;

            if (_offCanvasViewType == OffCanvasViewType.Add)
            {

                _recordExists = await _labelMopService.CheckRecordExists(_labelMop.Barcode!);

                if (_recordExists)
                {
                    _toastService.ShowToast("Barcode already exists!", Level.Danger);
                    return;
                }
                else
                {
                    await _labelMopService.AddLabelMopAsync(_labelMop);

                    _toastService.ShowToast("Barcode added!", Level.Success);
                }

            }
            else if (_offCanvasViewType == OffCanvasViewType.Edit)
            {
                await _labelMopService.UpdateLabelMopAsync(_labelMop);

                _toastService.ShowToast("Barcode updated!", Level.Success);
            }

            await OnSubmitSuccess.InvokeAsync();

            await Task.Delay((int)Delay.DataSuccess);

            await CloseOffCanvasAsync();
            await Task.CompletedTask;

        }

        private async Task HandleInvalidSubmitAsync()
        {
            await Task.FromResult(_displayValidationErrorMessages = true);
            await Task.CompletedTask;
        }

        private async Task CloseOffCanvasAsync()
        {
            _labelMop = new();

            await Task.FromResult(_offCanvas.Close(_offCanvasTarget));
            await Task.CompletedTask;
        }

        private async Task UpdateFormState(OffCanvasViewType offCanvasViewType, Level level)
        {
            await Task.FromResult(SetOffCanvasState(offCanvasViewType, level));
            await Task.CompletedTask;
        }

        public async Task ViewDetailsOffCanvasAsync(Guid id)
        {
            await Task.FromResult(SetOffCanvasState(OffCanvasViewType.View, Level.Info));
            await Task.FromResult(SetOffCanvasInfo(id));

            await Task.FromResult(_offCanvas.Open(_offCanvasTarget));
            await Task.CompletedTask;
        }

        public async Task EditDetailsOffCanvasAsync(Guid id)
        {
            await Task.FromResult(SetOffCanvasState(OffCanvasViewType.Edit, Level.Danger));
            await Task.FromResult(SetOffCanvasInfo(id));

            await Task.FromResult(_offCanvas.Open(_offCanvasTarget));
            await Task.CompletedTask;
        }

        private async Task SetOffCanvasInfo(Guid id)
        {
            _offCanvasTarget = id;
            _labelMop = _labelMopService.GetLabelMopById(id);

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

        protected override async Task OnInitializedAsync()
        {
            /*
             * TODO: list all areas and add disabled attribute in the select input field
             */
            _areas = await _areaService.GetAreasAsync();

            if (_labelMop.AreaId == Guid.Empty)
            {
                _isDisabled = true;
            }

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
