namespace Pood
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.toode_pb = new System.Windows.Forms.PictureBox();
            this.toode = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Toode_txt = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.Kogus_txt = new System.Windows.Forms.TextBox();
            this.Hind_txt = new System.Windows.Forms.TextBox();
            this.lisaKATbtn = new System.Windows.Forms.Button();
            this.kustutaKATbtn = new System.Windows.Forms.Button();
            this.lisabtn = new System.Windows.Forms.Button();
            this.uuendabtn = new System.Windows.Forms.Button();
            this.kustutabtn = new System.Windows.Forms.Button();
            this.puhustaBTN = new System.Windows.Forms.Button();
            this.otsi_fail_click = new System.Windows.Forms.Button();
            this.pood_click = new System.Windows.Forms.Button();
            this.Kat_box1 = new System.Windows.Forms.ComboBox();
            this.naitabtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.toode_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // toode_pb
            // 
            this.toode_pb.Location = new System.Drawing.Point(473, 12);
            this.toode_pb.Name = "toode_pb";
            this.toode_pb.Size = new System.Drawing.Size(451, 196);
            this.toode_pb.TabIndex = 0;
            this.toode_pb.TabStop = false;
            this.toode_pb.Click += new System.EventHandler(this.toode_pb_Click);
            // 
            // toode
            // 
            this.toode.AutoSize = true;
            this.toode.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.toode.Location = new System.Drawing.Point(38, 54);
            this.toode.Name = "toode";
            this.toode.Size = new System.Drawing.Size(77, 24);
            this.toode.TabIndex = 1;
            this.toode.Text = "Toode:";
            this.toode.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label2.Location = new System.Drawing.Point(38, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Kogus:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label3.Location = new System.Drawing.Point(38, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 24);
            this.label3.TabIndex = 3;
            this.label3.Text = "Hind:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label4.Location = new System.Drawing.Point(38, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 24);
            this.label4.TabIndex = 4;
            this.label4.Text = "Kategooriad:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(42, 288);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(882, 273);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellMouseEnter);
            this.dataGridView1.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellMouseLeave);
            this.dataGridView1.MouseLeave += new System.EventHandler(this.dataGridView1_MouseLeave);
            this.dataGridView1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseMove);
            // 
            // Toode_txt
            // 
            this.Toode_txt.Location = new System.Drawing.Point(121, 54);
            this.Toode_txt.Name = "Toode_txt";
            this.Toode_txt.Size = new System.Drawing.Size(175, 20);
            this.Toode_txt.TabIndex = 6;
            // 
            // Kogus_txt
            // 
            this.Kogus_txt.Location = new System.Drawing.Point(121, 100);
            this.Kogus_txt.Name = "Kogus_txt";
            this.Kogus_txt.Size = new System.Drawing.Size(175, 20);
            this.Kogus_txt.TabIndex = 7;
            // 
            // Hind_txt
            // 
            this.Hind_txt.Location = new System.Drawing.Point(123, 140);
            this.Hind_txt.Name = "Hind_txt";
            this.Hind_txt.Size = new System.Drawing.Size(173, 20);
            this.Hind_txt.TabIndex = 8;
            // 
            // lisaKATbtn
            // 
            this.lisaKATbtn.Location = new System.Drawing.Point(40, 228);
            this.lisaKATbtn.Name = "lisaKATbtn";
            this.lisaKATbtn.Size = new System.Drawing.Size(141, 25);
            this.lisaKATbtn.TabIndex = 10;
            this.lisaKATbtn.Text = "Lisa kategooriat";
            this.lisaKATbtn.UseVisualStyleBackColor = true;
            this.lisaKATbtn.Click += new System.EventHandler(this.lisaKATbtn_Click);
            // 
            // kustutaKATbtn
            // 
            this.kustutaKATbtn.Location = new System.Drawing.Point(190, 228);
            this.kustutaKATbtn.Name = "kustutaKATbtn";
            this.kustutaKATbtn.Size = new System.Drawing.Size(141, 25);
            this.kustutaKATbtn.TabIndex = 11;
            this.kustutaKATbtn.Text = "Kustuta kategooriat";
            this.kustutaKATbtn.UseVisualStyleBackColor = true;
            this.kustutaKATbtn.Click += new System.EventHandler(this.kustutaKATbtn_Click);
            // 
            // lisabtn
            // 
            this.lisabtn.Cursor = System.Windows.Forms.Cursors.Default;
            this.lisabtn.Location = new System.Drawing.Point(42, 259);
            this.lisabtn.Name = "lisabtn";
            this.lisabtn.Size = new System.Drawing.Size(73, 23);
            this.lisabtn.TabIndex = 12;
            this.lisabtn.Text = "Lisa";
            this.lisabtn.UseVisualStyleBackColor = true;
            this.lisabtn.Click += new System.EventHandler(this.lisabtn_Click);
            // 
            // uuendabtn
            // 
            this.uuendabtn.Location = new System.Drawing.Point(119, 259);
            this.uuendabtn.Name = "uuendabtn";
            this.uuendabtn.Size = new System.Drawing.Size(62, 23);
            this.uuendabtn.TabIndex = 13;
            this.uuendabtn.Text = "Uuenda";
            this.uuendabtn.UseVisualStyleBackColor = true;
            this.uuendabtn.Click += new System.EventHandler(this.uuendabtn_Click);
            // 
            // kustutabtn
            // 
            this.kustutabtn.Location = new System.Drawing.Point(190, 259);
            this.kustutabtn.Name = "kustutabtn";
            this.kustutabtn.Size = new System.Drawing.Size(69, 23);
            this.kustutabtn.TabIndex = 14;
            this.kustutabtn.Text = "Kustuta";
            this.kustutabtn.UseVisualStyleBackColor = true;
            this.kustutabtn.Click += new System.EventHandler(this.kustutabtn_Click);
            // 
            // puhustaBTN
            // 
            this.puhustaBTN.Location = new System.Drawing.Point(265, 259);
            this.puhustaBTN.Name = "puhustaBTN";
            this.puhustaBTN.Size = new System.Drawing.Size(66, 23);
            this.puhustaBTN.TabIndex = 15;
            this.puhustaBTN.Text = "Puhusta";
            this.puhustaBTN.UseVisualStyleBackColor = true;
            this.puhustaBTN.Click += new System.EventHandler(this.button6_Click);
            // 
            // otsi_fail_click
            // 
            this.otsi_fail_click.Location = new System.Drawing.Point(337, 230);
            this.otsi_fail_click.Name = "otsi_fail_click";
            this.otsi_fail_click.Size = new System.Drawing.Size(75, 23);
            this.otsi_fail_click.TabIndex = 16;
            this.otsi_fail_click.Text = "Otsi fail";
            this.otsi_fail_click.UseVisualStyleBackColor = true;
            this.otsi_fail_click.Click += new System.EventHandler(this.button7_Click);
            // 
            // pood_click
            // 
            this.pood_click.Location = new System.Drawing.Point(337, 259);
            this.pood_click.Name = "pood_click";
            this.pood_click.Size = new System.Drawing.Size(75, 23);
            this.pood_click.TabIndex = 17;
            this.pood_click.Text = "Pood";
            this.pood_click.UseVisualStyleBackColor = true;
            this.pood_click.Click += new System.EventHandler(this.button8_Click);
            // 
            // Kat_box1
            // 
            this.Kat_box1.FormattingEnabled = true;
            this.Kat_box1.Location = new System.Drawing.Point(183, 187);
            this.Kat_box1.Name = "Kat_box1";
            this.Kat_box1.Size = new System.Drawing.Size(175, 21);
            this.Kat_box1.TabIndex = 19;
            this.Kat_box1.SelectedIndexChanged += new System.EventHandler(this.Kat_box1_SelectedIndexChanged);
            // 
            // naitabtn
            // 
            this.naitabtn.Location = new System.Drawing.Point(972, 360);
            this.naitabtn.Name = "naitabtn";
            this.naitabtn.Size = new System.Drawing.Size(80, 22);
            this.naitabtn.TabIndex = 20;
            this.naitabtn.Text = "Näita Kõik";
            this.naitabtn.UseVisualStyleBackColor = true;
            this.naitabtn.Click += new System.EventHandler(this.naitabtn_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 42);
            this.label1.TabIndex = 21;
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(15, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.label5.TabIndex = 22;
            this.label5.Text = "Balance:";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(103, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 23);
            this.label6.TabIndex = 23;
            this.label6.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 573);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.naitabtn);
            this.Controls.Add(this.Kat_box1);
            this.Controls.Add(this.pood_click);
            this.Controls.Add(this.otsi_fail_click);
            this.Controls.Add(this.puhustaBTN);
            this.Controls.Add(this.kustutabtn);
            this.Controls.Add(this.uuendabtn);
            this.Controls.Add(this.lisabtn);
            this.Controls.Add(this.kustutaKATbtn);
            this.Controls.Add(this.lisaKATbtn);
            this.Controls.Add(this.Hind_txt);
            this.Controls.Add(this.Kogus_txt);
            this.Controls.Add(this.Toode_txt);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.toode);
            this.Controls.Add(this.toode_pb);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.toode_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox toode_pb;
        private System.Windows.Forms.Label toode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox Toode_txt;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox Kogus_txt;
        private System.Windows.Forms.TextBox Hind_txt;
        private System.Windows.Forms.Button lisaKATbtn;
        private System.Windows.Forms.Button kustutaKATbtn;
        private System.Windows.Forms.Button lisabtn;
        private System.Windows.Forms.Button uuendabtn;
        private System.Windows.Forms.Button kustutabtn;
        private System.Windows.Forms.Button puhustaBTN;
        private System.Windows.Forms.Button otsi_fail_click;
        private System.Windows.Forms.Button pood_click;
        private System.Windows.Forms.ComboBox Kat_box1;
        private System.Windows.Forms.Button naitabtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}

