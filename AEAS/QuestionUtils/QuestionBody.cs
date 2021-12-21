using Bunifu.UI.WinForms;
using System.Drawing;

namespace AEAS.QuestionUtils
{
    internal abstract class QuestionBody
    {
        public BunifuPanel BodyPanel { get; set; }
        public string Answer { get; set; }

        public QuestionBody(Size size, Point location)
        {
            BodyPanel = new BunifuPanel();
            BodyPanel.ShowBorders = false;
            BodyPanel.Size = size;
            BodyPanel.Location = location;
        }
        public BunifuPanel GetBody()
        {
            return BodyPanel;
        }

        public abstract bool Check();
    }
}
