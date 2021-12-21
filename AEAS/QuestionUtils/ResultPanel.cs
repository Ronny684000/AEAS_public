using Bunifu.UI.WinForms;
using Bunifu.UI.WinForms.BunifuButton;

namespace AEAS.QuestionUtils
{
    internal class ResultPanel
    {

        public BunifuPanel Body { get; set; }
        public BunifuPanel ResultBody { get; set; }
        public BunifuLabel Header { get; set; }
        public BunifuLabel MetricFormName { get; set; }
        public BunifuLabel MetricTestName { get; set; }
        public BunifuHSlider ProgressBarForm { get; set; }
        public BunifuHSlider ProgressBarTest { get; set; }
        public BunifuLabel PersentageForm { get; set; }
        public BunifuLabel PersentageTest { get; set; }
        public BunifuButton OK { get; set; }

        public ResultPanel(float formRes, float testRes)
        {
            Body = new BunifuPanel();
            ResultBody = new Bunifu.UI.WinForms.BunifuPanel();
            Header = new Bunifu.UI.WinForms.BunifuLabel();
            MetricFormName = new Bunifu.UI.WinForms.BunifuLabel();
            MetricTestName = new Bunifu.UI.WinForms.BunifuLabel();
            ProgressBarForm = new Bunifu.UI.WinForms.BunifuHSlider();
            ProgressBarTest = new Bunifu.UI.WinForms.BunifuHSlider();
            PersentageForm = new Bunifu.UI.WinForms.BunifuLabel();
            PersentageTest = new Bunifu.UI.WinForms.BunifuLabel();
            OK = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            Body.SuspendLayout();
            ResultBody.SuspendLayout();
            // 
            // Body
            // 
            Body.BackgroundColor = System.Drawing.Color.Transparent;
            Body.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            Body.BorderColor = System.Drawing.Color.Transparent;
            Body.BorderRadius = 3;
            Body.BorderThickness = 1;
            Body.Controls.Add(Header);
            Body.Controls.Add(ResultBody);
            Body.Location = new System.Drawing.Point(12, 12);
            Body.Name = "Body";
            Body.ShowBorders = true;
            Body.Size = new System.Drawing.Size(727, 424);
            Body.TabIndex = 0;
            Body.Visible = false;
            // 
            // ResultBody
            // 
            ResultBody.BackgroundColor = System.Drawing.Color.LightBlue;
            ResultBody.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ResultBody.BorderColor = System.Drawing.Color.Transparent;
            ResultBody.BorderRadius = 3;
            ResultBody.BorderThickness = 1;
            ResultBody.Controls.Add(OK);
            ResultBody.Controls.Add(PersentageTest);
            ResultBody.Controls.Add(PersentageForm);
            ResultBody.Controls.Add(ProgressBarTest);
            ResultBody.Controls.Add(ProgressBarForm);
            ResultBody.Controls.Add(MetricTestName);
            ResultBody.Controls.Add(MetricFormName);
            ResultBody.Location = new System.Drawing.Point(28, 105);
            ResultBody.Name = "ResultBody";
            ResultBody.ShowBorders = true;
            ResultBody.Size = new System.Drawing.Size(671, 316);
            ResultBody.TabIndex = 1;
            // 
            // Header
            // 
            Header.AllowParentOverrides = false;
            Header.AutoEllipsis = false;
            Header.AutoSize = false;
            Header.BackColor = System.Drawing.Color.SteelBlue;
            Header.CursorType = System.Windows.Forms.Cursors.Default;
            Header.Font = new System.Drawing.Font("Century Gothic", 12F);
            Header.ForeColor = System.Drawing.Color.White;
            Header.Location = new System.Drawing.Point(28, 18);
            Header.Name = "Header";
            Header.RightToLeft = System.Windows.Forms.RightToLeft.No;
            Header.Size = new System.Drawing.Size(671, 81);
            Header.TabIndex = 2;
            Header.Text = "Результаты";
            Header.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            Header.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // MetricFormName
            // 
            MetricFormName.AllowParentOverrides = false;
            MetricFormName.AutoEllipsis = false;
            MetricFormName.AutoSize = false;
            MetricFormName.CursorType = System.Windows.Forms.Cursors.Default;
            MetricFormName.Font = new System.Drawing.Font("Century Gothic", 12F);
            MetricFormName.ForeColor = System.Drawing.Color.SteelBlue;
            MetricFormName.Location = new System.Drawing.Point(46, 35);
            MetricFormName.Name = "MetricFormName";
            MetricFormName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            MetricFormName.Size = new System.Drawing.Size(381, 23);
            MetricFormName.TabIndex = 0;
            MetricFormName.Text = "Анкета самооценки";
            MetricFormName.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            MetricFormName.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // MetricTestName
            // 
            MetricTestName.AllowParentOverrides = false;
            MetricTestName.AutoEllipsis = false;
            MetricTestName.AutoSize = false;
            MetricTestName.CursorType = null;
            MetricTestName.Font = new System.Drawing.Font("Century Gothic", 12F);
            MetricTestName.ForeColor = System.Drawing.Color.SteelBlue;
            MetricTestName.Location = new System.Drawing.Point(46, 134);
            MetricTestName.Name = "MetricTestName";
            MetricTestName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            MetricTestName.Size = new System.Drawing.Size(381, 23);
            MetricTestName.TabIndex = 1;
            MetricTestName.Text = "Тест профпригодности";
            MetricTestName.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            MetricTestName.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // ProgressBarForm
            // 
            ProgressBarForm.AllowCursorChanges = true;
            ProgressBarForm.AllowHomeEndKeysDetection = false;
            ProgressBarForm.AllowIncrementalClickMoves = true;
            ProgressBarForm.AllowMouseDownEffects = false;
            ProgressBarForm.AllowMouseHoverEffects = false;
            ProgressBarForm.AllowScrollingAnimations = true;
            ProgressBarForm.AllowScrollKeysDetection = true;
            ProgressBarForm.AllowScrollOptionsMenu = true;
            ProgressBarForm.AllowShrinkingOnFocusLost = false;
            ProgressBarForm.BackColor = System.Drawing.Color.Transparent;
            ProgressBarForm.BindingContainer = null;
            ProgressBarForm.BorderRadius = 1;
            ProgressBarForm.BorderThickness = 1;
            ProgressBarForm.Cursor = System.Windows.Forms.Cursors.Hand;
            ProgressBarForm.DrawThickBorder = true;
            ProgressBarForm.DurationBeforeShrink = 2000;
            ProgressBarForm.ElapsedColor = System.Drawing.Color.SteelBlue;
            ProgressBarForm.LargeChange = 10;
            ProgressBarForm.Location = new System.Drawing.Point(46, 64);
            ProgressBarForm.Maximum = 100;
            ProgressBarForm.Minimum = 0;
            ProgressBarForm.MinimumSize = new System.Drawing.Size(0, 31);
            ProgressBarForm.MinimumThumbLength = 18;
            ProgressBarForm.Name = "bunifuHSlider1";
            ProgressBarForm.OnDisable.ScrollBarBorderColor = System.Drawing.Color.Silver;
            ProgressBarForm.OnDisable.ScrollBarColor = System.Drawing.Color.Transparent;
            ProgressBarForm.OnDisable.ThumbColor = System.Drawing.Color.Silver;
            ProgressBarForm.ScrollBarBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            ProgressBarForm.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            ProgressBarForm.ShrinkSizeLimit = 3;
            ProgressBarForm.Size = new System.Drawing.Size(590, 31);
            ProgressBarForm.SliderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            ProgressBarForm.SliderStyle = Bunifu.UI.WinForms.BunifuHSlider.SliderStyles.Thick;
            ProgressBarForm.SliderThumbStyle = Utilities.BunifuSlider.BunifuHScrollBar.SliderThumbStyles.Circular;
            ProgressBarForm.SmallChange = 1;
            ProgressBarForm.TabIndex = 7;
            ProgressBarForm.ThumbColor = System.Drawing.Color.SteelBlue;
            ProgressBarForm.ThumbFillColor = System.Drawing.SystemColors.Control;
            ProgressBarForm.ThumbLength = 58;
            ProgressBarForm.ThumbMargin = 1;
            ProgressBarForm.ThumbSize = Bunifu.UI.WinForms.BunifuHSlider.ThumbSizes.Small;
            ProgressBarForm.ThumbStyle = Bunifu.UI.WinForms.BunifuHSlider.ThumbStyles.Outline;
            ProgressBarForm.Value = (int)formRes;
            // 
            // bunifuHSlider2
            // 
            ProgressBarTest.AllowCursorChanges = true;
            ProgressBarTest.AllowHomeEndKeysDetection = false;
            ProgressBarTest.AllowIncrementalClickMoves = true;
            ProgressBarTest.AllowMouseDownEffects = false;
            ProgressBarTest.AllowMouseHoverEffects = false;
            ProgressBarTest.AllowScrollingAnimations = true;
            ProgressBarTest.AllowScrollKeysDetection = true;
            ProgressBarTest.AllowScrollOptionsMenu = true;
            ProgressBarTest.AllowShrinkingOnFocusLost = false;
            ProgressBarTest.BackColor = System.Drawing.Color.Transparent;
            ProgressBarTest.BindingContainer = null;
            ProgressBarTest.BorderRadius = 2;
            ProgressBarTest.BorderThickness = 1;
            ProgressBarTest.Cursor = System.Windows.Forms.Cursors.Hand;
            ProgressBarTest.DrawThickBorder = true;
            ProgressBarTest.DurationBeforeShrink = 2000;
            ProgressBarTest.ElapsedColor = System.Drawing.Color.SteelBlue;
            ProgressBarTest.LargeChange = 10;
            ProgressBarTest.Location = new System.Drawing.Point(46, 163);
            ProgressBarTest.Maximum = 100;
            ProgressBarTest.Minimum = 0;
            ProgressBarTest.MinimumSize = new System.Drawing.Size(0, 31);
            ProgressBarTest.MinimumThumbLength = 18;
            ProgressBarTest.Name = "bunifuHSlider2";
            ProgressBarTest.OnDisable.ScrollBarBorderColor = System.Drawing.Color.Silver;
            ProgressBarTest.OnDisable.ScrollBarColor = System.Drawing.Color.Transparent;
            ProgressBarTest.OnDisable.ThumbColor = System.Drawing.Color.Silver;
            ProgressBarTest.ScrollBarBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            ProgressBarTest.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            ProgressBarTest.ShrinkSizeLimit = 3;
            ProgressBarTest.Size = new System.Drawing.Size(590, 31);
            ProgressBarTest.SliderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            ProgressBarTest.SliderStyle = Bunifu.UI.WinForms.BunifuHSlider.SliderStyles.Thick;
            ProgressBarTest.SliderThumbStyle = Utilities.BunifuSlider.BunifuHScrollBar.SliderThumbStyles.Circular;
            ProgressBarTest.SmallChange = 1;
            ProgressBarTest.TabIndex = 8;
            ProgressBarTest.ThumbColor = System.Drawing.Color.SteelBlue;
            ProgressBarTest.ThumbFillColor = System.Drawing.SystemColors.Control;
            ProgressBarTest.ThumbLength = 58;
            ProgressBarTest.ThumbMargin = 1;
            ProgressBarTest.ThumbSize = Bunifu.UI.WinForms.BunifuHSlider.ThumbSizes.Small;
            ProgressBarTest.ThumbStyle = Bunifu.UI.WinForms.BunifuHSlider.ThumbStyles.Outline;
            ProgressBarTest.Value = (int)testRes;
            // 
            // PersentageForm
            // 
            PersentageForm.AllowParentOverrides = false;
            PersentageForm.AutoEllipsis = false;
            PersentageForm.AutoSize = false;
            PersentageForm.CursorType = System.Windows.Forms.Cursors.Default;
            PersentageForm.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            PersentageForm.ForeColor = System.Drawing.Color.SteelBlue;
            PersentageForm.Location = new System.Drawing.Point(304, 87);
            PersentageForm.Name = "PersentageForm";
            PersentageForm.RightToLeft = System.Windows.Forms.RightToLeft.No;
            PersentageForm.Size = new System.Drawing.Size(90, 49);
            PersentageForm.TabIndex = 4;
            PersentageForm.Text = (int)formRes + "%";
            PersentageForm.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            PersentageForm.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // PersentageTest
            // 
            PersentageTest.AllowParentOverrides = false;
            PersentageTest.AutoEllipsis = false;
            PersentageTest.AutoSize = false;
            PersentageTest.CursorType = null;
            PersentageTest.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            PersentageTest.ForeColor = System.Drawing.Color.SteelBlue;
            PersentageTest.Location = new System.Drawing.Point(304, 186);
            PersentageTest.Name = "PersentageTest";
            PersentageTest.RightToLeft = System.Windows.Forms.RightToLeft.No;
            PersentageTest.Size = new System.Drawing.Size(90, 49);
            PersentageTest.TabIndex = 5;
            PersentageTest.Text = (int)testRes + "%";
            PersentageTest.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            PersentageTest.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // OK
            // 
            OK.AllowAnimations = true;
            OK.AllowMouseEffects = true;
            OK.AllowToggling = false;
            OK.AnimationSpeed = 200;
            OK.AutoGenerateColors = false;
            OK.AutoRoundBorders = false;
            OK.AutoSizeLeftIcon = true;
            OK.AutoSizeRightIcon = true;
            OK.BackColor = System.Drawing.Color.Transparent;
            OK.BackColor1 = System.Drawing.Color.SteelBlue;
            OK.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            OK.ButtonText = "ОК";
            OK.ButtonTextMarginLeft = 0;
            OK.ColorContrastOnClick = 45;
            OK.ColorContrastOnHover = 45;
            OK.Cursor = System.Windows.Forms.Cursors.Default;
            OK.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            OK.ForeColor = System.Drawing.Color.White;
            OK.Location = new System.Drawing.Point(260, 262);
            OK.Name = "OK";
            OK.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            OK.OnDisabledState.BorderRadius = 1;
            OK.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            OK.OnDisabledState.BorderThickness = 1;
            OK.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            OK.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            OK.OnDisabledState.IconLeftImage = null;
            OK.OnDisabledState.IconRightImage = null;
            OK.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            OK.onHoverState.BorderRadius = 1;
            OK.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            OK.onHoverState.BorderThickness = 1;
            OK.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            OK.onHoverState.ForeColor = System.Drawing.Color.White;
            OK.onHoverState.IconLeftImage = null;
            OK.onHoverState.IconRightImage = null;
            OK.OnIdleState.BorderColor = System.Drawing.Color.SteelBlue;
            OK.OnIdleState.BorderRadius = 1;
            OK.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            OK.OnIdleState.BorderThickness = 1;
            OK.OnIdleState.FillColor = System.Drawing.Color.SteelBlue;
            OK.OnIdleState.ForeColor = System.Drawing.Color.White;
            OK.OnIdleState.IconLeftImage = null;
            OK.OnIdleState.IconRightImage = null;
            OK.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            OK.OnPressedState.BorderRadius = 1;
            OK.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            OK.OnPressedState.BorderThickness = 1;
            OK.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            OK.OnPressedState.ForeColor = System.Drawing.Color.White;
            OK.OnPressedState.IconLeftImage = null;
            OK.OnPressedState.IconRightImage = null;
            OK.Size = new System.Drawing.Size(150, 39);
            OK.TabIndex = 6;
            OK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            OK.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            OK.TextMarginLeft = 0;
            OK.TextPadding = new System.Windows.Forms.Padding(0);
            OK.UseDefaultRadiusAndThickness = true;
        }

        public BunifuPanel Get()
        {
            return Body;
        }
    }
}
