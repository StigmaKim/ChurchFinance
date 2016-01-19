namespace UI
{
    partial class TestForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            UI.Education education1 = new UI.Education();
            UI.Loan loan1 = new UI.Loan();
            UI.Manage manage1 = new UI.Manage();
            UI.MissionWork missionWork1 = new UI.MissionWork();
            UI.Person person1 = new UI.Person();
            UI.Pray pray1 = new UI.Pray();
            UI.Service service1 = new UI.Service();
            UI.Education education2 = new UI.Education();
            UI.Loan loan2 = new UI.Loan();
            UI.Manage manage2 = new UI.Manage();
            UI.MissionWork missionWork2 = new UI.MissionWork();
            UI.Person person2 = new UI.Person();
            UI.Pray pray2 = new UI.Pray();
            UI.Service service2 = new UI.Service();
            this.neoTabWindow1 = new NeoTabControlLibrary.NeoTabWindow();
            this.neoTabPage1 = new NeoTabControlLibrary.NeoTabPage();
            this.preViewBtn = new System.Windows.Forms.Button();
            this.printSetBtn = new System.Windows.Forms.Button();
            this.printBtn = new System.Windows.Forms.Button();
            this.spendDetail1 = new UI.SpendDetail();
            ((System.ComponentModel.ISupportInitialize)(this.neoTabWindow1)).BeginInit();
            this.neoTabWindow1.SuspendLayout();
            this.neoTabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // neoTabWindow1
            // 
            this.neoTabWindow1.Controls.Add(this.neoTabPage1);
            this.neoTabWindow1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neoTabWindow1.Location = new System.Drawing.Point(0, 0);
            this.neoTabWindow1.Name = "neoTabWindow1";
            this.neoTabWindow1.RendererName = null;
            this.neoTabWindow1.SelectedIndex = 0;
            this.neoTabWindow1.Size = new System.Drawing.Size(937, 609);
            this.neoTabWindow1.TabIndex = 0;
            // 
            // neoTabPage1
            // 
            this.neoTabPage1.BackColor = System.Drawing.Color.Transparent;
            this.neoTabPage1.Controls.Add(this.preViewBtn);
            this.neoTabPage1.Controls.Add(this.printSetBtn);
            this.neoTabPage1.Controls.Add(this.printBtn);
            this.neoTabPage1.Controls.Add(this.spendDetail1);
            this.neoTabPage1.Name = "neoTabPage1";
            this.neoTabPage1.Text = "neoTabPage1";
            this.neoTabPage1.ToolTipText = "neoTabPage1";
            // 
            // preViewBtn
            // 
            this.preViewBtn.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.preViewBtn.Location = new System.Drawing.Point(781, 519);
            this.preViewBtn.Name = "preViewBtn";
            this.preViewBtn.Size = new System.Drawing.Size(109, 45);
            this.preViewBtn.TabIndex = 3;
            this.preViewBtn.Text = "미리보기";
            this.preViewBtn.UseVisualStyleBackColor = true;
            this.preViewBtn.Click += new System.EventHandler(this.preViewBtn_Click);
            // 
            // printSetBtn
            // 
            this.printSetBtn.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.printSetBtn.Location = new System.Drawing.Point(645, 519);
            this.printSetBtn.Name = "printSetBtn";
            this.printSetBtn.Size = new System.Drawing.Size(120, 45);
            this.printSetBtn.TabIndex = 2;
            this.printSetBtn.Text = "인쇄 설정";
            this.printSetBtn.UseVisualStyleBackColor = true;
            this.printSetBtn.Click += new System.EventHandler(this.printSetBtn_Click);
            // 
            // printBtn
            // 
            this.printBtn.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Bold);
            this.printBtn.Location = new System.Drawing.Point(544, 519);
            this.printBtn.Name = "printBtn";
            this.printBtn.Size = new System.Drawing.Size(91, 45);
            this.printBtn.TabIndex = 1;
            this.printBtn.Text = "인쇄";
            this.printBtn.UseVisualStyleBackColor = true;
            this.printBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // spendDetail1
            // 
            education1.Book = 600000;
            education1.ScholarShip = 6000000;
            education1.Student = 2400000;
            education1.WeekSchool = 2400000;
            education1.YoungMan = 1800000;
            this.spendDetail1.BudgetEdu = education1;
            loan1.Interest = 8000000;
            loan1.Repayment = 12000000;
            this.spendDetail1.BudgetLoan = loan1;
            manage1.CarBuy = 6000000;
            manage1.CarManage = 10000000;
            manage1.Church = 22000000;
            manage1.Communication = 1500000;
            manage1.Etc = 12000000;
            manage1.Home = 2520000;
            manage1.Ministry = 4600000;
            manage1.Sang = 1000000;
            manage1.Tool = 2000000;
            manage1.Water = 3000000;
            this.spendDetail1.BudgetManage = manage1;
            missionWork1.Misson = 8000000;
            missionWork1.Visit = 700000;
            this.spendDetail1.BudgetMissionWork = missionWork1;
            person1.Bonus = 1800000;
            person1.Missionary = 20400000;
            person1.Priest = 21600000;
            this.spendDetail1.BudgetPerson = person1;
            pray1.Flower = 1500000;
            pray1.Jubo = 200000;
            pray1.Singer = 1200000;
            this.spendDetail1.BudgetPray = pray1;
            this.spendDetail1.BudgetPrepare = 11453000;
            service1.Events = 7000000;
            service1.GyeongJo = 1000000;
            service1.Saving = 1200000;
            this.spendDetail1.BudgetService = service1;
            education2.Book = 0;
            education2.ScholarShip = 500000;
            education2.Student = 200000;
            education2.WeekSchool = 200000;
            education2.YoungMan = 150000;
            this.spendDetail1.CurEdu = education2;
            loan2.Interest = 400410;
            loan2.Repayment = 500000;
            this.spendDetail1.CurLoan = loan2;
            manage2.CarBuy = 0;
            manage2.CarManage = 504000;
            manage2.Church = 1324300;
            manage2.Communication = 0;
            manage2.Etc = 628250;
            manage2.Home = 210000;
            manage2.Ministry = 300000;
            manage2.Sang = 0;
            manage2.Tool = 0;
            manage2.Water = 0;
            this.spendDetail1.CurManage = manage2;
            missionWork2.Misson = 660000;
            missionWork2.Visit = 0;
            this.spendDetail1.CurMissionWork = missionWork2;
            person2.Bonus = 0;
            person2.Missionary = 1700000;
            person2.Priest = 1800000;
            this.spendDetail1.CurPerson = person2;
            pray2.Flower = 100000;
            pray2.Jubo = 0;
            pray2.Singer = 100000;
            this.spendDetail1.CurPray = pray2;
            service2.Events = 12500;
            service2.GyeongJo = 0;
            service2.Saving = 100000;
            this.spendDetail1.CurService = service2;
            this.spendDetail1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spendDetail1.Location = new System.Drawing.Point(0, 0);
            this.spendDetail1.Name = "spendDetail1";
            this.spendDetail1.Prepare = 8111000;
            this.spendDetail1.Size = new System.Drawing.Size(929, 583);
            this.spendDetail1.TabIndex = 0;
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(937, 609);
            this.Controls.Add(this.neoTabWindow1);
            this.Name = "TestForm";
            this.Text = "TestForm";
            ((System.ComponentModel.ISupportInitialize)(this.neoTabWindow1)).EndInit();
            this.neoTabWindow1.ResumeLayout(false);
            this.neoTabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private NeoTabControlLibrary.NeoTabWindow neoTabWindow1;
        private NeoTabControlLibrary.NeoTabPage neoTabPage1;
        private SpendDetail spendDetail1;
        private System.Windows.Forms.Button printBtn;
        private System.Windows.Forms.Button printSetBtn;
        private System.Windows.Forms.Button preViewBtn;
    }
}