using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proje_Kutuphane
{
    public partial class FrmCalisan_Giris : Form
    {
        public FrmCalisan_Giris()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl=new sqlbaglantisi();

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select *from Tbl_Calisan where calisan_adsoyad=@p1 and calisan_sifre=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", textBox1.Text);
            komut.Parameters.AddWithValue("@p2", textBox2.Text);
            SqlDataReader dr=komut.ExecuteReader();
            if (dr.Read())
            {
                FrmCalisan_Panel fr = new FrmCalisan_Panel();
                fr.Text = textBox1.Text;
                fr.adsoyad = textBox1.Text;
                fr.sifre=textBox2.Text;
                fr.Show();
                this.Hide();
            }
            else
                MessageBox.Show("Hatalı Ad Soyad veya Şifre!! \n Lütfen Tekrar Deneyin!!", "Dikkat!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            bgl.baglanti().Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FrmGiris fr = new FrmGiris();
            fr.Show();
            this.Hide();
        }
    }
}
