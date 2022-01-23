using System;
using HealthCareApp.Settings.Enum;

namespace HealthCareApp.Components.Toast
{
    public interface IToastService
    {
        public event Action<string, Level> OnShow;
        public event Action OnHide;
        public void ShowToast(string message, Level level);
    }
}
