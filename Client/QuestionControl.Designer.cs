
namespace Client
{
    partial class QuestionControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.TextBox txtQuestion;
        private System.Windows.Forms.Button btnAddAnswer;
        private System.Windows.Forms.Button btnDeleteQuestion;
        public System.Windows.Forms.FlowLayoutPanel flowLayoutPanelAnswers;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblQuestion = new System.Windows.Forms.Label();
            this.txtQuestion = new System.Windows.Forms.TextBox();
            this.btnAddAnswer = new System.Windows.Forms.Button();
            this.btnDeleteQuestion = new System.Windows.Forms.Button();
            this.flowLayoutPanelAnswers = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // lblQuestion
            // 
            this.lblQuestion.AutoSize = true;
            this.lblQuestion.Location = new System.Drawing.Point(3, 8);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(65, 17);
            this.lblQuestion.TabIndex = 0;
            this.lblQuestion.Text = "Question";
            // 
            // txtQuestion
            // 
            this.txtQuestion.Location = new System.Drawing.Point(80, 6);
            this.txtQuestion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtQuestion.Name = "txtQuestion";
            this.txtQuestion.Size = new System.Drawing.Size(367, 22);
            this.txtQuestion.TabIndex = 1;
            // 
            // btnAddAnswer
            // 
            this.btnAddAnswer.Location = new System.Drawing.Point(80, 31);
            this.btnAddAnswer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddAnswer.Name = "btnAddAnswer";
            this.btnAddAnswer.Size = new System.Drawing.Size(89, 24);
            this.btnAddAnswer.TabIndex = 2;
            this.btnAddAnswer.Text = "Add Answer";
            this.btnAddAnswer.UseVisualStyleBackColor = true;
            this.btnAddAnswer.Click += new System.EventHandler(this.btnAddAnswer_Click);
            // 
            // btnDeleteQuestion
            // 
            this.btnDeleteQuestion.Location = new System.Drawing.Point(319, 31);
            this.btnDeleteQuestion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDeleteQuestion.Name = "btnDeleteQuestion";
            this.btnDeleteQuestion.Size = new System.Drawing.Size(89, 24);
            this.btnDeleteQuestion.TabIndex = 4;
            this.btnDeleteQuestion.Text = "Delete Question";
            this.btnDeleteQuestion.UseVisualStyleBackColor = true;
            this.btnDeleteQuestion.Click += new System.EventHandler(this.BtnDeleteQuestion_Click);
            // 
            // flowLayoutPanelAnswers
            // 
            this.flowLayoutPanelAnswers.AutoScroll = true;
            this.flowLayoutPanelAnswers.Location = new System.Drawing.Point(5, 60);
            this.flowLayoutPanelAnswers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanelAnswers.Name = "flowLayoutPanelAnswers";
            this.flowLayoutPanelAnswers.Size = new System.Drawing.Size(442, 120);
            this.flowLayoutPanelAnswers.TabIndex = 3;
            // 
            // QuestionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDeleteQuestion);
            this.Controls.Add(this.flowLayoutPanelAnswers);
            this.Controls.Add(this.btnAddAnswer);
            this.Controls.Add(this.txtQuestion);
            this.Controls.Add(this.lblQuestion);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "QuestionControl";
            this.Size = new System.Drawing.Size(450, 184);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
