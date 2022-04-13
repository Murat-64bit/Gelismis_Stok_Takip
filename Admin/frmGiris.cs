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
    public partial class frmGiris : Form
    {
        sqlbaglantisi bgl = new sqlbaglantisi();
        public frmGiris()
        {
            InitializeComponent();
        }
        int Move;
        int Mouse_X;
        int Mouse_Y;

        private void btnAnaSayfa_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from uyeler where uyeKullaniciAd=@p1 and uyeSifre=@p2 and uyeAdmin=1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", textBox1.Text);
            komut.Parameters.AddWithValue("@p2", textBox2.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                Form1 fr = new Form1();
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı Adı veya Şifre", "Bildirim", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            bgl.baglanti().Close();
        }

        private void frmGiris_Load(object sender, EventArgs e)
        {

        }

        private void frmGiris_MouseUp(object sender, MouseEventArgs e)
        {
            Move = 0;
        }

        private void frmGiris_MouseDown(object sender, MouseEventArgs e)
        {
            Move = 1;
            Mouse_X = e.X;
            Mouse_Y = e.Y;
        }

        private void frmGiris_MouseMove(object sender, MouseEventArgs e)
        {
            if (Move == 1)
            {
                this.SetDesktopLocation(MousePosition.X - Mouse_X, MousePosition.Y - Mouse_Y);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
