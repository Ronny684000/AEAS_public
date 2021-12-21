using System;
using System.Drawing;
using System.Windows.Forms;
using AEAS.Properties;
using Bunifu.UI.WinForms;

namespace AEAS.Pages
{
    internal class NavPanel
    {
        private static NavPanel _instance;
        public BunifuPanel Body { get; set; }
        public BunifuImageButton MainMenu { get; set; }
        public BunifuImageButton AuthMenu { get; set; }
        public BunifuImageButton Exit { get; set; }

        private NavPanel()
        {
            Body = new BunifuPanel();
            Body.Size = new Size(737, 55);
            Body.Location = new Point(0, 0);
            MainMenu = new BunifuImageButton();
            AuthMenu = new BunifuImageButton();
            Exit = new BunifuImageButton();
            Body.Controls.Add(MainMenu);
            Body.Controls.Add(AuthMenu);
            Body.Controls.Add(Exit);
            MainMenu.Size = new Size(35, 35);
            AuthMenu.Size = new Size(35, 35);
            Exit.Size = new Size(35, 35);
            MainMenu.ImageMargin = 7;
            AuthMenu.ImageMargin = 7;
            Exit.ImageMargin = 7;
            MainMenu.Location = new Point(54, 10);
            AuthMenu.Location = new Point(13, 10);
            Exit.Location = new Point(689, 10);
            MainMenu.Image = Resources.main_menu;
            AuthMenu.Image = Resources.authorization;
            Exit.Image = Resources.close;
            Exit.Click += ApplicationExit;
        }

        public static NavPanel GetInstance()
        {
            if (_instance == null)
            {
                _instance = new NavPanel();
            }
            return _instance;
        }

        public BunifuPanel Get()
        {
            return Body;
        }

        private void ApplicationExit(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
