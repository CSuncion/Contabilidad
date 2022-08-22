using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades.Adicionales;

namespace Entidades
{
    public class SaldoBancoEN
    {

        #region Nombre Campos

        public const string ClaObj = "ClaveObjeto";
        public const string ClaSalBan = "ClaveSaldoBanco";
        public const string CodEmp = "CodigoEmpresa";
        public const string NomEmp = "NombreEmpresa";
        public const string AñoSalBan = "AñoSaldoBanco";
        public const string CodCueBan = "CodigoCuentaBanco";
        public const string DesCueBan = "DescripcionCuentaBanco";
        public const string NumCueBan = "NumeroCuentaBanco";
        public const string CMon = "CMoneda";
        public const string NMon = "NMoneda";
        public const string IngSol00 = "IngresoSol00";
        public const string SalSol00 = "SalidaSol00";
        public const string SaldSol00 = "SaldoSol00";
        public const string IngSol01 = "IngresoSol01";
        public const string SalSol01 = "SalidaSol01";
        public const string SaldSol01 = "SaldoSol01";
        public const string IngSol02 = "IngresoSol02";
        public const string SalSol02 = "SalidaSol02";
        public const string SaldSol02 = "SaldoSol02";
        public const string IngSol03 = "IngresoSol03";
        public const string SalSol03 = "SalidaSol03";
        public const string SaldSol03 = "SaldoSol03";
        public const string IngSol04 = "IngresoSol04";
        public const string SalSol04 = "SalidaSol04";
        public const string SaldSol04 = "SaldoSol04";
        public const string IngSol05 = "IngresoSol05";
        public const string SalSol05 = "SalidaSol05";
        public const string SaldSol05 = "SaldoSol05";
        public const string IngSol06 = "IngresoSol06";
        public const string SalSol06 = "SalidaSol06";
        public const string SaldSol06 = "SaldoSol06";
        public const string IngSol07 = "IngresoSol07";
        public const string SalSol07 = "SalidaSol07";
        public const string SaldSol07 = "SaldoSol07";
        public const string IngSol08 = "IngresoSol08";
        public const string SalSol08 = "SalidaSol08";
        public const string SaldSol08 = "SaldoSol08";
        public const string IngSol09 = "IngresoSol09";
        public const string SalSol09 = "SalidaSol09";
        public const string SaldSol09 = "SaldoSol09";
        public const string IngSol10 = "IngresoSol10";
        public const string SalSol10 = "SalidaSol10";
        public const string SaldSol10 = "SaldoSol10";
        public const string IngSol11 = "IngresoSol11";
        public const string SalSol11 = "SalidaSol11";
        public const string SaldSol11 = "SaldoSol11";
        public const string IngSol12 = "IngresoSol12";
        public const string SalSol12 = "SalidaSol12";
        public const string SaldSol12 = "SaldoSol12";
        public const string IngDol00 = "IngresoDol00";
        public const string SalDol00 = "SalidaDol00";
        public const string SaldDol00 = "SaldoDol00";
        public const string IngDol01 = "IngresoDol01";
        public const string SalDol01 = "SalidaDol01";
        public const string SaldDol01 = "SaldoDol01";
        public const string IngDol02 = "IngresoDol02";
        public const string SalDol02 = "SalidaDol02";
        public const string SaldDol02 = "SaldoDol02";
        public const string IngDol03 = "IngresoDol03";
        public const string SalDol03 = "SalidaDol03";
        public const string SaldDol03 = "SaldoDol03";
        public const string IngDol04 = "IngresoDol04";
        public const string SalDol04 = "SalidaDol04";
        public const string SaldDol04 = "SaldoDol04";
        public const string IngDol05 = "IngresoDol05";
        public const string SalDol05 = "SalidaDol05";
        public const string SaldDol05 = "SaldoDol05";
        public const string IngDol06 = "IngresoDol06";
        public const string SalDol06 = "SalidaDol06";
        public const string SaldDol06 = "SaldoDol06";
        public const string IngDol07 = "IngresoDol07";
        public const string SalDol07 = "SalidaDol07";
        public const string SaldDol07 = "SaldoDol07";
        public const string IngDol08 = "IngresoDol08";
        public const string SalDol08 = "SalidaDol08";
        public const string SaldDol08 = "SaldoDol08";
        public const string IngDol09 = "IngresoDol09";
        public const string SalDol09 = "SalidaDol09";
        public const string SaldDol09 = "SaldoDol09";
        public const string IngDol10 = "IngresoDol10";
        public const string SalDol10 = "SalidaDol10";
        public const string SaldDol10 = "SaldoDol10";
        public const string IngDol11 = "IngresoDol11";
        public const string SalDol11 = "SalidaDol11";
        public const string SaldDol11 = "SaldoDol11";
        public const string IngDol12 = "IngresoDol12";
        public const string SalDol12 = "SalidaDol12";
        public const string SaldDol12 = "SaldoDol12";
        public const string UsuAgr = "UsuarioAgrega";
        public const string FecAgr = "FechaAgrega";
        public const string UsuMod = "UsuarioModifica";
        public const string FecMod = "FechaModifica";

