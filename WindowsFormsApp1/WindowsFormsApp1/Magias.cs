using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    [Serializable]
    public class Magias
    {
        private String Atributo;
        private double multiplicador;
        public int tipo;
        protected int ID;
        public string nome;
        public Magias()
        {
            tipo = 0;
        }
        public int getID()
        {
            return ID;
        }
        public double ataque()
        {
            return 50;
        }
        public double Heal()
        {
            return 50;
        }
        public double Debuff()
        {
            return -2;
        }
        public double UsarMagia(int id)
        {

            switch (id)
            {
                case (1):
                    return Heal();
                    
                case (2):
                    return Debuff();
                    
                default:
                    return 0;
            }
        }
    }
}
