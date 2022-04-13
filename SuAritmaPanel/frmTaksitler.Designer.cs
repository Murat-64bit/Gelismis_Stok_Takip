
namespace SuAritmaPanel
{
    partial class frmTaksitler
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTaksitler));
            this.maskedTextBox2 = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.tpBitmisTaksitler = new System.Windows.Forms.TabPage();
            this.button6 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tpTahsilEt = new System.Windows.Forms.TabPage();
            this.label15 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.lbla5 = new System.Windows.Forms.Label();
            this.lbla4 = new System.Windows.Forms.Label();
            this.lbla3 = new System.Windows.Forms.Label();
            this.lbla2 = new System.Windows.Forms.Label();
            this.lbla1 = new System.Windows.Forms.Label();
            this.lbl5 = new System.Windows.Forms.Label();
            this.lbl4 = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.cmbAdSoyadTahsilat = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tpTaksitler = new System.Windows.Forms.TabPage();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOdeme = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbIlce = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbIl = new System.Windows.Forms.ComboBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.tpBitmisTaksitler.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tpTahsilEt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tpTaksitler.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // maskedTextBox2
            // 
            this.maskedTextBox2.Location = new System.Drawing.Point(758, 6);
            this.maskedTextBox2.Mask = "00/00/0000";
            this.maskedTextBox2.Name = "maskedTextBox2";
            this.maskedTextBox2.Size = new System.Drawing.Size(123, 33);
            this.maskedTextBox2.TabIndex = 18;
            this.maskedTextBox2.ValidatingType = typeof(System.DateTime);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(686, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 25);
            this.label4.TabIndex = 17;
            this.label4.Text = "TARİH:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(500, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 25);
            this.label5.TabIndex = 15;
            this.label5.Text = "İLÇE";
            // 
            // comboBox3
            // 
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(553, 5);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(121, 33);
            this.comboBox3.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(325, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 25);
            this.label6.TabIndex = 13;
            this.label6.Text = "İL";
            // 
            // comboBox4
            // 
            this.comboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(357, 5);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(121, 33);
            this.comboBox4.TabIndex = 12;
            this.comboBox4.SelectedIndexChanged += new System.EventHandler(this.comboBox4_SelectedIndexChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(189, 5);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(123, 33);
            this.textBox2.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(174, 25);
            this.label8.TabIndex = 10;
            this.label8.Text = "Müşteri AD SOYAD:";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView2.Location = new System.Drawing.Point(3, 40);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(1144, 345);
            this.dataGridView2.TabIndex = 8;
            // 
            // tpBitmisTaksitler
            // 
            this.tpBitmisTaksitler.Controls.Add(this.button6);
            this.tpBitmisTaksitler.Controls.Add(this.maskedTextBox2);
            this.tpBitmisTaksitler.Controls.Add(this.label4);
            this.tpBitmisTaksitler.Controls.Add(this.label5);
            this.tpBitmisTaksitler.Controls.Add(this.comboBox3);
            this.tpBitmisTaksitler.Controls.Add(this.label6);
            this.tpBitmisTaksitler.Controls.Add(this.comboBox4);
            this.tpBitmisTaksitler.Controls.Add(this.textBox2);
            this.tpBitmisTaksitler.Controls.Add(this.label8);
            this.tpBitmisTaksitler.Controls.Add(this.dataGridView2);
            this.tpBitmisTaksitler.Controls.Add(this.button2);
            this.tpBitmisTaksitler.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.tpBitmisTaksitler.Location = new System.Drawing.Point(4, 37);
            this.tpBitmisTaksitler.Name = "tpBitmisTaksitler";
            this.tpBitmisTaksitler.Padding = new System.Windows.Forms.Padding(3);
            this.tpBitmisTaksitler.Size = new System.Drawing.Size(1150, 388);
            this.tpBitmisTaksitler.TabIndex = 2;
            this.tpBitmisTaksitler.Text = "Bitmiş/Silinmiş Taksitler";
            this.tpBitmisTaksitler.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Image = ((System.Drawing.Image)(resources.GetObject("button6.Image")));
            this.button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button6.Location = new System.Drawing.Point(1009, 1);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(101, 38);
            this.button6.TabIndex = 44;
            this.button6.Text = "Yenile";
            this.button6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click_1);
            // 
            // button2
            // 
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(902, 1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(101, 39);
            this.button2.TabIndex = 16;
            this.button2.Text = "Ara";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(3, 42);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1144, 343);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // tpTahsilEt
            // 
            this.tpTahsilEt.BackColor = System.Drawing.SystemColors.Control;
            this.tpTahsilEt.Controls.Add(this.label15);
            this.tpTahsilEt.Controls.Add(this.button5);
            this.tpTahsilEt.Controls.Add(this.button4);
            this.tpTahsilEt.Controls.Add(this.lbla5);
            this.tpTahsilEt.Controls.Add(this.lbla4);
            this.tpTahsilEt.Controls.Add(this.lbla3);
            this.tpTahsilEt.Controls.Add(this.lbla2);
            this.tpTahsilEt.Controls.Add(this.lbla1);
            this.tpTahsilEt.Controls.Add(this.lbl5);
            this.tpTahsilEt.Controls.Add(this.lbl4);
            this.tpTahsilEt.Controls.Add(this.lbl3);
            this.tpTahsilEt.Controls.Add(this.lbl2);
            this.tpTahsilEt.Controls.Add(this.lbl1);
            this.tpTahsilEt.Controls.Add(this.cmbAdSoyadTahsilat);
            this.tpTahsilEt.Controls.Add(this.pictureBox1);
            this.tpTahsilEt.Location = new System.Drawing.Point(4, 37);
            this.tpTahsilEt.Name = "tpTahsilEt";
            this.tpTahsilEt.Padding = new System.Windows.Forms.Padding(3);
            this.tpTahsilEt.Size = new System.Drawing.Size(1150, 388);
            this.tpTahsilEt.TabIndex = 3;
            this.tpTahsilEt.Text = "Tahsil Oluştur";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(563, 65);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(73, 25);
            this.label15.TabIndex = 22;
            this.label15.Text = "label15";
            this.label15.Visible = false;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(3, 78);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(88, 89);
            this.button5.TabIndex = 21;
            this.button5.Text = "Müşteri Ürünler";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(3, 178);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(88, 42);
            this.button4.TabIndex = 19;
            this.button4.Text = "Oluştur";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // lbla5
            // 
            this.lbla5.AutoSize = true;
            this.lbla5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbla5.Location = new System.Drawing.Point(617, 235);
            this.lbla5.Name = "lbla5";
            this.lbla5.Size = new System.Drawing.Size(58, 20);
            this.lbla5.TabIndex = 13;
            this.lbla5.Text = "label16";
            // 
            // lbla4
            // 
            this.lbla4.AutoSize = true;
            this.lbla4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbla4.Location = new System.Drawing.Point(617, 213);
            this.lbla4.Name = "lbla4";
            this.lbla4.Size = new System.Drawing.Size(58, 20);
            this.lbla4.TabIndex = 12;
            this.lbla4.Text = "label17";
            // 
            // lbla3
            // 
            this.lbla3.AutoSize = true;
            this.lbla3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbla3.Location = new System.Drawing.Point(617, 191);
            this.lbla3.Name = "lbla3";
            this.lbla3.Size = new System.Drawing.Size(58, 20);
            this.lbla3.TabIndex = 11;
            this.lbla3.Text = "label18";
            // 
            // lbla2
            // 
            this.lbla2.AutoSize = true;
            this.lbla2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbla2.Location = new System.Drawing.Point(617, 169);
            this.lbla2.Name = "lbla2";
            this.lbla2.Size = new System.Drawing.Size(58, 20);
            this.lbla2.TabIndex = 10;
            this.lbla2.Text = "label19";
            // 
            // lbla1
            // 
            this.lbla1.AutoSize = true;
            this.lbla1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbla1.Location = new System.Drawing.Point(617, 147);
            this.lbla1.Name = "lbla1";
            this.lbla1.Size = new System.Drawing.Size(58, 20);
            this.lbla1.TabIndex = 9;
            this.lbla1.Text = "label20";
            // 
            // lbl5
            // 
            this.lbl5.AutoSize = true;
            this.lbl5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl5.Location = new System.Drawing.Point(134, 235);
            this.lbl5.Name = "lbl5";
            this.lbl5.Size = new System.Drawing.Size(58, 20);
            this.lbl5.TabIndex = 7;
            this.lbl5.Text = "label13";
            // 
            // lbl4
            // 
            this.lbl4.AutoSize = true;
            this.lbl4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl4.Location = new System.Drawing.Point(134, 213);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(58, 20);
            this.lbl4.TabIndex = 6;
            this.lbl4.Text = "label12";
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl3.Location = new System.Drawing.Point(134, 191);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(34, 20);
            this.lbl3.TabIndex = 5;
            this.lbl3.Text = "lbl3";
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl2.Location = new System.Drawing.Point(134, 169);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(34, 20);
            this.lbl2.TabIndex = 4;
            this.lbl2.Text = "lbl2";
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl1.Location = new System.Drawing.Point(134, 147);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(50, 20);
            this.lbl1.TabIndex = 3;
            this.lbl1.Text = "label9";
            // 
            // cmbAdSoyadTahsilat
            // 
            this.cmbAdSoyadTahsilat.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbAdSoyadTahsilat.FormattingEnabled = true;
            this.cmbAdSoyadTahsilat.Location = new System.Drawing.Point(193, 91);
            this.cmbAdSoyadTahsilat.Name = "cmbAdSoyadTahsilat";
            this.cmbAdSoyadTahsilat.Size = new System.Drawing.Size(360, 29);
            this.cmbAdSoyadTahsilat.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(97, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(958, 374);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // tpTaksitler
            // 
            this.tpTaksitler.Controls.Add(this.label11);
            this.tpTaksitler.Controls.Add(this.label10);
            this.tpTaksitler.Controls.Add(this.label9);
            this.tpTaksitler.Controls.Add(this.button1);
            this.tpTaksitler.Controls.Add(this.textBox1);
            this.tpTaksitler.Controls.Add(this.label1);
            this.tpTaksitler.Controls.Add(this.btnOdeme);
            this.tpTaksitler.Controls.Add(this.button3);
            this.tpTaksitler.Controls.Add(this.label3);
            this.tpTaksitler.Controls.Add(this.cmbIlce);
            this.tpTaksitler.Controls.Add(this.label2);
            this.tpTaksitler.Controls.Add(this.cmbIl);
            this.tpTaksitler.Controls.Add(this.textBox3);
            this.tpTaksitler.Controls.Add(this.label7);
            this.tpTaksitler.Controls.Add(this.dataGridView1);
            this.tpTaksitler.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tpTaksitler.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.tpTaksitler.Location = new System.Drawing.Point(4, 37);
            this.tpTaksitler.Name = "tpTaksitler";
            this.tpTaksitler.Padding = new System.Windows.Forms.Padding(3);
            this.tpTaksitler.Size = new System.Drawing.Size(1150, 388);
            this.tpTaksitler.TabIndex = 1;
            this.tpTaksitler.Text = "Taksitler";
            this.tpTaksitler.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(584, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(26, 25);
            this.label11.TabIndex = 46;
            this.label11.Text = "İL";
            this.label11.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(473, 6);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(26, 25);
            this.label10.TabIndex = 45;
            this.label10.Text = "İL";
            this.label10.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(419, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(26, 25);
            this.label9.TabIndex = 44;
            this.label9.Text = "İL";
            this.label9.Visible = false;
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(1026, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 35);
            this.button1.TabIndex = 43;
            this.button1.Text = "Yenile";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(43, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(66, 33);
            this.textBox1.TabIndex = 42;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 25);
            this.label1.TabIndex = 41;
            this.label1.Text = "ID";
            // 
            // btnOdeme
            // 
            this.btnOdeme.Image = ((System.Drawing.Image)(resources.GetObject("btnOdeme.Image")));
            this.btnOdeme.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOdeme.Location = new System.Drawing.Point(919, 4);
            this.btnOdeme.Name = "btnOdeme";
            this.btnOdeme.Size = new System.Drawing.Size(101, 35);
            this.btnOdeme.TabIndex = 40;
            this.btnOdeme.Text = "Ödeme";
            this.btnOdeme.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOdeme.UseVisualStyleBackColor = true;
            this.btnOdeme.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // button3
            // 
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(812, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(101, 35);
            this.button3.TabIndex = 39;
            this.button3.Text = "Ara";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(616, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 25);
            this.label3.TabIndex = 38;
            this.label3.Text = "İLÇE";
            // 
            // cmbIlce
            // 
            this.cmbIlce.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIlce.FormattingEnabled = true;
            this.cmbIlce.Location = new System.Drawing.Point(669, 6);
            this.cmbIlce.Name = "cmbIlce";
            this.cmbIlce.Size = new System.Drawing.Size(121, 33);
            this.cmbIlce.TabIndex = 37;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(441, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 25);
            this.label2.TabIndex = 36;
            this.label2.Text = "İL";
            // 
            // cmbIl
            // 
            this.cmbIl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIl.FormattingEnabled = true;
            this.cmbIl.Location = new System.Drawing.Point(473, 6);
            this.cmbIl.Name = "cmbIl";
            this.cmbIl.Size = new System.Drawing.Size(121, 33);
            this.cmbIl.TabIndex = 35;
            this.cmbIl.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(305, 6);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(123, 33);
            this.textBox3.TabIndex = 34;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(125, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(174, 25);
            this.label7.TabIndex = 33;
            this.label7.Text = "Müşteri AD SOYAD:";
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tpTahsilEt);
            this.tabControl1.Controls.Add(this.tpTaksitler);
            this.tabControl1.Controls.Add(this.tpBitmisTaksitler);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1158, 429);
            this.tabControl1.TabIndex = 2;
            // 
            // frmTaksitler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1158, 429);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmTaksitler";
            this.Text = "frmTaksitler";
            this.Activated += new System.EventHandler(this.frmTaksitler_Activated);
            this.Load += new System.EventHandler(this.frmTaksitler_Load);
            this.Click += new System.EventHandler(this.frmTaksitler_Click);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.tpBitmisTaksitler.ResumeLayout(false);
            this.tpBitmisTaksitler.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tpTahsilEt.ResumeLayout(false);
            this.tpTahsilEt.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tpTaksitler.ResumeLayout(false);
            this.tpTaksitler.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.MaskedTextBox maskedTextBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TabPage tpBitmisTaksitler;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabPage tpTahsilEt;
        private System.Windows.Forms.TabPage tpTaksitler;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOdeme;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbIlce;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbIl;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cmbAdSoyadTahsilat;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label lbla5;
        private System.Windows.Forms.Label lbla4;
        private System.Windows.Forms.Label lbla3;
        private System.Windows.Forms.Label lbla2;
        private System.Windows.Forms.Label lbla1;
        private System.Windows.Forms.Label lbl5;
        private System.Windows.Forms.Label lbl4;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
    }
}