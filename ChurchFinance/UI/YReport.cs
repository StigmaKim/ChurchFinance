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
using System.Drawing.Printing;

namespace UI
{
    public partial class YReport : UserControl
    {

        #region 변수 선언
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
        int Other;
        int Interest;
        int sum;
        
        private DateTime date;

        #endregion

        PrintDocument pd;
        PageSettings pgSettings;
        Button printButton;

        #region 생성자

        public YReport(Button printBtn)
        {
            InitializeComponent();
            SQLite = new SQLite();

            #region 예시 데이터 입력
            date = DateTime.Now;

            Thanks = 0;
            O10 = 0;
            Cell = 0;
            Archi = 0;
            Mission = 0;
            Rice = 0;
            Help = 0;
            Car = 0;
            Term = 0;

            sum = 0;

            #endregion

            NN.Location = new Point(750, 50);
            NN.Font = new Font("Microsoft Sans Serif", 13);
            name.Font = new Font("Microsoft Sans Serif", 15);

            NNbtn.Location = new Point(875, 50);
            NNbtn.Size = new Size(70, 26);
            NNbtn.Font = new Font("Microsoft Sans Serif", 12);
            NNbtn.Text = "검색";
            NNbtn.TextAlign = ContentAlignment.MiddleCenter;

            NNbtn.Click += NNbtn_Click;


            sum = Thanks + O10 + Cell + Archi + Mission + Rice + Help + Car + Term + Other + Interest;

            // Income DataGridView 설정
            setIncome();

            // 합계부분 두 DataGridView를 설정합니다.
            setTotal();

            inputData();

            pd = new PrintDocument();
            pgSettings = new PageSettings();

            printButton = printBtn;
            printButton.Click += PrintButton_Click;
            Paint += YReport_Paint;
            pd.PrintPage += Pd_PrintPage;   
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog ppd = new PrintPreviewDialog();

            ppd.Document = pd;

            ppd.ShowDialog();

        }

        private void Pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            int curYPos = 80;

            income.RowHeadersVisible = false;

            SizeF sz = e.Graphics.MeasureString(title.Text, new Font("Tahoma", 20));
            e.Graphics.DrawString(title.Text, new Font("Tahoma", 20), new SolidBrush(Color.Black), new Point((int)(pgSettings.PaperSize.Width / 2 - (sz.Width / 2)), curYPos));

            curYPos += 80;

            SizeF nameSz = e.Graphics.MeasureString(name.Text, new Font("Tahoma", 15));
            e.Graphics.DrawString(name.Text, new Font("Tahoma", 12), new SolidBrush(Color.Black), new Point((int)(pgSettings.PaperSize.Width / 2 - (nameSz.Width / 2)), curYPos));

            curYPos += 120;

            Bitmap bm = new Bitmap(this.income.Width, this.income.Height);
            income.DrawToBitmap(bm, new Rectangle(0, 0, this.income.Width, this.income.Height));

            // DataGridView 그리기
            // e.Graphics.DrawImage(bm, new Rectangle(pgSettings.Margins.Right / 2, curYPos, pgSettings.PaperSize.Width - ((pgSettings.Margins.Left / 2) + pgSettings.Margins.Right), this.income.Height));
            e.Graphics.DrawImage(bm, new Rectangle((pgSettings.PaperSize.Width / 2 - bm.Width / 2), curYPos, this.income.Width, this.income.Height));
            
            curYPos += bm.Size.Height + 15;

            income.RowHeadersVisible = true;
            total.RowHeadersVisible = false;

            Bitmap totalBm = new Bitmap(this.total.Width, this.total.Height);
            total.DrawToBitmap(totalBm, new Rectangle(0, 0, this.total.Width, this.total.Height));

            // DataGridView 그리기
            // e.Graphics.DrawImage(bm, new Rectangle(pgSettings.Margins.Right / 2, curYPos, pgSettings.PaperSize.Width - ((pgSettings.Margins.Left / 2) + pgSettings.Margins.Right), this.income.Height));
            e.Graphics.DrawImage(totalBm, new Rectangle((pgSettings.PaperSize.Width / 2 - totalBm.Width / 2), curYPos, this.total.Width, this.total.Height));


            total.RowHeadersVisible = true;            

        }

        public void SetDate(DateTime d)
        {
            date = d;
        }

