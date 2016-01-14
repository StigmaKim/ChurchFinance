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
    public partial class ImageBtn : UserControl
    {

        #region Variable

        // 이미지 관련 변수
        private Point imgLoc;
        private Size imgSz;
        public Bitmap img;

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


        public ImageBtn()
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
                    , new Size(Width / 2, Height / 2)
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

            Paint += ImageBtn_Paint;
            // MouseDown 이벤트
            MouseDown += ImageBtn_MouseDown;
            // MouseUp 이벤트
            MouseUp += ImageBtn_MouseUp;
            // MouseHover 이벤트 추가
            MouseHover += ImageBtn_MouseHover;
            // MouseLeave 이벤트 
            MouseLeave += ImageBtn_MouseLeave;
            // 사이즈 변경
            Resize += ImageBtn_Resize;
        }


        #region 그리기 함수

        private void ImageBtn_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            try
            {
                // 이미지 관련 작업
                Bitmap _img = new Bitmap(img, new Size((Width / 3) * 2, (Height / 3) * 2));
                imgSz = _img.Size;
                imgLoc = new Point((Width / 2) - (imgSz.Width / 2), Height / 15);

                // 문자열 관련 작업
                strFont = new Font(fontName, (float)(Height / 10),FontStyle.Bold);
                SizeF strSz = g.MeasureString(str, strFont);
                strLoc = new Point((int)((Width / 2) - (strSz.Width / 2)), imgLoc.Y + imgSz.Height);

                g.DrawImage(_img, imgLoc);

                g.DrawString(str, strFont, strBrush, strLoc);
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

        private void ImageBtn_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }


        private void ImageBtn_MouseDown(object sender, MouseEventArgs e)
        {

            BackColor = Color.LightBlue;
            borderPen.Color = Color.SkyBlue;
        }


        private void ImageBtn_MouseUp(object sender, MouseEventArgs e)
        {
            BackColor = Color.LightCyan;
            borderPen.Color = Color.Transparent;
        }

        private void ImageBtn_MouseHover(object sender, EventArgs e)
        {

            BackColor = Color.LightCyan;
            strBrush.Color = Color.Coral;
                        
        }

        private void ImageBtn_MouseLeave(object sender, EventArgs e)
        {

            BorderStyle = BorderStyle.None;
            BackColor = Color.Transparent;
            strBrush.Color = Color.Black;
        }

        #endregion
    }
}
