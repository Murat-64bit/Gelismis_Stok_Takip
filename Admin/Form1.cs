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

namespace Admin
{
    public partial class Form1 : Form
    {
        sqlbaglantisi bgl = new sqlbaglantisi();

        public Form1()
        {
            InitializeComponent();
        }

        private void Listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("select uyeID as 'ID',uyeAdSoyad as 'Ad Soyad', uyeKullaniciAd as 'Kullanıcı Ad',uyeSifre as 'Şifre',uyeAdmin as 'Admin' from uyeler",bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Listele();
            dataGridView1.Columns[3].Visible = false;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into uyeler (uyeAdSoyad,uyeKullaniciAd,uyeSifre,uyeAdmin) values (@p1,@p2,@p3,0)",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtAdSoyad.Text);
            komut.Parameters.AddWithValue("@p2", txtKullaniciAd.Text);
            komut.Parameters.AddWithValue("@p3", txtSifre.Text);
            komut.ExecuteNonQuery();
            Listele();
            MessageBox.Show("Üye başarı ile kayıt edildi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update uyeler set uyeAdSoyad=@p1,uyeKullaniciAd=@p2,uyeSifre=@p3 where uyeID=@p4",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtAdSoyad.Text);
            komut.Parameters.AddWithValue("@p2", txtKullaniciAd.Text);
            komut.Parameters.AddWithValue("@p3", txtSifre.Text);
            komut.Parameters.AddWithValue("@p4", txtID.Text);
            komut.ExecuteNonQuery();
            Listele();
            MessageBox.Show("Üye başarı ile güncellendi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int secilen = dataGridView1.SelectedCells[0].RowIndex;
                txtID.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
                txtAdSoyad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
                txtKullaniciAd.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
                txtSifre.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
                label5.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();


            }
            catch (Exception)
            {


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from uyeler where uyeID=@p1",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtID.Text);
            komut.ExecuteNonQuery();
            Listele();
            MessageBox.Show("Üye başarı ile silindi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (label5.Text == "False")
            {
                SqlCommand komut = new SqlCommand("update uyeler set uyeAdmin=1 where uyeID=@p2", bgl.baglanti());
                komut.Parameters.AddWithValue("@p2", txtID.Text);
                komut.ExecuteNonQuery();
                Listele();
                MessageBox.Show("Üye başarı ile admin yapıldı.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }  
            if (label5.Text == "True")
            {
                SqlCommand komut = new SqlCommand("update uyeler set uyeAdmin=0 where uyeID=@p2", bgl.baglanti());
                komut.Parameters.AddWithValue("@p2", txtID.Text);
                komut.ExecuteNonQuery();
                Listele();
                MessageBox.Show("Üye başarı ile adminlikten alındı.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
