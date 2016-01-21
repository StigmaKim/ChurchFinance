using NeoTabControlLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Diagnostics;

namespace UI
{
    public partial class Form1 : Form
    {
        // DataGridView 생성
        DataGridView income = null;
        DataGridView income_total = null;
        DataGridView _income_total = null;

        DataGridView _income_Thanks = null;
        DataGridView _income_10 = null;
        DataGridView _income_Cell = null;
        DataGridView _income_Archi = null;
        DataGridView _income_Mission = null;
        DataGridView _income_Rice = null;
        DataGridView _income_Help = null;
        DataGridView _income_Car = null;
        DataGridView _income_Term = null;
        DataGridView _income_Other = null;
        DataGridView _income_Interest = null;

        int Sum_Thanks = 0;
        int Sum_10 = 0;
        int Sum_Cell = 0;
        int Sum_Archi = 0;
        int Sum_Mission = 0;
        int Sum_Rice = 0;
        int Sum_Help = 0;
        int Sum_Car = 0;
        int Sum_Term = 0;
        int Sum_Other = 0;
        int Sum_Interest = 0;

        WeekSpendPage WSP = null;

        string currentCategory = null;
        Control currentTab = null;

        // DB 관련 
        SQLite SQLite = null ;
        SQLiteCommand cmd = null;

        // Week Tab
        NeoTabPage W_IncomeTab;
        NeoTabPage W_SpendingTab;

        // Month Tab
        NeoTabPage M_ReportTab;
        NeoTabPage M_IncomeTab;
        NeoTabPage M_SpendingTab;
        NeoTabPage M_DetailTab;

        SpendReport sr = null;
        IncomeProgress ip = null;
        IncomeProgress sp = null;
        SpendDetail sd = null;

        // Year Tab
        NeoTabPage Y_IncomeTab;
        NeoTabPage Y_SpendingTab;
        
        // Budget Tab
        NeoTabPage B_IncomeTab;
        NeoTabPage B_SpendTab;

        Budget BIp;
        Budget BSp;

        int cnt = 0;


        public Form1()
        {
            InitializeComponent();
            
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;

            SQLite = new SQLite(); // DB Object
            cmd = SQLite.GetSQLCommand(); // Command Object
            currentCategory = "Week";
            button1.Visible = true;
            button2.Visible = false;
            
            dateTimePicker1.CloseUp += DateTimePicker1_CloseUp;
            
            neoTabWindow1.Renderer = NeoTabControlLibrary.AddInRendererManager.LoadRenderer("MarginBlueRendererVS2");
            neoTabWindow1.BackColor = Color.White;

            imgBtnContainer1.BackColor = Color.White;
            imgBtnContainer2.BackColor = Color.White;
            button1.Click += Button1_Click;

            panel5.BackColor = Color.LightGray;
            panel2.BackColor = Color.LightGray;

            // Budget
            B_IncomeTab = new NeoTabPage();
            B_SpendTab = new NeoTabPage();
            B_IncomeTab.Text = "수입 예산";
            B_SpendTab.Text = "지출 예산";
            BIp = new Budget(Budget.DMode.income, dateTimePicker1);
            BIp.SetDate(dateTimePicker1.Value);
            BIp.SetLabel();
            BIp.Dock = DockStyle.Fill;
            BSp = new Budget(Budget.DMode.spend, dateTimePicker1);
            BSp.SetDate(dateTimePicker1.Value);
            BSp.SetLabel();
            BSp.Dock = DockStyle.Fill;
            B_IncomeTab.Controls.Add(BIp);
            B_SpendTab.Controls.Add(BSp);

            // Week
            W_IncomeTab = new NeoTabPage();
            W_SpendingTab = new NeoTabPage();

            // Month
            M_ReportTab = new NeoTabPage();
            M_ReportTab.Text = "재정 보고";
            sr = new SpendReport();
            sr.SetDate(dateTimePicker1.Value);
            sr.Validate();
            sr.Dock = DockStyle.Fill;
            M_ReportTab.Controls.Add(sr);

            M_IncomeTab = new NeoTabPage();
            M_IncomeTab.Text = "재정 수입";
            ip = new IncomeProgress(IncomeProgress.DMode.income, button2);
            ip.Dock = DockStyle.Fill;
            M_IncomeTab.Controls.Add(ip);

            M_SpendingTab = new NeoTabPage();
            M_SpendingTab.Text = "재정 지출";
            sp = new IncomeProgress(IncomeProgress.DMode.spend, button2);
            ip.Dock = DockStyle.Fill;
            M_SpendingTab.Controls.Add(sp);

            M_DetailTab = new NeoTabPage();
            M_DetailTab.Text = "지출 세부 항목";
            sd = new SpendDetail(button2);
            sd.Dock = DockStyle.Fill;
            M_DetailTab.Controls.Add(sd);

            setImgBtn();
            setWeekTabPage();

            // IncomeProgress
            ip.Date = DateTime.Now;
            sp.Date = DateTime.Now;
            ip.setIncomeFromDB();
            ip.setSpendFromDB();
            sp.setSpendFromDB();
            sp.setSpendFromDB();
        }

        private void DateTimePicker1_CloseUp(object sender, EventArgs e)
        {
            switch( currentCategory)
            {
                case "Week":
            SetThanksDGV(2);
            Set10DGV(2);
            SetCellDGV(2);
            SetArchiDGV(2);
            SetMissionDGV(2);
            SetRiceDGV(2);
            SetHelpDGV(2);
            SetCarDGV(2);
            SetTermDGV(2);
            SetOtherDGV(2);
            SetInterestDGV(2);

            SetInputSumDGV();
                    currentTab.Hide();
                    _income_Thanks.Show();
            currentTab = _income_Thanks;
                    
                    break;

                case "Month":
            // IncomeProgress
            ip.Date = dateTimePicker1.Value;
            sp.Date = dateTimePicker1.Value;
            ip.titleInvalidate();
            sp.titleInvalidate();
            ip.setIncomeFromDB();
                    sp.setIncomeFromDB();
                    ip.setSpendFromDB();
            sp.setSpendFromDB();
        
                    // SpendReport
                    sr.SetDate(dateTimePicker1.Value);
                    sr.setIncomeFromDB();
                    sr.setSpendFromDB();
                    sr.Invalidate();

                    break;

                case "Year":




                    break;

                case "Budget":                       
                    
                    break;
        }
        }
        /// <summary>
        /// 아이콘 설정
        /// </summary>
        private void setImgBtn()
        {
            // imgBtnContainer1

            // 첫번째 아이콘 추가
            ImageBtn weekBtn = new ImageBtn();
            weekBtn.img = new Bitmap(Environment.CurrentDirectory + "\\Image\\Week.png");
            weekBtn.ImgName = "Week";
            weekBtn.str = "주 단위 정산";
            weekBtn.Click += WeekBtn_Click;
            imgBtnContainer1.InputBtn(weekBtn);

            // 두번째 아이콘 추가
            ImageBtn monthBtn = new ImageBtn();
            monthBtn.img = new Bitmap(Environment.CurrentDirectory + "\\Image\\Month.png");
            monthBtn.ImgName = "Month";
            monthBtn.str = "월 단위 정산";
            monthBtn.Click += MonthBtn_Click;
            imgBtnContainer1.InputBtn(monthBtn);

            // 세번째 아이콘 추가
            ImageBtn yearBtn = new ImageBtn();
            yearBtn.img = new Bitmap(Environment.CurrentDirectory + "\\Image\\Year.png");
            yearBtn.ImgName = "Year";
            yearBtn.str = "년 단위 정산";
            yearBtn.Click += YearBtn_Click;
            imgBtnContainer1.InputBtn(yearBtn);


            // imgBtnContainer2

            ImageBtn budgetBtn = new ImageBtn();
            budgetBtn.img = new Bitmap(Environment.CurrentDirectory + "\\Image\\Budget.png");
            budgetBtn.ImgName = "Budget";
            budgetBtn.Click += BudgetBtn_Click;
            imgBtnContainer2.InputBtn(budgetBtn);

            TitleBtn LogoBtn = new TitleBtn();
            LogoBtn.img = new Bitmap(Environment.CurrentDirectory + "\\Image\\Title.png");
            LogoBtn.ImgName = "Title";
            // LogoBtn.Click
            imgBtnContainer2.InputBtn(LogoBtn);
        }

