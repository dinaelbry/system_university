using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing; // Add this for Color and Font

namespace system_university
{
    public partial class Login : Form
    {
        private readonly string connectionString = "    Data Source = DINA\\DINA;Initial Catalog = system_university; Integrated Security = True; TrustServerCertificate=True;";

        public bool IsAuthenticated { get; private set; }

        public Login()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string password = textBox2.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Enter username and password", "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT top 1 username from users where username = @username AND password = @password";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        var result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            IsAuthenticated = true;
                            DialogResult = DialogResult.OK;
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("Invalid username or password.", "Login Failed",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            textBox2.Clear();
                            textBox2.Focus();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Login_Load(object sender, EventArgs e)
        {
            ApplyButtonEffects(this);
        }

        private void ApplyButtonEffects(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl is Button btn)
                {
                    btn.MouseEnter += Button_MouseEnter;
                    btn.MouseLeave += Button_MouseLeave;
                }
                else if (ctrl.HasChildren)
                {
                    ApplyButtonEffects(ctrl);
                }
            }
        }

        private void Button_MouseEnter(object? sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                btn.BackColor = Color.LightSkyBlue;
                btn.Font = new Font(btn.Font.FontFamily, 12, FontStyle.Bold); // ثابت
            }
        }

        private void Button_MouseLeave(object? sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                btn.BackColor = SystemColors.Control;
                btn.Font = new Font(btn.Font.FontFamily, 10, FontStyle.Regular); // ثابت
            }
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
    }
}