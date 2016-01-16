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
    public partial class IncomeProgress : UserControl
    {

        #region 예산 변수

        #region 수입 예산 변수

        /// <summary>
        /// 주일 헌금 예산
        /// </summary>
        private int budgetWeekOffering;
        /// <summary>
        /// 십일조 헌금 예산
        /// </summary>
        private int budgetSipil;
        /// <summary>
        /// 감사 헌금 예산
        /// </summary>
        private int budgetThanksOffering;
        /// <summary>
        /// 선교 헌금 예산
        /// </summary>
        private int budgetMissionWork;
        /// <summary>
        /// 구역헌금 예산
        /// </summary>
        private int budgetRegion;
        /// <summary>
        /// 특별헌금 예산
        /// </summary>
        private int budgetSpecial;
        /// <summary>
        /// 절기헌금 예산
        /// </summary>
        private int budgetSeason;

        /// <summary>
        /// 예산 합
        /// </summary>
        private int budgetSum;

        #endregion

        #region 지출 예산 변수

        /// <summary>
        /// 예배비 예산
        /// </summary>
        private int budgetPray;
        /// <summary>
        /// 선교비 예산
        /// </summary>
        private int budgetSpendMission;
        /// <summary>
        /// 교육비 예산
        /// </summary>
        private int budgetEdu;
        /// <summary>
        /// 인건비 예산
        /// </summary>
        private int budgetPerson;
        /// <summary>
        /// 봉사비 예산
        /// </summary>
        private int budgetService;
        /// <summary>
        /// 운영관리비 예산
        /// </summary>
        private int budgetManage;
        /// <summary>
        /// 대출 관련비 예산
        /// </summary>
        private int budgetLoan;
        /// <summary>
        /// 예비비 예산
        /// </summary>
        private int budgetPrepare;

        /// <summary>
        /// 합계
        /// </summary>
        private int budgetSpendSum;
        #endregion

        #endregion

        #region 월 수입 지출 변수

        #region 수입 관련 변수
        /// <summary>
        /// 주일 헌금
        /// </summary>
        private int week;
        /// <summary>
        /// 십일조 헌금
        /// </summary>
        private int sipil;
        /// <summary>
        /// 감사 헌금
        /// </summary>
        private int thanks;
        /// <summary>
        /// 선교 헌금
        /// </summary>
        private int missionWork;
        /// <summary>
        /// 구역 헌금
        /// </summary>
        private int region;
        /// <summary>
        /// 특별 헌금
        /// </summary>
        private int special;
        /// <summary>
        /// 절기 헌금
        /// </summary>
        private int season;
        /// <summary>
        /// 차량 헌금
        /// </summary>
        private int carOffering;
        /// <summary>
        /// 수입 이자
        /// </summary>
        private int incomeInterest;

        /// <summary>
        /// 합계
        /// </summary>
        private int sum;

        #endregion 

        #region 지출 변수

        /// <summary>
        /// 예배비
        /// </summary>
        private int pray;
        /// <summary>
        /// 선교비
        /// </summary>
        private int spendMission;
        /// <summary>
        /// 교육비
        /// </summary>
        private int edu;
        /// <summary>
        /// 인건비
        /// </summary>
        private int person;
        /// <summary>
        /// 봉사비
        /// </summary>
        private int service;
        /// <summary>
        /// 운영 관리비
        /// </summary>
        private int manage;
        /// <summary>
        /// 대출 관리비
        /// </summary>
        private int loan;
        /// <summary>
        ///  예비비
        /// </summary>
        private int prepare;

        /// <summary>
        /// 합계
        /// </summary>
        private int spendSum;
        #endregion

        #endregion

        #region 기타 변수

        /// <summary>
        /// 날짜
        /// </summary>
        private DateTime date;
        public DMode mode;
        #endregion

        #region get/set

        public int BudgetWeekOffering
        {
            get
            {
                return budgetWeekOffering;
            }

            set
            {
                budgetWeekOffering = value;
            }
        }

        public int BudgetSipil
        {
            get
            {
                return budgetSipil;
            }

            set
            {
                budgetSipil = value;
            }
        }

        public int BudgetThanksOffering
        {
            get
            {
                return budgetThanksOffering;
            }

            set
            {
                budgetThanksOffering = value;
            }
        }

        public int BudgetMissionWork
        {
            get
            {
                return budgetMissionWork;
            }

            set
            {
                budgetMissionWork = value;
            }
        }

        public int BudgetRegion
        {
            get
            {
                return budgetRegion;
            }

            set
            {
                budgetRegion = value;
            }
        }

        public int Week
        {
            get
            {
                return week;
            }

            set
            {
                week = value;
            }
        }

        public int Sipil
        {
            get
            {
                return sipil;
            }

            set
            {
                sipil = value;
            }
        }

        public int Thanks
        {
            get
            {
                return thanks;
            }

            set
            {
                thanks = value;
            }
        }

        public int MissionWork
        {
            get
            {
                return missionWork;
            }

            set
            {
                missionWork = value;
            }
        }

        public int Region1
        {
            get
            {
                return region;
            }

            set
            {
                region = value;
            }
        }

        public int Special
        {
            get
            {
                return special;
            }

            set
            {
                special = value;
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
            }
        }

        public int Season
        {
            get
            {
                return season;
            }

            set
            {
                season = value;
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
            }
        }

        public int BudgetPray
        {
            get
            {
                return budgetPray;
            }

            set
            {
                budgetPray = value;
            }
        }

        public int BudgetSpendMission
        {
            get
            {
                return budgetSpendMission;
            }

            set
            {
                budgetSpendMission = value;
            }
        }

        public int BudgetEdu
        {
            get
            {
                return budgetEdu;
            }

            set
            {
                budgetEdu = value;
            }
        }

        public int Pray
        {
            get
            {
                return pray;
            }

            set
            {
                pray = value;
            }
        }

        public int SpendMission
        {
            get
            {
                return spendMission;
            }

            set
            {
                spendMission = value;
            }
        }

        #endregion

        public enum DMode
        {
            income,
            spend
        };

        /// <summary>
        /// 생성자
        /// </summary>
        public IncomeProgress(DMode drawMode)
        {
            InitializeComponent();

            mode = drawMode;

            Paint += IncomeProgress_Paint;

            #region 예시 데이터 입력 (실제 사용시에는 제거)

            date = DateTime.Now;
                        
            // 예산 데이터 입력
            budgetWeekOffering = 7000000;
            budgetSipil = 95000000;
            budgetThanksOffering = 30000000;
            budgetMissionWork = 6000000;
            budgetRegion = 6000000;
            budgetSpecial = 12000000;
            budgetSeason = 6000000;

            // 진행 데이터 입력
            week = 327000;
            sipil = 4411000;
            thanks = 1615000;
            missionWork = 260000;
            region = 40000;
            special = 7745000;
            season = 1320000;
            incomeInterest = 0;
            carOffering = 80000;

            // 지출 예산 데이터 입력
            budgetPray = 2900000;
            budgetSpendMission = 8700000;
            budgetEdu = 13200000;
            budgetPerson = 43800000;
            budgetService = 9200000;
            budgetManage = 66620000;
            budgetLoan = 20000000;
            budgetPrepare = 11453000;

            // 지출 진행 데이터 입력
            pray = 200000;
            spendMission = 660000;
            edu = 1050500;
            person = 3500000;
            service = 112500;
            manage = 3303980;
            loan = 900410;
            prepare = 900410;

            #endregion

            budgetSpendSum = budgetPray + budgetSpendMission + budgetEdu + budgetPerson + budgetService + budgetManage + budgetLoan + budgetPrepare;
            spendSum = pray + spendMission + edu + person + manage + prepare;

            budgetSum = budgetWeekOffering + budgetSipil + budgetThanksOffering + budgetMissionWork + budgetRegion + budgetSpecial + budgetSeason;
            sum = week + sipil + thanks + missionWork + region + special + season;

            
            if (mode == DMode.income)
            {
                title.Text = date.Year + "년 " + date.Month + "월 재정 수입 명세서";
                setViews();
            }
            else if(mode == DMode.spend)
            {
                title.Text = date.Year + "년 " + date.Month + "월 재정 지출 명세서";
                spendSetView();
            }
            setViews();
        }

        /// <summary>
        /// DataGridView 설정 부분
        /// </summary>
        private void setViews()
        {
            // 예산 데이터뷰 세팅
            budgetView.ColumnCount = 3;
            budgetView.ReadOnly = true;

            budgetView.Columns[0].HeaderText = "항목";
            budgetView.Columns[1].HeaderText = "금액";
            budgetView.Columns[2].HeaderText = "구성 비";
            
            for(int i = 0;i < budgetView.ColumnCount; i++)
            {
                budgetView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            budgetView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            budgetView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            if(mode == DMode.income)
                budgetView.RowCount = 8;

            // 현재 상황 데이터뷰 세팅
            progressView.ColumnCount = 3;
            progressView.ReadOnly = true;

            progressView.Columns[0].HeaderText = "항목";
            progressView.Columns[1].HeaderText = "금액";
            progressView.Columns[2].HeaderText = "구성 비";

            for(int i = 0;i < progressView.ColumnCount; i++)
            {
                progressView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            progressView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            progressView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            if (mode == DMode.income)
                progressView.RowCount = 8;

            // 기타 데이터뷰 세팅
            etcView.ColumnCount = 2;
            etcView.ReadOnly = true;
            etcView.ColumnHeadersVisible = false;

            for(int i = 0;i < etcView.ColumnCount; i++)
            {
                etcView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            etcView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            etcView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            etcView.RowCount = 2;
        }

        /// <summary>
        /// DataGridView SpendMode 설정 부분
        /// </summary>
        private void spendSetView()
        {
            setViews();

            budgetView.Size = new Size(430, 230);
            budgetView.RowCount = 9;

            progressView.Size = new Size(430, 230);
            progressView.RowCount = 9;
        }

        #region income 모드
        
        /// <summary>
        /// 예산 입력
        /// </summary>
        private void budgetInput()
        {
            // 주일 헌금
            budgetView.Rows[0].Cells[0].Value = "주일 헌금";
            budgetView.Rows[0].Cells[1].Value = budgetWeekOffering.ToString("n0") + "원";
            budgetView.Rows[0].Cells[2].Value = ((float)budgetWeekOffering / (float)budgetSum * 100).ToString("00.00") + " %";

            // 십일조
            budgetView.Rows[1].Cells[0].Value = "십일조 헌금";
            budgetView.Rows[1].Cells[1].Value = budgetSipil.ToString("n0") + "원";
            budgetView.Rows[1].Cells[2].Value = ((float)budgetSipil / (float)budgetSum * 100).ToString("00.00") + " %";


            // 감사 헌금
            budgetView.Rows[2].Cells[0].Value = "감사 헌금";
            budgetView.Rows[2].Cells[1].Value = budgetThanksOffering.ToString("n0") + "원";
            budgetView.Rows[2].Cells[2].Value = ((float)budgetThanksOffering / (float)budgetSum * 100).ToString("00.00") + " %";


            // 선교 헌금
            budgetView.Rows[3].Cells[0].Value = "선교 헌금";
            budgetView.Rows[3].Cells[1].Value = budgetMissionWork.ToString("n0") + "원";
            budgetView.Rows[3].Cells[2].Value = ((float)budgetMissionWork / (float)budgetSum * 100).ToString("00.00") + " %";


            // 구역 헌금
            budgetView.Rows[4].Cells[0].Value = "구역 헌금";
            budgetView.Rows[4].Cells[1].Value = budgetRegion.ToString("n0") + "원";
            budgetView.Rows[4].Cells[2].Value = ((float)budgetRegion / (float)budgetSum * 100).ToString("00.00") + " %";


            // 특별 헌금
            budgetView.Rows[5].Cells[0].Value = "특별 헌금";
            budgetView.Rows[5].Cells[1].Value = budgetSpecial.ToString("n0") + "원";
            budgetView.Rows[5].Cells[2].Value = ((float)budgetSpecial / (float)budgetSum * 100).ToString("00.00") + " %";


            // 절기 헌금
            budgetView.Rows[6].Cells[0].Value = "절기 헌금";
            budgetView.Rows[6].Cells[1].Value = budgetSeason.ToString("n0") + "원";
            budgetView.Rows[6].Cells[2].Value = ((float)budgetSeason / (float)budgetSum * 100).ToString("00.00") + " %";

            // 합계
            budgetView.Rows[7].Cells[0].Value = "합계";
            budgetView.Rows[7].Cells[1].Value = budgetSum.ToString("n0") + "원";
            budgetView.Rows[7].Cells[2].Value = ((float)budgetSum / (float)budgetSum * 100).ToString("00.00") + " %";

        }

        /// <summary>
        /// 진행상황 입력
        /// </summary>
        private void progressInput()
        {
            // 주일 헌금
            progressView.Rows[0].Cells[0].Value = "주일 헌금";
            progressView.Rows[0].Cells[1].Value = week.ToString("n0").ToString();
            progressView.Rows[0].Cells[2].Value = ((float)week / (float)budgetWeekOffering * 100).ToString("00.00") + "%";

            // 십일조 헌금
            progressView.Rows[1].Cells[0].Value = "십일조 헌금";
            progressView.Rows[1].Cells[1].Value = sipil.ToString("n0").ToString();
            progressView.Rows[1].Cells[2].Value = ((float)sipil / (float)budgetSipil * 100).ToString("00.00") + "%";

            // 감사 헌금
            progressView.Rows[2].Cells[0].Value = "감사 헌금";
            progressView.Rows[2].Cells[1].Value = thanks.ToString("n0").ToString();
            progressView.Rows[2].Cells[2].Value = ((float)thanks / (float)budgetThanksOffering * 100).ToString("00.00") + "%";

            // 선교 헌금
            progressView.Rows[3].Cells[0].Value = "선교 헌금";
            progressView.Rows[3].Cells[1].Value = missionWork.ToString("n0").ToString();
            progressView.Rows[3].Cells[2].Value = ((float)missionWork / (float)budgetMissionWork * 100).ToString("00.00") + "%";

            // 구역 헌금
            progressView.Rows[4].Cells[0].Value = "구역 헌금";
            progressView.Rows[4].Cells[1].Value = region.ToString("n0").ToString();
            progressView.Rows[4].Cells[2].Value = ((float)region / (float)budgetRegion * 100).ToString("00.00") + "%";

            // 특별 헌금
            progressView.Rows[5].Cells[0].Value = "특별 헌금";
            progressView.Rows[5].Cells[1].Value = special.ToString("n0").ToString();
            progressView.Rows[5].Cells[2].Value = ((float)special / (float)budgetSpecial * 100).ToString("00.00") + "%";

            // 절기 헌금
            progressView.Rows[6].Cells[0].Value = "절기 헌금";
            progressView.Rows[6].Cells[1].Value = season.ToString("n0").ToString();
            progressView.Rows[6].Cells[2].Value = ((float)season / (float)budgetSeason * 100).ToString("00.00") + "%";

            // 합계
            progressView.Rows[7].Cells[0].Value = "합계";
            progressView.Rows[7].Cells[1].Value = sum.ToString("n0").ToString();
            progressView.Rows[7].Cells[2].Value = ((float)sum / (float)budgetSum * 100).ToString("00.00") + "%";
        }

        /// <summary>
        /// 기타 데이터뷰 입력
        /// </summary>
        private void etcInput()
        {
            // 수입 이자
            etcView.Rows[0].Cells[0].Value = "수입 이자";
            etcView.Rows[0].Cells[1].Value = incomeInterest.ToString("n0") + "원";

            // 차량 헌금
            etcView.Rows[1].Cells[0].Value = "차랑 헌금";
            etcView.Rows[1].Cells[1].Value = carOffering.ToString("n0") + "원";
        }

        #endregion

        #region spend 모드

        /// <summary>
        /// 예산 입력 부분
        /// </summary>
        private void spendBudgetInput()
        {
            // 예배비
            budgetView.Rows[0].Cells[0].Value = "예배비";
            budgetView.Rows[0].Cells[1].Value = budgetPray.ToString("n0") + "원";
            budgetView.Rows[0].Cells[2].Value = ((float)budgetPray / (float)budgetSpendSum * 100).ToString("00.00") + " %";

            // 선교비
            budgetView.Rows[1].Cells[0].Value = "선교비";
            budgetView.Rows[1].Cells[1].Value = budgetSpendMission.ToString("n0") + "원";
            budgetView.Rows[1].Cells[2].Value = ((float)budgetSpendMission / (float)budgetSpendSum * 100).ToString("00.00") + " %";

            // 교육비
            budgetView.Rows[2].Cells[0].Value = "교육비";
            budgetView.Rows[2].Cells[1].Value = budgetEdu.ToString("n0") + "원";
            budgetView.Rows[2].Cells[2].Value = ((float)budgetEdu / (float)budgetSpendSum * 100).ToString("00.00") + " %";

            // 인건비
            budgetView.Rows[3].Cells[0].Value = "인건비";
            budgetView.Rows[3].Cells[1].Value = budgetPerson.ToString("n0") + "원";
            budgetView.Rows[3].Cells[2].Value = ((float)budgetPerson / (float)budgetSpendSum * 100).ToString("00.00") + " %";

            // 봉사비
            budgetView.Rows[4].Cells[0].Value = "봉사비";
            budgetView.Rows[4].Cells[1].Value = budgetService.ToString("n0") + "원";
            budgetView.Rows[4].Cells[2].Value = ((float)budgetService / (float)budgetSpendSum * 100).ToString("00.00") + " %";

            // 운영 관리비
            budgetView.Rows[5].Cells[0].Value = "운영 관리비";
            budgetView.Rows[5].Cells[1].Value = budgetManage.ToString("n0") + "원";
            budgetView.Rows[5].Cells[2].Value = ((float)budgetManage / (float)budgetSpendSum * 100).ToString("00.00") + " %";

            // 대출 관련비
            budgetView.Rows[6].Cells[0].Value = "대출 관련비";
            budgetView.Rows[6].Cells[1].Value = budgetLoan.ToString("n0") + "원";
            budgetView.Rows[6].Cells[2].Value = ((float)budgetLoan / (float)budgetSpendSum * 100).ToString("00.00") + " %";

            // 예비비
            budgetView.Rows[7].Cells[0].Value = "예비비";
            budgetView.Rows[7].Cells[1].Value = budgetPrepare.ToString("n0") + "원";
            budgetView.Rows[7].Cells[2].Value = ((float)budgetPrepare / (float)budgetSpendSum * 100).ToString("00.00") + " %";

            // 합계
            budgetView.Rows[8].Cells[0].Value = "합계";
            budgetView.Rows[8].Cells[1].Value = budgetSpendSum.ToString("n0") + "원";
            budgetView.Rows[8].Cells[2].Value = ((float)budgetSum / (float)budgetSpendSum * 100).ToString("00.00") + " %";
            
        }
        
        /// <summary>
        /// 진행상황 입력
        /// </summary>
        private void spendProgressInput()
        {
            // 예배비
            progressView.Rows[0].Cells[0].Value = "예배비";
            progressView.Rows[0].Cells[1].Value = pray.ToString("n0").ToString();
            progressView.Rows[0].Cells[2].Value = ((float)pray / (float)budgetPray * 100).ToString("00.00") + "%";

            // 선교비
            progressView.Rows[1].Cells[0].Value = "선교비";
            progressView.Rows[1].Cells[1].Value = spendMission.ToString("n0").ToString();
            progressView.Rows[1].Cells[2].Value = ((float)spendMission / (float)budgetSpendMission * 100).ToString("00.00") + "%";

            // 교육비
            progressView.Rows[2].Cells[0].Value = "교육비";
            progressView.Rows[2].Cells[1].Value = edu.ToString("n0").ToString();
            progressView.Rows[2].Cells[2].Value = ((float)edu / (float)budgetEdu * 100).ToString("00.00") + "%";

            // 인건비
            progressView.Rows[3].Cells[0].Value = "인건비";
            progressView.Rows[3].Cells[1].Value = person.ToString("n0").ToString();
            progressView.Rows[3].Cells[2].Value = ((float)person / (float)budgetPerson * 100).ToString("00.00") + "%";

            // 봉사비
            progressView.Rows[4].Cells[0].Value = "봉사비";
            progressView.Rows[4].Cells[1].Value = service.ToString("n0").ToString();
            progressView.Rows[4].Cells[2].Value = ((float)service / (float)budgetService * 100).ToString("00.00") + "%";

            // 운영 관리비
            progressView.Rows[5].Cells[0].Value = "운영 관리비";
            progressView.Rows[5].Cells[1].Value = manage.ToString("n0").ToString();
            progressView.Rows[5].Cells[2].Value = ((float)manage / (float)budgetManage * 100).ToString("00.00") + "%";

            // 대출 관리비
            progressView.Rows[6].Cells[0].Value = "대출 관리비";
            progressView.Rows[6].Cells[1].Value = loan.ToString("n0").ToString();
            progressView.Rows[6].Cells[2].Value = ((float)loan / (float)budgetLoan * 100).ToString("00.00") + "%";

            // 예비비
            progressView.Rows[7].Cells[0].Value = "예비비";
            progressView.Rows[7].Cells[1].Value = prepare.ToString("n0").ToString();
            progressView.Rows[7].Cells[2].Value = ((float)prepare / (float)budgetPrepare * 100).ToString("00.00") + "%";

            // 합계
            progressView.Rows[8].Cells[0].Value = "합계";
            progressView.Rows[8].Cells[1].Value = spendSum.ToString("n0").ToString();
            progressView.Rows[8].Cells[2].Value = ((float)spendSum / (float)budgetSpendSum * 100).ToString("00.00") + "%";
        }

        /// <summary>
        /// 기타 입력
        /// </summary>
        private void spendEtcInput()
        {

        }

        #endregion

        /// <summary>
        /// 그리는 부분
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IncomeProgress_Paint(object sender, PaintEventArgs e)
        {
            if (mode == DMode.income)
            {
                // 예산 입력
                budgetInput();

                // 진행상황 입력
                progressInput();

                // 기타데이터 입력
                etcInput();
            }
            else
            {
                spendBudgetInput();

                spendProgressInput();

                spendEtcInput();
            }
        }
    }
}
