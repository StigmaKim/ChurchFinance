namespace UI
{
    partial class YReport
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.title = new System.Windows.Forms.Label();
            this.income = new System.Windows.Forms.DataGridView();
            this.spend = new System.Windows.Forms.DataGridView();
            this.beforeBalance = new System.Windows.Forms.DataGridView();
            this.afterBalance = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.income)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.beforeBalance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.afterBalance)).BeginInit();
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.title.Location = new System.Drawing.Point(252, 18);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(70, 26);
            this.title.TabIndex = 0;
            this.title.Text = "label1";
            // 
            // income
            // 
            this.income.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.income.Location = new System.Drawing.Point(30, 65);
            this.income.Name = "income";
            this.income.RowTemplate.Height = 23;
            this.income.Size = new System.Drawing.Size(248, 299);
            this.income.TabIndex = 1;
            // 
            // spend
            // 
            this.spend.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.spend.Location = new System.Drawing.Point(308, 65);
            this.spend.Name = "spend";
            this.spend.RowTemplate.Height = 23;
            this.spend.Size = new System.Drawing.Size(240, 299);
            this.spend.TabIndex = 2;
            // 
            // beforeBalance
            // 
            this.beforeBalance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.beforeBalance.Location = new System.Drawing.Point(30, 375);
            this.beforeBalance.Name = "beforeBalance";
            this.beforeBalance.RowTemplate.Height = 23;
            this.beforeBalance.Size = new System.Drawing.Size(248, 29);
            this.beforeBalance.TabIndex = 3;
            // 
            // afterBalance
            // 
            this.afterBalance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.afterBalance.Location = new System.Drawing.Point(308, 375);
            this.afterBalance.Name = "afterBalance";
            this.afterBalance.RowTemplate.Height = 23;
            this.afterBalance.Size = new System.Drawing.Size(240, 29);
            this.afterBalance.TabIndex = 4;
            // 
            // YReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.afterBalance);
            this.Controls.Add(this.beforeBalance);
            this.Controls.Add(this.spend);
            this.Controls.Add(this.income);
            this.Controls.Add(this.title);
            this.Name = "YReport";
            this.Size = new System.Drawing.Size(715, 461);
            ((System.ComponentModel.ISupportInitialize)(this.income)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.beforeBalance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.afterBalance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label title;
        private System.Windows.Forms.DataGridView income;
        private System.Windows.Forms.DataGridView spend;
        private System.Windows.Forms.DataGridView beforeBalance;
        private System.Windows.Forms.DataGridView afterBalance;
    }
}
