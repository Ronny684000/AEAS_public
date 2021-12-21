using System.Drawing;
using System.Windows.Forms;
using Bunifu.UI.WinForms;

namespace AEAS.QuestionUtils
{
    internal class QuestionBodyFillWord : QuestionBody
    {
        public BunifuTextBox TxbRequired { get; set; }
        public BunifuLabel LblInstruction { get; set; }

        public QuestionBodyFillWord(Size size, Point location) : base(size, location)
        {
            TxbRequired = new BunifuTextBox();
            TxbRequired.Location = new Point(469, 65);
            TxbRequired.Size = new Size(170, 37);
            LblInstruction = SetLabel(new BunifuLabel(), new Font("Segoe UI", 11), new Size(450, 135),
                new Point(13, 18), "Вставьте слово на место пропуска...");
            SetControls();
        }

        private void SetControls()
        {
            BodyPanel.Controls.AddRange(new Control[] { TxbRequired, LblInstruction });
        }

        private BunifuLabel SetLabel(BunifuLabel label, Font font, Size size, Point location, string text)
        {
            label.Font = font;
            label.TextAlignment = ContentAlignment.MiddleCenter;
            label.AutoSize = false;
            label.Size = size;
            label.Location = location;
            label.Text = text;
            return label;
        }

        public override bool Check()
        {
            return TxbRequired.Text == Answer;
        }
    }
}
