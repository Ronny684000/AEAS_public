using System.Drawing;
using Bunifu.UI.WinForms;

namespace AEAS.QuestionUtils
{
    internal class QuestionText
    {
        public BunifuPanel BodyPanel { get; set; }
        public BunifuLabel Text { get; set; }

        public QuestionText(Size size, Point location, string text)
        {
            BodyPanel = new BunifuPanel();
            Text = SetLabel(new BunifuLabel(), new Font("Segoe UI", 12, FontStyle.Bold),
                new Size(586, 108), new Point(45, 17), Color.White, text);
            BodyPanel.ShowBorders = false;
            BodyPanel.BackgroundColor = Color.FromArgb(40, 96, 144);
            BodyPanel.Size = size;
            BodyPanel.Location = location;
            BodyPanel.Controls.Add(Text);
        }

        public BunifuPanel GetBody()
        {
            return BodyPanel;
        }

        private BunifuLabel SetLabel(BunifuLabel label, Font font, Size size, Point location, Color forecolor, string text)
        {
            label.Font = font;
            label.TextAlignment = ContentAlignment.MiddleCenter;
            label.ForeColor = forecolor;
            label.AutoSize = false;
            label.Size = size;
            label.Location = location;
            label.Text = text;
            return label;
        }

        public string GetText()
        {
            return Text.Text;
        }
    }
}
