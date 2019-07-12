using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    [Serializable]
    public class HealerSkills : Magias
    {   
        public int Tipo;
        public HealerSkills()
        {
            Tipo = 1;
            
        }
        public void Id(int id)
        {
            this.ID = id;
        }
        public double Heal()
        {
            return Heal();
        }

    }
}
