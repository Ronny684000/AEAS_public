using System.Drawing;
using System.Windows.Forms;
using Bunifu.UI.WinForms.BunifuAnimatorNS;
using Bunifu.UI.WinForms;

namespace AEAS.Pages
{
    internal abstract class AbstractPage
    {
        public Panel Canvas { get; set; }

        public AbstractPage(Size size, Point location)
        {
            Canvas = new Panel();
            Canvas.Size = size;
            Canvas.Location = location;
            Canvas.BackColor = Color.Transparent;
            Canvas.Visible = false;
        }

        public abstract void SetUp();

        public Panel Get()
        {
            return Canvas;
        }

        public void SwitchTo(AbstractPage nextPage)
        {
            BunifuTransition tr = new BunifuTransition();
            tr.HideSync(Get(), false, Animation.HorizSlide);
            tr.ShowSync(nextPage.Get(), false, Animation.HorizSlide);
        }
    }
}
