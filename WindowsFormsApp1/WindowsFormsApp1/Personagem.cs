using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    [Serializable]
    public class Personagem : atributos
    {
        public int DIETIME;
        private Itens item;
        private Boolean MaoEsquerda = false;
        private Boolean MaoDireita = false;
        private Boolean Armadura = false;
        private Boolean Capacete = false;
        private Boolean Bota = false;
        private Itens MaoDireitaEquipe;
        private Itens MaoEsquerdaEquipe;
        private Itens ArmaduraEquipe;
        private Itens CapaceteEquipe;
        private Itens BotaEquipe;
        private String Nome;

        private List<Itens> itens;
        public double Vida1 { get => Vida;}
        public int VidaMaxima1 { get => VidaMaxima; }
        public string nome { get => Nome; set => Nome = value; }
        public double Atk1 { get => Atk; }
        public double Def1 { get => Def; }
        public double Lvl1 { get => Lvl; }
        public int Gold1 { get => Gold; }
        public List<Magias> Magi1 { get => magia; }
        public List<Itens> itens1 { get => this.itens; }
        public  int ChanceCritico2 { get => ChanceCritico1; }
        public bool MaoEsquerda1 { get => MaoEsquerda; }
        public bool MaoDireita1 { get => MaoDireita; }
        public bool Armadura1 { get => Armadura; }
        public bool Capacete1 { get => Capacete; }
        public bool Bota1 { get => Bota; }
        public Itens MaoDireitaEquipe1 { get => MaoDireitaEquipe; }
        public Itens MaoEsquerdaEquipe1 { get => MaoEsquerdaEquipe; }
        public Itens ArmaduraEquipe1 { get => ArmaduraEquipe;  }
        public Itens CapaceteEquipe1 { get => CapaceteEquipe;}
        public Itens BotaEquipe1 { get => BotaEquipe; }

        public Personagem(byte[] data)
        {
            //começamos pelo 1 por causa do bit do boolean
            Vida = BitConverter.ToDouble(data, 6);
            VidaMaxima = BitConverter.ToInt32(data, 14);
            Lvl = BitConverter.ToInt32(data, 18);
            int NomeTamanho = BitConverter.ToInt32(data, 22);
            nome = Encoding.ASCII.GetString(data, 26, NomeTamanho);
        }
        public byte[] ToByteArray(bool PressButon = false,bool atacou=false, int Ataque = 0, bool mouseMove = false,
            int mouseTop = 0, int MouseLeft = 0)
        {
            List<byte> ArrayByte = new List<byte>();
            ArrayByte.AddRange(BitConverter.GetBytes(PressButon));
            ArrayByte.AddRange(BitConverter.GetBytes(atacou));
            ArrayByte.AddRange(BitConverter.GetBytes(Ataque));
            if (!atacou && !mouseMove)
            {
                ArrayByte.AddRange(BitConverter.GetBytes(Vida));
                ArrayByte.AddRange(BitConverter.GetBytes(VidaMaxima));
                ArrayByte.AddRange(BitConverter.GetBytes(Lvl));
                ArrayByte.AddRange(BitConverter.GetBytes(nome.Length));
                ArrayByte.AddRange(Encoding.ASCII.GetBytes(nome));
            }
            if(mouseMove)
            {
                ArrayByte.AddRange(BitConverter.GetBytes(mouseMove));
                ArrayByte.AddRange(BitConverter.GetBytes(mouseTop));
                ArrayByte.AddRange(BitConverter.GetBytes(MouseLeft));
            }
            return ArrayByte.ToArray();
        }
        public Personagem()
        {
            itens = new List<Itens>();
            magia = new List<Magias>();
            Vida = 100;
            VidaMaxima = 100;
            Atk = 1;
            Def = 1;
            Lvl = 1;
            Gold = 0;
            DIETIME1 = 1111;
            Magi = new Magias();
            ChanceCritico1 = 1;

            
        }
        public byte[] mousepvp(int top,int left)
        {
            return ToByteArray(false,false,0,true,top,left);
        }

        public Personagem(PersonagemDTO personagemDTO)
        {
            magia = personagemDTO.Magi1;
            Vida = personagemDTO.Vida1;
            VidaMaxima = personagemDTO.VidaMaxima1;
            Atk = personagemDTO.Atk1;
            Def = personagemDTO.Def1;
            this.Lvl = Convert.ToInt32(personagemDTO.Lvl1);
            Gold = personagemDTO.Gold1;
            DIETIME = personagemDTO.DIETIME;
            Magi = new Magias();
            ChanceCritico1 = personagemDTO.ChanceCritico2;
            itens = personagemDTO.itens;
        }

      
        public int dietime()
        {
            return DIETIME1;
        }
        public double def()
        {
            return Def;
        }
        public double atk()
        {
            return Atk;
        }
        public double vida()
        {
            return Vida1;
        }
        public int lvl()
        {
            return Lvl;
        }
        public int gold()
        {
            return Gold;
        }
        public void ganharGold(int gold)
        {
            this.Gold = this.Gold + gold;
        }
        public Boolean PodeComprar(int gold)
        {
            if (this.Gold >= gold)
            {
                this.Gold = this.Gold - gold;
                return true;
            }else
                return false;
            
        }
        public void ComprarItem(Itens item)
        {
           if (PodeComprar(item.Gold1))
           {
             this.itens.Add(item);
           }
        }

        public void Equipar(Itens item)
        {
            switch (item.Tipo1)
            {
                case (4):
                   this.Bota= true;
                    BotaEquipe = item;
                    PodeEquipar(item);
                    itens.Remove(item);
                    break;
                case (0):
                    this.MaoDireita = true;
                    MaoDireitaEquipe = item;
                    PodeEquipar(item);
                    itens.Remove(item);
                    break;
                case (1):
                    this.MaoEsquerda = true;
                    MaoEsquerdaEquipe = item;
                    PodeEquipar(item);
                    itens.Remove(item);
                    break;
                case (3):
                    this.Capacete = true;
                    CapaceteEquipe = item;
                    PodeEquipar(item);
                    itens.Remove(item);
                    break;
                case (2):
                    this.Armadura = true;
                    ArmaduraEquipe = item;
                    PodeEquipar(item);
                    itens.Remove(item);
                    break;
            }
        }
        private void PodeEquipar(Itens item)
        {
            Atk = item.Atk1 + Atk1;
            Def = item.Def1 + Def;
            Vida = item.Vida1 + Vida1;
            ChanceCritico1 = item.ChanceCritico2 + ChanceCritico2;
            VidaMaxima = item.VidaMaxima1 + VidaMaxima;
            
        }
        
        public void ComprarATK(int gold)
        {
            if (PodeComprar(gold))
                this.Atk++;

        }
        public void ComprarDef(int gold)
        {
            if (PodeComprar(gold))
                this.Def++;
        }
        public double xp()
        {
            
            return XP1;
        }
        
        public double atacar()
        {
            Random random = new Random();
            int andom = random.Next(ChanceCritico1, 11);
            if (andom == 10)
              return Critico();
            return Atk;
        }
        public byte[] atacarPVP()
        {
            Random random = new Random();
            double dano = atk();
            int andom = random.Next(ChanceCritico1, 11);
            if (andom == 10) {
                dano = Critico();
            }

            return ToByteArray(false , true, (int)dano);
        }

        private double Critico()
        {
            return Atk * 2;
        }
        public double defender()
        {
            return Def * 0.5;
        }
        public void tomarGolpe(double golpe)
        {
            Vida = Vida1 - golpe;
        }
        public void tomarGolpe(byte[] data)
        {
            Vida = Vida - BitConverter.ToInt32(data, 2);
        }
        public Boolean Estado()
        {
            return Vida1 > 0;
        }
        public void upar(int xp)
        {
            this.XP1 = this.XP1 + xp;
            if (XP1 >= Xpnecessaria)
            {
                if (XP1 > Xpnecessaria)
                    this.XP1 = this.XP1 - Xpnecessaria;
                else
                    this.XP1 = 0;
                Xpnecessaria = (Lvl * Xpnecessaria) * 2;
                Lvl++;
                Atk++;
                Def++;
                VidaMaxima = VidaMaxima + 10;
                if (VidaMaxima / 2 > Vida1)
                    Vida = VidaMaxima / 2;
            }
        }
        public void ComprarMagia(HealerSkills magia)
        {
            magia = new HealerSkills();
            
            magia.nome = "tradicao";
            magia.Id(1);
            this.magia.Add(magia);
        }
        public int vidamaxima()
        {
            return VidaMaxima;
        }
        public List<Magias> ListarMagia()
        {
            return magia;
        }
        public void UsarMagia(string Id)
        {
            int tmp = Convert.ToInt32(Id);
            Vida = Vida1 + Magi.UsarMagia(tmp);
        }
        
    }
}
