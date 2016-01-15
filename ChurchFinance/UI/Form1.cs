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


namespace UI
{
    public partial class Form1 : Form
    {
        // DB 관련 
        SQLite SQLite;

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

            neoTabWindow1.Renderer = NeoTabControlLibrary.AddInRendererManager.LoadRenderer("MarginBlueRendererVS2");
            neoTabWindow1.BackColor = Color.White;

            setImgBtn();
            
            setTabPage();
            
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

        }

        #endregion 

        private void setTabPage()
        {
            W_IncomeTab = new NeoTabPage();
            W_SpendingTab = new NeoTabPage();

            W_IncomeTab.Text = "수 입";
            W_IncomeTab.BackColor = Color.White;
            W_SpendingTab.Text = "지 출";
            W_SpendingTab.BackColor = Color.White;

            neoTabWindow1.Controls.Add(W_IncomeTab);
            neoTabWindow1.Controls.Add(W_SpendingTab);

            AddGridView();
        }

        private void AddGridView()
        {
            #region 수입 탭 GridView 설정

            DataGridView income = new DataGridView();
            DataGridView _income = new DataGridView();

            income.Size = new Size(400, 400);
            income.Location = new Point(20, 20);

            income.ColumnCount = 2;

            income.Columns[0].Name = "수입";
            income.Columns[1].Name = "금액";

            String[] rows = { "십일조", "4,300,200원" };
            income.Rows.Add(rows);

            _income.Size = new Size(400, 400);
            _income.Location = new Point(450, 20);

            W_IncomeTab.Controls.Add(income);
            W_IncomeTab.Controls.Add(_income);

            #endregion
        }

    }
}
