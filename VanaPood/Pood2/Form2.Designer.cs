namespace Pood
{
    partial class Form2
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
            this.nikitaPood = new System.Windows.Forms.Label();
            this.dataGridViewPood = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPood)).BeginInit();
            this.SuspendLayout();
            // 
            // nikitaPood
            // 
            this.nikitaPood.AutoSize = true;
            this.nikitaPood.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.nikitaPood.Location = new System.Drawing.Point(48, 9);
            this.nikitaPood.Name = "nikitaPood";
            this.nikitaPood.Size = new System.Drawing.Size(317, 29);
            this.nikitaPood.TabIndex = 1;
            this.nikitaPood.Text = "NIKITA ORLENKO POOD!";
            // 
            // dataGridViewPood
            // 
            this.dataGridViewPood.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPood.Location = new System.Drawing.Point(12, 219);
            this.dataGridViewPood.Name = "dataGridViewPood";
            this.dataGridViewPood.Size = new System.Drawing.Size(975, 307);
            this.dataGridViewPood.TabIndex = 2;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 538);
            this.Controls.Add(this.dataGridViewPood);
            this.Controls.Add(this.nikitaPood);
            this.Name = "Form2";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPood)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label nikitaPood;
        private System.Windows.Forms.DataGridView dataGridViewPood;
    }
}