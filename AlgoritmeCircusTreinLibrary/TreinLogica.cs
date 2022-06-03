using AlgoritmeCircusTreinLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmeCircusTreinLibrary
{
    public class TreinLogica
    {
        public void VulTrein(Trein trein, List<Dier> dieren)
        {
            List<Dier> remaining = new List<Dier>(dieren);
            trein.AddWagon();
            foreach (Dier dier in dieren)
            {
                int index = 0;
                
                foreach (Wagon wagon in trein.WagonList)
                {
                    index++;
                    bool isMogelijk = true;
                    if (!wagon.PastDierInWagon(dier))
                    {
                        if (index >= trein.WagonList.Count)
                        {
                            VulTrein(trein, remaining);
                            return;
                        }

                        continue;
                    }

                    if(!wagon.CarnivoorCheck(dier))
                    {
                        isMogelijk = false;
                    }

                    if (!isMogelijk)
                    {
                        if (index >= trein.WagonList.Count)
                        {
                            VulTrein(trein, remaining);
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
