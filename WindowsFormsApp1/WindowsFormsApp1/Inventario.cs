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
    public partial class Inventario : Form
    {
        Personagem personagem;
        List<Itens> itens;
        enum armor :short
        {
            Height = 50,
            Width = 60,
            Top = 84,
            Left = 219
        }
        enum bota : short
        {
            Height = 50,
            Width = 60,
            Top = 204,
            Left = 223
        }
        enum capacete : short
        {
            Height = 50,
            Width = 60,
            Top = 26,
            Left = 219
        }
       enum bracoesquerdo:short
       {
           Height = 50,
           Width = 60,
           Top = 146,
           Left = 184
       }
        enum bracodireito:short
        {

            Height = 50,
            Width = 60,
            Top = 146,
            Left = 258
        }
        public Inventario(Personagem personagem)
        {
            InitializeComponent();  
            this.personagem = personagem;
            Ataque.Text = personagem.Atk1.ToString();
            Defesa.Text = personagem.Def1.ToString();
            VidaeVidaMaxima.Text = personagem.Vida1.ToString() + " / " + personagem.VidaMaxima1.ToString();
            Critical.Text = personagem.ChanceCritico2.ToString();
            itens = personagem.itens1;
            if (personagem.MaoDireita1)
                  addPictureBox((short)bracodireito.Top, (short)bracodireito.Left,
                      (short)bracodireito.Height, (short)bracodireito.Width, 
                      personagem.MaoDireitaEquipe1.url);

            if (personagem.MaoEsquerda1)
                addPictureBox((short)bracoesquerdo.Top, (short)bracoesquerdo.Left,
                    (short)bracoesquerdo.Height,(short)bracoesquerdo.Width, 
                    personagem.MaoEsquerdaEquipe1.url);

            if (personagem.Capacete1)
                addPictureBox((short)capacete.Top, (short)capacete.Left, 
                    (short)capacete.Height, (short)capacete.Width, 
                    personagem.CapaceteEquipe1.url);
         
            if (personagem.Bota1)
                addPictureBox((short)bota.Top, (short)bota.Left, 
                    (short)bota.Height, (short)bota.Width, 
                    personagem.BotaEquipe1.url);

            if (personagem.Armadura1)
                addPictureBox((short)armor.Top, (short)armor.Left, 
                    (short)armor.Height, (short)armor.Width, 
                    personagem.ArmaduraEquipe1.url);
           

            int acrescentatop = 0;
            int acrescentaleft = 0;
            int i = 0;
            foreach (Itens item in itens)
            {
                Image image = Image.FromFile(item.url);
                PictureBox pic = new PictureBox();
                Label label = new Label();
                pic.Image = image;
                pic.Name = item.nome;
                pic.Height = 41;
                pic.Width = 41;
                pic.BackColor = (Color)new ColorConverter().ConvertFromInvariantString("#858ba1");
                pic.BorderStyle = BorderStyle.FixedSingle;
                pic.Cursor = Cursors.Hand;
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                label.Width = 41;
                label.Height = 41;
                label.BackColor = (Color)new ColorConverter().ConvertFromInvariantString("#858ba1");
                label.Text = item.Gold1.ToString();
                Font font = new Font("Britannic Bold", 11.25F);
                label.Font = font;
                label.ForeColor = Color.Gold;
                label.Top = 118 + acrescentatop;
                label.Left = 529;
                pic.Top = 48 + acrescentatop;
                pic.Left = 389 + acrescentaleft;
                acrescentaleft = acrescentaleft + 41;
                if (acrescentaleft >= 410)
                {
                    
                    acrescentatop = acrescentatop + 41;
                    acrescentaleft = 41;
                    pic.Left = 389;
                    pic.Top = 48 + acrescentatop;
                }
                Controls.Add(label);
                this.Controls.Add(pic);
                pic.DoubleClick += (sender, EventArgs) =>
                {
                    Pic_DoubleClick(sender, EventArgs, item);
                };
                pic.BringToFront();

                i++;
                if (i == 36)
                    break;
            }
             while (i < 36)
            {
                PictureBox picVazia = new PictureBox();

                
                picVazia.Top = 48 + acrescentatop;
                picVazia.Left = 389 + acrescentaleft;
                picVazia.Height = 41;
                picVazia.Width = 41;
                picVazia.BackColor = (Color)new ColorConverter().ConvertFromInvariantString("#858ba1");
                picVazia.SizeMode = PictureBoxSizeMode.StretchImage;
                picVazia.BorderStyle = BorderStyle.FixedSingle;
                picVazia.Cursor = Cursors.Hand;
                acrescentaleft = acrescentaleft + 41;
                if (acrescentaleft >= 410)
                {
                    acrescentatop = acrescentatop + 41;
                    acrescentaleft = 41;
                    picVazia.Left = 389;
                    picVazia.Top = 48 + acrescentatop;
                    
                }
                Controls.Add(picVazia);
                picVazia.BringToFront();
                i++;
             }
        }

        private void Pic_DoubleClick(object sender, EventArgs e, Itens item)
        {
            PictureBox pic = (PictureBox) sender;
            Substituto(pic.Top, pic.Left,pic.Height,pic.Width ,pic.BackColor);

            if (item.Tipo1 == (byte)tipo.BracoEsquerdo)
            {
                personagem.Equipar(item);
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                pic.BorderStyle = BorderStyle.FixedSingle;
                pic.BackColor = Color.Transparent;
                pic.Height = 50;
                pic.Width = 60;
                pic.Top = 146;
                pic.Left = 184;
                Controls.Add(pic);
                pic.BringToFront();
            }else if(item.Tipo1 == (byte)tipo.BracoDireito)
            {
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                pic.BorderStyle = BorderStyle.FixedSingle;
                pic.BackColor = Color.Transparent;
                personagem.Equipar(item);
                pic.Height = 50;
                pic.Width = 60;
                pic.Top = 146;
                pic.Left = 258;
                Controls.Add(pic);
                pic.BringToFront();
            }else if(item.Tipo1 == (byte)tipo.Peito)
            {
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                pic.BorderStyle = BorderStyle.FixedSingle;
                pic.BackColor = Color.Transparent;
                personagem.Equipar(item);
                pic.Height = 50;
                pic.Width = 60;
                pic.Top = 84;
                pic.Left = 219;
                Controls.Add(pic);
                pic.BringToFront();
            }else if(item.Tipo1 == (byte)tipo.Capacete)
            {
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                pic.BorderStyle = BorderStyle.FixedSingle;
                pic.BackColor = Color.Transparent;
                personagem.Equipar(item);
                pic.Height = 50;
                pic.Width = 60;
                pic.Top = 26;
                pic.Left = 219;
                Controls.Add(pic);
                pic.BringToFront();
            }else if(item.Tipo1 == (byte)tipo.Bota)
            {
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                pic.BorderStyle = BorderStyle.FixedSingle;
                pic.BackColor = Color.Transparent;
                personagem.Equipar(item);
                pic.Height = 50;
                pic.Width = 60;
                pic.Top = 204;
                pic.Left = 223;
                Controls.Add(pic);
                pic.BringToFront();
            }
        }
        public void addPictureBox(short top, short left, short height, short width, string url)
        {
            PictureBox pic = new PictureBox();
            pic.SizeMode = PictureBoxSizeMode.StretchImage;
            pic.BorderStyle = BorderStyle.FixedSingle;
            pic.Top = top;
            pic.Left = left;
            pic.Height = height;
            pic.Width = width;
            pic.Image = Image.FromFile(url);
            Controls.Add(pic);
            pic.BringToFront();

        }
        public void Substituto(int top,int left,int heig,int widt, Color color)
        {
            PictureBox picVazia = new PictureBox();
            picVazia.Image = null;
            picVazia.Top = top;
            picVazia.Left = left;
            picVazia.Height = heig;
            picVazia.Width = widt;
            picVazia.BackColor = color;
            Controls.Add(picVazia);
            picVazia.BringToFront();

        }


        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Close();
            new Thread(OpenNewForm).Start();
        }
        private void OpenNewForm(object obj)
        {
            Application.Run(new Form2(personagem));
            GC.Collect();

        }
    }
}
