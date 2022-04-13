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
    public partial class frmAnaSayfa : Form
    {
        public frmAnaSayfa()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select Convert(varchar(10), sum(taksitAylikUcret)) from taksitler where convert(datetime, taksitTarih, 103) < convert(datetime, '" + maskedTextBox1.Text + "', 103) and taksitler.durum=1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", label7.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                label6.Text = dr[0].ToString() + " TL";
            }
        }

        private void frmAnaSayfa_Load(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            string formatlanmis = now.ToString("dd/MM/yyyy");
            label7.Text = formatlanmis; 
            DateTime bakim30 = DateTime.Now.AddDays(30);
            string format = bakim30.ToString("dd/MM/yyyy");
            label8.Text = format;

            // ÖDEME GÜNÜ GEÇENLER
            SqlCommand komut = new SqlCommand("select musteri.musteriAdSoyad as 'Ad Soyad' ,iller.sehir as 'Şehir',ilceler.ilce as 'İlçe',CONVERT(VARCHAR,taksitler.taksitTarih) as 'Tarih' from taksitler" +
            " inner join musteri on taksitler.taksitMusteriid = musteri.musteriID" +
            " inner join iller on taksitler.taksitIl = iller.id" +
            " inner join ilceler on taksitler.taksitIlce = ilceler.id " +
            " where convert(datetime,'"+label7.Text+"', 103) > convert(datetime, taksitTarih, 103)  and taksitler.durum = 1", bgl.baglanti());
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            // GÜNÜ GELENLER
            SqlCommand komut2 = new SqlCommand("select musteri.musteriAdSoyad as 'Ad Soyad' ,iller.sehir as 'Şehir',ilceler.ilce as 'İlçe',CONVERT(VARCHAR,taksitler.taksitTarih) as 'Tarih' from taksitler" +
            " inner join musteri on taksitler.taksitMusteriid = musteri.musteriID" +
            " inner join iller on taksitler.taksitIl = iller.id" +
            " inner join ilceler on taksitler.taksitIlce = ilceler.id " +
            " where taksitTarih = '"+ label7.Text + "' and taksitler.durum = 1", bgl.baglanti());
            SqlDataAdapter da2 = new SqlDataAdapter(komut2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2; 
            // 30 güne yakın bakım günleri
            SqlCommand komut3 = new SqlCommand("select musteri.musteriAdSoyad as 'Ad Soyad' ,iller.sehir as 'Şehir',ilceler.ilce as 'İlçe',CONVERT(VARCHAR,teknikler.teknikBakimTarih) as 'Tarih' from teknikler" +
            " inner join musteri on teknikler.teknikMusteriid = musteri.musteriID" +
            " inner join iller on teknikler.teknikIl = iller.id" +
            " inner join ilceler on teknikler.teknikIlce = ilceler.id " +
            " where teknikBakimTarih > '" + format + "' and teknikler.durum = 1 and teknikler.teknikBaslik='BAKIM'", bgl.baglanti());
            SqlDataAdapter da3 = new SqlDataAdapter(komut3);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            dataGridView3.DataSource = dt3;
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
