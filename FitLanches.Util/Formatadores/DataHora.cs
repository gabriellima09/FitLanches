using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitLanches.Util.Formatadores
{
    public static class DataHora
    {
        public static string ConverterTempo(this int value)
        {
            int hora = (value / (60 * 60));
            int min = ((value - (hora * 60 * 60)) / 60);
            int seg = (value - (hora * 60 * 60) - (min * 60));

            return string.Concat(
                hora > 0 ? hora.ToString() + "h " : string.Empty,
                min > 0 ? min.ToString() + "min " : string.Empty,
                seg > 0 ? seg.ToString() + "seg" : string.Empty
                );
        }
    }
}
