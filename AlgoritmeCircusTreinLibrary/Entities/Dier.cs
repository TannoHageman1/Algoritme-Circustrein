using AlgoritmeCircusTreinLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmeCircusTreinLibrary.Entities
{
    public class Dier
    {
        public bool IsCarnivoor;
        public int Grootte;

        public Dier(bool IsCarnivoor, int Grootte)
        {
            if (Grootte < 1)
            {
                throw new DierSizeException("Dier kan niet kleiner zijn dan 1.");
            }
            else if (Grootte > 5)
            {
                throw new DierSizeException("Dier kan niet groter zijn dan 5.");
            }

            this.Grootte = Grootte;
            this.IsCarnivoor = IsCarnivoor;
        }

        public bool IsGroterDan(Dier dier)
        {
            return Grootte > dier.Grootte;
        }
    }
}
