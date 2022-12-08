using System.Data.SqlClient;

namespace pasang
{
    public partial class Form1 : Form
    {
        SqlConnection conn = new SqlConnection
            (@"Data source=.\SQLEXPRESS;
            Initial catalog=tickets;
            user id=sa;password=kist@123;");
        public Form1()
        {
            InitializeComponent();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.ShowDialog();
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            string login1 = "SELECT * FROM login1 WHERE username ='" + textBox1.Text + "' and password = '" + textBox2.Text + "'";
            SqlCommand cmd = new SqlCommand(login1, conn);
            cmd.ExecuteNonQuery();
            var dr = cmd.ExecuteReader();
            if (dr.Read() == true)
            {
                new Form2().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password ,Please Try Again", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                textBox1.Text = "";
                textBox2.Text = "";
            }

            conn.Close();

        }
    }
}