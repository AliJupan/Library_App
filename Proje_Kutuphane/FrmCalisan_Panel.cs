using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proje_Kutuphane
{
    public partial class FrmCalisan_Panel : Form
    {
        public FrmCalisan_Panel()
        {
            InitializeComponent();
        }

        public string adsoyad;
        public string sifre;
        sqlbaglantisi bgl = new sqlbaglantisi();

        private void FrmCalisan_Detay_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'proje_KutuphaneDataSet2.Tbl_Musteri' table. You can move, or remove it, as needed.
            this.tbl_MusteriTableAdapter.Fill(this.proje_KutuphaneDataSet2.Tbl_Musteri);
            // TODO: This line of code loads data into the 'proje_KutuphaneDataSet.Tbl_Kitap' table. You can move, or remove it, as needed.
            this.tbl_KitapTableAdapter.Fill(this.proje_KutuphaneDataSet.Tbl_Kitap);
            textBox1.Text = adsoyad;
            textBox2.Text = sifre;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.UseSystemPasswordChar= false;
            textBox2.UseSystemPasswordChar = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.UseSystemPasswordChar = true;
            textBox2.UseSystemPasswordChar = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmKitap_Islemleri fr=new FrmKitap_Islemleri();
            fr.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FrmGiris fr=new FrmGiris();
            fr.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmCalisan_Detay fr=new FrmCalisan_Detay();
            fr.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.tbl_MusteriTableAdapter.Fill(this.proje_KutuphaneDataSet2.Tbl_Musteri);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            FrmGiris fr = new FrmGiris();
            fr.Show();
            this.Hide();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView2.SelectedCells[0].RowIndex;
            textBox3.Text = dataGridView2.Rows[secilen].Cells[2].Value.ToString();
            textBox4.Text = dataGridView2.Rows[secilen].Cells[0].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand doldur = new SqlCommand("update Tbl_Musteri set musteri_kitap=@p1 where musteri_id=@p2", bgl.baglanti());
            doldur.Parameters.AddWithValue("@p2", textBox4.Text);
            doldur.Parameters.AddWithValue("@p1", DBNull.Value);
            doldur.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kitap Geri Alındı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            textBox4.Clear();
            textBox3.Clear();
        }
    }
}
