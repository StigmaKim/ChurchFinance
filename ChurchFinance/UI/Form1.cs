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
        NeoTabPage currentWeekTab = null; 

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
        

        public Form1()
        {
            InitializeComponent();
            SQLite = new SQLite(); // DB Object
            cmd = SQLite.GetSQLCommand(); // Command Object
            currentCategory = "Week";
            button1.Visible = true;
            button2.Visible = false;

            dateTimePicker1.ValueChanged += DateTimePicker1_ValueChanged;
            
            neoTabWindow1.Renderer = NeoTabControlLibrary.AddInRendererManager.LoadRenderer("MarginBlueRendererVS2");
            neoTabWindow1.BackColor = Color.White;
            imgBtnContainer1.BackColor = Color.White;
            imgBtnContainer2.BackColor = Color.White;
            button1.Click += Button1_Click;

            setImgBtn();
            setWeekTabPage();

            neoTabWindow1.SelectedIndexChanged += NeoTabWindow1_SelectedIndexChanged;


            panel5.BackColor = Color.LightGray;
            panel2.BackColor = Color.LightGray;
            
            // Month
            M_ReportTab = new NeoTabPage();
            M_ReportTab.Text = "재정 보고";
            sr = new SpendReport();
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
            M_DetailTab.Text = "지출 세부항목";
            M_DetailTab.AutoScroll = true;
            sd = new SpendDetail();
            sd.Dock = DockStyle.Fill;
            M_DetailTab.Controls.Add(sd);

            ip.Date = DateTime.Now;
            sp.Date = DateTime.Now;
            ip.setIncomeFromDB();
            ip.setSpendFromDB();
            sp.setSpendFromDB();
            sp.setSpendFromDB();
        }

        private void NeoTabWindow1_SelectedIndexChanged(object sender, SelectedIndexChangedEventArgs e)
        {
            currentWeekTab = e.TabPage;           
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e) // 날짜 바뀔땐 항상 감사헌금 띄움
        {
            /*
            W_IncomeTab.Controls.Remove(currentTab);
            W_IncomeTab.Controls.Remove(income);
            W_IncomeTab.Controls.Remove(income_total);
            W_IncomeTab.Controls.Remove(_income_total);
            */
            W_IncomeTab.Controls.Add(_income_Thanks);
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

            // 값 변화있을때 Re Draw
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

            W_IncomeTab.Controls.Remove(_income_Thanks);
            W_IncomeTab.Controls.Remove(_income_10);
            W_IncomeTab.Controls.Remove(_income_Cell);
            W_IncomeTab.Controls.Remove(_income_Archi);
            W_IncomeTab.Controls.Remove(_income_Mission);
            W_IncomeTab.Controls.Remove(_income_Rice);
            W_IncomeTab.Controls.Remove(_income_Help);
            W_IncomeTab.Controls.Remove(_income_Car);
            W_IncomeTab.Controls.Remove(_income_Term);
            W_IncomeTab.Controls.Remove(_income_Other);
            W_IncomeTab.Controls.Remove(_income_Interest);

            SetInputSumDGV();
            W_IncomeTab.Controls.Add(_income_Thanks);
            currentTab = _income_Thanks;
            /*
            W_IncomeTab.Controls.Add(_income_Thanks);
            W_IncomeTab.Controls.Add(income);
            W_IncomeTab.Controls.Add(_income_total);
            W_IncomeTab.Controls.Add(income_total);
            */

            ip.Date = dateTimePicker1.Value;
            sp.Date = dateTimePicker1.Value;
            ip.setIncomeFromDB();
            sp.setSpendFromDB();
            sp.setSpendFromDB();
            sp.setSpendFromDB();
        }


        /// <summary>
        /// 아이콘 설정
        /// </summary>
        private void setImgBtn()
        {
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

            //imgBtnContainer1.

        }

        #region WEEK MONTH YEAR CLICK EVENT

        /// <summary>
        /// Year 버튼 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void YearBtn_Click(object sender, EventArgs e)
        {
            neoTabWindow1.Controls.Clear();

            currentCategory = "Year";
            button1.Visible = false;
            button2.Visible = true;
        }

        /// <summary>
        /// Month 버튼 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            
        }

        /// <summary>
        /// Week 버튼 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WeekBtn_Click(object sender, EventArgs e)
        {
            // Tab 다 지우고 새로 넣기
            neoTabWindow1.Controls.Clear();

            neoTabWindow1.Controls.Add(W_IncomeTab);
            neoTabWindow1.Controls.Add(W_SpendingTab);
            currentWeekTab = W_IncomeTab;

            currentCategory = "Week";
            button1.Visible = true;
            button2.Visible = false;
        }

        #endregion 
        
        private void setWeekTabPage()
        {
            W_IncomeTab = new NeoTabPage();
            W_SpendingTab = new NeoTabPage();

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

            W_IncomeTab.Controls.Remove(_income_Thanks);
            W_IncomeTab.Controls.Remove(_income_10);
            W_IncomeTab.Controls.Remove(_income_Cell);
            W_IncomeTab.Controls.Remove(_income_Archi);
            W_IncomeTab.Controls.Remove(_income_Mission);
            W_IncomeTab.Controls.Remove(_income_Rice);
            W_IncomeTab.Controls.Remove(_income_Help);
            W_IncomeTab.Controls.Remove(_income_Car);
            W_IncomeTab.Controls.Remove(_income_Term);
            W_IncomeTab.Controls.Remove(_income_Other);
            W_IncomeTab.Controls.Remove(_income_Interest);

            SetInputSumDGV(); // 최초 DGV 그리기. ( 수입 SUM )
            W_IncomeTab.Controls.Add(_income_Thanks);
            currentTab = _income_Thanks;
            currentWeekTab = W_IncomeTab;
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
            
            income.CellMouseDown += Income_CellMouseDown;


            #endregion

            #region DGV 옵션 1
            // income ---------------------------------------
            income.Size = new Size(300, 400);
            income.Location = new Point(20, 20);
            income.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            income.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            income.ColumnCount = 2;
            income.ReadOnly = true;

            income.Columns[0].Name = "수 입";
            income.Columns[1].Name = "금 액";
            
            //String[] rows = { "십일조", "4,300,200원" };
            //income.Rows.Add(rows);

            for (int i = 0; i < income.Columns.Count; i++)
            {
                income.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            /*
            for(int i = 0;i < 20; i++)
            {
                String[] row = { " ", " " };
                income.Rows.Add(row);
            }
            */

            // income_total ------------------------------
            income_total.Size = new Size(300, 26);
            income_total.Location = new Point(20, 425);
            income_total.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            income_total.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            income_total.ColumnHeadersVisible = false;
            income_total.ColumnCount = 2;
            income_total.ReadOnly = true;

            income_total.Rows[0].Cells[0].Value = "Total";

            for (int i = 0; i < income_total.Columns.Count; i++)
            {
                income_total.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            // _income_total -------------------------------
            _income_total.Size = new Size(600, 26);
            _income_total.Location = new Point(350, 425);
            _income_total.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _income_total.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _income_total.ColumnHeadersVisible = false;
            _income_total.ColumnCount = 3;
            _income_total.ReadOnly = true;

            _income_total.Rows[0].Cells[0].Value = "Total";
            _income_total.Rows[0].Cells[1].Value = "";
            _income_total.Rows[0].Cells[2].Value = "";

            for (int i = 0; i < _income_total.Columns.Count; i++)
            {
                _income_total.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            #endregion

            
            #region DGV 옵션 2

            // _income_Thanks ----------------------------------
            _income_Thanks.Size = new Size(600, 400);
            _income_Thanks.Location = new Point(350, 20);
            _income_Thanks.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _income_Thanks.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        
            // _income_10 ----------------------------------
            _income_10.Size = new Size(600, 400);
            _income_10.Location = new Point(350, 20);
            _income_10.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _income_10.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // _income_Cell ----------------------------------
            _income_Cell.Size = new Size(600, 400);
            _income_Cell.Location = new Point(350, 20);
            _income_Cell.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _income_Cell.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // _income_Archi ----------------------------------
            _income_Archi.Size = new Size(600, 400);
            _income_Archi.Location = new Point(350, 20);
            _income_Archi.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _income_Archi.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // _income_Mission ----------------------------------
            _income_Mission.Size = new Size(600, 400);
            _income_Mission.Location = new Point(350, 20);
            _income_Mission.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _income_Mission.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // _income_Rice ----------------------------------
            _income_Rice.Size = new Size(600, 400);
            _income_Rice.Location = new Point(350, 20);
            _income_Rice.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _income_Rice.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // _income_Help ----------------------------------
            _income_Help.Size = new Size(600, 400);
            _income_Help.Location = new Point(350, 20);
            _income_Help.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _income_Help.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // _income_Car ----------------------------------
            _income_Car.Size = new Size(600, 400);
            _income_Car.Location = new Point(350, 20);
            _income_Car.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _income_Car.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // _income_Term ----------------------------------
            _income_Term.Size = new Size(600, 400);
            _income_Term.Location = new Point(350, 20);
            _income_Term.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _income_Term.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // _income_Other ----------------------------------
            _income_Other.Size = new Size(600, 400);
            _income_Other.Location = new Point(350, 20);
            _income_Other.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _income_Other.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // _income_Interest ----------------------------------
            _income_Interest.Size = new Size(600, 400);
            _income_Interest.Location = new Point(350, 20);
            _income_Interest.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _income_Interest.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            #endregion

            // Draw DGVS --------------------------------------------------

            W_IncomeTab.Controls.Add(income);

            W_IncomeTab.Controls.Add(_income_Thanks);
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

            W_IncomeTab.Controls.Add(income_total);
            W_IncomeTab.Controls.Add(_income_total);
            
        }



        private void Income_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            Debug.WriteLine("Rows : " + e.RowIndex);
            W_IncomeTab.Controls.Remove(currentTab);

            switch (e.RowIndex)
            {
                case 0:
                    W_IncomeTab.Controls.Add(_income_Thanks);
                    _income_total.Rows[0].Cells[1].Value = Sum_Thanks;
                    currentTab = _income_Thanks;
                    break;
                case 1:
                    W_IncomeTab.Controls.Add(_income_10);
                    _income_total.Rows[0].Cells[1].Value = Sum_10;
                    currentTab = _income_10;
                    break;
                case 2:
                    W_IncomeTab.Controls.Add(_income_Cell);
                    _income_total.Rows[0].Cells[1].Value = Sum_Cell;
                    currentTab = _income_Cell;
                    break;
                case 3:
                    W_IncomeTab.Controls.Add(_income_Archi);
                    _income_total.Rows[0].Cells[1].Value = Sum_Archi;
                    currentTab = _income_Archi;
                    break;
                case 4:
                    W_IncomeTab.Controls.Add(_income_Mission);
                    _income_total.Rows[0].Cells[1].Value = Sum_Mission;
                    currentTab = _income_Mission;
                    break;
                case 5:
                    W_IncomeTab.Controls.Add(_income_Rice);
                    _income_total.Rows[0].Cells[1].Value = Sum_Rice;
                    currentTab = _income_Rice;
                    break;
                case 6:
                    W_IncomeTab.Controls.Add(_income_Help);
                    _income_total.Rows[0].Cells[1].Value = Sum_Help;
                    currentTab = _income_Help;
                    break;
                case 7:
                    W_IncomeTab.Controls.Add(_income_Car);
                    _income_total.Rows[0].Cells[1].Value = Sum_Car;
                    currentTab = _income_Car;
                    break;
                case 8:
                    W_IncomeTab.Controls.Add(_income_Term);
                    _income_total.Rows[0].Cells[1].Value = Sum_Term;
                    currentTab = _income_Term;
                    break;
                case 9:
                    W_IncomeTab.Controls.Add(_income_Other);
                    _income_total.Rows[0].Cells[1].Value = Sum_Other;
                    currentTab = _income_Other;
                    break;
                case 10:
                    W_IncomeTab.Controls.Add(_income_Interest);
                    _income_total.Rows[0].Cells[1].Value = Sum_Interest;
                    currentTab = _income_Interest;
                    break;
            }
        }
        
        #region 에딧 이벤트

        private void _income_Thanks_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Set New Value`s Date
            if (_income_Thanks.Rows[e.RowIndex].Cells[2].Value.ToString() == "")
                _income_Thanks.Rows[e.RowIndex].Cells[2].Value = ((DateTime)dateTimePicker1.Value).ToShortDateString();

            // Set Sumation.
            int sum = 0;
            for (int i = 0; i < _income_Thanks.RowCount - 1; i++)
            {
                if (_income_Thanks.Rows[i].Cells[1].Value.ToString() != "")
                    sum += Convert.ToInt32(_income_Thanks.Rows[i].Cells[1].Value);
            }
            Sum_Thanks = sum;
            _income_total.Rows[0].Cells[1].Value = Sum_Thanks;

            SetInputSumDGV();
            SQLite.CloseDB();
        }

        private void _income_10_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Set New Value`s Date
            if (_income_10.Rows[e.RowIndex].Cells[2].Value.ToString() == "")
                _income_10.Rows[e.RowIndex].Cells[2].Value = ((DateTime)dateTimePicker1.Value).ToShortDateString();

            // Set Sumation.
            int sum = 0;
            for (int i = 0; i < _income_10.RowCount - 1; i++)
            {
                if (_income_10.Rows[i].Cells[1].Value.ToString() != "")
                    sum += Convert.ToInt32(_income_10.Rows[i].Cells[1].Value);
            }
            Sum_10 = sum;
            _income_total.Rows[0].Cells[1].Value = Sum_10;

            SetInputSumDGV();
            SQLite.CloseDB();
        }

        private void _income_Cell_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Set New Value`s Date
            if (_income_Cell.Rows[e.RowIndex].Cells[2].Value.ToString() == "")
                _income_Cell.Rows[e.RowIndex].Cells[2].Value = ((DateTime)dateTimePicker1.Value).ToShortDateString();

            // Set Sumation.
            int sum = 0;
            for (int i = 0; i < _income_Cell.RowCount - 1; i++)
            {
                //Debug.WriteLine("Cell 0 : " + _income.Rows[0].Cells[0].Value);
                if (_income_Cell.Rows[i].Cells[1].Value.ToString() != "")
                    sum += Convert.ToInt32(_income_Cell.Rows[i].Cells[1].Value);
            }
            Sum_Cell = sum;
            _income_total.Rows[0].Cells[1].Value = Sum_Cell;

            SetInputSumDGV();
            SQLite.CloseDB();
        }

        private void _income_Archi_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Set New Value`s Date
            if (_income_Archi.Rows[e.RowIndex].Cells[2].Value.ToString() == "")
                _income_Archi.Rows[e.RowIndex].Cells[2].Value = ((DateTime)dateTimePicker1.Value).ToShortDateString();

            // Set Sumation.
            int sum = 0;
            for (int i = 0; i < _income_Archi.RowCount - 1; i++)
            {
                //Debug.WriteLine("Cell 0 : " + _income.Rows[0].Cells[0].Value);
                if (_income_Archi.Rows[i].Cells[1].Value.ToString() != "")
                    sum += Convert.ToInt32(_income_Archi.Rows[i].Cells[1].Value);
            }
            Sum_Archi = sum;
            _income_total.Rows[0].Cells[1].Value = Sum_Archi;

            SetInputSumDGV();
            SQLite.CloseDB();
        }

        private void _income_Mission_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Set New Value`s Date
            if (_income_Mission.Rows[e.RowIndex].Cells[2].Value.ToString() == "")
                _income_Mission.Rows[e.RowIndex].Cells[2].Value = ((DateTime)dateTimePicker1.Value).ToShortDateString();

            // Set Sumation.
            int sum = 0;
            for (int i = 0; i < _income_Mission.RowCount - 1; i++)
            {
                //Debug.WriteLine("Cell 0 : " + _income.Rows[0].Cells[0].Value);
                if (_income_Mission.Rows[i].Cells[1].Value.ToString() != "")
                    sum += Convert.ToInt32(_income_Mission.Rows[i].Cells[1].Value);
            }
            Sum_Mission = sum;
            _income_total.Rows[0].Cells[1].Value = Sum_Mission;

            SetInputSumDGV();
            SQLite.CloseDB();
        }

        private void _income_Rice_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Set New Value`s Date
            if (_income_Rice.Rows[e.RowIndex].Cells[2].Value.ToString() == "")
                _income_Rice.Rows[e.RowIndex].Cells[2].Value = ((DateTime)dateTimePicker1.Value).ToShortDateString();

            // Set Sumation.
            int sum = 0;
            for (int i = 0; i < _income_Rice.RowCount - 1; i++)
            {
                //Debug.WriteLine("Cell 0 : " + _income.Rows[0].Cells[0].Value);
                if (_income_Rice.Rows[i].Cells[1].Value.ToString() != "")
                    sum += Convert.ToInt32(_income_Rice.Rows[i].Cells[1].Value);
            }
            Sum_Rice = sum;
            _income_total.Rows[0].Cells[1].Value = Sum_Rice;

            SetInputSumDGV();
            SQLite.CloseDB();
        }

        private void _income_Help_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Set New Value`s Date
            if (_income_Help.Rows[e.RowIndex].Cells[2].Value.ToString() == "")
                _income_Help.Rows[e.RowIndex].Cells[2].Value = ((DateTime)dateTimePicker1.Value).ToShortDateString();

            // Set Sumation.
            int sum = 0;
            for (int i = 0; i < _income_Help.RowCount - 1; i++)
            {
                //Debug.WriteLine("Cell 0 : " + _income.Rows[0].Cells[0].Value);
                if (_income_Help.Rows[i].Cells[1].Value.ToString() != "")
                    sum += Convert.ToInt32(_income_Help.Rows[i].Cells[1].Value);
            }
            Sum_Help = sum;
            _income_total.Rows[0].Cells[1].Value = Sum_Help;

            SetInputSumDGV();
            SQLite.CloseDB();
        }

        private void _income_Car_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Set New Value`s Date
            if (_income_Car.Rows[e.RowIndex].Cells[2].Value.ToString() == "")
                _income_Car.Rows[e.RowIndex].Cells[2].Value = ((DateTime)dateTimePicker1.Value).ToShortDateString();

            // Set Sumation.
            int sum = 0;
            for (int i = 0; i < _income_Car.RowCount - 1; i++)
            {
                //Debug.WriteLine("Cell 0 : " + _income.Rows[0].Cells[0].Value);
                if (_income_Car.Rows[i].Cells[1].Value.ToString() != "")
                    sum += Convert.ToInt32(_income_Car.Rows[i].Cells[1].Value);
            }
            Sum_Car = sum;
            _income_total.Rows[0].Cells[1].Value = Sum_Car;

            SetInputSumDGV();
            SQLite.CloseDB();
        }

        private void _income_Term_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Set New Value`s Date
            if (_income_Term.Rows[e.RowIndex].Cells[2].Value.ToString() == "")
                _income_Term.Rows[e.RowIndex].Cells[2].Value = ((DateTime)dateTimePicker1.Value).ToShortDateString();

            // Set Sumation.
            int sum = 0;
            for (int i = 0; i < _income_Term.RowCount - 1; i++)
            {
                //Debug.WriteLine("Cell 0 : " + _income.Rows[0].Cells[0].Value);
                if (_income_Term.Rows[i].Cells[1].Value.ToString() != "")
                    sum += Convert.ToInt32(_income_Term.Rows[i].Cells[1].Value);
            }
            Sum_Term = sum;
            _income_total.Rows[0].Cells[1].Value = Sum_Term;

            SetInputSumDGV();
            SQLite.CloseDB();
        }

        private void _income_Other_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Set New Value`s Date
            if (_income_Other.Rows[e.RowIndex].Cells[2].Value.ToString() == "")
                _income_Other.Rows[e.RowIndex].Cells[2].Value = ((DateTime)dateTimePicker1.Value).ToShortDateString();

            // Set Sumation.
            int sum = 0;
            for (int i = 0; i < _income_Other.RowCount - 1; i++)
            {
                //Debug.WriteLine("Cell 0 : " + _income.Rows[0].Cells[0].Value);
                if (_income_Other.Rows[i].Cells[1].Value.ToString() != "")
                    sum += Convert.ToInt32(_income_Other.Rows[i].Cells[1].Value);
            }
            Sum_Other = sum;
            _income_total.Rows[0].Cells[1].Value = Sum_Other;

            SetInputSumDGV();
            SQLite.CloseDB();
        }

        private void _income_Interest_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Set New Value`s Date
            if (_income_Interest.Rows[e.RowIndex].Cells[2].Value.ToString() == "")
                _income_Interest.Rows[e.RowIndex].Cells[2].Value = ((DateTime)dateTimePicker1.Value).ToShortDateString();

            // Set Sumation.
            int sum = 0;
            for (int i = 0; i < _income_Interest.RowCount - 1; i++)
            {
                //Debug.WriteLine("Cell 0 : " + _income.Rows[0].Cells[0].Value);
                if (_income_Interest.Rows[i].Cells[1].Value.ToString() != "")
                    sum += Convert.ToInt32(_income_Interest.Rows[i].Cells[1].Value);
            }
            Sum_Interest = sum;
            _income_total.Rows[0].Cells[1].Value = Sum_Interest;

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
                    DataSet ds = SQLite.ExecuteSelectQuery(string.Format("select name as '이 름', amount as '금 액', date as '날 짜' from Offering_Thanks where date = '{0}' order by no asc", DateTime.Now.ToShortDateString()));
                    _income_Thanks.DataSource = ds.Tables[0];
                    Debug.WriteLine("Value :: " + _income_Thanks.Rows[0].Cells[1].Value);
                }
                else if (check == 2)
                {
                    Debug.WriteLine("Test :: " + check);
                    DataSet ds = SQLite.ExecuteSelectQuery(string.Format("select name as '이 름', amount as '금 액', date as '날 짜' from Offering_Thanks where date = '{0}' order by no asc", ((DateTime)dateTimePicker1.Value).ToShortDateString()));
                    Debug.WriteLine("Date : " + dateTimePicker1.Value.ToShortDateString());
                    _income_Thanks.DataSource = ds.Tables[0];
                    Debug.WriteLine("Value :: " + _income_Thanks.Rows[0].Cells[1].Value);

                }
                
                for (int i = 0; i< _income_Thanks.Columns.Count; i++)
                {
                    _income_Thanks.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                
                // Set Sumation.
                int sum = 0;
                for (int i = 0; i < _income_Thanks.RowCount - 1; i++)
                {
                    //Debug.WriteLine("Cell 0 : " + _income.Rows[0].Cells[0].Value);
                    if (_income_Thanks.Rows[i].Cells[1].Value.ToString() != "")
                    {
                        Debug.WriteLine("value : " + Convert.ToInt32(_income_Thanks.Rows[i].Cells[1].Value));
                        sum += Convert.ToInt32(_income_Thanks.Rows[i].Cells[1].Value);
                    }
                        
                }
                                    
                Sum_Thanks = sum;
                Debug.WriteLine("Sum Thanks : " + Sum_Thanks);
                _income_total.Rows[0].Cells[1].Value = Sum_Thanks;
                
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
                    DataSet ds = SQLite.ExecuteSelectQuery(string.Format("select name as '이 름', amount as '금 액', date as '날 짜' from Offering_10 where date = '{0}' order by no asc", DateTime.Now.ToShortDateString()));
                    _income_10.DataSource = ds.Tables[0];
                }
                else if (check == 2)
                {
                    DataSet ds = SQLite.ExecuteSelectQuery(string.Format("select name as '이 름', amount as '금 액', date as '날 짜' from Offering_10 where date = '{0}' order by no asc", dateTimePicker1.Value.ToShortDateString()));
                    _income_10.DataSource = ds.Tables[0];
                }

                for (int i = 0; i < _income_10.Columns.Count; i++)
                {
                    _income_10.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                // Set Sumation.
                int sum = 0;
                for (int i = 0; i < _income_10.RowCount - 1; i++)
                {
                    //Debug.WriteLine("Cell 0 : " + _income.Rows[0].Cells[0].Value);
                    if (_income_10.Rows[i].Cells[1].Value.ToString() != "")
                        sum += Convert.ToInt32(_income_10.Rows[i].Cells[1].Value);
                }
                Sum_10 = sum;

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
                    DataSet ds = SQLite.ExecuteSelectQuery(string.Format("select name as '이 름', amount as '금 액', date as '날 짜' from Offering_Cell where date = '{0}' order by no asc", DateTime.Now.ToShortDateString()));
                    _income_Cell.DataSource = ds.Tables[0];
                }
                else if (check == 2)
                {
                    DataSet ds = SQLite.ExecuteSelectQuery(string.Format("select name as '이 름', amount as '금 액', date as '날 짜' from Offering_Cell where date = '{0}' order by no asc", dateTimePicker1.Value.ToShortDateString()));
                    _income_Cell.DataSource = ds.Tables[0];
                }

                for (int i = 0; i < _income_Cell.Columns.Count; i++)
                {
                    _income_Cell.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                // Set Sumation.
                int sum = 0;
                for (int i = 0; i < _income_Cell.RowCount - 1; i++)
                {
                    //Debug.WriteLine("Cell 0 : " + _income.Rows[0].Cells[0].Value);
                    if (_income_Cell.Rows[i].Cells[1].Value.ToString() != "")
                        sum += Convert.ToInt32(_income_Cell.Rows[i].Cells[1].Value);
                }
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
                    DataSet ds = SQLite.ExecuteSelectQuery(string.Format("select name as '이 름', amount as '금 액', date as '날 짜' from Offering_Archi where date = '{0}' order by no asc", DateTime.Now.ToShortDateString()));
                    _income_Archi.DataSource = ds.Tables[0];
                }
                else if (check == 2)
                {
                    DataSet ds = SQLite.ExecuteSelectQuery(string.Format("select name as '이 름', amount as '금 액', date as '날 짜' from Offering_Archi where date = '{0}' order by no asc", dateTimePicker1.Value.ToShortDateString()));
                    _income_Archi.DataSource = ds.Tables[0];
                }

                for (int i = 0; i < _income_Archi.Columns.Count; i++)
                {
                    _income_Archi.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                // Set Sumation.
                int sum = 0;
                for (int i = 0; i < _income_Archi.RowCount - 1; i++)
                {
                    //Debug.WriteLine("Cell 0 : " + _income.Rows[0].Cells[0].Value);
                    if (_income_Archi.Rows[i].Cells[1].Value.ToString() != "")
                        sum += Convert.ToInt32(_income_Archi.Rows[i].Cells[1].Value);
                }
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
                    DataSet ds = SQLite.ExecuteSelectQuery(string.Format("select name as '이 름', amount as '금 액', date as '날 짜' from Offering_Mission where date = '{0}' order by no asc", DateTime.Now.ToShortDateString()));
                    _income_Mission.DataSource = ds.Tables[0];
                }
                else if (check == 2)
                {
                    DataSet ds = SQLite.ExecuteSelectQuery(string.Format("select name as '이 름', amount as '금 액', date as '날 짜' from Offering_Mission where date = '{0}' order by no asc", dateTimePicker1.Value.ToShortDateString()));
                    _income_Mission.DataSource = ds.Tables[0];
                }

                for (int i = 0; i < _income_Mission.Columns.Count; i++)
                {
                    _income_Mission.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                // Set Sumation.
                int sum = 0;
                for (int i = 0; i < _income_Mission.RowCount - 1; i++)
                {
                    //Debug.WriteLine("Cell 0 : " + _income.Rows[0].Cells[0].Value);
                    if (_income_Mission.Rows[i].Cells[1].Value.ToString() != "")
                        sum += Convert.ToInt32(_income_Mission.Rows[i].Cells[1].Value);
                }
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
                    DataSet ds = SQLite.ExecuteSelectQuery(string.Format("select name as '이 름', amount as '금 액', date as '날 짜' from Offering_Rice where date = '{0}' order by no asc", DateTime.Now.ToShortDateString()));
                    _income_Rice.DataSource = ds.Tables[0];
                }
                else if (check == 2)
                {
                    DataSet ds = SQLite.ExecuteSelectQuery(string.Format("select name as '이 름', amount as '금 액', date as '날 짜' from Offering_Rice where date = '{0}' order by no asc", dateTimePicker1.Value.ToShortDateString()));
                    _income_Rice.DataSource = ds.Tables[0];
                }

                for (int i = 0; i < _income_Rice.Columns.Count; i++)
                {
                    _income_Rice.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                // Set Sumation.
                int sum = 0;
                for (int i = 0; i < _income_Rice.RowCount - 1; i++)
                {
                    //Debug.WriteLine("Cell 0 : " + _income.Rows[0].Cells[0].Value);
                    if (_income_Rice.Rows[i].Cells[1].Value.ToString() != "")
                        sum += Convert.ToInt32(_income_Rice.Rows[i].Cells[1].Value);
                }
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
                    DataSet ds = SQLite.ExecuteSelectQuery(string.Format("select name as '이 름', amount as '금 액', date as '날 짜' from Offering_Help where date = '{0}' order by no asc", DateTime.Now.ToShortDateString()));
                    _income_Help.DataSource = ds.Tables[0];
                }
                else if (check == 2)
                {
                    DataSet ds = SQLite.ExecuteSelectQuery(string.Format("select name as '이 름', amount as '금 액', date as '날 짜' from Offering_Help where date = '{0}' order by no asc", dateTimePicker1.Value.ToShortDateString()));
                    _income_Help.DataSource = ds.Tables[0];
                }

                for (int i = 0; i < _income_Help.Columns.Count; i++)
                {
                    _income_Help.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                // Set Sumation.
                int sum = 0;
                for (int i = 0; i < _income_Help.RowCount - 1; i++)
                {
                    //Debug.WriteLine("Cell 0 : " + _income.Rows[0].Cells[0].Value);
                    if (_income_Help.Rows[i].Cells[1].Value.ToString() != "")
                        sum += Convert.ToInt32(_income_Help.Rows[i].Cells[1].Value);
                }
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
                    DataSet ds = SQLite.ExecuteSelectQuery(string.Format("select name as '이 름', amount as '금 액', date as '날 짜' from Offering_Car where date = '{0}' order by no asc", DateTime.Now.ToShortDateString()));
                    _income_Car.DataSource = ds.Tables[0];
                }
                else if (check == 2)
                {
                    DataSet ds = SQLite.ExecuteSelectQuery(string.Format("select name as '이 름', amount as '금 액', date as '날 짜' from Offering_Car where date = '{0}' order by no asc", dateTimePicker1.Value.ToShortDateString()));
                    _income_Car.DataSource = ds.Tables[0];
                }

                for (int i = 0; i < _income_Car.Columns.Count; i++)
                {
                    _income_Car.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                // Set Sumation.
                int sum = 0;
                for (int i = 0; i < _income_Car.RowCount - 1; i++)
                {
                    //Debug.WriteLine("Cell 0 : " + _income.Rows[0].Cells[0].Value);
                    if (_income_Car.Rows[i].Cells[1].Value.ToString() != "")
                        sum += Convert.ToInt32(_income_Car.Rows[i].Cells[1].Value);
                }
                Sum_Help = sum;

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
                    DataSet ds = SQLite.ExecuteSelectQuery(string.Format("select name as '이 름', amount as '금 액', date as '날 짜' from Offering_Term where date = '{0}' order by no asc", DateTime.Now.ToShortDateString()));
                    _income_Term.DataSource = ds.Tables[0];
                }
                else if (check == 2)
                {
                    DataSet ds = SQLite.ExecuteSelectQuery(string.Format("select name as '이 름', amount as '금 액', date as '날 짜' from Offering_Term where date = '{0}' order by no asc", dateTimePicker1.Value.ToShortDateString()));
                    _income_Term.DataSource = ds.Tables[0];
                }

                for (int i = 0; i < _income_Term.Columns.Count; i++)
                {
                    _income_Term.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                // Set Sumation.
                int sum = 0;
                for (int i = 0; i < _income_Term.RowCount - 1; i++)
                {
                    //Debug.WriteLine("Cell 0 : " + _income.Rows[0].Cells[0].Value);
                    if (_income_Term.Rows[i].Cells[1].Value.ToString() != "")
                        sum += Convert.ToInt32(_income_Term.Rows[i].Cells[1].Value);
                }
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
                    DataSet ds = SQLite.ExecuteSelectQuery(string.Format("select name as '이 름', amount as '금 액', date as '날 짜' from Offering_Other where date = '{0}' order by no asc", DateTime.Now.ToShortDateString()));
                    _income_Other.DataSource = ds.Tables[0];
                }
                else if (check == 2)
                {
                    DataSet ds = SQLite.ExecuteSelectQuery(string.Format("select name as '이 름', amount as '금 액', date as '날 짜' from Offering_Other where date = '{0}' order by no asc", dateTimePicker1.Value.ToShortDateString()));
                    _income_Other.DataSource = ds.Tables[0];
                }

                for (int i = 0; i < _income_Other.Columns.Count; i++)
                {
                    _income_Other.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                // Set Sumation.
                int sum = 0;
                for (int i = 0; i < _income_Other.RowCount - 1; i++)
                {
                    //Debug.WriteLine("Cell 0 : " + _income.Rows[0].Cells[0].Value);
                    if (_income_Other.Rows[i].Cells[1].Value.ToString() != "")
                        sum += Convert.ToInt32(_income_Other.Rows[i].Cells[1].Value);
                }
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
                    DataSet ds = SQLite.ExecuteSelectQuery(string.Format("select name as '이 름', amount as '금 액', date as '날 짜' from Offering_Interest where date = '{0}' order by no asc", DateTime.Now.ToShortDateString()));
                    _income_Interest.DataSource = ds.Tables[0];
                }
                else if (check == 2)
                {
                    DataSet ds = SQLite.ExecuteSelectQuery(string.Format("select name as '이 름', amount as '금 액', date as '날 짜' from Offering_Interest where date = '{0}' order by no asc", dateTimePicker1.Value.ToShortDateString()));
                    _income_Interest.DataSource = ds.Tables[0];
                }

                for (int i = 0; i < _income_Interest.Columns.Count; i++)
                {
                    _income_Interest.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                // Set Sumation.
                int sum = 0;
                for (int i = 0; i < _income_Interest.RowCount - 1; i++)
                {
                    //Debug.WriteLine("Cell 0 : " + _income.Rows[0].Cells[0].Value);
                    if (_income_Interest.Rows[i].Cells[1].Value.ToString() != "")
                        sum += Convert.ToInt32(_income_Interest.Rows[i].Cells[1].Value);
                }
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
                String[] a = { "감사헌금", Sum_Thanks.ToString() };
                income.Rows.Add(a);

                // 십일조
                string[] b = {  "십일조", Sum_10.ToString() };
                income.Rows.Add(b);

                // 구역헌금
                string[] c = { "구역헌금", Sum_Cell.ToString() };
                income.Rows.Add(c);

                // 건축헌금
                string[] d = { "건축헌금", Sum_Archi.ToString() };
                income.Rows.Add(d);

                // 선교헌금
                string[] e = { "선교헌금", Sum_Mission.ToString() };
                income.Rows.Add(e);

                // 성미헌금
                string[] f = { "성미헌금", Sum_Rice.ToString() };
                income.Rows.Add(f);

                // 구제헌금
                string[] g = { "구제헌금", Sum_Help.ToString() };
                income.Rows.Add(g);

                // 차량헌금
                string[] h = { "차량헌금", Sum_Car.ToString() };
                income.Rows.Add(h);

                // 절기헌금
                string[] n = { "절기헌금", Sum_Term.ToString() };
                income.Rows.Add(n);

                // 기타헌금
                string[] k = { "기타수입", Sum_Other.ToString() };
                income.Rows.Add(k);

                // 이자수입
                string[] j = { "이자수입", Sum_Interest.ToString() };
                income.Rows.Add(j);


                // Total of Total
                int sumn = 0;
                for (int i = 0; i < income.RowCount-1; i++)
                {
                    //Debug.WriteLine("Cell 0 : " + income.Rows[0].Cells[1].Value);
                    if (income.Rows[i].Cells[1].Value.ToString() != "")
                        sumn += Convert.ToInt32(income.Rows[i].Cells[1].Value);
                }

                income_total.Rows[0].Cells[1].Value = sumn;
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
            if (currentWeekTab == W_IncomeTab)
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
                    SQLite.Execute(string.Format("insert into Offering_thanks (name, amount, date) values('{0}', {1}, '{2}')", _income_Thanks.Rows[i].Cells[0].Value, _income_Thanks.Rows[i].Cells[1].Value, ((DateTime)_income_Thanks.Rows[i].Cells[2].Value).ToShortDateString()));
                for (int i = 0; i < _income_10.RowCount - 1; i++)
                    SQLite.Execute(string.Format("insert into Offering_10 (name, amount, date) values('{0}', {1}, '{2}')", _income_10.Rows[i].Cells[0].Value, _income_10.Rows[i].Cells[1].Value, ((DateTime)_income_10.Rows[i].Cells[2].Value).ToShortDateString()));
                for (int i = 0; i < _income_Cell.RowCount - 1; i++)
                    SQLite.Execute(string.Format("insert into Offering_Cell (name, amount, date) values('{0}', {1}, '{2}')", _income_Cell.Rows[i].Cells[0].Value, _income_Cell.Rows[i].Cells[1].Value, ((DateTime)_income_Cell.Rows[i].Cells[2].Value).ToShortDateString()));
                for (int i = 0; i < _income_Archi.RowCount - 1; i++)
                    SQLite.Execute(string.Format("insert into Offering_Archi (name, amount, date) values('{0}', {1}, '{2}')", _income_Archi.Rows[i].Cells[0].Value, _income_Archi.Rows[i].Cells[1].Value, ((DateTime)_income_Archi.Rows[i].Cells[2].Value).ToShortDateString()));
                for (int i = 0; i < _income_Mission.RowCount - 1; i++)
                    SQLite.Execute(string.Format("insert into Offering_Mission (name, amount, date) values('{0}', {1}, '{2}')", _income_Mission.Rows[i].Cells[0].Value, _income_Mission.Rows[i].Cells[1].Value, ((DateTime)_income_Mission.Rows[i].Cells[2].Value).ToShortDateString()));
                for (int i = 0; i < _income_Rice.RowCount - 1; i++)
                    SQLite.Execute(string.Format("insert into Offering_Rice (name, amount, date) values('{0}', {1}, '{2}')", _income_Rice.Rows[i].Cells[0].Value, _income_Rice.Rows[i].Cells[1].Value, ((DateTime)_income_Rice.Rows[i].Cells[2].Value).ToShortDateString()));
                for (int i = 0; i < _income_Help.RowCount - 1; i++)
                    SQLite.Execute(string.Format("insert into Offering_Help (name, amount, date) values('{0}', {1}, '{2}')", _income_Help.Rows[i].Cells[0].Value, _income_Help.Rows[i].Cells[1].Value, ((DateTime)_income_Help.Rows[i].Cells[2].Value).ToShortDateString()));
                for (int i = 0; i < _income_Car.RowCount - 1; i++)
                    SQLite.Execute(string.Format("insert into Offering_Car (name, amount, date) values('{0}', {1}, '{2}')", _income_Car.Rows[i].Cells[0].Value, _income_Car.Rows[i].Cells[1].Value, ((DateTime)_income_Car.Rows[i].Cells[2].Value).ToShortDateString()));
                for (int i = 0; i < _income_Term.RowCount - 1; i++)
                    SQLite.Execute(string.Format("insert into Offering_Term (name, amount, date) values('{0}', {1}, '{2}')", _income_Term.Rows[i].Cells[0].Value, _income_Term.Rows[i].Cells[1].Value, ((DateTime)_income_Term.Rows[i].Cells[2].Value).ToShortDateString()));
                for (int i = 0; i < _income_Help.RowCount - 1; i++)
                    SQLite.Execute(string.Format("insert into Offering_Other (name, amount, date) values('{0}', {1}, '{2}')", _income_Other.Rows[i].Cells[0].Value, _income_Other.Rows[i].Cells[1].Value, ((DateTime)_income_Other.Rows[i].Cells[2].Value).ToShortDateString()));
                for (int i = 0; i < _income_Car.RowCount - 1; i++)
                    SQLite.Execute(string.Format("insert into Offering_Interest (name, amount, date) values('{0}', {1}, '{2}')", _income_Interest.Rows[i].Cells[0].Value, _income_Interest.Rows[i].Cells[1].Value, ((DateTime)_income_Interest.Rows[i].Cells[2].Value).ToShortDateString()));
            }
            else if (currentWeekTab == W_SpendingTab)
            {
                WSP.ButtonEvent();
            }

            ip.setIncomeFromDB();
            sp.setSpendFromDB();
            sp.setSpendFromDB();
            sp.setSpendFromDB();
        }
    }
}
