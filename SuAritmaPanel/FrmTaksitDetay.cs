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
    public partial class FrmTaksitDetay : Form
    {
        sqlbaglantisi bgl = new sqlbaglantisi();

        public FrmTaksitDetay()
        {
            InitializeComponent();
        }

        public string id;
        public string tarih;
        public string ucret;
        public string taksit;

        private void FrmTaksitDetay_Load(object sender, EventArgs e)
        {
            maskedTextBox1.Text = tarih;
            mskUcret.Text = ucret;
            DateTime tarih2 = Convert.ToDateTime(maskedTextBox1.Text).AddMonths(1);
            string formatlanmis = tarih2.ToString("dd/MM/yyyy");
            label5.Text = formatlanmis;

            label3.Text = id;
            maskedTextBox2.Text = taksit;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int taksit2 = int.Parse(maskedTextBox2.Text) + 1;

            if (maskedTextBox2.Enabled == true)
            {
                SqlCommand komut = new SqlCommand("update taksitler set taksitTarih=@p1,taksitAylikUcret=@p2,taksitSayi=@p3 where taksitID=@p4", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", maskedTextBox1.Text);
                komut.Parameters.AddWithValue("@p2", mskUcret.Text);
                komut.Parameters.AddWithValue("@p3", taksit2);
                komut.Parameters.AddWithValue("@p4", label3.Text);
                komut.ExecuteNonQuery();
                this.Close();
            }
            else
            {
                SqlCommand komut = new SqlCommand("update taksitler set taksitTarih=@p1,taksitAylikUcret=@p2,taksitSayi=@p3 where taksitID=@p4", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", label5.Text);
                komut.Parameters.AddWithValue("@p2", mskUcret.Text);
                komut.Parameters.AddWithValue("@p3", maskedTextBox2.Text);
                komut.Parameters.AddWithValue("@p4", label3.Text);
                komut.ExecuteNonQuery();
                this.Close();
            }

          // Taksit ay düşür

            frmTaksitler f2 = (frmTaksitler)Application.OpenForms["frmTaksitler"];
            f2.odeme();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            maskedTextBox1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mskUcret.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            maskedTextBox2.Enabled = true;
        }
    }
}
