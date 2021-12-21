using Bunifu.UI.WinForms;
using System.Drawing;
using System.Windows.Forms;

namespace AEAS.QuestionUtils
{
    internal class QuestionBodySeveral : QuestionBody
    {
        public BunifuCheckBox CbxVariant1 { get; set; }
        public BunifuCheckBox CbxVariant2 { get; set; }
        public BunifuCheckBox CbxVariant3 { get; set; }
        public BunifuCheckBox CbxVariant4 { get; set; }
        public BunifuLabel LblVariant1 { get; set; }
        public BunifuLabel LblVariant2 { get; set; }
        public BunifuLabel LblVariant3 { get; set; }
        public BunifuLabel LblVariant4 { get; set; }

        public QuestionBodySeveral(Size size, Point location, string[] variants) 
            : base(size, location)
        {
            CbxVariant1 = new BunifuCheckBox();
            CbxVariant1.Name = variants[0];
            CbxVariant2 = new BunifuCheckBox();
            CbxVariant2.Name = variants[1];
            CbxVariant3 = new BunifuCheckBox();
            CbxVariant3.Name = variants[2];
            CbxVariant4 = new BunifuCheckBox();
            CbxVariant4.Name = variants[3];
            LblVariant1 = SetLabel(new BunifuLabel(), new Font("Segoe UI", 10),
                new Size(609, 21), new Point(53, 13), variants[0]);
            LblVariant2 = SetLabel(new BunifuLabel(), new Font("Segoe UI", 10),
                new Size(609, 21), new Point(53, 53), variants[1]);
            LblVariant3 = SetLabel(new BunifuLabel(), new Font("Segoe UI", 10),
                new Size(609, 21), new Point(53, 93), variants[2]);
            LblVariant4 = SetLabel(new BunifuLabel(), new Font("Segoe UI", 10),
                new Size(609, 21), new Point(53, 133), variants[3]);
            CbxVariant1.Location = new Point(13, 13);
            CbxVariant2.Location = new Point(13, 53);
            CbxVariant3.Location = new Point(13, 93);
            CbxVariant4.Location = new Point(13, 133);
            CbxVariant1.Checked = false;
            CbxVariant2.Checked = false;
            CbxVariant3.Checked = false;
            CbxVariant4.Checked = false;
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
            BodyPanel.Controls.AddRange(new Control[] {CbxVariant1, CbxVariant2, CbxVariant3, CbxVariant4,
            LblVariant1, LblVariant2, LblVariant3, LblVariant4});
        }

        public override bool Check()
        {
            bool ckr1 = true;
            bool ckr2 = true;
            bool ckr3 = true;
            bool ckr4 = true;
            string[] rAnswerList = Answer.Split(';');
            foreach (var ans in rAnswerList)
            {

                if(CbxVariant1.Name == ans && CbxVariant1.Checked || CbxVariant1.Name != ans && !CbxVariant1.Checked)
                {
                    ckr1 = true;
                }
                else
                {
                    ckr1 = false;
                }
                if (CbxVariant2.Name == ans && CbxVariant2.Checked || CbxVariant2.Name != ans && !CbxVariant2.Checked)
                {
                    ckr2 = true;
                }
                else
                {
                    ckr2 = false;
                }
                if (CbxVariant3.Name == ans && CbxVariant3.Checked || CbxVariant3.Name != ans && !CbxVariant3.Checked)
                {
                    ckr3 = true;
                }
                else
                {
                    ckr3 = false;
                }
                if (CbxVariant4.Name == ans && CbxVariant4.Checked || CbxVariant4.Name != ans && !CbxVariant4.Checked)
                {
                    ckr4 = true;
                }
                else
                {
                    ckr4 = false;
                }
            }
            return ckr1 && ckr2 && ckr3 && ckr4;
        }
    }
}