        #region WEEK MONTH YEAR CLICK EVENT
        private void BudgetBtn_Click(object sender, EventArgs e)
        {
            neoTabWindow1.Controls.Clear();
            neoTabWindow1.Controls.Add(B_IncomeTab);
            neoTabWindow1.Controls.Add(B_SpendTab);
            BIp.SetDate(dateTimePicker1.Value);
            BSp.SetDate(dateTimePicker1.Value);
            currentCategory = "Budget";
            button1.Visible = true;
            button2.Visible = false;

            // 값 세팅 부분
        }
        private void YearBtn_Click(object sender, EventArgs e)
        {
            neoTabWindow1.Controls.Clear();

            currentCategory = "Year";
            button1.Visible = false;
            button2.Visible = true;

            // 값 세팅 부분
        }
        private void MonthBtn_Click(object sender, EventArgs e)
        {
            neoTabWindow1.Controls.Clear();

            neoTabWindow1.Controls.Add(M_ReportTab);
            neoTabWindow1.Controls.Add(M_IncomeTab);
            neoTabWindow1.Controls.Add(M_SpendingTab);
            neoTabWindow1.Controls.Add(M_DetailTab);

            currentCategory = "Month";
            button1.Visible = false;
            button2.Visible = true;
            
            // 값 세팅 부분
            // IncomeProgress
            ip.Date = dateTimePicker1.Value;
            sp.Date = dateTimePicker1.Value;
            ip.titleInvalidate();
            sp.titleInvalidate();
            ip.setBudgetFromDB();
            sp.setBudgetFromDB();
            ip.setIncomeFromDB();
            sp.setIncomeFromDB();
            ip.setSpendFromDB();
            sp.setSpendFromDB();
        }
        private void WeekBtn_Click(object sender, EventArgs e)
        {
            neoTabWindow1.Controls.Clear();
            neoTabWindow1.Controls.Add(W_IncomeTab);
            neoTabWindow1.Controls.Add(W_SpendingTab);

            currentCategory = "Week";
            button1.Visible = true;
            button2.Visible = false;

            // 값 세팅 부분
            SetThanksDGV(2);
            Set10DGV(2);
            SetCellDGV(2);
            SetArchiDGV(2);
            SetMissionDGV(2);
            SetRiceDGV(2);
            SetHelpDGV(2);
            SetCarDGV(2);
            SetTermDGV(2);
            SetOtherDGV(2);
            SetInterestDGV(2);

            SetInputSumDGV();
            currentTab.Hide();
            _income_Thanks.Show();
            currentTab = _income_Thanks;
        }
        #endregion 
        
        private void setWeekTabPage()
        {
            W_IncomeTab.Text = "수 입";
            W_IncomeTab.BackColor = Color.White;
            W_IncomeTab.AutoScroll = true;
            W_SpendingTab.Text = "지 출";
            W_SpendingTab.BackColor = Color.White;
            W_SpendingTab.AutoScroll = true;

            neoTabWindow1.Controls.Add(W_IncomeTab);
            neoTabWindow1.Controls.Add(W_SpendingTab);

            // Spend Area
            WSP = new WeekSpendPage(W_SpendingTab, dateTimePicker1);
            WSP.WeekSpendPageStart();

            // Income Area
            AddGridView();
            CreateTable();

            // 최초 DGV 그리기.
            SetThanksDGV(1);
            Set10DGV(1);
            SetCellDGV(1);    
            SetArchiDGV(1);      
            SetMissionDGV(1);    
            SetRiceDGV(1);     
            SetHelpDGV(1);
            SetCarDGV(1);
            SetTermDGV(1);
            SetOtherDGV(1);
            SetInterestDGV(1);

            _income_total.Rows[0].Cells[1].Value = ToComma(Sum_Thanks);

            SetInputSumDGV(); // 최초 DGV 그리기. ( 수입 SUM )

            currentTab = _income_Thanks;
        }

        private static string ToNoComma(TextBox tb)
        {
            string[] a = tb.Text.Split(',');
            string temp = "";
            for (int i = 0; i < a.Length; i++)
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
            try
            {
                s = String.Format("{0:N0}", Convert.ToInt32(str));
            }
            catch (FormatException e)
            {
                return str.ToString();
            }
            catch (InvalidCastException e)
            {
                return "0";
            }
            return s;
        }

        private void CreateTable()
        {
            SQLite.Execute(string.Format("create table Offering_Thanks " +
                "(no Integer primary key autoincrement, date datetime, name varchar(40), amount Integer)"));
            SQLite.Execute(string.Format("create table Offering_10 " +
                "(no Integer primary key autoincrement, date datetime, name varchar(40), amount Integer)"));
            SQLite.Execute(string.Format("create table Offering_Cell " +
                "(no Integer primary key autoincrement, date datetime, name varchar(40), amount Integer)"));
            SQLite.Execute(string.Format("create table Offering_Archi " +
                "(no Integer primary key autoincrement, date datetime, name varchar(40), amount Integer)"));
            SQLite.Execute(string.Format("create table Offering_Mission " +
                "(no Integer primary key autoincrement, date datetime, name varchar(40), amount Integer)"));
            SQLite.Execute(string.Format("create table Offering_Rice " +
                "(no Integer primary key autoincrement, date datetime, name varchar(40), amount Integer)"));
            SQLite.Execute(string.Format("create table Offering_Help " +
                "(no Integer primary key autoincrement, date datetime, name varchar(40), amount Integer)"));
            SQLite.Execute(string.Format("create table Offering_Car " +
                "(no Integer primary key autoincrement, date datetime, name varchar(40), amount Integer)"));
            SQLite.Execute(string.Format("create table Offering_Term " +
                "(no Integer primary key autoincrement, date datetime, name varchar(40), amount Integer)"));
            SQLite.Execute(string.Format("create table Offering_Other " +
                "(no Integer primary key autoincrement, date datetime, name varchar(40), amount Integer)"));
            SQLite.Execute(string.Format("create table Offering_Interest " +
                "(no Integer primary key autoincrement, date datetime, name varchar(40), amount Integer)"));
        }

