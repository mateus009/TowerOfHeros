using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    [Serializable]
    public class PersonagemDTO: atributos
    {
       public int ChanceCritico2;
        public Magias Magi;
        public int VidaMaxima1;
        public int Xpnecessaria;
        public List<Magias> Magi1;
        public double Vida1;
        public double Atk1;
        public double Def1;
        public double Lvl1;
        public int Gold1;
        public int DIETIME;
        public int XP1;
        public List<Itens> itens;
        public Itens item;
        public PersonagemDTO(Personagem personagem)
        {
            magia = personagem.Magi1;
            Vida = personagem.Vida1;
            VidaMaxima = personagem.VidaMaxima1;
            Atk = personagem.Atk1;
            Def = personagem.Def1;
            this.Lvl = Convert.ToInt32(personagem.Lvl1);
            Gold = personagem.Gold1;
            DIETIME = personagem.DIETIME;
            ChanceCritico1 = personagem.ChanceCritico2;
            itens = personagem.itens1;
        }
        public PersonagemDTO()
        {

        }
    }
}
