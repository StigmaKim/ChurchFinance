﻿namespace UI
{
    partial class Form1
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

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.neoTabWindow1 = new NeoTabControlLibrary.NeoTabWindow();
            this.imgBtnContainer1 = new UI.ImgBtnContainer();
            ((System.ComponentModel.ISupportInitialize)(this.neoTabWindow1)).BeginInit();
            this.SuspendLayout();
            // 
            // neoTabWindow1
            // 
            this.neoTabWindow1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.neoTabWindow1.Location = new System.Drawing.Point(13, 116);
            this.neoTabWindow1.Name = "neoTabWindow1";
            this.neoTabWindow1.RendererName = null;
            this.neoTabWindow1.Size = new System.Drawing.Size(968, 451);
            this.neoTabWindow1.TabIndex = 1;
            // 
            // imgBtnContainer1
            // 
            this.imgBtnContainer1.Location = new System.Drawing.Point(13, 13);
            this.imgBtnContainer1.Name = "imgBtnContainer1";
            this.imgBtnContainer1.Size = new System.Drawing.Size(968, 97);
            this.imgBtnContainer1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 579);
            this.Controls.Add(this.imgBtnContainer1);
            this.Controls.Add(this.neoTabWindow1);
            this.Name = "Form1";
            this.Text = "정산 프로그램";
            ((System.ComponentModel.ISupportInitialize)(this.neoTabWindow1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private NeoTabControlLibrary.NeoTabWindow neoTabWindow1;
        private ImgBtnContainer imgBtnContainer1;
    }
}

