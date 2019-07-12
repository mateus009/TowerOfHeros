using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    [Serializable]
    public class atributos
    {
        private int xpnecessaria = 1500;
        private int ChanceCritico = 0;
        private double vida, atk, def;
        private int lvl, gold, DIETIME, XP;
        private int vidaMaxima;
        private List<Magias> magias;
        private Magias magi;

        protected int ChanceCritico1 { get => ChanceCritico; set => ChanceCritico = value; }
        protected  Magias Magi { get => magi; set => magi = value; }
        protected int VidaMaxima { get => vidaMaxima; set => vidaMaxima = value; }
        protected int Xpnecessaria { get => xpnecessaria; set => xpnecessaria = value; }
        protected List<Magias> magia { get => magias; set => magias = value; }
        protected double Vida { get => vida; set => vida = value; }
        protected double Atk { get => atk; set => atk = value; }
        protected double Def { get => def; set => def = value; }
        protected int Lvl { get => lvl; set => lvl = value; }
        protected int Gold { get => gold; set => gold = value; }
        protected int DIETIME1 { get => DIETIME; set => DIETIME = value; }
        protected int XP1 { get => XP; set => XP = value; }
        
    }
}
