using System;
namespace HealthCareApp.Shared
{
    public partial class NavMenu
    {
        private enum NavSubmenu
        {
            None,
            Settings,
            Playground,
            Api
        };

        private bool _collapseNavMenu { get; set; }
        private bool _collapseNavSubmenu { get; set; }

        private NavSubmenu _navSubmenu { get; set; }

        private string _navMenuCssClass => _collapseNavMenu ? "collapse" : string.Empty;

        public NavMenu()
        {
            _collapseNavMenu = true;
            _collapseNavSubmenu = true;
            _navSubmenu = NavSubmenu.None;
        }


        private void ToggleNavMenu()
        {
            _collapseNavMenu = !_collapseNavMenu;
        }

        private void ToggleNavSubmenu(NavSubmenu submenu)
        {
            _collapseNavSubmenu = !_collapseNavSubmenu;

            if (_navSubmenu == submenu)
            {
                _navSubmenu = NavSubmenu.None;
            }
            else
            {
                _navSubmenu = submenu;
            }
        }
    }
}
