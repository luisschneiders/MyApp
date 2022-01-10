using System;
namespace HealthCareApp.Components.Toast
{
    public interface IToastService
    {
        public event Action<string, ToastLevel> OnShow;
        public event Action OnHide;
        public void ShowToast(string message, ToastLevel level);
    }
}
