using System;
using MyApp.Settings.Enum;

namespace MyApp.Components.Toast
{
    public interface IToastService
    {
        public event Action<string, Level> OnShow;
        public event Action OnHide;
        public void ShowToast(string message, Level level);
    }
}
