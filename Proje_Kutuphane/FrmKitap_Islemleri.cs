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
    public partial class FrmKitap_Islemleri : Form
    {
        public FrmKitap_Islemleri()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        private void Frm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'proje_KutuphaneDataSet.Tbl_Kitap' table. You can move, or remove it, as needed.
            this.tbl_KitapTableAdapter.Fill(this.proje_KutuphaneDataSet.Tbl_Kitap);


            SqlCommand komut = new SqlCommand("select kitap_tur from Tbl_Kitap group by Kitap_TUR", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0]);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            txtyazar.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtad.Clear();
            txtid.Clear();
            comboBox1.Items.Clear();
            txtyazar.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand guncelle = new SqlCommand("update Tbl_Kitap set kitap_ad=@p1,kitap_tur=@p2,kitap_yazar=@p3 where kitap_id=@p4", bgl.baglanti());
            guncelle.Parameters.AddWithValue("@p1", txtad.Text);
            guncelle.Parameters.AddWithValue("@p2", comboBox1.Text);
            guncelle.Parameters.AddWithValue("@p3", txtyazar.Text);
            guncelle.Parameters.AddWithValue("@p4", txtid.Text);
            guncelle.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kitap Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand sil = new SqlCommand("delete from Tbl_Kitap where kitap_id=@p1", bgl.baglanti());
            sil.Parameters.AddWithValue("@p1", txtid.Text);
            sil.ExecuteNonQuery();
            MessageBox.Show("Kitap Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand ekle = new SqlCommand("insert into Tbl_Kitap(kitap_ad,kitap_tur,kitap_yazar)values(@p1,@p2,@p3)", bgl.baglanti());
            ekle.Parameters.AddWithValue("@p1", txtad.Text);
            ekle.Parameters.AddWithValue("@p2", comboBox1.Text);
            ekle.Parameters.AddWithValue("@p3", txtyazar.Text);
            ekle.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kitap Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.tbl_KitapTableAdapter.Fill(this.proje_KutuphaneDataSet.Tbl_Kitap);
        }
    }
}
