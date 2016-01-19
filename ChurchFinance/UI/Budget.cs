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

        int Worship;
        int Mis;
        int Edu;
        int Human;
        int Vol;
        int Main;
        int Loan;
        int Res;
        int Sum_spend;

        public Budget()
        {
            InitializeComponent();
            SQLite = new SQLite();

            SetView();
            CreateTable();
            GetValues();
            SetRows();
            dgv.CellEndEdit += Dgv_CellEndEdit;
            dgv1.CellEndEdit += Dgv1_CellEndEdit;

        }

        private void Dgv1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            for (int i = 0; i < dgv1.RowCount - 3; i++)
                dgv1.Rows[i].Cells[1].Value = ToComma(dgv1.Rows[i].Cells[1].Value);

            int sum = 0;
            for(int i = 0; i < 8; i ++)
                sum += Convert.ToInt32(ToNoComma(dgv1.Rows[i].Cells[1].Value));

            dgv1.Rows[9].Cells[1].Value = ToComma(sum);
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
            dgv.Location = new Point(170, 50);
            dgv.Size = new Size(300, 332);
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.ColumnHeadersHeight = 30;
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.ColumnCount = 2;
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


            // dgv1
            dgv1.Location = new Point(500, 50);
            dgv1.Size = new Size(300, 332);
            dgv1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv1.ColumnHeadersHeight = 30;
            dgv1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv1.ColumnCount = 2;
            dgv1.RowTemplate.Height = 30;
            dgv1.RowCount = 11;
            dgv1.Font = new Font("Microsoft Sans Serif", 12);
            dgv1.AllowUserToAddRows = false;

            dgv1.CellFormatting += Dgv1_CellFormatting;
            dgv1.EditingControlShowing += Dgv1_EditingControlShowing;

            dgv1.Columns[0].Name = "항 목";
            dgv1.Columns[1].Name = "금 액";
            dgv1.Columns["항 목"].ReadOnly = true;

            for (int i = 0; i < dgv1.Columns.Count; i++)
                dgv1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
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

                Worship = 0;
                Mis = 0;
                Edu = 0;
                Human = 0;
                Vol = 0;
                Main = 0;
                Loan = 0;
                Res = 0;
                Sum_spend = 0;
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

                Worship = Convert.ToInt32(ds.Tables[0].Rows[9]["amount"]);
                Mis = Convert.ToInt32(ds.Tables[0].Rows[10]["amount"]);
                Edu = Convert.ToInt32(ds.Tables[0].Rows[11]["amount"]);
                Human = Convert.ToInt32(ds.Tables[0].Rows[12]["amount"]);
                Vol = Convert.ToInt32(ds.Tables[0].Rows[13]["amount"]);
                Main = Convert.ToInt32(ds.Tables[0].Rows[14]["amount"]);
                Loan = Convert.ToInt32(ds.Tables[0].Rows[15]["amount"]);
                Res = Convert.ToInt32(ds.Tables[0].Rows[16]["amount"]);
                Sum_spend = Worship + Mis + Edu + Human + Vol + Main + Loan + Res;
            }
        }
        private void SetRows()
        {
            dgv.Rows[0].Cells[0].Value = "감사헌금";
            dgv.Rows[0].Cells[1].Value = Thanks;
            dgv.Rows[1].Cells[0].Value = "십일조";
            dgv.Rows[1].Cells[1].Value = O10;
            dgv.Rows[2].Cells[0].Value = "구역헌금";
            dgv.Rows[2].Cells[1].Value = Cell;
            dgv.Rows[3].Cells[0].Value = "건축헌금";
            dgv.Rows[3].Cells[1].Value = Archi;
            dgv.Rows[4].Cells[0].Value = "선교헌금";
            dgv.Rows[4].Cells[1].Value = Mission;
            dgv.Rows[5].Cells[0].Value = "성미헌금";
            dgv.Rows[5].Cells[1].Value = Rice;
            dgv.Rows[6].Cells[0].Value = "구제헌금";
            dgv.Rows[6].Cells[1].Value = Help;
            dgv.Rows[7].Cells[0].Value = "차량헌금";
            dgv.Rows[7].Cells[1].Value = Car;
            dgv.Rows[8].Cells[0].Value = "절기헌금";
            dgv.Rows[8].Cells[1].Value = Term;
            dgv.Rows[9].Cells[0].Value = "Total";
            int sum = 0;
            for (int i = 0; i < 9; i++)
                sum += Convert.ToInt32(dgv.Rows[i].Cells[1].Value);
            dgv.Rows[9].Cells[1].Value = sum;
            dgv.Rows[9].Height = 30;
            dgv.Rows[9].ReadOnly = true;

            dgv1.Rows[0].Cells[0].Value = "예배비";
            dgv1.Rows[0].Cells[1].Value = Worship;
            dgv1.Rows[1].Cells[0].Value = "선교비";
            dgv1.Rows[1].Cells[1].Value = Mis;
            dgv1.Rows[2].Cells[0].Value = "교육비";
            dgv1.Rows[2].Cells[1].Value = Edu;
            dgv1.Rows[3].Cells[0].Value = "인건비";
            dgv1.Rows[3].Cells[1].Value = Human;
            dgv1.Rows[4].Cells[0].Value = "봉사비";
            dgv1.Rows[4].Cells[1].Value = Vol;
            dgv1.Rows[5].Cells[0].Value = "운영관리비";
            dgv1.Rows[5].Cells[1].Value = Main;
            dgv1.Rows[6].Cells[0].Value = "대출관련비";
            dgv1.Rows[6].Cells[1].Value = Loan;
            dgv1.Rows[7].Cells[0].Value = "예비비";
            dgv1.Rows[7].Cells[1].Value = Res;
            dgv1.Rows[9].Cells[0].Value = "Total";
            sum = 0;
            for (int i = 0; i < 8; i++)
                sum += Convert.ToInt32(dgv1.Rows[i].Cells[1].Value);
            dgv1.Rows[9].Cells[1].Value = sum;
            dgv1.Rows[9].Height = 30;
            dgv1.Rows[8].ReadOnly = true;
            dgv1.Rows[9].ReadOnly = true;
        }

        private void CreateTable()
        {
            int err;
            err = SQLite.Execute(string.Format("create table Budget " +
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
        public void ButtonEvent()
        {
            SQLite.Execute(string.Format("drop table Budget"));
            CreateTable();
            try
            {
                for(int i = 0; i < 9; i ++ )
                    SQLite.Execute(string.Format("insert into Budget (amount) values ({0})", Convert.ToInt32(ToNoComma(dgv.Rows[i].Cells[1].Value))));
                for (int i = 0; i < 8; i++ )
                    SQLite.Execute(string.Format("insert into Budget (amount) values ({0})", Convert.ToInt32(ToNoComma(dgv1.Rows[i].Cells[1].Value))));
            }
            catch (SQLiteException e)
            {
                Debug.WriteLine(e);
            }
        }
    }
}

