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

        #region get/set 메소드

        public int BudgetThanksOffering
        {
            get
            {
                return budgetThanksOffering;
            }

            set
            {
                budgetThanksOffering = value;
                Invalidate();
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
                Invalidate();
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
                Invalidate();
            }
        }

        public int BudgetBuild
        {
            get
            {
                return budgetBuild;
            }

            set
            {
                budgetBuild = value;
                Invalidate();
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
                Invalidate();
            }
        }

        public int BudgetSungmi
        {
            get
            {
                return budgetSungmi;
            }

            set
            {
                budgetSungmi = value;
                Invalidate();
            }
        }

        public int BudgetSaving
        {
            get
            {
                return budgetSaving;
            }

            set
            {
                budgetSaving = value;
                Invalidate();
            }
        }

        public int BudgetCar
        {
            get
            {
                return budgetCar;
            }

            set
            {
                budgetCar = value;
                Invalidate();
            }
        }

        public int BudgetEtc
        {
            get
            {
                return budgetEtc;
            }

            set
            {
                budgetEtc = value;
                Invalidate();
            }
        }

        public int BudgetIncome
        {
            get
            {
                return budgetIncome;
            }

            set
            {
                budgetIncome = value;
                Invalidate();
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
                Invalidate();
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
                Invalidate();
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
                Invalidate();
            }
        }

        public int BudgetPerson
        {
            get
            {
                return budgetPerson;
            }

            set
            {
                budgetPerson = value;
                Invalidate();
            }
        }

        public int BudgetService
        {
            get
            {
                return budgetService;
            }

            set
            {
                budgetService = value;
                Invalidate();
            }
        }

        public int BudgetManage
        {
            get
            {
                return budgetManage;
            }

            set
            {
                budgetManage = value;
                Invalidate();
            }
        }

        public int BudgetLoan
        {
            get
            {
                return budgetLoan;
            }

            set
            {
                budgetLoan = value;
                Invalidate();
            }
        }

        public int BudgetPrepare
        {
            get
            {
                return budgetPrepare;
            }

            set
            {
                budgetPrepare = value;
                Invalidate();
            }
        }

        public int ThanksOffering
        {
            get
            {
                return thanksOffering;
            }

            set
            {
                thanksOffering = value;
                Invalidate();
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
                Invalidate();
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
                Invalidate();
            }
        }

        public int Build
        {
            get
            {
                return build;
            }

            set
            {
                build = value;
                Invalidate();
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
                Invalidate();
            }
        }

        public int Sungmi
        {
            get
            {
                return sungmi;
            }

            set
            {
                sungmi = value;
                Invalidate();
            }
        }

        public int Saving
        {
            get
            {
                return saving;
            }

            set
            {
                saving = value;
                Invalidate();
            }
        }

        public int Car
        {
            get
            {
                return car;
            }

            set
            {
                car = value;
                Invalidate();
            }
        }

        public int Etc
        {
            get
            {
                return etc;
            }

            set
            {
                etc = value;
                Invalidate();
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
                income = value;
                Invalidate();
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
                Invalidate();
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
                Invalidate();
            }
        }

        public int Edu
        {
            get
            {
                return edu;
            }

            set
            {
                edu = value;
                Invalidate();
            }
        }

        public int Person
        {
            get
            {
                return person;
            }

            set
            {
                person = value;
                Invalidate();
            }
        }

        public int Service
        {
            get
            {
                return service;
            }

            set
            {
                service = value;
                Invalidate();
            }
        }

        public int Manage
        {
            get
            {
                return manage;
            }

            set
            {
                manage = value;
                Invalidate();
            }
        }

        public int Loan
        {
            get
            {
                return loan;
            }

            set
            {
                loan = value;
                Invalidate();
            }
        }

        public int Prepare
        {
            get
            {
                return prepare;
            }

            set
            {
                prepare = value;
                Invalidate();
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
            BudgetThanksOffering = 2000000;
            BudgetSipil = 14000000;
            BudgetRegion = 25000000;
            BudgetBuild = 1000000;
            BudgetMissionWork = 8000000;
            BudgetSungmi = 7000000;
            BudgetSaving = 10000000;
            BudgetCar = 8000000;
            BudgetIncome = 3000000;
            BudgetEtc = 10000000;
            BudgetIncome = 6000000;
            
            // 진행 데이터 입력
            ThanksOffering = 200000;
            Sipil = 1200000;
            Region1 = 4200000;
            Build = 150000;
            MissionWork = 600000;
            Sungmi = 350000;
            Saving = 1200000;
            Car = 890000;
            Income = 243000;
            Etc = 300000;
            Income = 358000;

            // 지출 예산 데이터 입력
            BudgetPray = 2900000;
            BudgetSpendMission = 8700000;
            BudgetEdu = 13200000;
            BudgetPerson = 43800000;
            BudgetService = 9200000;
            BudgetManage = 66620000;
            BudgetLoan = 20000000;
            BudgetPrepare = 11453000;

            // 지출 진행 데이터 입력
            Pray = 200000;
            SpendMission = 660000;
            Edu = 1050500;
            Person = 3500000;
            Service = 112500;
            Manage = 3303980;
            Loan = 900410;
            Prepare = 8111000;

            #endregion

            // 수입 합계
            budgetSum = BudgetThanksOffering + BudgetSipil + BudgetRegion + BudgetBuild + BudgetMissionWork + BudgetSungmi + BudgetSaving + BudgetCar + BudgetEtc
                + BudgetIncome;
            sum = ThanksOffering + Sipil + Region1 + Build + MissionWork + Sungmi + Saving + Car + Etc;
            
            // 지출 합계
            budgetSpendSum = BudgetPray + BudgetSpendMission + BudgetEdu + BudgetPerson + BudgetService + BudgetManage + BudgetLoan + BudgetPrepare;
            spendSum = Pray + SpendMission + Edu + Person + Service + Manage + Loan + Prepare;

            
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
            budgetView.Rows[0].Cells[1].Value = BudgetThanksOffering.ToString("n0") + "원";
            budgetView.Rows[0].Cells[2].Value = ((float)BudgetThanksOffering / (float)budgetSum * 100).ToString("00.00") + " %";
            budgetView.Rows[0].Cells[3].Value = ThanksOffering.ToString("n0") + "원";
            budgetView.Rows[0].Cells[4].Value = ((float)ThanksOffering / (float)BudgetThanksOffering * 100).ToString("00.00") + " %";

            // 십일조
            budgetView.Rows[1].Cells[0].Value = "십일조";
            budgetView.Rows[1].Cells[1].Value = BudgetSipil.ToString("n0") + "원";
            budgetView.Rows[1].Cells[2].Value = ((float)BudgetSipil / (float)budgetSum * 100).ToString("00.00") + " %";
            budgetView.Rows[1].Cells[3].Value = Sipil.ToString("n0") + "원";
            budgetView.Rows[1].Cells[4].Value = ((float)Sipil / (float)BudgetSipil * 100).ToString("00.00") + " %";

            // 구역 헌금
            budgetView.Rows[2].Cells[0].Value = "구역 헌금";
            budgetView.Rows[2].Cells[1].Value = BudgetRegion.ToString("n0") + "원";
            budgetView.Rows[2].Cells[2].Value = ((float)BudgetRegion / (float)budgetSum * 100).ToString("00.00") + " %";
            budgetView.Rows[2].Cells[3].Value = Region1.ToString("n0") + "원";
            budgetView.Rows[2].Cells[4].Value = ((float)Region1 / (float)BudgetRegion * 100).ToString("00.00") + " %";

            // 건축 헌금
            budgetView.Rows[3].Cells[0].Value = "건축 헌금";
            budgetView.Rows[3].Cells[1].Value = BudgetBuild.ToString("n0") + " 원";
            budgetView.Rows[3].Cells[2].Value = ((float)BudgetBuild / (float)budgetSum * 100).ToString("00.00") + " %";
            budgetView.Rows[3].Cells[3].Value = MissionWork.ToString("n0") + " 원";
            budgetView.Rows[3].Cells[4].Value = ((float)Build/ (float)BudgetBuild * 100).ToString("00.00") + " %";

            // 선교 헌금
            budgetView.Rows[4].Cells[0].Value = "선교 헌금";
            budgetView.Rows[4].Cells[1].Value = BudgetMissionWork.ToString("n0") + " 원";
            budgetView.Rows[4].Cells[2].Value = ((float)BudgetMissionWork / (float)budgetSum * 100).ToString("00.00") + " %";
            budgetView.Rows[4].Cells[3].Value = MissionWork.ToString("n0") + " 원";
            budgetView.Rows[4].Cells[4].Value = ((float)MissionWork / (float)BudgetMissionWork * 100).ToString("00.00") + " %";

            // 성미 헌금
            budgetView.Rows[5].Cells[0].Value = "성미 헌금";
            budgetView.Rows[5].Cells[1].Value = BudgetSungmi.ToString("n0") + " 원";
            budgetView.Rows[5].Cells[2].Value = ((float)BudgetSungmi / (float)budgetSum * 100).ToString("00.00") + " %";
            budgetView.Rows[5].Cells[3].Value = Sungmi.ToString("n0") + " 원";
            budgetView.Rows[5].Cells[4].Value = ((float)Sungmi / (float)BudgetSungmi * 100).ToString("00.00") + " %";

            // 구제 헌금
            budgetView.Rows[6].Cells[0].Value = "구제 헌금";
            budgetView.Rows[6].Cells[1].Value = BudgetSaving.ToString("n0") + " 원";
            budgetView.Rows[6].Cells[2].Value = ((float)BudgetSaving / (float)budgetSum * 100).ToString("00.00") + " %";
            budgetView.Rows[6].Cells[3].Value = Saving.ToString("n0") + " 원";
            budgetView.Rows[6].Cells[4].Value = ((float)ThanksOffering / (float)BudgetThanksOffering * 100).ToString("00.00") + " %";

            // 차량 헌금
            budgetView.Rows[7].Cells[0].Value = "차량 헌금";
            budgetView.Rows[7].Cells[1].Value = BudgetCar.ToString("n0") + " 원";
            budgetView.Rows[7].Cells[2].Value = ((float)BudgetCar / (float)budgetSum * 100).ToString("00.00") + " %";
            budgetView.Rows[7].Cells[3].Value = Car.ToString("n0") + " 원";
            budgetView.Rows[7].Cells[4].Value = ((float)Car / (float)BudgetCar * 100).ToString("00.00") + " %";

            // 이자 수입
            budgetView.Rows[8].Cells[0].Value = "이자 수입";
            budgetView.Rows[8].Cells[1].Value = BudgetIncome.ToString("n0") + " 원";
            budgetView.Rows[8].Cells[2].Value = ((float)BudgetIncome / (float)budgetSum * 100).ToString("00.00") + " %";
            budgetView.Rows[8].Cells[3].Value = Income.ToString("n0") + " 원";
            budgetView.Rows[8].Cells[4].Value = ((float)Income / (float)BudgetIncome * 100).ToString("00.00") + " %";

            // 기타 수입
            budgetView.Rows[9].Cells[0].Value = "기타 수입";
            budgetView.Rows[9].Cells[1].Value = BudgetEtc.ToString("n0") + " 원";
            budgetView.Rows[9].Cells[2].Value = ((float)BudgetEtc / (float)budgetSum * 100).ToString("00.00") + " %";
            budgetView.Rows[9].Cells[3].Value = Etc.ToString("n0") + " 원";
            budgetView.Rows[9].Cells[4].Value = ((float)Etc / (float)BudgetEtc * 100).ToString("00.00") + " %";
            
            // 합계
            budgetView.Rows[10].Cells[0].Value = "합계";
            budgetView.Rows[10].Cells[1].Value = budgetSum.ToString("n0") + " 원";
            budgetView.Rows[10].Cells[2].Value = ((float)budgetSum / (float)budgetSum * 100).ToString("00.00") + " %";
            budgetView.Rows[10].Cells[3].Value = sum.ToString("n0") + " 원";
            budgetView.Rows[10].Cells[4].Value = ((float)sum / (float)budgetSum * 100).ToString("00.00") + " %";

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
            budgetView.Rows[0].Cells[1].Value = BudgetPray.ToString("n0") + "원";
            budgetView.Rows[0].Cells[2].Value = ((float)BudgetPray / (float)budgetSpendSum * 100).ToString("00.00") + " %";
            budgetView.Rows[0].Cells[3].Value = Pray.ToString("n0") + "원";
            budgetView.Rows[0].Cells[4].Value = ((float)Pray / (float)BudgetPray * 100).ToString("00.00") + " %";

            // 선교비
            budgetView.Rows[1].Cells[0].Value = "선교비";
            budgetView.Rows[1].Cells[1].Value = BudgetSpendMission.ToString("n0") + "원";
            budgetView.Rows[1].Cells[2].Value = ((float)BudgetSpendMission / (float)budgetSpendSum * 100).ToString("00.00") + " %";
            budgetView.Rows[1].Cells[3].Value = SpendMission.ToString("n0") + "원";
            budgetView.Rows[1].Cells[4].Value = ((float)SpendMission / (float)BudgetSpendMission * 100).ToString("00.00") + " %";

            // 교육비
            budgetView.Rows[2].Cells[0].Value = "교육비";
            budgetView.Rows[2].Cells[1].Value = BudgetEdu.ToString("n0") + "원";
            budgetView.Rows[2].Cells[2].Value = ((float)BudgetEdu / (float)budgetSpendSum * 100).ToString("00.00") + " %";
            budgetView.Rows[2].Cells[3].Value = Edu.ToString("n0") + "원";
            budgetView.Rows[2].Cells[4].Value = ((float)Edu / (float)BudgetEdu * 100).ToString("00.00") + " %";

            // 인건비
            budgetView.Rows[3].Cells[0].Value = "인건비";
            budgetView.Rows[3].Cells[1].Value = BudgetPerson.ToString("n0") + "원";
            budgetView.Rows[3].Cells[2].Value = ((float)BudgetPerson / (float)budgetSpendSum * 100).ToString("00.00") + " %";
            budgetView.Rows[3].Cells[3].Value = Person.ToString("n0") + "원";
            budgetView.Rows[3].Cells[4].Value = ((float)Person / (float)BudgetPerson * 100).ToString("00.00") + " %";

            // 봉사비
            budgetView.Rows[4].Cells[0].Value = "봉사비";
            budgetView.Rows[4].Cells[1].Value = BudgetService.ToString("n0") + "원";
            budgetView.Rows[4].Cells[2].Value = ((float)BudgetService / (float)budgetSpendSum * 100).ToString("00.00") + " %";
            budgetView.Rows[4].Cells[3].Value = Service.ToString("n0") + "원";
            budgetView.Rows[4].Cells[4].Value = ((float)Service / (float)BudgetService * 100).ToString("00.00") + " %";

            // 운영 관리비
            budgetView.Rows[5].Cells[0].Value = "운영 관리비";
            budgetView.Rows[5].Cells[1].Value = BudgetManage.ToString("n0") + "원";
            budgetView.Rows[5].Cells[2].Value = ((float)BudgetManage / (float)budgetSpendSum * 100).ToString("00.00") + " %";
            budgetView.Rows[5].Cells[3].Value = Manage.ToString("n0") + "원";
            budgetView.Rows[5].Cells[4].Value = ((float)Manage / (float)BudgetManage * 100).ToString("00.00") + " %";

            // 대출 관련비
            budgetView.Rows[6].Cells[0].Value = "대출 관련비";
            budgetView.Rows[6].Cells[1].Value = BudgetLoan.ToString("n0") + "원";
            budgetView.Rows[6].Cells[2].Value = ((float)BudgetLoan / (float)budgetSpendSum * 100).ToString("00.00") + " %";
            budgetView.Rows[6].Cells[3].Value = Loan.ToString("n0") + "원";
            budgetView.Rows[6].Cells[4].Value = ((float)Loan / (float)BudgetLoan * 100).ToString("00.00") + " %";

            // 예비비
            budgetView.Rows[7].Cells[0].Value = "예비비";
            budgetView.Rows[7].Cells[1].Value = BudgetPrepare.ToString("n0") + "원";
            budgetView.Rows[7].Cells[2].Value = ((float)BudgetPrepare / (float)budgetSpendSum * 100).ToString("00.00") + " %";
            budgetView.Rows[7].Cells[3].Value = Prepare.ToString("n0") + "원";
            budgetView.Rows[7].Cells[4].Value = ((float)Prepare / (float)BudgetPrepare * 100).ToString("00.00") + " %";

            // 합계
            budgetView.Rows[8].Cells[0].Value = "합계";
            budgetView.Rows[8].Cells[1].Value = budgetSpendSum.ToString("n0") + "원";
            budgetView.Rows[8].Cells[2].Value = ((float)budgetSum / (float)budgetSpendSum * 100).ToString("00.00") + " %";
            budgetView.Rows[8].Cells[3].Value = spendSum.ToString("n0") + "원";
            budgetView.Rows[8].Cells[4].Value = ((float)spendSum / (float)budgetSpendSum * 100).ToString("00.00") + " %";
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
                // 수입 내용 입력
                budgetInput();
            }
            else if(mode == DMode.spend)
            {
                // 수입 지출 입력
                spendBudgetInput();
            }
        }
    }
}