        #endregion

        #region Atributos

        private string _ClaveObjeto = string.Empty;
        private string _ClaveSaldoBanco = string.Empty;
        private string _CodigoEmpresa = string.Empty;
        private string _NombreEmpresa = string.Empty;
        private string _AñoSaldoBanco = string.Empty;
        private string _CodigoCuentaBanco = string.Empty;
        private string _DescripcionCuentaBanco = string.Empty;
        private string _NumeroCuentaBanco = string.Empty;
        private string _CMoneda = string.Empty;
        private string _NMoneda = string.Empty;
        private decimal _IngresoSol00 = 0;
        private decimal _SalidaSol00 = 0;
        private decimal _SaldoSol00 = 0;
        private decimal _IngresoSol01 = 0;
        private decimal _SalidaSol01 = 0;
        private decimal _SaldoSol01 = 0;
        private decimal _IngresoSol02 = 0;
        private decimal _SalidaSol02 = 0;
        private decimal _SaldoSol02 = 0;
        private decimal _IngresoSol03 = 0;
        private decimal _SalidaSol03 = 0;
        private decimal _SaldoSol03 = 0;
        private decimal _IngresoSol04 = 0;
        private decimal _SalidaSol04 = 0;
        private decimal _SaldoSol04 = 0;
        private decimal _IngresoSol05 = 0;
        private decimal _SalidaSol05 = 0;
        private decimal _SaldoSol05 = 0;
        private decimal _IngresoSol06 = 0;
        private decimal _SalidaSol06 = 0;
        private decimal _SaldoSol06 = 0;
        private decimal _IngresoSol07 = 0;
        private decimal _SalidaSol07 = 0;
        private decimal _SaldoSol07 = 0;
        private decimal _IngresoSol08 = 0;
        private decimal _SalidaSol08 = 0;
        private decimal _SaldoSol08 = 0;
        private decimal _IngresoSol09 = 0;
        private decimal _SalidaSol09 = 0;
        private decimal _SaldoSol09 = 0;
        private decimal _IngresoSol10 = 0;
        private decimal _SalidaSol10 = 0;
        private decimal _SaldoSol10 = 0;
        private decimal _IngresoSol11 = 0;
        private decimal _SalidaSol11 = 0;
        private decimal _SaldoSol11 = 0;
        private decimal _IngresoSol12 = 0;
        private decimal _SalidaSol12 = 0;
        private decimal _SaldoSol12 = 0;
        private decimal _IngresoDol00 = 0;
        private decimal _SalidaDol00 = 0;
        private decimal _SaldoDol00 = 0;
        private decimal _IngresoDol01 = 0;
        private decimal _SalidaDol01 = 0;
        private decimal _SaldoDol01 = 0;
        private decimal _IngresoDol02 = 0;
        private decimal _SalidaDol02 = 0;
        private decimal _SaldoDol02 = 0;
        private decimal _IngresoDol03 = 0;
        private decimal _SalidaDol03 = 0;
        private decimal _SaldoDol03 = 0;
        private decimal _IngresoDol04 = 0;
        private decimal _SalidaDol04 = 0;
        private decimal _SaldoDol04 = 0;
        private decimal _IngresoDol05 = 0;
        private decimal _SalidaDol05 = 0;
        private decimal _SaldoDol05 = 0;
        private decimal _IngresoDol06 = 0;
        private decimal _SalidaDol06 = 0;
        private decimal _SaldoDol06 = 0;
        private decimal _IngresoDol07 = 0;
        private decimal _SalidaDol07 = 0;
        private decimal _SaldoDol07 = 0;
        private decimal _IngresoDol08 = 0;
        private decimal _SalidaDol08 = 0;
        private decimal _SaldoDol08 = 0;
        private decimal _IngresoDol09 = 0;
        private decimal _SalidaDol09 = 0;
        private decimal _SaldoDol09 = 0;
        private decimal _IngresoDol10 = 0;
        private decimal _SalidaDol10 = 0;
        private decimal _SaldoDol10 = 0;
        private decimal _IngresoDol11 = 0;
        private decimal _SalidaDol11 = 0;
        private decimal _SaldoDol11 = 0;
        private decimal _IngresoDol12 = 0;
        private decimal _SalidaDol12 = 0;
        private decimal _SaldoDol12 = 0;
        private string _UsuarioAgrega = string.Empty;
        private DateTime _FechaAgrega = DateTime.Now;
        private string _UsuarioModifica = string.Empty;
        private DateTime _FechaModifica = DateTime.Now;
        private Adicional _Adicionales = new Adicional();

