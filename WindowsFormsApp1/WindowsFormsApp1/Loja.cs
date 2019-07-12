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
    public partial class Loja : Form
    {
        Itens item;
        Personagem personagem;
        MessageBox message;
        public Loja(Personagem personagem)
        {
            this.personagem = personagem;
            InitializeComponent();
            string[] dir = Directory.GetFiles(@"C:\Users\Mateus.Storalli\Downloads\Jogo\Itens");
            Random random = new Random();
            int acrescentatop = 0;
            LoadOrSave load = new LoadOrSave();
            for (int i = 0; i < 4; i++)
            {
                item = load.ReadFromJsonFile<Itens>(dir[random.Next(0, dir.Length)]);
                Image image = Image.FromFile(item.url);
                PictureBox pic = new PictureBox();
                Label label = new Label();
                pic.Image = image;
                pic.Name = item.nome;
                pic.Height = 29;
                pic.Width = 30;
                pic.BackColor = Color.Transparent;
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                pic.BorderStyle = BorderStyle.FixedSingle;
                label.Width = 40;
                label.Height = 20;
                label.BackColor = Color.Transparent;
                label.Text = item.Gold1.ToString();
                
                System.Drawing.Font font = new Font("Britannic Bold", 11.25F);
                label.Font = font;
                label.ForeColor = Color.Gold;
                if(i < 2)
                {
                    label.Top = 70 + acrescentatop;
                    label.Left = 176;
                    pic.Top = 86 + acrescentatop;
                    pic.Left = 176;
                    if(i==0)
                        acrescentatop = acrescentatop+ 61;
                }
                else
                {
                    label.Top = 70 + acrescentatop;
                    pic.Top = 86 + acrescentatop;
                    label.Left = 231;
                    pic.Left = 231;
                    acrescentatop = acrescentatop - 61;
                }
                Controls.Add(label);
                this.Controls.Add(pic);
                pic.Click += Pic_Click; ;
                pic.MouseHover += Pic_MouseHover;
                pic.MouseLeave += Pic_MouseLeave;
            }
        }

        private void Pic_MouseLeave(object sender, EventArgs e)
        {
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
        }
        LoadOrSave load = new LoadOrSave();
        private void Pic_MouseHover(object sender, EventArgs e)
        {

            PictureBox pic = sender as PictureBox;
            Itens algo = load.ReadFromJsonFile<Itens>(@"C:\Users\Mateus.Storalli\Downloads\Jogo\Itens\" + pic.Name);
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label2.Text = algo.Atk1.ToString();
            label3.Text = algo.Def1.ToString();
            label4.Text = algo.Vida1.ToString();
            label5.Text = algo.VidaMaxima1.ToString();
            label6.Text = algo.ChanceCritico2.ToString();
        }

        private void Pic_Click(object sender, EventArgs e)
        {
            LoadOrSave Load = new LoadOrSave();
            PictureBox pic = sender as PictureBox;
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            Itens algo = Load.ReadFromJsonFile<Itens>(@"C:\Users\Mateus.Storalli\Downloads\Jogo\Itens\" + pic.Name);

            DialogResult result;
            result = MessageBox.Show( "Ataque: "+ algo.Atk1 
                + "\n " + "Defesa: " + algo.Def1 
                + "\n ChanceCritico: "+ algo.ChanceCritico2 
                + "\n Vida:" + algo.Vida1 
                + "\n LVL: " + algo.Lvl1
                + "\n comprar este item?",algo.nome,buttons);
            if(result == DialogResult.Yes)
                personagem.ComprarItem(algo);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            personagem.ComprarItem(item);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Close();
        }
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
           Thread thread = new Thread(OpenNewForm);
           thread.Start();
        }
        public void OpenNewForm(object form)
        {
            Application.Run(new Form2(personagem));
            GC.Collect();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
