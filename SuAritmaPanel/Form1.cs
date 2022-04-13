using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuAritmaPanel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string kAd;
        public void formGetir(Form frm)
        {
            panel2.Controls.Clear();
            frm.MdiParent = this;
            frm.FormBorderStyle = FormBorderStyle.None;
            panel2.Controls.Add(frm);
            frm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            frmAnaSayfa anaSayfa = new frmAnaSayfa();
            formGetir(anaSayfa);
            label2.Text = kAd;
        }

        private void btnAnaSayfa_Click(object sender, EventArgs e)
        {
            frmAnaSayfa anaSayfa = new frmAnaSayfa();
            formGetir(anaSayfa);
        }

        private void btnMusteriler_Click(object sender, EventArgs e)
        {
            frmMusteriler musteriler = new frmMusteriler();
            formGetir(musteriler);
        }

        private void btnSatislar_Click(object sender, EventArgs e)
        {
            frmSatislar satislar = new frmSatislar();
            formGetir(satislar);
        }

        private void btnTaksitler_Click(object sender, EventArgs e)
        {
            frmTaksitler taksitler = new frmTaksitler();
            formGetir(taksitler);
        }

        private void btnRapor_Click(object sender, EventArgs e)
        {
            frmRaporlar raporlar = new frmRaporlar();
            formGetir(raporlar);
        }

        private void btnTeknik_Click(object sender, EventArgs e)
        {
            frmTeknik teknik = new frmTeknik();
            formGetir(teknik);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            frmGiris giris = new frmGiris();
            this.Close();
            giris.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
