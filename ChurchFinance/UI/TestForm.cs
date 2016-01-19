using NeoTabControlLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace UI
{
    public partial class TestForm : Form
    {

        private NeoTabControlLibrary.NeoTabPage neoTabPage2;

        private PrintDocument printDoc;
        private PageSettings pgSettings;
        private PrinterSettings prtSetting;

        public TestForm()
        {
            InitializeComponent();

            printDoc = new PrintDocument();
            pgSettings = new PageSettings();
            prtSetting = new PrinterSettings();

            neoTabWindow1.Renderer = AddInRendererManager.LoadRenderer("MarginBlueRendererVS2");
            
            neoTabPage1.Text = "수 입";
            neoTabPage1.BackColor = Color.White;
            
        }

        // 인쇄 버튼
        private void button1_Click(object sender, EventArgs e)
        {
            printDoc.Print();
        }

        // 설정 버튼
        private void printSetBtn_Click(object sender, EventArgs e)
        {
            
        }

        // 미리보기 버튼
        private void preViewBtn_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog dig = new PrintPreviewDialog();
            dig.ShowDialog();

            //dig.Document = 
        }
    }
}

