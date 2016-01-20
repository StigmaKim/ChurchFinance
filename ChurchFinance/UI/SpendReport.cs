using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class SpendReport : UserControl
    {

        #region public 변수

        int Thanks;
        int O10;
        int Cell;
        int Archi;
        int Mission;
        int Rice;
        int Help;
        int Car;
        int Term;
        int Other;
        int Interest;
        int sum;

        int Worship;
        int SMission;
        int Edu;
        int Human;
        int Vol;
        int Main;
        int Loan;
        int Res;
        int spendSum;

        int balance;

        SQLite SQLite;
        
        private DateTime date;

        #endregion
                
        public SpendReport()
        {
            InitializeComponent();
            SQLite = new SQLite();

            Title.Location = new Point(380, 20);
            spend.ClearSelection();
            
            Paint += SpendReport_Paint;
        }
        
        public void SetDate(DateTime d)
        {
            date = d;
        }
        private void SpendReport_Paint(object sender, PaintEventArgs e)
        {
            Title.Text = date.Year + "년 " + date.Month + "월 재정 보고";

            setIncomeDGV();
            setSpendDGV();
            setTotalDGVS();
            setIncomeFromDB();
            setSpendFromDB();
            setValueIntoDGVS();
        }

        private void setValueIntoDGVS()
        {
            income.Rows[0].Cells[1].Value = Thanks.ToString("n0") + " 원";
            income.Rows[1].Cells[1].Value = O10.ToString("n0") + " 원";
            income.Rows[2].Cells[1].Value = Cell.ToString("n0") + " 원";
            income.Rows[3].Cells[1].Value = Archi.ToString("n0") + " 원";
            income.Rows[4].Cells[1].Value = Mission.ToString("n0") + " 원";
            income.Rows[5].Cells[1].Value = Rice.ToString("n0") + " 원";
            income.Rows[6].Cells[1].Value = Help.ToString("n0") + " 원";
            income.Rows[7].Cells[1].Value = Car.ToString("n0") + " 원";
            income.Rows[8].Cells[1].Value = Term.ToString("n0") + " 원";
            income.Rows[9].Cells[1].Value = Other.ToString("n0") + " 원";
            income.Rows[10].Cells[1].Value = Interest.ToString("n0") + " 원";
            income.Rows[11].Cells[1].Value = sum.ToString("n0") + " 원";

            spend.Rows[0].Cells[1].Value = Worship.ToString("n0") + " 원";
            spend.Rows[1].Cells[1].Value = SMission.ToString("n0") + " 원";
            spend.Rows[2].Cells[1].Value = Edu.ToString("n0") + " 원";
            spend.Rows[3].Cells[1].Value = Human.ToString("n0") + " 원";
            spend.Rows[4].Cells[1].Value = Vol.ToString("n0") + " 원";
            spend.Rows[5].Cells[1].Value = Main.ToString("n0") + " 원";
            spend.Rows[6].Cells[1].Value = Loan.ToString("n0") + " 원";
            spend.Rows[7].Cells[1].Value = Res.ToString("n0") + " 원";
            spend.Rows[11].Cells[1].Value = spendSum.ToString("n0") + " 원";
        }

        public void setIncomeFromDB()
        {
            Thanks = SQLite.ExecuteSumQuery(string.Format("select sum(amount) from Offering_Thanks where strftime('%Y-%m', date) = '{0}'", string.Format(date.Year.ToString() + "-" + date.Month.ToString("d2"))));
            O10 = SQLite.ExecuteSumQuery(string.Format("select sum(amount) from Offering_10 where strftime('%Y-%m', date) = '{0}'", string.Format(date.Year.ToString() + "-" + date.Month.ToString("d2"))));
            Cell = SQLite.ExecuteSumQuery(string.Format("select sum(amount) from Offering_Cell where strftime('%Y-%m', date) = '{0}'", string.Format(date.Year.ToString() + "-" + date.Month.ToString("d2"))));
            Archi = SQLite.ExecuteSumQuery(string.Format("select sum(amount) from Offering_Archi where strftime('%Y-%m', date) = '{0}'", string.Format(date.Year.ToString() + "-" + date.Month.ToString("d2"))));
            Mission = SQLite.ExecuteSumQuery(string.Format("select sum(amount) from Offering_Mission where strftime('%Y-%m', date) = '{0}'", string.Format(date.Year.ToString() + "-" + date.Month.ToString("d2"))));
            Rice = SQLite.ExecuteSumQuery(string.Format("select sum(amount) from Offering_Rice where strftime('%Y-%m', date) = '{0}'", string.Format(date.Year.ToString() + "-" + date.Month.ToString("d2"))));
            Help = SQLite.ExecuteSumQuery(string.Format("select sum(amount) from Offering_Help where strftime('%Y-%m', date) = '{0}'", string.Format(date.Year.ToString() + "-" + date.Month.ToString("d2"))));
            Car = SQLite.ExecuteSumQuery(string.Format("select sum(amount) from Offering_Car where strftime('%Y-%m', date) = '{0}'", string.Format(date.Year.ToString() + "-" + date.Month.ToString("d2"))));
            Term = SQLite.ExecuteSumQuery(string.Format("select sum(amount) from Offering_Term where strftime('%Y-%m', date) = '{0}'", string.Format(date.Year.ToString() + "-" + date.Month.ToString("d2"))));
            Other = SQLite.ExecuteSumQuery(string.Format("select sum(amount) from Offering_Other where strftime('%Y-%m', date) = '{0}'", string.Format(date.Year.ToString() + "-" + date.Month.ToString("d2"))));
            Interest = SQLite.ExecuteSumQuery(string.Format("select sum(amount) from Offering_Interest where strftime('%Y-%m', date) = '{0}'", string.Format(date.Year.ToString() + "-" + date.Month.ToString("d2"))));

            sum = Thanks + O10 + Cell + Archi + Mission + Rice + Help + Car + Term + Other + Interest;
        }

        public void setSpendFromDB()
        {
            Worship = SQLite.ExecuteSumQuery(string.Format("select sum(amount) from Spending_Worship where strftime('%Y-%m', date) = '{0}'", string.Format(date.Year.ToString() + "-" + date.Month.ToString("d2"))));
            SMission = SQLite.ExecuteSumQuery(string.Format("select sum(amount) from Spending_Mission where strftime('%Y-%m', date) = '{0}'", string.Format(date.Year.ToString() + "-" + date.Month.ToString("d2"))));
            Edu = SQLite.ExecuteSumQuery(string.Format("select sum(amount) from Spending_Edu where strftime('%Y-%m', date) = '{0}'", string.Format(date.Year.ToString() + "-" + date.Month.ToString("d2"))));
            Human = SQLite.ExecuteSumQuery(string.Format("select sum(amount) from Spending_Human where strftime('%Y-%m', date) = '{0}'", string.Format(date.Year.ToString() + "-" + date.Month.ToString("d2"))));
            Vol = SQLite.ExecuteSumQuery(string.Format("select sum(amount) from Spending_Vol where strftime('%Y-%m', date) = '{0}'", string.Format(date.Year.ToString() + "-" + date.Month.ToString("d2"))));
            Main = SQLite.ExecuteSumQuery(string.Format("select sum(amount) from Spending_Main where strftime('%Y-%m', date) = '{0}'", string.Format(date.Year.ToString() + "-" + date.Month.ToString("d2"))));
            Loan = SQLite.ExecuteSumQuery(string.Format("select sum(amount) from Spending_Loan where strftime('%Y-%m', date) = '{0}'", string.Format(date.Year.ToString() + "-" + date.Month.ToString("d2"))));
            Res = SQLite.ExecuteSumQuery(string.Format("select sum(amount) from Spending_Res where strftime('%Y-%m', date) = '{0}'", string.Format(date.Year.ToString() + "-" + date.Month.ToString("d2"))));

            spendSum = Worship + SMission + Edu + Human + Vol + Main + Loan + Res;
        }
        
        private void setIncomeDGV()
        {
            income.ClearSelection();
            income.Location = new Point(180, 70);
            income.Size = new Size(300, 392);
            income.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            income.ColumnCount = 2;
            income.RowTemplate.Height = 30;
            income.RowHeadersVisible = false;

            for (int i = 0; i < income.Columns.Count; i++)
                income.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            for (int i = 0; i < income.ColumnCount; i++)
                income.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

            income.Columns[0].HeaderText = "항 목";
            income.Columns[1].HeaderText = "금 액";

            income.ReadOnly = true;
            income.RowCount = 12;

            income.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            income.ColumnHeadersHeight = 30;
            income.Rows[0].Cells[0].Value = "  감사헌금";
            income.Rows[1].Cells[0].Value = "  십일조";
            income.Rows[2].Cells[0].Value = "  구역헌금";
            income.Rows[3].Cells[0].Value = "  건축헌금";
            income.Rows[4].Cells[0].Value = "  선교헌금";
            income.Rows[5].Cells[0].Value = "  성미헌금";
            income.Rows[6].Cells[0].Value = "  구제헌금";
            income.Rows[7].Cells[0].Value = "  차량헌금";
            income.Rows[8].Cells[0].Value = "  절기헌금";
            income.Rows[9].Cells[0].Value = "  기타수입";
            income.Rows[10].Cells[0].Value = "  이자수입";
            income.Rows[11].Cells[0].Value = "  수입 총액";
            income.Rows[11].Height = 30;
            income.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            income.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            income.Font = new Font("Microsoft Sans Serif", 12);
            income.Rows[0].Height = 30;
            income.RowHeadersDefaultCellStyle.Padding = new Padding(income.RowHeadersWidth);

            income.SelectionChanged += Income_SelectionChanged;
        }

        private void Income_SelectionChanged(object sender, EventArgs e)
        {
            income.ClearSelection();
        }

        private void setSpendDGV()
        {
            spend.ClearSelection();
            spend.Location = new Point(490, 70);
            spend.Size = new Size(300, 392);
            
            spend.ColumnCount = 2;
            spend.RowTemplate.Height = 30;
            spend.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            spend.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            spend.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            spend.RowHeadersVisible = false;
            spend.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            spend.ColumnHeadersHeight = 30;

            for (int i = 0; i < spend.Columns.Count; i++)
                spend.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            for (int i = 0; i < spend.ColumnCount; i++)
                spend.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

            spend.Columns[0].HeaderText = "항 목";
            spend.Columns[1].HeaderText = "금 액";

            spend.ReadOnly = true;
            spend.RowCount = 12;

            spend.Rows[0].Cells[0].Value = "  예배비";
            spend.Rows[1].Cells[0].Value = "  선교비";
            spend.Rows[2].Cells[0].Value = "  교육비";
            spend.Rows[3].Cells[0].Value = "  인건비";
            spend.Rows[4].Cells[0].Value = "  봉사비";
            spend.Rows[5].Cells[0].Value = "  운영관리비";
            spend.Rows[6].Cells[0].Value = "  대출관련비";
            spend.Rows[7].Cells[0].Value = "  예비비";
            spend.Rows[11].Cells[0].Value = "  지출 총액";

            spend.Rows[11].Height = 30;

            spend.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            spend.Font = new Font("Microsoft Sans Serif", 12);
            spend.RowHeadersDefaultCellStyle.Padding = new Padding(income.RowHeadersWidth);

            spend.SelectionChanged += Spend_SelectionChanged;
        }

        private void Spend_SelectionChanged(object sender, EventArgs e)
        {
            spend.ClearSelection();
        }

        private void setTotalDGVS()
        {
            // beforeBalance
            beforeBalance.ClearSelection();
            beforeBalance.SelectionChanged += BeforeBalance_SelectionChanged;
            beforeBalance.Location = new Point(180, 470);
            beforeBalance.Size = new Size(300, 33);
            beforeBalance.RowHeadersVisible = false;
            beforeBalance.ColumnCount = 2;
            beforeBalance.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            beforeBalance.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            beforeBalance.ColumnHeadersVisible = false;
            beforeBalance.ReadOnly = true;
            beforeBalance.RowTemplate.Height = 30;
            beforeBalance.RowCount = 2;
            beforeBalance.AllowUserToAddRows = false;
            beforeBalance.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            beforeBalance.ColumnHeadersHeight = 30;
            beforeBalance.Font = new Font("Microsoft Sans Serif", 12);
            beforeBalance.RowHeadersDefaultCellStyle.Padding = new Padding(income.RowHeadersWidth);
            beforeBalance.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            beforeBalance.AllowUserToResizeRows = false;
            beforeBalance.AllowUserToResizeColumns = false;

            for (int i = 0; i < beforeBalance.Columns.Count; i++)
                beforeBalance.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            beforeBalance.Rows[0].Cells[0].Value = "  전월 이월액";

            // afterBalance
            afterBalance.ClearSelection();
            afterBalance.SelectionChanged += AfterBalance_SelectionChanged;
            afterBalance.Location = new Point(490, 470);
            afterBalance.Size = new Size(300, 33);
            afterBalance.RowHeadersVisible = false;
            afterBalance.ColumnCount = 2;
            afterBalance.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            afterBalance.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            afterBalance.ColumnHeadersVisible = false;
            afterBalance.ReadOnly = true;
            afterBalance.RowTemplate.Height = 30;
            afterBalance.RowCount = 2;
            afterBalance.AllowUserToAddRows = false;
            afterBalance.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            afterBalance.ColumnHeadersHeight = 30;
            afterBalance.Font = new Font("Microsoft Sans Serif", 12);
            afterBalance.RowHeadersDefaultCellStyle.Padding = new Padding(income.RowHeadersWidth);
            afterBalance.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            afterBalance.AllowUserToResizeRows = false;
            afterBalance.AllowUserToResizeColumns = false;

            for (int i = 0; i < afterBalance.Columns.Count; i++)
                afterBalance.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            afterBalance.Rows[0].Cells[0].Value = "  잔 액";
        }

        private void AfterBalance_SelectionChanged(object sender, EventArgs e)
        {
            afterBalance.ClearSelection();
        }

        private void BeforeBalance_SelectionChanged(object sender, EventArgs e)
        {
            beforeBalance.ClearSelection();
        }
    }
}
