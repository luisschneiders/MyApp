using System;
using System.Timers;
using HealthCareApp.Settings.Enum;

namespace HealthCareApp.Components.Toast
{
    public class ToastService : IToastService, IDisposable
    {
        public event Action<string, Level> OnShow;
        public event Action OnHide;
        private Timer Countdown;

        public void ShowToast(string message, Level level)
        {
            OnShow?.Invoke(message, level);
            StartCountDown();
        }

        private void StartCountDown()
        {
            SetCountDown();
            if (Countdown.Enabled)
            {
                Countdown.Stop();
                Countdown.Start();
            }
            else
            {
                Countdown.Start();
            }
        }

        private void SetCountDown()
        {
            if (Countdown == null)
            {
                Countdown = new Timer(2500);
                Countdown.Elapsed += HideToast;
                Countdown.AutoReset = false;
            }
        }

        private void HideToast(object source, ElapsedEventArgs args)
        {
            OnHide?.Invoke();
        }

        public void Dispose()
        {
            Countdown?.Dispose();
        }

    }
}
