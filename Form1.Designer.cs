namespace DataBase
{
    partial class SyntheticalExperimenta
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_StudentInformation = new System.Windows.Forms.Button();
            this.btn_CourseMaterials = new System.Windows.Forms.Button();
            this.btn_StudentAchievement = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_StudentInformation
            // 
            this.btn_StudentInformation.Location = new System.Drawing.Point(79, 63);
            this.btn_StudentInformation.Name = "btn_StudentInformation";
            this.btn_StudentInformation.Size = new System.Drawing.Size(120, 23);
            this.btn_StudentInformation.TabIndex = 0;
            this.btn_StudentInformation.Text = "学生资料管理";
            this.btn_StudentInformation.UseVisualStyleBackColor = true;
            this.btn_StudentInformation.Click += new System.EventHandler(this.btn_StudentInformation_Click);
            // 
            // btn_CourseMaterials
            // 
            this.btn_CourseMaterials.Location = new System.Drawing.Point(79, 122);
            this.btn_CourseMaterials.Name = "btn_CourseMaterials";
            this.btn_CourseMaterials.Size = new System.Drawing.Size(120, 23);
            this.btn_CourseMaterials.TabIndex = 1;
            this.btn_CourseMaterials.Text = "课程资料管理";
            this.btn_CourseMaterials.UseVisualStyleBackColor = true;
            this.btn_CourseMaterials.Click += new System.EventHandler(this.btn_CourseMaterials_Click);
            // 
            // btn_StudentAchievement
            // 
            this.btn_StudentAchievement.Location = new System.Drawing.Point(79, 181);
            this.btn_StudentAchievement.Name = "btn_StudentAchievement";
            this.btn_StudentAchievement.Size = new System.Drawing.Size(120, 23);
            this.btn_StudentAchievement.TabIndex = 2;
            this.btn_StudentAchievement.Text = "学生成绩管理";
            this.btn_StudentAchievement.UseVisualStyleBackColor = true;
            this.btn_StudentAchievement.Click += new System.EventHandler(this.btn_StudentAchievement_Click);
            // 
            // SyntheticalExperimenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.btn_StudentAchievement);
            this.Controls.Add(this.btn_CourseMaterials);
            this.Controls.Add(this.btn_StudentInformation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SyntheticalExperimenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "教技、农信综合实验";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_StudentInformation;
        private System.Windows.Forms.Button btn_CourseMaterials;
        private System.Windows.Forms.Button btn_StudentAchievement;
    }
}

