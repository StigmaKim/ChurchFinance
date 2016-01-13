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

        public TestForm()
        {
            InitializeComponent();

            neoTabWindow1.Renderer = NeoTabControlLibrary.AddInRendererManager.LoadRenderer("MarginBlueRendererVS2");

            neoTabPage2 = new NeoTabControlLibrary.NeoTabPage();

            neoTabPage2.BackColor = System.Drawing.Color.Transparent;
            neoTabPage2.Name = "neoTabPage2";
            neoTabPage2.Text = "neoTabPage2";
            neoTabPage2.ToolTipText = "neoTabPage2";

            neoTabWindow1.Controls.Add(neoTabPage2);
        }
    }
}
