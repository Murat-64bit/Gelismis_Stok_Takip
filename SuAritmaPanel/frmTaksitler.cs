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
using System.Collections;

namespace SuAritmaPanel
{
    public partial class frmTaksitler : Form
    {
        sqlbaglantisi bgl = new sqlbaglantisi();

        private void listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("select taksitID as 'ID' , musteri.musteriAdSoyad as 'Müşteri' , iller.sehir as 'İL' , ilceler.ilce as 'İlçe' , urunler.urunAD as 'Ürün' ,taksitAylikUcret as 'Ücret', taksitSayi as 'Taksit',taksitTarih as 'Ödeme Tarihi'  from taksitler " +
        "inner join musteri on taksitler.taksitMusteriid = musteri.musteriID " +
        " inner join iller on taksitler.taksitIl = iller.id " +
        "inner join ilceler on taksitler.taksitIlce = ilceler.id " +
        " inner join urunler on taksitler.taksitUrun = urunler.urunID where taksitler.durum=1 and taksitler.taksitSayi!=0", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            SqlCommand komut = new SqlCommand("update taksitler set durum=0 where taksitSayi=0",bgl.baglanti());
            komut.ExecuteNonQuery();

            SqlDataAdapter da2 = new SqlDataAdapter("select taksitID as 'ID' , musteri.musteriAdSoyad as 'Müşteri' , iller.sehir as 'İL' , ilceler.ilce as 'İlçe' , urunler.urunAD as 'Ürün' ,taksitAylikUcret as 'Ücret', taksitSayi as 'Taksit',taksitTarih as 'Ödeme Tarihi'  from taksitler " +
   "inner join musteri on taksitler.taksitMusteriid = musteri.musteriID " +
   " inner join iller on taksitler.taksitIl = iller.id " +
   "inner join ilceler on taksitler.taksitIlce = ilceler.id " +
   " inner join urunler on taksitler.taksitUrun = urunler.urunID where taksitler.durum=0 or taksitler.taksitSayi = 0", bgl.baglanti());
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;
        }

        public void odeme()
        {
            SqlCommand komut = new SqlCommand("update taksitler set taksitSayi=taksitSayi-1 where taksitID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", textBox1.Text);
            komut.ExecuteNonQuery();
            MessageBox.Show("Aylık ödemesinden taksit eksildi");
            listele();
        }

        public frmTaksitler()
        {
            InitializeComponent();
        }

        frmTaksitSecim fr2 = new frmTaksitSecim();
        // Ürün Ad
        public string bir="", iki="", uc="", dort="", bes="";
        // Ürün Fiyat
        public string bir1="", iki2="", uc3="", dort4="", bes5="";
        public int birs1=0, ikis2=0, ucs3=0, dorts4=0, bess5=0;
        public string Musteriat;

        private void button2_Click(object sender, EventArgs e)
        {

            SqlCommand komut = new SqlCommand("select taksitID as 'ID' , musteri.musteriAdSoyad as 'Müşteri' , iller.sehir as 'İL' , ilceler.ilce as 'İlçe' , urunler.urunAD as 'Ürün' ,taksitAylikUcret as 'Ücret', taksitSayi as 'Taksit',taksitTarih as 'Ödeme Tarihi' from taksitler inner join musteri on taksitler.taksitMusteriid = musteri.musteriID" +
                " inner join iller on taksitler.taksitIl = iller.id " +
   "inner join ilceler on taksitler.taksitIlce = ilceler.id " +
   " inner join urunler on taksitler.taksitUrun = urunler.urunID " +
   "WHERE musteri.musteriAdSoyad like '%" + textBox2.Text + "%' and taksitIl=@p2 and taksitIlce=@p3 and taksitler.durum=0", bgl.baglanti());

            komut.Parameters.AddWithValue("@p2", comboBox4.SelectedValue);
            komut.Parameters.AddWithValue("@p3", comboBox3.SelectedValue);
            komut.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(komut);
            da.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox4.SelectedIndex != -1)
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("select * from ilceler where sehir = " + comboBox4.SelectedValue, bgl.baglanti());
                da.Fill(dt);
                comboBox3.ValueMember = "id";
                comboBox3.DisplayMember = "ilce";
                comboBox3.DataSource = dt;

            }
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            listele();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int toplam1 = birs1;
            int toplam2 = birs1 + ikis2;
            int toplam3 = birs1 + ikis2 + ucs3;
            int toplam4 = birs1 + ikis2 + ucs3 + dorts4;
            int toplam5 = birs1 + ikis2 + ucs3 + dorts4 + bess5;
            bmp = new Bitmap(SuAritmaPanel.Properties.Resources.makbuz2);
            Graphics gr = Graphics.FromImage(bmp);

