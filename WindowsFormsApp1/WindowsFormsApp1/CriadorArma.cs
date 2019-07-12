using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class CriadorArma : Form
    {
        Personagem personagem;
        public CriadorArma(Personagem personagem)
        {
            this.personagem = personagem;
            InitializeComponent();
            Ataque.TextChanged += TextChanged;
            Defesa.TextChanged += TextChanged;
            Vida.TextChanged += TextChanged;
            ChanceCritico.TextChanged += TextChanged;
           
        }
        

        private int lvl;
        private double gold;
        private Boolean Validacao()
        {
            if (Ataque.Text == "" || Defesa.Text == "" || Vida.Text == "" || ChanceCritico.Text == "")
                return false;
            if (int.TryParse(Ataque.Text, out int a) && int.TryParse(Defesa.Text, out int b) && int.TryParse(Vida.Text, out int c) && int.TryParse(ChanceCritico.Text, out int d))
                return true;
            return false;
        }
        private void TextChanged(object sender, EventArgs e)
        {

            if(Validacao())
            {
                int.TryParse(Ataque.Text, out int a);
                int.TryParse(Defesa.Text, out int b);
                int.TryParse(Vida.Text, out int c);
                int.TryParse(ChanceCritico.Text, out int d);
                label1.Text = ((a * 3) + (b * 4) + (c * 2) + (d * 10)).ToString();
                gold = Convert.ToDouble(label1.Text);
                double lvlnecessario = (gold / 100);
                char[] separador = new char[] { '.' };
                string[] virgula = lvlnecessario.ToString().Split(separador);
                lvl = Convert.ToInt32((gold / 100));
                label6.Text = lvl.ToString();
            }
            else
                label1.Text = "Apenas numeros por favor";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            var a = openFileDialog.FileName;
            
            string NomeItem = openFileDialog.SafeFileName;
            if (Validacao())
            {
                Itens item = new Itens(Convert.ToDouble(Ataque.Text),
                    Convert.ToDouble(Defesa.Text),
                    Convert.ToDouble(Vida.Text),
                    Convert.ToInt32(ChanceCritico.Text)
                    , a, Convert.ToInt32(gold), lvl, NomeItem,(tipo)(byte)listBox1.SelectedIndex);

                new LoadOrSave().WriteToJsonFile<Itens>(@"C:\Users\Mateus.Storalli\Downloads\Jogo\Itens\" + NomeItem, item);
            }
            label1.Text = a;

        }
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            Thread Thread = new Thread(OpenNewForm);
            Thread.Start();
        }
        public void OpenNewForm(object form)
        {
            Application.Run(new Form2(personagem));
            GC.Collect();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
