using System;
using AreaLibrary.Models;
using DepartmentLibrary.Models;
using EmployeeLibrary.Models;
using HealthCareApp.Components.OffCanvas;
using HealthCareApp.Components.Toast;
using HealthCareApp.Data;
using HealthCareApp.Settings.Enum;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Pages.DepartmentPage
{
    public partial class AreaOffCanvas : ComponentBase
    {

        [Inject]
        private AreaService _areaService { get; set; } = default!;

        [Inject]
        private DepartmentService _departmentService { get; set; } = default!;

        [Inject]
        private ToastService _toastService { get; set; }

        [Parameter]
        public EventCallback OnSubmitSuccess { get; set; }

        private OffCanvas _offCanvas { get; set; }
        private Guid _offCanvasTarget { get; set; }

        private Area _area { get; set; }

        private List<Department> _departments { get; set; }

        private OffCanvasViewType _offCanvasViewType { get; set; }

        private string _badgeBackground { get; set; }

        private bool _displayValidationErrorMessages { get; set; }
        private bool _isDisabled { get; set; }

        public AreaOffCanvas()
        {
            _toastService = new();
            _offCanvas = new();
            _area = new();
            _departments = new List<Department>();
            _badgeBackground = Level.Info.ToString().ToLower();
            _displayValidationErrorMessages = false;
            _isDisabled = true;
        }

        protected override async Task OnInitializedAsync()
        {
            _departments = await _departmentService.GetDepartmentsAsync();

            if (_area.DepartmentId == Guid.Empty)
            {
                _isDisabled = true;
            }

            await Task.CompletedTask;
        }

        public async Task AddRecordOffCanvasAsync()
        {
            _area = new();
            _isDisabled = true;
            await Task.FromResult(SetOffCanvasState(OffCanvasViewType.Add, Level.Success));

            await Task.FromResult(_offCanvas.Open(Guid.NewGuid()));
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

        public async Task RefreshDepartmentList()
        {
            _departments = await _departmentService.GetDepartmentsAsync();
            await Task.CompletedTask;
        }

        private async Task SetOffCanvasState(OffCanvasViewType offCanvasViewType, Level level)
        {
            _offCanvasViewType = offCanvasViewType;
            _badgeBackground = level.ToString().ToLower();

            await Task.CompletedTask;
        }

        private async Task UpdateFormState(OffCanvasViewType offCanvasViewType, Level level)
        {
            await Task.FromResult(SetOffCanvasState(offCanvasViewType, level));
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

        private async Task HandleValidSubmitAsync()
        {
            _displayValidationErrorMessages = false;

            if (_offCanvasViewType == OffCanvasViewType.Add)
            {
                await _areaService.AddAreaAsync(_area);

                _toastService.ShowToast("Area added!", Level.Success);
            }
            else if (_offCanvasViewType == OffCanvasViewType.Edit)
            {
                await _areaService.UpdateAreaAsync(_area);

                _toastService.ShowToast("Area updated!", Level.Success);
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

        private async Task SetOffCanvasInfo(Guid id)
        {
            _offCanvasTarget = id;
            _area = _areaService.GetAreaById(id);
            _isDisabled = false;
            await Task.CompletedTask;
        }

        private async Task CloseOffCanvasAsync()
        {
            _area = new Area();
            _isDisabled = true;

            await Task.FromResult(_offCanvas.Close(_offCanvasTarget));
            await Task.CompletedTask;
        }
    }
}
