using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    [Serializable]
    public enum tipo : byte
    {
        BracoDireito=0,
        BracoEsquerdo=1,
        Peito=2,
        Capacete=3,
        Bota=4
    }
    [Serializable]
    public class Itens : atributos
    {
        private byte tipo;
        
        
        public string url,nome;
        private string Tipo;
        public double Vida1 { get => Vida; }
        public int VidaMaxima1 { get => VidaMaxima;  }
        public double Atk1 { get => Atk; }
        public double Def1 { get => Def;  }
        public int Lvl1 { get => Lvl;  }
        public int Gold1 { get => Gold; }
        public int ChanceCritico2 { get => ChanceCritico1; }
        public string Url { get => url;  }
        public byte Tipo1 { get => tipo; }

        public Itens(double ataque, double defesa, double vida, int chanceCritico, string URL, int gold, int lvl, string nome,tipo tipo)
        {

            Vida = vida;
            Atk = ataque;
            this.nome = nome;
            Def = defesa;
            this.ChanceCritico1 = chanceCritico;
            url = URL;
            this.tipo = (byte)tipo;
            this.Lvl = lvl;
            this.Gold = gold;
            this.VidaMaxima = 0;
            this.XP1 = 0;
            this.Xpnecessaria = 0;
        }

        public Itens()
        {

        }
       
        
    }
}
