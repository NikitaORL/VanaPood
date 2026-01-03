using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Pood
{
    public partial class Form2 : Form
    {
        SqlConnection connect = new SqlConnection(
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Tooded_DB.mdf;Integrated Security=True");

        SqlDataAdapter adapter;

        public Form2()
        {
            InitializeComponent();
            NaitaAndmed();
        }

        public void NaitaAndmed()
        {
            try
            {
                connect.Open();

                DataTable dt = new DataTable();

                adapter = new SqlDataAdapter(
                    "SELECT " +
                    "ToodeTabel.Id, " +
                    "ToodeTabel.Toodenimetus, " +
                    "ToodeTabel.Kogus, " +
                    "ToodeTabel.Hind, " +
                    "ToodeTabel.Pilt, " +
                    "KategooriaTabel.Kategooria_nimetus AS Kategooria " +
                    "FROM ToodeTabel " +
                    "INNER JOIN KategooriaTabel ON ToodeTabel.Kategooriad = KategooriaTabel.Id",
                    connect);

                adapter.Fill(dt);

                dataGridViewPood.Columns.Clear();
                dataGridViewPood.DataSource = dt;
                dataGridViewPood.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки данных: " + ex.Message);
                connect.Close();
            }
        }
    }
}