        #endregion

        #region Propiedades

        public string ClaveObjeto
        {
            get { return this._ClaveObjeto; }
            set { this._ClaveObjeto = value; }
        }

        public string ClaveSaldoBanco
        {
            get { return this._ClaveSaldoBanco; }
            set { this._ClaveSaldoBanco = value; }
        }

        public string CodigoEmpresa
        {
            get { return this._CodigoEmpresa; }
            set { this._CodigoEmpresa = value; }
        }

        public string NombreEmpresa
        {
            get { return this._NombreEmpresa; }
            set { this._NombreEmpresa = value; }
        }

        public string AñoSaldoBanco
        {
            get { return this._AñoSaldoBanco; }
            set { this._AñoSaldoBanco = value; }
        }

        public string CodigoCuentaBanco
        {
            get { return this._CodigoCuentaBanco; }
            set { this._CodigoCuentaBanco = value; }
        }

        public string DescripcionCuentaBanco
        {
            get { return this._DescripcionCuentaBanco; }
            set { this._DescripcionCuentaBanco = value; }
        }

        public string NumeroCuentaBanco
        {
            get { return this._NumeroCuentaBanco; }
            set { this._NumeroCuentaBanco = value; }
        }

        public string CMoneda
        {
            get { return this._CMoneda; }
            set { this._CMoneda = value; }
        }

        public string NMoneda
        {
            get { return this._NMoneda; }
            set { this._NMoneda = value; }
        }

        public decimal IngresoSol00
        {
            get { return this._IngresoSol00; }
            set { this._IngresoSol00 = value; }
        }

        public decimal SalidaSol00
        {
            get { return this._SalidaSol00; }
            set { this._SalidaSol00 = value; }
        }

        public decimal SaldoSol00
        {
            get { return this._SaldoSol00; }
            set { this._SaldoSol00 = value; }
        }

        public decimal IngresoSol01
        {
            get { return this._IngresoSol01; }
            set { this._IngresoSol01 = value; }
        }

        public decimal SalidaSol01
        {
            get { return this._SalidaSol01; }
            set { this._SalidaSol01 = value; }
        }

        public decimal SaldoSol01
        {
            get { return this._SaldoSol01; }
            set { this._SaldoSol01 = value; }
        }

        public decimal IngresoSol02
        {
            get { return this._IngresoSol02; }
            set { this._IngresoSol02 = value; }
        }

        public decimal SalidaSol02
        {
            get { return this._SalidaSol02; }
            set { this._SalidaSol02 = value; }
        }

        public decimal SaldoSol02
        {
            get { return this._SaldoSol02; }
            set { this._SaldoSol02 = value; }
        }

        public decimal IngresoSol03
        {
            get { return this._IngresoSol03; }
            set { this._IngresoSol03 = value; }
        }

        public decimal SalidaSol03
        {
            get { return this._SalidaSol03; }
            set { this._SalidaSol03 = value; }
        }

        public decimal SaldoSol03
        {
            get { return this._SaldoSol03; }
            set { this._SaldoSol03 = value; }
        }

        public decimal IngresoSol04
        {
            get { return this._IngresoSol04; }
            set { this._IngresoSol04 = value; }
        }

        public decimal SalidaSol04
        {
            get { return this._SalidaSol04; }
            set { this._SalidaSol04 = value; }
        }

        public decimal SaldoSol04
        {
            get { return this._SaldoSol04; }
            set { this._SaldoSol04 = value; }
        }

        public decimal IngresoSol05
        {
            get { return this._IngresoSol05; }
            set { this._IngresoSol05 = value; }
        }

