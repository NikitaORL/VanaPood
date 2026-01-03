using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Pood
{
    public partial class Form1 : Form
    {
        int balance = 0;
        string extension = null;
        //C:\Users\opilane\Source\Repos\Pood2\Pood2\Tooded_DB.mdf
        SqlConnection connect = new SqlConnection(
    @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Tooded_DB.mdf;Integrated Security=True");
        SqlDataAdapter adapter_toode, adapter_kategooria;
        SqlCommand command;
        public Form1()
        {
            InitializeComponent();
            NaitaAndmed();
            Naitakategooriad();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Toode_txt.Text = "";
            Kogus_txt.Text = "";
            Hind_txt.Text = "";
            Kat_box1.SelectedItem = null;
            using (FileStream fs = new FileStream(Path.Combine(Path.GetFullPath(@"..\..\Image"), "nikita.png"), FileMode.Open, FileAccess.Read))
            {
                toode_pb.Image = Image.FromStream(fs);
            }
        }
        SaveFileDialog save;
        OpenFileDialog open;

        private void button7_Click(object sender, EventArgs e)
        {
            open = new OpenFileDialog();
            open.InitialDirectory = @"C:\Users\opilane\source\repos\Pood2\Pood2/images";
            open.Multiselect = true;
            open.Filter = "Images Files(*.jpeg;*.bmp;*.png;*.jpg)|*.jpeg;*.bmp;*.png;*.jpg";

            FileInfo open_info = new FileInfo(@"C:\Users\opilane\source\repos\Pood2\Pood2/Image" + open.FileName);
            if (open.ShowDialog() == DialogResult.OK && Toode_txt.Text != null)
            {
                save = new SaveFileDialog();
                save.InitialDirectory = Path.GetFullPath(@"..\..\images");

                save.FileName = Toode_txt.Text + Path.GetExtension(open.FileName);
                save.Filter = "Image Files|" + "*" + Path.GetExtension(open.FileName) + "|All files|*.*";


                if (save.ShowDialog() == DialogResult.OK && Toode_txt.Text != null)
                {
                    File.Copy(open.FileName, save.FileName);
                    toode_pb.Image = Image.FromFile(save.FileName);
                }
            }
            else
            {
                MessageBox.Show("Puudub toode nimetus või oli vajutatud Cancel");
            }
        }

        private void Kat_box1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        Form popupForm;
        private void Loopilt(Image image, int r)
        {
            popupForm = new Form();
            popupForm.FormBorderStyle = FormBorderStyle.None;
            popupForm.StartPosition = FormStartPosition.Manual;
            popupForm.Size = new Size(200, 200);

            PictureBox pictureBox = new PictureBox();
            pictureBox.Image = image;
            pictureBox.Dock = DockStyle.Fill;
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;

            popupForm.Controls.Add(pictureBox);

            System.Drawing.Rectangle cellRectangle = dataGridView1.GetCellDisplayRectangle(4, r, true);
            System.Drawing.Point popupLocation = dataGridView1.PointToScreen(cellRectangle.Location);

            popupForm.Location = new System.Drawing.Point(popupLocation.X + cellRectangle.Width, popupLocation.Y);
            popupForm.Show();

        }

        public void NaitaAndmed()
        {
            connect.Open();
            DataTable dt_toode = new DataTable();
            adapter_toode = new SqlDataAdapter(
    "SELECT ToodeTabel.Id, ToodeTabel.Toodenimetus, ToodeTabel.Kogus, " +
    "ToodeTabel.Hind, ToodeTabel.Pilt, ToodeTabel.BPilt, " +
    "KategooriaTabel.Kategooria_nimetus AS Kategooria_nimetus " +
    "FROM ToodeTabel INNER JOIN KategooriaTabel ON ToodeTabel.Kategooriad = KategooriaTabel.Id",
    connect);
            adapter_toode.Fill(dt_toode);
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = dt_toode;
            DataGridViewComboBoxColumn combo_kat = new DataGridViewComboBoxColumn();
            combo_kat.DataPropertyName = "Kategooria_nimetus";
            HashSet<string> keys = new HashSet<string>();
            foreach (DataRow item in dt_toode.Rows)
            {
                string kat_n = item["Kategooria_nimetus"].ToString();
                if (!keys.Contains(kat_n))
                {
                    keys.Add(kat_n);
                    combo_kat.Items.Add(kat_n);

                }
            }
            dataGridView1.Columns.Add(combo_kat);
            toode_pb.Image = Image.FromFile(Path.Combine(Path.GetFullPath(@"..\..\Image"), "nikita.png"));
            connect.Close();
        }
        private void lisaKATbtn_Click(object sender, EventArgs e)
        {
            bool on = false;
            foreach (var item in Kat_box1.Items)
            {
                if (item.ToString() == Kat_box1.Text)
                {
                    on = true;
                }
            }

            if (on == false)
            {
                command = new SqlCommand("INSERT INTO Kategooriatabel (Kategooria_nimetus) VALUES (@kat)", connect);
                connect.Open();
                command.Parameters.AddWithValue("@kat", Kat_box1.Text);
                command.ExecuteNonQuery();
                connect.Close();
                Kat_box1.Items.Clear();
                Naitakategooriad();
            }
            else
            {
                MessageBox.Show("Selline kategooria on juba olemas");
            }
        }

        private void kustutaKATbtn_Click(object sender, EventArgs e)
        {
            if (Kat_box1.SelectedItem != null)
            {
                connect.Open();
                string kat_val = Kat_box1.SelectedItem.ToString();
                command = new SqlCommand("delete from Kategooriatabel where Kategooria_nimetus=@kat ", connect);
                command.Parameters.AddWithValue("@kat", kat_val);
                command.ExecuteNonQuery();
                connect.Close();
                Kat_box1.Items.Clear();
                Naitakategooriad();
            }
        }

        private void toode_pb_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void dataGridView1_MouseLeave(object sender, EventArgs e)
        {

        }
        byte[] imageData;
        //private void dataGridView1_MouseEnter(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.RowIndex >= 0 && e.ColumnIndex == 4)
        //    {
        //        imageData = dataGridView1.Rows[e.RowIndex].Cells["Bpilt"].Value as byte[];
        //        if (imageData != null)
        //        {
        //            using (MemoryStream ms = new MemoryStream(imageData))
        //            {
        //                Image image = Image.FromStream(ms);
        //                Loopilt(image, e.RowIndex);
        //            }
        //        }
        //    }

        //}

        private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 4)
            {
                imageData = dataGridView1.Rows[e.RowIndex].Cells["Bpilt"].Value as byte[];
                if (imageData != null)
                {
                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        Image image = Image.FromStream(ms);
                        Loopilt(image, e.RowIndex);
                    }
                }
            }
        }

        private void dataGridView1_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (popupForm != null && !popupForm.IsDisposed)
            {
                popupForm.Close();
            }
        }
        private void lisabtn_Click(object sender, EventArgs e)
        {
            if (Toode_txt.Text.Trim() != string.Empty &&
                Kogus_txt.Text.Trim() != string.Empty &&
                Hind_txt.Text.Trim() != string.Empty &&
                Kat_box1.SelectedItem != null)
            {
                if (open == null || string.IsNullOrEmpty(open.FileName))
                {
                    MessageBox.Show("Palun vali esmalt toote pilt!", "Viga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    using (SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Tooded_DB.mdf;Integrated Security=True"))
                    {
                        conn.Open();

                        int Id;
                        using (SqlCommand cmd = new SqlCommand("SELECT Id FROM KategooriaTabel WHERE Kategooria_nimetus=@kat", conn))
                        {
                            cmd.Parameters.AddWithValue("@kat", Kat_box1.Text);
                            Id = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        using (SqlCommand cmd = new SqlCommand(
                            "INSERT INTO ToodeTabel (Toodenimetus, Kogus, Hind, Pilt, BPilt, Kategooriad) " +
                            "VALUES (@toode, @kogus, @hind, @pilt, @bpilt, @kat)", conn))
                        {
                            cmd.Parameters.AddWithValue("@toode", Toode_txt.Text);
                            cmd.Parameters.AddWithValue("@kogus", Kogus_txt.Text);
                            cmd.Parameters.AddWithValue("@hind", Hind_txt.Text);

                            string extension = Path.GetExtension(open.FileName);
                            cmd.Parameters.AddWithValue("@pilt", Toode_txt.Text + extension);

                            byte[] imageData = File.ReadAllBytes(open.FileName);
                            cmd.Parameters.AddWithValue("@bpilt", imageData);

                            cmd.Parameters.AddWithValue("@kat", Id);

                            cmd.ExecuteNonQuery();
                        }
                    }

                    NaitaAndmed();

                    // Исправлено на balanceLabel
                    balance += 10;
                    label6.Text = balance + " €";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Andmebaasiga viga! " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Palun täida kõik väljad!", "Viga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void kustutabtn_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);
            MessageBox.Show(Id.ToString());
            if (Id != 0)
            {
                command = new SqlCommand("DELETE FROM ToodeTabel WHERE Id=@id", connect);

                connect.Open();
                command.Parameters.AddWithValue("@id", Id);
                command.ExecuteNonQuery();
                connect.Close();
                NaitaAndmed();
                MessageBox.Show("Andmed tabelist Tooded on Kustatud");


            }
            else
            {
                MessageBox.Show("Viga Tooted tabelist admete kustutamisega");
            }
        }

        private void uuendabtn_Click(object sender, EventArgs e)
        {
            if (Toode_txt.Text != "" && Kogus_txt.Text != "" && Hind_txt.Text != "" && toode_pb.Image != null)
            {

                int Id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);

                string file_pilt = Toode_txt.Text + extension;

                MemoryStream ms = new MemoryStream();
                toode_pb.Image.Save(ms, toode_pb.Image.RawFormat);
                byte[] imgBytes = ms.ToArray();

                using (SqlCommand command = new SqlCommand(
                    "UPDATE ToodeTabel SET Toodenimetus=@toode, Kogus=@kogus, Hind=@hind, Pilt=@pilt, BPilt=@BPilt WHERE Id=@id",
                    connect))
                {
                    command.Parameters.AddWithValue("@id", Id);
                    command.Parameters.AddWithValue("@toode", Toode_txt.Text);
                    command.Parameters.AddWithValue("@kogus", Convert.ToInt32(Kogus_txt.Text));
                    command.Parameters.AddWithValue("@hind", Convert.ToDouble(Hind_txt.Text));
                    command.Parameters.AddWithValue("@pilt", file_pilt);
                    command.Parameters.Add("@BPilt", SqlDbType.VarBinary).Value = imgBytes;

                    connect.Open();
                    command.ExecuteNonQuery();
                    connect.Close();
                }

                NaitaAndmed();
                MessageBox.Show("Andmed uuendatud");


            }
            else
            {
                MessageBox.Show("Palun täida kõik väljad ja lisa pilt");
            }
        }

        private void naitabtn_Click(object sender, EventArgs e)
        {
            this.Size = new Size(1350, 600);

            // Создаем TabControl
            TabControl kategooriad = new TabControl();
            kategooriad.Name = "Kategooriad";
            kategooriad.Width = 450;
            kategooriad.Height = this.Height;
            kategooriad.Location = new System.Drawing.Point(900, 0);

            connect.Open();

            // Загружаем категории
            SqlDataAdapter adapter_kategooria = new SqlDataAdapter(
                "SELECT Id, Kategooria_nimetus FROM KategooriaTabel", connect);
            DataTable dt_kat = new DataTable();
            adapter_kategooria.Fill(dt_kat);

            // ImageList для вкладок
            ImageList iconsList = new ImageList();
            iconsList.ColorDepth = ColorDepth.Depth32Bit;
            iconsList.ImageSize = new Size(25, 25);

            int i = 0;
            foreach (DataRow nimetus in dt_kat.Rows)
            {
                // Добавляем вкладку
                kategooriad.TabPages.Add((string)nimetus["Kategooria_nimetus"]);
                kategooriad.TabPages[i].ImageIndex = i;

                // Получаем Id категории
                int kat_Id = (int)nimetus["Id"];

                // Загружаем файлы прямо здесь
                SqlDataAdapter adapter_failid = new SqlDataAdapter(
                    "SELECT Pilt FROM ToodeTabel WHERE Kategooriad=@id", connect);
                adapter_failid.SelectCommand.Parameters.AddWithValue("@id", kat_Id);
                DataTable dt_failid = new DataTable();
                adapter_failid.Fill(dt_failid);

                int r = 0;
                int c = 0;

                foreach (DataRow fail in dt_failid.Rows)
                {
                    if (fail["Pilt"] != DBNull.Value)
                    {
                        PictureBox pictureBox = new PictureBox();
                        pictureBox.Image = Image.FromFile(@"..\..\Image\" + fail["Pilt"].ToString());
                        pictureBox.Width = pictureBox.Height = 100;
                        pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                        pictureBox.Location = new System.Drawing.Point(c, r);

                        c += 100 + 2; // следующий элемент справа
                        kategooriad.TabPages[i].Controls.Add(pictureBox);
                    }
                }

                i++;
            }

            kategooriad.ImageList = iconsList;
            connect.Close();
            this.Controls.Add(kategooriad);

        }


        public void Naitakategooriad()
        {
            connect.Open();
            adapter_kategooria = new SqlDataAdapter("Select Id,Kategooria_nimetus FROM Kategooriatabel", connect);
            DataTable dt_kat = new DataTable();
            adapter_kategooria.Fill(dt_kat);
            foreach (DataRow item in dt_kat.Rows)
            {
                if (!Kat_box1.Items.Contains(item["Kategooria_nimetus"]))
                {
                    Kat_box1.Items.Add(item["Kategooria_nimetus"]);
                }
                else
                {
                    command = new SqlCommand("Delete from Kategooriatabel where Id=@id", connect);
                    command.Parameters.AddWithValue("@id", item["Id"]);
                    command.ExecuteNonQuery();
                }
            }
            connect.Close();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        public void Balance()
        {
            string balance = label1.Text;
            label1.Text = "5";
            MessageBox.Show("Palk:", balance);
        }


        private void button8_Click(object sender, EventArgs e)
        {
            Form2 shopForm = new Form2();
            shopForm.Show();
        }
    }
}