            // AD
            gr.DrawString(Musteriat, new Font("Segoe UI", 18, FontStyle.Bold), new SolidBrush(Color.Black), 75, 140);
            // TUTAR
            if (lbl2.Text == "")
            {
                gr.DrawString(toplam1.ToString() + "TL", new Font("Segoe UI", 18, FontStyle.Regular), new SolidBrush(Color.Black), 555, 370);
            }
            else if (lbl3.Text == "")
            {
                gr.DrawString(toplam2.ToString() + "TL", new Font("Segoe UI", 18, FontStyle.Regular), new SolidBrush(Color.Black), 555, 370);
            }
            else if (lbl4.Text == "")
            {
                gr.DrawString(toplam3.ToString() + "TL", new Font("Segoe UI", 18, FontStyle.Regular), new SolidBrush(Color.Black), 555, 370);

            }
            else if (lbl5.Text == "")
            {
                gr.DrawString(toplam4.ToString() + "TL", new Font("Segoe UI", 18, FontStyle.Regular), new SolidBrush(Color.Black), 555, 370);
            }
            else
            {
                gr.DrawString(toplam5.ToString() + "TL", new Font("Segoe UI", 18, FontStyle.Regular), new SolidBrush(Color.Black), 555, 370);

            }
            // 1. Satır
            gr.DrawString(bir, new Font("Segoe UI", 18, FontStyle.Regular), new SolidBrush(Color.Black), 20, 208);
            gr.DrawString(bir1, new Font("Segoe UI", 18, FontStyle.Regular), new SolidBrush(Color.Black), 440, 208);
            // 2. Satır
            gr.DrawString(iki, new Font("Segoe UI", 18, FontStyle.Regular), new SolidBrush(Color.Black), 20, 243);
            gr.DrawString(iki2, new Font("Segoe UI", 18, FontStyle.Regular), new SolidBrush(Color.Black), 440, 243);
            // 3. Satır
            gr.DrawString(uc, new Font("Segoe UI", 18, FontStyle.Regular), new SolidBrush(Color.Black), 20, 276);
            gr.DrawString(uc3, new Font("Segoe UI", 18, FontStyle.Regular), new SolidBrush(Color.Black), 440, 276);
            // 4. Satır
            gr.DrawString(dort, new Font("Segoe UI", 18, FontStyle.Regular), new SolidBrush(Color.Black), 20, 308);
            gr.DrawString(dort4, new Font("Segoe UI", 18, FontStyle.Regular), new SolidBrush(Color.Black), 440, 308);
            // 5. Satır
            gr.DrawString(bes, new Font("Segoe UI", 18, FontStyle.Regular), new SolidBrush(Color.Black), 20, 342);
            gr.DrawString(bes5, new Font("Segoe UI", 18, FontStyle.Regular), new SolidBrush(Color.Black), 440, 342);

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void frmTaksitler_Load(object sender, EventArgs e)
        {
            lbl1.Text = bir.ToString();
            lbl2.Text = iki.ToString();
            lbl3.Text = uc.ToString();
            lbl4.Text = dort.ToString();
            lbl5.Text = bes.ToString(); 
            
            lbla1.Text = bir1.ToString();
            lbla2.Text = iki2.ToString();
            lbla3.Text = uc3.ToString();
            lbla4.Text = dort4.ToString();
            lbla5.Text = bes5.ToString();


            // İL SATIŞ YAP
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from iller ORDER BY id ASC ", bgl.baglanti());
            da.Fill(dt);
            cmbIl.ValueMember = "id";
            cmbIl.DisplayMember = "sehir";
            cmbIl.DataSource = dt;
            // İL izleeeeğ YAP
            DataTable dt3 = new DataTable();
            SqlDataAdapter da3 = new SqlDataAdapter("select * from iller ORDER BY id ASC ", bgl.baglanti());
            da3.Fill(dt3);
            comboBox4.ValueMember = "id";
            comboBox4.DisplayMember = "sehir";
            comboBox4.DataSource = dt3;  
            // Müşteriler
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select * from musteri ORDER BY musteriID ASC", bgl.baglanti());
            da2.Fill(dt2);
            cmbAdSoyadTahsilat.ValueMember = "musteriID";
            cmbAdSoyadTahsilat.DisplayMember = "musteriAdSoyad";
            cmbAdSoyadTahsilat.DataSource = dt2;

         
            listele();

        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int secilen = dataGridView1.SelectedCells[0].RowIndex;
                textBox1.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
                textBox3.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
                label9.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
                label11.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
                label10.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();

                cmbIl.SelectedValue = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
                cmbIlce.SelectedValue = dataGridView1.Rows[secilen].Cells[4].Value.ToString();


            }
            catch (Exception)
            {


            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbIl.SelectedIndex != -1)
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("select * from ilceler where sehir = " + cmbIl.SelectedValue, bgl.baglanti());
                da.Fill(dt);
                cmbIlce.ValueMember = "id";
                cmbIlce.DisplayMember = "ilce";
                cmbIlce.DataSource = dt;

            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            FrmTaksitDetay detay = new FrmTaksitDetay();
            detay.tarih = label10.Text;
            detay.ucret = label9.Text;
            detay.id = textBox1.Text;
            detay.taksit = label11.Text;

            detay.Show();


