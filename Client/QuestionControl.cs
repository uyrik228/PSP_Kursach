using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Client
{
    public partial class QuestionControl : UserControl
    {
        public string QuestionText
        {
            get => txtQuestion.Text;
            set => txtQuestion.Text = value;
        }

        public int QuestionId { get; set; }

        private List<AnswerControl> answerControls;
        public List<AnswerControl> AnswerControls => answerControls;
        public event EventHandler<QuestionControl> QuestionRemoved;



        public QuestionControl()
        {
            InitializeComponent();
            answerControls = new List<AnswerControl>();

            // Привязка обработчика события KeyPress для текстового поля вопроса
            this.txtQuestion.KeyPress += new KeyPressEventHandler(this.RestrictInput);

            Button btnDeleteQuestion = new Button
            {
                Text = "Удалить вопрос",
                AutoSize = true
            };
            btnDeleteQuestion.Click += BtnDeleteQuestion_Click;
            //Controls.Add(btnDeleteQuestion);
        }

        private void BtnDeleteQuestion_Click(object sender, EventArgs e)
        {
            QuestionRemoved?.Invoke(this, this);
        }



        private void btnAddAnswer_Click(object sender, EventArgs e)
        {
            AnswerControl answerControl = new AnswerControl();
            answerControls.Add(answerControl);
            flowLayoutPanelAnswers.Controls.Add(answerControl);

            // Привязка обработчика события KeyPress для текстового поля ответа
            answerControl.KeyPress += new KeyPressEventHandler(this.RestrictInput);

            // Привязка обработчика события удаления ответа
            answerControl.AnswerRemoved += AnswerControl_AnswerRemoved;
        }

        private void AnswerControl_AnswerRemoved(object sender, AnswerControl e)
        {
            flowLayoutPanelAnswers.Controls.Remove(e);
            answerControls.Remove(e);
            flowLayoutPanelAnswers.PerformLayout(); // Обновляем интерфейс
            flowLayoutPanelAnswers.Invalidate(); // Перерисовываем контейнер

            this.PerformLayout();
            this.Update();
        }

        // Обработчик события KeyPress для ограничения ввода символов
        private void RestrictInput(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '~' || e.KeyChar == '^')
            {
                e.Handled = true;
            }
        }
    }
}
