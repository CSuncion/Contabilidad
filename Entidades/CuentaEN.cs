using Entidades.Adicionales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class CuentaEN
    {

        #region Nombre Campos

        public const string ClaObj = "ClaveObjeto";
        public const string ClaCue = "ClaveCuenta";
        public const string CodEmp = "CodigoEmpresa";
        public const string NomEmp = "NombreEmpresa";
        public const string CodCue = "CodigoCuenta";
        public const string DesCue = "DescripcionCuenta";
        public const string NumDigAna = "NumeroDigitosAnalitica";
        public const string CDoc = "CDocumento";
        public const string NDoc = "NDocumento";
        public const string CAux = "CAuxiliar";
        public const string NAux = "NAuxiliar";
        public const string CCenCos = "CCentroCosto";
        public const string NCenCos = "NCentroCosto";
        public const string CAlm = "CAlmacen";
        public const string NAlm = "NAlmacen";
        public const string CAre = "CArea";
        public const string NAre = "NArea";
        public const string CFluCaj = "CFlujoCaja";
        public const string NFluCaj = "NFlujoCaja";
        public const string CAut = "CAutomatica";
        public const string NAut = "NAutomatica";
        public const string CDifCam = "CDiferenciaCambio";
        public const string NDifCam = "NDiferenciaCambio";
        public const string CBan = "CBanco";
        public const string NBan = "NBanco";
        public const string CMon = "CMoneda";
        public const string NMon = "NMoneda";
        public const string CAsiApe = "CAsientoApertura";
        public const string NAsiApe = "NAsientoApertura";
        public const string CAsiCie7 = "CAsientoCierre7";
        public const string NAsiCie7 = "NAsientoCierre7";
        public const string CAsiCie9 = "CAsientoCierre9";
        public const string NAsiCie9 = "NAsientoCierre9";
        public const string CReg = "CRegistro";
        public const string NReg = "NRegistro";
        public const string CodCueAut1 = "CodigoCuentaAutomatica1";
        public const string DesCueAut1 = "DescripcionCuentaAutomatica1";
        public const string CodCueAut2 = "CodigoCuentaAutomatica2";
        public const string DesCueAut2 = "DescripcionCuentaAutomatica2";
        public const string CodForCon = "CodigoFormatoContable";
        public const string DesForCon = "DescripcionFormatoContable";
        public const string VerFal = "VerdadFalso";
        public const string COriVenCre = "COrigenVentanaCreacion";
        public const string NOriVenCre = "NOrigenVentanaCreacion";
        public const string CEstCue = "CEstadoCuenta";
        public const string NEstCue = "NEstadoCuenta";
        public const string UsuAgr = "UsuarioAgrega";
        public const string FecAgr = "FechaAgrega";
        public const string UsuMod = "UsuarioModifica";
        public const string FecMod = "FechaModifica";

        #endregion

        #region Atributos

        private string _ClaveObjeto = string.Empty;
        private string _ClaveCuenta = string.Empty;
        private string _CodigoEmpresa = string.Empty;
        private string _NombreEmpresa = string.Empty;
        private string _CodigoCuenta = string.Empty;
        private string _DescripcionCuenta = string.Empty;
        private string _NumeroDigitosAnalitica = string.Empty;
        private string _CDocumento = string.Empty;
        private string _NDocumento = string.Empty;
        private string _CAuxiliar = string.Empty;
        private string _NAuxiliar = string.Empty;
        private string _CCentroCosto = string.Empty;
        private string _NCentroCosto = string.Empty;
        private string _CAlmacen = string.Empty;
        private string _NAlmacen = string.Empty;
        private string _CArea = string.Empty;
        private string _NArea = string.Empty;
        private string _CFlujoCaja = string.Empty;
        private string _NFlujoCaja = string.Empty;
        private string _CAutomatica = string.Empty;
        private string _NAutomatica = string.Empty;
        private string _CDiferenciaCambio = string.Empty;
        private string _NDiferenciaCambio = string.Empty;
        private string _CBanco = string.Empty;
        private string _NBanco = string.Empty;
        private string _CMoneda = string.Empty;
        private string _NMoneda = string.Empty;
        private string _CAsientoApertura = string.Empty;
        private string _NAsientoApertura = string.Empty;
        private string _CAsientoCierre7 = string.Empty;
        private string _NAsientoCierre7 = string.Empty;
        private string _CAsientoCierre9 = string.Empty;
        private string _NAsientoCierre9 = string.Empty;
        private string _CRegistro = "9";
        private string _NRegistro = "Otros";
        private string _CodigoCuentaAutomatica1 = string.Empty;
        private string _DescripcionCuentaAutomatica1 = string.Empty;
        private string _CodigoCuentaAutomatica2 = string.Empty;
        private string _DescripcionCuentaAutomatica2 = string.Empty;
        private string _CodigoFormatoContable = string.Empty;
        private string _DescripcionFormatoContable = string.Empty;
        private bool _VerdadFalso = false;
        private string _COrigenVentanaCreacion = "01";
        private string _NOrigenVentanaCreacion = "Ventana Editar";
        private string _CEstadoCuenta = "1";
        private string _NEstadoCuenta = string.Empty;
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

        public string ClaveCuenta
        {
            get { return this._ClaveCuenta; }
            set { this._ClaveCuenta = value; }
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

        public string CodigoCuenta
        {
            get { return this._CodigoCuenta; }
            set { this._CodigoCuenta = value; }
        }

        public string DescripcionCuenta
        {
            get { return this._DescripcionCuenta; }
            set { this._DescripcionCuenta = value; }
        }

        public string NumeroDigitosAnalitica
        {
            get { return this._NumeroDigitosAnalitica; }
            set { this._NumeroDigitosAnalitica = value; }
        }

        public string CDocumento
        {
            get { return this._CDocumento; }
            set { this._CDocumento = value; }
        }

        public string NDocumento
        {
            get { return this._NDocumento; }
            set { this._NDocumento = value; }
        }

        public string CAuxiliar
        {
            get { return this._CAuxiliar; }
            set { this._CAuxiliar = value; }
        }

        public string NAuxiliar
        {
            get { return this._NAuxiliar; }
            set { this._NAuxiliar = value; }
        }

        public string CCentroCosto
        {
            get { return this._CCentroCosto; }
            set { this._CCentroCosto = value; }
        }

        public string NCentroCosto
        {
            get { return this._NCentroCosto; }
            set { this._NCentroCosto = value; }
        }

        public string CAlmacen
        {
            get { return this._CAlmacen; }
            set { this._CAlmacen = value; }
        }

        public string NAlmacen
        {
            get { return this._NAlmacen; }
            set { this._NAlmacen = value; }
        }

        public string CArea
        {
            get { return this._CArea; }
            set { this._CArea = value; }
        }

        public string NArea
        {
            get { return this._NArea; }
            set { this._NArea = value; }
        }

        public string CFlujoCaja
        {
            get { return this._CFlujoCaja; }
            set { this._CFlujoCaja = value; }
        }

        public string NFlujoCaja
        {
            get { return this._NFlujoCaja; }
            set { this._NFlujoCaja = value; }
        }

        public string CAutomatica
        {
            get { return this._CAutomatica; }
            set { this._CAutomatica = value; }
        }

        public string NAutomatica
        {
            get { return this._NAutomatica; }
            set { this._NAutomatica = value; }
        }

        public string CDiferenciaCambio
        {
            get { return this._CDiferenciaCambio; }
            set { this._CDiferenciaCambio = value; }
        }

        public string NDiferenciaCambio
        {
            get { return this._NDiferenciaCambio; }
            set { this._NDiferenciaCambio = value; }
        }

        public string CBanco
        {
            get { return this._CBanco; }
            set { this._CBanco = value; }
        }

        public string NBanco
        {
            get { return this._NBanco; }
            set { this._NBanco = value; }
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

        public string CAsientoApertura
        {
            get { return this._CAsientoApertura; }
            set { this._CAsientoApertura = value; }
        }

        public string NAsientoApertura
        {
            get { return this._NAsientoApertura; }
            set { this._NAsientoApertura = value; }
        }

        public string CAsientoCierre7
        {
            get { return this._CAsientoCierre7; }
            set { this._CAsientoCierre7 = value; }
        }

        public string NAsientoCierre7
        {
            get { return this._NAsientoCierre7; }
            set { this._NAsientoCierre7 = value; }
        }

        public string CAsientoCierre9
        {
            get { return this._CAsientoCierre9; }
            set { this._CAsientoCierre9 = value; }
        }

        public string NAsientoCierre9
        {
            get { return this._NAsientoCierre9; }
            set { this._NAsientoCierre9 = value; }
        }

        public string CRegistro
        {
            get { return this._CRegistro; }
            set { this._CRegistro = value; }
        }

        public string NRegistro
        {
            get { return this._NRegistro; }
            set { this._NRegistro = value; }
        }

        public string CodigoCuentaAutomatica1
        {
            get { return this._CodigoCuentaAutomatica1; }
            set { this._CodigoCuentaAutomatica1 = value; }
        }

        public string DescripcionCuentaAutomatica1
        {
            get { return this._DescripcionCuentaAutomatica1; }
            set { this._DescripcionCuentaAutomatica1 = value; }
        }

        public string CodigoCuentaAutomatica2
        {
            get { return this._CodigoCuentaAutomatica2; }
            set { this._CodigoCuentaAutomatica2 = value; }
        }

        public string DescripcionCuentaAutomatica2
        {
            get { return this._DescripcionCuentaAutomatica2; }
            set { this._DescripcionCuentaAutomatica2 = value; }
        }

        public string CodigoFormatoContable
        {
            get { return this._CodigoFormatoContable; }
            set { this._CodigoFormatoContable = value; }
        }

        public string DescripcionFormatoContable
        {
            get { return this._DescripcionFormatoContable; }
            set { this._DescripcionFormatoContable = value; }
        }

        public bool VerdadFalso
        {
            get { return this._VerdadFalso; }
            set { this._VerdadFalso = value; }
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

        public string CEstadoCuenta
        {
            get { return this._CEstadoCuenta; }
            set { this._CEstadoCuenta = value; }
        }

        public string NEstadoCuenta
        {
            get { return this._NEstadoCuenta; }
            set { this._NEstadoCuenta = value; }
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
