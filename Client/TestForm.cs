using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Client
{
    public partial class TestForm : Form
    {
        private int userId;
        private int testId;
        private List<QuestionControl> questionControls;
        private int currentQuestionIndex = 0;
        private Dictionary<int, bool> userAnswers = new Dictionary<int, bool>();

        public TestForm(int userId, int testId, List<QuestionControl> questionControls)
        {
            InitializeComponent();
            this.userId = userId;
            this.testId = testId;
            this.questionControls = questionControls;
            DisplayQuestion();
        }

        private void DisplayQuestion()
        {
            if (currentQuestionIndex < questionControls.Count)
            {
                var questionControl = questionControls[currentQuestionIndex];
                questionLabel.Text = questionControl.QuestionText;
                answersGroupBox.Controls.Clear();

                int yOffset = 20; // Начальное смещение по вертикали

                foreach (var answerControl in questionControl.AnswerControls)
                {
                    var checkBox = new CheckBox
                    {
                        Text = answerControl.AnswerText,
                        Tag = answerControl.AnswerId,
                        AutoSize = true,
                        Location = new Point(10, yOffset) // Устанавливаем позицию CheckBox
                    };
                    answersGroupBox.Controls.Add(checkBox);
                    yOffset += 30; // Увеличиваем смещение для следующего CheckBox
                }

                // Обновление интерфейса
                answersGroupBox.PerformLayout();
                answersGroupBox.Invalidate();
            }
            else
            {
                // Все вопросы пройдены, показать кнопку завершения теста
                nextButton.Visible = false;
                finishButton.Visible = true;
            }
        }




        private void nextButton_Click(object sender, EventArgs e)
        {
            // Сохранение ответов пользователя
            foreach (CheckBox checkBox in answersGroupBox.Controls)
            {
                int answerId = (int)checkBox.Tag;
                userAnswers[answerId] = checkBox.Checked;
            }

            currentQuestionIndex++;
            DisplayQuestion();
        }

        private void finishButton_Click(object sender, EventArgs e)
        {
            // Отправка результатов теста на сервер
            SubmitTestResults();
            Close();
        }

        private void SubmitTestResults()
        {
            try
            {
                var answers = new List<string>();
                foreach (var answer in userAnswers)
                {
                    answers.Add($"{answer.Key}:{(answer.Value ? 1 : 0)}");
                }

                string formattedAnswers = string.Join("^", answers);
                string message = $"submit_test|{userId}|{testId}|{formattedAnswers}";
                SendMessageToServer(message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
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
