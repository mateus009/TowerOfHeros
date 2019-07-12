using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
namespace WindowsFormsApp1
{
    public partial class Ringue : Form
    {
        private Thread thread;
        Personagem personagem;
        Monster monster;
        public Ringue(Personagem personagem)
        {
            this.personagem = personagem;
            monster = new Monster(personagem);
            InitializeComponent();
            label1.Text = personagem.vida().ToString();
            label2.Text = monster.vida().ToString();
            

        }
        public Ringue(Personagem personagem, TcpClient tcpClient)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            monster.tomarGolpe(personagem.atacar());
            label2.Text = monster.vida().ToString();
            personagem.tomarGolpe(monster.atacar());
            label1.Text = personagem.vida().ToString();
            if (monster.vida() <= 0)
                matar();
            else if (personagem.vida() <=0){
                morreu();
            }
        }
        private void matar()
        {
            personagem.upar(Convert.ToInt32(monster.Xp1));
            this.Close();
            thread = new Thread(OpenForm2);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }
        private void morreu()
        {
            this.Close();
            thread = new Thread(OpenForm1);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            int top = 50;
            int left = 100;
            List<Magias> magia = personagem.ListarMagia();
            Button button = new Button();
            foreach (var Magia in magia)
            {
                button.Name = Magia.getID().ToString() ;
                button.Text = Magia.nome;
                this.Controls.Add(button);
                button.Click += Button_Click;
                //pictureBox3.Visible = true;
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            personagem.UsarMagia(button.Name);
            

        }

        private void skill_Click(object sender, EventArgs e)
        {
            label1.Text = sender.ToString();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            
            
        }
        private void btnExit_Click(object sender, FormClosedEventArgs e)
        {
            
        }
      // protected override void OnFormClosing(FormClosingEventArgs e)
      // {
      //     GC.Collect();
      // }
      // protected override void OnFormClosed(FormClosedEventArgs e)
      // {
      //     base.OnFormClosed(e);
      //     
      // }
        
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            
            thread = new Thread(OpenForm2);
            thread.Start();
            

        }


        public void OpenForm2(object form)
        {
            Application.Run(new Form2(personagem));
            GC.Collect();
        }
        public void OpenForm1(object form)
        {
            Application.Run(new Form1());
            GC.Collect();
        }
    }
    
}
