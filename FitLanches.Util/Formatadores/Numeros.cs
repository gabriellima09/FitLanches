using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitLanches.Util.Formatadores
{
    public static class Numeros
    {
        public static string ConverterMoeda(this decimal value)
        {
            return string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", value);
        }
    }
}
