using System;
using System.Windows.Forms;

namespace Client
{
    public partial class AnswerControl : UserControl
    {
        public int AnswerId { get; set; }
        public string AnswerText
        {
            get => txtAnswer.Text;
            set => txtAnswer.Text = value;
        }

        public bool IsCorrect
        {
            get => chkIsCorrect.Checked;
            set => chkIsCorrect.Checked = value;
        }


        public TextBox AnswerTextBox => txtAnswer; // Добавляем свойство для доступа к текстовому полю

        public event EventHandler<AnswerControl> AnswerRemoved;

        public AnswerControl()
        {
            InitializeComponent();

            // Привязка обработчика события KeyPress для текстового поля ответа
            this.txtAnswer.KeyPress += new KeyPressEventHandler(this.RestrictInput);

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
