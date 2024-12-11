using System;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace Client
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string passwordConfirm = txtPasswordConfirm.Text;
            string role = cmbRole.SelectedItem.ToString();
            string roleCode = txtRoleCode.Text;

            if (password != passwordConfirm)
            {
                MessageBox.Show("Пароли не совпадают!");
                return;
            }

            if (role == "Admin" && string.IsNullOrEmpty(roleCode))
            {
                MessageBox.Show("Вы не ввели кодовое слово!");
                return;
            }

            string hashedPassword = HashPassword(password);
            string message = $"register|{username}|{hashedPassword}|{role}|{roleCode}";
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
                MessageBox.Show(response);
                stream.Close();
                client.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void linkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }
    }
}
