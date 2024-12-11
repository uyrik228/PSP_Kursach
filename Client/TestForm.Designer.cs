
namespace Client
{
    partial class TestForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label questionLabel;
        private System.Windows.Forms.GroupBox answersGroupBox;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Button finishButton;

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
            this.questionLabel = new System.Windows.Forms.Label();
            this.answersGroupBox = new System.Windows.Forms.GroupBox();
            this.nextButton = new System.Windows.Forms.Button();
            this.finishButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // questionLabel
            // 
            this.questionLabel.AutoSize = true;
            this.questionLabel.Location = new System.Drawing.Point(10, 10);
            this.questionLabel.Name = "questionLabel";
            this.questionLabel.Size = new System.Drawing.Size(56, 17);
            this.questionLabel.TabIndex = 0;
            this.questionLabel.Text = "Вопрос";
            // 
            // answersGroupBox
            // 
            this.answersGroupBox.Location = new System.Drawing.Point(10, 50);
            this.answersGroupBox.Name = "answersGroupBox";
            this.answersGroupBox.Size = new System.Drawing.Size(398, 204);
            this.answersGroupBox.TabIndex = 1;
            this.answersGroupBox.TabStop = false;
            // 
            // nextButton
            // 
            this.nextButton.Location = new System.Drawing.Point(10, 260);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(100, 30);
            this.nextButton.TabIndex = 2;
            this.nextButton.Text = "Следующий";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // finishButton
            // 
            this.finishButton.Location = new System.Drawing.Point(120, 260);
            this.finishButton.Name = "finishButton";
            this.finishButton.Size = new System.Drawing.Size(100, 30);
            this.finishButton.TabIndex = 3;
            this.finishButton.Text = "Завершить";
            this.finishButton.UseVisualStyleBackColor = true;
            this.finishButton.Visible = false;
            this.finishButton.Click += new System.EventHandler(this.finishButton_Click);
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 300);
            this.Controls.Add(this.questionLabel);
            this.Controls.Add(this.answersGroupBox);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.finishButton);
            this.Name = "TestForm";
            this.Text = "Прохождение теста";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}