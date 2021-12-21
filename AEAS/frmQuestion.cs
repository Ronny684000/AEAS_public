using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Bunifu.UI.WinForms;
using Bunifu.UI.WinForms.BunifuButton;
using Bunifu.UI.WinForms.BunifuAnimatorNS;
using AEAS.Database;
using AEAS.User;
using AEAS.QuestionUtils;
using AEAS.QuestionUtils.Enum;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Linq;

namespace AEAS
{
    public partial class frmQuestion : Form
    {

        private int qcount;
        private int ptr = -1;
        private List<BunifuDataGridView> saList = new List<BunifuDataGridView>();
        private List<float[][]> saCostList = new List<float[][]>();
        private List<string>[] qContList;
        private List<Question> qList = new List<Question>();
        private BunifuTransition sTransition = new BunifuTransition();
        private float Sum { get; set; }
        private BunifuShadowPanel CurrentQuestion { get; set; }
        public frmQuestion()
        {
            InitializeComponent();
        }

        private void Calculate()
        {
            for (int k = 0; k < saList.Count; k++)
            {
                for (int i = 0; i < saList[k].Rows.Count; i++)
                {
                    for (int j = 0; j < saList[k].Rows[i].Cells.Count - 1; j++)
                    {
                        bool isChecked = Convert.ToBoolean(saList[k].Rows[i].Cells[j + 1].Value);
                        if (isChecked)
                        {
                            Sum += saCostList[k][i][j];
                        }
                    }
                }
            }
        }

        private float GetFormMaximum()
        {
            float sum = 0;
            for (int k = 0; k < saList.Count; k++)
            {
                for (int i = 0; i < saList[k].Rows.Count; i++)
                {
                    sum += saCostList[k][i][0];
                }
            }
            return sum;
        }
        private void GetSATests()
        {
            DBCommandExecutor getTests = new DBCommandExecutor();
            string getTestsQuery = new QueryBuilder()
                .SELECT("test_name, test_cols, test_rows, test_cols_factors, test_rows_costs")
                .FROM("test")
                .JOIN("forms_tests")
                .ON().Equal("forms_tests.test_id", "test.test_id")
                .JOIN("form")
                .ON().Equal("forms_tests.form_id", "form.form_id")
                .WHERE().Equals("form_subject", UserInfo.UserSubject)
                .Build();
            MySqlDataReader testsReader = getTests.getReader(getTestsQuery);
            int x = 9;
            while (testsReader.Read())
            {
                BunifuLabel tableName = new BunifuLabel();
                string[] rows = testsReader.GetString(2).Split(';');
                var iecolFactors = from test in testsReader.GetString(3).Split(';') select float.Parse(test);
                float[] colFactors = iecolFactors.ToArray();
                var ierowCosts = from test in testsReader.GetString(4).Split(';') select float.Parse(test);
                float[] rowCosts = ierowCosts.ToArray();
                float[][] saTable = new float[rowCosts.Length][];
                for (int i = 0; i < saTable.Length; i++)
                {
                    saTable[i] = new float[colFactors.Length];
                    for (int j = 0; j < saTable[i].Length; j++)
                    {
                        saTable[i][j] = rowCosts[i] * colFactors[j];
                    }
                }
                saCostList.Add(saTable);
                BunifuDataGridView tableBody = new BunifuDataGridView();
                tableBody.SelectionMode = DataGridViewSelectionMode.CellSelect;
                tableName.AutoSize = false;
                tableName.Size = new Size(707, 47);
                tableName.Location = new Point(3, x);
                tableName.BackColor = Color.SteelBlue;
                tableName.Font = new Font("Century Gothic", 12);
                tableName.ForeColor = Color.White;
                tableName.TextAlignment = ContentAlignment.MiddleCenter;
                tableName.Text = testsReader.GetString(0);
                tableBody.Size = new Size(707, 50 * (rows.Length + 1));
                tableBody.Location = new Point(3, x + 53);
                tableBody.BackgroundColor = Color.White;
                tableBody.AllowUserToAddRows = false;
                tableBody.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                tableBody.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                tableBody.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                tableBody.ColumnHeadersHeight = 50;
                tableBody.RowTemplate.Height = 50;
                var rowHeaders = new DataGridViewTextBoxColumn();
                rowHeaders.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                rowHeaders.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                tableBody.Columns.Add(rowHeaders);
                string[] cols = testsReader.GetString(1).Split(';');
                for (int i = 0; i < cols.Length; i++)
                {
                    var column = new DataGridViewCheckBoxColumn();
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    column.DefaultCellStyle.Font = new Font("Century Gothic", 12);
                    column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    column.HeaderText = cols[i];
                    tableBody.Columns.Add(column);
                }
                tableBody.Rows.Clear();
                for (int i = 0; i < rows.Length; i++)
                {
                    tableBody.Rows.Add(rows[i]);
                }
                bunifuPanel1.Controls.Add(tableName);
                bunifuPanel1.Controls.Add(tableBody);
                saList.Add(tableBody);
                x += tableName.Size.Height + tableBody.Size.Height + 6;
            }
            testsReader.Close();
        }
        private QuestionBody ChooseAnsType(string questionText, string typeSource)
        {
            switch (typeSource)
            {
                case "1of4":
                    {
                        return new QuestionBodySingle(QuestionSizeMap.BodyStandard,
                            QuestionLocationMap.BodyStandard, GetVariants(questionText));
                    };
                case "fill in word":
                    {
                        return new QuestionBodyFillWord(QuestionSizeMap.BodyStandard,
                            QuestionLocationMap.BodyStandard);
                    };
                case "several":
                    {
                        return new QuestionBodySeveral(QuestionSizeMap.BodyStandard,
                            QuestionLocationMap.BodyStandard, GetVariants(questionText));
                    };
            }
            return null;
        }

