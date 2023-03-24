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
    public partial class FrmSifre : Form
    {
        public FrmSifre()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand giris = new SqlCommand("select *from Tbl_Musteri where musteri_id=@p1 and musteri_adsoyad=@p2 and musteri_telno=@p3", bgl.baglanti());
                giris.Parameters.AddWithValue("@p1", textBox1.Text);
                giris.Parameters.AddWithValue("@p2", txtadsoyad_ko.Text);
                giris.Parameters.AddWithValue("@p3", msktelno_ko.Text);
                SqlDataReader dr = giris.ExecuteReader();
                if (dr.Read())
                {
                    panel2.BringToFront();

                }
                else
                    MessageBox.Show("Hatalı Ad Soyad veya Şifre!! \n Lütfen Tekrar Deneyin!!", "Dikkat!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bgl.baglanti().Close();
            }
            catch
            {
                MessageBox.Show("Hatalı Giriş!! \nLütfen Tekrar Deneyin!!", "Dikkat!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand guncelle = new SqlCommand("update Tbl_Musteri set musteri_sifre=@p1 where musteri_id=@p2", bgl.baglanti());
                guncelle.Parameters.AddWithValue("@p1", txtsifre.Text);
                guncelle.Parameters.AddWithValue("@p2", textBox1.Text);
                guncelle.ExecuteNonQuery();
                MessageBox.Show("Şifreniz Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Hatalı Giriş!! \nLütfen Tekrar Deneyin!!", "Dikkat!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmSifre_Load(object sender, EventArgs e)
        {
            panel1.BringToFront();
        }
    }
}
