using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace DatabaseExample
{
    public partial class Database_Example : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=D:\maxcity\data.mdf;
        Integrated Security=True;User Instance=True");
        String hash = "S#e|-|@N";
        String password = "";
      
        public Database_Example()
        {
            InitializeComponent();
        }

        private bool isvalid()
        {

            if (Name.Text.Trim() == string.Empty)
            {
                MessageBox.Show(" Name required", "Error");
                Name.Focus();
                return false;
            }
            if (ID.Text.Trim() == string.Empty)
            {
                MessageBox.Show(" ID required", "Error");
                ID.Focus();
                return false;
            }
            if (Mobile.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Mobile required", "Error");
                Mobile.Focus();
                return false;
            }
            if (Username.Text.Trim() == string.Empty)
            {
                MessageBox.Show(" Username required", "Error");
                Username.Focus();
                return false;
            }
            if (PasswordBox.Text.Trim() == string.Empty)
            {
                MessageBox.Show(" Password required", "Error");
                PasswordBox.Focus();
                return false;
            }
            if (Mobile.Text.Trim() != String.Empty)
            {
                int telephone;
                bool isNumeric = int.TryParse(Mobile.Text.Trim(), out telephone);
                if (!isNumeric)
                {
                    connection.Close();
                    MessageBox.Show("Mobile should be numbers", "Error");
                    Mobile.Focus();
                    return false;
                }
            }
            return true;
        }

        private void Search_Click(object sender, EventArgs e)
        {
            Database_Example example = new Database_Example();
            connection.Open();
           
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            if (ID.Text.Trim() != string.Empty)
            {
                command.CommandText = "Select * from Account where ID= '" + ID.Text.Trim() + "' ";

                SqlDataReader dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {
                    Name.Text = dataReader.GetString(0).Trim();
                    string cons2 = dataReader.GetString(2).Trim();
                    string cons3 = dataReader.GetString(3).Trim();
                    string cons4 = dataReader.GetString(4).Trim();
                    string cons5 = dataReader.GetString(5).Trim();
                    string cons6 = dataReader.GetString(6).Trim();
                    
                    Mobile.Text = cons2;
                    Post.Text = cons3;
                    Username.Text = cons4;
                    PasswordBox.Text = cons5;
                    dataReader.Close();

                }
                else
                {
                    dataReader.Close();
                    MessageBox.Show("Invalid Data");
                    this.Hide();
                    example.Show();
                    Name.Focus();
                }
            }
            else
            {
                MessageBox.Show("Invalid Data");
                this.Hide();
                example.Show();
                Name.Focus();
            }
            connection.Close();

        }

        private void Save_Click(object sender, EventArgs e)
        {
            Database_Example example = new Database_Example();
            byte[] data = UTF8Encoding.UTF8.GetBytes(PasswordBox.Text);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tps = new TripleDESCryptoServiceProvider() { Key = keys, 
                    Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform trans = tps.CreateEncryptor();
                    byte[] result = trans.TransformFinalBlock(data, 0, data.Length);
                    password = Convert.ToBase64String(result, 0, result.Length);

                }
            }
            if (isvalid())
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM Account WHERE ID='" + ID.Text.Trim() + "'";
                SqlDataReader dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {
                    MessageBox.Show("ID available", "Error");
                    ID.Focus();
                    connection.Close();
                }
                else
                {
                    SqlCommand command2 = new SqlCommand();
                    command2.CommandText = "Insert into Account values ('" + Name.Text.Trim() + "','" + ID.Text.Trim() 
                    + "','" + Mobile.Text.Trim() + "','" + Post.Text.Trim() + "','" + Username.Text.Trim() + "','" + 
                    password.Trim() + "','" + "A" + "')";
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command2.CommandText, connection.ConnectionString);
                    DataTable dt = new DataTable();
                    dataAdapter.Fill(dt);
                    MessageBox.Show("Successfully Saved");
                    connection.Close();
                    example.Show();
                    this.Hide();


                }
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            Database_Example example = new Database_Example();
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;

            command.CommandText = "Select * from Account where ID= '" + ID.Text.Trim() + "' ";

            SqlDataReader dataReader = command.ExecuteReader();
            if (ID.Text.Trim() == "001")
            {
                MessageBox.Show("Admin cannot remove");
                ID.Focus();
            }
            else if (dataReader.Read())
            {
                command.CommandText = "Delete from Account where ID='" + ID.Text.Trim() + "'";
                dataReader.Close();
                command.ExecuteNonQuery();
                MessageBox.Show("Deleted");
                example.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invaid ID ");
            }

            connection.Close();
        }

        private void Update_Click(object sender, EventArgs e)
        {
            Database_Example example = new Database_Example();
            byte[] data = UTF8Encoding.UTF8.GetBytes(PasswordBox.Text);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tps = new TripleDESCryptoServiceProvider() { Key = keys,
                    Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform trans = tps.CreateEncryptor();
                    byte[] result = trans.TransformFinalBlock(data, 0, data.Length);
                    password = Convert.ToBase64String(result, 0, result.Length);

                }
            }
            if (isvalid())
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM Account WHERE ID='" + ID.Text.Trim() + "'";
                SqlDataReader dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {
                    command.CommandText = "UPDATE Account SET Name='" + Name.Text.Trim() + "',Mobile='"
                        + Mobile.Text.Trim() + "',Post='" + Post.Text.Trim() + "',UserName='" + Username.Text.Trim() +
                        "',Password='" + password.Trim() + "',Type='" + "A" + "' WHERE ID='" + ID.Text.Trim() + "' ";
                    dataReader.Close();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Updated");
                    this.Hide();
                    example.Show();
                }
                else { MessageBox.Show("Invaid ID", "Error"); }
                connection.Close();
            }
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            Database_Example example = new Database_Example();
            example.Show();
            this.Hide();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
