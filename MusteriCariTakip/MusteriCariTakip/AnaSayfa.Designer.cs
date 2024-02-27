
namespace MusteriCariTakip
{
    partial class AnaSayfa
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
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dgvCustomers = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ColumnGoruntule = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnBorcEkle = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnOdemeEkle = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnMusteriDuzenle = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnMusteriSil = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(5, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "Anasayfa";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(334, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(158, 58);
            this.button1.TabIndex = 1;
            this.button1.Text = "Müşteri Ekle";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvCustomers
            // 
            this.dgvCustomers.AllowUserToAddRows = false;
            this.dgvCustomers.AllowUserToDeleteRows = false;
            this.dgvCustomers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCustomers.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnGoruntule,
            this.ColumnBorcEkle,
            this.ColumnOdemeEkle,
            this.ColumnMusteriDuzenle,
            this.ColumnMusteriSil});
            this.dgvCustomers.Location = new System.Drawing.Point(15, 141);
            this.dgvCustomers.Name = "dgvCustomers";
            this.dgvCustomers.ReadOnly = true;
            this.dgvCustomers.Size = new System.Drawing.Size(1162, 488);
            this.dgvCustomers.TabIndex = 2;
            this.dgvCustomers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dgvCustomers.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentDoubleClick);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button2.Location = new System.Drawing.Point(1011, 107);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(166, 28);
            this.button2.TabIndex = 3;
            this.button2.Text = "Tabloyu Yenile";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(170, 28);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(158, 58);
            this.button3.TabIndex = 4;
            this.button3.Text = "Ayarlar Ve Log Kayıtları";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(6, 28);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(158, 58);
            this.button4.TabIndex = 5;
            this.button4.Text = "Raporlar";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(677, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(500, 92);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "İşlemler";
            // 
            // ColumnGoruntule
            // 
            this.ColumnGoruntule.HeaderText = "Görüntüle";
            this.ColumnGoruntule.Name = "ColumnGoruntule";
            this.ColumnGoruntule.ReadOnly = true;
            this.ColumnGoruntule.Text = "";
            // 
            // ColumnBorcEkle
            // 
            this.ColumnBorcEkle.HeaderText = "Borç Ekle";
            this.ColumnBorcEkle.Name = "ColumnBorcEkle";
            this.ColumnBorcEkle.ReadOnly = true;
            this.ColumnBorcEkle.Text = "";
            // 
            // ColumnOdemeEkle
            // 
            this.ColumnOdemeEkle.HeaderText = "Ödeme Ekle";
            this.ColumnOdemeEkle.Name = "ColumnOdemeEkle";
            this.ColumnOdemeEkle.ReadOnly = true;
            this.ColumnOdemeEkle.Text = "";
            // 
            // ColumnMusteriDuzenle
            // 
            this.ColumnMusteriDuzenle.HeaderText = "Müşteri Düzenle";
            this.ColumnMusteriDuzenle.Name = "ColumnMusteriDuzenle";
            this.ColumnMusteriDuzenle.ReadOnly = true;
            this.ColumnMusteriDuzenle.Text = "";
            // 
            // ColumnMusteriSil
            // 
            this.ColumnMusteriSil.HeaderText = "Müşteri Sil";
            this.ColumnMusteriSil.Name = "ColumnMusteriSil";
            this.ColumnMusteriSil.ReadOnly = true;
            this.ColumnMusteriSil.Text = "";
            // 
            // AnaSayfa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1187, 640);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dgvCustomers);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "AnaSayfa";
            this.Text = "AnaSayfa";
            this.Load += new System.EventHandler(this.AnaSayfa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgvCustomers;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnGoruntule;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnBorcEkle;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnOdemeEkle;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnMusteriDuzenle;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnMusteriSil;
    }
}