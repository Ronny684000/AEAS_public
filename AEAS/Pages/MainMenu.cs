using System.Drawing;
using Bunifu.UI.WinForms;
using Bunifu.Framework.UI;
using AEAS.Properties;

namespace AEAS.Pages
{
    internal class MainMenu : AbstractPage
    {
        private static MainMenu _instance;
        public BunifuTileButton EstimateExperts { get; set; }

        private MainMenu(Size size, Point location) : base(size, location)
        {
            EstimateExperts = new BunifuTileButton();
            EstimateExperts.Location = new Point(2, 0);
            EstimateExperts.Size = new Size(210, 190);
            EstimateExperts.Image = Resources.planning;
            EstimateExperts.ImageZoom = 60;
            EstimateExperts.Font = new Font("Century Gothic", 12);
            EstimateExperts.LabelText = "Оценить экспертов";
            SetUp();
        }

        public static MainMenu GetInstance(Size size, Point location)
        {
            if (_instance == null)
            {
                _instance = new MainMenu(size, location);
            }
            return _instance;
        }

        public override void SetUp()
        {
            Canvas.Controls.Add(EstimateExperts);
        }
    }
}
