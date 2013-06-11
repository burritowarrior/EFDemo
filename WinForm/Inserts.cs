using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WinForm
{
    public partial class Inserts : Form
    {
        private const string STR_CONNECTION = @"server=localhost;User Id=sqluser;Password=sqluser;database=development";

        public Inserts()
        {
            InitializeComponent();
        }

        private void Inserts_Load(object sender, System.EventArgs e)
        {

        }

        private void buttonSubmit_Click(object sender, System.EventArgs e)
        {
            try
            {
                using (var sqlConnection = new MySqlConnection(STR_CONNECTION))
                using (var sqlCommand = new MySqlCommand("InsertEmployee", sqlConnection))
                {
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add("firstName", MySqlDbType.VarChar, 15).Value = textBoxFirstName.Text.Trim();
                    sqlCommand.Parameters.Add("lastName", MySqlDbType.VarChar, 15).Value = textBoxLastName.Text.Trim();
                    sqlCommand.Parameters.Add("address", MySqlDbType.VarChar, 64).Value = textBoxAddress.Text.Trim();

                    sqlCommand.ExecuteNonQuery();

                    label1.Text = @"Success!";
                }
            }
            catch (MySqlException mse)
            {
                label1.Text = mse.Message;
            }

        }
    }
}
