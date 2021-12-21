using System;
using System.Windows.Forms;
using AEAS.Pages;
using static AEAS.Pages.NavPanelHandler;
using AEAS.Pages.Enum;
using MainMenu = AEAS.Pages.MainMenu;

namespace AEAS
{
    public partial class frmWelcome : Form
    {
        private AuthPage AuthPage { get; set; } = AuthPage.GetInstance(PageSizeMap.Standard, PageLocationMap.Standard);
        private MainMenu MenuPage { get; set; } = MainMenu.GetInstance(PageSizeMap.Standard, PageLocationMap.Standard);
        private NavPanel NavPanel { get; set; } = NavPanel.GetInstance();
        public frmWelcome()
        {
            InitializeComponent();
        }

        private void frmWelcome_Load(object sender, EventArgs e)
        {
            AuthPage.Get().Visible = true;
            Controls.Add(AuthPage.Get());
            Controls.Add(MenuPage.Get());
            Controls.Add(NavPanel.Get());
            SetAuthActive(NavPanel);
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            WndProc(ref m);
        }
    }
}
