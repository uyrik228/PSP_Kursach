
namespace Client
{
    partial class AddTestForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTestName;
        private System.Windows.Forms.TextBox txtTestName;
        private System.Windows.Forms.Button btnAddQuestion;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelQuestions;
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
            this.lblTestName = new System.Windows.Forms.Label();
            this.txtTestName = new System.Windows.Forms.TextBox();
            this.btnAddQuestion = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.flowLayoutPanelQuestions = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // lblTestName
            // 
            this.lblTestName.AutoSize = true;
            this.lblTestName.Location = new System.Drawing.Point(16, 18);
            this.lblTestName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTestName.Name = "lblTestName";
            this.lblTestName.Size = new System.Drawing.Size(77, 17);
            this.lblTestName.TabIndex = 0;
            this.lblTestName.Text = "Test Name";
            // 
            // txtTestName
            // 
            this.txtTestName.Location = new System.Drawing.Point(133, 15);
            this.txtTestName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTestName.Name = "txtTestName";
            this.txtTestName.Size = new System.Drawing.Size(377, 22);
            this.txtTestName.TabIndex = 1;
            // 
            // btnAddQuestion
            // 
            this.btnAddQuestion.Location = new System.Drawing.Point(230, 45);
            this.btnAddQuestion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddQuestion.Name = "btnAddQuestion";
            this.btnAddQuestion.Size = new System.Drawing.Size(133, 28);
            this.btnAddQuestion.TabIndex = 2;
            this.btnAddQuestion.Text = "Add Question";
            this.btnAddQuestion.UseVisualStyleBackColor = true;
            this.btnAddQuestion.Click += new System.EventHandler(this.btnAddQuestion_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(243, 82);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 28);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // flowLayoutPanelQuestions
            // 
            this.flowLayoutPanelQuestions.AutoScroll = true;
            this.flowLayoutPanelQuestions.Location = new System.Drawing.Point(16, 118);
            this.flowLayoutPanelQuestions.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flowLayoutPanelQuestions.Name = "flowLayoutPanelQuestions";
            this.flowLayoutPanelQuestions.Size = new System.Drawing.Size(494, 240);
            this.flowLayoutPanelQuestions.TabIndex = 4;
            // 
            // AddTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 371);
            this.Controls.Add(this.flowLayoutPanelQuestions);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnAddQuestion);
            this.Controls.Add(this.txtTestName);
            this.Controls.Add(this.lblTestName);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "AddTestForm";
            this.Text = "Add Test";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}