        private void AddGridView()
        {
            #region 수입 탭 GridView 선언

            income = new DataGridView();
            income_total = new DataGridView();
            _income_total = new DataGridView();

            _income_Thanks = new DataGridView();
            _income_10 = new DataGridView();
            _income_Cell = new DataGridView();
            _income_Archi = new DataGridView();
            _income_Mission = new DataGridView();
            _income_Rice = new DataGridView();
            _income_Help = new DataGridView();
            _income_Car = new DataGridView();
            _income_Term = new DataGridView();
            _income_Other = new DataGridView();
            _income_Interest = new DataGridView();
            
            _income_Thanks.CellEndEdit += _income_Thanks_CellEndEdit;
            _income_10.CellEndEdit += _income_10_CellEndEdit;
            _income_Cell.CellEndEdit += _income_Cell_CellEndEdit;
            _income_Archi.CellEndEdit += _income_Archi_CellEndEdit;
            _income_Mission.CellEndEdit += _income_Mission_CellEndEdit;
            _income_Rice.CellEndEdit += _income_Rice_CellEndEdit;
            _income_Help.CellEndEdit += _income_Help_CellEndEdit;
            _income_Car.CellEndEdit += _income_Car_CellEndEdit;
            _income_Term.CellEndEdit += _income_Term_CellEndEdit;
            _income_Other.CellEndEdit += _income_Other_CellEndEdit;
            _income_Interest.CellEndEdit += _income_Interest_CellEndEdit;

            _income_Thanks.EditingControlShowing += _income_Thanks_EditingControlShowing;
            _income_10.EditingControlShowing += _income_10_EditingControlShowing;
            _income_Cell.EditingControlShowing += _income_Cell_EditingControlShowing;
            _income_Archi.EditingControlShowing += _income_Archi_EditingControlShowing;
            _income_Mission.EditingControlShowing += _income_Mission_EditingControlShowing;
            _income_Rice.EditingControlShowing += _income_Rice_EditingControlShowing;
            _income_Help.EditingControlShowing += _income_Help_EditingControlShowing;
            _income_Car.EditingControlShowing += _income_Car_EditingControlShowing;
            _income_Term.EditingControlShowing += _income_Term_EditingControlShowing;
            _income_Other.EditingControlShowing += _income_Other_EditingControlShowing;
            _income_Interest.EditingControlShowing += _income_Interest_EditingControlShowing;
            
            income.CellMouseDown += Income_CellMouseDown;

            #endregion

            #region DGV 옵션 1
            // income ---------------------------------------
            income.Size = new Size(300, 392);
            income.Location = new Point(20, 20);
            income.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            income.ColumnHeadersHeight = 30;
            income.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            income.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            income.Font = new Font("Microsoft Sans Serif", 12);
            income.RowTemplate.Height = 30;
            income.ColumnCount = 2;
            income.ReadOnly = true;
            income.AllowUserToAddRows = false;
            income.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            income.RowHeadersWidthSizeMode =
                DataGridViewRowHeadersWidthSizeMode.DisableResizing;

            income.Columns[0].Name = "항 목";
            income.Columns[1].Name = "금 액";
            
            for (int i = 0; i < income.Columns.Count; i++)
                income.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            for (int i = 0; i < income.ColumnCount ; i++)
                income.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

            // income_total ------------------------------
            income_total.Size = new Size(300, 31);
            income_total.Location = new Point(20, 425);
            income_total.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            income_total.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            income_total.Font = new Font("Microsoft Sans Serif", 12);
            income_total.RowTemplate.Height = 30;
            income_total.ColumnCount = 2;
            income_total.ReadOnly = true;
            income_total.ColumnHeadersVisible = false;
            income_total.SelectionChanged += Income_total_SelectionChanged;
            income_total.RowCount = 2;
            income_total.AllowUserToAddRows = false;
            income_total.RowHeadersWidthSizeMode =
                DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            income_total.RowHeadersDefaultCellStyle.Padding = new Padding(income_total.RowHeadersWidth);

            income_total.Rows[0].Cells[0].Value = "Total";

            for (int i = 0; i < income_total.Columns.Count; i++)
                income_total.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            // _income_total -------------------------------
            _income_total.Size = new Size(600, 31);
            _income_total.Location = new Point(350, 425);
            _income_total.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _income_total.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _income_total.Font = new Font("Microsoft Sans Serif", 12);
            _income_total.RowTemplate.Height = 30;
            _income_total.ColumnHeadersVisible = false;
            _income_total.ColumnCount = 3;
            _income_total.ReadOnly = true;
            _income_total.SelectionChanged += _income_total_SelectionChanged;
            _income_total.RowCount = 2;
            _income_total.AllowUserToAddRows = false;
            _income_total.RowHeadersWidthSizeMode =
                DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            _income_total.RowHeadersDefaultCellStyle.Padding = new Padding(_income_total.RowHeadersWidth);

            _income_total.Rows[0].Cells[0].Value = "Total";
            _income_total.Rows[0].Cells[1].Value = "";
            _income_total.Rows[0].Cells[2].Value = "";

            for (int i = 0; i < _income_total.Columns.Count; i++)
                _income_total.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            #endregion
            
            #region DGV 옵션 2

            // _income_Thanks ----------------------------------
            _income_Thanks.Size = new Size(600, 392);
            _income_Thanks.Location = new Point(350, 20);
            _income_Thanks.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _income_Thanks.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _income_Thanks.RowTemplate.Height = 30;
            _income_Thanks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            _income_Thanks.ColumnHeadersHeight = 30;
            _income_Thanks.Font = new Font("Microsoft Sans Serif", 12);
            _income_Thanks.RowHeadersWidthSizeMode =
                DataGridViewRowHeadersWidthSizeMode.DisableResizing;

            // _income_10 ----------------------------------
            _income_10.Size = new Size(600, 392);
            _income_10.Location = new Point(350, 20);
            _income_10.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _income_10.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _income_10.RowTemplate.Height = 30;
            _income_10.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            _income_10.ColumnHeadersHeight = 30;
            _income_10.Font = new Font("Microsoft Sans Serif", 12);
            _income_10.RowHeadersWidthSizeMode =
                DataGridViewRowHeadersWidthSizeMode.DisableResizing;

            // _income_Cell ----------------------------------
            _income_Cell.Size = new Size(600, 392);
            _income_Cell.Location = new Point(350, 20);
            _income_Cell.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _income_Cell.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _income_Cell.RowTemplate.Height = 30;
            _income_Cell.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            _income_Cell.ColumnHeadersHeight = 30;
            _income_Cell.Font = new Font("Microsoft Sans Serif", 12);
            _income_Cell.RowHeadersWidthSizeMode =
                DataGridViewRowHeadersWidthSizeMode.DisableResizing;

            // _income_Archi ----------------------------------
            _income_Archi.Size = new Size(600, 392);
            _income_Archi.Location = new Point(350, 20);
            _income_Archi.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _income_Archi.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _income_Archi.RowTemplate.Height = 30;
            _income_Archi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            _income_Archi.ColumnHeadersHeight = 30;
            _income_Archi.Font = new Font("Microsoft Sans Serif", 12);
            _income_Archi.RowHeadersWidthSizeMode =
                DataGridViewRowHeadersWidthSizeMode.DisableResizing;

            // _income_Mission ----------------------------------
            _income_Mission.Size = new Size(600, 392);
            _income_Mission.Location = new Point(350, 20);
            _income_Mission.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _income_Mission.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _income_Mission.RowTemplate.Height = 30;
            _income_Mission.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            _income_Mission.ColumnHeadersHeight = 30;
            _income_Mission.Font = new Font("Microsoft Sans Serif", 12);
            _income_Mission.RowHeadersWidthSizeMode =
                DataGridViewRowHeadersWidthSizeMode.DisableResizing;

            // _income_Rice ----------------------------------
            _income_Rice.Size = new Size(600, 392);
            _income_Rice.Location = new Point(350, 20);
            _income_Rice.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _income_Rice.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _income_Rice.RowTemplate.Height = 30;
            _income_Rice.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            _income_Rice.ColumnHeadersHeight = 30;
            _income_Rice.Font = new Font("Microsoft Sans Serif", 12);
            _income_Rice.RowHeadersWidthSizeMode =
                DataGridViewRowHeadersWidthSizeMode.DisableResizing;

            // _income_Help ----------------------------------
            _income_Help.Size = new Size(600, 392);
            _income_Help.Location = new Point(350, 20);
            _income_Help.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _income_Help.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _income_Help.RowTemplate.Height = 30;
            _income_Help.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            _income_Help.ColumnHeadersHeight = 30;
            _income_Help.Font = new Font("Microsoft Sans Serif", 12);
            _income_Help.RowHeadersWidthSizeMode =
                DataGridViewRowHeadersWidthSizeMode.DisableResizing;

            // _income_Car ----------------------------------
            _income_Car.Size = new Size(600, 392);
            _income_Car.Location = new Point(350, 20);
            _income_Car.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _income_Car.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _income_Car.RowTemplate.Height = 30;
            _income_Car.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            _income_Car.ColumnHeadersHeight = 30;
            _income_Car.Font = new Font("Microsoft Sans Serif", 12);
            _income_Car.RowHeadersWidthSizeMode =
                DataGridViewRowHeadersWidthSizeMode.DisableResizing;

            // _income_Term ----------------------------------
            _income_Term.Size = new Size(600, 392);
            _income_Term.Location = new Point(350, 20);
            _income_Term.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _income_Term.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _income_Term.RowTemplate.Height = 30;
            _income_Term.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            _income_Term.ColumnHeadersHeight = 30;
            _income_Term.Font = new Font("Microsoft Sans Serif", 12);
            _income_Term.RowHeadersWidthSizeMode =
                DataGridViewRowHeadersWidthSizeMode.DisableResizing;

            // _income_Other ----------------------------------
            _income_Other.Size = new Size(600, 392);
            _income_Other.Location = new Point(350, 20);
            _income_Other.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _income_Other.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _income_Other.RowTemplate.Height = 30;
            _income_Other.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            _income_Other.ColumnHeadersHeight = 30;
            _income_Other.Font = new Font("Microsoft Sans Serif", 12);
            _income_Other.RowHeadersWidthSizeMode =
                DataGridViewRowHeadersWidthSizeMode.DisableResizing;

            // _income_Interest ----------------------------------
            _income_Interest.Size = new Size(600, 392);
            _income_Interest.Location = new Point(350, 20);
            _income_Interest.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _income_Interest.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _income_Interest.RowTemplate.Height = 30;
            _income_Interest.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            _income_Interest.ColumnHeadersHeight = 30;
            _income_Interest.Font = new Font("Microsoft Sans Serif", 12);
            _income_Interest.RowHeadersWidthSizeMode =
                DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            #endregion

            // Draw DGVS --------------------------------------------------

            W_IncomeTab.Controls.Add(income);

            W_IncomeTab.Controls.Add(_income_Thanks);
            currentTab = _income_Thanks;
            
            W_IncomeTab.Controls.Add(_income_10);
            W_IncomeTab.Controls.Add(_income_Cell);
            W_IncomeTab.Controls.Add(_income_Archi);
            W_IncomeTab.Controls.Add(_income_Mission);
            W_IncomeTab.Controls.Add(_income_Rice);
            W_IncomeTab.Controls.Add(_income_Help);
            W_IncomeTab.Controls.Add(_income_Car);
            W_IncomeTab.Controls.Add(_income_Term);
            W_IncomeTab.Controls.Add(_income_Other);
            W_IncomeTab.Controls.Add(_income_Interest);

            _income_10.Hide();
            _income_Cell.Hide();
            _income_Archi.Hide();
            _income_Mission.Hide();
            _income_Rice.Hide();
            _income_Help.Hide();
            _income_Car.Hide();
            _income_Term.Hide();
            _income_Other.Hide();
            _income_Interest.Hide();

            W_IncomeTab.Controls.Add(income_total);
            W_IncomeTab.Controls.Add(_income_total);
            
        }

        #region EditingControlShowing
        private void _income_Thanks_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox tb = e.Control as TextBox;
            tb.Text = ToNoComma(tb);
        }

