using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geldautomaat
{
    class Automaat
    {
        public bool InBedrijf;
        public double Opnamelimiet;
        public double VooraadLimiet;
        
        public Automaat(bool InBedrijf, double Opnamelimiet, double VooraadLimiet)
        {
            this.InBedrijf = InBedrijf;
            this.Opnamelimiet = Opnamelimiet;
            this.VooraadLimiet = VooraadLimiet;
        } 

    }
}
