using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace adamasmaca
{
    public partial class Form1 : Form
    {
        string[] kelimeler = { "BILGISAYAR", "YAZILIM", "KLAVYE", "MONITOR", "INTERNET" };

        Random rnd = new Random();

        string secilenKelime;
        char[] gorunenKelime;

        int can = 6;
        int skor = 0;
        int yanlis = 0;
        string[] asama =
{
    "🙂",
    "😐",
    "😕",
    "😟",
    "😨",
    "😰",
    "💀"
};
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            skor = 0;
            label3.Text = "Skor: 0";

            YeniOyun();
            YeniOyun();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            char harf = Convert.ToChar(textBox1.Text.ToUpper());

            bool bulundu = false;

            for (int i = 0; i < secilenKelime.Length; i++)
            {
                if (secilenKelime[i] == harf)
                {
                    gorunenKelime[i] = harf;
                    bulundu = true;
                }
            }

            if (!bulundu)
            {

                can--;
                yanlis++;

                label4.Text = asama[yanlis];
            }

            label1.Text = string.Join(" ", gorunenKelime);

            listBox1.Items.Add(harf);

            textBox1.Clear();

            if (!label1.Text.Contains("_"))
            {
                MessageBox.Show("Kazandın!");
            }

            if (can == 0)
            {
                MessageBox.Show("Kaybettin! Kelime: " + secilenKelime);
            }
        }
        void YeniOyun()
        {
            secilenKelime = kelimeler[rnd.Next(kelimeler.Length)];

            gorunenKelime = new char[secilenKelime.Length];

            for (int i = 0; i < gorunenKelime.Length; i++)
            {
                gorunenKelime[i] = '_';
            }

            can = 6;
            yanlis = 0; // 👈 BURAYA
            label4.Text = asama[yanlis]; // 👈 BURAYA

            label2.Text = "Can: " + can;
            label1.Text = string.Join(" ", gorunenKelime);

            listBox1.Items.Clear();
            textBox1.Clear();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            YeniOyun();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string tahmin = textBox1.Text.ToUpper();

            if (tahmin == secilenKelime)
            {
                label1.Text = string.Join(" ", secilenKelime.ToCharArray());
                MessageBox.Show("🎉 Kazandın!");
                skor += 10;
                label3.Text = "Skor: " + skor;
            }
            else
            {
                can--;
                label2.Text = "Can: " + can;
                MessageBox.Show("❌ Yanlış kelime!");
            }

            if (can == 0)
            {
                MessageBox.Show("Kaybettin! Kelime: " + secilenKelime);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