        public void InitializeValue()
        {
            // Initial Value
            Thanks = 0;
            O10 = 0;
            Cell = 0;
            Archi = 0;
            Mission = 0;
            Rice = 0;
            Help = 0;
            Car = 0;
            Term = 0;
            sum = 0;

            name.Text = "";
            NN.Text = "";
        }
        private void NNbtn_Click(object sender, EventArgs e)
        {
            // Initial Value
            Thanks = 0;
            O10 = 0;
            Cell = 0;
            Archi = 0;
            Mission = 0;
            Rice = 0;
            Help = 0;
            Car = 0;
            Term = 0;

            // Set Name
            name.Text = NN.Text;
            DataSet temp;
            if ( (temp = SQLite.ExecuteSelectQuery(string.Format("select sum(amount) as sum from Offering_Thanks where name = '{0}' AND strftime('%Y', date) = '{1}'", NN.Text, date.Year))).Tables[0].Rows[0]["sum"] != DBNull.Value)
                Thanks = Convert.ToInt32(temp.Tables[0].Rows[0]["sum"]);
            if ( (temp = SQLite.ExecuteSelectQuery(string.Format("select sum(amount) as sum from Offering_10 where name = '{0}' AND strftime('%Y', date) = '{1}'", NN.Text, date.Year))).Tables[0].Rows[0]["sum"] != DBNull.Value)
                O10 = Convert.ToInt32(temp.Tables[0].Rows[0]["sum"]);
            if ( (temp = SQLite.ExecuteSelectQuery(string.Format("select sum(amount) as sum from Offering_Cell where name = '{0}' AND strftime('%Y', date) = '{1}'", NN.Text, date.Year))).Tables[0].Rows[0]["sum"] != DBNull.Value)
                Cell = Convert.ToInt32(temp.Tables[0].Rows[0]["sum"]);
            if ( (temp = SQLite.ExecuteSelectQuery(string.Format("select sum(amount) as sum from Offering_Archi where name = '{0}' AND strftime('%Y', date) = '{1}'", NN.Text, date.Year))).Tables[0].Rows[0]["sum"] != DBNull.Value)
                Archi = Convert.ToInt32(temp.Tables[0].Rows[0]["sum"]);
            if ( (temp = SQLite.ExecuteSelectQuery(string.Format("select sum(amount) as sum from Offering_Mission where name = '{0}' AND strftime('%Y', date) = '{1}'", NN.Text, date.Year))).Tables[0].Rows[0]["sum"] != DBNull.Value)
                Mission = Convert.ToInt32(temp.Tables[0].Rows[0]["sum"]);
            if ( (temp = SQLite.ExecuteSelectQuery(string.Format("select sum(amount) as sum from Offering_Rice where name = '{0}' AND strftime('%Y', date) = '{1}'", NN.Text, date.Year))).Tables[0].Rows[0]["sum"] != DBNull.Value)
                Rice = Convert.ToInt32(temp.Tables[0].Rows[0]["sum"]);
            if ( (temp = SQLite.ExecuteSelectQuery(string.Format("select sum(amount) as sum from Offering_Help where name = '{0}' AND strftime('%Y', date) = '{1}'", NN.Text, date.Year))).Tables[0].Rows[0]["sum"] != DBNull.Value)
                Help = Convert.ToInt32(temp.Tables[0].Rows[0]["sum"]);
            if ( (temp = SQLite.ExecuteSelectQuery(string.Format("select sum(amount) as sum from Offering_Car where name = '{0}' AND strftime('%Y', date) = '{1}'", NN.Text, date.Year))).Tables[0].Rows[0]["sum"] != DBNull.Value)
                Car = Convert.ToInt32(temp.Tables[0].Rows[0]["sum"]);
            if ( (temp = SQLite.ExecuteSelectQuery(string.Format("select sum(amount) as sum from Offering_Term where name = '{0}' AND strftime('%Y', date) = '{1}'", NN.Text, date.Year))).Tables[0].Rows[0]["sum"] != DBNull.Value)
                Term = Convert.ToInt32(temp.Tables[0].Rows[0]["sum"]);

            sum = Thanks + O10 + Cell + Archi + Mission + Rice + Help + Car + Term;
            inputData();
            setText();
        }

        #endregion

        #region DataGridView 설정

        /// <summary>
        /// Income DataGridView를 설정
        /// </summary>

