using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proje_Kutuphane
{
    public partial class FrmMusteri_Bilgileri_Guncelle : Form
    {
        public FrmMusteri_Bilgileri_Guncelle()
        {
            InitializeComponent();
        }

        public string ad;
        public string telno;
        sqlbaglantisi bgl = new sqlbaglantisi();

        private void FrmMusteri_Bilgileri_Guncelle_Load(object sender, EventArgs e)
        {
            txtadsoyad.Text = ad;
            msktelno.Text = telno;
        }

        private void btn_girisyap2_Click(object sender, EventArgs e)
        {
            SqlCommand guncelle = new SqlCommand("update Tbl_Musteri set musteri_sifre=@p1,musteri_telno=@p2 where musteri_adsoyad=@p3", bgl.baglanti());
            guncelle.Parameters.AddWithValue("@p1", txtsifre.Text);
            guncelle.Parameters.AddWithValue("@p2", msktelno.Text);
            guncelle.Parameters.AddWithValue("@p3", txtadsoyad.Text);
            guncelle.ExecuteNonQuery();
            MessageBox.Show("Bilglileriniz Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            bgl.baglanti().Close();
        }
    }
}
