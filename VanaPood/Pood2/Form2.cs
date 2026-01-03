using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Pood
{
    public partial class Form2 : Form
    {
        SqlConnection connect = new SqlConnection(
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Tooded_DB.mdf;Integrated Security=True");

        SqlDataAdapter adapter;
        private Button ostaButton;
        private NumericUpDown kogusNumeric;
        private Label summaLabel;
        private int selectedProductId = 0;
        private decimal selectedProductPrice = 0;
        private int selectedProductQuantity = 0;
        private string selectedProductName = "";

        public Form2()
        {
            InitializeComponent();
            InitializeCustomComponents();
            NaitaAndmed();
        }

        private void InitializeCustomComponents()
        {
            // NumericUpDown koguse valimiseks
            kogusNumeric = new NumericUpDown
            {
                Location = new Point(400, 50),
                Width = 80,
                Minimum = 1,
                Maximum = 1000,
                Value = 1,
                Enabled = false,
                Font = new Font("Microsoft Sans Serif", 9)
            };
            kogusNumeric.ValueChanged += KogusNumeric_ValueChanged;

            // Ostu nupp
            ostaButton = new Button
            {
                Text = "OSTA",
                Location = new Point(490, 48),
                Width = 80,
                Height = 28,
                Enabled = false,
                BackColor = Color.LightGreen,
                Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold)
            };
            ostaButton.Click += OstaButton_Click;

            // Summa kuvamiseks
            summaLabel = new Label
            {
                Text = "Kogusumma: 0 €",
                Location = new Point(580, 52),
                Width = 150,
                Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold),
                ForeColor = Color.DarkRed
            };

            // Koguse silt
            Label kogusSilt = new Label
            {
                Text = "Kogus:",
                Location = new Point(330, 52),
                Width = 70,
                Font = new Font("Microsoft Sans Serif", 9)
            };


            // Lisa elemendid vormile
            Controls.Add(kogusSilt);
            Controls.Add(kogusNumeric);
            Controls.Add(ostaButton);
            Controls.Add(summaLabel);
            

            // DataGridView valiku muutmise töötleja
            dataGridViewPood.SelectionChanged += DataGridViewPood_SelectionChanged;
        }

        private void DataGridViewPood_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewPood.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridViewPood.SelectedRows[0];

                // Hangi valitud toote andmed
                selectedProductId = Convert.ToInt32(selectedRow.Cells["Id"].Value);
                selectedProductName = selectedRow.Cells["Toodenimetus"].Value.ToString();
                selectedProductPrice = Convert.ToDecimal(selectedRow.Cells["Hind"].Value);
                selectedProductQuantity = Convert.ToInt32(selectedRow.Cells["Kogus"].Value);

                // Määra maksimaalne ostuks kogus
                kogusNumeric.Maximum = selectedProductQuantity;
                kogusNumeric.Value = 1;
                kogusNumeric.Enabled = true;

                // Luba ostu nupp
                ostaButton.Enabled = true;

                // Uuenda kogusummat
                UpdateTotalPrice();
            }
            else
            {
                kogusNumeric.Enabled = false;
                ostaButton.Enabled = false;
                summaLabel.Text = "Kogusumma: 0 €";
            }
        }

        private void KogusNumeric_ValueChanged(object sender, EventArgs e)
        {
            UpdateTotalPrice();
        }

        private void UpdateTotalPrice()
        {
            decimal total = selectedProductPrice * kogusNumeric.Value;
            summaLabel.Text = $"Kogusumma: {total:F2} €";
        }

        private void OstaButton_Click(object sender, EventArgs e)
        {
            if (selectedProductId == 0)
            {
                MessageBox.Show("Palun vali ostmiseks toode!", "Viga",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int purchaseQuantity = (int)kogusNumeric.Value;

            if (purchaseQuantity > selectedProductQuantity)
            {
                MessageBox.Show($"Pole piisavalt laos! Saadaval: {selectedProductQuantity} tk.",
                    "Viga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Ostu kinnitamine
            DialogResult result = MessageBox.Show(
                $"Kas oled kindel, et soovid osta {purchaseQuantity} tk seda toodet?\nKogusumma: {purchaseQuantity * selectedProductPrice:F2} €",
                "Kinnita ost",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    connect.Open();

                    // Uuenda toote kogust andmebaasis
                    using (SqlCommand updateCmd = new SqlCommand(
                        "UPDATE ToodeTabel SET Kogus = Kogus - @quantity WHERE Id = @id AND Kogus >= @quantity",
                        connect))
                    {
                        updateCmd.Parameters.AddWithValue("@id", selectedProductId);
                        updateCmd.Parameters.AddWithValue("@quantity", purchaseQuantity);

                        int rowsAffected = updateCmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // Ost õnnestus
                            MessageBox.Show($"Ost sooritatud!\nOstetud: {purchaseQuantity} tk\nSumma: {purchaseQuantity * selectedProductPrice:F2} €",
                                "Õnnestus", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Uuenda andmete kuvamist
                            NaitaAndmed();

                            // Lähtesta valik
                            dataGridViewPood.ClearSelection();
                            selectedProductId = 0;
                            kogusNumeric.Value = 1;
                            kogusNumeric.Enabled = false;
                            ostaButton.Enabled = false;
                            summaLabel.Text = "Kogusumma: 0 €";
                        }
                        else
                        {
                            MessageBox.Show("Ostu sooritamine ebaõnnestus. Toode võib olla otsas.",
                                "Viga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ostu ajal tekkis viga: {ex.Message}", "Viga",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connect.Close();
                }
            }
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
                    "INNER JOIN KategooriaTabel ON ToodeTabel.Kategooriad = KategooriaTabel.Id " +
                    "WHERE ToodeTabel.Kogus > 0",
                    connect);

                adapter.Fill(dt);

                dataGridViewPood.Columns.Clear();
                dataGridViewPood.DataSource = dt;
                dataGridViewPood.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Seadista veergude kuvamine
                if (dataGridViewPood.Columns.Count > 0)
                {
                    dataGridViewPood.Columns["Id"].Visible = false;
                    dataGridViewPood.Columns["Kogus"].HeaderText = "Kogus";
                    dataGridViewPood.Columns["Hind"].HeaderText = "Hind (€)";
                    dataGridViewPood.Columns["Toodenimetus"].HeaderText = "Toote nimi";
                    dataGridViewPood.Columns["Kategooria"].HeaderText = "Kategooria";
                    dataGridViewPood.Columns["Pilt"].HeaderText = "Pilt";
                }

                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Andmete laadimise viga: " + ex.Message);
                connect.Close();
            }
        }

        // Tühjad Designer'i sündmuste töötlejad
        private void Form2_Load(object sender, EventArgs e) { }
        private void dataGridViewPood_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}