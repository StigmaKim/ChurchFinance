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
        /// 감사 헌금 예산
        /// </summary>
        private int budgetThanksOffering;
        /// <summary>
        /// 십일조 헌금 예산
        /// </summary>
        private int budgetSipil;
        /// <summary>
        /// 구역헌금 예산
        /// </summary>
        private int budgetRegion;
        /// <summary>
        /// 건축 헌금 예산
        /// </summary>
        private int budgetBuild;
        /// <summary>
        /// 선교 헌금 예산
        /// </summary>
        private int budgetMissionWork;
        /// <summary>
        /// 성미 헌금
        /// </summary>
        private int budgetSungmi;
        /// <summary>
        /// 구제헌금
        /// </summary>
        private int budgetSaving;
        /// <summary>
        /// 차량헌금
        /// </summary>
        private int budgetCar;
        /// <summary>
        /// 기타헌금
        /// </summary>
        private int budgetEtc;
        /// <summary>
        /// 이자 수입
        /// </summary>
        private int budgetIncome;

        /// <summary>
        /// 예산 합
        /// </summary>
        private int budgetSum;

        #endregion

        #region 지출 예산 변수

        /// <summary>
        /// 예배비
        /// </summary>
        private int budgetPray;
        /// <summary>
        /// 선교비
        /// </summary>
        private int budgetSpendMission;
        /// <summary>
        /// 교육비
        /// </summary>
        private int budgetEdu;
        /// <summary>
        /// 인건비
        /// </summary>
        private int budgetPerson;
        /// <summary>
        /// 봉사비
        /// </summary>
        private int budgetService;
        /// <summary>
        /// 운영 관리비
        /// </summary>
        private int budgetManage;
        /// <summary>
        /// 대출 관리비
        /// </summary>
        private int budgetLoan;
        /// <summary>
        ///  예비비
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
        /// 감사 헌금 
        /// </summary>
        private int thanksOffering;
        /// <summary>
        /// 십일조 헌금 예산
        /// </summary>
        private int sipil;
        /// <summary>
        /// 구역헌금 예산
        /// </summary>
        private int region;
        /// <summary>
        /// 건축 헌금 예산
        /// </summary>
        private int build;
        /// <summary>
        /// 선교 헌금 예산
        /// </summary>
        private int missionWork;
        /// <summary>
        /// 성미 헌금
        /// </summary>
        private int sungmi;
        /// <summary>
        /// 구제헌금
        /// </summary>
        private int saving;
        /// <summary>
        /// 차량헌금
        /// </summary>
        private int car;
        /// <summary>
        /// 기타헌금
        /// </summary>
        private int etc;
        /// <summary>
        /// 이자 수입
        /// </summary>
        private int income;

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
            budgetThanksOffering = 2000000;
            budgetSipil = 14000000;
            budgetRegion = 25000000;
            budgetBuild = 1000000;
            budgetMissionWork = 8000000;
            budgetSungmi = 7000000;
            budgetSaving = 10000000;
            budgetCar = 8000000;
            budgetIncome = 3000000;
            budgetEtc = 10000000;
            budgetIncome = 6000000;
            
            // 진행 데이터 입력
            thanksOffering = 200000;
            sipil = 1200000;
            region = 4200000;
            build = 150000;
            missionWork = 600000;
            sungmi = 350000;
            saving = 1200000;
            car = 890000;
            income = 243000;
            etc = 300000;
            income = 358000;

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
            prepare = 8111000;

            #endregion

            // 수입 합계
            budgetSum = budgetThanksOffering + budgetSipil + budgetRegion + budgetBuild + budgetMissionWork + budgetSungmi + budgetSaving + budgetCar + budgetEtc
                + budgetIncome;
            sum = thanksOffering + sipil + region + build + missionWork + sungmi + saving + car + etc;
            
            // 지출 합계
            budgetSpendSum = budgetPray + budgetSpendMission + budgetEdu + budgetPerson + budgetService + budgetManage + budgetLoan + budgetPrepare;
            spendSum = pray + spendMission + edu + person + service + manage + loan + prepare;

            
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
            budgetView.ColumnCount = 5;
            budgetView.ReadOnly = true;

            budgetView.Columns[0].HeaderText = "항목";
            budgetView.Columns[1].HeaderText = "금액";
            budgetView.Columns[2].HeaderText = "구성 비";
            budgetView.Columns[3].HeaderText = "금액";
            budgetView.Columns[4].HeaderText = "진도 비";

            for(int i = 0;i < budgetView.ColumnCount; i++)
            {
                budgetView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            budgetView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            budgetView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            if(mode == DMode.income)
                budgetView.RowCount = 11;

            
        }

        /// <summary>
        /// DataGridView SpendMode 설정 부분
        /// </summary>
        private void spendSetView()
        {
            setViews();

            budgetView.Size = new Size(880, 230);
            budgetView.RowCount = 9;
            
        }

        #region income 모드
        
        /// <summary>
        /// 예산 입력
        /// </summary>
        private void budgetInput()
        {
            // 감사 헌금
            budgetView.Rows[0].Cells[0].Value = "감사 헌금";
            budgetView.Rows[0].Cells[1].Value = budgetThanksOffering.ToString("n0") + "원";
            budgetView.Rows[0].Cells[2].Value = ((float)budgetThanksOffering / (float)budgetSum * 100).ToString("00.00") + " %";
            budgetView.Rows[0].Cells[3].Value = thanksOffering.ToString("n0") + "원";
            budgetView.Rows[0].Cells[4].Value = ((float)thanksOffering / (float)budgetThanksOffering * 100).ToString("00.00") + " %";

            // 십일조
            budgetView.Rows[1].Cells[0].Value = "십일조";
            budgetView.Rows[1].Cells[1].Value = budgetSipil.ToString("n0") + "원";
            budgetView.Rows[1].Cells[2].Value = ((float)budgetSipil / (float)budgetSum * 100).ToString("00.00") + " %";
            budgetView.Rows[1].Cells[3].Value = sipil.ToString("n0") + "원";
            budgetView.Rows[1].Cells[4].Value = ((float)sipil / (float)budgetSipil * 100).ToString("00.00") + " %";

            // 구역 헌금
            budgetView.Rows[2].Cells[0].Value = "구역 헌금";
            budgetView.Rows[2].Cells[1].Value = budgetRegion.ToString("n0") + "원";
            budgetView.Rows[2].Cells[2].Value = ((float)budgetRegion / (float)budgetSum * 100).ToString("00.00") + " %";
            budgetView.Rows[2].Cells[3].Value = region.ToString("n0") + "원";
            budgetView.Rows[2].Cells[4].Value = ((float)region / (float)budgetRegion * 100).ToString("00.00") + " %";

            // 건축 헌금
            budgetView.Rows[3].Cells[0].Value = "건축 헌금";
            budgetView.Rows[3].Cells[1].Value = budgetBuild.ToString("n0") + " 원";
            budgetView.Rows[3].Cells[2].Value = ((float)budgetBuild / (float)budgetSum * 100).ToString("00.00") + " %";
            budgetView.Rows[3].Cells[3].Value = missionWork.ToString("n0") + " 원";
            budgetView.Rows[3].Cells[4].Value = ((float)build/ (float)budgetBuild * 100).ToString("00.00") + " %";

            // 선교 헌금
            budgetView.Rows[4].Cells[0].Value = "선교 헌금";
            budgetView.Rows[4].Cells[1].Value = budgetMissionWork.ToString("n0") + " 원";
            budgetView.Rows[4].Cells[2].Value = ((float)budgetMissionWork / (float)budgetSum * 100).ToString("00.00") + " %";
            budgetView.Rows[4].Cells[3].Value = missionWork.ToString("n0") + " 원";
            budgetView.Rows[4].Cells[4].Value = ((float)missionWork / (float)budgetMissionWork * 100).ToString("00.00") + " %";

            // 성미 헌금
            budgetView.Rows[5].Cells[0].Value = "성미 헌금";
            budgetView.Rows[5].Cells[1].Value = budgetSungmi.ToString("n0") + " 원";
            budgetView.Rows[5].Cells[2].Value = ((float)budgetSungmi / (float)budgetSum * 100).ToString("00.00") + " %";
            budgetView.Rows[5].Cells[3].Value = sungmi.ToString("n0") + " 원";
            budgetView.Rows[5].Cells[4].Value = ((float)sungmi / (float)budgetSungmi * 100).ToString("00.00") + " %";

            // 구제 헌금
            budgetView.Rows[6].Cells[0].Value = "구제 헌금";
            budgetView.Rows[6].Cells[1].Value = budgetSaving.ToString("n0") + " 원";
            budgetView.Rows[6].Cells[2].Value = ((float)budgetSaving / (float)budgetSum * 100).ToString("00.00") + " %";
            budgetView.Rows[6].Cells[3].Value = saving.ToString("n0") + " 원";
            budgetView.Rows[6].Cells[4].Value = ((float)thanksOffering / (float)budgetThanksOffering * 100).ToString("00.00") + " %";

            // 차량 헌금
            budgetView.Rows[7].Cells[0].Value = "차량 헌금";
            budgetView.Rows[7].Cells[1].Value = budgetCar.ToString("n0") + " 원";
            budgetView.Rows[7].Cells[2].Value = ((float)budgetCar / (float)budgetSum * 100).ToString("00.00") + " %";
            budgetView.Rows[7].Cells[3].Value = car.ToString("n0") + " 원";
            budgetView.Rows[7].Cells[4].Value = ((float)car / (float)budgetCar * 100).ToString("00.00") + " %";

            // 이자 수입
            budgetView.Rows[8].Cells[0].Value = "이자 수입";
            budgetView.Rows[8].Cells[1].Value = budgetIncome.ToString("n0") + " 원";
            budgetView.Rows[8].Cells[2].Value = ((float)budgetIncome / (float)budgetSum * 100).ToString("00.00") + " %";
            budgetView.Rows[8].Cells[3].Value = income.ToString("n0") + " 원";
            budgetView.Rows[8].Cells[4].Value = ((float)income / (float)budgetIncome * 100).ToString("00.00") + " %";

            // 기타 수입
            budgetView.Rows[9].Cells[0].Value = "기타 수입";
            budgetView.Rows[9].Cells[1].Value = budgetEtc.ToString("n0") + " 원";
            budgetView.Rows[9].Cells[2].Value = ((float)budgetEtc / (float)budgetSum * 100).ToString("00.00") + " %";
            budgetView.Rows[9].Cells[3].Value = etc.ToString("n0") + " 원";
            budgetView.Rows[9].Cells[4].Value = ((float)etc / (float)budgetEtc * 100).ToString("00.00") + " %";
            
            // 합계
            budgetView.Rows[10].Cells[0].Value = "합계";
            budgetView.Rows[10].Cells[1].Value = budgetSum.ToString("n0") + " 원";
            budgetView.Rows[10].Cells[2].Value = ((float)budgetSum / (float)budgetSum * 100).ToString("00.00") + " %";
            budgetView.Rows[10].Cells[3].Value = sum.ToString("n0") + " 원";
            budgetView.Rows[10].Cells[4].Value = ((float)sum / (float)budgetSum * 100).ToString("00.00") + " %";

        }
        /*
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
        */

        /*
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

        */
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
            budgetView.Rows[0].Cells[3].Value = pray.ToString("n0") + "원";
            budgetView.Rows[0].Cells[4].Value = ((float)pray / (float)budgetPray * 100).ToString("00.00") + " %";

            // 선교비
            budgetView.Rows[1].Cells[0].Value = "선교비";
            budgetView.Rows[1].Cells[1].Value = budgetSpendMission.ToString("n0") + "원";
            budgetView.Rows[1].Cells[2].Value = ((float)budgetSpendMission / (float)budgetSpendSum * 100).ToString("00.00") + " %";
            budgetView.Rows[1].Cells[3].Value = spendMission.ToString("n0") + "원";
            budgetView.Rows[1].Cells[4].Value = ((float)spendMission / (float)budgetSpendMission * 100).ToString("00.00") + " %";

            // 교육비
            budgetView.Rows[2].Cells[0].Value = "교육비";
            budgetView.Rows[2].Cells[1].Value = budgetEdu.ToString("n0") + "원";
            budgetView.Rows[2].Cells[2].Value = ((float)budgetEdu / (float)budgetSpendSum * 100).ToString("00.00") + " %";
            budgetView.Rows[2].Cells[3].Value = edu.ToString("n0") + "원";
            budgetView.Rows[2].Cells[4].Value = ((float)edu / (float)budgetEdu * 100).ToString("00.00") + " %";

            // 인건비
            budgetView.Rows[3].Cells[0].Value = "인건비";
            budgetView.Rows[3].Cells[1].Value = budgetPerson.ToString("n0") + "원";
            budgetView.Rows[3].Cells[2].Value = ((float)budgetPerson / (float)budgetSpendSum * 100).ToString("00.00") + " %";
            budgetView.Rows[3].Cells[3].Value = person.ToString("n0") + "원";
            budgetView.Rows[3].Cells[4].Value = ((float)person / (float)budgetPerson * 100).ToString("00.00") + " %";

            // 봉사비
            budgetView.Rows[4].Cells[0].Value = "봉사비";
            budgetView.Rows[4].Cells[1].Value = budgetService.ToString("n0") + "원";
            budgetView.Rows[4].Cells[2].Value = ((float)budgetService / (float)budgetSpendSum * 100).ToString("00.00") + " %";
            budgetView.Rows[4].Cells[3].Value = service.ToString("n0") + "원";
            budgetView.Rows[4].Cells[4].Value = ((float)service / (float)budgetService * 100).ToString("00.00") + " %";

            // 운영 관리비
            budgetView.Rows[5].Cells[0].Value = "운영 관리비";
            budgetView.Rows[5].Cells[1].Value = budgetManage.ToString("n0") + "원";
            budgetView.Rows[5].Cells[2].Value = ((float)budgetManage / (float)budgetSpendSum * 100).ToString("00.00") + " %";
            budgetView.Rows[5].Cells[3].Value = manage.ToString("n0") + "원";
            budgetView.Rows[5].Cells[4].Value = ((float)manage / (float)budgetManage * 100).ToString("00.00") + " %";

            // 대출 관련비
            budgetView.Rows[6].Cells[0].Value = "대출 관련비";
            budgetView.Rows[6].Cells[1].Value = budgetLoan.ToString("n0") + "원";
            budgetView.Rows[6].Cells[2].Value = ((float)budgetLoan / (float)budgetSpendSum * 100).ToString("00.00") + " %";
            budgetView.Rows[6].Cells[3].Value = loan.ToString("n0") + "원";
            budgetView.Rows[6].Cells[4].Value = ((float)loan / (float)budgetLoan * 100).ToString("00.00") + " %";

            // 예비비
            budgetView.Rows[7].Cells[0].Value = "예비비";
            budgetView.Rows[7].Cells[1].Value = budgetPrepare.ToString("n0") + "원";
            budgetView.Rows[7].Cells[2].Value = ((float)budgetPrepare / (float)budgetSpendSum * 100).ToString("00.00") + " %";
            budgetView.Rows[7].Cells[3].Value = prepare.ToString("n0") + "원";
            budgetView.Rows[7].Cells[4].Value = ((float)prepare / (float)budgetPrepare * 100).ToString("00.00") + " %";

            // 합계
            budgetView.Rows[8].Cells[0].Value = "합계";
            budgetView.Rows[8].Cells[1].Value = budgetSpendSum.ToString("n0") + "원";
            budgetView.Rows[8].Cells[2].Value = ((float)budgetSum / (float)budgetSpendSum * 100).ToString("00.00") + " %";
            budgetView.Rows[8].Cells[3].Value = spendSum.ToString("n0") + "원";
            budgetView.Rows[8].Cells[4].Value = ((float)spendSum / (float)budgetSpendSum * 100).ToString("00.00") + " %";
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
                //progressInput();

                // 기타데이터 입력
                //etcInput();
            }
            else if(mode == DMode.spend)
            {
                // 지출 예산 입력
                spendBudgetInput();

                // 지출 진행상황 입력
                //spendProgressInput();

                // 지출 기타데이터 입력
                spendEtcInput();
            }
        }
    }
}
