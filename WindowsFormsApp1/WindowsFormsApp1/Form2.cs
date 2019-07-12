using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using WMPLib;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
       

        Thread Thread;
        public Personagem personagem;
        HealerSkills heal = new HealerSkills();
        System.Windows.Forms.Timer tempo;
        WindowsMediaPlayer player;
        public Form2(Personagem personagem)
        {
            DoubleBuffered = true;
            player = new WindowsMediaPlayer();
            this.personagem =  personagem;
            InitializeComponent();
            tempo = new System.Windows.Forms.Timer();
            tempo.Start();
            tempo.Tick += GainGold;
            label3.Text = personagem.def().ToString();
            label2.Text = personagem.atk().ToString();
            label4.Text = personagem.vida().ToString();
            this.KeyPreview = true;
            KeyDown += Form2_KeyPress;
            
            player.URL = @"C:\Users\mateu\Desktop\jenni\Vindsvept-TheFae.mp3";
            player.controls.play();
            

        }

        private void Form2_KeyPress(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
              textBox1.Visible = true;
            textBox1.KeyDown += TextBox1_KeyDown;
        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if(textBox1.Text == "Cheats")
                {
                    tempo.Stop();
                    tempo.Dispose();
                    Close();
                    Thread = new Thread(OpenNewForm5);
                    Thread.SetApartmentState(ApartmentState.STA);
                    Thread.Start();
                }

            }

        }

        private void label1_Click(object sender, EventArgs e)
        {
            //label1.Text = tempo.Enabled.ToString();
            Luta();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }
        private void GainGold(object sender, EventArgs e)
        {
            
            label1.Text = personagem.gold().ToString();
            //GerarMonstro();
            personagem.DIETIME++;
        }
        private void GerarMonstro()
        {
          if (personagem.DIETIME % 100 == 0)
                Luta();

        }

        private void Luta()
        {
            tempo.Stop();
            tempo.Dispose();
            Close();
            Thread = new Thread(ringue);
            Thread.Start();
            
        }



        public void OpenNewForm5(object form)
        {
            Application.Run(new CriadorArma(personagem));
            GC.Collect();
        }

        public void ringue(object form)
        {
            Application.Run(new Ringue(personagem));    
            GC.Collect();
        }
        public void SaveForm(object form)
        {
            Application.Run(new FormSaving(personagem));
            GC.Collect();
            tempo.Start();
        }
        public void loja(object form)
        {
            Application.Run(new Loja(personagem));
            GC.Collect();
            tempo.Start();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
         
        }
       
        
        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            personagem.ganharGold(100);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            int gold = 0;
            double def = personagem.def();
            gold = (100 * Convert.ToInt32(def));
            personagem.ComprarDef(gold);
            label3.Text = def.ToString();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            int gold = personagem.gold();
            double att = personagem.atk();
            gold = 100 + (Convert.ToInt32(att) * 2);
            personagem.ComprarATK(gold);
            label2.Text = personagem.atk().ToString();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            tempo.Stop();
            Close();
            Thread = new Thread(ringue);
            Thread.Start();

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
           //LoadOrSave.WriteToJsonFile<Personagem>(@"C:\Users\Mateus.Storalli\Downloads\Jogo\Save\afeteste.txt", personagem);
            tempo.Stop();
            Close();
            Thread = new Thread(loja);
            Thread.Start();
            
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            tempo.Stop();
            Close();
            Thread = new Thread(inventario);
            Thread.Start();
        }
        private void inventario(object obj)
        {
            Application.Run(new Inventario(personagem));
            GC.Collect();

        }
        private void OpenPvp(object obj)
        {
            Application.Run(new RinguePVP(personagem));
            GC.Collect();

        }
        private void OpenPvp2(object obj)
        {
            Application.Run(new RinguePVPFind(personagem));
            GC.Collect();

        }

        private void label5_Click(object sender, EventArgs e)
        {
            tempo.Stop();
            tempo.Dispose();
            Close();
            Thread = new Thread(OpenPvp2);
            Thread.Start();

        }

        private void label6_Click(object sender, EventArgs e)
        {
            tempo.Stop();
            tempo.Dispose();
            Close();
            Thread = new Thread(OpenPvp);
            Thread.Start();

        }

        private void Save_click(object sender, EventArgs e)
        {
            tempo.Stop();
            Close();
            Thread = new Thread(SaveForm);
            Thread.Start();
        }
    }
}
