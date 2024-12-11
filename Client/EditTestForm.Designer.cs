
namespace Client
{
    partial class EditTestForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtTestName;
        private System.Windows.Forms.Label lblTestName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnAddQuestion;
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
            this.txtTestName = new System.Windows.Forms.TextBox();
            this.lblTestName = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnAddQuestion = new System.Windows.Forms.Button();
            this.flowLayoutPanelQuestions = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtTestName
            // 
            this.txtTestName.Location = new System.Drawing.Point(16, 31);
            this.txtTestName.Margin = new System.Windows.Forms.Padding(4);
            this.txtTestName.Name = "txtTestName";
            this.txtTestName.Size = new System.Drawing.Size(479, 22);
            this.txtTestName.TabIndex = 0;
            // 
            // lblTestName
            // 
            this.lblTestName.AutoSize = true;
            this.lblTestName.Location = new System.Drawing.Point(16, 11);
            this.lblTestName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTestName.Name = "lblTestName";
            this.lblTestName.Size = new System.Drawing.Size(113, 17);
            this.lblTestName.TabIndex = 1;
            this.lblTestName.Text = "Название теста";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(396, 511);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 28);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAddQuestion
            // 
            this.btnAddQuestion.Location = new System.Drawing.Point(16, 511);
            this.btnAddQuestion.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddQuestion.Name = "btnAddQuestion";
            this.btnAddQuestion.Size = new System.Drawing.Size(133, 28);
            this.btnAddQuestion.TabIndex = 3;
            this.btnAddQuestion.Text = "Добавить вопрос";
            this.btnAddQuestion.UseVisualStyleBackColor = true;
            this.btnAddQuestion.Click += new System.EventHandler(this.btnAddQuestion_Click);
            // 
            // flowLayoutPanelQuestions
            // 
            this.flowLayoutPanelQuestions.AutoScroll = true;
            this.flowLayoutPanelQuestions.Location = new System.Drawing.Point(16, 99);
            this.flowLayoutPanelQuestions.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanelQuestions.Name = "flowLayoutPanelQuestions";
            this.flowLayoutPanelQuestions.Size = new System.Drawing.Size(480, 405);
            this.flowLayoutPanelQuestions.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(370, 34);
            this.label1.TabIndex = 5;
            this.label1.Text = "Если хотите удалить вопрос(для вопроса есть кнопка)\r\n или ответ просто оставьте п" +
    "устую строку";
            // 
            // EditTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 554);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flowLayoutPanelQuestions);
            this.Controls.Add(this.btnAddQuestion);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblTestName);
            this.Controls.Add(this.txtTestName);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "EditTestForm";
            this.Text = "Редактирование теста";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
    }
}