using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
namespace SuAritmaPanel
{
    public partial class frmMusteriler : Form
    {
        sqlbaglantisi bgl = new sqlbaglantisi();
        public frmMusteriler()
        {
            InitializeComponent();
        }
        
        private void listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("select musteriID as 'ID',musteriAdSoyad as 'Ad Soyad', musteriTC as 'T.C NO'" +
                ",iller.sehir as 'İL', ilceler.ilce as 'İlçe',musteriMahalle as 'Mahalle', musteriAcikAdres as 'Açık Adres',musteriTelefon as 'Telefon' from musteri" +
                " inner join iller on musteri.musteriIl = iller.id " +
                "inner join ilceler on musteri.musteriIlce = ilceler.id " +
                "where durum=1",bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
         

        }

        private void frmMusteriler_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from iller ORDER BY id ASC ", bgl.baglanti());
            da.Fill(dt);
            cmbIl.ValueMember = "id";
            cmbIl.DisplayMember = "sehir";
            cmbIl.DataSource = dt;
            DataTable dt2 = new DataTable();

            SqlDataAdapter da2 = new SqlDataAdapter("select * from iller ORDER BY id ASC ", bgl.baglanti());
            da2.Fill(dt2);
            txtIl.ValueMember = "id";
            txtIl.DisplayMember = "sehir";
            txtIl.DataSource = dt2;
            listele();



        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
           
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand kaydet = new SqlCommand("insert into musteri (musteriAdSoyad,musteriTC,musteriIl,musteriIlce,musteriMahalle,musteriAcikAdres,musteriTelefon,durum) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,1)", bgl.baglanti());
                kaydet.Parameters.AddWithValue("@p1", txtAdSoyad.Text);
                kaydet.Parameters.AddWithValue("@p2", mskTC.Text);
                kaydet.Parameters.AddWithValue("@p3", cmbIl.SelectedValue);
                kaydet.Parameters.AddWithValue("@p4", cmbIlce.SelectedValue);
                kaydet.Parameters.AddWithValue("@p5", txtMahalle.Text);
                kaydet.Parameters.AddWithValue("@p6", rtbAdres.Text);
                kaydet.Parameters.AddWithValue("@p7", txtTelefon.Text);
                kaydet.ExecuteNonQuery();
                MessageBox.Show("Müşteri kayıt edildi");
                listele();
            }
            catch (Exception)
            {
                MessageBox.Show("Bir şeyler eksik veya yanlış gitti.","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);


            }



        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand sil = new SqlCommand("update musteri set durum=0 where musteriID=@p1",bgl.baglanti());
            sil.Parameters.AddWithValue("@p1", txtID.Text);
            sil.ExecuteNonQuery();
            listele();
            MessageBox.Show("Müşteri sistemden silindi");

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int secilen = dataGridView1.SelectedCells[0].RowIndex;
                txtID.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
                txtAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
                txtIl.SelectedValue = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
                txtIlce.SelectedValue = dataGridView1.Rows[secilen].Cells[4].Value.ToString();

            }
            catch (Exception)
            {


            }
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

        private void cmbIlce_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAra_Click(object sender, EventArgs e)
        {
          
            SqlCommand komut = new SqlCommand("SELECT musteriID as 'ID',musteriAdSoyad as 'Ad Soyad', musteriTC as 'T.C NO'" +
                ",iller.sehir as 'İL', ilceler.ilce as 'İlçe',musteriMahalle as 'Mahalle', musteriAcikAdres as 'Açık Adres',musteriTelefon as 'Telefon' from musteri" +
                " inner join iller on musteri.musteriIl = iller.id " +
                "inner join ilceler on musteri.musteriIlce = ilceler.id " +
                "WHERE musteriAdSoyad like '%" + txtAd.Text+ "%' and musteriIl=@p2 and musteriIlce=@p3", bgl.baglanti());
            komut.Parameters.AddWithValue("@p2", txtIl.SelectedValue);
            komut.Parameters.AddWithValue("@p3", txtIlce.SelectedValue);
            komut.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(komut);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            listele();
        }
    }
}
