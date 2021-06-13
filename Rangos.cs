using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace CompletarRango
{
    public class Rangos : IRangos
    {
        public List<int> CompletarRango(List<int> rango)
        {
            List<int> rangoFinal = new List<int>();

            int minNumero = rango.Min(r => r);
            int maxNumero = rango.Max(r => r);

            for (int xI = minNumero; xI <= maxNumero; xI++) {
                rangoFinal.Add(xI);
            }

            return rangoFinal;
        }
    }
}
