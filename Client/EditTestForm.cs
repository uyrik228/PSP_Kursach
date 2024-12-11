using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Client
{
    public partial class EditTestForm : Form
    {
        private int userId;
        private int testId;
        private List<QuestionControl> questionControls;

        public EditTestForm(int userId, int testId, string testName, List<QuestionControl> existingQuestions)
        {
            InitializeComponent();
            this.userId = userId;
            this.testId = testId;
            txtTestName.Text = testName;
            questionControls = existingQuestions;
            foreach (var questionControl in questionControls)
            {
                flowLayoutPanelQuestions.Controls.Add(questionControl);
                questionControl.QuestionRemoved += QuestionControl_QuestionRemoved;
                foreach (var answerControl in questionControl.AnswerControls)
                {
                    answerControl.AnswerRemoved += AnswerControl_AnswerRemoved;
                }
            }
        }
        private void AnswerControl_AnswerRemoved(object sender, AnswerControl e)
        {
            var questionControl = questionControls.FirstOrDefault(q => q.AnswerControls.Contains(e));
            if (questionControl != null)
            {
                questionControl.AnswerControls.Remove(e);
                questionControl.Controls.Remove(e);

                this.PerformLayout();
                this.Update();
            }
        }
        private void QuestionControl_QuestionRemoved(object sender, QuestionControl e)
        {
            questionControls.Remove(e);
            flowLayoutPanelQuestions.Controls.Remove(e);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            string testName = txtTestName.Text;
            List<string> questions = new List<string>();
            foreach (var questionControl in questionControls)
            {
                string questionText = questionControl.QuestionText;
                if (string.IsNullOrWhiteSpace(questionText)) continue; // Пропуск пустых вопросов
                List<string> answers = new List<string>();
                foreach (var answerControl in questionControl.AnswerControls)
                {
                    string answerText = answerControl.AnswerText;
                    if (string.IsNullOrWhiteSpace(answerText)) continue; // Пропуск пустых ответов

                    bool isCorrect = answerControl.IsCorrect;
                    answers.Add($"{answerText}^{(isCorrect ? 1 : 0)}");
                }
                if (answers.Count > 0)
                {
                    questions.Add($"{questionText}~{string.Join("~", answers)}");
                }
            }
            if (questions.Count == 0)
            {
                MessageBox.Show("Тест должен содержать хотя бы один вопрос с ответами.");
                return;
            }

            string message = $"update_test|{userId}|{testId}|{testName}|{string.Join(";", questions)}";
            SendMessageToServer(message);
            Close();
            //EditTestForm.Close();
        }
        private void btnAddQuestion_Click(object sender, EventArgs e)
        {
            QuestionControl questionControl = new QuestionControl();
            questionControls.Add(questionControl);
            flowLayoutPanelQuestions.Controls.Add(questionControl);
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
