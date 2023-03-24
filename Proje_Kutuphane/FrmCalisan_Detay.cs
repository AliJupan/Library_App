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
    public partial class FrmCalisan_Detay : Form
    {
        public FrmCalisan_Detay()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl=new sqlbaglantisi();  

        private void FrmCalisan_Detay_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'proje_KutuphaneDataSet1.Tbl_Calisan' table. You can move, or remove it, as needed.
            this.tbl_CalisanTableAdapter.Fill(this.proje_KutuphaneDataSet1.Tbl_Calisan);

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.tbl_CalisanTableAdapter.Fill(this.proje_KutuphaneDataSet1.Tbl_Calisan);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtad.Clear();
            txtid.Clear();
            txtsifre.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand ekle = new SqlCommand("insert into Tbl_Calisan(calisan_adsoyad,calisan_sifre)values(@p2,@p3)",bgl.baglanti());
            ekle.Parameters.AddWithValue("@p2",txtad.Text);
            ekle.Parameters.AddWithValue("@p3", txtsifre.Text);
            ekle.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Çalışan Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand guncelle = new SqlCommand("update Tbl_Calisan set calisan_adsoyad=@p1,calisan_sifre=@p2 where calisan_id=@p3", bgl.baglanti());
            guncelle.Parameters.AddWithValue("@p1", txtad.Text);
            guncelle.Parameters.AddWithValue("@p2", txtsifre.Text);
            guncelle.Parameters.AddWithValue("@p3", txtid.Text);
            guncelle.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Çalışan Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand guncelle = new SqlCommand("delete from  Tbl_Calisan where calisan_id=@p1", bgl.baglanti());
            guncelle.Parameters.AddWithValue("@p1", txtid.Text);
            guncelle.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Çalışan Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtsifre.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
        }
    }
}
