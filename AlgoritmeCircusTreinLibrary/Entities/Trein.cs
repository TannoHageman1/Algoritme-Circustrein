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
    }
}
