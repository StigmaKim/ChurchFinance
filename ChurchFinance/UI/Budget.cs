using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data.SQLite;
using System.Globalization;

namespace UI
{
    public partial class Budget : UserControl
    {
        SQLite SQLite;
        DateTime date;
        DMode mode;

        // 수입
        int Thanks;
        int O10;
        int Cell;
        int Archi;
        int Mission;
        int Rice;
        int Help;
        int Car;
        int Term;
        int Sum_income;

        // 지출
        int Worship;
        int Mis;
        int Edu;
        int Human;
        int Vol;
        int Main;
        int Loan;
        int Res;
        int Sum_spend;

        int Sum_Worship = 0;
        int Sum_Mission = 0;
        int Sum_Edu = 0;
        int Sum_Human = 0;
        int Sum_Vol = 0;
        int Sum_Main = 0;
        int Sum_Loan = 0;
        int Sum_Res = 0;

        DataGridView spend = null;
        DataGridView spend_Worship = null;
        DataGridView spend_Mission = null;
        DataGridView spend_Edu = null;
        DataGridView spend_Human = null;
        DataGridView spend_Vol = null;
        DataGridView spend_Main = null;
        DataGridView spend_Loan = null;

        DataGridView currentTab;

        DateTimePicker dateTimePicker1;

        public enum DMode
        {
            income,
            spend
        };

        public Budget(DMode d, DateTimePicker dtp)
        {
            InitializeComponent();
            mode = d;
            dateTimePicker1 = dtp;

            SQLite = new SQLite();

            if( mode == DMode.spend)
            {
                spend = new DataGridView();
                spend_Worship = new DataGridView();
                spend_Mission = new DataGridView();
                spend_Edu = new DataGridView();
                spend_Human = new DataGridView();
                spend_Vol = new DataGridView();
                spend_Main = new DataGridView();
                spend_Loan = new DataGridView();

                spend.CellEndEdit += Spend_CellEndEdit;
                spend_Worship.CellEndEdit += Spend_Worship_CellEndEdit;
                spend_Mission.CellEndEdit += Spend_Mission_CellEndEdit;
                spend_Edu.CellEndEdit += Spend_Edu_CellEndEdit;
                spend_Human.CellEndEdit += Spend_Human_CellEndEdit;
                spend_Vol.CellEndEdit += Spend_Vol_CellEndEdit;
                spend_Main.CellEndEdit += Spend_Main_CellEndEdit;
                spend_Loan.CellEndEdit += Spend_Loan_CellEndEdit;
                spend.CellMouseDown += Spend_CellMouseDown;

                AddGridView();
            }

            dgv.Hide();
            SetView();
            CreateTable();
            GetValues();
            SetRows();
            dgv.CellEndEdit += Dgv_CellEndEdit;

        }

        private void Spend_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Make Comma type
            for (int i = 0; i < 8; i++)
                if(spend.Rows[i].Cells[1].Value != null )
                spend.Rows[i].Cells[1].Value = ToComma(spend.Rows[i].Cells[1].Value);

            // Set Sumation.
            int sum = 0;
            for (int i = 0; i < 8; i++)
                if (spend.Rows[i].Cells[1].Value.ToString() != "")
                    sum += Convert.ToInt32(ToNoComma(spend.Rows[i].Cells[1].Value));

            spend.Rows[11].Cells[1].Value = ToComma(sum);

            //SetInputSumDGV();
        }

        private void Spend_Worship_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Make Comma type
            for (int i = 0; i < 3; i++)
                if (spend_Worship.Rows[i].Cells[1].Value != null)
                    spend_Worship.Rows[i].Cells[1].Value = ToComma(spend_Worship.Rows[i].Cells[1].Value);

            // Set Sumation.
            int sum = 0;
            for (int i = 0; i < 3; i++)
                if (spend_Worship.Rows[i].Cells[1].Value.ToString() != "")
                    sum += Convert.ToInt32(ToNoComma(spend_Worship.Rows[i].Cells[1].Value));

