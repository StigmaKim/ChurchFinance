using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Diagnostics;

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

        private SQLite SQLite;
        public PrintDocument pd;
        private PageSettings pgSettings;
        private Button printBtn;
        DateTime date;

        /// <summary>
        /// 생성자
        /// </summary>
        public SpendDetail(Button btn)
        {
            InitializeComponent();
            SQLite = new SQLite();
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

            printBtn = btn;

            // 표 설정
            setView();

            Paint += SpendDetail_Paint;
        }

        public void SetDate(DateTime d)
        {
            date = d;
        }

        /// <summary>
        /// DataGridView 설정
        /// </summary>
        private void setView()
        {
            this.BackColor = Color.White;

            // 행 갯수와 Alignment
            DataView.Location = new Point(60, 40);
            DataView.Size = new Size(860, 452);
            DataView.ColumnCount = 7;

            DataView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DataView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataView.Font = new Font("Microsoft Sans Serif", 12);
            DataView.RowTemplate.Height = 30;

            // 컬럼 헤더
            DataView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            DataView.ColumnHeadersHeight = 30;
            DataView.ReadOnly = true;

            DataView.Columns[0].HeaderText = "항목";
            DataView.Columns[1].HeaderText = "세목";
            DataView.Columns[3].HeaderText = "예산";
            DataView.Columns[5].HeaderText = "지출";
            DataView.Columns[6].HeaderText = "진도비";
            DataView.AllowUserToAddRows = false;

            DataView.Columns[0].Width = 100;
            DataView.Columns[1].Width = 130;
            DataView.Columns[2].Width = 130;
            DataView.Columns[3].Width = 130;
            DataView.Columns[4].Width = 130;
            DataView.Columns[5].Width = 130;
            DataView.Columns[6].Width = 90;
            /*
            for (int i = 0; i < DataView.ColumnCount; i++)
                DataView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                */

            for (int i = 0; i < DataView.ColumnCount; i++)
                DataView.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

            DataView.RowCount = 37;
            DataView.Rows[0].DefaultCellStyle.BackColor = Color.Lavender;
            DataView.Rows[7].DefaultCellStyle.BackColor = Color.Lavender;
            DataView.Rows[4].DefaultCellStyle.BackColor = Color.Lavender;
            DataView.Rows[13].DefaultCellStyle.BackColor = Color.Lavender;
            DataView.Rows[17].DefaultCellStyle.BackColor = Color.Lavender;
            DataView.Rows[21].DefaultCellStyle.BackColor = Color.Lavender;
            DataView.Rows[32].DefaultCellStyle.BackColor = Color.Lavender;
            DataView.Rows[35].DefaultCellStyle.BackColor = Color.Lavender;
            DataView.Rows[36].DefaultCellStyle.BackColor = Color.Lavender;

            DataView.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            DataView.Columns[0].DefaultCellStyle.Padding = new Padding(5, 0, 0, 0);
            DataView.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            DataView.Columns[1].DefaultCellStyle.Padding = new Padding(5, 0, 0, 0);
            DataView.RowHeadersVisible = false;

            DataView.SelectionChanged += DataView_SelectionChanged;
            DataView.ClearSelection();

            // 프린트 관련 변수 및 이벤트 연결
            pd = new PrintDocument();
            pgSettings = new PageSettings();
            pd.PrintPage += Pd_PrintPage;

        }

        private void DataView_SelectionChanged(object sender, EventArgs e)
        {
            DataView.ClearSelection();
        }

        public void SetValueFromDB()
        {
            DataSet ds = SQLite.ExecuteSelectQuery(string.Format("select * from Budget2_" + date.Year));
            Debug.WriteLine("Why");
            budgetPray.Flower = Convert.ToInt32(ds.Tables[0].Rows[0]["amount"]);
            budgetPray.Singer = Convert.ToInt32(ds.Tables[0].Rows[1]["amount"]); ;
            budgetPray.Jubo = Convert.ToInt32(ds.Tables[0].Rows[2]["amount"]); ;
            budgetMissionWork.Misson = Convert.ToInt32(ds.Tables[0].Rows[3]["amount"]); ;
            budgetMissionWork.Visit = Convert.ToInt32(ds.Tables[0].Rows[4]["amount"]); ;
            budgetEdu.WeekSchool = Convert.ToInt32(ds.Tables[0].Rows[5]["amount"]); ;
            budgetEdu.Student = Convert.ToInt32(ds.Tables[0].Rows[6]["amount"]); ;
            budgetEdu.YoungMan = Convert.ToInt32(ds.Tables[0].Rows[7]["amount"]); ;
            budgetEdu.ScholarShip = Convert.ToInt32(ds.Tables[0].Rows[8]["amount"]); ;
            budgetEdu.Book = Convert.ToInt32(ds.Tables[0].Rows[9]["amount"]); ;
            budgetPerson.Priest = Convert.ToInt32(ds.Tables[0].Rows[10]["amount"]); ;
            budgetPerson.Missionary = Convert.ToInt32(ds.Tables[0].Rows[11]["amount"]); ;
            budgetPerson.Bonus = Convert.ToInt32(ds.Tables[0].Rows[12]["amount"]); ;
            budgetService.GyeongJo = Convert.ToInt32(ds.Tables[0].Rows[13]["amount"]); ;
            budgetService.Saving = Convert.ToInt32(ds.Tables[0].Rows[14]["amount"]); ;
            budgetService.Events = Convert.ToInt32(ds.Tables[0].Rows[15]["amount"]); ;
            budgetManage.Home = Convert.ToInt32(ds.Tables[0].Rows[16]["amount"]); ;
            budgetManage.Church = Convert.ToInt32(ds.Tables[0].Rows[17]["amount"]); ;
            budgetManage.Ministry = Convert.ToInt32(ds.Tables[0].Rows[18]["amount"]); ;
            budgetManage.Water = Convert.ToInt32(ds.Tables[0].Rows[19]["amount"]); ;
            budgetManage.Communication = Convert.ToInt32(ds.Tables[0].Rows[20]["amount"]); ;
            budgetManage.CarManage = Convert.ToInt32(ds.Tables[0].Rows[21]["amount"]); ;
            budgetManage.CarBuy = Convert.ToInt32(ds.Tables[0].Rows[22]["amount"]); ;
            budgetManage.Sang = Convert.ToInt32(ds.Tables[0].Rows[23]["amount"]); ;
            budgetManage.Tool = Convert.ToInt32(ds.Tables[0].Rows[24]["amount"]); ;
            budgetManage.Etc = Convert.ToInt32(ds.Tables[0].Rows[25]["amount"]); ;
            budgetLoan.Repayment = Convert.ToInt32(ds.Tables[0].Rows[26]["amount"]); ;
            budgetLoan.Interest = Convert.ToInt32(ds.Tables[0].Rows[27]["amount"]); ;
            budgetPrepare = Convert.ToInt32(ds.Tables[0].Rows[28]["amount"]); ;

            ds = SQLite.ExecuteSelectQuery(string.Format("select amount from Spending_Worship " +
                 "where strftime('%Y-%m', date) = '{0}'", string.Format(date.Year.ToString() + "-" + date.Month.ToString("d2"))));
            curPray.Flower = Convert.ToInt32(ds.Tables[0].Rows[0]["amount"]);
            curPray.Singer = Convert.ToInt32(ds.Tables[0].Rows[1]["amount"]);
            curPray.Jubo = Convert.ToInt32(ds.Tables[0].Rows[2]["amount"]);

            ds = SQLite.ExecuteSelectQuery(string.Format("select amount from Spending_Mission " +
                 "where strftime('%Y-%m', date) = '{0}'", string.Format(date.Year.ToString() + "-" + date.Month.ToString("d2"))));
            curMissionWork.Misson = Convert.ToInt32(ds.Tables[0].Rows[0]["amount"]);
            curMissionWork.Visit = Convert.ToInt32(ds.Tables[0].Rows[1]["amount"]);

            ds = SQLite.ExecuteSelectQuery(string.Format("select amount from Spending_Edu " +
                 "where strftime('%Y-%m', date) = '{0}'", string.Format(date.Year.ToString() + "-" + date.Month.ToString("d2"))));
            curEdu.WeekSchool = Convert.ToInt32(ds.Tables[0].Rows[0]["amount"]);
            curEdu.Student = Convert.ToInt32(ds.Tables[0].Rows[1]["amount"]);
            curEdu.YoungMan = Convert.ToInt32(ds.Tables[0].Rows[2]["amount"]);
            curEdu.ScholarShip = Convert.ToInt32(ds.Tables[0].Rows[3]["amount"]);
            curEdu.Book = Convert.ToInt32(ds.Tables[0].Rows[4]["amount"]);

            ds = SQLite.ExecuteSelectQuery(string.Format("select amount from Spending_Human " +
                 "where strftime('%Y-%m', date) = '{0}'", string.Format(date.Year.ToString() + "-" + date.Month.ToString("d2"))));
            curPerson.Priest = Convert.ToInt32(ds.Tables[0].Rows[0]["amount"]);
            curPerson.Missionary = Convert.ToInt32(ds.Tables[0].Rows[1]["amount"]);
            curPerson.Bonus = Convert.ToInt32(ds.Tables[0].Rows[2]["amount"]);

            ds = SQLite.ExecuteSelectQuery(string.Format("select amount from Spending_Vol " +
                 "where strftime('%Y-%m', date) = '{0}'", string.Format(date.Year.ToString() + "-" + date.Month.ToString("d2"))));
            curService.GyeongJo = Convert.ToInt32(ds.Tables[0].Rows[0]["amount"]);
            curService.Saving = Convert.ToInt32(ds.Tables[0].Rows[1]["amount"]);
            curService.Events = Convert.ToInt32(ds.Tables[0].Rows[2]["amount"]);

            ds = SQLite.ExecuteSelectQuery(string.Format("select amount from Spending_Main " +
                 "where strftime('%Y-%m', date) = '{0}'", string.Format(date.Year.ToString() + "-" + date.Month.ToString("d2"))));
            curManage.Home = Convert.ToInt32(ds.Tables[0].Rows[0]["amount"]);
            curManage.Church = Convert.ToInt32(ds.Tables[0].Rows[1]["amount"]);
            curManage.Ministry = Convert.ToInt32(ds.Tables[0].Rows[2]["amount"]);
            curManage.Water = Convert.ToInt32(ds.Tables[0].Rows[3]["amount"]);
            curManage.Communication = Convert.ToInt32(ds.Tables[0].Rows[4]["amount"]);
            curManage.CarManage = Convert.ToInt32(ds.Tables[0].Rows[5]["amount"]);
            curManage.CarBuy = Convert.ToInt32(ds.Tables[0].Rows[6]["amount"]);
            curManage.Sang = Convert.ToInt32(ds.Tables[0].Rows[7]["amount"]);
            curManage.Tool = Convert.ToInt32(ds.Tables[0].Rows[8]["amount"]);
            curManage.Etc = Convert.ToInt32(ds.Tables[0].Rows[9]["amount"]);

            ds = SQLite.ExecuteSelectQuery(string.Format("select amount from Spending_Loan " +
                 "where strftime('%Y-%m', date) = '{0}'", string.Format(date.Year.ToString() + "-" + date.Month.ToString("d2"))));
            curLoan.Repayment = Convert.ToInt32(ds.Tables[0].Rows[0]["amount"]);
            curLoan.Interest = Convert.ToInt32(ds.Tables[0].Rows[1]["amount"]);

            ds = SQLite.ExecuteSelectQuery(string.Format("select amount from Spending_Res " +
                 "where strftime('%Y-%m', date) = '{0}'", string.Format(date.Year.ToString() + "-" + date.Month.ToString("d2"))));
            int sum = 0;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                sum += Convert.ToInt32(ds.Tables[0].Rows[i]["amount"]);

            curPrepare = sum;
            inputData();
        }

        #region 프린터 인쇄 처리

        /// <summary>
        /// 프린트 출력
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            Bitmap tapBM = new Bitmap(pgSettings.PaperSize.Width, pgSettings.PaperSize.Height);

            // 사이즈 임시 저장
            Size tempSz = DataView.Size;

            // 높이에 맞는 사이즈 설정
            DataView.Size = new Size(tempSz.Width, 875);

            DataView.DrawToBitmap(tapBM, new Rectangle(new Point(0, 0), new Size(pgSettings.PaperSize.Width, pgSettings.PaperSize.Height)));

            e.Graphics.DrawImage(tapBM, new Point(5, 5));

            DataView.Size = tempSz;
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog dig = new PrintPreviewDialog();

            dig.Document = pd;

            dig.ShowDialog();
        }

        #endregion

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
            if (curPray.getSum() == 0 || budgetPray.getSum() == 0)
                DataView.Rows[0].Cells[6].Value = 0.ToString("0.00") + "%";
            else
                DataView.Rows[0].Cells[6].Value = ((float)(curPray.getSum())
                    / (float)(budgetPray.getSum()) * 100).ToString("0.00") + "%";

            DataView.Rows[1].Cells[1].Value = "강단꽃꽃이";
            DataView.Rows[1].Cells[2].Value = budgetPray.Flower.ToString("n0") + "원";
            DataView.Rows[1].Cells[4].Value = curPray.Flower.ToString("n0") + "원";
            if (curPray.Flower == 0 || budgetPray.Flower == 0)
                DataView.Rows[1].Cells[6].Value = 0.ToString("0.00") + "%";
            else
                DataView.Rows[1].Cells[6].Value = ((float)curPray.Flower / budgetPray.Flower * 100).ToString("0.00") + "%";

            DataView.Rows[2].Cells[1].Value = "성가대운영비";
            DataView.Rows[2].Cells[2].Value = budgetPray.Singer.ToString("n0") + "원";
            DataView.Rows[2].Cells[4].Value = curPray.Singer.ToString("n0") + "원";
            if (curPray.Singer == 0 || budgetPray.Singer == 0)
                DataView.Rows[2].Cells[6].Value = 0.ToString("0.00") + "%";
            else
                DataView.Rows[2].Cells[6].Value = ((float)curPray.Singer / budgetPray.Singer * 100).ToString("0.00") + "%";

            DataView.Rows[3].Cells[1].Value = "주보대";
            DataView.Rows[3].Cells[2].Value = budgetPray.Jubo.ToString("n0") + "원";
            DataView.Rows[3].Cells[4].Value = curPray.Jubo.ToString("n0") + "원";
            if (curPray.Jubo == 0 || budgetPray.Jubo == 0)
                DataView.Rows[3].Cells[6].Value = 0.ToString("0.00") + "%";
            else
                DataView.Rows[3].Cells[6].Value = ((float)curPray.Jubo / budgetPray.Jubo * 100).ToString("0.00") + "%";

            // 선교비
            DataView.Rows[4].Cells[0].Value = "선교비";
            DataView.Rows[4].Cells[1].Value = "소계";
            DataView.Rows[4].Cells[3].Value = (budgetMissionWork.getSum()).ToString("n0") + "원";
            DataView.Rows[4].Cells[5].Value = (curMissionWork.getSum()).ToString("n0") + "원";
            if (curMissionWork.getSum() == 0 || budgetMissionWork.getSum() == 0)
                DataView.Rows[4].Cells[6].Value = 0.ToString("0.00") + "%";
            else
                DataView.Rows[4].Cells[6].Value = ((float)(curMissionWork.getSum())
                    / (float)(budgetMissionWork.getSum()) * 100).ToString("0.00") + "%";

            DataView.Rows[5].Cells[1].Value = "선교비";
            DataView.Rows[5].Cells[2].Value = budgetMissionWork.Misson.ToString("n0") + "원";
            DataView.Rows[5].Cells[4].Value = curMissionWork.Misson.ToString("n0") + "원";
            if (curMissionWork.Misson == 0 || budgetMissionWork.Misson == 0)
                DataView.Rows[5].Cells[6].Value = 0.ToString("0.00") + "%";
            else
                DataView.Rows[5].Cells[6].Value = ((float)curMissionWork.Misson / budgetMissionWork.Misson * 100).ToString("0.00") + "%";

            DataView.Rows[6].Cells[1].Value = "심방비";
            DataView.Rows[6].Cells[2].Value = budgetMissionWork.Visit.ToString("n0") + "원";
            DataView.Rows[6].Cells[4].Value = curMissionWork.Visit.ToString("n0") + "원";
            if (curMissionWork.Visit == 0 || budgetMissionWork.Visit == 0)
                DataView.Rows[6].Cells[6].Value = 0.ToString("0.00") + "%";
            else
                DataView.Rows[6].Cells[6].Value = ((float)curMissionWork.Visit / budgetMissionWork.Visit * 100).ToString("0.00") + "%";

            // 교육비
            DataView.Rows[7].Cells[0].Value = "교육비";
            DataView.Rows[7].Cells[1].Value = "소계";
            DataView.Rows[7].Cells[3].Value = (budgetEdu.getSum()).ToString("n0") + "원";
            DataView.Rows[7].Cells[5].Value = (curEdu.getSum()).ToString("n0") + "원";
            if (curPray.getSum() == 0 || budgetPray.getSum() == 0)
                DataView.Rows[7].Cells[6].Value = 0.ToString("0.00") + "%";
            else
                DataView.Rows[7].Cells[6].Value = ((float)(curEdu.getSum())
                    / (float)(budgetEdu.getSum()) * 100).ToString("0.00") + "%";

            DataView.Rows[8].Cells[1].Value = "주일학교지원비";
            DataView.Rows[8].Cells[2].Value = budgetEdu.WeekSchool.ToString("n0") + "원";
            DataView.Rows[8].Cells[4].Value = curEdu.WeekSchool.ToString("n0") + "원";
            if (curEdu.WeekSchool == 0 || budgetEdu.WeekSchool == 0)
                DataView.Rows[8].Cells[6].Value = 0.ToString("0.00") + "%";
            else
                DataView.Rows[8].Cells[6].Value = ((float)curEdu.WeekSchool / budgetEdu.WeekSchool * 100).ToString("0.00") + "%";

            DataView.Rows[9].Cells[1].Value = "학생부지원비";
            DataView.Rows[9].Cells[2].Value = budgetEdu.Student.ToString("n0") + "원";
            DataView.Rows[9].Cells[4].Value = curEdu.Student.ToString("n0") + "원";
            if (curEdu.Student == 0 || budgetEdu.Student == 0)
                DataView.Rows[9].Cells[6].Value = 0.ToString("0.00") + "%";
            else
                DataView.Rows[9].Cells[6].Value = ((float)curEdu.Student / budgetEdu.Student * 100).ToString("0.00") + "%";

            DataView.Rows[10].Cells[1].Value = "청년부지원비";
            DataView.Rows[10].Cells[2].Value = budgetEdu.YoungMan.ToString("n0") + "원";
            DataView.Rows[10].Cells[4].Value = curEdu.YoungMan.ToString("n0") + "원";
            if (curEdu.YoungMan == 0 || budgetEdu.YoungMan == 0)
                DataView.Rows[10].Cells[6].Value = 0.ToString("0.00") + "%";
            else
                DataView.Rows[10].Cells[6].Value = ((float)curEdu.YoungMan / budgetEdu.YoungMan * 100).ToString("0.00") + "%";

            DataView.Rows[11].Cells[1].Value = "장학금";
            DataView.Rows[11].Cells[2].Value = budgetEdu.ScholarShip.ToString("n0") + "원";
            DataView.Rows[11].Cells[4].Value = curEdu.ScholarShip.ToString("n0") + "원";
            if (curEdu.ScholarShip == 0 || budgetEdu.ScholarShip == 0)
                DataView.Rows[11].Cells[6].Value = 0.ToString("0.00") + "%";
            else
                DataView.Rows[11].Cells[6].Value = ((float)curEdu.ScholarShip / budgetEdu.ScholarShip * 100).ToString("0.00") + "%";

            DataView.Rows[12].Cells[1].Value = "도서비";
            DataView.Rows[12].Cells[2].Value = budgetEdu.Book.ToString("n0") + "원";
            DataView.Rows[12].Cells[4].Value = curEdu.Book.ToString("n0") + "원";
            if (curEdu.Book == 0 || budgetEdu.Book == 0)
                DataView.Rows[12].Cells[6].Value = 0.ToString("0.00") + "%";
            else
                DataView.Rows[12].Cells[6].Value = ((float)curEdu.Book / budgetEdu.Book * 100).ToString("0.00") + "%";

            // 인건비
            DataView.Rows[13].Cells[0].Value = "인건비";
            DataView.Rows[13].Cells[1].Value = "소계";
            DataView.Rows[13].Cells[3].Value = (budgetPerson.getSum()).ToString("n0") + "원";
            DataView.Rows[13].Cells[5].Value = (curPerson.getSum()).ToString("n0") + "원";
            if (curPerson.getSum() == 0 || budgetPerson.getSum() == 0)
                DataView.Rows[13].Cells[6].Value = 0.ToString("0.00") + "%";
            else
                DataView.Rows[13].Cells[6].Value = ((float)(curPerson.getSum())
                    / (float)(budgetPerson.getSum()) * 100).ToString("0.00") + "%";

            DataView.Rows[14].Cells[1].Value = "목사님사례비";
            DataView.Rows[14].Cells[2].Value = budgetPerson.Priest.ToString("n0") + "원";
            DataView.Rows[14].Cells[4].Value = curPerson.Priest.ToString("n0") + "원";
            if (curPerson.Priest == 0 || budgetPerson.Priest == 0)
                DataView.Rows[14].Cells[6].Value = 0.ToString("0.00") + "%";
            else
                DataView.Rows[14].Cells[6].Value = ((float)curPerson.Priest / budgetPerson.Priest * 100).ToString("0.00") + "%";

            DataView.Rows[15].Cells[1].Value = "전도사님사례비";
            DataView.Rows[15].Cells[2].Value = budgetPerson.Missionary.ToString("n0") + "원";
            DataView.Rows[15].Cells[4].Value = curPerson.Missionary.ToString("n0") + "원";
            if (curPerson.Missionary == 0 || budgetPerson.Missionary == 0)
                DataView.Rows[15].Cells[6].Value = 0.ToString("0.00") + "%";
            else
                DataView.Rows[15].Cells[6].Value = ((float)curPerson.Missionary / budgetPerson.Missionary * 100).ToString("0.00") + "%";

            DataView.Rows[16].Cells[1].Value = "상여금";
            DataView.Rows[16].Cells[2].Value = budgetPerson.Bonus.ToString("n0") + "원";
            DataView.Rows[16].Cells[4].Value = curPerson.Bonus.ToString("n0") + "원";
            if (curPerson.Bonus == 0 || budgetPerson.Bonus == 0)
                DataView.Rows[16].Cells[6].Value = 0.ToString("0.00") + "%";
            else
                DataView.Rows[16].Cells[6].Value = ((float)curPerson.Bonus / budgetPerson.Bonus * 100).ToString("0.00") + "%";

            // 봉사비
            DataView.Rows[17].Cells[0].Value = "봉사비";
            DataView.Rows[17].Cells[1].Value = "소계";
            DataView.Rows[17].Cells[3].Value = (budgetService.getSum()).ToString("n0") + "원";
            DataView.Rows[17].Cells[5].Value = (curService.getSum()).ToString("n0") + "원";
            if (curService.getSum() == 0 || budgetService.getSum() == 0)
                DataView.Rows[17].Cells[6].Value = 0.ToString("0.00") + "%";
            else
                DataView.Rows[17].Cells[6].Value = ((float)(curService.getSum())
                    / (float)(budgetService.getSum()) * 100).ToString("0.00") + "%";

            DataView.Rows[18].Cells[1].Value = "경조비";
            DataView.Rows[18].Cells[2].Value = budgetService.GyeongJo.ToString("n0") + "원";
            DataView.Rows[18].Cells[4].Value = curService.GyeongJo.ToString("n0") + "원";
            if (curService.GyeongJo == 0 || budgetService.GyeongJo == 0)
                DataView.Rows[18].Cells[6].Value = 0.ToString("0.00") + "%";
            else
                DataView.Rows[18].Cells[6].Value = ((float)curService.GyeongJo / budgetService.GyeongJo * 100).ToString("0.00") + "%";

            DataView.Rows[19].Cells[1].Value = "구제비";
            DataView.Rows[19].Cells[2].Value = budgetService.Saving.ToString("n0") + "원";
            DataView.Rows[19].Cells[4].Value = curService.Saving.ToString("n0") + "원";
            if (curService.Saving == 0 || budgetService.Saving == 0)
                DataView.Rows[19].Cells[6].Value = 0.ToString("0.00") + "%";
            else
                DataView.Rows[19].Cells[6].Value = ((float)curService.Saving / budgetService.Saving * 100).ToString("0.00") + "%";

            DataView.Rows[20].Cells[1].Value = "행사비";
            DataView.Rows[20].Cells[2].Value = budgetService.Events.ToString("n0") + "원";
            DataView.Rows[20].Cells[4].Value = curService.Events.ToString("n0") + "원";
            if (curService.Events == 0 || budgetService.Events == 0)
                DataView.Rows[20].Cells[6].Value = 0.ToString("0.00") + "%";
            else
                DataView.Rows[20].Cells[6].Value = ((float)curService.Events / budgetService.Events * 100).ToString("0.00") + "%";

            // 운영 관리비
            DataView.Rows[21].Cells[0].Value = "운영관리비";
            DataView.Rows[21].Cells[1].Value = "소계";
            DataView.Rows[21].Cells[3].Value = (budgetManage.getSum()).ToString("n0") + "원";
            DataView.Rows[21].Cells[5].Value = (curManage.getSum()).ToString("n0") + "원";
            if (curManage.getSum() == 0 || budgetManage.getSum() == 0)
                DataView.Rows[21].Cells[6].Value = 0.ToString("0.00") + "%";
            else
                DataView.Rows[21].Cells[6].Value = ((float)(curManage.getSum())
                    / (float)(budgetManage.getSum()) * 100).ToString("0.00") + "%";

            DataView.Rows[22].Cells[1].Value = "사택유지비";
            DataView.Rows[22].Cells[2].Value = budgetManage.Home.ToString("n0") + "원";
            DataView.Rows[22].Cells[4].Value = curManage.Home.ToString("n0") + "원";
            if (curManage.Home == 0 || budgetManage.Home == 0)
                DataView.Rows[22].Cells[6].Value = 0.ToString("0.00") + "%";
            else
                DataView.Rows[22].Cells[6].Value = ((float)curManage.Home / budgetManage.Home * 100).ToString("0.00") + "%";

            DataView.Rows[23].Cells[1].Value = "교회관리비";
            DataView.Rows[23].Cells[2].Value = budgetManage.Church.ToString("n0") + "원";
            DataView.Rows[23].Cells[4].Value = curManage.Church.ToString("n0") + "원";
            if (curManage.Church == 0 || budgetManage.Church == 0)
                DataView.Rows[23].Cells[6].Value = 0.ToString("0.00") + "%";
            else
                DataView.Rows[23].Cells[6].Value = ((float)curManage.Church / budgetManage.Church * 100).ToString("0.00") + "%";

            DataView.Rows[24].Cells[1].Value = "목회활동비";
            DataView.Rows[24].Cells[2].Value = budgetManage.Ministry.ToString("n0") + "원";
            DataView.Rows[24].Cells[4].Value = curManage.Ministry.ToString("n0") + "원";
            if (curManage.Ministry == 0 || budgetManage.Ministry == 0)
                DataView.Rows[24].Cells[6].Value = 0.ToString("0.00") + "%";
            else
                DataView.Rows[24].Cells[6].Value = ((float)curManage.Ministry / budgetManage.Ministry * 100).ToString("0.00") + "%";

            DataView.Rows[25].Cells[1].Value = "수도광열비";
            DataView.Rows[25].Cells[2].Value = budgetManage.Water.ToString("n0") + "원";
            DataView.Rows[25].Cells[4].Value = curManage.Water.ToString("n0") + "원";
            if (curManage.Water == 0 || budgetManage.Water == 0)
                DataView.Rows[25].Cells[6].Value = 0.ToString("0.00") + "%";
            else
                DataView.Rows[25].Cells[6].Value = ((float)curManage.Water / budgetManage.Water * 100).ToString("0.00") + "%";

            DataView.Rows[26].Cells[1].Value = "통신비";
            DataView.Rows[26].Cells[2].Value = budgetManage.Communication.ToString("n0") + "원";
            DataView.Rows[26].Cells[4].Value = curManage.Communication.ToString("n0") + "원";
            if (curManage.Communication == 0 || budgetManage.Communication == 0)
                DataView.Rows[26].Cells[6].Value = 0.ToString("0.00") + "%";
            else
                DataView.Rows[26].Cells[6].Value = ((float)curManage.Communication / budgetManage.Communication * 100).ToString("0.00") + "%";

            DataView.Rows[27].Cells[1].Value = "차량관리비";
            DataView.Rows[27].Cells[2].Value = budgetManage.CarManage.ToString("n0") + "원";
            DataView.Rows[27].Cells[4].Value = curManage.CarManage.ToString("n0") + "원";
            if (curManage.CarManage == 0 || budgetManage.CarManage == 0)
                DataView.Rows[27].Cells[6].Value = 0.ToString("0.00") + "%";
            else
                DataView.Rows[27].Cells[6].Value = ((float)curManage.CarManage / budgetManage.CarManage * 100).ToString("0.00") + "%";

            DataView.Rows[28].Cells[1].Value = "차랑구입비적립";
            DataView.Rows[28].Cells[2].Value = budgetManage.CarBuy.ToString("n0") + "원";
            DataView.Rows[28].Cells[4].Value = curManage.CarBuy.ToString("n0") + "원";
            if (curManage.CarBuy == 0 || budgetManage.CarBuy == 0)
                DataView.Rows[28].Cells[6].Value = 0.ToString("0.00") + "%";
            else
                DataView.Rows[28].Cells[6].Value = ((float)curManage.CarBuy / budgetManage.CarBuy * 100).ToString("0.00") + "%";

            DataView.Rows[29].Cells[1].Value = "상회비";
            DataView.Rows[29].Cells[2].Value = budgetManage.Sang.ToString("n0") + "원";
            DataView.Rows[29].Cells[4].Value = curManage.Sang.ToString("n0") + "원";
            if (curManage.Sang == 0 || budgetManage.Sang == 0)
                DataView.Rows[29].Cells[6].Value = 0.ToString("0.00") + "%";
            else
                DataView.Rows[29].Cells[6].Value = ((float)curManage.Sang / budgetManage.Sang * 100).ToString("0.00") + "%";

            DataView.Rows[30].Cells[1].Value = "교회비품비";
            DataView.Rows[30].Cells[2].Value = budgetManage.Tool.ToString("n0") + "원";
            DataView.Rows[30].Cells[4].Value = curManage.Tool.ToString("n0") + "원";
            if (curManage.Tool == 0 || budgetManage.Tool == 0)
                DataView.Rows[30].Cells[6].Value = 0.ToString("0.00") + "%";
            else
                DataView.Rows[30].Cells[6].Value = ((float)curManage.Tool / budgetManage.Tool * 100).ToString("0.00") + "%";

            DataView.Rows[31].Cells[1].Value = "기타지출";
            DataView.Rows[31].Cells[2].Value = budgetManage.Etc.ToString("n0") + "원";
            DataView.Rows[31].Cells[4].Value = curManage.Etc.ToString("n0") + "원";
            if (curManage.Etc == 0 || budgetManage.Etc == 0)
                DataView.Rows[31].Cells[6].Value = 0.ToString("0.00") + "%";
            else
                DataView.Rows[31].Cells[6].Value = ((float)curManage.Etc / budgetManage.Etc * 100).ToString("0.00") + "%";

            // 대출 관련비
            DataView.Rows[32].Cells[0].Value = "대출관련비";
            DataView.Rows[32].Cells[1].Value = "소계";
            DataView.Rows[32].Cells[3].Value = (budgetLoan.getSum()).ToString("n0") + "원";
            DataView.Rows[32].Cells[5].Value = (curLoan.getSum()).ToString("n0") + "원";
            if (curLoan.getSum() == 0 || budgetLoan.getSum() == 0)
                DataView.Rows[32].Cells[6].Value = 0.ToString("0.00") + "%";
            else
                DataView.Rows[32].Cells[6].Value = ((float)(curLoan.getSum())
                    / (float)(budgetLoan.getSum()) * 100).ToString("0.00") + "%";

            DataView.Rows[33].Cells[1].Value = "상환적립";
            DataView.Rows[33].Cells[2].Value = budgetLoan.Repayment.ToString("n0") + "원";
            DataView.Rows[33].Cells[4].Value = curLoan.Repayment.ToString("n0") + "원";
            if (curLoan.Repayment == 0 || budgetLoan.Repayment == 0)
                DataView.Rows[33].Cells[6].Value = 0.ToString("0.00") + "%";
            else
                DataView.Rows[33].Cells[6].Value = ((float)curLoan.Repayment / budgetLoan.Repayment * 100).ToString("0.00") + "%";

            DataView.Rows[34].Cells[1].Value = "지급이자";
            DataView.Rows[34].Cells[2].Value = budgetLoan.Interest.ToString("n0") + "원";
            DataView.Rows[34].Cells[4].Value = curLoan.Interest.ToString("n0") + "원";
            if (curLoan.Interest == 0 || budgetLoan.Interest == 0)
                DataView.Rows[34].Cells[6].Value = 0.ToString("0.00") + "%";
            else
                DataView.Rows[34].Cells[6].Value = ((float)curLoan.Interest / budgetLoan.Interest * 100).ToString("0.00") + "%";

            // 예비비
            DataView.Rows[35].Cells[0].Value = "예비비";
            DataView.Rows[35].Cells[3].Value = budgetPrepare.ToString("n0") + "원";
            DataView.Rows[35].Cells[5].Value = curPrepare.ToString("n0") + "원";
            if (curPrepare == 0 || budgetPrepare == 0)
                DataView.Rows[35].Cells[6].Value = 0.ToString("0.00") + "%";
            else
                DataView.Rows[35].Cells[6].Value = ((float)curPrepare / budgetPrepare * 100).ToString("0.00") + "%";

            // 합계
            DataView.Rows[36].Cells[0].Value = "합계";
            DataView.Rows[36].Cells[3].Value = (budgetPray.getSum() + budgetMissionWork.getSum() + budgetEdu.getSum() + budgetPerson.getSum()
                + budgetService.getSum() + budgetManage.getSum() + budgetLoan.getSum() + budgetPrepare).ToString("n0") + "원";
            DataView.Rows[36].Cells[5].Value = (curPray.getSum() + curMissionWork.getSum() + curEdu.getSum() + curPerson.getSum()
                + curService.getSum() + curManage.getSum() + curLoan.getSum() + curPrepare).ToString("n0") + "원";
            if ((curPray.getSum() + curMissionWork.getSum() + curEdu.getSum() + curPerson.getSum()
                + curService.getSum() + curManage.getSum() + curLoan.getSum() + curPrepare) == 0 ||
                (budgetPray.getSum() + budgetMissionWork.getSum() + budgetEdu.getSum() + budgetPerson.getSum()
                + budgetService.getSum() + budgetManage.getSum() + budgetLoan.getSum() + budgetPrepare) == 0)
                DataView.Rows[36].Cells[6].Value = 0.ToString("0.00") + "%";
            else
                DataView.Rows[36].Cells[6].Value = ((float)(curPray.getSum() + curMissionWork.getSum() + curEdu.getSum() + curPerson.getSum()
                    + curService.getSum() + curManage.getSum() + curLoan.getSum() + curPrepare)
                    / (float)(budgetPray.getSum() + budgetMissionWork.getSum() + budgetEdu.getSum() + budgetPerson.getSum()
                    + budgetService.getSum() + budgetManage.getSum() + budgetLoan.getSum() + budgetPrepare) * 100).ToString("0.00") + "%";
        }

        /// <summary>
        /// Paint
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SpendDetail_Paint(object sender, PaintEventArgs e)
        {
            label1.Text = date.Year + "년 " + date.Month + "월 지출 세부 명세";
            label1.Location = new Point(350, 10);
            SetValueFromDB();
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

