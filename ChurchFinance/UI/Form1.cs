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
        DataGridView income_total = null;
        DataGridView _income_total = null;
        int dgvcnt = 0;

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
            setInitialTotal();

            panel5.BackColor = Color.LightGray;
            panel2.BackColor = Color.LightGray;
            
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

        private void setInitialTotal()
        {
            int sum = 0;
            for (int i = 0; i < _income.RowCount - 1; i++)
            {
                Debug.WriteLine("Cell 0 : " + _income.Rows[0].Cells[0].Value);
                if (_income.Rows[i].Cells[1].Value.ToString() != "")
                    sum += (int)_income.Rows[i].Cells[1].Value;
            }

            _income_total.Rows[0].Cells[1].Value = sum;
        }
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
            income_total = new DataGridView();
            _income_total = new DataGridView();


            _income.CellEndEdit += _income_CellEndEdit;

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

            // _income ----------------------------------
            _income.Size = new Size(600, 400);
            _income.Location = new Point(350, 20);
            _income.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _income.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //_income.ColumnCount = 3;

            for (int i = 0; i < income.Columns.Count; i++)
            {
                income.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

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

            
            // Draw DGVS --------------------------------------------------

            W_IncomeTab.Controls.Add(income);
            W_IncomeTab.Controls.Add(_income);
            W_IncomeTab.Controls.Add(income_total);
            W_IncomeTab.Controls.Add(_income_total);

            #endregion
        }

        private void _income_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int sum = 0;

            for (int i = 0; i < _income.RowCount - 1; i++)
            {
                //Debug.WriteLine("Cell 0 : " + _income.Rows[0].Cells[0].Value);
                if (_income.Rows[i].Cells[1].Value.ToString() != "")
                    sum += (int)_income.Rows[i].Cells[1].Value;
            }

            _income_total.Rows[0].Cells[1].Value = sum;
        }

        private void SetThanksDGV()
        {
            try
            {
                SQLite.ConnectToDB();

                SQLite.Execute(string.Format("create table Offering_Thanks " + 
                    "(no Integer primary key autoincrement, date varchar(40), name varchar(40), amount int)"));

                DataSet ds = SQLite.ExecuteSelectQuery(string.Format("select name as '이름', amount as '금 액', date as '날 짜' from Offering_Thanks order by no asc"));
                _income.DataSource = ds.Tables[0];

                for (int i = 0; i< _income.Columns.Count; i++)
                {
                    _income.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                dgvcnt = _income.Rows.Count; // dgvcnt Setting!!!!!!!!!!!!!!
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
                // 감사헌금
                SQLite.ConnectToDB();
                cmd = SQLite.GetSQLCommand();
                cmd.CommandText = string.Format("select sum(amount) from Offering_Thanks");
                object sum = cmd.ExecuteScalar();
                income.Rows[0].Cells[0].Value = "감사헌금";
                income.Rows[0].Cells[1].Value = sum;
                





                // Total of Total
                int sumn = 0;
                for (int i = 0; i < income.RowCount; i++)
                {
                    Debug.WriteLine("Cell 0 : " + income.Rows[0].Cells[1].Value);
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

       
        private void button1_Click(object sender, EventArgs e)
        {
            
            SQLite.Execute(string.Format("Delete From Offering_thanks"));
            
            Debug.WriteLine("Check value : " + _income.RowCount);
            Debug.WriteLine("Check value : " + _income.Rows[0].Cells[0].Value);
            for (int i = 0; i < _income.RowCount-1 ; i ++)
            {
                // cell 0 - name, 1 - amount, 2- date
                SQLite.Execute(string.Format("insert into Offering_thanks (name, amount, date) values('{0}', {1}, '{2}')", _income.Rows[i].Cells[0].Value, _income.Rows[i].Cells[1].Value, _income.Rows[i].Cells[2].Value)); 
            }

            /*
            int i = 0;
            try {
                for (; i < dgvcnt; i++)
                {
                    cmd.CommandText = string.Format("update Offering_Thanks set name = '{0}', amount = {1} where no = {2}", _income.Rows[i].Cells[0].Value, _income.Rows[i].Cells[1].Value, i + 1);
                    cmd.ExecuteNonQuery();
                }
                i--;
                for (; i < _income.Rows.Count - 1; i++)
                {
                    cmd.CommandText = string.Format("Insert into Offering_Thanks (name, amount) values('{0}', {1})", _income.Rows[i].Cells[0].Value, _income.Rows[i].Cells[1].Value);
                    cmd.ExecuteNonQuery();
                }

                DataSet ds = SQLite.ExecuteSelectQuery(string.Format("select name as '이름', amount as '금 액', date as '날 짜' from Offering_Thanks order by no asc"));
                _income.DataSource = ds.Tables[0];
            }
            catch( SQLiteException err)
            {
                SQLite.CloseDB();
                Debug.WriteLine(err);
            }
            */

        }
    }
}
