
namespace Client
{
    partial class AnswerControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblAnswer;
        private System.Windows.Forms.TextBox txtAnswer;
        private System.Windows.Forms.CheckBox chkIsCorrect;
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
            this.lblAnswer = new System.Windows.Forms.Label();
            this.txtAnswer = new System.Windows.Forms.TextBox();
            this.chkIsCorrect = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblAnswer
            // 
            this.lblAnswer.AutoSize = true;
            this.lblAnswer.Location = new System.Drawing.Point(3, 8);
            this.lblAnswer.Name = "lblAnswer";
            this.lblAnswer.Size = new System.Drawing.Size(54, 17);
            this.lblAnswer.TabIndex = 0;
            this.lblAnswer.Text = "Answer";
            // 
            // txtAnswer
            // 
            this.txtAnswer.Location = new System.Drawing.Point(62, 6);
            this.txtAnswer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAnswer.Name = "txtAnswer";
            this.txtAnswer.Size = new System.Drawing.Size(267, 22);
            this.txtAnswer.TabIndex = 1;
            // 
            // chkIsCorrect
            // 
            this.chkIsCorrect.AutoSize = true;
            this.chkIsCorrect.Location = new System.Drawing.Point(338, 8);
            this.chkIsCorrect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkIsCorrect.Name = "chkIsCorrect";
            this.chkIsCorrect.Size = new System.Drawing.Size(18, 17);
            this.chkIsCorrect.TabIndex = 2;
            this.chkIsCorrect.UseVisualStyleBackColor = true;
            // 
            // AnswerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkIsCorrect);
            this.Controls.Add(this.txtAnswer);
            this.Controls.Add(this.lblAnswer);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "AnswerControl";
            this.Size = new System.Drawing.Size(375, 42);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