        private void setText()
        {
            // 라벨 텍스트 수정
            title.Text = date.Year + "년도 재정 보고";
            title.Location = new Point(380, 20);
            name.Location = new Point(380, 50);
            name.Size = new Size(205, 25);
            name.AutoSize = false;
            name.Font = new Font("Microsoft Sans Serif", 13);
            name.TextAlign = HorizontalAlignment.Center;
            name.BorderStyle = BorderStyle.None;
        }

        private void setIncome()
        {
            income.ClearSelection();
            income.Location = new Point(290, 80);
            income.Size = new Size(400, 352);
            income.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            income.ColumnCount = 2;
            income.RowTemplate.Height = 35;
            income.RowHeadersVisible = false;

            for (int i = 0; i < income.Columns.Count; i++)
                income.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            for (int i = 0; i < income.ColumnCount; i++)
                income.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

            income.Columns[0].HeaderText = "항 목";
            income.Columns[1].HeaderText = "금 액";

            income.ReadOnly = true;
            income.RowCount = 9;

            income.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            income.ColumnHeadersHeight = 35;
            income.Rows[0].Cells[0].Value = "  감사헌금";
            income.Rows[1].Cells[0].Value = "  십일조";
            income.Rows[2].Cells[0].Value = "  구역헌금";
            income.Rows[3].Cells[0].Value = "  건축헌금";
            income.Rows[4].Cells[0].Value = "  선교헌금";
            income.Rows[5].Cells[0].Value = "  성미헌금";
            income.Rows[6].Cells[0].Value = "  구제헌금";
            income.Rows[7].Cells[0].Value = "  차량헌금";
            income.Rows[8].Cells[0].Value = "  절기헌금";
            income.Rows[8].Height = 35;
            income.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            income.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            income.Font = new Font("Microsoft Sans Serif", 14);
            income.RowHeadersDefaultCellStyle.Padding = new Padding(income.RowHeadersWidth);

            income.SelectionChanged += Income_SelectionChanged;
            income.ClearSelection();
        }

        private void Income_SelectionChanged(object sender, EventArgs e)
        {
            income.ClearSelection();
        }

        /// <summary>
        /// 합계부분 두 DataGridView를 설정합니다.
        /// </summary>
        private void setTotal()
        {
            // total
            total.ClearSelection();
            total.Location = new Point(290, 440);
            total.Size = new Size(400, 37);
            total.RowHeadersVisible = false;
            total.ColumnCount = 2;
            total.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            total.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            total.ColumnHeadersVisible = false;
            total.ReadOnly = true;
            total.RowTemplate.Height = 35;
            total.RowCount = 2;
            total.AllowUserToAddRows = false;
            total.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            total.ColumnHeadersHeight = 30;
            total.Font = new Font("Microsoft Sans Serif", 14);
            total.RowHeadersDefaultCellStyle.Padding = new Padding(income.RowHeadersWidth);
            total.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            total.AllowUserToResizeRows = false;
            total.AllowUserToResizeColumns = false;

            for (int i = 0; i < total.Columns.Count; i++)
                total.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            total.Rows[0].Cells[0].Value = "  총계";

            total.SelectionChanged += Total_SelectionChanged;
            total.ClearSelection();
        }

        private void Total_SelectionChanged(object sender, EventArgs e)
        {
            total.ClearSelection();
        }

        #endregion

        #region 데이터 입력

        /// <summary>
        /// 값 넣기
        /// </summary>
        private void inputData()
        {
            // 수입
            income.Rows[0].Cells[1].Value = Thanks.ToString("n0") + " 원";
            income.Rows[1].Cells[1].Value = O10.ToString("n0") + " 원";
            income.Rows[2].Cells[1].Value = Cell.ToString("n0") + " 원";
            income.Rows[3].Cells[1].Value = Archi.ToString("n0") + " 원";
            income.Rows[4].Cells[1].Value = Mission.ToString("n0") + " 원";
            income.Rows[5].Cells[1].Value = Rice.ToString("n0") + " 원";
            income.Rows[6].Cells[1].Value = Help.ToString("n0") + " 원";
            income.Rows[7].Cells[1].Value = Car.ToString("n0") + " 원";
            income.Rows[8].Cells[1].Value = Term.ToString("n0") + " 원";

            total.Rows[0].Cells[1].Value = sum.ToString("n0") + " 원";
        }

        #endregion

        private void YReport_Paint(object sender, PaintEventArgs e)
        {
            inputData();
            setText();
        }

    }
}
