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

namespace UI
{
    public partial class TestForm : Form
    {

        private NeoTabControlLibrary.NeoTabPage neoTabPage2;
        private IncomeProgress ip;

        public TestForm()
        {
            InitializeComponent();

            neoTabWindow1.Renderer = AddInRendererManager.LoadRenderer("MarginBlueRendererVS2");
            
            neoTabPage1.Text = "수 입";
            neoTabPage1.BackColor = Color.White;
        }
        
    }
}

