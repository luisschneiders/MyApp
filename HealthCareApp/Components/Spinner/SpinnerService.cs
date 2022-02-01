using System;
namespace HealthCareApp.Components.Spinner
{
    public class SpinnerService : ISpinnerService
    {
        public event Action OnShow;
        public event Action OnHide;

        public void ShowSpinner()
        {
            OnShow?.Invoke();
        }

        public void HideSpinner()
        {
            OnHide?.Invoke();
        }
    }
}
