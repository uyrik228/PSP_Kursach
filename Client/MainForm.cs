using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace Client
{
    public partial class MainForm : Form
    {
        private string role;  // Переменная для хранения роли пользователя
        private int userId;   // Переменная для хранения ID пользователя

        public MainForm(string role, int userId)
        {
            InitializeComponent();
            this.role = role;
            this.userId = userId;
            LoadTests();
        }

        private void LoadTests()
        {
            try
            {
                TcpClient client = new TcpClient("127.0.0.1", 12345);
                NetworkStream stream = client.GetStream();
                // было изначально string message = role == "admin" ? "load_all_tests" : $"load_user_tests|{userId}";
                string message = "load_all_tests";
                byte[] data = Encoding.UTF8.GetBytes(message);
                stream.Write(data, 0, data.Length);

                byte[] responseData = new byte[4096];
                int bytes = stream.Read(responseData, 0, responseData.Length);
                string response = Encoding.UTF8.GetString(responseData, 0, bytes);

                DataTable dt = new DataTable();
                dt.Columns.Add("id", typeof(int));
                dt.Columns.Add("title", typeof(string));
                dt.Columns.Add("created_at", typeof(string));
                dt.Columns.Add("username", typeof(string));

                string[] rows = response.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string row in rows)
                {
                    string[] cols = row.Split('|');
                    DataRow dr = dt.NewRow();
                    dr["id"] = int.Parse(cols[0]);
                    dr["title"] = cols[1];
                    dr["created_at"] = cols[2];
                    dr["username"] = cols[3];
                    dt.Rows.Add(dr);
                }

                dataGridView.DataSource = dt;

                stream.Close();
                client.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Логика для добавления тестов и вопросов
            AddTestForm addTestForm = new AddTestForm(userId);
            addTestForm.ShowDialog();
            LoadTests();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Логика для удаления тестов и вопросов (только для администраторов)
            if (dataGridView.SelectedRows.Count > 0)
            {
                int selectedTestId = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["id"].Value);

                /*if (role == "admin" || IsUserTest(selectedTestId))
                {*/
                    // Отправка запроса на сервер для удаления теста
                    string message = $"delete_test|{userId}|{selectedTestId}";
                    SendMessageToServer(message);
                    LoadTests();
                /*}
                else
                {
                    MessageBox.Show("Вы не можете удалить этот тест.");
                }*/
            }
            else
            {
                MessageBox.Show("Выберите тест для удаления.");
            }
        }


        private List<QuestionControl> LoadQuestions(int testId)
        {
            List<QuestionControl> questionControls = new List<QuestionControl>();

            try
            {
                TcpClient client = new TcpClient("127.0.0.1", 12345);
                NetworkStream stream = client.GetStream();
                string message = $"load_test|{testId}";
                byte[] data = Encoding.UTF8.GetBytes(message);
                stream.Write(data, 0, data.Length);

                byte[] responseData = new byte[4096];
                int bytes = stream.Read(responseData, 0, responseData.Length);
                string response = Encoding.UTF8.GetString(responseData, 0, bytes);

                string[] questions = response.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string question in questions)
                {
                    string[] parts = question.Split('~');
                    if (parts.Length < 3)
                    {
                        MessageBox.Show("Ошибка: Неверный формат данных вопроса.");
                        continue;
                    }

                    if (!int.TryParse(parts[0], out int questionId))
                    {
                        MessageBox.Show("Ошибка: Неверный формат идентификатора вопроса.");
                        continue;
                    }

                    string questionText = parts[1];
                    string[] answers = parts.Skip(2).ToArray();

                    QuestionControl questionControl = new QuestionControl
                    {
                        QuestionId = questionId,
                        QuestionText = questionText
                    };

                    foreach (string answer in answers)
                    {
                        string[] answerParts = answer.Split('^');
                        if (answerParts.Length < 3)
                        {
                            MessageBox.Show("Ошибка: Неверный формат данных ответа.");
                            continue;
                        }

                        if (!int.TryParse(answerParts[0], out int answerId))
                        {
                            MessageBox.Show("Ошибка: Неверный формат идентификатора ответа.");
                            continue;
                        }

                        string answerText = answerParts[1];
                        bool isCorrect = answerParts[2] == "1";

                        AnswerControl answerControl = new AnswerControl
                        {
                            AnswerId = answerId,
                            AnswerText = answerText,
                            IsCorrect = isCorrect
                        };


                        questionControl.AnswerControls.Add(answerControl);
                        questionControl.flowLayoutPanelAnswers.Controls.Add(answerControl);
                    }

                    questionControls.Add(questionControl);
                }

                stream.Close();
                client.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }

            return questionControls;
        }







        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                int selectedTestId = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["id"].Value);
                string testName = dataGridView.SelectedRows[0].Cells["title"].Value.ToString();

                // Загрузка существующих вопросов и ответов
                List<QuestionControl> existingQuestions = LoadQuestions(selectedTestId);

                EditTestForm editTestForm = new EditTestForm(userId, selectedTestId, testName, existingQuestions);
                editTestForm.ShowDialog();
                LoadTests();
            }
            else
            {
                MessageBox.Show("Выберите тест для редактирования.");
            }
        }

        /*private bool IsUserTest(int testId)
        {
            // Проверка, принадлежит ли тест пользователю
            // Реализуйте логику проверки принадлежности теста пользователю
            return true; // Пример
        }*/

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

        private void btnSubmin_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                int selectedTestId = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["id"].Value);

                // Отправка запроса на сервер для удаления теста
                List<QuestionControl> existingQuestions = LoadQuestions(selectedTestId);

                TestForm testForm = new TestForm(userId, selectedTestId, existingQuestions);
                testForm.ShowDialog();
                LoadTests();
                /*}
                else
                {
                    MessageBox.Show("Вы не можете удалить этот тест.");
                }*/
            }
            else
            {
                MessageBox.Show("Выберите тест, который хотите пройти.");
            }
        }
    }
}
