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
        DataGridView _income = null;

        // DB 관련 
        SQLite SQLite = null ;
        SQLiteCommand cmd = null;

        // Week Tab
        NeoTabPage W_IncomeTab;
        NeoTabPage W_SpendingTab;

        // Month Tab
        NeoTabPage M_IncomeTab;
        NeoTabPage M_SpendingTab;

        // Year Tab
        NeoTabPage Y_IncomeTab;
        NeoTabPage Y_SpendingTab;


        public Form1()
        {
            InitializeComponent();
            SQLite = new SQLite(); // DB Object
            cmd = SQLite.GetSQLCommand(); // Command Object

            neoTabWindow1.Renderer = NeoTabControlLibrary.AddInRendererManager.LoadRenderer("MarginBlueRendererVS2");
            neoTabWindow1.BackColor = Color.White;

            setImgBtn();
            setWeekTabPage();
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

        }

        #region 클릭 이벤트

        /// <summary>
        /// Year 버튼 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void YearBtn_Click(object sender, EventArgs e)
        {
            neoTabWindow1.Controls.Clear();
        }

        /// <summary>
        /// Month 버튼 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MonthBtn_Click(object sender, EventArgs e)
        {
            neoTabWindow1.Controls.Clear();
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

            AddGridView();
            SetInputSumDGV(); // 최초 DGV 그리기. ( 수입 SUM )
            SetThanksDGV(); // 최초 DGV 그리기. ( 감사헌금 )
        }

        private void AddGridView()
        {
            #region 수입 탭 GridView 설정

            income = new DataGridView();
            _income = new DataGridView();

            income.Size = new Size(300, 400);
            income.Location = new Point(20, 20);
            income.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            income.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            income.ColumnCount = 2;

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
            _income.Size = new Size(700, 400);
            _income.Location = new Point(350, 20);
            _income.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _income.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //_income.ColumnCount = 3;

            for (int i = 0; i < income.Columns.Count; i++)
            {
                income.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            W_IncomeTab.Controls.Add(income);
            W_IncomeTab.Controls.Add(_income);

            #endregion
        }

        private void SetThanksDGV()
        {
            try
            {
                SQLite.ConnectToDB();

                SQLite.Execute(string.Format("create table Offering_Thanks " + 
                    "(no Integer primary key autoincrement, date DATE, name varchar(40), amount int)"));
                
                cmd.CommandText = string.Format("select name as '이름', amount as '금 액', date as '날 짜' from Offering_Thanks order by no asc");
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                _income.DataSource = ds.Tables[0];

                for(int i = 0; i< _income.Columns.Count; i++)
                {
                    _income.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                                

                SQLite.CloseDB();
            }
            catch(SQLiteException e)
            {
                SQLite.CloseDB();
                Debug.WriteLine(e);
            }   
        }

        private void SetInputSumDGV()
        {
            try
            {
                SQLite.ConnectToDB();
                cmd = SQLite.GetSQLCommand();
                cmd.CommandText = string.Format("select sum(amount) from Offering_Thanks");
                object sum = cmd.ExecuteScalar();
                income.Rows[0].Cells[0].Value = "감사헌금";
                income.Rows[0].Cells[1].Value = sum;

                SQLite.CloseDB();
            }
            catch( SQLiteException e)
            {
                SQLite.CloseDB();
                Debug.WriteLine(e);
            }

        }

    }
}
