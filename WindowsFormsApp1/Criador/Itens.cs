using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Criador
{
    [Serializable]
    public class Itens : Atributos
    {
        public string url;
        public string nome;
        public double Vida1 { get => Vida; set => Vida = value; }
        public int VidaMaxima1 { get => VidaMaxima; set => VidaMaxima = value; }
        public double Atk1 { get => Atk; set => Atk = value; }
        public double Def1 { get => Def; set => Def = value; }
        public int Lvl1 { get => Lvl; }
        public int Gold1 { get => Gold; }
        public int ChanceCritico2 { get => ChanceCritico1; set => ChanceCritico1 = value; }
        public string Url { get => url; set => url = value; }

        public Itens()
        {
            
        }
        public Itens(double ataque,double defesa,double vida,int chanceCritico, string URL,int gold,int lvl,string nome)
        {
            this.nome = nome;
            Vida = vida;
            Atk = ataque;
            Def = defesa;
            this.ChanceCritico1= chanceCritico;
            url = URL;
            this.Lvl = lvl;
            this.Gold = gold;
            this.VidaMaxima = 0;
            this.XP1 = 0;
            this.Xpnecessaria = 0; 
        }
    }
}
