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
using MongoDB.Bson;
using MongoDB.Driver;
using WindowsFormsApp1.Util;

namespace WindowsFormsApp1
{
    public partial class RinguePVPFind : Form
    {
        private Socket serverSocket;
        private Socket clientSocket; // We will only accept one socket.
        Personagem PerInimigo;
        private bool suaVez;
        private Thread mandarMouse;
        private byte[] buffer;
        MongoClient server;
        private Thread thread;
        Personagem personagem;
        IMongoDatabase database;
        Monster monster;
        bool con = false;
        // Constants
        private const string CRLF = "\r\n";
        // Fields
        private static void ShowErrorDialog(string message)
        {
            MessageBox.Show(message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void StartServer()
        {
            try
            {
                serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                serverSocket.Bind(new IPEndPoint(IPAddress.Any, 3333));
                serverSocket.Listen(10);
                serverSocket.BeginAccept(AcceptCallback, null);
            }
            catch (SocketException ex)
            {
                ShowErrorDialog(ex.Message);
            }
            catch (ObjectDisposedException ex)
            {
                ShowErrorDialog(ex.Message);
            }
        }
        //Accept The User as loged
        private void AcceptCallback(IAsyncResult AR)
        {
            try
            {
                con = true;

                clientSocket = serverSocket.EndAccept(AR);
                buffer = new byte[clientSocket.ReceiveBufferSize];


                // Send Personagem To the Enemy
                byte[] sendData = personagem.ToByteArray();

                clientSocket.BeginSend(sendData, 0, sendData.Length, SocketFlags.None, SendCallback, null);
                // Listen for client data.
                Invoke((Action)delegate
                {
                    ImageEnemy.Visible = true;
                    ProntoButton.Text = "Esperando...";
                });
                    clientSocket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, ReceiveCallback, null);
                // Continue listening for clients.
                serverSocket.BeginAccept(AcceptCallback, null);

            }
            catch (SocketException ex)
            {
                ShowErrorDialog(ex.Message);
            }
            catch (ObjectDisposedException ex)
            {
                ShowErrorDialog(ex.Message);
            }
        }

        private void SendCallback(IAsyncResult AR)
        {

            try
            {
                clientSocket.EndSend(AR);
            }
            catch (SocketException ex)
            {
                ShowErrorDialog(ex.Message);
            }
            catch (ObjectDisposedException ex)
            {
                ShowErrorDialog(ex.Message);
            }

        }
        public RinguePVPFind(Personagem personagem)
        {
            // server = new MongoClient(
            //     "mongodb+srv://mateus383:<210164>@servercluster-siuh7.mongodb.net/test?retryWrites=true&w=majority"
            //     );
            //
            // database = server.GetDatabase("test");

            InitializeComponent();
            this.personagem = personagem;
            

             Thread ac = new Thread(ab);
             ac.Start();
            StartServer();
            monster = new Monster(personagem);
            suaVida.Text = personagem.vida().ToString();
            VidaEnemy.Text = monster.vida().ToString();
        }
        [MTAThread]
        private void ab()
        {
            MouseHover += (obj, evt) =>
            {
                MouseMove += (object a, MouseEventArgs ab) =>
                {
                    if (!con)
                        return;
                    byte[] buffer = personagem.mousepvp(ab.Location.Y, ab.Location.X);
                    clientSocket.BeginSend(buffer, 0, buffer.Length, SocketFlags.None, SendCallback, null);
                };
            };
        }

        //Recebe informaçoes de volta

        private void ReceiveCallback(IAsyncResult AR)
        {
            try
            {
                int received = clientSocket.EndReceive(AR);
                if (received == 0)
                    return;
                
                var ApertouButtao = BitConverter.ToBoolean(buffer, 0);
                var atacou = BitConverter.ToBoolean(buffer, 1);
                var mouseMove = BitConverter.ToBoolean(buffer, 6);
                if (atacou)
                {
                    personagem.tomarGolpe(buffer);
                    UpdateYourControlStates();
                    MudarBotoes(true);
                }
                else
                if (!ApertouButtao && !mouseMove)
                {
                    Personagem Tmp = new Personagem(buffer);
                    PerInimigo = Tmp;
                    UpdateControlStates();
                    Tmp = null;
                }
                else
                if(mouseMove)
                {
                    int top = BitConverter.ToInt32(buffer, 7);
                    int left = BitConverter.ToInt32(buffer, 11);
                    Thread mouse = new Thread(ReceiveMoveMouse);
                    Point mousevetor = new Point(left, top);
                    mouse.Start(mousevetor);
                }
                if(ApertouButtao)
                {
                    Invoke(
                        (Action)delegate
                        {
                            ProntoButton.Text = "Start";
                            ProntoButton.Enabled = true;
                        });
                }
                // Start receiving data again.
                // Esperando por mais recebimentos de dados
                clientSocket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, ReceiveCallback, null);
            }
            // Avoid Pokemon exception handling in cases like these.
            catch (SocketException ex)
            {
                ShowErrorDialog(ex.Message);
            }
            catch (ObjectDisposedException ex)
            {
                ShowErrorDialog(ex.Message);
            }
        }
        [STAThread]
        private void ReceiveMoveMouse(object novo)
        {
            Invoke((Action)delegate
            {
                mouse.Location = (Point)novo;
            });
        }
        
        private void UpdateYourControlStates()
        {
            Invoke((Action)delegate
            {
                suaVida.Text = personagem.Vida1.ToString() + " / " + personagem.VidaMaxima1.ToString();
            });
            byte[] sendData = personagem.ToByteArray();
            clientSocket.BeginSend(sendData, 0, sendData.Length, SocketFlags.None, SendCallback, null);
        }

        private void UpdateControlStates()
        {
            Invoke((Action)delegate
            {
                VidaEnemy.Text = PerInimigo.Vida1.ToString() + " / " + PerInimigo.VidaMaxima1.ToString();
                NameEnemy.Text = PerInimigo.nome;
                Lvl.Text = PerInimigo.Lvl1.ToString();
            });
        }
        
      
        private void button1_Click(object sender, EventArgs e)
        {

            byte[] buffer = personagem.atacarPVP();
            clientSocket.BeginSend(buffer, 0, buffer.Length, SocketFlags.None, SendCallback, null);
            MudarBotoes(false);
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
            suaVida.Text = sender.ToString();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            
            
        }
        private void btnExit_Click(object sender, FormClosedEventArgs e)
        {
            
        }
    
        
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

        private void button5_Click(object sender, EventArgs e)
        {
           

     

        }
        private void MudarBotoes(bool Status)
        {
            Invoke(
              (Action)delegate
              {
                  ATKButton.Enabled = Status;
                  FugirButton.Enabled = Status;
                  ItemButton.Enabled = Status;
                  SkillButton.Enabled = Status;
              });
        }
        private void prontoButton(object sender, EventArgs e)
        {
            try
            {
                    byte[] buffer = BitConverter.GetBytes(true);
                    clientSocket.BeginSend(buffer, 0, buffer.Length, SocketFlags.None, SendCallback, null);
                    Invoke(
                        (Action)delegate
                        {
                            ProntoButton.Enabled = false;
                            ProntoButton.Visible = false;
                            MudarBotoes(true);
                            suaVez = true;
                        });
            }
            catch (SocketException ex)
            {
                ShowErrorDialog(ex.Message);
            }
            catch (ObjectDisposedException ex)
            {
                ShowErrorDialog(ex.Message);
            }
        }
    }
    
}
