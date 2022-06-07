using AreaLibrary.Models;
using CSharpVitamins;
using DepartmentLibrary.Models;
using HealthCareApp.Components.Modal;
using HealthCareApp.Components.Toast;
using HealthCareApp.Data;
using HealthCareApp.Settings.Enum;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Pages.AreaPage
{
	public partial class AreaModalAdd : ComponentBase
	{
        [Inject]
        private AreaService _areaService { get; set; } = default!;

        [Inject]
        private DepartmentService _departmentService { get; set; } = default!;

        [Inject]
        private ToastService _toastService { get; set; }

        [Parameter]
        public EventCallback OnSubmitSuccess { get; set; }

        private Modal _modalAdd { get; set; }

        private Guid _modalAddTarget { get; set; }

        private Area _area { get; set; }

        private List<Department> _departments { get; set; }

        private bool _displayValidationErrorMessages { get; set; }
        private bool _isDisabled { get; set; }

        public AreaModalAdd()
		{
            _toastService = new();
            _modalAdd = new();
            _area = new();
            _departments = new List<Department>();
            _isDisabled = true;
        }

        protected override async Task OnInitializedAsync()
        {
            _departments = await _departmentService.GetActiveDepartmentsAsync();

            if (_area.DepartmentId == Guid.Empty)
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

            await _areaService.AddAreaAsync(_area);
            await OnSubmitSuccess.InvokeAsync();

            _toastService.ShowToast("Area added!", Level.Success);

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
            _area = new Area();
            _isDisabled = true;
            await Task.FromResult(_modalAdd.Close(_modalAddTarget));
            await Task.CompletedTask;
        }
    }
}
