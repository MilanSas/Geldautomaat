using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geldautomaat
{
    class Rekening
    {
        public double Saldo;
        public double kredietlimiet;


        public Rekening(double Saldo, double kredietlimiet)
        {
            this.Saldo = Saldo;
            this.kredietlimiet = kredietlimiet;
        }
    }
}
