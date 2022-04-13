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
    public partial class frmRaporlar : Form
    {
        public frmRaporlar()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();

        private void frmRaporlar_Load(object sender, EventArgs e)
        {
            label7.Text = DateTime.Now.ToLongDateString();

            SqlCommand komut = new SqlCommand("select taksitTarih as 'Tarih',sum(taksitAylikUcret) as 'Ücret' from taksitler group by taksitTarih",bgl.baglanti());
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                chart1.Series["Tarihler"].Points.AddXY(oku[0].ToString(), oku[1].ToString());
            }
            bgl.baglanti().Close();

            // İL RAPOR YAP
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from iller ORDER BY id ASC ", bgl.baglanti());
            da.Fill(dt);
            cmbIL.ValueMember = "id";
            cmbIL.DisplayMember = "sehir";
            cmbIL.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlCommand komut = new SqlCommand("select Convert(varchar(10), sum(taksitAylikUcret)) from taksitler where convert(datetime, taksitTarih, 103) < convert(datetime, '"+txtTarih.Text+"', 103) and taksitler.durum=1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", label7.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                lblTarih.Text = dr[0].ToString() + " TL";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select Convert(varchar(10), sum(taksitAylikUcret)) from taksitler where taksitler.taksitIl=@p1 and taksitler.durum=1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", cmbIL.SelectedValue);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                lblSehir.Text = dr[0].ToString() + " TL";
            }
        }
    }
}