            // Taksit tarih seçtir... (!)
           

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select taksitID as 'ID' , musteri.musteriAdSoyad as 'Müşteri' , iller.sehir as 'İL' , ilceler.ilce as 'İlçe' , urunler.urunAD as 'Ürün' ,taksitAylikUcret as 'Ücret', taksitSayi as 'Taksit',taksitTarih as 'Ödeme Tarihi'  from taksitler inner join musteri on taksitler.taksitMusteriid = musteri.musteriID" +
                " inner join iller on taksitler.taksitIl = iller.id " +
   "inner join ilceler on taksitler.taksitIlce = ilceler.id " +
   " inner join urunler on taksitler.taksitUrun = urunler.urunID "+
   "WHERE musteri.musteriAdSoyad like '%" + textBox3.Text + "%' and taksitIl=@p2 and taksitIlce=@p3 and taksitler.durum=1", bgl.baglanti());

            komut.Parameters.AddWithValue("@p2", cmbIl.SelectedValue);
            komut.Parameters.AddWithValue("@p3", cmbIlce.SelectedValue);
            komut.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(komut);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void frmTaksitler_Click(object sender, EventArgs e)
        {

        }
        Bitmap bmp;
        private void button4_Click(object sender, EventArgs e)
        {
            int toplam1 = birs1;
            int toplam2 = birs1 + ikis2;
            int toplam3 = birs1 + ikis2 + ucs3;
            int toplam4 = birs1 + ikis2 + ucs3 + dorts4;
            int toplam5 = birs1 + ikis2 + ucs3 + dorts4 + bess5;
            bmp = new Bitmap(SuAritmaPanel.Properties.Resources.makbuz2); 
            Graphics gr = Graphics.FromImage(bmp); 
           
            // AD
            gr.DrawString(Musteriat, new Font("Segoe UI",18 , FontStyle.Bold), new SolidBrush(Color.Black), 75,140);
            // TUTAR
            if (lbl2.Text == "")
            {
                gr.DrawString(toplam1.ToString() + "TL", new Font("Segoe UI", 18, FontStyle.Regular), new SolidBrush(Color.Black), 555, 370);
            }
            else if (lbl3.Text == "")
            {
                gr.DrawString(toplam2.ToString() + "TL", new Font("Segoe UI", 18, FontStyle.Regular), new SolidBrush(Color.Black), 555, 370);
            }
            else if (lbl4.Text == "")
            {
                gr.DrawString(toplam3.ToString() + "TL", new Font("Segoe UI", 18, FontStyle.Regular), new SolidBrush(Color.Black), 555, 370);

            } else if (lbl5.Text == "")
            {
                gr.DrawString(toplam4.ToString() + "TL", new Font("Segoe UI", 18, FontStyle.Regular), new SolidBrush(Color.Black), 555, 370);
            }
            else
            {
                gr.DrawString(toplam5.ToString() + "TL", new Font("Segoe UI", 18, FontStyle.Regular), new SolidBrush(Color.Black), 555, 370);

            }
            // 1. Satır
            gr.DrawString(bir, new Font("Segoe UI",18 , FontStyle.Regular), new SolidBrush(Color.Black), 20,208);
            gr.DrawString(bir1, new Font("Segoe UI",18 , FontStyle.Regular), new SolidBrush(Color.Black), 440,208);
            // 2. Satır
            gr.DrawString(iki, new Font("Segoe UI",18 , FontStyle.Regular), new SolidBrush(Color.Black), 20,243);
            gr.DrawString(iki2, new Font("Segoe UI",18 , FontStyle.Regular), new SolidBrush(Color.Black), 440, 243);
            // 3. Satır
            gr.DrawString(uc, new Font("Segoe UI",18 , FontStyle.Regular), new SolidBrush(Color.Black), 20,276);
            gr.DrawString(uc3, new Font("Segoe UI",18 , FontStyle.Regular), new SolidBrush(Color.Black), 440, 276);
            // 4. Satır
            gr.DrawString(dort, new Font("Segoe UI",18 , FontStyle.Regular), new SolidBrush(Color.Black), 20,308);
            gr.DrawString(dort4, new Font("Segoe UI",18 , FontStyle.Regular), new SolidBrush(Color.Black), 440, 308);
            // 5. Satır
            gr.DrawString(bes, new Font("Segoe UI",18 , FontStyle.Regular), new SolidBrush(Color.Black), 20,342);
            gr.DrawString(bes5, new Font("Segoe UI",18 , FontStyle.Regular), new SolidBrush(Color.Black), 440, 342);
            saveFileDialog1.Filter = "Resim | .png";
            saveFileDialog1.ShowDialog();
            try
            {
                bmp.Save(saveFileDialog1.FileName);

            }
            catch (Exception)
            {

                MessageBox.Show("Kayıt edilmedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmTaksitSecim frm = new frmTaksitSecim();
            string a= cmbAdSoyadTahsilat.SelectedValue.ToString();
            frm.musteriid = int.Parse(a);
            frm.musteriad = cmbAdSoyadTahsilat.Text;
            frm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void frmTaksitler_Activated(object sender, EventArgs e)
        {

        }
    }
}
