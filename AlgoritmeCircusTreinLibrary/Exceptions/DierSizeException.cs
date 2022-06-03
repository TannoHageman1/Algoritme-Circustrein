using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmeCircusTreinLibrary.Exceptions
{
    public class DierSizeException : Exception
    {
        public string msg;

        public DierSizeException()
        {
        }

        public DierSizeException(string msg) : base(msg)
        {
            this.msg = msg;
        }
    }
}
