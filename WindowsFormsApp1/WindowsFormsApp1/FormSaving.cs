using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FormSaving : Form
    {
        //string Caminho = @"C:\Users\Mateus.Storalli\Downloads\Jogo\Save\" ;
        
        Personagem personagem;
        Thread thread;
        public FormSaving(Personagem personagem)
        {
            InitializeComponent();
            this.personagem = personagem;
        }
 
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                label1.Text = "Digite um nome";
                return;
            }
            
            Personagem pwersonagem = personagem;
            string nom4e = textBox1.Text;
            LoadOrSave Save = new LoadOrSave();
            Save.WriteToJsonFile<Personagem>(@"C:\Users\Mateus.Storalli\Downloads\Jogo\Save\" + nom4e +".txt", pwersonagem);
            nom4e = null;
            label1.Text = "Salvo";
            JsonConverter.WriteJson<Personagem>(@"C:\Users\Mateus.Storalli\Downloads\Jogo\Save\" + nom4e + ".json", personagem);
        }
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            thread = new Thread(OpenNewForm);
            thread.Start();
        }
        public void OpenNewForm(object form)
        {
            Application.Run(new Form2(personagem));
            GC.Collect();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
