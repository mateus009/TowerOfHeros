using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Personagem personagem;
        
        public Form1()
        {
            
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                return;
            personagem = new Personagem();
            personagem.nome = textBox1.Text;
            OtherForm();
        }
        public void OpenNewForm(object form)
        {
            Application.Run(new Form2(personagem));
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int top = 247;
            int left = 214;
            string[] pastas;
            string[] dir = Directory.GetFiles(@"C:\Users\Mateus.Storalli\Downloads\Jogo\Save");
            foreach (string item in dir)
            {
                Button button = new Button();
                char[] separador = new char[] {'\\'};
                string nome = item.Split(separador, StringSplitOptions.None)[6];
                button.Name = nome;
                button.Text = nome;
                button.Top = top;
                button.Left = left;
                left = left + 80;
                this.Controls.Add(button);
                button.Click += Button_Click; ;

            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            
            Button button = sender as Button;
            LoadOrSave load= new LoadOrSave();
            personagem = load.ReadFromJsonFile<Personagem>(@"C:\Users\Mateus.Storalli\Downloads\Jogo\save\"+ button.Name);
            
            OtherForm();
        }
        private void OtherForm()
        {
            Close();
            Thread thread;
            thread = new Thread(OpenNewForm);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();

        }
    }
}
