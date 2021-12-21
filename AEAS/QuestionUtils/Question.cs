using System.Drawing;
using AEAS.Database;
using Bunifu.UI.WinForms;
using MySql.Data.MySqlClient;

namespace AEAS.QuestionUtils
{
    internal class Question
    {
        public BunifuShadowPanel BodyPanel { get; set; }
        public QuestionBody QuestionBody { get; set; }
        public QuestionText QuestionText { get; set; }
        public float Cost { get; set; }

        public Question(Size size, Point location)
        {
            BodyPanel = new BunifuShadowPanel();
            BodyPanel.Size = size;
            BodyPanel.Location = location;
        }

        public void Build(QuestionText text, QuestionBody body)
        {
            QuestionBody = body;
            QuestionText = text;
            GetAnswer();
            GetCost();
            BodyPanel.Controls.Add(text.GetBody());
            BodyPanel.Controls.Add(body.GetBody());
            BodyPanel.Visible = false;
        }

        public BunifuShadowPanel GetQuestion()
        {
            return BodyPanel;
        }

        private void GetAnswer()
        {
            DBCommandExecutor getAnswer = new DBCommandExecutor();
            string getAnsQuery = new QueryBuilder()
                .SELECT("ans")
                .FROM("question")
                .WHERE().Equals("text", QuestionText.GetText())
                .Build();
            MySqlDataReader ansReader = getAnswer.getReader(getAnsQuery);
            while (ansReader.Read())
            {
                QuestionBody.Answer = ansReader.GetString(0);
            }
            ansReader.Close();
        }

        private void GetCost()
        {
            DBCommandExecutor getCost = new DBCommandExecutor();
            string getCostQuery = new QueryBuilder()
                .SELECT("cost")
                .FROM("question")
                .WHERE().Equals("text", QuestionText.GetText())
                .Build();
            MySqlDataReader ansReader = getCost.getReader(getCostQuery);
            while (ansReader.Read())
            {
                Cost = ansReader.GetInt16(0);
            }
            ansReader.Close();
        }

        public float Validate()
        {
            if (QuestionBody.Check())
            {
                return Cost;
            }
            else
            {
                return 0;
            }
        }
    }
}
