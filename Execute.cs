using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace CompletarRango
{
    public class Execute
    {
        readonly IRangos _rangos;
        private readonly IConfigurationRoot _config;
        public Execute(IConfigurationRoot config,
            IRangos rangos)
        {
            _rangos = rangos;
            _config = config;
        }

        public void Run(string numeros)
        {
            List<string> numerosStr = numeros.Split(",").ToList();
            List<int> numerosInt = numerosStr.Select(n => Int32.Parse(n)).ToList(); 

            var resultado = _rangos.CompletarRango(numerosInt);

            Console.WriteLine(String.Join(",", resultado));
            Console.ReadKey();
        }
    }
}
