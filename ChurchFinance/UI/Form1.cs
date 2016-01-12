using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class Form1 : Form
    {

        Rectangle[] myTabRect = new Rectangle[2];
        Color SelectColor;
        Color etcTabColor;

        public Form1()
        {
            InitializeComponent();

            SelectColor = Color.LightCyan;
            etcTabColor = Color.LightGray;

            // OwnerDrawFixed모드를 설정해서 상위 Form에서 정의할 수 있도록 함
            tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;

            tabControl1.Dock = DockStyle.Fill;

            myTabRect[0] = tabControl1.GetTabRect(0);
            myTabRect[1] = tabControl1.GetTabRect(1);

            // Tab의 사이즈를 조절하려면 TabSizeMode.Fixed로 변경하고 조절해야함
            tabControl1.SizeMode = TabSizeMode.Fixed;
            tabControl1.ItemSize = new Size(100, 20);
                        
            tabPage1.BackColor = Color.White;
            tabPage2.BackColor = Color.White;

            tabPage1.BorderStyle = BorderStyle.None;

            tabControl1.DrawItem += new DrawItemEventHandler(OnDrawItem);
        }

        /// <summary>
        /// tabControl1을 Custom하게 그림
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnDrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;

            Rectangle SelectedItemRect = tabControl1.GetTabRect(e.Index);

            SolidBrush curTabBrush = new SolidBrush(SelectColor);
            SolidBrush etcTabBrush = new SolidBrush(etcTabColor);
            
            if (e.State == DrawItemState.Selected)
            {
                // 선택된 아이템
                g.FillRectangle(curTabBrush, SelectedItemRect);
            }
            else
            {
                // 선택되지 않은 아이템
                //g.FillRectangle(etcTabBrush, SelectedItemRect);
            }

            switch(e.Index)
            {
                case 0:
                    g.DrawString("수 입", e.Font, new SolidBrush(Color.Black), new Point(35, 5));

                    break;

                case 1:
                    g.DrawString("지 출", e.Font, new SolidBrush(Color.Black), new Point(135, 5));

                    break;

            }

        }
    }
}
