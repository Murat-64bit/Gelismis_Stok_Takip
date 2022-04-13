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
namespace SuAritmaPanel
{
    public partial class frmTeknik : Form
    {
        public frmTeknik()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();

        public void Listele()
        {
            // datagrid v1
            SqlDataAdapter da2 = new SqlDataAdapter("select teknikID as 'ID',musteri.musteriAdSoyad as 'Müşteri', urunler.urunAD as 'Ürün'," +
                "iller.sehir as 'İL',ilceler.ilce as 'İlçe',teknikBaslik as 'Başlık',teknikBakimTarih as 'Tarih' from teknikler " +
                "inner join musteri on teknikler.teknikMusteriid = musteri.musteriID " +
                "inner join urunler on teknikler.teknikUrun = urunler.urunID" +
                 " inner join iller on teknikler.teknikIl = iller.id " +
                "inner join ilceler on teknikler.teknikIlce = ilceler.id " +
                "where teknikler.durum=1 and teknikler.teknikBaslik = 'BAKIM' ", bgl.baglanti());
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            dataGridView1.DataSource = dt2;
            // datagrid v2
            SqlDataAdapter da = new SqlDataAdapter("select teknikID as 'ID',musteri.musteriAdSoyad as 'Müşteri', urunler.urunAD as 'Ürün'," +
                "iller.sehir as 'İL',ilceler.ilce as 'İlçe',teknikBaslik as 'Başlık',teknikdetay as 'Detay',teknikOlusturulmaTarih as 'Tarih' from teknikler " +
                "inner join musteri on teknikler.teknikMusteriid = musteri.musteriID " +
                "inner join urunler on teknikler.teknikUrun = urunler.urunID" +
                 " inner join iller on teknikler.teknikIl = iller.id " +
                "inner join ilceler on teknikler.teknikIlce = ilceler.id " +
                "where teknikler.durum=1 and teknikler.teknikBaslik != 'BAKIM' ", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into teknikler (teknikMusteriid,teknikUrun,teknikIl,teknikIlce,teknikBaslik,teknikDetay,teknikAciliyet," +
                "teknikOlusturulmaTarih,durum) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,1)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", cmbAd.SelectedValue);
            komut.Parameters.AddWithValue("@p2", cmbUrun.SelectedValue);
            komut.Parameters.AddWithValue("@p3", cmbIl.SelectedValue);
            komut.Parameters.AddWithValue("@p4", cmbIlce.SelectedValue);
            komut.Parameters.AddWithValue("@p5", txtBaslik.Text);
            komut.Parameters.AddWithValue("@p6", rtbDetay.Text);
            komut.Parameters.AddWithValue("@p7", cmbAciliyet.Text);
            komut.Parameters.AddWithValue("@p8", label7.Text);
            komut.ExecuteNonQuery();
            Listele();

            MessageBox.Show("Destek talebi başarı ile oluşturuldu.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void frmTeknik_Load(object sender, EventArgs e)
        {
            DateTime suan = DateTime.Now;
            string formatlanmis = suan.ToString("dd/MM/yyyy");
            label16.Text = formatlanmis;
            Listele();
            // Destek Oluştur
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from iller ORDER BY id ASC ", bgl.baglanti());
            da.Fill(dt);
            cmbIl.ValueMember = "id";
            cmbIl.DisplayMember = "sehir";
            cmbIl.DataSource = dt; 
            // Destek sayfası
            DataTable dt5 = new DataTable();
            SqlDataAdapter da5 = new SqlDataAdapter("select * from iller ORDER BY id ASC ", bgl.baglanti());
            da5.Fill(dt5);
            comboBox4.ValueMember = "id";
            comboBox4.DisplayMember = "sehir";
            comboBox4.DataSource = dt5;
            // Bakım Sayfası
            DataTable dt6 = new DataTable();
            SqlDataAdapter da6 = new SqlDataAdapter("select * from iller ORDER BY id ASC ", bgl.baglanti());
            da6.Fill(dt6);
            comboBox2.ValueMember = "id";
            comboBox2.DisplayMember = "sehir";
            comboBox2.DataSource = dt6;
            // AD SOYAD çekme müşteri
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select * from musteri ORDER BY musteriID ASC ", bgl.baglanti());
            da2.Fill(dt2);
            cmbAd.ValueMember = "musteriID";
            cmbAd.DisplayMember = "musteriAdSoyad";
            cmbAd.DataSource = dt2;
            // İSİM ÜRÜN ÇEKME
            DataTable dt3 = new DataTable();
            SqlDataAdapter da3 = new SqlDataAdapter("select * from urunler where durum=1 ORDER BY urunID ASC", bgl.baglanti());
            da3.Fill(dt3);
            cmbUrun.ValueMember = "urunID";
            cmbUrun.DisplayMember = "urunAD";
            cmbUrun.DataSource = dt3;
        }

        private void cmbIl_SelectedIndexChanged(object sender, EventArgs e)
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

        private void button5_Click(object sender, EventArgs e)
        {
            // 8.06 buraya el at
            SqlCommand komut = new SqlCommand("select teknikID as 'ID',musteri.musteriAdSoyad as 'Müşteri', urunler.urunAD as 'Ürün'," +
                 "iller.sehir as 'İL',ilceler.ilce as 'İlçe',teknikBaslik as 'Başlık',teknikBakimTarih as 'Tarih' from teknikler " +
                 "inner join musteri on teknikler.teknikMusteriid = musteri.musteriID " +
                 "inner join urunler on teknikler.teknikUrun = urunler.urunID" +
                  " inner join iller on teknikler.teknikIl = iller.id " +
                 "inner join ilceler on teknikler.teknikIlce = ilceler.id " +
                  "where musteri.musteriAdSoyad like '%" + textBox4.Text + "%' and teknikIl=@p1 and teknikIlce=@p2 and teknikler.durum=1 and teknikler.teknikBaslik = 'BAKIM' ", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", comboBox2.SelectedValue);
            komut.Parameters.AddWithValue("@p2", comboBox1.SelectedValue);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select teknikID as 'ID',musteri.musteriAdSoyad as 'Müşteri', urunler.urunAD as 'Ürün'," +
                  "iller.sehir as 'İL',ilceler.ilce as 'İlçe',teknikBaslik as 'Başlık',teknikdetay as 'Detay',teknikOlusturulmaTarih as 'Tarih' from teknikler " +
                  "inner join musteri on teknikler.teknikMusteriid = musteri.musteriID " +
                  "inner join urunler on teknikler.teknikUrun = urunler.urunID" +
                   " inner join iller on teknikler.teknikIl = iller.id " +
                  "inner join ilceler on teknikler.teknikIlce = ilceler.id " +
                  "where musteri.musteriAdSoyad like '%" + textBox3.Text + "%' and teknikIl=@p1 and teknikIlce=@p2 and teknikler.durum=1 and teknikler.teknikBaslik != 'BAKIM' ", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", comboBox4.SelectedValue);
            komut.Parameters.AddWithValue("@p2", comboBox3.SelectedValue);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex != -1)
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("select * from ilceler where sehir = " + comboBox2.SelectedValue, bgl.baglanti());
                da.Fill(dt);
                comboBox1.ValueMember = "id";
                comboBox1.DisplayMember = "ilce";
                comboBox1.DataSource = dt;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Listele();
        }
        public string AdSoyad, UrunAd, baslik, detay;
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int secilen = dataGridView2.SelectedCells[0].RowIndex;
                textBox2.Text = dataGridView2.Rows[secilen].Cells[0].Value.ToString();
                AdSoyad = dataGridView2.Rows[secilen].Cells[1].Value.ToString();
                UrunAd = dataGridView2.Rows[secilen].Cells[2].Value.ToString();
                baslik = dataGridView2.Rows[secilen].Cells[5].Value.ToString();
                detay = dataGridView2.Rows[secilen].Cells[6].Value.ToString();
                textBox3.Text = dataGridView2.Rows[secilen].Cells[1].Value.ToString();
                comboBox4.SelectedValue = dataGridView2.Rows[secilen].Cells[3].Value.ToString();
                comboBox3.SelectedValue = dataGridView2.Rows[secilen].Cells[4].Value.ToString();

            }
            catch (Exception)
            {


            }
        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show("" +
                "- AD SOYAD : " + AdSoyad + "" +
                "                                                                  " +
                "- ÜRÜN : " + UrunAd + "" +
                "                                                           " +
                "- BAŞLIK : " + baslik + "" +
                "                                                                    " +
                "- DETAY : " + detay + "", "Detaylar", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update teknikler set durum=0 where teknikID=@p1 and teknikBaslik != 'BAKIM'",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", textBox2.Text);
            komut.ExecuteNonQuery();
            Listele();
            MessageBox.Show("Destek talebi başarı ile silindi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int secilen = dataGridView1.SelectedCells[0].RowIndex;
                textBox1.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
                textBox4.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
                comboBox2.SelectedValue = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
                comboBox1.SelectedValue = dataGridView1.Rows[secilen].Cells[4].Value.ToString();

            }
            catch (Exception)
            {


            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update teknikler set durum=0 where teknikID=@p1 and teknikBaslik = 'BAKIM'", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", textBox1.Text);
            komut.ExecuteNonQuery();
            Listele();
            MessageBox.Show("Destek talebi başarı ile silindi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
    

