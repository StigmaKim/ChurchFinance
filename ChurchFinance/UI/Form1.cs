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

        public Form1()
        {
            InitializeComponent();

            neoTabWindow1.Renderer = NeoTabControlLibrary.AddInRendererManager.LoadRenderer("MarginBlueRendererVS2");
            neoTabWindow1.BackColor = Color.White;

            setImgBtn();

            setTabPage();

            AddGridView();


        }
        

        private void setImgBtn()
        {

            // 첫번째 아이콘 추가
            ImageBtn weekBtn = new ImageBtn();
            weekBtn.img = new Bitmap(Environment.CurrentDirectory + "\\Image\\Week.png");
            weekBtn.ImgName = "Week";
            weekBtn.str = "주 단위 정산";
            imgBtnContainer1.InputBtn(weekBtn);

            // 두번째 아이콘 추가
            ImageBtn monthBtn = new ImageBtn();
            monthBtn.img = new Bitmap(Environment.CurrentDirectory + "\\Image\\Month.png");
            monthBtn.ImgName = "Month";
            monthBtn.str = "월 단위 정산";
            imgBtnContainer1.InputBtn(monthBtn);

            // 세번째 아이콘 추가
            ImageBtn yearBtn = new ImageBtn();
            yearBtn.img = new Bitmap(Environment.CurrentDirectory + "\\Image\\Year.png");
            yearBtn.ImgName = "Year";
            yearBtn.str = "년 단위 정산";
            imgBtnContainer1.InputBtn(yearBtn);

        }

        private void setTabPage()
        {
            NeoTabPage incomeTab = new NeoTabPage();
            NeoTabPage spendingTab = new NeoTabPage();

            incomeTab.Text = "수 입";
            incomeTab.BackColor = Color.White;
            spendingTab.Text = "지 출";
            spendingTab.BackColor = Color.White;

            neoTabWindow1.Controls.Add(incomeTab);
            neoTabWindow1.Controls.Add(spendingTab);
        }

        private void AddGridView()
        {
            DataGridView income = new DataGridView();
            DataGridView _income = new DataGridView();

            income.Size = new Size(400, 400);
            income.Location = new Point(20, 20);
            

            _income.Size = new Size(400, 400);
            _income.Location = new Point(450, 20);

            neoTabWindow1.Controls[0].Controls.Add(income);
            neoTabWindow1.Controls[0].Controls.Add(_income);

        }

    }
}
