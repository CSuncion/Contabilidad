using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Estructuras
{
    public class InsumoFaltante
    {

        //campos nombres
        public const string CodLin = "CodigoLinea";
        public const string CodExi = "CodigoExistencia";
        public const string DesExi = "DescripcionExistencia";
        public const string CanParTra = "CantidadParteTrabajo";
        public const string CanStoExi = "CantidadStockExistencia";
        public const string CanFal = "CantidadFaltante";

        //atributos
        private string _CodigoLinea = string.Empty;
        private string _CodigoExistencia = string.Empty;
        private string _DescripcionExistencia = string.Empty;
        private decimal _CantidadParteTrabajo = 0;
        private decimal _CantidadStockExistencia = 0;
        private decimal _CantidadFaltante = 0;

        //propiedades
        public string CodigoLinea
        {
            get { return this._CodigoLinea; }
            set { this._CodigoLinea = value; }
        }

        public string CodigoExistencia
        {
            get { return this._CodigoExistencia; }
            set { this._CodigoExistencia = value; }
        }

        public string DescripcionExistencia
        {
            get { return this._DescripcionExistencia; }
            set { this._DescripcionExistencia = value; }
        }

        public decimal CantidadParteTrabajo
        {
            get { return this._CantidadParteTrabajo; }
            set { this._CantidadParteTrabajo = value; }
        }

        public decimal CantidadStockExistencia
        {
            get { return this._CantidadStockExistencia; }
            set { this._CantidadStockExistencia = value; }
        }

        public decimal CantidadFaltante
        {
            get { return this._CantidadFaltante; }
            set { this._CantidadFaltante = value; }
        }

    }
}
