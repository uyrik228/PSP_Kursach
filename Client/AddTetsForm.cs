using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Client
{
    public partial class AddTestForm : Form
    {
        private int userId;
        private List<QuestionControl> questionControls;

        public AddTestForm(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            questionControls = new List<QuestionControl>();
        }

        private void btnAddQuestion_Click(object sender, EventArgs e)
        {
            QuestionControl questionControl = new QuestionControl();
            questionControls.Add(questionControl);
            flowLayoutPanelQuestions.Controls.Add(questionControl);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string testName = txtTestName.Text;
            List<string> questions = new List<string>();

            foreach (var questionControl in questionControls)
            {
                string questionText = questionControl.QuestionText;
                List<string> answers = new List<string>();

                foreach (var answerControl in questionControl.AnswerControls)
                {
                    string answerText = answerControl.AnswerText;
                    bool isCorrect = answerControl.IsCorrect;
                    answers.Add($"{answerText}^{(isCorrect ? 1 : 0)}");
                }

                questions.Add($"{questionText}~{string.Join("~", answers)}");
            }

            string message = $"add_test|{userId}|{testName}|{string.Join(";", questions)}";
            Console.WriteLine("Отправляемое сообщение: " + message); // Вывод сообщения в консоль
            SendMessageToServer(message);
        }






        private void SendMessageToServer(string message)
        {
            try
            {
                TcpClient client = new TcpClient("127.0.0.1", 12345);
                NetworkStream stream = client.GetStream();
                byte[] data = Encoding.UTF8.GetBytes(message);
                stream.Write(data, 0, data.Length);

                byte[] responseData = new byte[256];
                int bytes = stream.Read(responseData, 0, responseData.Length);
                string response = Encoding.UTF8.GetString(responseData, 0, bytes);

                MessageBox.Show(response);

                stream.Close();
                client.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }
    }
}
