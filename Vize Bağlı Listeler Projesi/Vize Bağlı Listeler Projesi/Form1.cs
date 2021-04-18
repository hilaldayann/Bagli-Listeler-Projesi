using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vize_Bağlı_Listeler_Projesi
{
    public partial class Form1 : Form
    {
        public class ciftDugum
        {
            public int kodu;
            public string adi;
            public int fiyati;
            public ciftDugum sonraki;
            public ciftDugum onceki;
        }

        ciftDugum ilk = null;
        ciftDugum son = null;

        int kontrol = 0;
        int satir = -1;

        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ciftDugum yeni = new ciftDugum();
            ciftDugum gecici = ilk;
            yeni.kodu = Convert.ToInt32(textBox1.Text);
            yeni.adi = textBox2.Text;
            yeni.fiyati = Convert.ToInt32(textBox3.Text);
            bool varMiyokMu = false;

            if (ilk == null)
            {
                ilk = yeni;
                son = yeni;
                ilk.onceki = null;
                son.sonraki = null;
            }

            else
            {
                while (gecici != null)
                {
                    if (gecici.kodu == Convert.ToInt32(textBox1.Text))
                    {
                        varMiyokMu = true;
                        break;
                    }
                    gecici = gecici.sonraki;
                }
                if (varMiyokMu == false)
                {
                    ilk.onceki = yeni;
                    yeni.sonraki = ilk;
                    ilk = yeni;
                    ilk.onceki = null;
                }
                else
                {
                    MessageBox.Show("Eklemek İstediğiniz Ürünün Ürün Kodu Daha Önce Kullanılmıştır. Lütfen Ürün Kodunu Değiştiriniz.");
                }
            }

            dataGridView1.Rows.Clear();
            ciftDugum liste = ilk;
            while (liste != null)
            {
                dataGridView1.Rows.Add(liste.kodu, liste.adi, liste.fiyati);
                liste = liste.sonraki;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int bul = Convert.ToInt32(textBox4.Text);
            ciftDugum bulunacak = ilk;
            while (bulunacak != null)
            {
                if (bul == bulunacak.kodu)
                {
                    break;
                }
                else
                {
                    bulunacak = bulunacak.sonraki;
                }
            }
            textBox5.Text = bulunacak.adi;
            textBox6.Text = Convert.ToString(bulunacak.fiyati);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int kodu = Convert.ToInt32(textBox4.Text);
            ciftDugum gecici = ilk;

            while (gecici.sonraki != null)
            {
                if (gecici.kodu == kodu)
                {
                    kontrol = 1;
                    if (gecici == ilk)
                    {
                        ilk = gecici.sonraki;
                        ilk.onceki = null;
                        kontrol = 1;
                    }
                    else
                    {
                        gecici.onceki.sonraki = gecici.sonraki;
                        gecici.sonraki.onceki = gecici.onceki;
                    }
                }
                gecici = gecici.sonraki;
            }

            if (gecici.kodu == kodu)
            {
                gecici.onceki.sonraki = null;
            }

            dataGridView1.Rows.Clear();
            ciftDugum liste = ilk;
            while (liste != null)
            {
                dataGridView1.Rows.Add(liste.kodu, liste.adi, liste.fiyati);
                liste = liste.sonraki;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int bul = Convert.ToInt32(textBox7.Text);
            ciftDugum bulunacak = ilk;
            while (bulunacak != null)
            {
                if (bul == bulunacak.kodu)
                {
                    break;
                }
                else
                {
                    bulunacak = bulunacak.sonraki;
                }
            }
            textBox8.Text = bulunacak.adi;
            textBox9.Text = Convert.ToString(bulunacak.fiyati);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            satir = dataGridView1.CurrentRow.Index;
            dataGridView1.Rows[satir].Cells[2].Value = textBox9.Text;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString();

            textBox4.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            textBox5.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
            textBox6.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString();

            textBox7.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            textBox8.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
            textBox9.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString();
        }
    }
}