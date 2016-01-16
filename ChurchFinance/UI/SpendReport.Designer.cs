namespace UI
{
    partial class SpendReport
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
            this.foreYearBalanceView = new System.Windows.Forms.DataGridView();
            this.Title = new System.Windows.Forms.Label();
            this.incomeSpendView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.foreYearBalanceView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.incomeSpendView)).BeginInit();
            this.SuspendLayout();
            // 
            // foreYearBalanceView
            // 
            this.foreYearBalanceView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.foreYearBalanceView.Location = new System.Drawing.Point(14, 57);
            this.foreYearBalanceView.Name = "foreYearBalanceView";
            this.foreYearBalanceView.RowTemplate.Height = 23;
            this.foreYearBalanceView.Size = new System.Drawing.Size(675, 26);
            this.foreYearBalanceView.TabIndex = 0;
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.Title.Location = new System.Drawing.Point(21, 13);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(86, 26);
            this.Title.TabIndex = 1;
            this.Title.Text = "재정 보고";
            // 
            // incomeSpendView
            // 
            this.incomeSpendView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.incomeSpendView.Location = new System.Drawing.Point(14, 106);
            this.incomeSpendView.Name = "incomeSpendView";
            this.incomeSpendView.RowTemplate.Height = 23;
            this.incomeSpendView.Size = new System.Drawing.Size(675, 141);
            this.incomeSpendView.TabIndex = 2;
            // 
            // SpendReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.incomeSpendView);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.foreYearBalanceView);
            this.Name = "SpendReport";
            this.Size = new System.Drawing.Size(715, 461);
            ((System.ComponentModel.ISupportInitialize)(this.foreYearBalanceView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.incomeSpendView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView foreYearBalanceView;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.DataGridView incomeSpendView;
    }
}