        public decimal SalidaSol05
        {
            get { return this._SalidaSol05; }
            set { this._SalidaSol05 = value; }
        }

        public decimal SaldoSol05
        {
            get { return this._SaldoSol05; }
            set { this._SaldoSol05 = value; }
        }

        public decimal IngresoSol06
        {
            get { return this._IngresoSol06; }
            set { this._IngresoSol06 = value; }
        }

        public decimal SalidaSol06
        {
            get { return this._SalidaSol06; }
            set { this._SalidaSol06 = value; }
        }

        public decimal SaldoSol06
        {
            get { return this._SaldoSol06; }
            set { this._SaldoSol06 = value; }
        }

        public decimal IngresoSol07
        {
            get { return this._IngresoSol07; }
            set { this._IngresoSol07 = value; }
        }

        public decimal SalidaSol07
        {
            get { return this._SalidaSol07; }
            set { this._SalidaSol07 = value; }
        }

        public decimal SaldoSol07
        {
            get { return this._SaldoSol07; }
            set { this._SaldoSol07 = value; }
        }

        public decimal IngresoSol08
        {
            get { return this._IngresoSol08; }
            set { this._IngresoSol08 = value; }
        }

        public decimal SalidaSol08
        {
            get { return this._SalidaSol08; }
            set { this._SalidaSol08 = value; }
        }

        public decimal SaldoSol08
        {
            get { return this._SaldoSol08; }
            set { this._SaldoSol08 = value; }
        }

        public decimal IngresoSol09
        {
            get { return this._IngresoSol09; }
            set { this._IngresoSol09 = value; }
        }

        public decimal SalidaSol09
        {
            get { return this._SalidaSol09; }
            set { this._SalidaSol09 = value; }
        }

        public decimal SaldoSol09
        {
            get { return this._SaldoSol09; }
            set { this._SaldoSol09 = value; }
        }

        public decimal IngresoSol10
        {
            get { return this._IngresoSol10; }
            set { this._IngresoSol10 = value; }
        }

        public decimal SalidaSol10
        {
            get { return this._SalidaSol10; }
            set { this._SalidaSol10 = value; }
        }

        public decimal SaldoSol10
        {
            get { return this._SaldoSol10; }
            set { this._SaldoSol10 = value; }
        }

        public decimal IngresoSol11
        {
            get { return this._IngresoSol11; }
            set { this._IngresoSol11 = value; }
        }

        public decimal SalidaSol11
        {
            get { return this._SalidaSol11; }
            set { this._SalidaSol11 = value; }
        }

        public decimal SaldoSol11
        {
            get { return this._SaldoSol11; }
            set { this._SaldoSol11 = value; }
        }

        public decimal IngresoSol12
        {
            get { return this._IngresoSol12; }
            set { this._IngresoSol12 = value; }
        }

        public decimal SalidaSol12
        {
            get { return this._SalidaSol12; }
            set { this._SalidaSol12 = value; }
        }

        public decimal SaldoSol12
        {
            get { return this._SaldoSol12; }
            set { this._SaldoSol12 = value; }
        }

        public decimal IngresoDol00
        {
            get { return this._IngresoDol00; }
            set { this._IngresoDol00 = value; }
        }

        public decimal SalidaDol00
        {
            get { return this._SalidaDol00; }
            set { this._SalidaDol00 = value; }
        }

        public decimal SaldoDol00
        {
            get { return this._SaldoDol00; }
            set { this._SaldoDol00 = value; }
        }

        public decimal IngresoDol01
        {
            get { return this._IngresoDol01; }
            set { this._IngresoDol01 = value; }
        }

        public decimal SalidaDol01
        {
            get { return this._SalidaDol01; }
            set { this._SalidaDol01 = value; }
        }

        public decimal SaldoDol01
        {
            get { return this._SaldoDol01; }
            set { this._SaldoDol01 = value; }
        }

        public decimal IngresoDol02
        {
            get { return this._IngresoDol02; }
            set { this._IngresoDol02 = value; }
        }

        public decimal SalidaDol02
        {
            get { return this._SalidaDol02; }
            set { this._SalidaDol02 = value; }
        }

        public decimal SaldoDol02
        {
            get { return this._SaldoDol02; }
            set { this._SaldoDol02 = value; }
        }

        public decimal IngresoDol03
        {
            get { return this._IngresoDol03; }
            set { this._IngresoDol03 = value; }
        }

        public decimal SalidaDol03
        {
            get { return this._SalidaDol03; }
            set { this._SalidaDol03 = value; }
        }

