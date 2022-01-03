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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-RE91BPD\SQLEXPRESS;Initial Catalog=TEST;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
            
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From TBLKISILER where NUMARA=@p1 AND SIFRE=@p2", baglanti);
            komut.Parameters.AddWithValue("@p1", masknum.Text);
            komut.Parameters.AddWithValue("@p2", txtsifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if(dr.Read())
            {
                Form2 fr = new Form2();
                fr.numara = masknum.Text;
                fr.Show();
            }
            else
            {
                MessageBox.Show("Hatalı Bilgi");

            }
        }
    }
}
