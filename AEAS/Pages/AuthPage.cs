using System;
using System.Drawing;
using System.Windows.Forms;
using AEAS.Database;
using AEAS.Pages.Enum;
using AEAS.User;
using Bunifu.UI.WinForms;
using Bunifu.UI.WinForms.BunifuButton;
using MySql.Data.MySqlClient;
using Tulpep.NotificationWindow;

namespace AEAS.Pages
{
    internal class AuthPage : AbstractPage
    {
        private static AuthPage _instance;

        public PopupNotifier notifier;
        public BunifuTextBox TxbLogin { get; set; }
        public BunifuTextBox TxbPassword { get; set; }
        public BunifuButton BtnLogIn { get; set; }
        public BunifuButton BtnReg { get; set; }

        private AuthPage(Size size, Point location) : base(size, location)
        {
            TxbLogin = new BunifuTextBox();
            TxbLogin.Location = new Point(279, 101);
            TxbLogin.Size = new Size(157, 40);
            TxbLogin.PlaceholderText = "Логин";
            //Debug{
            TxbLogin.Text = "admin";
            //Debug}
            TxbPassword = new BunifuTextBox();
            TxbPassword.Location = new Point(279, 145);
            TxbPassword.Size = new Size(157, 40);
            TxbPassword.PasswordChar = '•';
            //Debug{
            TxbPassword.Text = "admin";
            //Debug}
            BtnLogIn = new BunifuButton();
            BtnLogIn.Location = new Point(279, 206);
            BtnLogIn.Size = new Size(157, 39);
            BtnLogIn.AutoRoundBorders = true;
            BtnLogIn.Font = new Font("Century Gothic", 9.75f);
            BtnLogIn.Text = "Войти";
            BtnLogIn.Click += LogIn;
            BtnReg = new BunifuButton();
            BtnReg.Location = new Point(279, 322);
            BtnReg.Size = new Size(157, 39);
            BtnReg.AutoRoundBorders = true;
            BtnReg.Font = new Font("Century Gothic", 9.75f);
            BtnReg.Text = "Регистрация";
            BtnReg.Click += Reg;
            SetUp();
            InitPopup();
        }

        public override void SetUp()
        {
            Canvas.Controls.AddRange(new Control[] { TxbLogin, TxbPassword, BtnLogIn, BtnReg });
        }

        public static AuthPage GetInstance(Size size, Point location)
        {
            if (_instance == null)
            {
                _instance = new AuthPage(size, location);
            }
            return _instance;
        }

        private void LogIn(object sender, EventArgs e)
        {
            if (CheckCreds())
            {
                if (CheckFirstEntry())
                {
                    UserInfo.UserSubject = GetUserData();
                    frmQuestion frmQuestion = (frmQuestion)Application.OpenForms["frmQuestion"];
                    if (frmQuestion != null)
                    {
                        frmQuestion.Show();
                    }
                    else
                    {
                        frmQuestion = new frmQuestion();
                        frmQuestion.Show();
                    }
                }
                else
                {
                    SwitchTo(MainMenu.GetInstance(PageSizeMap.Standard, PageLocationMap.Standard));
                }
            }
            else
            {
                notifier.Popup();
            }
        }

        private void Reg(object sender, EventArgs e)
        {
            frmReg frmReg = (frmReg)Application.OpenForms["frmReg"];
            if (frmReg != null)
            {
                frmReg.Show();
            }
            else
            {
                frmReg = new frmReg();
                frmReg.Show();
            }
        }

        private string GetUserData()
        {
            DBCommandExecutor getSubject = new DBCommandExecutor();
            string getQuestionQuery = new QueryBuilder()
                .SELECT("subject")
                .FROM("expert")
                .JOIN("expert_account")
                .ON().Equal("expert_account.expert_account_id", "expert.expert_account_id")
                .WHERE().Equals("login", TxbLogin.Text)
                .AND().Equals("password", TxbPassword.Text)
                .Build();
            MySqlDataReader subjectReader = getSubject.getReader(getQuestionQuery);
            string subject = "";
            while (subjectReader.Read())
            {
                subject = subjectReader.GetString(0);
            }
            subjectReader.Close();
            return subject;
        }

        private bool CheckCreds()
        {
            DBCommandExecutor sendCreds = new DBCommandExecutor();
            string sendAccountQuery = new QueryBuilder()
                .SELECT()
                .EXISTS(new QueryBuilder()
                .SELECT("*")
                .FROM("expert_account")
                .WHERE().Equals("login", TxbLogin.Text)
                .AND().Equals("password", TxbPassword.Text))
                .Build();
            MySqlDataReader existsReader = sendCreds.getReader(sendAccountQuery);
            bool exists = false;
            while (existsReader.Read())
            {
                exists = existsReader.GetBoolean(0);
            }
            existsReader.Close();
            return exists;
        }

        private bool CheckFirstEntry()
        {
            DBCommandExecutor getFirstEntry = new DBCommandExecutor();
            string getFirstEntryQuery = new QueryBuilder()
                .SELECT("first_enter")
                .FROM("expert_account")
                .WHERE().Equals("login", TxbLogin.Text)
                .AND().Equals("password", TxbPassword.Text)
                .Build();
            MySqlDataReader firstEntryReader = getFirstEntry.getReader(getFirstEntryQuery);
            bool firstEntry = false;
            while (firstEntryReader.Read())
            {
                firstEntry = firstEntryReader.GetBoolean(0);
            }
            firstEntryReader.Close();
            return firstEntry;
        }

        private void InitPopup()
        {
            notifier = new PopupNotifier();
            notifier.Image = Properties.Resources.vs;
            notifier.ImageSize = new Size(90, 90);
            notifier.TitleText = "Ошибка";
            notifier.TitleColor = Color.Red;
            notifier.ContentText = "Данные введены неверно, проверьте правильность ввода данных или создайте аккаунт";
            notifier.ShowGrip = false;
        }
    }
}