        public decimal SaldoDol03
        {
            get { return this._SaldoDol03; }
            set { this._SaldoDol03 = value; }
        }

        public decimal IngresoDol04
        {
            get { return this._IngresoDol04; }
            set { this._IngresoDol04 = value; }
        }

        public decimal SalidaDol04
        {
            get { return this._SalidaDol04; }
            set { this._SalidaDol04 = value; }
        }

        public decimal SaldoDol04
        {
            get { return this._SaldoDol04; }
            set { this._SaldoDol04 = value; }
        }

        public decimal IngresoDol05
        {
            get { return this._IngresoDol05; }
            set { this._IngresoDol05 = value; }
        }

        public decimal SalidaDol05
        {
            get { return this._SalidaDol05; }
            set { this._SalidaDol05 = value; }
        }

        public decimal SaldoDol05
        {
            get { return this._SaldoDol05; }
            set { this._SaldoDol05 = value; }
        }

        public decimal IngresoDol06
        {
            get { return this._IngresoDol06; }
            set { this._IngresoDol06 = value; }
        }

        public decimal SalidaDol06
        {
            get { return this._SalidaDol06; }
            set { this._SalidaDol06 = value; }
        }

        public decimal SaldoDol06
        {
            get { return this._SaldoDol06; }
            set { this._SaldoDol06 = value; }
        }

        public decimal IngresoDol07
        {
            get { return this._IngresoDol07; }
            set { this._IngresoDol07 = value; }
        }

        public decimal SalidaDol07
        {
            get { return this._SalidaDol07; }
            set { this._SalidaDol07 = value; }
        }

        public decimal SaldoDol07
        {
            get { return this._SaldoDol07; }
            set { this._SaldoDol07 = value; }
        }

        public decimal IngresoDol08
        {
            get { return this._IngresoDol08; }
            set { this._IngresoDol08 = value; }
        }

        public decimal SalidaDol08
        {
            get { return this._SalidaDol08; }
            set { this._SalidaDol08 = value; }
        }

        public decimal SaldoDol08
        {
            get { return this._SaldoDol08; }
            set { this._SaldoDol08 = value; }
        }

        public decimal IngresoDol09
        {
            get { return this._IngresoDol09; }
            set { this._IngresoDol09 = value; }
        }

        public decimal SalidaDol09
        {
            get { return this._SalidaDol09; }
            set { this._SalidaDol09 = value; }
        }

        public decimal SaldoDol09
        {
            get { return this._SaldoDol09; }
            set { this._SaldoDol09 = value; }
        }

        public decimal IngresoDol10
        {
            get { return this._IngresoDol10; }
            set { this._IngresoDol10 = value; }
        }

        public decimal SalidaDol10
        {
            get { return this._SalidaDol10; }
            set { this._SalidaDol10 = value; }
        }

        public decimal SaldoDol10
        {
            get { return this._SaldoDol10; }
            set { this._SaldoDol10 = value; }
        }

        public decimal IngresoDol11
        {
            get { return this._IngresoDol11; }
            set { this._IngresoDol11 = value; }
        }

        public decimal SalidaDol11
        {
            get { return this._SalidaDol11; }
            set { this._SalidaDol11 = value; }
        }

        public decimal SaldoDol11
        {
            get { return this._SaldoDol11; }
            set { this._SaldoDol11 = value; }
        }

        public decimal IngresoDol12
        {
            get { return this._IngresoDol12; }
            set { this._IngresoDol12 = value; }
        }

        public decimal SalidaDol12
        {
            get { return this._SalidaDol12; }
            set { this._SalidaDol12 = value; }
        }

        public decimal SaldoDol12
        {
            get { return this._SaldoDol12; }
            set { this._SaldoDol12 = value; }
        }

        public string UsuarioAgrega
        {
            get { return this._UsuarioAgrega; }
            set { this._UsuarioAgrega = value; }
        }

        public DateTime FechaAgrega
        {
            get { return this._FechaAgrega; }
            set { this._FechaAgrega = value; }
        }

        public string UsuarioModifica
        {
            get { return this._UsuarioModifica; }
            set { this._UsuarioModifica = value; }
        }

        public DateTime FechaModifica
        {
            get { return this._FechaModifica; }
            set { this._FechaModifica = value; }
        }

        public Adicional Adicionales
        {
            get { return this._Adicionales; }
            set { this._Adicionales = value; }
        }

        #endregion




    }
}
