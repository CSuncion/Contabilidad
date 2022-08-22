using Entidades.Adicionales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class RegContabDetaEN
    {

        #region Nombre Campos

        public const string ClaObj = "ClaveObjeto";
        public const string ClaRegConDet = "ClaveRegContabDeta";
        public const string CodEmp = "CodigoEmpresa";
        public const string NomEmp = "NombreEmpresa";
        public const string PerRegConCab = "PeriodoRegContabCabe";
        public const string COri = "COrigen";
        public const string NOri = "NOrigen";
        public const string CFil = "CFile";
        public const string NFil = "NFile";
        public const string CorRegConCab = "CorrelativoRegContabCabe";
        public const string CorRegConDet = "CorrelativoRegContabDeta";
        public const string ClaRegConCab = "ClaveRegContabCabe";
        public const string FecRegConCab = "FechaRegContabCabe";
        public const string IgvSolRegConCab = "IgvSolRegContabCabe";
        public const string PreVenSolRegConCab = "PrecioVentaSolRegContabCabe";
        public const string CodAux = "CodigoAuxiliar";
        public const string DesAux = "DescripcionAuxiliar";
        public const string CTipDoc = "CTipoDocumento";
        public const string NTipDoc = "NTipoDocumento";
        public const string CAplDocRef = "CAplicaDocumentoRef";
        public const string CTipNot = "CTipoNota";
        public const string SerDoc = "SerieDocumento";
        public const string NumDoc = "NumeroDocumento";
        public const string FecDoc = "FechaDocumento";
        public const string FecVctDoc = "FechaVctoDocumento";
        public const string CMonDoc = "CMonedaDocumento";
        public const string NMonDoc = "NMonedaDocumento";
        public const string VenTipCam = "VentaTipoCambio";
        public const string CodCue = "CodigoCuenta";
        public const string DesCue = "DescripcionCuenta";
        public const string CAut = "CAutomatica";
        public const string CodCueAut1 = "CodigoCuentaAutomatica1";
        public const string CodCueAut2 = "CodigoCuentaAutomatica2";
        public const string CBan = "CBanco";
        public const string CMon = "CMoneda";
        public const string CCenCosCue = "CCentroCostoCuenta";
        public const string CAreCue = "CAreaCuenta";
        public const string CAlm = "CAlmacen";
        public const string CAux = "CAuxiliar";
        public const string CDoc = "CDocumento";
        public const string CDebHab = "CDebeHaber";
        public const string NDebHab = "NDebeHaber";
        public const string ImpSolRegConDet = "ImporteSolRegContabDeta";
        public const string ImpMonRegConDet = "ImporteMonedaRegContabDeta";
        public const string GloRegConDet = "GlosaRegContabDeta";
        public const string CIngEgr = "CIngresoEgreso";
        public const string NIngEgr = "NIngresoEgreso";
        public const string CCenCos = "CCentroCosto";
        public const string NCenCos = "NCentroCosto";
        public const string CAre = "CArea";
        public const string NAre = "NArea";
        public const string CFluCaj = "CFlujoCaja";
        public const string NFluCaj = "NFlujoCaja";
        public const string CodAlm = "CodigoAlmacen";
        public const string DesAlm = "DescripcionAlmacen";
        public const string CodIteAlm = "CodigoItemAlmacen";
        public const string DesIteAlm = "DescripcionItemAlmacen";
        public const string CanIteAlm = "CantidadItemAlmacen";
        public const string CTipLinAsi = "CTipoLineaAsiento";
        public const string CEstRegConDet = "CEstadoRegContabDeta";
        public const string NEstRegConDet = "NEstadoRegContabDeta";
        public const string UsuAgr = "UsuarioAgrega";
        public const string FecAgr = "FechaAgrega";
        public const string UsuMod = "UsuarioModifica";
        public const string FecMod = "FechaModifica";

        #endregion

        #region Atributos

        private string _ClaveObjeto = string.Empty;
        private string _ClaveRegContabDeta = string.Empty;
        private string _CodigoEmpresa = string.Empty;
        private string _NombreEmpresa = string.Empty;
        private string _PeriodoRegContabCabe = string.Empty;
        private string _COrigen = string.Empty;
        private string _NOrigen = string.Empty;
        private string _CFile = string.Empty;
        private string _NFile = string.Empty;
        private string _CorrelativoRegContabCabe = string.Empty;
        private string _CorrelativoRegContabDeta = string.Empty;
        private string _ClaveRegContabCabe = string.Empty;
        private string _FechaRegContabCabe = string.Empty;
        private decimal _IgvSolRegContabCabe = 0;
        private decimal _PrecioVentaSolRegContabCabe = 0;
        private string _CodigoAuxiliar = string.Empty;
        private string _DescripcionAuxiliar = string.Empty;
        private string _CTipoDocumento = string.Empty;
        private string _NTipoDocumento = string.Empty;
        private string _CAplicaDocumentoRef = string.Empty;
        private string _CTipoNota = string.Empty;
        private string _SerieDocumento = string.Empty;
        private string _NumeroDocumento = string.Empty;
        private string _FechaDocumento = string.Empty;
        private string _FechaVctoDocumento = string.Empty;
        private string _CMonedaDocumento = string.Empty;
        private string _NMonedaDocumento = string.Empty;
        private decimal _VentaTipoCambio = 0;
        private string _CodigoCuenta = string.Empty;
        private string _DescripcionCuenta = string.Empty;
        private string _CAutomatica = string.Empty;
        private string _CodigoCuentaAutomatica1 = string.Empty;
        private string _CodigoCuentaAutomatica2 = string.Empty;
        private string _CBanco = string.Empty;
        private string _CMoneda = string.Empty;
        private string _CCentroCostoCuenta = string.Empty;
        private string _CAreaCuenta = string.Empty;
        private string _CAlmacen = string.Empty;
        private string _CAuxiliar = string.Empty;
        private string _CDocumento = string.Empty;
        private string _CDebeHaber = string.Empty;
        private string _NDebeHaber = string.Empty;
        private decimal _ImporteSolRegContabDeta = 0;
        private decimal _ImporteMonedaRegContabDeta = 0;
        private string _GlosaRegContabDeta = string.Empty;
        private string _CIngresoEgreso = string.Empty;
        private string _NIngresoEgreso = string.Empty;
        private string _CCentroCosto = string.Empty;
        private string _NCentroCosto = string.Empty;
        private string _CArea = string.Empty;
        private string _NArea = string.Empty;
        private string _CFlujoCaja = string.Empty;
        private string _NFlujoCaja = string.Empty;
        private string _CodigoAlmacen = string.Empty;
        private string _DescripcionAlmacen = string.Empty;
        private string _CodigoItemAlmacen = string.Empty;
        private string _DescripcionItemAlmacen = string.Empty;
        private decimal _CantidadItemAlmacen = 0;
        private string _CTipoLineaAsiento = ItemGEN.TipoLineaAsiento_Editado;
        private string _CEstadoRegContabDeta = "1";
        private string _NEstadoRegContabDeta = string.Empty;
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

        public string ClaveRegContabDeta
        {
            get { return this._ClaveRegContabDeta; }
            set { this._ClaveRegContabDeta = value; }
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

        public string PeriodoRegContabCabe
        {
            get { return this._PeriodoRegContabCabe; }
            set { this._PeriodoRegContabCabe = value; }
        }

        public string COrigen
        {
            get { return this._COrigen; }
            set { this._COrigen = value; }
        }

        public string NOrigen
        {
            get { return this._NOrigen; }
            set { this._NOrigen = value; }
        }

        public string CFile
        {
            get { return this._CFile; }
            set { this._CFile = value; }
        }

        public string NFile
        {
            get { return this._NFile; }
            set { this._NFile = value; }
        }

        public string CorrelativoRegContabCabe
        {
            get { return this._CorrelativoRegContabCabe; }
            set { this._CorrelativoRegContabCabe = value; }
        }

        public string CorrelativoRegContabDeta
        {
            get { return this._CorrelativoRegContabDeta; }
            set { this._CorrelativoRegContabDeta = value; }
        }

        public string ClaveRegContabCabe
        {
            get { return this._ClaveRegContabCabe; }
            set { this._ClaveRegContabCabe = value; }
        }

        public string FechaRegContabCabe
        {
            get { return this._FechaRegContabCabe; }
            set { this._FechaRegContabCabe = value; }
        }

        public decimal IgvSolRegContabCabe
        {
            get { return this._IgvSolRegContabCabe; }
            set { this._IgvSolRegContabCabe = value; }
        }

        public decimal PrecioVentaSolRegContabCabe
        {
            get { return this._PrecioVentaSolRegContabCabe; }
            set { this._PrecioVentaSolRegContabCabe = value; }
        }

        public string CodigoAuxiliar
        {
            get { return this._CodigoAuxiliar; }
            set { this._CodigoAuxiliar = value; }
        }

        public string DescripcionAuxiliar
        {
            get { return this._DescripcionAuxiliar; }
            set { this._DescripcionAuxiliar = value; }
        }

        public string CTipoDocumento
        {
            get { return this._CTipoDocumento; }
            set { this._CTipoDocumento = value; }
        }

        public string NTipoDocumento
        {
            get { return this._NTipoDocumento; }
            set { this._NTipoDocumento = value; }
        }

        public string CAplicaDocumentoRef
        {
            get { return this._CAplicaDocumentoRef; }
            set { this._CAplicaDocumentoRef = value; }
        }

        public string CTipoNota
        {
            get { return this._CTipoNota; }
            set { this._CTipoNota = value; }
        }

        public string SerieDocumento
        {
            get { return this._SerieDocumento; }
            set { this._SerieDocumento = value; }
        }

        public string NumeroDocumento
        {
            get { return this._NumeroDocumento; }
            set { this._NumeroDocumento = value; }
        }

        public string FechaDocumento
        {
            get { return this._FechaDocumento; }
            set { this._FechaDocumento = value; }
        }

        public string FechaVctoDocumento
        {
            get { return this._FechaVctoDocumento; }
            set { this._FechaVctoDocumento = value; }
        }

        public string CMonedaDocumento
        {
            get { return this._CMonedaDocumento; }
            set { this._CMonedaDocumento = value; }
        }

        public string NMonedaDocumento
        {
            get { return this._NMonedaDocumento; }
            set { this._NMonedaDocumento = value; }
        }

        public decimal VentaTipoCambio
        {
            get { return this._VentaTipoCambio; }
            set { this._VentaTipoCambio = value; }
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

        public string CAutomatica
        {
            get { return this._CAutomatica; }
            set { this._CAutomatica = value; }
        }

        public string CodigoCuentaAutomatica1
        {
            get { return this._CodigoCuentaAutomatica1; }
            set { this._CodigoCuentaAutomatica1 = value; }
        }

        public string CodigoCuentaAutomatica2
        {
            get { return this._CodigoCuentaAutomatica2; }
            set { this._CodigoCuentaAutomatica2 = value; }
        }

        public string CBanco
        {
            get { return this._CBanco; }
            set { this._CBanco = value; }
        }

        public string CMoneda
        {
            get { return this._CMoneda; }
            set { this._CMoneda = value; }
        }

        public string CCentroCostoCuenta
        {
            get { return this._CCentroCostoCuenta; }
            set { this._CCentroCostoCuenta = value; }
        }

        public string CAreaCuenta
        {
            get { return this._CAreaCuenta; }
            set { this._CAreaCuenta = value; }
        }

        public string CAlmacen
        {
            get { return this._CAlmacen; }
            set { this._CAlmacen = value; }
        }

        public string CAuxiliar
        {
            get { return this._CAuxiliar; }
            set { this._CAuxiliar = value; }
        }

        public string CDocumento
        {
            get { return this._CDocumento; }
            set { this._CDocumento = value; }
        }

        public string CDebeHaber
        {
            get { return this._CDebeHaber; }
            set { this._CDebeHaber = value; }
        }

        public string NDebeHaber
        {
            get { return this._NDebeHaber; }
            set { this._NDebeHaber = value; }
        }

        public decimal ImporteSolRegContabDeta
        {
            get { return this._ImporteSolRegContabDeta; }
            set { this._ImporteSolRegContabDeta = value; }
        }

        public decimal ImporteMonedaRegContabDeta
        {
            get { return this._ImporteMonedaRegContabDeta; }
            set { this._ImporteMonedaRegContabDeta = value; }
        }

        public string GlosaRegContabDeta
        {
            get { return this._GlosaRegContabDeta; }
            set { this._GlosaRegContabDeta = value; }
        }

        public string CIngresoEgreso
        {
            get { return this._CIngresoEgreso; }
            set { this._CIngresoEgreso = value; }
        }

        public string NIngresoEgreso
        {
            get { return this._NIngresoEgreso; }
            set { this._NIngresoEgreso = value; }
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

        public string CodigoAlmacen
        {
            get { return this._CodigoAlmacen; }
            set { this._CodigoAlmacen = value; }
        }

        public string DescripcionAlmacen
        {
            get { return this._DescripcionAlmacen; }
            set { this._DescripcionAlmacen = value; }
        }

        public string CodigoItemAlmacen
        {
            get { return this._CodigoItemAlmacen; }
            set { this._CodigoItemAlmacen = value; }
        }

        public string DescripcionItemAlmacen
        {
            get { return this._DescripcionItemAlmacen; }
            set { this._DescripcionItemAlmacen = value; }
        }

        public decimal CantidadItemAlmacen
        {
            get { return this._CantidadItemAlmacen; }
            set { this._CantidadItemAlmacen = value; }
        }

        public string CTipoLineaAsiento
        {
            get { return this._CTipoLineaAsiento; }
            set { this._CTipoLineaAsiento = value; }
        }

        public string CEstadoRegContabDeta
        {
            get { return this._CEstadoRegContabDeta; }
            set { this._CEstadoRegContabDeta = value; }
        }

        public string NEstadoRegContabDeta
        {
            get { return this._NEstadoRegContabDeta; }
            set { this._NEstadoRegContabDeta = value; }
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