            spend_Worship.Rows[11].Cells[1].Value = ToComma(sum);
            Sum_Worship = sum;
            SetInputSumDGV();
        }

        private void Spend_Mission_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Make Comma type
            for (int i = 0; i < 2; i++)
                if (spend_Mission.Rows[i].Cells[1].Value != null)
                    spend_Mission.Rows[i].Cells[1].Value = ToComma(spend_Mission.Rows[i].Cells[1].Value);

            // Set Sumation.
            int sum = 0;
            for (int i = 0; i < 2; i++)
                if (spend_Mission.Rows[i].Cells[1].Value.ToString() != "")
                    sum += Convert.ToInt32(ToNoComma(spend_Mission.Rows[i].Cells[1].Value));

            spend_Mission.Rows[11].Cells[1].Value = ToComma(sum);
            Sum_Mission = sum;
            SetInputSumDGV();
        }

        private void Spend_Edu_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Make Comma type
            for (int i = 0; i < 5; i++)
                if (spend_Edu.Rows[i].Cells[1].Value != null)
                    spend_Edu.Rows[i].Cells[1].Value = ToComma(spend_Edu.Rows[i].Cells[1].Value);

            // Set Sumation.
            int sum = 0;
            for (int i = 0; i < 5; i++)
                if (spend_Edu.Rows[i].Cells[1].Value.ToString() != "")
                    sum += Convert.ToInt32(ToNoComma(spend_Edu.Rows[i].Cells[1].Value));

            spend_Edu.Rows[11].Cells[1].Value = ToComma(sum);
            Sum_Edu = sum;
            SetInputSumDGV();
        }

        private void Spend_Human_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Make Comma type
            for (int i = 0; i < 3; i++)
                if (spend_Human.Rows[i].Cells[1].Value != null)
                    spend_Human.Rows[i].Cells[1].Value = ToComma(spend_Human.Rows[i].Cells[1].Value);

            // Set Sumation.
            int sum = 0;
            for (int i = 0; i < 3; i++)
                if (spend_Human.Rows[i].Cells[1].Value.ToString() != "")
                    sum += Convert.ToInt32(ToNoComma(spend_Human.Rows[i].Cells[1].Value));

            spend_Human.Rows[11].Cells[1].Value = ToComma(sum);
            Sum_Human = sum;
            SetInputSumDGV();
        }

        private void Spend_Vol_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Make Comma type
            for (int i = 0; i < 3; i++)
                if (spend_Vol.Rows[i].Cells[1].Value != null)
                    spend_Vol.Rows[i].Cells[1].Value = ToComma(spend_Vol.Rows[i].Cells[1].Value);

            // Set Sumation.
            int sum = 0;
            for (int i = 0; i < 3; i++)
                if (spend_Vol.Rows[i].Cells[1].Value.ToString() != "")
                    sum += Convert.ToInt32(ToNoComma(spend_Vol.Rows[i].Cells[1].Value));

            spend_Vol.Rows[11].Cells[1].Value = ToComma(sum);
            Sum_Vol = sum;
            SetInputSumDGV();
        }

        private void Spend_Main_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Make Comma type
            for (int i = 0; i < 10; i++)
                if (spend_Main.Rows[i].Cells[1].Value != null)
                    spend_Main.Rows[i].Cells[1].Value = ToComma(spend_Main.Rows[i].Cells[1].Value);

            // Set Sumation.
            int sum = 0;
            for (int i = 0; i < 10; i++)
                if (spend_Main.Rows[i].Cells[1].Value.ToString() != "")
                    sum += Convert.ToInt32(ToNoComma(spend_Main.Rows[i].Cells[1].Value));

            spend_Main.Rows[11].Cells[1].Value = ToComma(sum);
            Sum_Main = sum;
            SetInputSumDGV();
        }

        private void Spend_Loan_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Make Comma type
            for (int i = 0; i < 2; i++)
                if (spend_Loan.Rows[i].Cells[1].Value != null)
                    spend_Loan.Rows[i].Cells[1].Value = ToComma(spend_Loan.Rows[i].Cells[1].Value);

            // Set Sumation.
            int sum = 0;
            for (int i = 0; i < 2; i++)
                if (spend_Loan.Rows[i].Cells[1].Value.ToString() != "")
                    sum += Convert.ToInt32(ToNoComma(spend_Loan.Rows[i].Cells[1].Value));

            spend_Loan.Rows[11].Cells[1].Value = ToComma(sum);
            Sum_Loan = sum;
            SetInputSumDGV();
        }

        private void Spend_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1 && e.RowIndex != 8 && e.RowIndex != 7 && e.RowIndex != 9 && e.RowIndex != 10 && e.RowIndex != 11)
            {
                currentTab.Hide();
                switch (e.RowIndex)
                {
                    case 0:
                        spend_Worship.Show();
                        currentTab = spend_Worship;
                        break;
                    case 1:
                        spend_Mission.Show();
                        currentTab = spend_Mission;
                        break;
                    case 2:
                        spend_Edu.Show();
                        currentTab = spend_Edu;
                        break;
                    case 3:
                        spend_Human.Show();
                        currentTab = spend_Human;
                        break;
                    case 4:
                        spend_Vol.Show();
                        currentTab = spend_Vol;
                        break;
                    case 5:
                        spend_Main.Show();
                        currentTab = spend_Main;
                        break;
                    case 6:
                        spend_Loan.Show();
                        currentTab = spend_Loan;
                        break;
                }
            }
        }

        private void AddGridView()
        {
            #region DGV 옵션 1
            // spend ---------------------------------------
            spend.Size = new Size(450, 392);
            spend.Location = new Point(20, 80);
            spend.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            spend.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            spend.ColumnHeadersHeight = 30;
            spend.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            spend.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            spend.Font = new Font("Microsoft Sans Serif", 12);
            spend.RowTemplate.Height = 30;
            spend.ColumnCount = 2;
            spend.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            spend.Columns[0].ReadOnly = true;
            spend.AllowUserToAddRows = false;
            spend.RowHeadersWidthSizeMode =
                DataGridViewRowHeadersWidthSizeMode.DisableResizing;

            spend.Columns[0].Name = "항 목";
            spend.Columns[1].Name = "금 액";

            for (int i = 0; i < spend.Columns.Count; i++)
                spend.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            for (int i = 0; i < spend.ColumnCount; i++)
                spend.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            #endregion

            #region DGV 옵션 2

            // spend_Worship ----------------------------------
            spend_Worship.Size = new Size(450, 392);
            spend_Worship.Location = new Point(500, 80);
            spend_Worship.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            spend_Worship.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            spend_Worship.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            spend_Worship.ColumnHeadersHeight = 30;
            spend_Worship.Font = new Font("Microsoft Sans Serif", 12);
            spend_Worship.RowTemplate.Height = 30;
            spend_Worship.AllowUserToAddRows = false;
            spend_Worship.RowHeadersWidthSizeMode =
                DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            spend_Worship.RowCount = 12;
            spend_Worship.ColumnCount = 2;
            spend_Worship.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            spend_Worship.Columns[0].HeaderText = "항 목";
            spend_Worship.Columns[1].HeaderText = "금 액";

            // spend_Mission ----------------------------------
            spend_Mission.Size = new Size(450, 392);
            spend_Mission.Location = new Point(500, 80);
            spend_Mission.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            spend_Mission.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            spend_Mission.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            spend_Mission.ColumnHeadersHeight = 30;
            spend_Mission.Font = new Font("Microsoft Sans Serif", 12);
            spend_Mission.RowTemplate.Height = 30;
            spend_Mission.AllowUserToAddRows = false;
            spend_Mission.RowHeadersWidthSizeMode =
                DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            spend_Mission.RowCount = 12;
            spend_Mission.ColumnCount = 2;
            spend_Mission.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            spend_Mission.Columns[0].HeaderText = "항 목";
            spend_Mission.Columns[1].HeaderText = "금 액";

            // spend_Edu ----------------------------------
            spend_Edu.Size = new Size(450, 392);
            spend_Edu.Location = new Point(500, 80);
            spend_Edu.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            spend_Edu.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            spend_Edu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            spend_Edu.ColumnHeadersHeight = 30;
            spend_Edu.Font = new Font("Microsoft Sans Serif", 12);
            spend_Edu.RowTemplate.Height = 30;
            spend_Edu.AllowUserToAddRows = false;
            spend_Edu.RowHeadersWidthSizeMode =
                DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            spend_Edu.RowCount = 12;
            spend_Edu.ColumnCount = 2;
            spend_Edu.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            spend_Edu.Columns[0].HeaderText = "항 목";
            spend_Edu.Columns[1].HeaderText = "금 액";

            // spend_Human ----------------------------------
            spend_Human.Size = new Size(450, 392);
            spend_Human.Location = new Point(500, 80);
            spend_Human.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            spend_Human.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            spend_Human.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            spend_Human.ColumnHeadersHeight = 30;
            spend_Human.Font = new Font("Microsoft Sans Serif", 12);
            spend_Human.RowTemplate.Height = 30;
            spend_Human.AllowUserToAddRows = false;
            spend_Human.RowHeadersWidthSizeMode =
                DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            spend_Human.RowCount = 12;
            spend_Human.ColumnCount = 2;
            spend_Human.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            spend_Human.Columns[0].HeaderText = "항 목";
            spend_Human.Columns[1].HeaderText = "금 액";

            // spend_Vol ----------------------------------
            spend_Vol.Size = new Size(450, 392);
            spend_Vol.Location = new Point(500, 80);
            spend_Vol.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            spend_Vol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            spend_Vol.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            spend_Vol.ColumnHeadersHeight = 30;
            spend_Vol.Font = new Font("Microsoft Sans Serif", 12);
            spend_Vol.RowTemplate.Height = 30;
            spend_Vol.AllowUserToAddRows = false;
            spend_Vol.RowHeadersWidthSizeMode =
                DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            spend_Vol.RowCount = 12;
            spend_Vol.ColumnCount = 2;
            spend_Vol.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            spend_Vol.Columns[0].HeaderText = "항 목";
            spend_Vol.Columns[1].HeaderText = "금 액";

            // spend_Main ----------------------------------
            spend_Main.Size = new Size(450, 392);
            spend_Main.Location = new Point(500, 80);
            spend_Main.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            spend_Main.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            spend_Main.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            spend_Main.ColumnHeadersHeight = 30;
            spend_Main.Font = new Font("Microsoft Sans Serif", 12);
            spend_Main.RowTemplate.Height = 30;
            spend_Main.AllowUserToAddRows = false;
            spend_Main.RowHeadersWidthSizeMode =
                DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            spend_Main.RowCount = 12;
            spend_Main.ColumnCount = 2;
            spend_Main.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            spend_Main.Columns[0].HeaderText = "항 목";
            spend_Main.Columns[1].HeaderText = "금 액";

            // spend_Loan ----------------------------------
            spend_Loan.Size = new Size(450, 392);
            spend_Loan.Location = new Point(500, 80);
            spend_Loan.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            spend_Loan.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            spend_Loan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            spend_Loan.ColumnHeadersHeight = 30;
            spend_Loan.Font = new Font("Microsoft Sans Serif", 12);
            spend_Loan.RowTemplate.Height = 30;
            spend_Loan.AllowUserToAddRows = false;
            spend_Loan.RowHeadersWidthSizeMode =
                DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            spend_Loan.RowCount = 12;
            spend_Loan.ColumnCount = 2;
            spend_Loan.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            spend_Loan.Columns[0].HeaderText = "항 목";
            spend_Loan.Columns[1].HeaderText = "금 액";
            
            #endregion

            this.Controls.Add(spend);

            this.Controls.Add(spend_Worship);
            this.Controls.Add(spend_Mission);
            this.Controls.Add(spend_Edu);
            this.Controls.Add(spend_Human);
            this.Controls.Add(spend_Vol);
            this.Controls.Add(spend_Main);
            this.Controls.Add(spend_Loan);
            spend_Mission.Hide();
            spend_Edu.Hide();
            spend_Human.Hide();
            spend_Vol.Hide();
            spend_Main.Hide();
            spend_Loan.Hide();

            currentTab = spend_Worship;
        }

        public void SetLabel()
        {
            label1.Location = new Point(385, 20);
            label1.Font = new Font("Microsoft Sans Serif", 20);
            if ( mode == DMode.income)
                label1.Text = date.Year + "년 수입 예산";
            else if (mode == DMode.spend)
                label1.Text = date.Year + "년 지출 예산";
        }

        public void SetDate(DateTime d) {
            date = d;
        }

        private void Dgv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            for( int i = 0; i < dgv.RowCount-1; i++)
                dgv.Rows[i].Cells[1].Value = ToComma(dgv.Rows[i].Cells[1].Value);
            
            int sum = 0;
            for (int i = 0; i < 9; i++)
                sum += Convert.ToInt32(ToNoComma(dgv.Rows[i].Cells[1].Value));

            dgv.Rows[9].Cells[1].Value = ToComma(sum);            
            
        }

        private void SetView()
        {
            if( mode == DMode.income)
            {
                dgv.Show();
                dgv.Location = new Point(285, 80);
                dgv.Size = new Size(400, 332);
                dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                dgv.ColumnHeadersHeight = 30;
                dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv.ColumnCount = 2;
                dgv.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgv.RowTemplate.Height = 30;
                dgv.RowCount = 11;
                dgv.Font = new Font("Microsoft Sans Serif", 12);
                dgv.AllowUserToAddRows = false;

                dgv.CellFormatting += Dgv_CellFormatting;
                dgv.EditingControlShowing += Dgv_EditingControlShowing;

                dgv.Columns[0].Name = "항 목";
                dgv.Columns[1].Name = "금 액";
                dgv.Columns["항 목"].ReadOnly = true;

                for (int i = 0; i < dgv.Columns.Count; i++)
                    dgv.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                for (int i = 0; i < dgv.ColumnCount; i++)
                    dgv.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            else if( mode == DMode.spend)
            {

            }            
        }

        private void Dgv1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox tb = e.Control as TextBox;
            tb.Text = ToNoComma(tb);
        }

        private void Dgv1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
            {
                e.Value = String.Format("{0:N0}", e.Value);
            }
        }

        private static string ToNoComma(TextBox tb)
        {
            string[] a = tb.Text.Split(',');
            string temp ="";
            for ( int i = 0; i < a.Length; i++)
            {
                temp += a[i];
            }
            return temp;
        }
        private static string ToNoComma(object tb)
        {
            string[] a = tb.ToString().Split(',');
            string temp = "";
            for (int i = 0; i < a.Length; i++)
            {
                temp += a[i];
            }
            return temp;
        }
        private static string ToComma(object str)
        {
            string s;
            try {
                s =  String.Format("{0:N0}", Convert.ToInt32(str));
            }catch( FormatException e)
            {
                return str.ToString();
            }
            return s; 
        }

        private void Dgv_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox tb = e.Control as TextBox;
            tb.Text = ToNoComma(tb);
        }

        private void Dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
            {
                e.Value = String.Format("{0:N0}", e.Value);
            }
            else
            {
                e.Value = 0;
            }
        }

        private void GetValues()
        {
            if (mode == DMode.income)
            {
                DataSet ds = SQLite.ExecuteSelectQuery(string.Format("select amount from budget"));
                if (ds.Tables[0].Rows.Count == 0)
                {
                    Thanks = 0;
                    O10 = 0;
                    Cell = 0;
                    Archi = 0;
                    Mission = 0;
                    Rice = 0;
                    Help = 0;
                    Car = 0;
                    Term = 0;
                    Sum_income = 0;
                }
                else {
                    Thanks = Convert.ToInt32(ds.Tables[0].Rows[0]["amount"]);
                    O10 = Convert.ToInt32(ds.Tables[0].Rows[1]["amount"]);
                    Cell = Convert.ToInt32(ds.Tables[0].Rows[2]["amount"]);
                    Archi = Convert.ToInt32(ds.Tables[0].Rows[3]["amount"]);
                    Mission = Convert.ToInt32(ds.Tables[0].Rows[4]["amount"]);
                    Rice = Convert.ToInt32(ds.Tables[0].Rows[5]["amount"]);
                    Help = Convert.ToInt32(ds.Tables[0].Rows[6]["amount"]);
                    Car = Convert.ToInt32(ds.Tables[0].Rows[7]["amount"]);
                    Term = Convert.ToInt32(ds.Tables[0].Rows[8]["amount"]);
                    Sum_income = Thanks + O10 + Cell + Archi + Mission + Rice + Help + Car + Term;
                }
            }
            else if(mode == DMode.spend)
            {
                SetSpendBudgetDGV();
                SetInputSumDGV();
            }
        }
        private void SetRows()
        {
            if( mode == DMode.income)
            {
                dgv.Rows[0].Cells[0].Value = "  감사헌금";
                dgv.Rows[0].Cells[1].Value = Thanks;
                dgv.Rows[1].Cells[0].Value = "  십일조";
                dgv.Rows[1].Cells[1].Value = O10;
                dgv.Rows[2].Cells[0].Value = "  구역헌금";
                dgv.Rows[2].Cells[1].Value = Cell;
                dgv.Rows[3].Cells[0].Value = "  건축헌금";
                dgv.Rows[3].Cells[1].Value = Archi;
                dgv.Rows[4].Cells[0].Value = "  선교헌금";
                dgv.Rows[4].Cells[1].Value = Mission;
                dgv.Rows[5].Cells[0].Value = "  성미헌금";
                dgv.Rows[5].Cells[1].Value = Rice;
                dgv.Rows[6].Cells[0].Value = "  구제헌금";
                dgv.Rows[6].Cells[1].Value = Help;
                dgv.Rows[7].Cells[0].Value = "  차량헌금";
                dgv.Rows[7].Cells[1].Value = Car;
                dgv.Rows[8].Cells[0].Value = "  절기헌금";
                dgv.Rows[8].Cells[1].Value = Term;
                dgv.Rows[9].Cells[0].Value = "  Total";
                int sum = 0;
                for (int i = 0; i < 9; i++)
                    sum += Convert.ToInt32(dgv.Rows[i].Cells[1].Value);
                dgv.Rows[9].Cells[1].Value = sum;
                dgv.Rows[9].Height = 30;
                dgv.Rows[9].ReadOnly = true;
            }
            else if( mode == DMode.spend)
            {

            }
        }

        private void CreateTable()
        {
            if (mode == DMode.income)
            {
                Debug.WriteLine("HHHH");
                SQLite.Execute(string.Format("create table Budget " +
                            "(no Integer primary key autoincrement, amount Integer)"));
                /*
                1. 감사헌금
                2. 십일조
                3. 구역헌금
                4. 건축헌금
                5. 선교헌금
                6. 성미헌금
                7. 구제헌금
                8. 차량헌금
                9. 절기헌금
                10. 예배비
                11. 선교비
                12. 교육비
                13. 인건비
                14. 봉사비
                15. 운영관리비
                16. 대출관련비
                17. 예비비
                */
            }
            else if(mode == DMode.spend)
            {
                SQLite.Execute(string.Format("create table Budget2 " +
                        "(no Integer primary key autoincrement, amount Integer)"));
                /*
                1. 강단꽃꽃이
                2. 성가대운영비
                3. 주보대
                4. 선교비
                5. 심방비
                6. 주일학교지원비
                7. 학생부지원비
                8. 청년부지원비
                9. 장학금
                10. 도서비
                11. 목사님사례비
                12. 전도사님사례비
                13. 상여금
                14. 경조비
                15. 구제비
                16. 행사비
                17. 사택유지비
                18. 교회관리비
                19. 목회활동비
                20. 수도광열비
                21. 통신비
                22. 차량관리비
                23. 차량구입비적립
                24. 상회비
                25. 교회비품비
                26. 기타지출
                27. 상환적립
                28. 지급이자
                29. 예비비
                */
            }

        }
        public void ButtonEvent()
        {
            try
            {
                if( mode == DMode.income)
                {
                    SQLite.Execute(string.Format("drop table Budget"));
                    CreateTable();
                    for (int i = 0; i < 9; i++)
                        SQLite.Execute(string.Format("insert into Budget (amount) values ({0})", Convert.ToInt32(ToNoComma(dgv.Rows[i].Cells[1].Value))));
                }
                    
                else if( mode == DMode.spend)
                {
                    for (int i = 0; i < 8; i++)
                        SQLite.Execute(string.Format("insert into Budget (amount) values ({0})", Convert.ToInt32(ToNoComma(spend.Rows[i].Cells[1].Value))));
                    SQLite.Execute(string.Format("drop table Budget2"));
                    CreateTable();
                    for (int i = 0; i < 3; i++)
                        SQLite.Execute(string.Format("insert into Budget2 (amount) values ({0})", Convert.ToInt32(ToNoComma(spend_Worship.Rows[i].Cells[1].Value))));
                    for (int i = 0; i < 2; i++)
                        SQLite.Execute(string.Format("insert into Budget2 (amount) values ({0})", Convert.ToInt32(ToNoComma(spend_Mission.Rows[i].Cells[1].Value))));
                    for (int i = 0; i < 5; i++)
                        SQLite.Execute(string.Format("insert into Budget2 (amount) values ({0})", Convert.ToInt32(ToNoComma(spend_Edu.Rows[i].Cells[1].Value))));
                    for (int i = 0; i < 3; i++)
                        SQLite.Execute(string.Format("insert into Budget2 (amount) values ({0})", Convert.ToInt32(ToNoComma(spend_Human.Rows[i].Cells[1].Value))));
                    for (int i = 0; i < 3; i++)
                        SQLite.Execute(string.Format("insert into Budget2 (amount) values ({0})", Convert.ToInt32(ToNoComma(spend_Vol.Rows[i].Cells[1].Value))));
                    for (int i = 0; i < 10; i++)
                        SQLite.Execute(string.Format("insert into Budget2 (amount) values ({0})", Convert.ToInt32(ToNoComma(spend_Main.Rows[i].Cells[1].Value))));
                    for (int i = 0; i < 2; i++)
                        SQLite.Execute(string.Format("insert into Budget2 (amount) values ({0})", Convert.ToInt32(ToNoComma(spend_Loan.Rows[i].Cells[1].Value))));
                    SQLite.Execute(string.Format("insert into Budget2 (amount) values ({0})", Convert.ToInt32(ToNoComma(spend.Rows[7].Cells[1].Value))));
                }                
            }
            catch (SQLiteException e)
            {
                Debug.WriteLine(e);
            }
        }
        
        private void SetSpendBudgetDGV()
        {
            DataSet ds = SQLite.ExecuteSelectQuery(string.Format("select * from Budget2"));
            if(ds.Tables[0].Rows.Count == 0)
                for(int i = 0; i < 29; i++)
                    SQLite.Execute(string.Format("insert into Budget2 (amount) values({0})", 0));
            ds = SQLite.ExecuteSelectQuery(string.Format("select * from Budget2"));

            // Worship
            spend_Worship.Rows[0].Cells[0].Value = "  강단꽃꽃이";
            spend_Worship.Rows[1].Cells[0].Value = "  성가대운영비";
            spend_Worship.Rows[2].Cells[0].Value = "  주보대";
            for (int i = 0; i < 3; i++)
                spend_Worship.Rows[i].Cells[1].Value = ToComma(ds.Tables[0].Rows[i]["amount"].ToString());
            spend_Worship.Columns[0].ReadOnly = true;
                               
            for (int i = 0; i < spend_Worship.Columns.Count; i++)
                spend_Worship.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            for (int i = 0; i < spend_Worship.ColumnCount; i++)
                spend_Worship.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

            // Set Sumation.
            int sum = 0;
            for (int i = 0; i < 3; i++)
                if (spend_Worship.Rows[i].Cells[1].Value.ToString() != "")
                    sum += Convert.ToInt32(ToNoComma(spend_Worship.Rows[i].Cells[1].Value));
            Sum_Worship = sum;
            spend_Worship.Rows[11].Cells[0].Value = "  Total";
            spend_Worship.Rows[11].Cells[1].Value = ToComma(Sum_Worship);

            // Mission
            spend_Mission.Rows[0].Cells[0].Value = "  선교비";
            spend_Mission.Rows[1].Cells[0].Value = "  심방비";
            for (int i = 0; i < 2; i++)
                spend_Mission.Rows[i].Cells[1].Value = ToComma(ds.Tables[0].Rows[i+3]["amount"].ToString());
            spend_Mission.Columns[0].ReadOnly = true;

            for (int i = 0; i < spend_Mission.Columns.Count; i++)
                spend_Mission.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            for (int i = 0; i < spend_Mission.ColumnCount; i++)
                spend_Mission.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

            // Set Sumation.
            sum = 0;
            for (int i = 0; i < 2; i++)
                if (spend_Mission.Rows[i].Cells[1].Value.ToString() != "")
                    sum += Convert.ToInt32(ToNoComma(spend_Mission.Rows[i].Cells[1].Value));
            Sum_Mission = sum;
            spend_Mission.Rows[11].Cells[0].Value = "  Total";
            spend_Mission.Rows[11].Cells[1].Value = ToComma(Sum_Mission);

            // Edu
            spend_Edu.Rows[0].Cells[0].Value = "  주일학교지원비";
            spend_Edu.Rows[1].Cells[0].Value = "  학생부지원비";
            spend_Edu.Rows[2].Cells[0].Value = "  청년부지원비";
            spend_Edu.Rows[3].Cells[0].Value = "  장학금";
            spend_Edu.Rows[4].Cells[0].Value = "  도서비";
            for (int i = 0; i < 5; i++)
                spend_Edu.Rows[i].Cells[1].Value = ToComma(ds.Tables[0].Rows[i + 5]["amount"].ToString());
            spend_Edu.Columns[0].ReadOnly = true;

            for (int i = 0; i < spend_Edu.Columns.Count; i++)
                spend_Edu.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            for (int i = 0; i < spend_Edu.ColumnCount; i++)
                spend_Edu.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

            // Set Sumation.
            sum = 0;
            for (int i = 0; i < 5; i++)
                if (spend_Edu.Rows[i].Cells[1].Value.ToString() != "")
                    sum += Convert.ToInt32(ToNoComma(spend_Edu.Rows[i].Cells[1].Value));
            Sum_Edu = sum;
            spend_Edu.Rows[11].Cells[0].Value = "  Total";
            spend_Edu.Rows[11].Cells[1].Value = ToComma(Sum_Edu);

            // Human
            spend_Human.Rows[0].Cells[0].Value = "  목사님사례비";
            spend_Human.Rows[1].Cells[0].Value = "  전도사님사례비";
            spend_Human.Rows[2].Cells[0].Value = "  상여금";
            for (int i = 0; i < 3; i++)
                spend_Human.Rows[i].Cells[1].Value = ToComma(ds.Tables[0].Rows[i + 10]["amount"].ToString());
            spend_Human.Columns[0].ReadOnly = true;

            for (int i = 0; i < spend_Human.Columns.Count; i++)
                spend_Human.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            for (int i = 0; i < spend_Human.ColumnCount; i++)
                spend_Human.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

            // Set Sumation.
            sum = 0;
            for (int i = 0; i < 3; i++)
                if (spend_Human.Rows[i].Cells[1].Value.ToString() != "")
                    sum += Convert.ToInt32(ToNoComma(spend_Human.Rows[i].Cells[1].Value));
            Sum_Human = sum;
            spend_Human.Rows[11].Cells[0].Value = "  Total";
            spend_Human.Rows[11].Cells[1].Value = ToComma(Sum_Human);

            // Vol
            spend_Vol.Rows[0].Cells[0].Value = "  목사님사례비";
            spend_Vol.Rows[1].Cells[0].Value = "  전도사님사례비";
            spend_Vol.Rows[2].Cells[0].Value = "  상여금";
            for (int i = 0; i < 3; i++)
                spend_Vol.Rows[i].Cells[1].Value = ToComma(ds.Tables[0].Rows[i + 13]["amount"].ToString());
            spend_Vol.Columns[0].ReadOnly = true;

            for (int i = 0; i < spend_Vol.Columns.Count; i++)
                spend_Vol.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            for (int i = 0; i < spend_Vol.ColumnCount; i++)
                spend_Vol.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

            // Set Sumation.
            sum = 0;
            for (int i = 0; i < 3; i++)
                if (spend_Vol.Rows[i].Cells[1].Value.ToString() != "")
                    sum += Convert.ToInt32(ToNoComma(spend_Vol.Rows[i].Cells[1].Value));
            Sum_Vol = sum;
            spend_Vol.Rows[11].Cells[0].Value = "  Total";
            spend_Vol.Rows[11].Cells[1].Value = ToComma(Sum_Vol);

            // Main
            spend_Main.Rows[0].Cells[0].Value = "  사택유지비";
            spend_Main.Rows[1].Cells[0].Value = "  교회관리비";
            spend_Main.Rows[2].Cells[0].Value = "  목회활동비";
            spend_Main.Rows[3].Cells[0].Value = "  수도광열비";
            spend_Main.Rows[4].Cells[0].Value = "  통신비";
            spend_Main.Rows[5].Cells[0].Value = "  차량관리비";
            spend_Main.Rows[6].Cells[0].Value = "  차량구입비적립";
            spend_Main.Rows[7].Cells[0].Value = "  상회비";
            spend_Main.Rows[8].Cells[0].Value = "  교회비품비";
            spend_Main.Rows[9].Cells[0].Value = "  기타지출";
            for (int i = 0; i < 10; i++)
                spend_Main.Rows[i].Cells[1].Value = ToComma(ds.Tables[0].Rows[i + 16]["amount"].ToString());
            spend_Main.Columns[0].ReadOnly = true;

            for (int i = 0; i < spend_Main.Columns.Count; i++)
                spend_Main.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            for (int i = 0; i < spend_Main.ColumnCount; i++)
                spend_Main.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

            // Set Sumation.
            sum = 0;
            for (int i = 0; i < 10; i++)
                if (spend_Main.Rows[i].Cells[1].Value.ToString() != "")
                    sum += Convert.ToInt32(ToNoComma(spend_Main.Rows[i].Cells[1].Value));
            Sum_Main = sum;
            spend_Main.Rows[11].Cells[0].Value = "  Total";
            spend_Main.Rows[11].Cells[1].Value = ToComma(Sum_Main);

            // Loan
            spend_Loan.Rows[0].Cells[0].Value = "  상환적립";
            spend_Loan.Rows[1].Cells[0].Value = "  지급이자";
            for (int i = 0; i < 2; i++)
                spend_Loan.Rows[i].Cells[1].Value = ToComma(ds.Tables[0].Rows[i + 26]["amount"].ToString());
            spend_Loan.Columns[0].ReadOnly = true;

            for (int i = 0; i < spend_Loan.Columns.Count; i++)
                spend_Loan.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            for (int i = 0; i < spend_Loan.ColumnCount; i++)
                spend_Loan.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

            // Set Sumation.
            sum = 0;
            for (int i = 0; i < 2; i++)
                if (spend_Loan.Rows[i].Cells[1].Value.ToString() != "")
                    sum += Convert.ToInt32(ToNoComma(spend_Loan.Rows[i].Cells[1].Value));
            Sum_Loan = sum;
            spend_Loan.Rows[11].Cells[0].Value = "  Total";
            spend_Loan.Rows[11].Cells[1].Value = ToComma(Sum_Loan);

            // Res
            Sum_Res = Convert.ToInt32(ds.Tables[0].Rows[28]["amount"]);
        }
        
        private void SetInputSumDGV()
        {
            try
            {
                spend.Rows.Clear();

                // 예배비
                String[] a = { "  예배비", ToComma(Sum_Worship.ToString()) };
                spend.Rows.Add(a);

                // 선교비
                string[] b = { "  선교비", ToComma(Sum_Mission.ToString()) };
                spend.Rows.Add(b);

                // 교육비
                string[] c = { "  교육비", ToComma(Sum_Edu.ToString()) };
                spend.Rows.Add(c);

                // 인건비
                string[] d = { "  인건비", ToComma(Sum_Human.ToString()) };
                spend.Rows.Add(d);

                // 봉사비
                string[] e = { "  봉사비", ToComma(Sum_Vol.ToString()) };
                spend.Rows.Add(e);

                // 운영관리비
                string[] f = { "  운영관리비", ToComma(Sum_Main.ToString()) };
                spend.Rows.Add(f);

                // 대출관련비
                string[] g = { "  대출관련비", ToComma(Sum_Loan.ToString()) };
                spend.Rows.Add(g);

                // 예비비
                string[] h = { "  예비비", ToComma(Sum_Res.ToString()) };
                spend.Rows.Add(h);
                string[] q;
                for(int i=0; i < 3; i++)
                {
                    q = new string[] { "", "" };
                    spend.Rows.Add(q);
                }

                // Total of Total
                int sumn = 0;
                for (int i = 0; i < spend.RowCount - 1; i++)
                    if (spend.Rows[i].Cells[1].Value.ToString() != "")
                        sumn += Convert.ToInt32(ToNoComma(spend.Rows[i].Cells[1].Value));

                // 합계
                string[] m = { "  Total", ToComma(sumn.ToString()) };
                spend.Rows.Add(m);

                for(int i = 0; i < 12; i++)
                    if( i != 7 )
                        spend.Rows[i].Cells[1].ReadOnly = true;
                
            }
            catch (SQLiteException e)
            {
                Debug.WriteLine(e);
            }
        }
    }
}

