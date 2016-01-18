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

    public partial class SpendDetail : UserControl
    {

        #region 변수 선언

        /// <summary>
        /// 예산 예배비
        /// </summary>
        private Pray budgetPray;

        /// <summary>
        /// 현재 예배비
        /// </summary>
        private Pray curPray;

        /// <summary>
        /// 선교비
        /// </summary>
        private MissionWork budgetMissionWork;

        /// <summary>
        /// 현재 선교비
        /// </summary>
        private MissionWork curMissionWork;

        /// <summary>
        /// 예산 교육비
        /// </summary>
        private Education budgetEdu;

        /// <summary>
        /// 교육비
        /// </summary>
        private Education curEdu;

        /// <summary>
        /// 예산 인건비
        /// </summary>
        private Person budgetPerson;

        /// <summary>
        /// 현재 인건비
        /// </summary>
        private Person curPerson;

        /// <summary>
        /// 예산 봉사비
        /// </summary>
        private Service budgetService;

        /// <summary>
        /// 현재 봉사비
        /// </summary>
        private Service curService;

        /// <summary>
        /// 예산 운영 관리비
        /// </summary>
        private Manage budgetManage;

        /// <summary>
        /// 현재 운영 관리비
        /// </summary>
        private Manage curManage;

        /// <summary>
        /// 예산 대출 관련비
        /// </summary>
        private Loan budgetLoan;

        /// <summary>
        /// 현재 대출 관련비
        /// </summary>
        private Loan curLoan;

        /// <summary>
        /// 예산 예비비
        /// </summary>
        private int budgetPrepare;

        /// <summary>
        /// 예비비
        /// </summary>
        private int curPrepare;
        #endregion

        #region get / set

        public Pray BudgetPray
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

        public Pray CurPray
        {
            get
            {
                return curPray;
            }

            set
            {
                curPray = value;
                Invalidate();
            }
        }

        public MissionWork BudgetMissionWork
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

        public MissionWork CurMissionWork
        {
            get
            {
                return curMissionWork;
            }

            set
            {
                curMissionWork = value;
                Invalidate();
            }
        }

        public Education BudgetEdu
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

        public Education CurEdu
        {
            get
            {
                return curEdu;
            }

            set
            {
                curEdu = value;
                Invalidate();

            }
        }

        public Person BudgetPerson
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

        public Person CurPerson
        {
            get
            {
                return curPerson;
            }

            set
            {
                curPerson = value;
                Invalidate();

            }
        }

        public Service BudgetService
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

        public Service CurService
        {
            get
            {
                return curService;
            }

            set
            {
                curService = value;
                Invalidate();

            }
        }

        public Manage BudgetManage
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

        public Manage CurManage
        {
            get
            {
                return curManage;
            }

            set
            {
                curManage = value;
                Invalidate();

            }
        }

        public Loan BudgetLoan
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

        public Loan CurLoan
        {
            get
            {
                return curLoan;
            }

            set
            {
                curLoan = value;
                Invalidate();

            }
        }

        public int Prepare
        {
            get
            {
                return curPrepare;
            }

            set
            {
                curPrepare = value;
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

        #endregion

        /// <summary>
        /// 생성자
        /// </summary>
        public SpendDetail()
        {
            InitializeComponent();

            #region 변수 초기화

            budgetPray = new Pray();
            budgetMissionWork = new MissionWork();
            budgetEdu = new Education();
            budgetPerson = new Person();
            budgetService = new Service();
            budgetManage = new Manage();
            budgetLoan = new Loan();

            curPray = new Pray();
            curMissionWork = new MissionWork();
            curEdu = new Education();
            curPerson = new Person();
            curService = new Service();
            curManage = new Manage();
            curLoan = new Loan();
            
            #endregion

            #region 예시 데이터 입력


            // 예산 데이터 입력
            budgetPray.Flower = 1500000;
            budgetPray.Singer = 1200000;
            budgetPray.Jubo = 200000;
            budgetMissionWork.Misson = 8000000;
            budgetMissionWork.Visit = 700000;
            budgetEdu.WeekSchool = 2400000;
            budgetEdu.Student = 2400000;
            budgetEdu.YoungMan = 1800000;
            budgetEdu.ScholarShip = 6000000;
            budgetEdu.Book = 600000;
            budgetPerson.Priest = 21600000;
            budgetPerson.Missionary = 20400000;
            budgetPerson.Bonus = 1800000;
            budgetService.GyeongJo = 1000000;
            budgetService.Saving = 1200000;
            budgetService.Events = 7000000;
            budgetManage.Home = 2520000;
            budgetManage.Church = 22000000;
            budgetManage.Ministry = 4600000;
            budgetManage.Water = 3000000;
            budgetManage.Communication = 1500000;
            budgetManage.CarManage = 10000000;
            budgetManage.CarBuy = 6000000;
            budgetManage.Sang = 1000000;
            budgetManage.Tool = 2000000;
            budgetManage.Etc = 12000000;
            budgetLoan.Repayment = 12000000;
            budgetLoan.Interest = 8000000;
            BudgetPrepare = 11453000;
            

            // 현재 데이터 입력
            curPray.Flower = 100000;
            curPray.Singer = 100000;
            curPray.Jubo = 0;
            curMissionWork.Misson = 660000;
            curMissionWork.Visit = 0;
            curEdu.WeekSchool = 200000;
            curEdu.Student = 200000;
            curEdu.YoungMan = 150000;
            curEdu.ScholarShip = 500000;
            curEdu.Book = 0;
            curPerson.Priest = 1800000;
            curPerson.Missionary = 1700000;
            curPerson.Bonus = 0;
            curService.GyeongJo = 0;
            curService.Saving = 100000;
            curService.Events = 12500;
            curManage.Home = 210000;
            curManage.Church = 1324300;
            curManage.Ministry = 300000;
            curManage.Water = 0;
            curManage.Communication = 0;
            curManage.CarManage = 504000;
            curManage.CarBuy = 0;
            curManage.Sang = 0;
            curManage.Tool = 0;
            curManage.Etc = 628250;
            curLoan.Repayment = 500000;
            curLoan.Interest = 400410;
            curPrepare = 8111000;

            #endregion

            // 표 설정
            setView();

            Paint += SpendDetail_Paint;
        }

        /// <summary>
        /// DataGridView 설정
        /// </summary>
        private void setView()
        {
            // 행 갯수와 Alignment
            DataView.ColumnCount = 7;
            DataView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DataView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataView.Columns[0].HeaderText = "항목";
            DataView.Columns[1].HeaderText = "세목";
            DataView.Columns[3].HeaderText = "예산";
            DataView.Columns[5].HeaderText = "지출";
            DataView.Columns[6].HeaderText = "진도비";

            for (int i = 0; i < DataView.ColumnCount; i++)
                DataView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            DataView.ReadOnly = true;

            DataView.RowCount = 37;
        }

        /// <summary>
        /// Data Input
        /// </summary>
        private void inputData()
        {
            // 예배비
            DataView.Rows[0].Cells[0].Value = "예배비";
            DataView.Rows[0].Cells[1].Value = "소계";
            DataView.Rows[0].Cells[3].Value = (budgetPray.getSum()).ToString("n0") + "원";
            DataView.Rows[0].Cells[5].Value = (curPray.getSum()).ToString("n0") + "원";
            DataView.Rows[0].Cells[6].Value = ((float)(curPray.getSum())
                / (float)(budgetPray.getSum()) * 100).ToString("00.00") + "%";

            DataView.Rows[1].Cells[1].Value = "강단 꽃꽃이";
            DataView.Rows[1].Cells[2].Value = budgetPray.Flower.ToString("n0") + "원";
            DataView.Rows[1].Cells[4].Value = curPray.Flower.ToString("n0") + "원";
            DataView.Rows[1].Cells[6].Value = ((float)curPray.Flower / budgetPray.Flower * 100).ToString("00.00") + "%";

            DataView.Rows[2].Cells[1].Value = "성가대 운영비";
            DataView.Rows[2].Cells[2].Value = budgetPray.Singer.ToString("n0") + "원";
            DataView.Rows[2].Cells[4].Value = curPray.Singer.ToString("n0") + "원";
            DataView.Rows[2].Cells[6].Value = ((float)curPray.Singer / budgetPray.Singer * 100).ToString("00.00") + "%";

            DataView.Rows[3].Cells[1].Value = "주보대";
            DataView.Rows[3].Cells[2].Value = budgetPray.Jubo.ToString("n0") + "원";
            DataView.Rows[3].Cells[4].Value = curPray.Jubo.ToString("n0") + "원";
            DataView.Rows[3].Cells[6].Value = ((float)curPray.Jubo / budgetPray.Jubo * 100).ToString("00.00") + "%";

            // 선교비
            DataView.Rows[4].Cells[0].Value = "선교비";
            DataView.Rows[4].Cells[1].Value = "소계";
            DataView.Rows[4].Cells[3].Value = (budgetMissionWork.getSum()).ToString("n0") + "원";
            DataView.Rows[4].Cells[5].Value = (curMissionWork.getSum()).ToString("n0") + "원";
            DataView.Rows[4].Cells[6].Value = ((float)(curMissionWork.getSum())
                / (float)(budgetMissionWork.getSum() * 100)).ToString("00.00") + "%";

            DataView.Rows[5].Cells[1].Value = "선교비";
            DataView.Rows[5].Cells[2].Value = budgetMissionWork.Misson.ToString("n0") + "원";
            DataView.Rows[5].Cells[4].Value = curMissionWork.Misson.ToString("n0") + "원";
            DataView.Rows[5].Cells[6].Value = ((float)curMissionWork.Misson / budgetMissionWork.Misson * 100).ToString("00.00") + "%";

            DataView.Rows[6].Cells[1].Value = "심방비";
            DataView.Rows[6].Cells[2].Value = budgetMissionWork.Visit.ToString("n0") + "원";
            DataView.Rows[6].Cells[4].Value = curMissionWork.Visit.ToString("n0") + "원";
            DataView.Rows[6].Cells[6].Value = ((float)curMissionWork.Visit / budgetMissionWork.Visit * 100).ToString("00.00") + "%";

            // 교육비
            DataView.Rows[7].Cells[0].Value = "교육비";
            DataView.Rows[7].Cells[1].Value = "소계";
            DataView.Rows[7].Cells[3].Value = (budgetEdu.getSum()).ToString("n0") + "원";
            DataView.Rows[7].Cells[5].Value = (curEdu.getSum()).ToString("n0") + "원";
            DataView.Rows[7].Cells[6].Value = ((float)(curEdu.getSum())
                / (float)(budgetEdu.getSum())).ToString("00.00") + "%";

            DataView.Rows[8].Cells[1].Value = "주일학교 지원비";
            DataView.Rows[8].Cells[2].Value = budgetEdu.WeekSchool.ToString("n0") + "원";
            DataView.Rows[8].Cells[4].Value = curEdu.WeekSchool.ToString("n0") + "원";
            DataView.Rows[8].Cells[6].Value = ((float)curEdu.WeekSchool / budgetEdu.WeekSchool * 100).ToString("00.00") + "%";

            DataView.Rows[9].Cells[1].Value = "학생회지원비";
            DataView.Rows[9].Cells[2].Value = budgetEdu.Student.ToString("n0") + "원";
            DataView.Rows[9].Cells[4].Value = curEdu.Student.ToString("n0") + "원";
            DataView.Rows[9].Cells[6].Value = ((float)curEdu.Student / budgetEdu.Student * 100).ToString("00.00") + "%";

            DataView.Rows[10].Cells[1].Value = "청년부 지원비";
            DataView.Rows[10].Cells[2].Value = budgetEdu.YoungMan.ToString("n0") + "원";
            DataView.Rows[10].Cells[4].Value = curEdu.YoungMan.ToString("n0") + "원";
            DataView.Rows[10].Cells[6].Value = ((float)curEdu.YoungMan / budgetEdu.YoungMan * 100).ToString("00.00") + "%";

            DataView.Rows[11].Cells[1].Value = "장학금";
            DataView.Rows[11].Cells[2].Value = budgetEdu.ScholarShip.ToString("n0") + "원";
            DataView.Rows[11].Cells[4].Value = curEdu.ScholarShip.ToString("n0") + "원";
            DataView.Rows[11].Cells[6].Value = ((float)curEdu.ScholarShip / budgetEdu.ScholarShip * 100).ToString("00.00") + "%";

            DataView.Rows[12].Cells[1].Value = "도서비";
            DataView.Rows[12].Cells[2].Value = budgetEdu.Book.ToString("n0") + "원";
            DataView.Rows[12].Cells[4].Value = curEdu.Book.ToString("n0") + "원";
            DataView.Rows[12].Cells[6].Value = ((float)curEdu.Book / budgetEdu.Book * 100).ToString("00.00") + "%";

            // 인건비
            DataView.Rows[13].Cells[0].Value = "인건비";
            DataView.Rows[13].Cells[1].Value = "소계";
            DataView.Rows[13].Cells[3].Value = (budgetPerson.getSum()).ToString("n0") + "원";
            DataView.Rows[13].Cells[5].Value = (curPerson.getSum()).ToString("n0") + "원";
            DataView.Rows[13].Cells[6].Value = ((float)(curPerson.getSum())
                / (float)(budgetPerson.getSum())).ToString("00.00") + "%";

            DataView.Rows[14].Cells[1].Value = "목사님 사례비";
            DataView.Rows[14].Cells[2].Value = budgetPerson.Priest.ToString("n0") + "원";
            DataView.Rows[14].Cells[4].Value = curPerson.Priest.ToString("n0") + "원";
            DataView.Rows[14].Cells[6].Value = ((float)curPerson.Priest / budgetPerson.Priest * 100).ToString("00.00") + "%";

            DataView.Rows[15].Cells[1].Value = "전도사님 사례비";
            DataView.Rows[15].Cells[2].Value = budgetPerson.Missionary.ToString("n0") + "원";
            DataView.Rows[15].Cells[4].Value = curPerson.Missionary.ToString("n0") + "원";
            DataView.Rows[15].Cells[6].Value = ((float)curPerson.Missionary / budgetPerson.Missionary * 100).ToString("00.00") + "%";

            DataView.Rows[16].Cells[1].Value = "상여금";
            DataView.Rows[16].Cells[2].Value = budgetPerson.Bonus.ToString("n0") + "원";
            DataView.Rows[16].Cells[4].Value = curPerson.Bonus.ToString("n0") + "원";
            DataView.Rows[16].Cells[6].Value = ((float)curPerson.Bonus / budgetPerson.Bonus * 100).ToString("00.00") + "%";

            // 봉사비
            DataView.Rows[17].Cells[0].Value = "봉사비";
            DataView.Rows[17].Cells[1].Value = "소계";
            DataView.Rows[17].Cells[3].Value = (budgetService.getSum()).ToString("n0") + "원";
            DataView.Rows[17].Cells[5].Value = (curService.getSum()).ToString("n0") + "원";
            DataView.Rows[17].Cells[6].Value = ((float)(curService.getSum())
                / (float)(budgetService.getSum())).ToString("00.00") + "%";

            DataView.Rows[18].Cells[1].Value = "경조비";
            DataView.Rows[18].Cells[2].Value = budgetService.GyeongJo.ToString("n0") + "원";
            DataView.Rows[18].Cells[4].Value = curService.GyeongJo.ToString("n0") + "원";
            DataView.Rows[18].Cells[6].Value = ((float)curService.GyeongJo / budgetService.GyeongJo * 100).ToString("00.00") + "%";

            DataView.Rows[19].Cells[1].Value = "구제비";
            DataView.Rows[19].Cells[2].Value = budgetService.Saving.ToString("n0") + "원";
            DataView.Rows[19].Cells[4].Value = curService.Saving.ToString("n0") + "원";
            DataView.Rows[19].Cells[6].Value = ((float)curService.Saving / budgetService.Saving * 100).ToString("00.00") + "%";

            DataView.Rows[20].Cells[1].Value = "행사비";
            DataView.Rows[20].Cells[2].Value = budgetService.Events.ToString("n0") + "원";
            DataView.Rows[20].Cells[4].Value = curService.Events.ToString("n0") + "원";
            DataView.Rows[20].Cells[6].Value = ((float)curService.Events / budgetService.Events * 100).ToString("00.00") + "%";

            // 운영 관리비
            DataView.Rows[21].Cells[0].Value = "운영 관리비";
            DataView.Rows[21].Cells[1].Value = "소계";
            DataView.Rows[21].Cells[3].Value = (budgetManage.getSum()).ToString("n0") + "원";
            DataView.Rows[21].Cells[5].Value = (curManage.getSum()).ToString("n0") + "원";
            DataView.Rows[21].Cells[6].Value = ((float)(curManage.getSum())
                / (float)(budgetManage.getSum())).ToString("00.00") + "%";

            DataView.Rows[22].Cells[1].Value = "사택 유지비";
            DataView.Rows[22].Cells[2].Value = budgetManage.Home.ToString("n0") + "원";
            DataView.Rows[22].Cells[4].Value = curManage.Home.ToString("n0") + "원";
            DataView.Rows[22].Cells[6].Value = ((float)curManage.Home / budgetManage.Home * 100).ToString("00.00") + "%";

            DataView.Rows[23].Cells[1].Value = "교회 관리비";
            DataView.Rows[23].Cells[2].Value = budgetManage.Church.ToString("n0") + "원";
            DataView.Rows[23].Cells[4].Value = curManage.Church.ToString("n0") + "원";
            DataView.Rows[23].Cells[6].Value = ((float)curManage.Church / budgetManage.Church * 100).ToString("00.00") + "%";

            DataView.Rows[24].Cells[1].Value = "목회 활동비";
            DataView.Rows[24].Cells[2].Value = budgetManage.Ministry.ToString("n0") + "원";
            DataView.Rows[24].Cells[4].Value = curManage.Ministry.ToString("n0") + "원";
            DataView.Rows[24].Cells[6].Value = ((float)curManage.Ministry / budgetManage.Ministry * 100).ToString("00.00") + "%";

            DataView.Rows[25].Cells[1].Value = "수도 광열비";
            DataView.Rows[25].Cells[2].Value = budgetManage.Water.ToString("n0") + "원";
            DataView.Rows[25].Cells[4].Value = curManage.Water.ToString("n0") + "원";
            DataView.Rows[25].Cells[6].Value = ((float)curManage.Water / budgetManage.Water * 100).ToString("00.00") + "%";

            DataView.Rows[26].Cells[1].Value = "통신비";
            DataView.Rows[26].Cells[2].Value = budgetManage.Communication.ToString("n0") + "원";
            DataView.Rows[26].Cells[4].Value = curManage.Communication.ToString("n0") + "원";
            DataView.Rows[26].Cells[6].Value = ((float)curManage.Communication / budgetManage.Communication * 100).ToString("00.00") + "%";

            DataView.Rows[27].Cells[1].Value = "차량 관리비";
            DataView.Rows[27].Cells[2].Value = budgetManage.CarManage.ToString("n0") + "원";
            DataView.Rows[27].Cells[4].Value = curManage.CarManage.ToString("n0") + "원";
            DataView.Rows[27].Cells[6].Value = ((float)curManage.CarManage / budgetManage.CarManage * 100).ToString("00.00") + "%";

            DataView.Rows[28].Cells[1].Value = "차랑 구입비 정립";
            DataView.Rows[28].Cells[2].Value = budgetManage.CarBuy.ToString("n0") + "원";
            DataView.Rows[28].Cells[4].Value = curManage.CarBuy.ToString("n0") + "원";
            DataView.Rows[28].Cells[6].Value = ((float)curManage.CarBuy / budgetManage.CarBuy * 100).ToString("00.00") + "%";

            DataView.Rows[29].Cells[1].Value = "상회비";
            DataView.Rows[29].Cells[2].Value = budgetManage.Sang.ToString("n0") + "원";
            DataView.Rows[29].Cells[4].Value = curManage.Sang.ToString("n0") + "원";
            DataView.Rows[29].Cells[6].Value = ((float)curManage.Sang / budgetManage.Sang * 100).ToString("00.00") + "%";

            DataView.Rows[30].Cells[1].Value = "비품비";
            DataView.Rows[30].Cells[2].Value = budgetManage.Tool.ToString("n0") + "원";
            DataView.Rows[30].Cells[4].Value = curManage.Tool.ToString("n0") + "원";
            DataView.Rows[30].Cells[6].Value = ((float)curManage.Tool / budgetManage.Tool * 100).ToString("00.00") + "%";

            DataView.Rows[31].Cells[1].Value = "기타 지출비";
            DataView.Rows[31].Cells[2].Value = budgetManage.Etc.ToString("n0") + "원";
            DataView.Rows[31].Cells[4].Value = curManage.Etc.ToString("n0") + "원";
            DataView.Rows[31].Cells[6].Value = ((float)curManage.Etc / budgetManage.Etc * 100).ToString("00.00") + "%";

            // 대출 관련비
            DataView.Rows[32].Cells[0].Value = "대출 관련비";
            DataView.Rows[32].Cells[1].Value = "소계";
            DataView.Rows[32].Cells[3].Value = (budgetLoan.getSum()).ToString("n0") + "원";
            DataView.Rows[32].Cells[5].Value = (curLoan.getSum()).ToString("n0") + "원";
            DataView.Rows[32].Cells[6].Value = ((float)(curLoan.getSum())
                / (float)(budgetLoan.getSum())).ToString("00.00") + "%";

            DataView.Rows[33].Cells[1].Value = "상환적립";
            DataView.Rows[33].Cells[2].Value = budgetLoan.Repayment.ToString("n0") + "원";
            DataView.Rows[33].Cells[4].Value = curLoan.Repayment.ToString("n0") + "원";
            DataView.Rows[33].Cells[6].Value = ((float)curLoan.Repayment / budgetLoan.Repayment * 100).ToString("00.00") + "%";

            DataView.Rows[34].Cells[1].Value = "지급이자";
            DataView.Rows[34].Cells[2].Value = budgetLoan.Interest.ToString("n0") + "원";
            DataView.Rows[34].Cells[4].Value = curLoan.Interest.ToString("n0") + "원";
            DataView.Rows[34].Cells[6].Value = ((float)curLoan.Interest / budgetLoan.Interest * 100).ToString("00.00") + "%";

            // 예비비
            DataView.Rows[35].Cells[0].Value = "예비비";
            DataView.Rows[35].Cells[3].Value = budgetPrepare.ToString("n0") + "원";
            DataView.Rows[35].Cells[5].Value = curPrepare.ToString("n0") + "원";
            DataView.Rows[35].Cells[6].Value = ((float)curPrepare / budgetPrepare * 100).ToString("00.00") + "%";

            // 합계
            DataView.Rows[36].Cells[0].Value = "합계";
            DataView.Rows[36].Cells[3].Value = (budgetPray.getSum() + budgetMissionWork.getSum() + budgetEdu.getSum() + budgetPerson.getSum()
                + budgetService.getSum() + budgetManage.getSum() + budgetLoan.getSum() + budgetPrepare).ToString("n0") + "원";
            DataView.Rows[36].Cells[5].Value = (curPray.getSum() + curMissionWork.getSum() + curEdu.getSum() + curPerson.getSum()
                + curService.getSum() + curManage.getSum() + curLoan.getSum() + curPrepare).ToString("n0") + "원";
            DataView.Rows[36].Cells[6].Value = ((float)(curPray.getSum() + curMissionWork.getSum() + curEdu.getSum() + curPerson.getSum()
                + curService.getSum() + curManage.getSum() + curLoan.getSum() + curPrepare)
                / (float)(budgetPray.getSum() + budgetMissionWork.getSum() + budgetEdu.getSum() + budgetPerson.getSum()
                + budgetService.getSum() + budgetManage.getSum() + budgetLoan.getSum() + budgetPrepare) * 100).ToString("00.00") + "%";
        }

        /// <summary>
        /// Paint
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SpendDetail_Paint(object sender, PaintEventArgs e)
        {
            inputData();
        }
    }

    #region 각 항목별 구조체

    /// <summary>
    /// 예배비
    /// </summary>
    public class Pray
    {
        #region 변수 선언

        /// <summary>
        /// 강단 꽃꽃이
        /// </summary>
        private int flower;
        /// <summary>
        /// 성가대 운영비
        /// </summary>
        private int singer;
        /// <summary>
        /// 주보대
        /// </summary>
        private int jubo;

        #endregion

        #region get / set

        public int Flower
        {
            get
            {
                return flower;
            }

            set
            {
                flower = value;
            }
        }

        public int Singer
        {
            get
            {
                return singer;
            }

            set
            {
                singer = value;
            }
        }

        public int Jubo
        {
            get
            {
                return jubo;
            }

            set
            {
                jubo = value;
            }
        }

        #endregion

        public int getSum()
        {
            return flower + singer + jubo;
        }
    }

    /// <summary>
    /// 선교비
    /// </summary>
    public class MissionWork
    {
        #region 변수 선언

        /// <summary>
        /// 선교비
        /// </summary>
        private int misson;
        /// <summary>
        /// 심방비
        /// </summary>
        private int visit;
        
        #endregion

        #region get / set

        public int Misson
        {
            get
            {
                return misson;
            }

            set
            {
                misson = value;
            }
        }

        public int Visit
        {
            get
            {
                return visit;
            }

            set
            {
                visit = value;
            }
        }

        

        #endregion

        public int getSum()
        {
            return misson + visit;
        }
    }

    /// <summary>
    /// 교육비
    /// </summary>
    public class Education
    {
        #region 변수 선언

        /// <summary>
        /// 주일학교 지원비
        /// </summary>
        private int weekSchool;
        /// <summary>
        /// 학생회 지원비
        /// </summary>
        private int student;
        /// <summary>
        /// 청년부 지원비
        /// </summary>
        private int youngMan;
        /// <summary>
        /// 장학금
        /// </summary>
        private int scholarShip;
        /// <summary>
        /// 도서비
        /// </summary>
        private int book;

        #endregion

        #region get / set 

        public int WeekSchool
        {
            get
            {
                return weekSchool;
            }

            set
            {
                weekSchool = value;
            }
        }

        public int Student
        {
            get
            {
                return student;
            }

            set
            {
                student = value;
            }
        }

        public int YoungMan
        {
            get
            {
                return youngMan;
            }

            set
            {
                youngMan = value;
            }
        }

        public int ScholarShip
        {
            get
            {
                return scholarShip;
            }

            set
            {
                scholarShip = value;
            }
        }

        public int Book
        {
            get
            {
                return book;
            }

            set
            {
                book = value;
            }
        }

        #endregion

        public int getSum()
        {
            return weekSchool + student + youngMan + scholarShip + book;
        }
    }

    /// <summary>
    /// 인건비
    /// </summary>
    public class Person
    {
        #region 변수 선언

        /// <summary>
        /// 목사님 사례비
        /// </summary>
        private int priest;
        /// <summary>
        /// 전도사님 사례비
        /// </summary>
        private int missionary;
        /// <summary>
        /// 상여금
        /// </summary>
        private int bonus;

        #endregion

        #region get / set

        public int Priest
        {
            get
            {
                return priest;
            }

            set
            {
                priest = value;
            }
        }

        public int Missionary
        {
            get
            {
                return missionary;
            }

            set
            {
                missionary = value;
            }
        }

        public int Bonus
        {
            get
            {
                return bonus;
            }

            set
            {
                bonus = value;
            }
        }

        #endregion

        public int getSum()
        {
            return priest + missionary + bonus;
        }
    }

    /// <summary>
    /// 봉사비
    /// </summary>
    public class Service
    {
        #region 변수 선언

        /// <summary>
        /// 경조비
        /// </summary>
        private int gyeongJo;
        /// <summary>
        /// 구제비
        /// </summary>
        private int saving;
        /// <summary>
        /// 행사비
        /// </summary>
        private int events;

        #endregion

        #region get /set

        public int GyeongJo
        {
            get
            {
                return gyeongJo;
            }

            set
            {
                gyeongJo = value;
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
            }
        }

        public int Events
        {
            get
            {
                return events;
            }

            set
            {
                events = value;
            }
        }

        #endregion

        public int getSum()
        {
            return gyeongJo + saving + events;
        }
    }

    /// <summary>
    /// 운영 관리비
    /// </summary>
    public class Manage
    {

        #region 변수 선언

        /// <summary>
        /// 사택 유지비
        /// </summary>
        private int home;

        /// <summary>
        /// 교회 관리비
        /// </summary>
        private int church;

        /// <summary>
        /// 목회 활동비
        /// </summary>
        private int ministry;

        /// <summary>
        /// 수도 광열비
        /// </summary>
        private int water;

        /// <summary>
        /// 통신비
        /// </summary>
        private int communication;

        /// <summary>
        /// 차량 관리비
        /// </summary>
        private int carManage;

        /// <summary>
        /// 차량 구입비 정립
        /// </summary>
        private int carBuy;

        /// <summary>
        /// 상회비
        /// </summary>
        private int sang;

        /// <summary>
        /// 비품비
        /// </summary>
        private int tool;

        /// <summary>
        /// 기타 공과잡비
        /// </summary>
        private int etc;

        #endregion

        #region get / set

        public int Home
        {
            get
            {
                return home;
            }

            set
            {
                home = value;
            }
        }

        public int Church
        {
            get
            {
                return church;
            }

            set
            {
                church = value;
            }
        }

        public int Ministry
        {
            get
            {
                return ministry;
            }

            set
            {
                ministry = value;
            }
        }

        public int Water
        {
            get
            {
                return water;
            }

            set
            {
                water = value;
            }
        }

        public int Communication
        {
            get
            {
                return communication;
            }

            set
            {
                communication = value;
            }
        }

        public int CarManage
        {
            get
            {
                return carManage;
            }

            set
            {
                carManage = value;
            }
        }

        public int CarBuy
        {
            get
            {
                return carBuy;
            }

            set
            {
                carBuy = value;
            }
        }

        public int Tool
        {
            get
            {
                return tool;
            }

            set
            {
                tool = value;
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
            }
        }

        public int Sang
        {
            get
            {
                return sang;
            }

            set
            {
                sang = value;
            }
        }

        #endregion

        public int getSum()
        {
            return home + church + ministry + water + communication + carManage + carBuy + sang + tool + etc;
        }

    }

    /// <summary>
    /// 대출 관련비
    /// </summary>
    public class Loan
    {
        #region 변수 선언

        /// <summary>
        /// 상환 적립금
        /// </summary>
        private int repayment;

        /// <summary>
        /// 지급 이자
        /// </summary>
        private int interest;

        #endregion

        #region get / set

        public int Repayment
        {
            get
            {
                return repayment;
            }

            set
            {
                repayment = value;
            }
        }

        public int Interest
        {
            get
            {
                return interest;
            }

            set
            {
                interest = value;
            }
        }

        #endregion

        public int getSum()
        {
            return repayment + interest;
        }
    }
    #endregion
}
