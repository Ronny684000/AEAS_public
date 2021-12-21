using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using AEAS.Database;
using MySql.Data.MySqlClient;

namespace AEAS
{
    public partial class frmReg : Form
    {
        public string RegName { get; set; }
        public string RegLastName { get; set; }
        public string RegThirdName { get; set; }
        public string RegDegree { get; set; }
        public string RegEmail { get; set; }
        public string RegSubject { get; set; }
        public string RegLogin { get; set; }
        public string RegPassword { get; set; }
        public string RegProfileImage { get; set; }
        private string EncodeImage(Image image)
        {
            MemoryStream ms = new MemoryStream();
            image.Save(ms, image.RawFormat);
            return Convert.ToBase64String(ms.ToArray());
        }
        private void SendToDB()
        {
            DBCommandExecutor sendAccount = new DBCommandExecutor();
            string sendAccountQuery = new QueryBuilder()
                .INSERT_INTO("expert_account", "login, password, image")
                .VALUES(new object[][] { new object[] { RegLogin, RegPassword, RegProfileImage} })
                .Build();
            sendAccount.getReader(sendAccountQuery).Close();
            DBCommandExecutor getMaxId = new DBCommandExecutor();
            string getMaxIdQuery = new QueryBuilder()
                .SELECT("count(*)")
                .FROM("expert_account")
                .Build();
            MySqlDataReader maxIdReader = getMaxId.getReader(getMaxIdQuery);
            int id = 0;
            while (maxIdReader.Read())
            {
                id = maxIdReader.GetInt16(0);
            }
            maxIdReader.Close();
            DBCommandExecutor sendExpert = new DBCommandExecutor();
            string sendExpertQuery = new QueryBuilder()
                .INSERT_INTO("expert", "name, last_name, third_name, degree, subject, expert_account_id")
                .VALUES(new object[][] { new object[] {RegName, RegLastName, RegThirdName, RegDegree, RegSubject, id} })
                .Build();
            sendExpert.getReader(sendExpertQuery).Close();
        }
        private bool CheckPassword()
        {
            return bunifuTextBox7.Text == bunifuTextBox6.Text;
        }

        private bool CheckDataFill()
        {
            return bunifuTextBox1.Text != "" &&
                bunifuTextBox2.Text != "" &&
                bunifuTextBox3.Text != "" &&
                bunifuTextBox4.Text != "" &&
                bunifuTextBox5.Text != "" &&
                bunifuTextBox6.Text != "" &&
                bunifuTextBox7.Text != "" &&
                bunifuTextBox8.Text != "" &&
                bunifuDropdown1.Text != "";
        }
        private void PickRegData()
        {
            RegName = bunifuTextBox1.Text;
            RegLastName = bunifuTextBox2.Text;
            RegThirdName = bunifuTextBox3.Text;
            RegDegree = bunifuTextBox4.Text;
            RegEmail = bunifuTextBox8.Text;
            RegSubject = bunifuDropdown1.Text;
            RegLogin = bunifuTextBox5.Text;
            RegPassword = bunifuTextBox6.Text;
            RegProfileImage = EncodeImage(bunifuPictureBox1.Image);
        }
        private void SetPhoto()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            bunifuPictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                bunifuPictureBox1.Image = Image.FromFile(ofd.FileName);
            }
        }
        public frmReg()
        {
            InitializeComponent();
        }

        private void bunifuPictureBox1_Click(object sender, EventArgs e)
        {
            SetPhoto();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            if(CheckPassword() && CheckDataFill())
            {
                PickRegData();
                SendToDB();
                Hide();
            }
        }

        private void frmReg_Load(object sender, EventArgs e)
        {

        }
    }
}
