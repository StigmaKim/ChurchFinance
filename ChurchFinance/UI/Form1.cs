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

            setImgBtn();

            setTabPage();

        }
        

        private void setImgBtn()
        {
            imgBtnContainer1.BackColor = Color.Beige;

            // 첫번째 아이콘 추가
            ImageBtn weekBtn = new ImageBtn();
            weekBtn.img = new Bitmap(Environment.CurrentDirectory + "\\Image\\week.png");
            weekBtn.str = "주 단위 정산";
            imgBtnContainer1.InputBtn(weekBtn);

            // 두번째 아이콘 추가
            ImageBtn monthBtn = new ImageBtn();
            monthBtn.img = new Bitmap(Environment.CurrentDirectory + "\\Image\\month.png");
            monthBtn.str = "월 단위 정산";
            imgBtnContainer1.InputBtn(monthBtn);

            // 세번째 아이콘 추가
            ImageBtn yearBtn = new ImageBtn();
            yearBtn.img = new Bitmap(Environment.CurrentDirectory + "\\Image\\year.png");
            yearBtn.str = "년 단위 정산";
            imgBtnContainer1.InputBtn(yearBtn);

        }

        private void setTabPage()
        {
            NeoTabPage incomeTab = new NeoTabPage();
            NeoTabPage spendingTab = new NeoTabPage();

            incomeTab.Text = "수입";
            spendingTab.Text = "지출";

            neoTabWindow1.Controls.Add(incomeTab);
            neoTabWindow1.Controls.Add(spendingTab);

            DataGridView income = new DataGridView();

            income.Size = new Size(400, 200);
            income.Location = new Point(20, 20);

            incomeTab.Controls.Add(income);
        }

        
    }
}
