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
    public partial class SpendReport : UserControl
    {

        #region public 변수
        /// <summary>
        /// 전년도 이월액
        /// </summary>
        private int foreYearBalance;
        /// <summary>
        /// 수입
        /// </summary>
        private int income;
        /// <summary>
        /// 지출
        /// </summary>
        private int spend;
        /// <summary>
        /// 헌금
        /// </summary>
        private int offering;
        /// <summary>
        /// 재정 지출
        /// </summary>
        private int spending;
        /// <summary>
        /// 수입 이자
        /// </summary>
        private int incomeInterest;
        /// <summary>
        /// 대출 관련비
        /// </summary>
        private int loanEtc;
        /// <summary>
        /// 차월 이월액
        /// </summary>
        private int balance;
        /// <summary>
        /// 차랑 헌금
        /// </summary>
        private int carOffering;

        /// <summary>
        /// 날짜
        /// </summary>
        private DateTime date;

        #endregion

        #region get/set

        public int ForeYearBalance
        {
            get
            {
                return foreYearBalance;
            }

            set
            {
                Invalidate();
                foreYearBalance = value;
            }
        }

        public int Income
        {
            get
            {
                return income;
            }

            set
            {
                Invalidate();
                income = value;
                
            }
        }

        public int Spend
        {
            get
            {
                return spend;
            }

            set
            {
                spend = value;
                Invalidate();

            }
        }

        public int Offering
        {
            get
            {
                return offering;
            }

            set
            {
                offering = value;
                Invalidate();

            }
        }

        public int Spending
        {
            get
            {
                return spending;
            }

            set
            {
                spending = value;
                Invalidate();

            }
        }

        public int IncomeInterest
        {
            get
            {
                return incomeInterest;
            }

            set
            {
                incomeInterest = value;
                Invalidate();

            }
        }

        public int LoanEtc
        {
            get
            {
                return loanEtc;
            }

            set
            {
                loanEtc = value;
                Invalidate();

            }
        }

        public int Balance
        {
            get
            {
                return balance;
            }

            set
            {
                balance = value;
                Invalidate();

            }
        }

        public int CarOffering
        {
            get
            {
                return carOffering;
            }

            set
            {
                carOffering = value;
                Invalidate();

            }
        }

        public DateTime Date
        {
            get
            {
                return date;
            }

            set
            {
                date = value;
                Invalidate();

            }
        }

        #endregion
        
        public SpendReport()
        {
            InitializeComponent();

            // 예시 데이터 입력
            foreYearBalance = 4599710;
            income = 15718000;
            spend = 17837890;
            offering = 15718000;
            spending = 16937480;
            incomeInterest = 0;
            loanEtc = 900410;
            carOffering = 80000;
            date = DateTime.Now;

            
            // 차월 이월액
            balance = foreYearBalance - (spend - income);

            /*
            Title.Text = Date.Year + "년 " + Date.Month + "월 재정 보고";
            
            setForeYearBalance();

            inputInputSpendData();
            */
            Paint += SpendReport_Paint;
        }

        private void SpendReport_Paint(object sender, PaintEventArgs e)
        {

            Title.Text = Date.Year + "년 " + Date.Month + "월 재정 보고";

            setForeYearBalance();

            inputInputSpendData();
        }

        /// <summary>
        /// 전년도 이월액 부분을 셋팅합니다.
        /// </summary>
        private void setForeYearBalance()
        {
            // 전년도 이월액 설정
            foreYearBalanceView.ColumnCount = 2;

            for (int i = 0; i < foreYearBalanceView.Columns.Count; i++)
                foreYearBalanceView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            foreYearBalanceView.ColumnHeadersVisible = false;
            foreYearBalanceView.ReadOnly = true;
            foreYearBalanceView.RowCount = 1;

            foreYearBalanceView.Rows[0].Cells[0].Value = "전년도 이월액";
            foreYearBalanceView.Rows[0].Cells[1].Value = ForeYearBalance.ToString("n0") + " 원";
            foreYearBalanceView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            foreYearBalanceView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

        }

        /// <summary>
        /// 수입 지출 GridView를 설정합니다.
        /// </summary>
        private void inputInputSpendData()
        {
            balance = foreYearBalance - (spend - income);

            // 수입 지출 DatagridView 설정
            incomeSpendView.ColumnCount = 6;
            incomeSpendView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            incomeSpendView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            for (int i = 0; i < incomeSpendView.Columns.Count; i++)
                incomeSpendView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            incomeSpendView.ColumnHeadersVisible = false;
            incomeSpendView.ReadOnly = true;
            incomeSpendView.RowCount = 6;

            // 첫번째 줄
            incomeSpendView.Rows[0].Cells[0].Value = "수입";
            incomeSpendView.Rows[0].Cells[2].Value = Income.ToString("n0") + " 원";
            incomeSpendView.Rows[0].Cells[3].Value = "지출";
            incomeSpendView.Rows[0].Cells[5].Value = Spend.ToString("n0") + " 원";
            // 두번째 줄
            incomeSpendView.Rows[1].Cells[1].Value = "헌금";
            incomeSpendView.Rows[1].Cells[2].Value = Offering.ToString("n0") + " 원";
            incomeSpendView.Rows[1].Cells[4].Value = "재정 지출";
            incomeSpendView.Rows[1].Cells[5].Value = Spending.ToString("n0") + " 원";
            // 세번째 줄
            incomeSpendView.Rows[2].Cells[1].Value = "수입이자";
            incomeSpendView.Rows[2].Cells[2].Value = IncomeInterest.ToString("n0") + " 원";
            incomeSpendView.Rows[2].Cells[4].Value = "대출 관련비";
            incomeSpendView.Rows[2].Cells[5].Value = LoanEtc.ToString("n0") + " 원";
            // 네번째 줄
            incomeSpendView.Rows[4].Cells[4].Value = "차월 이월액";
            incomeSpendView.Rows[4].Cells[5].Value = Balance.ToString("n0") + " 원";
            // 다섯번째 줄
            incomeSpendView.Rows[5].Cells[4].Value = "차랑 헌금";
            incomeSpendView.Rows[5].Cells[5].Value = CarOffering.ToString("n0") + " 원";

        }
    }
}
