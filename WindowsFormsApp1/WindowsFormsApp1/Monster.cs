using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Monster : Personagem
    {
        Random random = new Random();
        private double xp1;
        public Monster(Personagem personagem)
        {
            int a = random.Next(1, 3);
            //1 = tank, 2 = mage, 3 = warrior
            if(personagem.lvl() == 1)
            {
                this.Def = 2;
                this.Atk = 1;
                this.Vida = 50;
            }else if (a == 1)
            {
                this.Def = personagem.atk() * 0.5 + personagem.def() * 0.5;
                this.Vida = personagem.vidamaxima() * 1.5;
                this.Atk = personagem.atk() * 0.2 + personagem.def() * 0.2;
            }else if( a== 2)
            {
                this.Def = personagem.atk() * 0.3 + personagem.def() * 0.3;
                this.Vida = personagem.vidamaxima();
                this.Atk = personagem.atk() * 0.1 + personagem.def() * 0.1;
            }else
            {
                this.Def = personagem.atk() * 0.1 + personagem.def() * 0.1;
                this.Vida = personagem.vidamaxima() * 2.0;
                this.Atk = personagem.atk() * 1.2 + personagem.def() * 0.5;
            }
            xp1 = personagem.lvl() * 100 + (Def * 300 + Atk * 100 + VidaMaxima * 20);
        }
       
        public double Xp1 { get => xp1;}
    }
}
