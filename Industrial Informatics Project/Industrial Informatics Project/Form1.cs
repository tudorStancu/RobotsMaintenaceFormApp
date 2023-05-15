using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Collections;
using System.Diagnostics;

namespace Industrial_Informatics_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadDB();
            loadDBManufacturers();
            loadComboBox();
            Font f = new Font("Arial", 20);
            label8.Font = f;
        }

        //Method that loads the whole db
        private void loadDB()
        {
            string con = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\stanc\Desktop\Faculta anu 3\Sem 2\C#\Industrial Informatics Project\Industrial Informatics Project\Database1.mdf; Integrated Security = True";
            SqlConnection cn_connection = new SqlConnection(con);

            if (cn_connection.State != ConnectionState.Open) cn_connection.Open();

            string sql_Text = "SELECT * FROM tableRobots";
            
            SqlDataAdapter adapter = new SqlDataAdapter(sql_Text, cn_connection);
            DataTable tbl = new DataTable();
            adapter.Fill(tbl);
           
            dataGridView1.DataSource = tbl;
            dataGridView3.DataSource = tbl;
          
        }
        private void loadDBManufacturers()
        {
            string con = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\stanc\Desktop\Faculta anu 3\Sem 2\C#\Industrial Informatics Project\Industrial Informatics Project\Database1.mdf; Integrated Security = True";
            SqlConnection cn_connection = new SqlConnection(con);

            if (cn_connection.State != ConnectionState.Open) cn_connection.Open();

            string sql_Text = "SELECT * FROM tableManufacturers";

            SqlDataAdapter adapter = new SqlDataAdapter(sql_Text, cn_connection);
            DataTable tbl = new DataTable();
            adapter.Fill(tbl);

            dataGridView2.DataSource = tbl;

        }
        private void loadComboBox()
        {
            string con = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\stanc\Desktop\Faculta anu 3\Sem 2\C#\Industrial Informatics Project\Industrial Informatics Project\Database1.mdf; Integrated Security = True";
            SqlConnection cn_connection = new SqlConnection(con);

            if (cn_connection.State != ConnectionState.Open) cn_connection.Open();

            string sql_Text = "SELECT Name FROM tableManufacturers";

            SqlDataAdapter adapter = new SqlDataAdapter(sql_Text, cn_connection);
            DataTable tbl = new DataTable();
            adapter.Fill(tbl);

            for (int i=0 ; i<tbl.Rows.Count ; i++)
            {
                comboBox1.Items.Add(tbl.Rows[i]["Name"].ToString());
            }

        }
        

        //add button
        private void button1_Click_1(object sender, EventArgs e)
        {
            string con = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\stanc\Desktop\Faculta anu 3\Sem 2\C#\Industrial Informatics Project\Industrial Informatics Project\Database1.mdf; Integrated Security = True";
            SqlConnection cn_connection = new SqlConnection(con);

            if (cn_connection.State != ConnectionState.Open) cn_connection.Open();

            string manufacturer = comboBox1.SelectedItem.ToString();
            string type = textBox2.Text;
            string price = textBox3.Text;
            string stock = textBox4.Text;

            string sql_Text = "INSERT into tableRobots ([Manufacturer], [Type], [Price], [Stock]) VALUES (" +
            "'" + manufacturer + "'," +
            "'" + type + "'," +
            "'" + price + "'," +
            "'" + stock + "')";

            SqlCommand sql_com = new SqlCommand(sql_Text, cn_connection);
            sql_com.ExecuteNonQuery();
            loadDB();
            MessageBox.Show("Robot added!");
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string con = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\stanc\Desktop\Faculta anu 3\Sem 2\C#\Industrial Informatics Project\Industrial Informatics Project\Database1.mdf; Integrated Security = True";
            SqlConnection cn_connection = new SqlConnection(con);

            if (cn_connection.State != ConnectionState.Open) cn_connection.Open();

            DataGridViewRow row = dataGridView1.CurrentRow;
            string rowIndex = row.Cells[0].Value.ToString();
            string sql_Text = "DELETE FROM tableRobots WHERE (ID=" + rowIndex + ")";

            SqlCommand sql_com = new SqlCommand(sql_Text, cn_connection);

            sql_com.ExecuteNonQuery();

            loadDB();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string con = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\stanc\Desktop\Faculta anu 3\Sem 2\C#\Industrial Informatics Project\Industrial Informatics Project\Database1.mdf; Integrated Security = True";
            SqlConnection cn_connection = new SqlConnection(con);

            if (cn_connection.State != ConnectionState.Open) cn_connection.Open();

            string sql_Text = "SELECT * From tableRobots ORDER BY Price";

            SqlDataAdapter adapter = new SqlDataAdapter(sql_Text, cn_connection);
            DataTable tbl = new DataTable();
            adapter.Fill(tbl);

            dataGridView1.DataSource = tbl;
        }


        private void button4_Click(object sender, EventArgs e)
        {
            string con = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\stanc\Desktop\Faculta anu 3\Sem 2\C#\Industrial Informatics Project\Industrial Informatics Project\Database1.mdf; Integrated Security = True";
            SqlConnection cn_connection = new SqlConnection(con);

            if (cn_connection.State != ConnectionState.Open) cn_connection.Open();

            string manufacturer = comboBox1.SelectedItem.ToString();
            string type = textBox2.Text;
            string price = textBox3.Text;
            string stock = textBox4.Text;

            DataGridViewRow row = dataGridView1.CurrentRow;
            string rowIndex = row.Cells[0].Value.ToString();
            string sql_Text = "UPDATE tableRobots SET [Manufacturer] = '" + manufacturer +
                "', [Type] = '" + type +
                "', [Price] = '" + price +
                "', [Stock] = '" + stock +
                "' WHERE ID = " + rowIndex;

            SqlCommand sql_com = new SqlCommand(sql_Text, cn_connection);
            sql_com.ExecuteNonQuery();

            loadDB();
        }
        
        private void button8_Click_1(object sender, EventArgs e)
        {
            string con = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\stanc\Desktop\Faculta anu 3\Sem 2\C#\Industrial Informatics Project\Industrial Informatics Project\Database1.mdf; Integrated Security = True";
            SqlConnection cn_connection = new SqlConnection(con);

            if (cn_connection.State != ConnectionState.Open) cn_connection.Open();

            DataGridViewRow row = dataGridView3.CurrentRow;
            string rowIndex = row.Cells[0].Value.ToString();
            DateTime dt = dateTimePicker1.Value.ToUniversalTime();
            string log = textBox1.Text;

            string sql_Text = "INSERT into tableMaintenance ([robotID], [date], [logs]) VALUES (" +
            "'" + rowIndex + "'," +
            "'" + dt + "'," +
            "'" + log + "')";

            SqlCommand sql_com = new SqlCommand(sql_Text, cn_connection);
            sql_com.ExecuteNonQuery();
            MessageBox.Show("Log Added!");
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            string con = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\stanc\Desktop\Faculta anu 3\Sem 2\C#\Industrial Informatics Project\Industrial Informatics Project\Database1.mdf; Integrated Security = True";
            SqlConnection cn_connection = new SqlConnection(con);

            if (cn_connection.State != ConnectionState.Open) cn_connection.Open();

            DataGridViewRow row = dataGridView3.CurrentRow;
            string rowIndex = row.Cells[0].Value.ToString();


            string sql_Text = "SELECT logs from tableMaintenance WHERE (robotID = " + rowIndex + ")";


            DataTable tbl = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(sql_Text, cn_connection);
            adapter.Fill(tbl);

            string stgDeAfisat = "Logs for the selected robot:\n";
            
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                stgDeAfisat += tbl.Rows[i]["Logs"].ToString();
                stgDeAfisat += "\n";
            }
            MessageBox.Show(stgDeAfisat);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string con = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\stanc\Desktop\Faculta anu 3\Sem 2\C#\Industrial Informatics Project\Industrial Informatics Project\Database1.mdf; Integrated Security = True";
            SqlConnection cn_connection = new SqlConnection(con);

            if (cn_connection.State != ConnectionState.Open) cn_connection.Open();

            string sql_Text = "SELECT * From tableRobots ORDER BY Manufacturer";

            SqlDataAdapter adapter = new SqlDataAdapter(sql_Text, cn_connection);
            DataTable tbl = new DataTable();
            adapter.Fill(tbl);

            dataGridView1.DataSource = tbl;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(1);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(2);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(3);
        }

        //Manufacturer add
        private void button12_Click(object sender, EventArgs e)
        {

        }
    }
}


            