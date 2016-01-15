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

            dateTimePicker1.Size = new Size(200, 200);

            panel1.BackColor = Color.Blue;

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
//            DataGridViewColumn testCol = new DataGridViewColumn();

  //          testCol.HeaderText = "Test";
    //        dataGridView1.Columns.Add(testCol);
        }

        private void dataGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(e.ColumnIndex + "/" + e.RowIndex);

            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}