        private void _income_10_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox tb = e.Control as TextBox;
            tb.Text = ToNoComma(tb);
        }

        private void _income_Cell_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox tb = e.Control as TextBox;
            tb.Text = ToNoComma(tb);
        }

        private void _income_Archi_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox tb = e.Control as TextBox;
            tb.Text = ToNoComma(tb);
        }

        private void _income_Mission_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox tb = e.Control as TextBox;
            tb.Text = ToNoComma(tb);
        }

        private void _income_Rice_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox tb = e.Control as TextBox;
            tb.Text = ToNoComma(tb);
        }

        private void _income_Help_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox tb = e.Control as TextBox;
            tb.Text = ToNoComma(tb);
        }

        private void _income_Car_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox tb = e.Control as TextBox;
            tb.Text = ToNoComma(tb);
        }

        private void _income_Term_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox tb = e.Control as TextBox;
            tb.Text = ToNoComma(tb);
        }

        private void _income_Other_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox tb = e.Control as TextBox;
            tb.Text = ToNoComma(tb);
        }

        private void _income_Interest_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox tb = e.Control as TextBox;
            tb.Text = ToNoComma(tb);
        }
        #endregion

        #region SelectionChanged
        private void _income_total_SelectionChanged(object sender, EventArgs e)
        {
            _income_total.ClearSelection();
        }

        private void Income_total_SelectionChanged(object sender, EventArgs e)
        {
            income_total.ClearSelection();
        }
        #endregion

        private void Income_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if( e.RowIndex != -1 && e.RowIndex != 11)
            {
                currentTab.Hide();
                switch (e.RowIndex)
                {
                    case 0:
                        _income_Thanks.Show();
                        _income_total.Rows[0].Cells[1].Value = ToComma(Sum_Thanks);
                        currentTab = _income_Thanks;
                        break;
                    case 1:
                        _income_10.Show();
                        _income_total.Rows[0].Cells[1].Value = ToComma(Sum_10);
                        currentTab = _income_10;
                        break;
                    case 2:
                        _income_Cell.Show();
                        _income_total.Rows[0].Cells[1].Value = ToComma(Sum_Cell);
                        currentTab = _income_Cell;
                        break;
                    case 3:
                        _income_Archi.Show();
                        _income_total.Rows[0].Cells[1].Value = ToComma(Sum_Archi);
                        currentTab = _income_Archi;
                        break;
                    case 4:
                        _income_Mission.Show();
                        _income_total.Rows[0].Cells[1].Value = ToComma(Sum_Mission);
                        currentTab = _income_Mission;
                        break;
                    case 5:
                        _income_Rice.Show();
                        _income_total.Rows[0].Cells[1].Value = ToComma(Sum_Rice);
                        currentTab = _income_Rice;
                        break;
                    case 6:
                        _income_Help.Show();
                        _income_total.Rows[0].Cells[1].Value = ToComma(Sum_Help);
                        currentTab = _income_Help;
                        break;
                    case 7:
                        _income_Car.Show();
                        _income_total.Rows[0].Cells[1].Value = ToComma(Sum_Car);
                        currentTab = _income_Car;
                        break;
                    case 8:
                        _income_Term.Show();
                        _income_total.Rows[0].Cells[1].Value = ToComma(Sum_Term);
                        currentTab = _income_Term;
                        break;
                    case 9:
                        _income_Other.Show();
                        _income_total.Rows[0].Cells[1].Value = ToComma(Sum_Other);
                        currentTab = _income_Other;
                        break;
                    case 10:
                        _income_Interest.Show();
                        _income_total.Rows[0].Cells[1].Value = ToComma(Sum_Interest);
                        currentTab = _income_Interest;
                        break;
                }
            }
        }

        #region CellEndEdit

        private void _income_Thanks_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Set New Value`s Date
            if (_income_Thanks.Rows[e.RowIndex].Cells[2].Value.ToString() == "")
                _income_Thanks.Rows[e.RowIndex].Cells[2].Value = ((DateTime)dateTimePicker1.Value).ToShortDateString();

            // Make Comma type
            for (int i = 0; i < _income_Thanks.RowCount - 1; i++)
                _income_Thanks.Rows[i].Cells[1].Value = ToComma(_income_Thanks.Rows[i].Cells[1].Value);

                // Set Sumation.
                int sum = 0;
            for (int i = 0; i < _income_Thanks.RowCount - 1; i++)
                if (_income_Thanks.Rows[i].Cells[1].Value.ToString() != "")
                    sum += Convert.ToInt32(ToNoComma(_income_Thanks.Rows[i].Cells[1].Value));

            Sum_Thanks = sum;
            _income_total.Rows[0].Cells[1].Value = ToComma(Sum_Thanks);

            SetInputSumDGV();
            SQLite.CloseDB();
        }

        private void _income_10_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Set New Value`s Date
            if (_income_10.Rows[e.RowIndex].Cells[2].Value.ToString() == "")
                _income_10.Rows[e.RowIndex].Cells[2].Value = ((DateTime)dateTimePicker1.Value).ToShortDateString();

            // Make Comma type
            for (int i = 0; i < _income_10.RowCount - 1; i++)
                _income_10.Rows[i].Cells[1].Value = ToComma(_income_10.Rows[i].Cells[1].Value);

            // Set Sumation.
            int sum = 0;
            for (int i = 0; i < _income_10.RowCount - 1; i++)
                if (_income_10.Rows[i].Cells[1].Value.ToString() != "")
                    sum += Convert.ToInt32(ToNoComma(_income_10.Rows[i].Cells[1].Value));

            Sum_10 = sum;
            _income_total.Rows[0].Cells[1].Value = ToComma(Sum_10);

            SetInputSumDGV();
            SQLite.CloseDB();
        }

        private void _income_Cell_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Set New Value`s Date
            if (_income_Cell.Rows[e.RowIndex].Cells[2].Value.ToString() == "")
                _income_Cell.Rows[e.RowIndex].Cells[2].Value = ((DateTime)dateTimePicker1.Value).ToShortDateString();

            // Make Comma type
            for (int i = 0; i < _income_Cell.RowCount - 1; i++)
                _income_Cell.Rows[i].Cells[1].Value = ToComma(_income_Cell.Rows[i].Cells[1].Value);

            // Set Sumation.
            int sum = 0;
            for (int i = 0; i < _income_Cell.RowCount - 1; i++)
                if (_income_Cell.Rows[i].Cells[1].Value.ToString() != "")
                    sum += Convert.ToInt32(ToNoComma(_income_Cell.Rows[i].Cells[1].Value));

            Sum_Cell = sum;
            _income_total.Rows[0].Cells[1].Value = ToComma(Sum_Cell);

            SetInputSumDGV();
            SQLite.CloseDB();
        }

        private void _income_Archi_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Set New Value`s Date
            if (_income_Archi.Rows[e.RowIndex].Cells[2].Value.ToString() == "")
                _income_Archi.Rows[e.RowIndex].Cells[2].Value = ((DateTime)dateTimePicker1.Value).ToShortDateString();

            // Make Comma type
            for (int i = 0; i < _income_Archi.RowCount - 1; i++)
                _income_Archi.Rows[i].Cells[1].Value = ToComma(_income_Archi.Rows[i].Cells[1].Value);

            // Set Sumation.
            int sum = 0;
            for (int i = 0; i < _income_Archi.RowCount - 1; i++)
                //Debug.WriteLine("Cell 0 : " + _income.Rows[0].Cells[0].Value);
                if (_income_Archi.Rows[i].Cells[1].Value.ToString() != "")
                    sum += Convert.ToInt32(ToNoComma(_income_Archi.Rows[i].Cells[1].Value));

            Sum_Archi = sum;
            _income_total.Rows[0].Cells[1].Value = ToComma(Sum_Archi);

            SetInputSumDGV();
            SQLite.CloseDB();
        }

        private void _income_Mission_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Set New Value`s Date
            if (_income_Mission.Rows[e.RowIndex].Cells[2].Value.ToString() == "")
                _income_Mission.Rows[e.RowIndex].Cells[2].Value = ((DateTime)dateTimePicker1.Value).ToShortDateString();

            // Make Comma type
            for (int i = 0; i < _income_Mission.RowCount - 1; i++)
                _income_Mission.Rows[i].Cells[1].Value = ToComma(_income_Mission.Rows[i].Cells[1].Value);

            // Set Sumation.
            int sum = 0;
            for (int i = 0; i < _income_Mission.RowCount - 1; i++)
                if (_income_Mission.Rows[i].Cells[1].Value.ToString() != "")
                    sum += Convert.ToInt32(ToNoComma(_income_Mission.Rows[i].Cells[1].Value));

            Sum_Mission = sum;
            _income_total.Rows[0].Cells[1].Value = ToComma(Sum_Mission);

            SetInputSumDGV();
            SQLite.CloseDB();
        }

        private void _income_Rice_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Set New Value`s Date
            if (_income_Rice.Rows[e.RowIndex].Cells[2].Value.ToString() == "")
                _income_Rice.Rows[e.RowIndex].Cells[2].Value = ((DateTime)dateTimePicker1.Value).ToShortDateString();

            // Make Comma type
            for (int i = 0; i < _income_Rice.RowCount - 1; i++)
                _income_Rice.Rows[i].Cells[1].Value = ToComma(_income_Rice.Rows[i].Cells[1].Value);

            // Set Sumation.
            int sum = 0;
            for (int i = 0; i < _income_Rice.RowCount - 1; i++)
                if (_income_Rice.Rows[i].Cells[1].Value.ToString() != "")
                    sum += Convert.ToInt32(ToNoComma(_income_Rice.Rows[i].Cells[1].Value));

            Sum_Rice = sum;
            _income_total.Rows[0].Cells[1].Value = ToComma(Sum_Rice);

            SetInputSumDGV();
            SQLite.CloseDB();
        }

        private void _income_Help_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Set New Value`s Date
            if (_income_Help.Rows[e.RowIndex].Cells[2].Value.ToString() == "")
                _income_Help.Rows[e.RowIndex].Cells[2].Value = ((DateTime)dateTimePicker1.Value).ToShortDateString();

            // Make Comma type
            for (int i = 0; i < _income_Help.RowCount - 1; i++)
                _income_Help.Rows[i].Cells[1].Value = ToComma(_income_Help.Rows[i].Cells[1].Value);

            // Set Sumation.
            int sum = 0;
            for (int i = 0; i < _income_Help.RowCount - 1; i++)
                if (_income_Help.Rows[i].Cells[1].Value.ToString() != "")
                    sum += Convert.ToInt32(ToNoComma(_income_Help.Rows[i].Cells[1].Value));

            Sum_Help = sum;
            _income_total.Rows[0].Cells[1].Value = ToComma(Sum_Help);

            SetInputSumDGV();
            SQLite.CloseDB();
        }

        private void _income_Car_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Set New Value`s Date
            if (_income_Car.Rows[e.RowIndex].Cells[2].Value.ToString() == "")
                _income_Car.Rows[e.RowIndex].Cells[2].Value = ((DateTime)dateTimePicker1.Value).ToShortDateString();

            // Make Comma type
            for (int i = 0; i < _income_Car.RowCount - 1; i++)
                _income_Car.Rows[i].Cells[1].Value = ToComma(_income_Car.Rows[i].Cells[1].Value);

            // Set Sumation.
            int sum = 0;
            for (int i = 0; i < _income_Car.RowCount - 1; i++)
                if (_income_Car.Rows[i].Cells[1].Value.ToString() != "")
                    sum += Convert.ToInt32(ToNoComma(_income_Car.Rows[i].Cells[1].Value));

            Sum_Car = sum;
            _income_total.Rows[0].Cells[1].Value = ToComma(Sum_Car);

            SetInputSumDGV();
            SQLite.CloseDB();
        }

        private void _income_Term_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Set New Value`s Date
            if (_income_Term.Rows[e.RowIndex].Cells[2].Value.ToString() == "")
                _income_Term.Rows[e.RowIndex].Cells[2].Value = ((DateTime)dateTimePicker1.Value).ToShortDateString();

            // Make Comma type
            for (int i = 0; i < _income_Term.RowCount - 1; i++)
                _income_Term.Rows[i].Cells[1].Value = ToComma(_income_Term.Rows[i].Cells[1].Value);

            // Set Sumation.
            int sum = 0;
            for (int i = 0; i < _income_Term.RowCount - 1; i++)
                if (_income_Term.Rows[i].Cells[1].Value.ToString() != "")
                    sum += Convert.ToInt32(ToNoComma(_income_Term.Rows[i].Cells[1].Value));

            Sum_Term = sum;
            _income_total.Rows[0].Cells[1].Value = ToComma(Sum_Term);

            SetInputSumDGV();
            SQLite.CloseDB();
        }

        private void _income_Other_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Set New Value`s Date
            if (_income_Other.Rows[e.RowIndex].Cells[2].Value.ToString() == "")
                _income_Other.Rows[e.RowIndex].Cells[2].Value = ((DateTime)dateTimePicker1.Value).ToShortDateString();

            // Make Comma type
            for (int i = 0; i < _income_Other.RowCount - 1; i++)
                _income_Other.Rows[i].Cells[1].Value = ToComma(_income_Other.Rows[i].Cells[1].Value);

            // Set Sumation.
            int sum = 0;
            for (int i = 0; i < _income_Other.RowCount - 1; i++)
                if (_income_Other.Rows[i].Cells[1].Value.ToString() != "")
                    sum += Convert.ToInt32(ToNoComma(_income_Other.Rows[i].Cells[1].Value));

            Sum_Other = sum;
            _income_total.Rows[0].Cells[1].Value = ToComma(Sum_Other);

            SetInputSumDGV();
            SQLite.CloseDB();
        }

        private void _income_Interest_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Set New Value`s Date
            if (_income_Interest.Rows[e.RowIndex].Cells[2].Value.ToString() == "")
                _income_Interest.Rows[e.RowIndex].Cells[2].Value = ((DateTime)dateTimePicker1.Value).ToShortDateString();

            // Make Comma type
            for (int i = 0; i < _income_Interest.RowCount - 1; i++)
                _income_Interest.Rows[i].Cells[1].Value = ToComma(_income_Interest.Rows[i].Cells[1].Value);

            // Set Sumation.
            int sum = 0;
            for (int i = 0; i < _income_Interest.RowCount - 1; i++)
                if (_income_Interest.Rows[i].Cells[1].Value.ToString() != "")
                    sum += Convert.ToInt32(ToNoComma(_income_Interest.Rows[i].Cells[1].Value));

            Sum_Interest = sum;
            _income_total.Rows[0].Cells[1].Value = ToComma(Sum_Interest);

            SetInputSumDGV();
            SQLite.CloseDB();
        }

        
        #endregion

        #region SetDGV Area
        private void SetThanksDGV(int check)
        {
            try
            {
                SQLite.ConnectToDB();

                if (check == 1)
                {
                    DataSet ds = SQLite.ExecuteSelectQuery(string.Format("select name as '이 름', cast( amount as TEXT ) as '금 액', date as '날 짜' from Offering_Thanks where date = '{0}' order by no asc", DateTime.Now.ToShortDateString()));
                    _income_Thanks.DataSource = ds.Tables[0];
                    for ( int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        ds.Tables[0].Rows[i]["금 액"] = ToComma(ds.Tables[0].Rows[i]["금 액"].ToString());
                }
                else if (check == 2)
                {
                    Debug.WriteLine("Date ::: " + dateTimePicker1.Value.ToShortDateString());
                    DataSet ds = SQLite.ExecuteSelectQuery(string.Format("select name as '이 름', cast ( amount as Text) as '금 액', date as '날 짜' from Offering_Thanks where date = '{0}' order by no asc", ((DateTime)dateTimePicker1.Value).ToShortDateString()));
                    _income_Thanks.DataSource = ds.Tables[0];
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        ds.Tables[0].Rows[i]["금 액"] = ToComma(ds.Tables[0].Rows[i]["금 액"].ToString());
                }
                
                for (int i = 0; i< _income_Thanks.Columns.Count; i++)
                    _income_Thanks.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                for (int i = 0; i < _income_Thanks.ColumnCount; i++)
                    _income_Thanks.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

                // Set Sumation.
                int sum = 0;
                for (int i = 0; i < _income_Thanks.RowCount - 1; i++)
                    if (_income_Thanks.Rows[i].Cells[1].Value.ToString() != "")
                        sum += Convert.ToInt32(ToNoComma(_income_Thanks.Rows[i].Cells[1].Value));
                                    
                Sum_Thanks = sum;
                
                SQLite.CloseDB();
            }
            catch(SQLiteException e)
            {
                SQLite.CloseDB();
                Debug.WriteLine(e);
            }   
        }

        private void Set10DGV(int check)
        {
            try
            {
                SQLite.ConnectToDB();

                if (check == 1)
                {
                    DataSet ds = SQLite.ExecuteSelectQuery(string.Format("select name as '이 름', cast (amount as Text) as'금 액', date as '날 짜' from Offering_10 where date = '{0}' order by no asc", DateTime.Now.ToShortDateString()));
                    _income_10.DataSource = ds.Tables[0];
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        ds.Tables[0].Rows[i]["금 액"] = ToComma(ds.Tables[0].Rows[i]["금 액"].ToString());
                }
                else if (check == 2)
                {
                    DataSet ds = SQLite.ExecuteSelectQuery(string.Format("select name as '이 름', cast (amount as Text) as'금 액', date as '날 짜' from Offering_10 where date = '{0}' order by no asc", dateTimePicker1.Value.ToShortDateString()));
                    _income_10.DataSource = ds.Tables[0];
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        ds.Tables[0].Rows[i]["금 액"] = ToComma(ds.Tables[0].Rows[i]["금 액"].ToString());
                }

                for (int i = 0; i < _income_10.Columns.Count; i++)
                    _income_10.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                for (int i = 0; i < _income_10.ColumnCount; i++)
                    _income_10.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

                // Set Sumation.
                int sum = 0;
                for (int i = 0; i < _income_10.RowCount - 1; i++)
                    if (_income_10.Rows[i].Cells[1].Value.ToString() != "")
                        sum += Convert.ToInt32(ToNoComma(_income_10.Rows[i].Cells[1].Value));
                Sum_10 = sum;

                W_IncomeTab.Invalidate();
                SQLite.CloseDB();
            }
            catch (SQLiteException e)
            {
                SQLite.CloseDB();
                Debug.WriteLine(e);
            }
        }

        private void SetCellDGV(int check)
        {
            try
            {
                SQLite.ConnectToDB();

                if (check == 1)
                {
                    DataSet ds = SQLite.ExecuteSelectQuery(string.Format("select name as '이 름', cast (amount as Text) as'금 액', date as '날 짜' from Offering_Cell where date = '{0}' order by no asc", DateTime.Now.ToShortDateString()));
                    _income_Cell.DataSource = ds.Tables[0];
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        ds.Tables[0].Rows[i]["금 액"] = ToComma(ds.Tables[0].Rows[i]["금 액"].ToString());
                }
                else if (check == 2)
                {
                    DataSet ds = SQLite.ExecuteSelectQuery(string.Format("select name as '이 름', cast (amount as Text) as '금 액', date as '날 짜' from Offering_Cell where date = '{0}' order by no asc", dateTimePicker1.Value.ToShortDateString()));
                    _income_Cell.DataSource = ds.Tables[0];
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        ds.Tables[0].Rows[i]["금 액"] = ToComma(ds.Tables[0].Rows[i]["금 액"].ToString());
                }

                for (int i = 0; i < _income_Cell.Columns.Count; i++)
                    _income_Cell.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                for (int i = 0; i < _income_Cell.ColumnCount; i++)
                    _income_Cell.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

                // Set Sumation.
                int sum = 0;
                for (int i = 0; i < _income_Cell.RowCount - 1; i++)
                    if (_income_Cell.Rows[i].Cells[1].Value.ToString() != "")
                        sum += Convert.ToInt32(ToNoComma(_income_Cell.Rows[i].Cells[1].Value));
                Sum_Cell = sum;
                
                SQLite.CloseDB();
            }
            catch (SQLiteException e)
            {
                SQLite.CloseDB();
                Debug.WriteLine(e);
            }
        }

        private void SetArchiDGV(int check)
        {
            try
            {
                SQLite.ConnectToDB();

                if (check == 1)
                {
                    DataSet ds = SQLite.ExecuteSelectQuery(string.Format("select name as '이 름', cast (amount as Text) as '금 액', date as '날 짜' from Offering_Archi where date = '{0}' order by no asc", DateTime.Now.ToShortDateString()));
                    _income_Archi.DataSource = ds.Tables[0];
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        ds.Tables[0].Rows[i]["금 액"] = ToComma(ds.Tables[0].Rows[i]["금 액"].ToString());
                }
                else if (check == 2)
                {
                    DataSet ds = SQLite.ExecuteSelectQuery(string.Format("select name as '이 름', cast (amount as Text) as '금 액', date as '날 짜' from Offering_Archi where date = '{0}' order by no asc", dateTimePicker1.Value.ToShortDateString()));
                    _income_Archi.DataSource = ds.Tables[0];
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        ds.Tables[0].Rows[i]["금 액"] = ToComma(ds.Tables[0].Rows[i]["금 액"].ToString());
                }

                for (int i = 0; i < _income_Archi.Columns.Count; i++)
                    _income_Archi.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                for (int i = 0; i < _income_Archi.ColumnCount; i++)
                    _income_Archi.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

                // Set Sumation.
                int sum = 0;
                for (int i = 0; i < _income_Archi.RowCount - 1; i++)
                    if (_income_Archi.Rows[i].Cells[1].Value.ToString() != "")
                        sum += Convert.ToInt32(ToNoComma(_income_Archi.Rows[i].Cells[1].Value));
                Sum_Archi = sum;
                
                SQLite.CloseDB();
            }
            catch (SQLiteException e)
            {
                SQLite.CloseDB();
                Debug.WriteLine(e);
            }
        }

        private void SetMissionDGV(int check)
        {
            try
            {
                SQLite.ConnectToDB();

                if (check == 1)
                { 
                    DataSet ds = SQLite.ExecuteSelectQuery(string.Format("select name as '이 름', cast (amount as Text) as '금 액', date as '날 짜' from Offering_Mission where date = '{0}' order by no asc", DateTime.Now.ToShortDateString()));
                    _income_Mission.DataSource = ds.Tables[0];
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        ds.Tables[0].Rows[i]["금 액"] = ToComma(ds.Tables[0].Rows[i]["금 액"].ToString());
                }
                else if (check == 2)
                {
                    DataSet ds = SQLite.ExecuteSelectQuery(string.Format("select name as '이 름', cast (amount as Text) as '금 액', date as '날 짜' from Offering_Mission where date = '{0}' order by no asc", dateTimePicker1.Value.ToShortDateString()));
                    _income_Mission.DataSource = ds.Tables[0];
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        ds.Tables[0].Rows[i]["금 액"] = ToComma(ds.Tables[0].Rows[i]["금 액"].ToString());
                }

                for (int i = 0; i < _income_Mission.Columns.Count; i++)
                    _income_Mission.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                for (int i = 0; i < _income_Mission.ColumnCount; i++)
                    _income_Mission.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

                // Set Sumation.
                int sum = 0;
                for (int i = 0; i < _income_Mission.RowCount - 1; i++)
                    if (_income_Mission.Rows[i].Cells[1].Value.ToString() != "")
                        sum += Convert.ToInt32(ToNoComma(_income_Mission.Rows[i].Cells[1].Value));
                Sum_Mission = sum;
                
                SQLite.CloseDB();
            }
            catch( SQLiteException e)
            {
                Debug.WriteLine(e);
            }
        }

        private void SetRiceDGV(int check)
        {
            try
            {
                SQLite.ConnectToDB();

                if (check == 1)
                {
                    DataSet ds = SQLite.ExecuteSelectQuery(string.Format("select name as '이 름', cast (amount as Text) as '금 액', date as '날 짜' from Offering_Rice where date = '{0}' order by no asc", DateTime.Now.ToShortDateString()));
                    _income_Rice.DataSource = ds.Tables[0];
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        ds.Tables[0].Rows[i]["금 액"] = ToComma(ds.Tables[0].Rows[i]["금 액"].ToString());
                }
                else if (check == 2)
                {
                    DataSet ds = SQLite.ExecuteSelectQuery(string.Format("select name as '이 름', cast (amount as Text) as '금 액', date as '날 짜' from Offering_Rice where date = '{0}' order by no asc", dateTimePicker1.Value.ToShortDateString()));
                    _income_Rice.DataSource = ds.Tables[0];
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        ds.Tables[0].Rows[i]["금 액"] = ToComma(ds.Tables[0].Rows[i]["금 액"].ToString());
                }

                for (int i = 0; i < _income_Rice.Columns.Count; i++)
                    _income_Rice.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                for (int i = 0; i < _income_Rice.ColumnCount; i++)
                    _income_Rice.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

                // Set Sumation.
                int sum = 0;
                for (int i = 0; i < _income_Rice.RowCount - 1; i++)
                    if (_income_Rice.Rows[i].Cells[1].Value.ToString() != "")
                        sum += Convert.ToInt32(ToNoComma(_income_Rice.Rows[i].Cells[1].Value));
                Sum_Rice = sum;
                
                SQLite.CloseDB();
            }
            catch (SQLiteException e)
            {
                Debug.WriteLine(e);
            }
        }

        private void SetHelpDGV(int check)
        {
            try
            {
                SQLite.ConnectToDB();

                if (check == 1)
                {
                    DataSet ds = SQLite.ExecuteSelectQuery(string.Format("select name as '이 름', cast (amount as Text) as '금 액', date as '날 짜' from Offering_Help where date = '{0}' order by no asc", DateTime.Now.ToShortDateString()));
                    _income_Help.DataSource = ds.Tables[0];
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        ds.Tables[0].Rows[i]["금 액"] = ToComma(ds.Tables[0].Rows[i]["금 액"].ToString());
                }
                else if (check == 2)
                {
                    DataSet ds = SQLite.ExecuteSelectQuery(string.Format("select name as '이 름', cast (amount as Text) as '금 액', date as '날 짜' from Offering_Help where date = '{0}' order by no asc", dateTimePicker1.Value.ToShortDateString()));
                    _income_Help.DataSource = ds.Tables[0];
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        ds.Tables[0].Rows[i]["금 액"] = ToComma(ds.Tables[0].Rows[i]["금 액"].ToString());
                }

                for (int i = 0; i < _income_Help.Columns.Count; i++)
                    _income_Help.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                for (int i = 0; i < _income_Help.ColumnCount; i++)
                    _income_Help.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

                // Set Sumation.
                int sum = 0;
                for (int i = 0; i < _income_Help.RowCount - 1; i++)
                    if (_income_Help.Rows[i].Cells[1].Value.ToString() != "")
                        sum += Convert.ToInt32(ToNoComma(_income_Help.Rows[i].Cells[1].Value));
                Sum_Help = sum;
                
                SQLite.CloseDB();
            }
            catch (SQLiteException e)
            {
                Debug.WriteLine(e);
            }
        }

        private void SetCarDGV(int check)
        {
            try
            {
                SQLite.ConnectToDB();

                if (check == 1)
                {
                    DataSet ds = SQLite.ExecuteSelectQuery(string.Format("select name as '이 름', cast (amount as Text) as '금 액', date as '날 짜' from Offering_Car where date = '{0}' order by no asc", DateTime.Now.ToShortDateString()));
                    _income_Car.DataSource = ds.Tables[0];
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        ds.Tables[0].Rows[i]["금 액"] = ToComma(ds.Tables[0].Rows[i]["금 액"].ToString());
                }
                else if (check == 2)
                {
                    DataSet ds = SQLite.ExecuteSelectQuery(string.Format("select name as '이 름', cast (amount as Text) as '금 액', date as '날 짜' from Offering_Car where date = '{0}' order by no asc", dateTimePicker1.Value.ToShortDateString()));
                    _income_Car.DataSource = ds.Tables[0];
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        ds.Tables[0].Rows[i]["금 액"] = ToComma(ds.Tables[0].Rows[i]["금 액"].ToString());
                }

                for (int i = 0; i < _income_Car.Columns.Count; i++)
                    _income_Car.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                for (int i = 0; i < _income_Car.ColumnCount; i++)
                    _income_Car.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

                // Set Sumation.
                int sum = 0;
                for (int i = 0; i < _income_Car.RowCount - 1; i++)
                    if (_income_Car.Rows[i].Cells[1].Value.ToString() != "")
                        sum += Convert.ToInt32(ToNoComma(_income_Car.Rows[i].Cells[1].Value));
                Sum_Car = sum;

                SQLite.CloseDB();
            }
            catch (SQLiteException e)
            {
                SQLite.CloseDB();
                Debug.WriteLine(e);
            }
        }

        private void SetTermDGV(int check)
        {
            try
            {
                SQLite.ConnectToDB();

                if (check == 1)
                {
                    DataSet ds = SQLite.ExecuteSelectQuery(string.Format("select name as '이 름', cast (amount as Text) as'금 액', date as '날 짜' from Offering_Term where date = '{0}' order by no asc", DateTime.Now.ToShortDateString()));
                    _income_Term.DataSource = ds.Tables[0];
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        ds.Tables[0].Rows[i]["금 액"] = ToComma(ds.Tables[0].Rows[i]["금 액"].ToString());
                }
                else if (check == 2)
                {
                    DataSet ds = SQLite.ExecuteSelectQuery(string.Format("select name as '이 름', cast (amount as Text) as '금 액', date as '날 짜' from Offering_Term where date = '{0}' order by no asc", dateTimePicker1.Value.ToShortDateString()));
                    _income_Term.DataSource = ds.Tables[0];
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        ds.Tables[0].Rows[i]["금 액"] = ToComma(ds.Tables[0].Rows[i]["금 액"].ToString());
                }

                for (int i = 0; i < _income_Term.Columns.Count; i++)
                    _income_Term.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                for (int i = 0; i < _income_Term.ColumnCount; i++)
                    _income_Term.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

                // Set Sumation.
                int sum = 0;
                for (int i = 0; i < _income_Term.RowCount - 1; i++)
                    if (_income_Term.Rows[i].Cells[1].Value.ToString() != "")
                        sum += Convert.ToInt32(ToNoComma(_income_Term.Rows[i].Cells[1].Value));
                Sum_Term = sum;

                SQLite.CloseDB();
            }
            catch (SQLiteException e)
            {
                Debug.WriteLine(e);
            }
        }

        private void SetOtherDGV(int check)
        {
            try
            {
                SQLite.ConnectToDB();

                if (check == 1)
                {
                    DataSet ds = SQLite.ExecuteSelectQuery(string.Format("select name as '이 름', cast (amount as Text) as'금 액', date as '날 짜' from Offering_Other where date = '{0}' order by no asc", DateTime.Now.ToShortDateString()));
                    _income_Other.DataSource = ds.Tables[0];
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        ds.Tables[0].Rows[i]["금 액"] = ToComma(ds.Tables[0].Rows[i]["금 액"].ToString());
                }
                else if (check == 2)
                {
                    DataSet ds = SQLite.ExecuteSelectQuery(string.Format("select name as '이 름', cast (amount as Text) as '금 액', date as '날 짜' from Offering_Other where date = '{0}' order by no asc", dateTimePicker1.Value.ToShortDateString()));
                    _income_Other.DataSource = ds.Tables[0];
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        ds.Tables[0].Rows[i]["금 액"] = ToComma(ds.Tables[0].Rows[i]["금 액"].ToString());
                }

                for (int i = 0; i < _income_Other.Columns.Count; i++)
                    _income_Other.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                for (int i = 0; i < _income_Other.ColumnCount; i++)
                    _income_Other.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

                // Set Sumation.
                int sum = 0;
                for (int i = 0; i < _income_Other.RowCount - 1; i++)
                    if (_income_Other.Rows[i].Cells[1].Value.ToString() != "")
                        sum += Convert.ToInt32(ToNoComma(_income_Other.Rows[i].Cells[1].Value));
                Sum_Other = sum;
                
                SQLite.CloseDB();
            }
            catch (SQLiteException e)
            {
                Debug.WriteLine(e);
            }
        }

        private void SetInterestDGV(int check)
        {
            try
            {
                SQLite.ConnectToDB();

                if (check == 1)
                {
                    DataSet ds = SQLite.ExecuteSelectQuery(string.Format("select name as '이 름', cast (amount as Text) as '금 액', date as '날 짜' from Offering_Interest where date = '{0}' order by no asc", DateTime.Now.ToShortDateString()));
                    _income_Interest.DataSource = ds.Tables[0];
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        ds.Tables[0].Rows[i]["금 액"] = ToComma(ds.Tables[0].Rows[i]["금 액"].ToString());
                }
                else if (check == 2)
                {
                    DataSet ds = SQLite.ExecuteSelectQuery(string.Format("select name as '이 름', cast (amount as Text) as '금 액', date as '날 짜' from Offering_Interest where date = '{0}' order by no asc", dateTimePicker1.Value.ToShortDateString()));
                    _income_Interest.DataSource = ds.Tables[0];
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        ds.Tables[0].Rows[i]["금 액"] = ToComma(ds.Tables[0].Rows[i]["금 액"].ToString());
                }

                for (int i = 0; i < _income_Interest.Columns.Count; i++)
                    _income_Interest.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                for (int i = 0; i < _income_Interest.ColumnCount; i++)
                    _income_Interest.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

                // Set Sumation.
                int sum = 0;
                for (int i = 0; i < _income_Interest.RowCount - 1; i++)
                    if (_income_Interest.Rows[i].Cells[1].Value.ToString() != "")
                        sum += Convert.ToInt32(ToNoComma(_income_Interest.Rows[i].Cells[1].Value));
                Sum_Interest = sum;

                SQLite.CloseDB();
            }
            catch (SQLiteException e)
            {
                SQLite.CloseDB();
                Debug.WriteLine(e);
            }
        }

        #endregion

        private void SetInputSumDGV()
        {
            try
            {
                SQLite.ConnectToDB();
                income.Rows.Clear();



                // 감사헌금
                String[] a = { "감사헌금", ToComma(Sum_Thanks.ToString()) };
                income.Rows.Add(a);

                // 십일조
                string[] b = {  "십일조", ToComma(Sum_10.ToString()) };
                income.Rows.Add(b);

                // 구역헌금
                string[] c = { "구역헌금", ToComma(Sum_Cell.ToString()) };
                income.Rows.Add(c);

                // 건축헌금
                string[] d = { "건축헌금", ToComma(Sum_Archi.ToString()) };
                income.Rows.Add(d);

                // 선교헌금
                string[] e = { "선교헌금", ToComma(Sum_Mission.ToString()) };
                income.Rows.Add(e);

                // 성미헌금
                string[] f = { "성미헌금", ToComma(Sum_Rice.ToString()) };
                income.Rows.Add(f);

                // 구제헌금
                string[] g = { "구제헌금", ToComma(Sum_Help.ToString() )};
                income.Rows.Add(g);

                // 차량헌금
                string[] h = { "차량헌금", ToComma(Sum_Car.ToString()) };
                income.Rows.Add(h);

                // 절기헌금
                string[] n = { "절기헌금", ToComma(Sum_Term.ToString() )};
                income.Rows.Add(n);

                // 기타헌금
                string[] k = { "기타수입", ToComma(Sum_Other.ToString()) };
                income.Rows.Add(k);

                // 이자수입
                string[] j = { "이자수입", ToComma(Sum_Interest.ToString()) };
                income.Rows.Add(j);


                // Total of Total
                int sumn = 0;
                for (int i = 0; i < income.RowCount-1; i++)
                {
                    if (income.Rows[i].Cells[1].Value.ToString() != "")
                        sumn += Convert.ToInt32(ToNoComma(income.Rows[i].Cells[1].Value));
                }

                income_total.Rows[0].Cells[1].Value = ToComma(sumn);
                SQLite.CloseDB();
            }
            catch( SQLiteException e)
            {
                SQLite.CloseDB();
                Debug.WriteLine(e);
            }
        }


        private void Button1_Click(object sender, EventArgs e)
        {
            if(currentCategory.Equals("Budget"))
            {
                BIp.ButtonEvent();
                BSp.ButtonEvent();
            }
            else
            {
                SQLite.Execute(string.Format("Delete From Offering_thanks where date = '{0}'", ((DateTime)dateTimePicker1.Value).ToShortDateString()));
                SQLite.Execute(string.Format("Delete From Offering_10 where date = '{0}'", ((DateTime)dateTimePicker1.Value).ToShortDateString()));
                SQLite.Execute(string.Format("Delete From Offering_Cell where date = '{0}'", ((DateTime)dateTimePicker1.Value).ToShortDateString()));
                SQLite.Execute(string.Format("Delete From Offering_Archi where date = '{0}'", ((DateTime)dateTimePicker1.Value).ToShortDateString()));
                SQLite.Execute(string.Format("Delete From Offering_Mission where date = '{0}'", ((DateTime)dateTimePicker1.Value).ToShortDateString()));
                SQLite.Execute(string.Format("Delete From Offering_Rice where date = '{0}'", ((DateTime)dateTimePicker1.Value).ToShortDateString()));
                SQLite.Execute(string.Format("Delete From Offering_Help where date = '{0}'", ((DateTime)dateTimePicker1.Value).ToShortDateString()));
                SQLite.Execute(string.Format("Delete From Offering_Car where date = '{0}'", ((DateTime)dateTimePicker1.Value).ToShortDateString()));
                SQLite.Execute(string.Format("Delete From Offering_Term where date = '{0}'", ((DateTime)dateTimePicker1.Value).ToShortDateString()));
                SQLite.Execute(string.Format("Delete From Offering_Other where date = '{0}'", ((DateTime)dateTimePicker1.Value).ToShortDateString()));
                SQLite.Execute(string.Format("Delete From Offering_Interest where date = '{0}'", ((DateTime)dateTimePicker1.Value).ToShortDateString()));

                for (int i = 0; i < _income_Thanks.RowCount - 1; i++)
                    if( _income_Thanks.Rows[i].Cells[1].Value.ToString() != "0")
                        SQLite.Execute(string.Format("insert into Offering_thanks (name, amount, date) values('{0}', {1}, '{2}')", _income_Thanks.Rows[i].Cells[0].Value, Convert.ToInt32(ToNoComma(_income_Thanks.Rows[i].Cells[1].Value)), ((DateTime)_income_Thanks.Rows[i].Cells[2].Value).ToShortDateString()));
                for (int i = 0; i < _income_10.RowCount - 1; i++)
                        if (_income_10.Rows[i].Cells[1].Value.ToString() != "0")
                            SQLite.Execute(string.Format("insert into Offering_10 (name, amount, date) values('{0}', {1}, '{2}')", _income_10.Rows[i].Cells[0].Value, Convert.ToInt32(ToNoComma(_income_10.Rows[i].Cells[1].Value)), ((DateTime)_income_10.Rows[i].Cells[2].Value).ToShortDateString()));
                for (int i = 0; i < _income_Cell.RowCount - 1; i++)
                        if (_income_Cell.Rows[i].Cells[1].Value.ToString() != "0")
                            SQLite.Execute(string.Format("insert into Offering_Cell (name, amount, date) values('{0}', {1}, '{2}')", _income_Cell.Rows[i].Cells[0].Value, Convert.ToInt32(ToNoComma(_income_Cell.Rows[i].Cells[1].Value)), ((DateTime)_income_Cell.Rows[i].Cells[2].Value).ToShortDateString()));
                for (int i = 0; i < _income_Archi.RowCount - 1; i++)
                        if (_income_Archi.Rows[i].Cells[1].Value.ToString() != "0")
                            SQLite.Execute(string.Format("insert into Offering_Archi (name, amount, date) values('{0}', {1}, '{2}')", _income_Archi.Rows[i].Cells[0].Value, Convert.ToInt32(ToNoComma(_income_Archi.Rows[i].Cells[1].Value)), ((DateTime)_income_Archi.Rows[i].Cells[2].Value).ToShortDateString()));
                for (int i = 0; i < _income_Mission.RowCount - 1; i++)
                        if (_income_Mission.Rows[i].Cells[1].Value.ToString() != "0")
                            SQLite.Execute(string.Format("insert into Offering_Mission (name, amount, date) values('{0}', {1}, '{2}')", _income_Mission.Rows[i].Cells[0].Value, Convert.ToInt32(ToNoComma(_income_Mission.Rows[i].Cells[1].Value)), ((DateTime)_income_Mission.Rows[i].Cells[2].Value).ToShortDateString()));
                for (int i = 0; i < _income_Rice.RowCount - 1; i++)
                        if (_income_Rice.Rows[i].Cells[1].Value.ToString() != "0")
                            SQLite.Execute(string.Format("insert into Offering_Rice (name, amount, date) values('{0}', {1}, '{2}')", _income_Rice.Rows[i].Cells[0].Value, Convert.ToInt32(ToNoComma(_income_Rice.Rows[i].Cells[1].Value)), ((DateTime)_income_Rice.Rows[i].Cells[2].Value).ToShortDateString()));
                for (int i = 0; i < _income_Help.RowCount - 1; i++)
                        if (_income_Help.Rows[i].Cells[1].Value.ToString() != "0")
                            SQLite.Execute(string.Format("insert into Offering_Help (name, amount, date) values('{0}', {1}, '{2}')", _income_Help.Rows[i].Cells[0].Value, Convert.ToInt32(ToNoComma(_income_Help.Rows[i].Cells[1].Value)), ((DateTime)_income_Help.Rows[i].Cells[2].Value).ToShortDateString()));
                for (int i = 0; i < _income_Car.RowCount - 1; i++)
                        if (_income_Car.Rows[i].Cells[1].Value.ToString() != "0")
                            SQLite.Execute(string.Format("insert into Offering_Car (name, amount, date) values('{0}', {1}, '{2}')", _income_Car.Rows[i].Cells[0].Value, Convert.ToInt32(ToNoComma(_income_Car.Rows[i].Cells[1].Value)), ((DateTime)_income_Car.Rows[i].Cells[2].Value).ToShortDateString()));
                for (int i = 0; i < _income_Term.RowCount - 1; i++)
                        if (_income_Term.Rows[i].Cells[1].Value.ToString() != "0")
                            SQLite.Execute(string.Format("insert into Offering_Term (name, amount, date) values('{0}', {1}, '{2}')", _income_Term.Rows[i].Cells[0].Value, Convert.ToInt32(ToNoComma(_income_Term.Rows[i].Cells[1].Value)), ((DateTime)_income_Term.Rows[i].Cells[2].Value).ToShortDateString()));
                for (int i = 0; i < _income_Other.RowCount - 1; i++)
                        if (_income_Other.Rows[i].Cells[1].Value.ToString() != "0")
                            SQLite.Execute(string.Format("insert into Offering_Other (name, amount, date) values('{0}', {1}, '{2}')", _income_Other.Rows[i].Cells[0].Value, Convert.ToInt32(ToNoComma(_income_Other.Rows[i].Cells[1].Value)), ((DateTime)_income_Other.Rows[i].Cells[2].Value).ToShortDateString()));
                for (int i = 0; i < _income_Interest.RowCount - 1; i++)
                        if (_income_Interest.Rows[i].Cells[1].Value.ToString() != "0")
                            SQLite.Execute(string.Format("insert into Offering_Interest (name, amount, date) values('{0}', {1}, '{2}')", _income_Interest.Rows[i].Cells[0].Value, Convert.ToInt32(ToNoComma(_income_Interest.Rows[i].Cells[1].Value)), ((DateTime)_income_Interest.Rows[i].Cells[2].Value).ToShortDateString()));

                SetThanksDGV(2);
                Set10DGV(2);
                SetCellDGV(2);
                SetArchiDGV(2);
                SetMissionDGV(2);
                SetRiceDGV(2);
                SetHelpDGV(2);
                SetCarDGV(2);
                SetTermDGV(2);
                SetOtherDGV(2);
                SetInterestDGV(2);

                // 지출 저장 이벤트
                WSP.ButtonEvent();

                // 저장된 값에따른 IncomeProgress 그림
                ip.setIncomeFromDB();
                sp.setSpendFromDB();
                sp.setSpendFromDB();
                sp.setSpendFromDB();
            }
        }
    }
}