        private void CreateQList()
        {
            for (int i = 0; i < qContList[0].Count; i++)
            {
                Question q = new Question(QuestionSizeMap.Standard, QuestionLocationMap.Standard);
                q.Build(new QuestionText(QuestionSizeMap.TextStandard, QuestionLocationMap.TextStandard, qContList[0][i]),
                    ChooseAnsType(qContList[0][i], qContList[1][i]));
                qList.Add(q);
            }
        }
        private void GetQuestionSet()
        {
            var questionList = new List<string>();
            var questionTypeList = new List<string>();
            DBCommandExecutor getQuestions = new DBCommandExecutor();
            string getQuestionQuery = new QueryBuilder()
                .SELECT("text, ans_type_content")
                .FROM("question")
                .JOIN("ans_type")
                .ON().Equal("question.ans_type_id", "ans_type.ans_type_id")
                .WHERE().Equals("question_subject", UserInfo.UserSubject)
                .Build();
            MySqlDataReader questionReader = getQuestions.getReader(getQuestionQuery);
            while (questionReader.Read())
            {
                questionList.Add(questionReader.GetString(0));
                questionTypeList.Add(questionReader.GetString(1));
            }
            qcount = questionList.Count;
            qContList = new List<string>[] { questionList, questionTypeList };
            questionReader.Close();
        }

        private string[] GetVariants(string questionText)
        {
            DBCommandExecutor getVariants = new DBCommandExecutor();
            string getVariantQuery = new QueryBuilder()
                .SELECT("v1", "v2", "v3", "v4")
                .FROM("question")
                .WHERE().Equals("text", questionText)
                .Build();
            MySqlDataReader variantReader = getVariants.getReader(getVariantQuery);
            string v1 = "";
            string v2 = "";
            string v3 = "";
            string v4 = "";
            while (variantReader.Read())
            {
                v1 = variantReader.GetString(0);
                v2 = variantReader.GetString(1);
                v3 = variantReader.GetString(2);
                v4 = variantReader.GetString(3);
            }
            variantReader.Close();
            return new string[] { v1, v2, v3, v4 };
        }

        private float GetTestMaximum()
        {
            var max = (from q in qList select q.Cost).Sum();
            return max;
        }

        private void frmQuestion_Load(object sender, EventArgs e)
        {
            GetQuestionSet();
            CreateQList();
            GetSATests();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            if (++ptr < qcount)
            {
                if (CurrentQuestion == null)
                {
                    CurrentQuestion = qList[ptr].GetQuestion();
                    Controls.Add(CurrentQuestion);
                    sTransition.Show(CurrentQuestion, false, Animation.VertSlide);
                }
                else
                {
                    sTransition.Hide(CurrentQuestion, false, Animation.VertSlide);
                    CurrentQuestion = qList[ptr].GetQuestion();
                    Controls.Add(CurrentQuestion);
                    sTransition.Show(CurrentQuestion, false, Animation.VertSlide);
                }
            }
            else
            {
                ptr--;
            }
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            if (--ptr > -1)
            {
                if (CurrentQuestion == null)
                {
                    CurrentQuestion = qList[ptr].GetQuestion();
                    Controls.Add(CurrentQuestion);
                    sTransition.Show(CurrentQuestion, false, Animation.VertSlide);
                }
                else
                {
                    sTransition.Hide(CurrentQuestion, false, Animation.VertSlide);
                    CurrentQuestion = qList[ptr].GetQuestion();
                    Controls.Add(CurrentQuestion);
                    sTransition.Show(CurrentQuestion, false, Animation.VertSlide);
                }
            }
            else
            {
                ptr++;
            }
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            Calculate();
            BunifuButton tButton = (BunifuButton)sender;
            tButton.Text = "Завершить";
            sTransition.HideSync(bunifuLabel1, false, Animation.VertSlide);
            sTransition.HideSync(bunifuPanel1, false, Animation.VertSlide);
            sTransition.HideSync(bunifuVScrollBar1, false, Animation.VertSlide);
            sTransition.ShowSync(bunifuButton1, true, Animation.VertSlide);
            sTransition.ShowSync(bunifuButton2, true, Animation.VertSlide);
            tButton.Click -= bunifuButton3_Click;
            tButton.Click += Finish;
            bunifuButton1_Click(bunifuButton1, new EventArgs());

        }

        private void Finish(object sender, EventArgs e)
        {
            var cSum = (from q in qList select q.Validate()).Sum();
            float testResult = cSum / GetTestMaximum() * 100;
            float formResult = Sum / GetFormMaximum() * 100;
            sTransition.HideSync(bunifuButton1, false, Animation.VertSlide);
            sTransition.HideSync(bunifuButton2, false, Animation.VertSlide);
            sTransition.HideSync(bunifuButton3, false, Animation.VertSlide);
            sTransition.HideSync(CurrentQuestion, false, Animation.VertSlide);
            ResultPanel resultPanel = new ResultPanel(formResult, testResult);
            Controls.Add(resultPanel.Get());
            sTransition.ShowSync(resultPanel.Get(), false, Animation.VertSlide);
        }
    }
}
