using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing.Printing;

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
        /// 절기
        /// </summary>
        private int budgetTerm;

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
        private int term;
        /// <summary>
        /// 절기
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

        private int total;

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
        SQLite SQLite = null;

        #endregion

        #region get/set 메소드

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

        public int BudgetTerm
        {
            get
            {
                return budgetTerm;
            }

            set
            {
                budgetTerm = value;
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

        public int Region
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

        public int Term
        {
            get
            {
                return term;
            }

            set
            {
                term = value;
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

        private PageSettings pgSettings;
        private PrinterSettings prtSetting;

        public enum DMode
        {
            income,
            spend
        };

        /// <summary>
        /// 생성자
        /// </summary>
        public IncomeProgress(DMode drawMode, Button button2)
        {
            InitializeComponent();
            printDocument1.PrintPage += PrintDocument1_PrintPage;
            SQLite = new SQLite();

            mode = drawMode;

            Paint += IncomeProgress_Paint;
            
            date = DateTime.Now;
            
            title.Location = new Point(360, 10);
            titleInvalidate();

            if (mode == DMode.income)
            {
                AdditionalView.Visible = true;
                SumView.Visible = true;
                setAdditionalView();
                setSumView();
            }
            else if (mode == DMode.spend)
            {
                AdditionalView.Visible = false;
                SumView.Visible = false;
            }

            setViews();
            button2.Click += Button2_Click;

            pgSettings = new PageSettings();

        }
        public void titleInvalidate()
        {
            if (mode == DMode.income)
                title.Text = date.Year + "년 " + date.Month + "월 재정 수입 명세서";
            else if (mode == DMode.spend)
                title.Text = date.Year + "년 " + date.Month + "월 재정 지출 명세서";
        }

        /// <summary>
        /// DataView 추가 (영훈)
        /// </summary>
        
        public void setBudgetFromDB()
        {
            // 예산 데이터 입력
            DataSet ds = SQLite.ExecuteSelectQuery(string.Format("select amount from Budget_" + date.Year));
            if( ds.Tables.Count == 0 )
            {
                BudgetThanksOffering = 0;
                BudgetSipil = 0;
                BudgetRegion = 0;
                BudgetBuild = 0;
                BudgetMissionWork = 0;
                BudgetSungmi = 0;
                BudgetSaving = 0;
                BudgetCar = 0;
                BudgetTerm = 0;


                // 지출 예산 데이터 입력
                BudgetPray = 0;
                BudgetSpendMission = 0;
                BudgetEdu = 0;
                BudgetPerson = 0;
                BudgetService = 0;
                BudgetManage = 0;
                BudgetLoan = 0;
                BudgetPrepare = 0;
            }
            else
            {
                if (ds.Tables[0].Rows.Count == 0)
                {
                    BudgetThanksOffering = 0;
                    BudgetSipil = 0;
                    BudgetRegion = 0;
                    BudgetBuild = 0;
                    BudgetMissionWork = 0;
                    BudgetSungmi = 0;
                    BudgetSaving = 0;
                    BudgetCar = 0;
                    BudgetTerm = 0;


                    // 지출 예산 데이터 입력
                    BudgetPray = 0;
                    BudgetSpendMission = 0;
                    BudgetEdu = 0;
                    BudgetPerson = 0;
                    BudgetService = 0;
                    BudgetManage = 0;
                    BudgetLoan = 0;
                    BudgetPrepare = 0;
                }
                else
                {
                    BudgetThanksOffering = Convert.ToInt32(ds.Tables[0].Rows[0]["amount"].ToString());
                    BudgetSipil = Convert.ToInt32(ds.Tables[0].Rows[1]["amount"].ToString());
                    BudgetRegion = Convert.ToInt32(ds.Tables[0].Rows[2]["amount"].ToString());
                    BudgetBuild = Convert.ToInt32(ds.Tables[0].Rows[3]["amount"].ToString());
                    BudgetMissionWork = Convert.ToInt32(ds.Tables[0].Rows[4]["amount"].ToString());
                    BudgetSungmi = Convert.ToInt32(ds.Tables[0].Rows[5]["amount"].ToString());
                    BudgetSaving = Convert.ToInt32(ds.Tables[0].Rows[6]["amount"].ToString());
                    BudgetCar = Convert.ToInt32(ds.Tables[0].Rows[7]["amount"].ToString());
                    BudgetTerm = Convert.ToInt32(ds.Tables[0].Rows[8]["amount"].ToString());


                    // 지출 예산 데이터 입력
                    BudgetPray = Convert.ToInt32(ds.Tables[0].Rows[9]["amount"].ToString());
                    BudgetSpendMission = Convert.ToInt32(ds.Tables[0].Rows[10]["amount"].ToString());
                    BudgetEdu = Convert.ToInt32(ds.Tables[0].Rows[11]["amount"].ToString());
                    BudgetPerson = Convert.ToInt32(ds.Tables[0].Rows[12]["amount"].ToString());
                    BudgetService = Convert.ToInt32(ds.Tables[0].Rows[13]["amount"].ToString());
                    BudgetManage = Convert.ToInt32(ds.Tables[0].Rows[14]["amount"].ToString());
                    BudgetLoan = Convert.ToInt32(ds.Tables[0].Rows[15]["amount"].ToString());
                    BudgetPrepare = Convert.ToInt32(ds.Tables[0].Rows[16]["amount"].ToString());

                }
            }

            // 수입 합계
            budgetSum = BudgetThanksOffering + BudgetSipil + BudgetRegion + BudgetBuild + BudgetMissionWork + BudgetSungmi + BudgetSaving + BudgetCar + BudgetTerm;
            sum = ThanksOffering + Sipil + Region + Build + MissionWork + Sungmi + Saving + Car + Etc;

            // 지출 합계
            budgetSpendSum = BudgetPray + BudgetSpendMission + BudgetEdu + BudgetPerson + BudgetService + BudgetManage + BudgetLoan + BudgetPrepare;
            spendSum = Pray + SpendMission + Edu + Person + Service + Manage + Loan + Prepare;
        }

        private void setAdditionalView()
        {
            
            AdditionalView.ColumnCount = 5;
            AdditionalView.Font = new Font("Microsoft Sans Serif", 12);
            AdditionalView.RowTemplate.Height = 30;
            AdditionalView.ReadOnly = true;
            AdditionalView.RowCount = 3;
            AdditionalView.SelectionChanged += AdditionalView_SelectionChanged;
            AdditionalView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            AdditionalView.ColumnHeadersVisible = false;
            AdditionalView.AllowUserToAddRows = false;
            AdditionalView.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            for (int i = 0; i < AdditionalView.ColumnCount; i++)
                AdditionalView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            AdditionalView.RowHeadersDefaultCellStyle.Padding = new Padding(AdditionalView.RowHeadersWidth);
        }

        private void AdditionalView_SelectionChanged(object sender, EventArgs e)
        {
            AdditionalView.ClearSelection();
        }

        /// <summary>
        /// 합계 뷰 추가 (영훈)
        /// </summary>
        private void setSumView()
        {
            SumView.Location = new Point(80, 465);
            SumView.Size = new Size(800, 32);
            SumView.ColumnCount = 5;
            SumView.Font = new Font("Microsoft Sans Serif", 12);
            SumView.RowTemplate.Height = 30;
            SumView.ReadOnly = true;
            SumView.RowCount = 2;
            SumView.SelectionChanged += SumView_SelectionChanged;
            SumView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            SumView.ColumnHeadersVisible = false;
            SumView.AllowUserToAddRows = false;
            SumView.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            for (int i = 0; i < SumView.ColumnCount; i++)
                SumView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            SumView.RowHeadersDefaultCellStyle.Padding = new Padding(SumView.RowHeadersWidth);
        }


        private void SumView_SelectionChanged(object sender, EventArgs e)
        {
            SumView.ClearSelection();
        }

        #region 프린터 부분

        private void Button2_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog dig = new PrintPreviewDialog();

            dig.Document = printDocument1;

            dig.ShowDialog();
            //printDocument1.Print();

        }

        private void PrintDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (mode == DMode.income)
            {
                int curYPos = 150;
                int margin = 20;

                budgetView.RowHeadersVisible = false;
                AdditionalView.RowHeadersVisible = false;
                SumView.RowHeadersVisible = false;

                // 문자 그리기
                SizeF sz = e.Graphics.MeasureString(title.Text, new Font("Tahoma", 20));
                e.Graphics.DrawString(title.Text, new Font("Tahoma", 20), new SolidBrush(Color.Black), new Point((int)(pgSettings.PaperSize.Width / 2 - (sz.Width / 2)), curYPos));

                Bitmap bm = new Bitmap(this.budgetView.Width, this.budgetView.Height);
                budgetView.DrawToBitmap(bm, new Rectangle(0, 0, this.budgetView.Width, this.budgetView.Height));

                curYPos += (int)sz.Height + 80;

                // DataGridView 그리기
                e.Graphics.DrawImage(bm, new Rectangle(pgSettings.Margins.Right / 2, curYPos, pgSettings.PaperSize.Width - ((pgSettings.Margins.Left / 2) + pgSettings.Margins.Right), this.budgetView.Height));

                curYPos += bm.Size.Height + 15;

                bm = new Bitmap(this.AdditionalView.Width, this.AdditionalView.Height);
                AdditionalView.DrawToBitmap(bm, new Rectangle(0, 0, this.AdditionalView.Width, this.AdditionalView.Height));
                e.Graphics.DrawImage(bm, new Rectangle(pgSettings.Margins.Right / 2, curYPos, pgSettings.PaperSize.Width - ((pgSettings.Margins.Left / 2) + pgSettings.Margins.Right), this.AdditionalView.Height));

                curYPos += bm.Size.Height + 15;

                bm = new Bitmap(this.SumView.Width, this.SumView.Height);
                SumView.DrawToBitmap(bm, new Rectangle(0, 0, this.SumView.Width, this.SumView.Height));
                e.Graphics.DrawImage(bm, new Rectangle(pgSettings.Margins.Right / 2, curYPos, pgSettings.PaperSize.Width - ((pgSettings.Margins.Left / 2) + pgSettings.Margins.Right), this.SumView.Height));

                budgetView.RowHeadersVisible = true;
                AdditionalView.RowHeadersVisible = true;
                SumView.RowHeadersVisible = true;
            }
            else if(mode == DMode.spend)
            {

                int curYPos = 150;
                int margin = 20;

                budgetView.RowHeadersVisible = false;
                
                // 문자 그리기
                SizeF sz = e.Graphics.MeasureString(title.Text, new Font("Tahoma", 20));
                e.Graphics.DrawString(title.Text, new Font("Tahoma", 20), new SolidBrush(Color.Black), new Point((int)(pgSettings.PaperSize.Width / 2 - (sz.Width / 2)), curYPos));

                Bitmap bm = new Bitmap(this.budgetView.Width, this.budgetView.Height);
                budgetView.DrawToBitmap(bm, new Rectangle(0, 0, this.budgetView.Width, this.budgetView.Height));

                curYPos += (int)sz.Height + 80;

                // DataGridView 그리기
                e.Graphics.DrawImage(bm, new Rectangle(pgSettings.Margins.Right / 2, curYPos, pgSettings.PaperSize.Width - ((pgSettings.Margins.Left / 2) + pgSettings.Margins.Right), this.budgetView.Height));

                curYPos += bm.Size.Height + 15;
                
                budgetView.RowHeadersVisible = true;
                AdditionalView.RowHeadersVisible = true;
                SumView.RowHeadersVisible = true;
            }
        }

        #endregion

        /// <summary>
        /// DB 설정 (영훈)
        /// </summary>
        public void setIncomeFromDB()
        {
            ThanksOffering = SQLite.ExecuteSumQuery(string.Format("select sum(amount) from Offering_Thanks where strftime('%Y-%m', date) = '{0}'", string.Format(date.Year.ToString() + "-" + date.Month.ToString("d2"))));
            Sipil = SQLite.ExecuteSumQuery(string.Format("select sum(amount) from Offering_10 where strftime('%Y-%m', date) = '{0}'", string.Format(date.Year.ToString() + "-" + date.Month.ToString("d2"))));
            Region = SQLite.ExecuteSumQuery(string.Format("select sum(amount) from Offering_Cell where strftime('%Y-%m', date) = '{0}'", string.Format(date.Year.ToString() + "-" + date.Month.ToString("d2"))));
            Build = SQLite.ExecuteSumQuery(string.Format("select sum(amount) from Offering_Archi where strftime('%Y-%m', date) = '{0}'", string.Format(date.Year.ToString() + "-" + date.Month.ToString("d2"))));
            MissionWork = SQLite.ExecuteSumQuery(string.Format("select sum(amount) from Offering_Mission where strftime('%Y-%m', date) = '{0}'", string.Format(date.Year.ToString() + "-" + date.Month.ToString("d2"))));
            Sungmi = SQLite.ExecuteSumQuery(string.Format("select sum(amount) from Offering_Rice where strftime('%Y-%m', date) = '{0}'", string.Format(date.Year.ToString() + "-" + date.Month.ToString("d2"))));
            Saving = SQLite.ExecuteSumQuery(string.Format("select sum(amount) from Offering_Help where strftime('%Y-%m', date) = '{0}'", string.Format(date.Year.ToString() + "-" + date.Month.ToString("d2"))));
            Car = SQLite.ExecuteSumQuery(string.Format("select sum(amount) from Offering_Car where strftime('%Y-%m', date) = '{0}'", string.Format(date.Year.ToString() + "-" + date.Month.ToString("d2"))));
            Term = SQLite.ExecuteSumQuery(string.Format("select sum(amount) from Offering_Term where strftime('%Y-%m', date) = '{0}'", string.Format(date.Year.ToString() + "-" + date.Month.ToString("d2"))));
            Etc = SQLite.ExecuteSumQuery(string.Format("select sum(amount) from Offering_Other where strftime('%Y-%m', date) = '{0}'", string.Format(date.Year.ToString() + "-" + date.Month.ToString("d2"))));
            Income = SQLite.ExecuteSumQuery(string.Format("select sum(amount) from Offering_Interest where strftime('%Y-%m', date) = '{0}'", string.Format(date.Year.ToString() + "-" + date.Month.ToString("d2"))));

            sum = ThanksOffering + Sipil + Region + Build + MissionWork + Sungmi + Saving + Car + Term;
            total = ThanksOffering + Sipil + Region + Build + MissionWork + Sungmi + Saving + Car + Term + Etc + Income;

            Invalidate();
        }

        public void setSpendFromDB()
        {
            Pray = SQLite.ExecuteSumQuery(string.Format("select sum(amount) from Spending_Worship where strftime('%Y-%m', date) = '{0}'", string.Format(date.Year.ToString() + "-" + date.Month.ToString("d2"))));
            SpendMission = SQLite.ExecuteSumQuery(string.Format("select sum(amount) from Spending_Mission where strftime('%Y-%m', date) = '{0}'", string.Format(date.Year.ToString() + "-" + date.Month.ToString("d2"))));
            Edu = SQLite.ExecuteSumQuery(string.Format("select sum(amount) from Spending_Edu where strftime('%Y-%m', date) = '{0}'", string.Format(date.Year.ToString() + "-" + date.Month.ToString("d2"))));
            Person = SQLite.ExecuteSumQuery(string.Format("select sum(amount) from Spending_Human where strftime('%Y-%m', date) = '{0}'", string.Format(date.Year.ToString() + "-" + date.Month.ToString("d2"))));
            Service = SQLite.ExecuteSumQuery(string.Format("select sum(amount) from Spending_Vol where strftime('%Y-%m', date) = '{0}'", string.Format(date.Year.ToString() + "-" + date.Month.ToString("d2"))));
            Manage = SQLite.ExecuteSumQuery(string.Format("select sum(amount) from Spending_Main where strftime('%Y-%m', date) = '{0}'", string.Format(date.Year.ToString() + "-" + date.Month.ToString("d2"))));
            Loan = SQLite.ExecuteSumQuery(string.Format("select sum(amount) from Spending_Loan where strftime('%Y-%m', date) = '{0}'", string.Format(date.Year.ToString() + "-" + date.Month.ToString("d2"))));
            Prepare = SQLite.ExecuteSumQuery(string.Format("select sum(amount) from Spending_Res where strftime('%Y-%m', date) = '{0}'", string.Format(date.Year.ToString() + "-" + date.Month.ToString("d2"))));

            spendSum = Pray + SpendMission + Edu + Person + Service + Manage + Loan + Prepare;

            Invalidate();
        }

        /// <summary>
        /// DataGridView 설정 부분
        /// </summary>
        private void setViews()
        {
            budgetView.Width = 600;
            budgetView.Location = new Point(80, 50);

            // 예산 데이터뷰 세팅
            budgetView.ColumnCount = 5;
            budgetView.Font = new Font("Microsoft Sans Serif", 12);
            budgetView.RowTemplate.Height = 30;

            budgetView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            budgetView.ColumnHeadersHeight = 30;
            budgetView.ReadOnly = true;
            budgetView.SelectionChanged += BudgetView_SelectionChanged;

            budgetView.Columns[0].HeaderText = "항목";
            budgetView.Columns[1].HeaderText = "금액";
            budgetView.Columns[2].HeaderText = "구성비";
            budgetView.Columns[3].HeaderText = "금액";
            budgetView.Columns[4].HeaderText = "진도비";
            budgetView.AllowUserToAddRows = false;

            for (int i = 0; i < budgetView.ColumnCount; i++)
                budgetView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            for (int i = 0; i < 5; i++)
                budgetView.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

            budgetView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            budgetView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            budgetView.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            budgetView.RowHeadersDefaultCellStyle.Padding = new Padding(budgetView.RowHeadersWidth);

            if (mode == DMode.income)
            {
                budgetView.Size = new Size(800, 332);
                budgetView.RowCount = 10;
            }
            else if (mode == DMode.spend)
            {
                budgetView.Size = new Size(800, 302);
                budgetView.RowCount = 9;
            }
        }

        private void BudgetView_SelectionChanged(object sender, EventArgs e)
        {
            budgetView.ClearSelection();
        }

        #region income 모드

        /// <summary>
        /// 예산 입력
        /// </summary>
        private void budgetInput()
        {
            // 감사 헌금
            budgetView.Rows[0].Cells[0].Value = "  감사 헌금";
            budgetView.Rows[0].Cells[1].Value = BudgetThanksOffering.ToString("n0") + " 원";
            if (ThanksOffering == 0 || BudgetThanksOffering == 0)
                budgetView.Rows[0].Cells[2].Value = 0.ToString("0.00") + " %";
            else
                budgetView.Rows[0].Cells[2].Value = ((float)BudgetThanksOffering / (float)budgetSum * 100).ToString("0.00") + " %";
            budgetView.Rows[0].Cells[3].Value = ThanksOffering.ToString("n0") + " 원";
            if (ThanksOffering == 0 || BudgetThanksOffering == 0)
                budgetView.Rows[0].Cells[4].Value = 0.ToString("0.00") + " %";
            else
                budgetView.Rows[0].Cells[4].Value = ((float)ThanksOffering / (float)BudgetThanksOffering * 100).ToString("0.00") + " %";

            // 십일조
            budgetView.Rows[1].Cells[0].Value = "  십일조";
            budgetView.Rows[1].Cells[1].Value = BudgetSipil.ToString("n0") + " 원";
            if (ThanksOffering == 0 || BudgetThanksOffering == 0)
                budgetView.Rows[1].Cells[2].Value = 0.ToString("0.00") + " %";
            else
                budgetView.Rows[1].Cells[2].Value = ((float)BudgetSipil / (float)budgetSum * 100).ToString("0.00") + " %";
            budgetView.Rows[1].Cells[3].Value = Sipil.ToString("n0") + " 원";
            if (Sipil == 0 || BudgetSipil == 0)
                budgetView.Rows[1].Cells[4].Value = 0.ToString("0.00") + " %";
            else
                budgetView.Rows[1].Cells[4].Value = ((float)Sipil / (float)BudgetSipil * 100).ToString("0.00") + " %";

            // 구역 헌금
            budgetView.Rows[2].Cells[0].Value = "  구역 헌금";
            budgetView.Rows[2].Cells[1].Value = BudgetRegion.ToString("n0") + " 원";
            if (ThanksOffering == 0 || BudgetThanksOffering == 0)
                budgetView.Rows[2].Cells[2].Value = 0.ToString("0.00") + " %";
            else
                budgetView.Rows[2].Cells[2].Value = ((float)BudgetRegion / (float)budgetSum * 100).ToString("0.00") + " %";
            budgetView.Rows[2].Cells[3].Value = Region.ToString("n0") + " 원";
            if (Region == 0 || BudgetRegion == 0)
                budgetView.Rows[2].Cells[4].Value = 0.ToString("0.00") + " %";
            else
                budgetView.Rows[2].Cells[4].Value = ((float)Region / (float)BudgetRegion * 100).ToString("0.00") + " %";

            // 건축 헌금
            budgetView.Rows[3].Cells[0].Value = "  건축 헌금";
            budgetView.Rows[3].Cells[1].Value = BudgetBuild.ToString("n0") + " 원";
            if (ThanksOffering == 0 || BudgetThanksOffering == 0)
                budgetView.Rows[3].Cells[2].Value = 0.ToString("0.00") + " %";
            else
                budgetView.Rows[3].Cells[2].Value = ((float)BudgetBuild / (float)budgetSum * 100).ToString("0.00") + " %";
            budgetView.Rows[3].Cells[3].Value = MissionWork.ToString("n0") + " 원";
            if (Build == 0 || BudgetBuild == 0)
                budgetView.Rows[3].Cells[4].Value = 0.ToString("0.00") + " %";
            else    
                budgetView.Rows[3].Cells[4].Value = ((float)Build/ (float)BudgetBuild * 100).ToString("0.00") + " %";

            // 선교 헌금
            budgetView.Rows[4].Cells[0].Value = "  선교 헌금";
            budgetView.Rows[4].Cells[1].Value = BudgetMissionWork.ToString("n0") + " 원";
            if (ThanksOffering == 0 || BudgetThanksOffering == 0)
                budgetView.Rows[4].Cells[2].Value = 0.ToString("0.00") + " %";
            else
                budgetView.Rows[4].Cells[2].Value = ((float)BudgetMissionWork / (float)budgetSum * 100).ToString("0.00") + " %";
            budgetView.Rows[4].Cells[3].Value = MissionWork.ToString("n0") + " 원";
            if (MissionWork == 0 || BudgetMissionWork == 0)
                budgetView.Rows[4].Cells[4].Value = 0.ToString("0.00") + " %";
            else
                budgetView.Rows[4].Cells[4].Value = ((float)MissionWork / (float)BudgetMissionWork * 100).ToString("0.00") + " %";

            // 성미 헌금
            budgetView.Rows[5].Cells[0].Value = "  성미 헌금";
            budgetView.Rows[5].Cells[1].Value = BudgetSungmi.ToString("n0") + " 원";
            if (ThanksOffering == 0 || BudgetThanksOffering == 0)
                budgetView.Rows[5].Cells[2].Value = 0.ToString("0.00") + " %";
            else
                budgetView.Rows[5].Cells[2].Value = ((float)BudgetSungmi / (float)budgetSum * 100).ToString("0.00") + " %";
            budgetView.Rows[5].Cells[3].Value = Sungmi.ToString("n0") + " 원";
            if (Sungmi == 0 || BudgetSungmi == 0)
                budgetView.Rows[5].Cells[4].Value = 0.ToString("0.00") + " %";
            else
                budgetView.Rows[5].Cells[4].Value = ((float)Sungmi / (float)BudgetSungmi * 100).ToString("0.00") + " %";

            // 구제 헌금
            budgetView.Rows[6].Cells[0].Value = "  구제 헌금";
            budgetView.Rows[6].Cells[1].Value = BudgetSaving.ToString("n0") + " 원";
            if (ThanksOffering == 0 || BudgetThanksOffering == 0)
                budgetView.Rows[6].Cells[2].Value = 0.ToString("0.00") + " %";
            else
                budgetView.Rows[6].Cells[2].Value = ((float)BudgetSaving / (float)budgetSum * 100).ToString("0.00") + " %";
            budgetView.Rows[6].Cells[3].Value = Saving.ToString("n0") + " 원";
            if (Saving == 0 || BudgetSaving == 0)
                budgetView.Rows[6].Cells[4].Value = 0.ToString("0.00") + " %";
            else
                budgetView.Rows[6].Cells[4].Value = ((float)Saving / (float)BudgetSaving * 100).ToString("0.00") + " %";

            // 차량 헌금
            budgetView.Rows[7].Cells[0].Value = "  차량 헌금";
            budgetView.Rows[7].Cells[1].Value = BudgetCar.ToString("n0") + " 원";
            if (ThanksOffering == 0 || BudgetThanksOffering == 0)
                budgetView.Rows[7].Cells[2].Value = 0.ToString("0.00") + " %";
            else
                budgetView.Rows[7].Cells[2].Value = ((float)BudgetCar / (float)budgetSum * 100).ToString("0.00") + " %";
            budgetView.Rows[7].Cells[3].Value = Car.ToString("n0") + " 원";
            if (Car == 0 || BudgetCar == 0)
                budgetView.Rows[7].Cells[4].Value = 0.ToString("0.00") + " %";
            else
                budgetView.Rows[7].Cells[4].Value = ((float)Car / (float)BudgetCar * 100).ToString("0.00") + " %";
            
            // 절기 헌금
            budgetView.Rows[8].Cells[0].Value = "  절기 헌금";
            budgetView.Rows[8].Cells[1].Value = BudgetTerm.ToString("n0") + " 원";
            if (ThanksOffering == 0 || BudgetThanksOffering == 0)
                budgetView.Rows[8].Cells[2].Value = 0.ToString("0.00") + " %";
            else
                budgetView.Rows[8].Cells[2].Value = ((float)BudgetTerm / (float)budgetSum * 100).ToString("0.00") + " %";
            budgetView.Rows[8].Cells[3].Value = Term.ToString("n0") + " 원";
            if (Car == 0 || BudgetTerm == 0)
                budgetView.Rows[8].Cells[4].Value = 0.ToString("0.00") + " %";
            else
                budgetView.Rows[8].Cells[4].Value = ((float)Term / (float)BudgetTerm * 100).ToString("0.00") + " %";
            
            // 예산합계
            budgetView.Rows[9].Cells[0].Value = "  합계";
            budgetView.Rows[9].Cells[1].Value = budgetSum.ToString("n0") + " 원";
            if (ThanksOffering == 0 || BudgetThanksOffering == 0)
                budgetView.Rows[9].Cells[2].Value = 0.ToString("0.00") + " %";
            else
                budgetView.Rows[9].Cells[2].Value = ((float)budgetSum / (float)budgetSum * 100).ToString("0.00") + " %";
            budgetView.Rows[9].Cells[3].Value = sum.ToString("n0") + " 원";
            budgetView.Rows[9].Height = 30;
            if (sum == 0 || budgetSum == 0)
                budgetView.Rows[9].Cells[4].Value = 0.ToString("0.00") + " %";
            else
                budgetView.Rows[9].Cells[4].Value = ((float)sum / (float)budgetSum * 100).ToString("0.00") + " %";


            // 기타 수입
            AdditionalView.Rows[0].Cells[0].Value = "  기타 수입";
            AdditionalView.Rows[0].Cells[3].Value = Etc.ToString("n0") + " 원";

            // 이자 수입
            AdditionalView.Rows[1].Cells[0].Value = "  이자 수입";
            AdditionalView.Rows[1].Cells[3].Value = Income.ToString("n0") + " 원";
            AdditionalView.Rows[1].Height = 30;

            // Total
            SumView.Rows[0].Cells[0].Value = "  합계";
            SumView.Rows[0].Cells[3].Value = total.ToString("n0") + " 원";
            SumView.Rows[0].Height = 30;
        }
        
        #endregion

        #region spend 모드

        /// <summary>
        /// 예산 입력 부분
        /// </summary>
        private void spendBudgetInput()
        {
            // 예배비
            budgetView.Rows[0].Cells[0].Value = "  예배비";
            budgetView.Rows[0].Cells[1].Value = BudgetPray.ToString("n0") + " 원";
            if (Pray == 0 || BudgetPray == 0)
                budgetView.Rows[0].Cells[2].Value = 0.ToString("0.00") + " %";
            else
                budgetView.Rows[0].Cells[2].Value = ((float)BudgetPray / (float)budgetSpendSum * 100).ToString("0.00") + " %";
            budgetView.Rows[0].Cells[3].Value = Pray.ToString("n0") + " 원";
            if (Pray == 0 || BudgetPray == 0)
                budgetView.Rows[0].Cells[4].Value = 0.ToString("0.00") + " %";
            else
                budgetView.Rows[0].Cells[4].Value = ((float)Pray / (float)BudgetPray * 100).ToString("0.00") + " %";

            // 선교비
            budgetView.Rows[1].Cells[0].Value = "  선교비";
            budgetView.Rows[1].Cells[1].Value = BudgetSpendMission.ToString("n0") + " 원";
            if (Pray == 0 || BudgetPray == 0)
                budgetView.Rows[1].Cells[2].Value = 0.ToString("0.00") + " %";
            else
                budgetView.Rows[1].Cells[2].Value = ((float)BudgetSpendMission / (float)budgetSpendSum * 100).ToString("0.00") + " %";
            budgetView.Rows[1].Cells[3].Value = SpendMission.ToString("n0") + " 원";
            if (SpendMission == 0 || BudgetSpendMission == 0)
                budgetView.Rows[1].Cells[4].Value = 0.ToString("0.00") + " %";
            else
                budgetView.Rows[1].Cells[4].Value = ((float)SpendMission / (float)BudgetSpendMission * 100).ToString("0.00") + " %";


            // 교육비 
            budgetView.Rows[2].Cells[0].Value = "  교육비";
            budgetView.Rows[2].Cells[1].Value = BudgetEdu.ToString("n0") + " 원";
            if (Pray == 0 || BudgetPray == 0)
                budgetView.Rows[2].Cells[2].Value = 0.ToString("0.00") + " %";
            else
                budgetView.Rows[2].Cells[2].Value = ((float)BudgetEdu / (float)budgetSpendSum * 100).ToString("0.00") + " %";
            budgetView.Rows[2].Cells[3].Value = Edu.ToString("n0") + " 원";
            if (Edu == 0 || BudgetEdu == 0)
                budgetView.Rows[2].Cells[4].Value = 0.ToString("0.00") + " %";
            else
                budgetView.Rows[2].Cells[4].Value = ((float)Edu / (float)BudgetEdu * 100).ToString("0.00") + " %";

            // 인건비
            budgetView.Rows[3].Cells[0].Value = "  인건비";
            budgetView.Rows[3].Cells[1].Value = BudgetPerson.ToString("n0") + " 원";
            if (Pray == 0 || BudgetPray == 0)
                budgetView.Rows[3].Cells[2].Value = 0.ToString("0.00") + " %";
            else
                budgetView.Rows[3].Cells[2].Value = ((float)BudgetPerson / (float)budgetSpendSum * 100).ToString("0.00") + " %";
            budgetView.Rows[3].Cells[3].Value = Person.ToString("n0") + " 원";
            if (Person == 0 || BudgetPerson == 0)
                budgetView.Rows[3].Cells[4].Value = 0.ToString("0.00") + " %";
            else
                budgetView.Rows[3].Cells[4].Value = ((float)Person / (float)BudgetPerson * 100).ToString("0.00") + " %";

            // 봉사비
            budgetView.Rows[4].Cells[0].Value = "  봉사비";
            budgetView.Rows[4].Cells[1].Value = BudgetService.ToString("n0") + " 원";
            if (Pray == 0 || BudgetPray == 0)
                budgetView.Rows[4].Cells[2].Value = 0.ToString("0.00") + " %";
            else
                budgetView.Rows[4].Cells[2].Value = ((float)BudgetService / (float)budgetSpendSum * 100).ToString("0.00") + " %";
            budgetView.Rows[4].Cells[3].Value = Service.ToString("n0") + " 원";
            if (Service == 0 || BudgetService == 0)
                budgetView.Rows[4].Cells[4].Value = 0.ToString("0.00") + " %";
            else
                budgetView.Rows[4].Cells[4].Value = ((float)Service / (float)BudgetService * 100).ToString("0.00") + " %";

            // 운영 관리비
            budgetView.Rows[5].Cells[0].Value = "  운영 관리비";
            budgetView.Rows[5].Cells[1].Value = BudgetManage.ToString("n0") + " 원";
            if (Pray == 0 || BudgetPray == 0)
                budgetView.Rows[5].Cells[2].Value = 0.ToString("0.00") + " %";
            else
                budgetView.Rows[5].Cells[2].Value = ((float)BudgetManage / (float)budgetSpendSum * 100).ToString("0.00") + " %";
            budgetView.Rows[5].Cells[3].Value = Manage.ToString("n0") + " 원";
            if (Manage == 0 || BudgetManage == 0)
                budgetView.Rows[5].Cells[4].Value = 0.ToString("0.00") + " %";
            else
                budgetView.Rows[5].Cells[4].Value = ((float)Manage / (float)BudgetManage * 100).ToString("0.00") + " %";

            // 대출 관련비
            budgetView.Rows[6].Cells[0].Value = "  대출 관련비";
            budgetView.Rows[6].Cells[1].Value = BudgetLoan.ToString("n0") + " 원";
            if (Pray == 0 || BudgetPray == 0)
                budgetView.Rows[6].Cells[2].Value = 0.ToString("0.00") + " %";
            else
                budgetView.Rows[6].Cells[2].Value = ((float)BudgetLoan / (float)budgetSpendSum * 100).ToString("0.00") + " %";
            budgetView.Rows[6].Cells[3].Value = Loan.ToString("n0") + " 원";
            if (Loan == 0 || BudgetLoan == 0)
                budgetView.Rows[6].Cells[4].Value = 0.ToString("0.00") + " %";
            else
                budgetView.Rows[6].Cells[4].Value = ((float)Loan / (float)BudgetLoan * 100).ToString("0.00") + " %";

            // 예비비
            budgetView.Rows[7].Cells[0].Value = "  예비비";
            budgetView.Rows[7].Cells[1].Value = BudgetPrepare.ToString("n0") + " 원";
            if (Pray == 0 || BudgetPray == 0)
                budgetView.Rows[7].Cells[2].Value = 0.ToString("0.00") + " %";
            else
                budgetView.Rows[7].Cells[2].Value = ((float)BudgetPrepare / (float)budgetSpendSum * 100).ToString("0.00") + " %";
            budgetView.Rows[7].Cells[3].Value = Prepare.ToString("n0") + " 원";
            if (Prepare == 0 || BudgetPrepare == 0)
                budgetView.Rows[7].Cells[4].Value = 0.ToString("0.00") + " %";
            else
                budgetView.Rows[7].Cells[4].Value = ((float)Prepare / (float)BudgetPrepare * 100).ToString("0.00") + " %";

            // 합계
            budgetView.Rows[8].Cells[0].Value = "  합계";
            budgetView.Rows[8].Cells[1].Value = budgetSpendSum.ToString("n0") + " 원";
            if (Pray == 0 || BudgetPray == 0)
                budgetView.Rows[8].Cells[2].Value = 0.ToString("0.00") + " %";
            else
                budgetView.Rows[8].Cells[2].Value = ((float)budgetSpendSum / (float)budgetSpendSum * 100).ToString("0.00") + " %";
            budgetView.Rows[8].Cells[3].Value = spendSum.ToString("n0") + " 원";
            budgetView.Rows[8].Height = 30;
            if (spendSum == 0 || budgetSpendSum == 0)
                budgetView.Rows[8].Cells[4].Value = 0.ToString("0.00") + " %";
            else
                budgetView.Rows[8].Cells[4].Value = ((float)spendSum / (float)budgetSpendSum * 100).ToString("0.00") + " %";
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
