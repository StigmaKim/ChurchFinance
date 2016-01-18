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
    public partial class TitleBtn : UserControl
    {

        #region Variable

        // 이미지 관련 변수
        private Point imgLoc;
        private Size imgSz;
        private int cut;
        public Bitmap img;
        public String ImgName;

        // 배경색
        public Color backColor;

        // 문자 관련 변수
        private Point strLoc;
        private SolidBrush strBrush;
        public String str;
        public Font strFont;
        public String fontName;
        

        // 테두리 관련
        private Pen borderPen;
        public int margin;

        #endregion


        public TitleBtn()
        {
            InitializeComponent();

            // 이미지의 위치
            imgLoc = new Point(20, 20);

            // 문자의 위치
            strLoc = new Point(50, 50);

            // 이미지 로드
            try
            {
                img = new Bitmap(
                    Image.FromFile(Environment.CurrentDirectory + "\\Image\\iCalendar.png")
                    , new Size(Width, Height)
                    );
                
                imgSz = img.Size;
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }

            fontName = "맑은 고딕(제목)";

            strFont = new Font(fontName, 10f,FontStyle.Bold);
            strBrush = new SolidBrush(Color.Black);

            // 배경색 저장
            backColor = BackColor;

            str = "예시 문자열";

            borderPen = new Pen(Color.Transparent);
            margin = 2;

            cut = 0;

            Paint += ImageBtn_Paint;
            // MouseDown 이벤트
            MouseDown += ImageBtn_MouseDown;
        }


        #region 그리기 함수

        private void ImageBtn_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            try
            {
                // 이미지 관련 작업
                Bitmap _img = new Bitmap(img, new Size(this.Width - cut, this.Height - cut));
                imgSz = _img.Size;
                imgLoc = new Point(cut, cut);


                // 문자열 관련 작업
                strFont = new Font(fontName, (float)(Height / 10),FontStyle.Bold);
                SizeF strSz = g.MeasureString(str, strFont);
                strLoc = new Point((int)((Width / 2) - (strSz.Width / 2)), imgLoc.Y + imgSz.Height);

                g.DrawImage(_img, imgLoc);

                //g.DrawString(str, strFont, strBrush, strLoc);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

            
            // Border 그리기
            g.DrawLine(borderPen, new Point(margin, margin), new Point(margin, Height - margin));
            g.DrawLine(borderPen, new Point(margin, margin), new Point(Width - margin, margin));
            g.DrawLine(borderPen, new Point(Width - margin, margin), new Point(Width - margin, Height - margin));
            g.DrawLine(borderPen, new Point(margin, Height - margin), new Point(Width - margin, Height - margin));
            
        }

        #endregion

        #region 내부 이벤트들

        private void ImageBtn_MouseDown(object sender, MouseEventArgs e)
        {
            Invalidate();
        }
        #endregion
    }
}
