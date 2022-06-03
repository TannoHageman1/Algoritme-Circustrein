using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmeCircusTreinLibrary.Entities
{
    public class Wagon
    {
        private List<Dier> dieren;

        public Wagon()
        {
            dieren = new List<Dier>();
        }

        public int GetBezetheid()
        {
            int bezetheid = 0;
            foreach (Dier dier in dieren)
            {
                bezetheid += dier.Grootte;
            }
            return bezetheid;
        }
        public void AddDier(Dier dier)
        {
            dieren.Add(dier);

        }

        public List<Dier> GetDieren()
        {
            return dieren;
        }

        public bool CarnivoorCheck(Dier dier)
        {
            foreach (Dier wagonDier in GetDieren())
            {
                if (!dier.IsGroterDan(wagonDier))
                {
                    if (wagonDier.IsCarnivoor)
                    {
                        return false;
                    }
                }
                else if (dier.IsCarnivoor)
                {
                    return false;
                }
            }

            return true;
        }

        public bool PastDierInWagon(Dier dier)
        {
            return GetBezetheid() + dier.Grootte <= 10;
        }
    }
}
