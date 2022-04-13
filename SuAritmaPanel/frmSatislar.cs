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
    public partial class frmSatislar : Form
    {

        sqlbaglantisi bgl = new sqlbaglantisi();
        public frmSatislar()
        {
            InitializeComponent();
        }
        private void listele()
        {
            // AKTİF SATIŞLAR
            SqlDataAdapter da = new SqlDataAdapter("select satisID as 'ID' , musteri.musteriAdSoyad as 'Müşteri' , iller.sehir as 'İL' , ilceler.ilce as 'İlçe' , urunler.urunAD as 'Ürün' ,satisUcret as 'Ücret', satisTaksit as 'Taksit',satisTarih from satislar " +
    "inner join musteri on satislar.satisMusteriid = musteri.musteriID " +
    " inner join iller on satislar.satisIl = iller.id " +
    "inner join ilceler on satislar.satisIlce = ilceler.id " +
    " inner join urunler on satislar.satisUrun = urunler.urunID where satislar.durum=1", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            // İPTAL SATIŞLAR
            SqlDataAdapter da2 = new SqlDataAdapter("select satisID as 'ID' , musteri.musteriAdSoyad as 'Müşteri' , iller.sehir as 'İL' , ilceler.ilce as 'İlçe' , urunler.urunAD as 'Ürün' ,satisUcret as 'Ücret', satisTaksit as 'Taksit',satisTarih from satislar " +
                "inner join musteri on satislar.satisMusteriid = musteri.musteriID " +
                " inner join iller on satislar.satisIl = iller.id " +
                "inner join ilceler on satislar.satisIlce = ilceler.id " +
                " inner join urunler on satislar.satisUrun = urunler.urunID where satislar.durum=0", bgl.baglanti());
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;

            SqlDataAdapter da3 = new SqlDataAdapter("select urunID as 'ID', urunAD as 'ÜRÜN İSİM', urunUcret as 'ÜCRET' from urunler where durum=1", bgl.baglanti());
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            dataGridView3.DataSource = dt3;
        }
        private void frmSatislar_Load(object sender, EventArgs e)
        {
            DateTime BirYilSonrasi = DateTime.Now.AddYears(1);
            DateTime suan = DateTime.Now;
            string formattedDate = BirYilSonrasi.ToString("dd/MM/yyyy");
            string formatlanmis = suan.ToString("dd/MM/yyyy");


            label16.Text = formatlanmis;
            label19.Text = formattedDate;
            DateTime.Now.AddYears(1);
            // İL SATIŞ YAP
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from iller ORDER BY id ASC ", bgl.baglanti());
            da.Fill(dt);
            cmbIl.ValueMember = "id";
            cmbIl.DisplayMember = "sehir";
            cmbIl.DataSource = dt;
          
            // SON SATIŞLAR
            DataTable dt5 = new DataTable();
            SqlDataAdapter da5 = new SqlDataAdapter("select * from iller ORDER BY id ASC ", bgl.baglanti());
            da5.Fill(dt5);
            comboBox2.ValueMember = "id";
            comboBox2.DisplayMember = "sehir";
            comboBox2.DataSource = dt5; 
            // silinmiş iptal satışlar
            DataTable dt6 = new DataTable();
            SqlDataAdapter da6 = new SqlDataAdapter("select * from iller ORDER BY id ASC ", bgl.baglanti());
            da6.Fill(dt6);
            txtIl.ValueMember = "id";
            txtIl.DisplayMember = "sehir";
            txtIl.DataSource = dt6;
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
            listele();
        }

        private void radioPesin_CheckedChanged(object sender, EventArgs e)
        {
            mskTaksit.Text = "0";
            mskTaksit.Enabled = false;
            txtTarih.Enabled = false;
            txtTarih.Text = "Peşin";

        }

        private void radioPesinDegil_CheckedChanged(object sender, EventArgs e)
        {
            mskTaksit.Text = "";
            mskTaksit.Enabled = true;
            txtTarih.Enabled = true;

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (radioPesin.Checked == true)
            {
                try
                {
                    SqlCommand kaydet = new SqlCommand("insert into satislar (satisMusteriid,satisIl,satisIlce,satisUrun,satisUcret,satisTaksit,satisTarih,durum) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,1)", bgl.baglanti());
                    kaydet.Parameters.AddWithValue("@p1", cmbAd.SelectedValue);
                    kaydet.Parameters.AddWithValue("@p2", cmbIl.SelectedValue);
                    kaydet.Parameters.AddWithValue("@p3", cmbIlce.SelectedValue);
                    kaydet.Parameters.AddWithValue("@p4", cmbUrun.SelectedValue);
                    kaydet.Parameters.AddWithValue("@p5", mskUcret.Text);
                    kaydet.Parameters.AddWithValue("@p6", mskTaksit.Text);
                    kaydet.Parameters.AddWithValue("@p7", label16.Text);
                    kaydet.ExecuteNonQuery();

                    SqlCommand komut2 = new SqlCommand("insert into teknikler (teknikMusteriid,teknikUrun,teknikIl,teknikIlce,teknikBaslik," +
               "teknikBakimTarih,durum) values (@p1,@p2,@p3,@p4,@p5,@p8,1)", bgl.baglanti());
                    komut2.Parameters.AddWithValue("@p1", cmbAd.SelectedValue);
                    komut2.Parameters.AddWithValue("@p2", cmbUrun.SelectedValue);
                    komut2.Parameters.AddWithValue("@p3", cmbIl.SelectedValue);
                    komut2.Parameters.AddWithValue("@p4", cmbIlce.SelectedValue);
                    komut2.Parameters.AddWithValue("@p5", "BAKIM");
                    komut2.Parameters.AddWithValue("@p8", label19.Text);
                    komut2.ExecuteNonQuery();
                    MessageBox.Show("Satış kayıt edildi");
                    listele();
                }
                catch (Exception)
                {
                    MessageBox.Show("Bir şeyler eksik veya yanlış gitti.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);


                }
            }
            if (radioPesin.Checked == false && radioPesinDegil.Checked == true)
            {
                try
                {
                    // Satışlara kayıt
                    SqlCommand kaydet = new SqlCommand("insert into satislar (satisMusteriid,satisIl,satisIlce,satisUrun,satisUcret,satisTaksit,satisTarih,durum) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,1)", bgl.baglanti());
                    kaydet.Parameters.AddWithValue("@p1", cmbAd.SelectedValue);
                    kaydet.Parameters.AddWithValue("@p2", cmbIl.SelectedValue);
                    kaydet.Parameters.AddWithValue("@p3", cmbIlce.SelectedValue);
                    kaydet.Parameters.AddWithValue("@p4", cmbUrun.SelectedValue);
                    kaydet.Parameters.AddWithValue("@p5", mskUcret.Text);
                    kaydet.Parameters.AddWithValue("@p6", mskTaksit.Text);
                    kaydet.Parameters.AddWithValue("@p7", label16.Text);
                    kaydet.ExecuteNonQuery();
                    
                    int a = Convert.ToInt32(mskUcret.Text);
                    int b = Convert.ToInt32(mskTaksit.Text);
                    int c = a / b;
                    // Taksitlere kayıt
                    SqlCommand kaydet2 = new SqlCommand("insert into taksitler (taksitMusteriid,taksitIl,taksitIlce,taksitUrun,taksitAylikUcret ,taksitSayi,taksitTarih,durum) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,1)", bgl.baglanti());
                    kaydet2.Parameters.AddWithValue("@p1", cmbAd.SelectedValue);
                    kaydet2.Parameters.AddWithValue("@p2", cmbIl.SelectedValue);
                    kaydet2.Parameters.AddWithValue("@p3", cmbIlce.SelectedValue);
                    kaydet2.Parameters.AddWithValue("@p4", cmbUrun.SelectedValue);
                    kaydet2.Parameters.AddWithValue("@p5", c);
                    kaydet2.Parameters.AddWithValue("@p6", mskTaksit.Text);
                    kaydet2.Parameters.AddWithValue("@p7", txtTarih.Text);
                    kaydet2.ExecuteNonQuery();

                    SqlCommand komut3 = new SqlCommand("insert into teknikler (teknikMusteriid,teknikUrun,teknikIl,teknikIlce,teknikBaslik," +
             "teknikBakimTarih,durum) values (@p1,@p2,@p3,@p4,@p5,@p8,1)", bgl.baglanti());
                    komut3.Parameters.AddWithValue("@p1", cmbAd.SelectedValue);
                    komut3.Parameters.AddWithValue("@p2", cmbUrun.SelectedValue);
                    komut3.Parameters.AddWithValue("@p3", cmbIl.SelectedValue);
                    komut3.Parameters.AddWithValue("@p4", cmbIlce.SelectedValue);
                    komut3.Parameters.AddWithValue("@p5", "BAKIM");
                    komut3.Parameters.AddWithValue("@p8", label19.Text);
                    komut3.ExecuteNonQuery();
                    MessageBox.Show("Satış kayıt edildi");



                    listele();
                }
                catch (Exception)
                {
                    MessageBox.Show("Bir şeyler eksik veya yanlış gitti.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);


                }
            }
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

        private void btnUrunKaydet_Click(object sender, EventArgs e)
        {
            if (txtUrunAd.Text != "")
            {
                SqlCommand komut = new SqlCommand("insert into urunler (urunAD,urunUcret,durum) values (@p1,@p2,1)",bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", txtUrunAd.Text);
                komut.Parameters.AddWithValue("@p2", txtUcreet.Text);
                komut.ExecuteNonQuery();
                listele();
                MessageBox.Show("Ürün kayıt edildi");
            }
            else
            {
                MessageBox.Show("Bir şeyler eksik veya yanlış gitti.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnUrunSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update urunler set durum=0 where urunID=@p1",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtUrunID.Text);
            komut.ExecuteNonQuery();
            listele();
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int secilen = dataGridView3.SelectedCells[0].RowIndex;
                txtUrunID.Text = dataGridView3.Rows[secilen].Cells[0].Value.ToString();
                txtUrunAd.Text = dataGridView3.Rows[secilen].Cells[1].Value.ToString();
                txtUcreet.Text = dataGridView3.Rows[secilen].Cells[2].Value.ToString();
              

            }
            catch (Exception)
            {


            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update satislar set durum=0 where satisID=@p1",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", textBox1.Text);
            komut.ExecuteNonQuery();
            listele();
            MessageBox.Show("Satış başarı ile silindi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            listele();
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select satisID as 'ID' , musteri.musteriAdSoyad as 'Müşteri' , iller.sehir as 'İL' , ilceler.ilce as 'İlçe' , urunler.urunAD as 'Ürün' ,satisUcret as 'Ücret', satisTaksit as 'Taksit',satisTarih from satislar " +
    "inner join musteri on satislar.satisMusteriid = musteri.musteriID " +
    " inner join iller on satislar.satisIl = iller.id " +
    "inner join ilceler on satislar.satisIlce = ilceler.id " +
    " inner join urunler on satislar.satisUrun = urunler.urunID where musteri.musteriAdSoyad like '%" + textBox2.Text + "%' and satislar.satisIl=@p1 and satislar.satisIlce=@p2 and satislar.durum=1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", comboBox2.SelectedValue);
            komut.Parameters.AddWithValue("@p2", comboBox1.SelectedValue);
            komut.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void txtIl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtIl.SelectedIndex != -1)
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("select * from ilceler where sehir = " + txtIl.SelectedValue, bgl.baglanti());
                da.Fill(dt);
                txtIlce.ValueMember = "id";
                txtIlce.DisplayMember = "ilce";
                txtIlce.DataSource = dt;

            }
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int secilen = dataGridView1.SelectedCells[0].RowIndex;
                textBox1.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
                comboBox2.SelectedValue = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
                comboBox1.SelectedValue = dataGridView1.Rows[secilen].Cells[4].Value.ToString();

            }
            catch (Exception)
            {


            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int secilen = dataGridView2.SelectedCells[0].RowIndex;
                txtID.Text = dataGridView2.Rows[secilen].Cells[0].Value.ToString();
                txtAd.Text = dataGridView2.Rows[secilen].Cells[1].Value.ToString();
                txtIl.SelectedValue = dataGridView2.Rows[secilen].Cells[3].Value.ToString();
                txtIlce.SelectedValue = dataGridView2.Rows[secilen].Cells[4].Value.ToString();

            }
            catch (Exception)
            {


            }
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select satisID as 'ID' , musteri.musteriAdSoyad as 'Müşteri' , iller.sehir as 'İL' , ilceler.ilce as 'İlçe' , urunler.urunAD as 'Ürün' ,satisUcret as 'Ücret', satisTaksit as 'Taksit',satisTarih from satislar " +
    "inner join musteri on satislar.satisMusteriid = musteri.musteriID " +
    " inner join iller on satislar.satisIl = iller.id " +
    "inner join ilceler on satislar.satisIlce = ilceler.id " +
    " inner join urunler on satislar.satisUrun = urunler.urunID where musteri.musteriAdSoyad like '%" + txtAd.Text + "%' and satislar.satisIl=@p1 and satislar.satisIlce=@p2 and satislar.durum=0", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtIl.SelectedValue);
            komut.Parameters.AddWithValue("@p2", txtIlce.SelectedValue);
            komut.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;

        }
    }
}
