using System.Drawing;
using Bunifu.UI.WinForms;
using System.Windows.Forms;

namespace AEAS.QuestionUtils
{
    internal class QuestionBodySingle : QuestionBody
    {
        public BunifuRadioButton RbVariant1 { get; set; }
        public BunifuRadioButton RbVariant2 { get; set; }
        public BunifuRadioButton RbVariant3 { get; set; }
        public BunifuRadioButton RbVariant4 { get; set; }
        public BunifuLabel LblVariant1 { get; set; }
        public BunifuLabel LblVariant2 { get; set; }
        public BunifuLabel LblVariant3 { get; set; }
        public BunifuLabel LblVariant4 { get; set; }

        public QuestionBodySingle(Size size, Point location, string[] variants)
            : base(size, location)
        {
            RbVariant1 = new BunifuRadioButton();
            RbVariant1.Name = variants[0];
            RbVariant2 = new BunifuRadioButton();
            RbVariant2.Name = variants[1];
            RbVariant3 = new BunifuRadioButton();
            RbVariant3.Name = variants[2];
            RbVariant4 = new BunifuRadioButton();
            RbVariant4.Name = variants[3];
            LblVariant1 = SetLabel(new BunifuLabel(), new Font("Segoe UI", 10),
                new Size(609, 21), new Point(53, 13), variants[0]);
            LblVariant2 = SetLabel(new BunifuLabel(), new Font("Segoe UI", 10),
                new Size(609, 21), new Point(53, 53), variants[1]);
            LblVariant3 = SetLabel(new BunifuLabel(), new Font("Segoe UI", 10),
                new Size(609, 21), new Point(53, 93), variants[2]);
            LblVariant4 = SetLabel(new BunifuLabel(), new Font("Segoe UI", 10),
                new Size(609, 21), new Point(53, 133), variants[3]);
            RbVariant1.Location = new Point(13, 13);
            RbVariant2.Location = new Point(13, 53);
            RbVariant3.Location = new Point(13, 93);
            RbVariant4.Location = new Point(13, 133);
            SetControls();
        }

        private BunifuLabel SetLabel(BunifuLabel label, Font font, Size size, Point location, string text)
        {
            label.Font = font;
            label.TextAlignment = ContentAlignment.MiddleLeft;
            label.AutoSize = false;
            label.Size = size;
            label.Location = location;
            label.Text = text;
            return label;
        }

        private void SetControls()
        {
            BodyPanel.Controls.AddRange(new Control[] {RbVariant1, RbVariant2, RbVariant3, RbVariant4,
            LblVariant1, LblVariant2, LblVariant3, LblVariant4});
        }

        public override bool Check()
        {
            BunifuRadioButton rAnswer = (BunifuRadioButton)BodyPanel.Controls[Answer];
            return rAnswer.Checked;
        }
    }
}
