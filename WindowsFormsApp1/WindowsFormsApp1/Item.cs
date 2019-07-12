using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Item:atributos
    {
        private string url;
        public string URL { get => url; set => value; }
        public double Vida1 { get => Vida; }
        public int VidaMaxima1 { get => VidaMaxima; }
        public double Atk1 { get => Atk; }
        public double Def1 { get => Def; }
        public double Lvl1 { get => Lvl; }
        public int Gold1 { get => Gold; }
        public List<Magias> Magi1 { get => magia; }
        public int ChanceCritico2 { get => ChanceCritico1; }

        public Item(ItemDTO ItemDTO)
        {
            magia = ItemDTO.Magi1;
            Vida = ItemDTO.Vida1;
            VidaMaxima = ItemDTO.VidaMaxima1;
            Atk = ItemDTO.Atk1;
            Def = ItemDTO.Def1;
            this.Lvl = Convert.ToInt32(ItemDTO.Lvl1);
            Gold = ItemDTO.Gold1;
            Magi = new Magias();
            ChanceCritico1 = ItemDTO.ChanceCritico2;

        }
    }
}
