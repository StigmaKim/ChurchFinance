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
    public partial class SpendReportPanel : UserControl
    {

        // 전년도 이월액
        public int foreYearBalance;
        // 수입액
        public int income;
        // 수입 이자
        public int incomePlus;
        // 헌금
        public int offering;
        // 지출액
        public int spending;
        // 재정 지출
        public int normalSpending;
        // 대출관련 비용
        public int loan;
        // 차월 이월액
        public int foreMonthBalance;
        // 차량 헌금
        public int carOffering;
        // 재정보고 날짜
        public DateTime date;

        // 테두리 관련 변수
        private Pen linePen;
        private int margin;

        // 사이즈
        private SizeF bodyStrSz;
        

        public SpendReportPanel()
        {
            InitializeComponent();

            // 라인 색 지정
            linePen = new Pen(new SolidBrush(Color.Black));
            margin = 5;

            // 현재 날짜
            date = DateTime.Now;
                        
            // Paint 이벤트
            Paint += SpendViewPanel_Paint;

            foreYearBalance = 4599710;
            income = 15718000;
            spending = 17837800;
            offering = 17837800;
            normalSpending = 16937480;
            incomePlus = 0;
            loan = 900410;

            bodyStrSz = new SizeF(Width, 30);
        }

        /// <summary>
        /// Paint
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SpendViewPanel_Paint(object sender, PaintEventArgs e)
        {
            // Grapihs
            Graphics g = e.Graphics;

            int curPoint = 0;

            // 전체 테두리 그리기
            g.DrawLine(linePen, new Point(margin, margin), new Point((Width - margin), margin));
            g.DrawLine(linePen, new Point(margin, margin), new Point(margin, Height - margin));
            g.DrawLine(linePen, new Point((Width - margin), margin), new Point((Width - margin), (Height - margin)));
            g.DrawLine(linePen, new Point(margin, Height - margin), new Point((Width - margin), Height - margin));

            // 큰 제목 그리기
            StringFormat format = new StringFormat();
            format.LineAlignment = StringAlignment.Center;
            format.Alignment = StringAlignment.Center;
            g.DrawString(
                date.Year + "년도 " + date.Month + "월 재정 보고서",
                new Font("맑은 고딕", 24f),
                new SolidBrush(Color.Black),
                new RectangleF(new PointF(margin,margin),new SizeF(Width, 60)),
                format);

            curPoint += 150;

            // 전년도 이월액 문자 그리기
            g.DrawRectangle(linePen,
                new Rectangle(new Point((int)(margin * 4), (margin + curPoint)), new Size((int)bodyStrSz.Width / 2, (int)bodyStrSz.Height)));
            g.DrawRectangle(linePen,
                new Rectangle(new Point((int)(bodyStrSz.Width / 2) + (margin * 4), (margin + curPoint)), new Size((int)bodyStrSz.Width / 2, (int)bodyStrSz.Height)));
            format.LineAlignment = StringAlignment.Far;
            format.Alignment = StringAlignment.Far;
            g.DrawString(
                "전년도 이월액",
                new Font("바탕", 12f),
                new SolidBrush(Color.Black),
                new RectangleF(new PointF((margin * 4), (margin + curPoint)), new Size((int)bodyStrSz.Width / 2, (int)bodyStrSz.Height)),
                format);
            g.DrawString(
                foreYearBalance.ToString("n0") + "원",
                new Font("바탕", 12f),
                new SolidBrush(Color.Black),
                new RectangleF(new PointF((bodyStrSz.Width / 2) + (margin * 4), (margin + curPoint)), new Size((int)bodyStrSz.Width / 2, (int)bodyStrSz.Height)),
                format);

            curPoint += 50;

            // 수입액 문자 그리기
            g.DrawRectangle(linePen,
                new Rectangle(new Point((int)(margin * 4), (margin + curPoint)), new Size((int)bodyStrSz.Width / 2, (int)bodyStrSz.Height)));
            g.DrawString(
                "수입액 : " + income.ToString("n0") + "원",
                new Font("바탕", 12f),
                new SolidBrush(Color.Black),
                new RectangleF(new PointF((margin * 4), (margin + curPoint)), new SizeF(bodyStrSz.Width / 2, bodyStrSz.Height)),
                format);

            // 지출액 문자 그리기
            g.DrawRectangle(linePen,
                new Rectangle(new Point((int)(bodyStrSz.Width / 2) + (margin * 4), (margin + curPoint)), new Size((int)bodyStrSz.Width / 2, (int)bodyStrSz.Height)));
            g.DrawString(
                "지출액 : " + spending.ToString("n0") + "원",
                new Font("바탕", 12f),
                new SolidBrush(Color.Black),
                new RectangleF(new PointF((bodyStrSz.Width / 2) + (margin * 4), (margin + curPoint)), new SizeF(bodyStrSz.Width / 2, bodyStrSz.Height)),
                format);

            curPoint += 30;

            // 헌금 문자 그리기
            g.DrawRectangle(linePen,
                new Rectangle(new Point((int)(margin * 4), (margin + curPoint)), new Size((int)bodyStrSz.Width / 2, (int)bodyStrSz.Height)));
            format.LineAlignment = StringAlignment.Far;
            format.Alignment = StringAlignment.Far;
            g.DrawString(
                "헌금 : " + offering.ToString("n0") + "원",
                new Font("바탕", 12f),
                new SolidBrush(Color.Black),
                new RectangleF(new PointF((margin * 4), (margin + curPoint)), new SizeF(bodyStrSz.Width / 2, bodyStrSz.Height)),
                format);

            // 지출액 상세
            g.DrawRectangle(linePen,
                new Rectangle(new Point((int)(bodyStrSz.Width / 2) + (margin * 4), (margin + curPoint)), new Size((int)bodyStrSz.Width / 2, (int)bodyStrSz.Height)));
            g.DrawString(
                "재정 지출 : " + normalSpending.ToString("n0") + "원",
                new Font("바탕", 12f),
                new SolidBrush(Color.Black),
                new RectangleF(new PointF((bodyStrSz.Width / 2) + (margin * 4), (margin + curPoint)), new SizeF(bodyStrSz.Width / 2, bodyStrSz.Height)),
                format);

            curPoint += 30;

            // 수입이자
            g.DrawRectangle(linePen,
                new Rectangle(new Point((int)(margin * 4), (margin + curPoint)), new Size((int)bodyStrSz.Width / 2, (int)bodyStrSz.Height)));
            g.DrawString(
                "수입 이자 : " + incomePlus.ToString("n0") + "원",
                new Font("바탕", 12f),
                new SolidBrush(Color.Black),
                new RectangleF(new PointF((margin * 4), (margin + curPoint)), new SizeF(bodyStrSz.Width / 2, bodyStrSz.Height)),
                format);

            // 대출 관련비
            g.DrawRectangle(linePen,
                new Rectangle(new Point((int)(bodyStrSz.Width / 2) + (margin * 4), (margin + curPoint)), new Size((int)bodyStrSz.Width / 2, (int)bodyStrSz.Height)));
            g.DrawString(
                "대출 관련비 : " + loan.ToString("n0") + "원",
                new Font("바탕", 12f),
                new SolidBrush(Color.Black),
                new RectangleF(new PointF((bodyStrSz.Width / 2) + (margin * 4), (margin + curPoint)), new SizeF(bodyStrSz.Width / 2, bodyStrSz.Height)),
                format);

        }

        private void SpendReportPanel_Load(object sender, EventArgs e)
        {
            
        }
    }
}
