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
    public partial class frmTaksitSecim : Form
    {
        sqlbaglantisi bgl = new sqlbaglantisi();
        public frmTaksitSecim()
        {
            InitializeComponent();
        }
        public int musteriid;
        public string musteriad;
        private void frmTaksitSecim_Load(object sender, EventArgs e)
        {


            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select urunAD +' '  +CONVERT(varchar(10), taksitAylikUcret) + ' TL' as 'Selam' , CONVERT(varchar(10), taksitAylikUcret) + ' TL' as 'Para',taksitAylikUcret,UrunAD from taksitler " +
                "inner join urunler on taksitler.taksitUrun = urunler.urunID where taksitler.durum=1 and taksitler.taksitMusteriid=" + musteriid+"", bgl.baglanti());
            da.Fill(dt);
            listBox1.ValueMember = "taksitUrun";
            listBox1.DisplayMember = "Selam";
            listBox1.DataSource = dt;
            

            /* DataTable dt = new DataTable();
          SqlDataAdapter da = new SqlDataAdapter("select * from urunler", bgl.baglanti());
          // komut.Parameters.AddWithValue("@p1", musteriid);
          da.Fill(dt);
          listBox1.ValueMember = "urunID";
          listBox1.DisplayMember = "urunAD";
          listBox1.DataSource = dt; 
            "select urunAD,taksitAylikUcret from taksitler inner join " +
                "urunler on taksitler.taksitUrun = urunler.urunID where taksitler.durum=1 and taksitler.taksitMusteriid=@p1*/
            textBox1.Text = musteriad;

        }



        public void btnMusteriler_Click(object sender, EventArgs e)
        {
            frmTaksitler fr = new frmTaksitler();
            if (listBox1.SelectedItems.Count <=5)
            {
                if (listBox1.SelectedItems.Count == 1)
                {
                    fr.bir = (listBox1.SelectedItems[0] as DataRowView)["urunAD"].ToString();
                    fr.bir1 = (listBox1.SelectedItems[0] as DataRowView)["Para"].ToString();
                    fr.birs1 = int.Parse((listBox1.SelectedItems[0] as DataRowView)["taksitAylikUcret"].ToString());
                    fr.Musteriat = textBox1.Text;
                    Form1 f2 = (Form1)Application.OpenForms["Form1"];
                    f2.formGetir(fr);
                }
                else if (listBox1.SelectedItems.Count == 2)
                {
                    fr.bir = (listBox1.SelectedItems[0] as DataRowView)["urunAD"].ToString();
                    fr.bir1 = (listBox1.SelectedItems[0] as DataRowView)["Para"].ToString();
                    fr.birs1 = int.Parse((listBox1.SelectedItems[0] as DataRowView)["taksitAylikUcret"].ToString());
                    fr.iki = (listBox1.SelectedItems[1] as DataRowView)["urunAD"].ToString();
                    fr.iki2 = (listBox1.SelectedItems[1] as DataRowView)["Para"].ToString();
                    fr.ikis2 = int.Parse((listBox1.SelectedItems[1] as DataRowView)["taksitAylikUcret"].ToString());
                    fr.Musteriat = textBox1.Text;

                    Form1 f2 = (Form1)Application.OpenForms["Form1"];
                    f2.formGetir(fr);
                }
                else if (listBox1.SelectedItems.Count == 3)
                {
                    fr.bir = (listBox1.SelectedItems[0] as DataRowView)["urunAD"].ToString();
                    fr.bir1 = (listBox1.SelectedItems[0] as DataRowView)["Para"].ToString();
                    fr.birs1 = int.Parse((listBox1.SelectedItems[0] as DataRowView)["taksitAylikUcret"].ToString());
                    fr.iki = (listBox1.SelectedItems[1] as DataRowView)["urunAD"].ToString();
                    fr.iki2 = (listBox1.SelectedItems[1] as DataRowView)["Para"].ToString();
                    fr.ikis2 = int.Parse((listBox1.SelectedItems[1] as DataRowView)["taksitAylikUcret"].ToString());
                    fr.uc = (listBox1.SelectedItems[2] as DataRowView)["urunAD"].ToString();
                    fr.uc3 = (listBox1.SelectedItems[2] as DataRowView)["Para"].ToString();
                    fr.ucs3 = int.Parse((listBox1.SelectedItems[2] as DataRowView)["taksitAylikUcret"].ToString());

                    fr.Musteriat = textBox1.Text;

                    Form1 f2 = (Form1)Application.OpenForms["Form1"];
                    f2.formGetir(fr);
                }
                else if (listBox1.SelectedItems.Count == 4)
                {
                    fr.bir = (listBox1.SelectedItems[0] as DataRowView)["urunAD"].ToString();
                    fr.bir1 = (listBox1.SelectedItems[0] as DataRowView)["Para"].ToString();
                    fr.birs1 = int.Parse((listBox1.SelectedItems[0] as DataRowView)["taksitAylikUcret"].ToString());
                    fr.iki = (listBox1.SelectedItems[1] as DataRowView)["urunAD"].ToString();
                    fr.iki2 = (listBox1.SelectedItems[1] as DataRowView)["Para"].ToString();
                    fr.ikis2 = int.Parse((listBox1.SelectedItems[1] as DataRowView)["taksitAylikUcret"].ToString());
                    fr.uc = (listBox1.SelectedItems[2] as DataRowView)["urunAD"].ToString();
                    fr.uc3 = (listBox1.SelectedItems[2] as DataRowView)["Para"].ToString();
                    fr.ucs3 = int.Parse((listBox1.SelectedItems[2] as DataRowView)["taksitAylikUcret"].ToString());
                    fr.dort = (listBox1.SelectedItems[3] as DataRowView)["urunAD"].ToString();
                    fr.dort4 = (listBox1.SelectedItems[3] as DataRowView)["Para"].ToString();
                    fr.dorts4 = int.Parse((listBox1.SelectedItems[3] as DataRowView)["taksitAylikUcret"].ToString());

                    fr.Musteriat = textBox1.Text;

                    Form1 f2 = (Form1)Application.OpenForms["Form1"];
                    f2.formGetir(fr);
                }
                else if (listBox1.SelectedItems.Count == 5)
                {
                    fr.bir = (listBox1.SelectedItems[0] as DataRowView)["urunAD"].ToString();
                    fr.bir1 = (listBox1.SelectedItems[0] as DataRowView)["Para"].ToString();
                    fr.birs1 = int.Parse((listBox1.SelectedItems[0] as DataRowView)["taksitAylikUcret"].ToString());
                    fr.iki = (listBox1.SelectedItems[1] as DataRowView)["urunAD"].ToString();
                    fr.iki2 = (listBox1.SelectedItems[1] as DataRowView)["Para"].ToString();
                    fr.ikis2 = int.Parse((listBox1.SelectedItems[1] as DataRowView)["taksitAylikUcret"].ToString());
                    fr.uc = (listBox1.SelectedItems[2] as DataRowView)["urunAD"].ToString();
                    fr.uc3 = (listBox1.SelectedItems[2] as DataRowView)["Para"].ToString();
                    fr.ucs3 = int.Parse((listBox1.SelectedItems[2] as DataRowView)["taksitAylikUcret"].ToString());
                    fr.dort = (listBox1.SelectedItems[3] as DataRowView)["urunAD"].ToString();
                    fr.dort4 = (listBox1.SelectedItems[3] as DataRowView)["Para"].ToString();
                    fr.dorts4 = int.Parse((listBox1.SelectedItems[3] as DataRowView)["taksitAylikUcret"].ToString());
                    fr.bes = (listBox1.SelectedItems[4] as DataRowView)["urunAD"].ToString();
                    fr.bes5 = (listBox1.SelectedItems[4] as DataRowView)["Para"].ToString();
                    fr.bess5 = int.Parse((listBox1.SelectedItems[4] as DataRowView)["taksitAylikUcret"].ToString());
                    fr.Musteriat = textBox1.Text;

                    Form1 f2 = (Form1)Application.OpenForms["Form1"];
                    f2.formGetir(fr);
                }
            }
            else
            {
                MessageBox.Show("Seçtiğiniz aralıklar beş seçenekten fazladır lütfen tekrar kontrol ediniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            



            //fr.uc = checkedListBox1.SelectedItem.ToString();
            //fr.dort = checkedListBox1.SelectedItem.ToString();
            /* fr.iki = checkedListBox1.SelectedItems[1].ToString();
             fr.uc = checkedListBox1.SelectedItems[2].ToString();
             fr.dort = checkedListBox1.SelectedItems[3].ToString();
             fr.bes = checkedListBox1.SelectedItems[4].ToString(); */

        


        }

        private void frmTaksitSecim_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
