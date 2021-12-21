using AEAS.Properties;

namespace AEAS.Pages
{
    internal class NavPanelHandler
    {
        public static void SetMenuActive(NavPanel nav)
        {
            nav.MainMenu.Image = Resources.main_menu_active;
            nav.AuthMenu.Image = Resources.authorization;
        }

        public static void SetAuthActive(NavPanel nav)
        {
            nav.MainMenu.Image = Resources.main_menu;
            nav.AuthMenu.Image = Resources.authorization_active;
        }
    }
}
