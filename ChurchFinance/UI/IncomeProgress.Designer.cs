namespace UI
{
    partial class IncomeProgress
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
            this.budgetView = new System.Windows.Forms.DataGridView();
            this.title = new System.Windows.Forms.Label();
            this.progressView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.budgetView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressView)).BeginInit();
            this.SuspendLayout();
            // 
            // budgetView
            // 
            this.budgetView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.budgetView.Location = new System.Drawing.Point(56, 60);
            this.budgetView.Name = "budgetView";
            this.budgetView.RowTemplate.Height = 23;
            this.budgetView.Size = new System.Drawing.Size(303, 463);
            this.budgetView.TabIndex = 0;
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Tahoma", 15F);
            this.title.Location = new System.Drawing.Point(56, 15);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(64, 24);
            this.title.TabIndex = 1;
            this.title.Text = "label1";
            // 
            // progressView
            // 
            this.progressView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.progressView.Location = new System.Drawing.Point(426, 60);
            this.progressView.Name = "progressView";
            this.progressView.RowTemplate.Height = 23;
            this.progressView.Size = new System.Drawing.Size(299, 463);
            this.progressView.TabIndex = 2;
            // 
            // IncomeProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.progressView);
            this.Controls.Add(this.title);
            this.Controls.Add(this.budgetView);
            this.Name = "IncomeProgress";
            this.Size = new System.Drawing.Size(876, 555);
            ((System.ComponentModel.ISupportInitialize)(this.budgetView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView budgetView;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.DataGridView progressView;
    }
}
