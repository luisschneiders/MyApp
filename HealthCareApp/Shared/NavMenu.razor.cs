using System;
namespace HealthCareApp.Shared
{
    public partial class NavMenu
    {
        private enum NavSubmenu
        {
            None,
            First,
            Second
        };

        private bool collapseNavMenu = true;
        private bool collapseNavSubmenu = true;

        private string NavMenuCssClass => collapseNavMenu ? "collapse" : null;
        private string NavSubmenuIcon => collapseNavSubmenu ? "bi-chevron-expand" : "bi-chevron-contract";
        private NavSubmenu navSubmenu = NavSubmenu.None;


        private void ToggleNavMenu()
        {
            collapseNavMenu = !collapseNavMenu;
        }

        private void ToggleNavSubmenu(NavSubmenu submenu)
        {
            collapseNavSubmenu = !collapseNavSubmenu;

            if (navSubmenu == submenu)
            {
                navSubmenu = NavSubmenu.None;
            }
            else
            {
                navSubmenu = submenu;
            }
        }
    }
}
