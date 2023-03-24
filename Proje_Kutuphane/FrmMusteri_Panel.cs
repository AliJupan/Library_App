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
    public partial class FrmMusteri_Panel : Form
    {
        public FrmMusteri_Panel()
        {
            InitializeComponent();
        }
 
        sqlbaglantisi bgl = new sqlbaglantisi();
        public string ads;

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmMusteri_Panel_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'proje_KutuphaneDataSet.Tbl_Kitap' table. You can move, or remove it, as needed.
            this.tbl_KitapTableAdapter.Fill(this.proje_KutuphaneDataSet.Tbl_Kitap);
            label6.Text =ads;
            SqlCommand doldur = new SqlCommand("select * from Tbl_Musteri where musteri_adsoyad=@p1", bgl.baglanti());
            doldur.Parameters.AddWithValue("@p1",label6.Text); 
            SqlDataReader dr= doldur.ExecuteReader();
            while(dr.Read())
            {
                label7.Text = dr[0].ToString();
                label5.Text = dr[2].ToString();
                label4.Text = dr[4].ToString();
            }
            bgl.baglanti().Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand doldur = new SqlCommand("update Tbl_Musteri set musteri_kitap=@p1 where musteri_id=@p2", bgl.baglanti());
                doldur.Parameters.AddWithValue("@p1", textBox4.Text);
                doldur.Parameters.AddWithValue("@p2", label7.Text);
                SqlCommand cmd = new SqlCommand("select * from Tbl_Musteri where musteri_kitap=@k2", bgl.baglanti());
                cmd.Parameters.AddWithValue("@k2", textBox4.Text);
                var dr = cmd.ExecuteScalar();
                if (dr != null)
                {
                    MessageBox.Show("Lütfen Başka Kitap Seçiniz", "Dikkat!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    doldur.ExecuteNonQuery();
                    MessageBox.Show("Kitap Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bgl.baglanti().Close();
                }

            }
            catch
            {
                MessageBox.Show("Lütfen Başka Kitap Seçiniz", "Dikkat!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            textBox4.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FrmGiris fr = new FrmGiris();
            fr.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmMusteri_Bilgileri_Guncelle frm = new FrmMusteri_Bilgileri_Guncelle();
            frm.Text = label6.Text;
            frm.ad = label6.Text;
            frm.telno= label4.Text;
            frm.Show();
        }
    }
}
