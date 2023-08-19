using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TipoCambioSunatEN
    {
        public string token { get; set; }
        public bool success { get; set; }
        public string fecha { get; set; }
        public string moneda { get; set; }
        public decimal precio_compra { get; set; }
        public decimal precio_venta { get; set; }
    }
}
