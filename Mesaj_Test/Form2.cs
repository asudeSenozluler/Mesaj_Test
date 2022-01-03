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

namespace Mesaj_Test
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public string numara;

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-RE91BPD\SQLEXPRESS;Initial Catalog=TEST;Integrated Security=True");
        void gelenkutusu()
            {
                SqlDataAdapter da1=new SqlDataAdapter("Select * From TBLMESAJLAR where alıcı="+numara,baglanti);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                dataGridView1.DataSource = dt1;
             }
        void gidenkutusu()
        {
            SqlDataAdapter da2 = new SqlDataAdapter("Select * From TBLMESAJLAR where gonderen=" + numara, baglanti);
            DataTable dt2= new DataTable();
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            lblnum.Text = numara;
            gelenkutusu();
            gidenkutusu();

            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select Ad,Soyad From TBLKISILER where numara=" + numara, baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while(dr.Read())
            {
                lbladsoyad.Text = dr[0] + " " + dr[1];
            }
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into TBLMESAJLAR (gonderen,alıcı,baslık,ıcerık) values (@p1,@p2,@p3,@p4) ", baglanti);
            komut.Parameters.AddWithValue("@p1", numara);
            komut.Parameters.AddWithValue("@p2", maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@p3", textBox1.Text);
            komut.Parameters.AddWithValue("@p4", richTextBox1.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Mesajınız İletildi");
            gidenkutusu();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            maskedTextBox1.Text = "";
            textBox1.Text = "";
            richTextBox1.Text = "";
        }
    }
}
