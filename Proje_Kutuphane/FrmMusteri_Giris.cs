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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Proje_Kutuphane
{
    public partial class FrmMusteri_Giris : Form
    {
        public FrmMusteri_Giris()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl=new sqlbaglantisi();
        

        private void btn_girisyap_Click(object sender, EventArgs e)
        {
            panel2.BringToFront();
        }

        private void btn_kayitol_Click(object sender, EventArgs e)
        {
            panel1.BringToFront();
        }

        private void FrmMusteri_Giris_Load(object sender, EventArgs e)
        {
            btn_girisyap.PerformClick();
        }

        private void btn_kayitol2_Click(object sender, EventArgs e)
        {
            SqlCommand kayit = new SqlCommand("insert into Tbl_Musteri(musteri_adsoyad,musteri_sifre,musteri_telno)values(@p1,@p2,@p3)", bgl.baglanti());
            kayit.Parameters.AddWithValue("@p1", txtadsoyad_ko.Text);
            kayit.Parameters.AddWithValue("@p2", txtsifre_ko.Text);
            kayit.Parameters.AddWithValue("@p3",msktelno_ko.Text);
            SqlCommand cmd = new SqlCommand("select * from Tbl_Musteri where musteri_adsoyad=@d1", bgl.baglanti());
            cmd.Parameters.AddWithValue("@d1", txtadsoyad_ko.Text);
            var dr = cmd.ExecuteScalar();
            if (dr != null)
            {
                MessageBox.Show("Lütfen Başka Ad Soyad Deneyiniz", "Dikkat!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                kayit.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Kaydınız Alınmıştır", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_girisyap2_Click(object sender, EventArgs e)
        {
            SqlCommand giris = new SqlCommand("select *from Tbl_Musteri where musteri_adsoyad=@p1 and musteri_sifre=@p2", bgl.baglanti());
            giris.Parameters.AddWithValue("@p1", txtadsoyad_gy.Text);
            giris.Parameters.AddWithValue("@p2", txtsifre_gy.Text);
            SqlDataReader dr=giris.ExecuteReader();
            if(dr.Read())
            {
                FrmMusteri_Panel fr=new FrmMusteri_Panel();
                fr.Text = txtadsoyad_gy.Text;
                fr.ads = txtadsoyad_gy.Text;
                fr.Show();
                this.Hide();
            }
            else
                MessageBox.Show("Hatalı Ad Soyad veya Şifre!! \n Lütfen Tekrar Deneyin!!", "Dikkat!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bgl.baglanti().Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmSifre fr = new FrmSifre();
            fr.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            FrmGiris fr = new FrmGiris();
            fr.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            FrmGiris fr = new FrmGiris();
            fr.Show();
            this.Hide();
        }
    }
}
