using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows;
using System.Linq;
using System.Threading;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Numerics;
using CircularProgressBar;

namespace WinTeste
{

    public partial class Form1 : Form
    {

        ArrayList list;
        bool down = false;
        Rectangle circle = new Rectangle(220, 10, 150, 150);
        public Form1()
        {
           InitializeComponent();
            label6.Text = DateTime.Now.Millisecond.ToString();
            list = new ArrayList();
            Tempo.Text = "1";
            circularProgressBar1.Value = 0;
            Thread thread = new Thread(mudarTempo);
            thread.Start();
            Thread Progressbar = new Thread(Progress);
            Progressbar.Start();

            //Point a = PointToClient(PointToScreen(Location));
            //label5.Text = a.ToString();
        }
        private void Progress(object novo)
        {
            try
            {
                ProgressBarMeu bar = novo as ProgressBarMeu;
                if (bar == null || bar.Equals(null)) {
                    invokeCircularProgressBar();
                    return;
                }

                for (bar.Value = 0; bar.Value < bar.Maximum; bar.Value= bar.Value +3)
                {
                    Invoke((Action)delegate
                    {
                        label5.Text = bar.Value.ToString();
                    });
                    Thread.Sleep(100);
                }

                Invoke((Action)delegate
                {
                    bar.Dispose();
                });
                invokeCircularProgressBar();
            }
            catch
            {
                invokeCircularProgressBar();

            }
        }
        public static Image RotateImage(Image img, float rotationAngle)
        {
            //cria um bitmap imagem vazio
            Bitmap bmp = new Bitmap(img.Width, img.Height);
            //faz ele virar um grafico
            Graphics gfx = Graphics.FromImage(bmp);
            //agr nos setamos a rotacao para o centro da imagem;
            gfx.TranslateTransform((float)bmp.Width / 2, (float)bmp.Height / 2);
            //agora rotaciona a imagem
            gfx.RotateTransform(rotationAngle);
            gfx.TranslateTransform(-(float)bmp.Width / 2, -(float)bmp.Height / 2);

            //seta a modo Interpolação para a maiorqualidadePorCubo para continuar com a qualidade
            //quality image once it is transformed to the specified size
            gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;

            //agora desenha a nova imagem em um objecto grafico
            gfx.DrawImage(img, new Point(0, 0));
            //dispose o objeto grafico
            gfx.Dispose();
            return bmp;
        }
        int repetidotop;
        int repetidoleft;
        int contador = 0;
        private void invokeCircularProgressBar(ProgressBarMeu circularBar = null)
        {
            contador++;
            
            if (contador >= 6)
            {
                if (Convert.ToInt32(Pontos.Text) >= 100)
                    stado.Text = "perfect";
                else
                    stado.Text = "boa";
                Invoke((Action)delegate
                {
                    stado.Visible = true;
                    label7.Text = DateTime.Now.Millisecond.ToString();

                });
                return;
            }
           
            int[] top = new int[] { 121, 278, 182, 233, 155, 310 };
            int[] left = new int[] { 295, 311, 433, 365, 387, 400, 423, 335, 456, 478 };
            ProgressBarMeu teste = new ProgressBarMeu();
            teste.Text = string.Empty;
            teste.Click += ponto;
            if (repetidotop < 183)
                repetidotop = top[new Random().Next(4, 6)];
            else
                repetidotop = top[new Random().Next(0, 3)];

            if (repetidoleft < 387)
                repetidoleft = left[new Random().Next(5, 10)];
            else
                repetidoleft = left[new Random().Next(0, 4)];

            teste.Top = repetidotop;
            teste.Left = repetidoleft;
            teste.Width = 50;
            teste.Height = 50;
            teste.Maximum = 100;
            teste.Value = 0;
            try
            {
                Invoke((Action)delegate
                {
                    Controls.Add(teste);
                });
            }
            catch (InvalidOperationException ex) {
                Close();

            }
            catch (InvalidAsynchronousStateException ex)
            {
                Close();
            }
                Thread Progressbar = new Thread(Progress);
                Progressbar.Start(teste);
            
        }
        private void ponto(object sender, EventArgs e)
        {
            ProgressBarMeu a = sender as ProgressBarMeu;
            Invoke((Action)delegate
            {
                if (a.Value >= 93 && a.Value <= 100)
                    Pontos.Text = (30 + Convert.ToInt32(Pontos.Text)) + "";
                else
                    Pontos.Text = (3 + Convert.ToInt32(Pontos.Text)) + "";
                a.Value = a.Maximum;
                a.Dispose();
            });
        }
        

        private void mudarTempo()
        {

            Thread.Sleep(1000);
             while (false)
             { 
                Invoke((Action)delegate
                {
                    Tempo.Text = (Convert.ToInt32(Tempo.Text) + 1).ToString();
                });
                Thread.Sleep(1000);
                
                if (Tempo.Text == "20")
                    break;
             }
        }
     
        

        private void circularProgressBar1_Click(object sender, EventArgs e)
        {
            if(circularProgressBar1.Value >= 90 && circularProgressBar1.Value <= 100)
            {
                Pontos.Text = (100 + Convert.ToInt32(Pontos.Text)) + "";
            }
            else
            {
                Pontos.Text = (3 + Convert.ToInt32(Pontos.Text)) + "";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }


    class OvalPictureBox : PictureBox
    {
        private Color _borderColor;
        private int _borderWidth;
        public OvalPictureBox()
        {
            this.BackColor = Color.DarkGray;

        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            using (var gp = new GraphicsPath())
            {

                gp.AddEllipse(new Rectangle(0, 0, this.Width , this.Height));
                this.Region = new Region(gp);
            }
        }
        
        [Browsable(true)]
        public Color BorderColor
        {
            get { return _borderColor; }
            set { _borderColor = value; this.Invalidate(); }
        }
        [Browsable(true)]
        public int BorderWidth
        {
            get { return _borderWidth; }
            set { _borderWidth = value; this.Invalidate(); }
        }
       
        protected override void OnPaint(PaintEventArgs pe)
        {
         
            ClientRectangle.Inflate(-100, -100);

            ControlPaint.DrawBorder(pe.Graphics, ClientRectangle,Color.Red, ButtonBorderStyle.Solid);
            GraphicsPath graphics = new GraphicsPath();
            graphics.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
            this.Region = new System.Drawing.Region(graphics);
            base.OnPaint(pe);
            
        }   
    }
}
