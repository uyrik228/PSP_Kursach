using System;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace Client
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = HashPassword(txtPassword.Text); // Хэшируем пароль перед отправкой
            string message = $"login|{username}|{password}";
            SendMessageToServer(message);
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
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

                if (response.StartsWith("success"))
                {
                    // Получаем роль и ID пользователя из ответа
                    string[] parts = response.Split('|');
                    string role = parts[1];
                    int userId = int.Parse(parts[2]);

                    // Открываем главную форму
                    MainForm mainForm = new MainForm(role, userId);
                    mainForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Неверное имя пользователя или пароль.");
                }

                stream.Close();
                client.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void linkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
            this.Hide();
        }
    }
}
