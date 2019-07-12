using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Criador
{
    [Serializable]
    public class Atributos
    {
        private int xpnecessaria = 1500;
        private int ChanceCritico = 0;
        private double vida, atk, def;
        private int lvl, gold, XP;
        private int vidaMaxima;
    
        protected int ChanceCritico1 { get => ChanceCritico; set => ChanceCritico = value; }
        protected int VidaMaxima { get => vidaMaxima; set => vidaMaxima = value; }
        protected int Xpnecessaria { get => xpnecessaria; set => xpnecessaria = value; }
        protected double Vida { get => vida; set => vida = value; }
        protected double Atk { get => atk; set => atk = value; }
        protected double Def { get => def; set => def = value; }
        protected int Lvl { get => lvl; set => lvl = value; }
        protected int Gold { get => gold; set => gold = value; }
        protected int XP1 { get => XP; set => XP = value; }
    }
}
