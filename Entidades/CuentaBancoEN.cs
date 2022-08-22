using Entidades.Adicionales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class CuentaBancoEN
    {

        #region Nombre Campos

        public const string ClaObj = "ClaveObjeto";
        public const string ClaCueBan = "ClaveCuentaBanco";
        public const string CodEmp = "CodigoEmpresa";
        public const string NomEmp = "NombreEmpresa";
        public const string CodCueBan = "CodigoCuentaBanco";
        public const string DesCueBan = "DescripcionCuentaBanco";
        public const string CMon = "CMoneda";
        public const string NMon = "NMoneda";
        public const string CodBan = "CodigoBanco";
        public const string NomBan = "NombreBanco";
        public const string NumCueBan = "NumeroCuentaBanco";
        public const string CTip = "CTipo";
        public const string NTip = "NTipo";
        public const string SalCueBan = "SaldoCuentaBanco";
        public const string COriVenCre = "COrigenVentanaCreacion";
        public const string NOriVenCre = "NOrigenVentanaCreacion";
        public const string CEstCueBan = "CEstadoCuentaBanco";
        public const string NEstCueBan = "NEstadoCuentaBanco";
        public const string UsuAgr = "UsuarioAgrega";
        public const string FecAgr = "FechaAgrega";
        public const string UsuMod = "UsuarioModifica";
        public const string FecMod = "FechaModifica";

        #endregion

        #region Atributos

        private string _ClaveObjeto = string.Empty;
        private string _ClaveCuentaBanco = string.Empty;
        private string _CodigoEmpresa = string.Empty;
        private string _NombreEmpresa = string.Empty;
        private string _CodigoCuentaBanco = string.Empty;
        private string _DescripcionCuentaBanco = string.Empty;
        private string _CMoneda = string.Empty;
        private string _NMoneda = string.Empty;
        private string _CodigoBanco = string.Empty;
        private string _NombreBanco = string.Empty;
        private string _NumeroCuentaBanco = string.Empty;
        private string _CTipo = "0";
        private string _NTipo = string.Empty;
        private decimal _SaldoCuentaBanco = 0;
        private string _COrigenVentanaCreacion = "01";
        private string _NOrigenVentanaCreacion = "Ventana Editar";
        private string _CEstadoCuentaBanco = "1";
        private string _NEstadoCuentaBanco = string.Empty;
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

        public string ClaveCuentaBanco
        {
            get { return this._ClaveCuentaBanco; }
            set { this._ClaveCuentaBanco = value; }
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

        public string CodigoBanco
        {
            get { return this._CodigoBanco; }
            set { this._CodigoBanco = value; }
        }

        public string NombreBanco
        {
            get { return this._NombreBanco; }
            set { this._NombreBanco = value; }
        }

        public string NumeroCuentaBanco
        {
            get { return this._NumeroCuentaBanco; }
            set { this._NumeroCuentaBanco = value; }
        }

        public string CTipo
        {
            get { return this._CTipo; }
            set { this._CTipo = value; }
        }

        public string NTipo
        {
            get { return this._NTipo; }
            set { this._NTipo = value; }
        }

        public decimal SaldoCuentaBanco
        {
            get { return this._SaldoCuentaBanco; }
            set { this._SaldoCuentaBanco = value; }
        }

        public string COrigenVentanaCreacion
        {
            get { return this._COrigenVentanaCreacion; }
            set { this._COrigenVentanaCreacion = value; }
        }

        public string NOrigenVentanaCreacion
        {
            get { return this._NOrigenVentanaCreacion; }
            set { this._NOrigenVentanaCreacion = value; }
        }

        public string CEstadoCuentaBanco
        {
            get { return this._CEstadoCuentaBanco; }
            set { this._CEstadoCuentaBanco = value; }
        }

        public string NEstadoCuentaBanco
        {
            get { return this._NEstadoCuentaBanco; }
            set { this._NEstadoCuentaBanco = value; }
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
