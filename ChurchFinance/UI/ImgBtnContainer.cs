using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class ImgBtnContainer : UserControl
    {
        
        private Point curPoint;
        private int xLoc;
        private int yLoc;

        public int margin;
        
        public ImgBtnContainer()
        {
            InitializeComponent();

            margin = 5;

            xLoc = 5;
            yLoc = 5;

            curPoint = new Point(xLoc, yLoc);

        }

        /// <summary>
        /// ImgBtn을 추가합니다.
        /// </summary>
        public void InputBtn(ImageBtn btn)
        {
            btn.Size = new Size(Height - (margin * 2), Height - (margin * 2));
            btn.Location = new Point(curPoint.X,curPoint.Y);

            Controls.Add(btn);

            xLoc += (margin + btn.Size.Width);
            curPoint = new Point(xLoc, yLoc);

        }
    }
}
