using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmeCircusTreinLibrary.Entities
{
    public class Trein
    {
        public List<Wagon> WagonList { get; set; }

        public Trein()
        {
            WagonList = new List<Wagon>();
        }

        public void AddWagon()
        {
            WagonList.Add(new Wagon());

        }

        public void VulTrein(List<Dier> dieren)
        {
            List<Dier> remaining = new List<Dier>(dieren);
            AddWagon();
            foreach (Dier dier in dieren)
            {
                int index = 0;

                foreach (Wagon wagon in WagonList)
                {
                    index++;
                    bool isMogelijk = true;
                    if (!wagon.PastDierInWagon(dier))
                    {
                        if (index >= WagonList.Count)
                        {
                            VulTrein(remaining);
                            return;
                        }

                        continue;
                    }

                    if (!wagon.CarnivoorCheck(dier))
                    {
                        isMogelijk = false;
                    }

                    if (!isMogelijk)
                    {
                        if (index >= WagonList.Count)
                        {
                            VulTrein(remaining);
                            return;
                        }

                        continue;
                    }

                    wagon.AddDier(dier);
                    remaining.Remove(dier);
                    break;
                }
            }

        }
    }
}
