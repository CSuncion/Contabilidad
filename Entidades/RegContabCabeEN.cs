using Entidades.Adicionales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class RegContabCabeEN
    {

        #region Nombre Campos

        public const string ClaObj = "ClaveObjeto";
        public const string ClaRegConCab = "ClaveRegContabCabe";
        public const string CodEmp = "CodigoEmpresa";
        public const string NomEmp = "NombreEmpresa";
        public const string PerRegConCab = "PeriodoRegContabCabe";
        public const string COri = "COrigen";
        public const string NOri = "NOrigen";
        public const string CFil = "CFile";
        public const string NFil = "NFile";
        public const string CorRegConCab = "CorrelativoRegContabCabe";
        public const string FecRegConCab = "FechaRegContabCabe";
        public const string CodAux = "CodigoAuxiliar";
        public const string DesAux = "DescripcionAuxiliar";
        public const string ApePatAux = "ApellidoPaternoAuxiliar";
        public const string ApeMatAux = "ApellidoMaternoAuxiliar";
        public const string PriNomAux = "PrimerNombreAuxiliar";
        public const string SegNomAux = "SegundoNombreAuxiliar";
        public const string CTipDocAux = "CTipoDocumentoAuxiliar";
        public const string FecInsSnpAux = "FechaInscripcionSnpAuxiliar";
        public const string CModCom = "CModoCompra";
        public const string NModCom = "NModoCompra";
        public const string CTipCom = "CTipoCompra";
        public const string NTipCom = "NTipoCompra";
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
        public const string CTipDocRef = "CTipoDocumentoRef";
        public const string NTipDocRef = "NTipoDocumentoRef";
        public const string SerDocRef = "SerieDocumentoRef";
        public const string NumDocRef = "NumeroDocumentoRef";
        public const string FecDocRef = "FechaDocumentoRef";
        public const string FecVctDocRef = "FechaVctoDocumentoRef";
        public const string CMonDocRef = "CMonedaDocumentoRef";
        public const string NMonDocRef = "NMonedaDocumentoRef";
        public const string VenTipCam = "VentaTipoCambio";
        public const string PorIgv = "PorcentajeIgv";
        public const string CAplIgv = "CAplicaIgv";
        public const string NAplIgv = "NAplicaIgv";
        public const string CAplIna = "CAplicaInafecto";
        public const string NAplIna = "NAplicaInafecto";
        public const string ValVenRegConCab = "ValorVentaRegContabCabe";
        public const string IgvRegConCab = "IgvRegContabCabe";
        public const string ExoRegConCab = "ExoneradoRegContabCabe";
        public const string InaRegConCab = "InafectoRegContabCabe";
        public const string PreVenRegConCab = "PrecioVentaRegContabCabe";
        public const string ValVenSolRegConCab = "ValorVentaSolRegContabCabe";
        public const string IgvSolRegConCab = "IgvSolRegContabCabe";
        public const string ExoSolRegConCab = "ExoneradoSolRegContabCabe";
        public const string InaSolRegConCab = "InafectoSolRegContabCabe";
        public const string PreVenSolRegConCab = "PrecioVentaSolRegContabCabe";
        public const string GloRegConCab = "GlosaRegContabCabe";
        public const string CAplDet = "CAplicaDetraccion";
        public const string NAplDet = "NAplicaDetraccion";
        public const string NumPapDet = "NumeroPapeletaDetraccion";
        public const string FecDet = "FechaDetraccion";
        public const string CodCue = "CodigoCuenta";
        public const string DesCue = "DescripcionCuenta";
        public const string CMonCue = "CMonedaCuenta";
        public const string NMonCue = "NMonedaCuenta";
        public const string NumCueBan = "NumeroCuentaBanco";
        public const string CAplRet = "CAplicaRetencion";
        public const string NAplRet = "NAplicaRetencion";
        public const string TotHon = "TotalHonorario";
        public const string RetHon = "RetencionHonorario";
        public const string PagHon = "PagoHonorario";
        public const string ImpRegConCab = "ImporteRegContabCabe";
        public const string ImpSolRegConCab = "ImporteSolRegContabCabe";
        public const string CModPag = "CModoPago";
        public const string NModPag = "NModoPago";
        public const string GirPagRegConCab = "GiradoPagoRegContabCabe";
        public const string CarRegConCab = "CartaRegContabCabe";
        public const string ClaIngRegConCab = "ClaveIngresoRegContabCabe";
        public const string CEstRegConCab = "CEstadoRegContabCabe";
        public const string NEstRegConCab = "NEstadoRegContabCabe";
        public const string UsuAgr = "UsuarioAgrega";
        public const string FecAgr = "FechaAgrega";
        public const string UsuMod = "UsuarioModifica";
        public const string FecMod = "FechaModifica";

        #endregion

        #region Atributos

        private string _ClaveObjeto = string.Empty;
        private string _ClaveRegContabCabe = string.Empty;
        private string _CodigoEmpresa = string.Empty;
        private string _NombreEmpresa = string.Empty;
        private string _PeriodoRegContabCabe = string.Empty;
        private string _COrigen = string.Empty;
        private string _NOrigen = string.Empty;
        private string _CFile = string.Empty;
        private string _NFile = string.Empty;
        private string _CorrelativoRegContabCabe = string.Empty;
        private string _FechaRegContabCabe = string.Empty;
        private string _CodigoAuxiliar = string.Empty;
        private string _DescripcionAuxiliar = string.Empty;
        private string _ApellidoPaternoAuxiliar = string.Empty;
        private string _ApellidoMaternoAuxiliar = string.Empty;
        private string _PrimerNombreAuxiliar = string.Empty;
        private string _SegundoNombreAuxiliar = string.Empty;
        private string _CTipoDocumentoAuxiliar = string.Empty;
        private string _FechaInscripcionSnpAuxiliar = string.Empty;
        private string _CModoCompra = string.Empty;
        private string _NModoCompra = string.Empty;
        private string _CTipoCompra = string.Empty;
        private string _NTipoCompra = string.Empty;
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
        private string _CTipoDocumentoRef = string.Empty;
        private string _NTipoDocumentoRef = string.Empty;
        private string _SerieDocumentoRef = string.Empty;
        private string _NumeroDocumentoRef = string.Empty;
        private string _FechaDocumentoRef = string.Empty;
        private string _FechaVctoDocumentoRef = string.Empty;
        private string _CMonedaDocumentoRef = string.Empty;
        private string _NMonedaDocumentoRef = string.Empty;
        private decimal _VentaTipoCambio = 0;
        private decimal _PorcentajeIgv = 0;
        private string _CAplicaIgv = "1";
        private string _NAplicaIgv = "Si";
        private string _CAplicaInafecto = "0";
        private string _NAplicaInafecto = "No";
        private decimal _ValorVentaRegContabCabe = 0;
        private decimal _IgvRegContabCabe = 0;
        private decimal _ExoneradoRegContabCabe = 0;
        private decimal _InafectoRegContabCabe = 0;
        private decimal _PrecioVentaRegContabCabe = 0;
        private decimal _ValorVentaSolRegContabCabe = 0;
        private decimal _IgvSolRegContabCabe = 0;
        private decimal _ExoneradoSolRegContabCabe = 0;
        private decimal _InafectoSolRegContabCabe = 0;
        private decimal _PrecioVentaSolRegContabCabe = 0;
        private string _GlosaRegContabCabe = string.Empty;
        private string _CAplicaDetraccion = "0";
        private string _NAplicaDetraccion = "No";
        private string _NumeroPapeletaDetraccion = string.Empty;
        private string _FechaDetraccion = string.Empty;
        private string _CodigoCuenta = string.Empty;
        private string _DescripcionCuenta = string.Empty;
        private string _CMonedaCuenta = string.Empty;
        private string _NMonedaCuenta = string.Empty;
        private string _NumeroCuentaBanco = string.Empty;
        private string _CAplicaRetencion = string.Empty;
        private string _NAplicaRetencion = string.Empty;
        private decimal _TotalHonorario = 0;
        private decimal _RetencionHonorario = 0;
        private decimal _PagoHonorario = 0;
        private decimal _ImporteRegContabCabe = 0;
        private decimal _ImporteSolRegContabCabe = 0;
        private string _CModoPago = string.Empty;
        private string _NModoPago = string.Empty;
        private string _GiradoPagoRegContabCabe = string.Empty;
        private string _CartaRegContabCabe = string.Empty;
        private string _ClaveIngresoRegContabCabe = string.Empty;
        private string _CEstadoRegContabCabe = "1";
        private string _NEstadoRegContabCabe = string.Empty;
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

        public string ClaveRegContabCabe
        {
            get { return this._ClaveRegContabCabe; }
            set { this._ClaveRegContabCabe = value; }
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

        public string FechaRegContabCabe
        {
            get { return this._FechaRegContabCabe; }
            set { this._FechaRegContabCabe = value; }
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

        public string ApellidoPaternoAuxiliar
        {
            get { return this._ApellidoPaternoAuxiliar; }
            set { this._ApellidoPaternoAuxiliar = value; }
        }

        public string ApellidoMaternoAuxiliar
        {
            get { return this._ApellidoMaternoAuxiliar; }
            set { this._ApellidoMaternoAuxiliar = value; }
        }

        public string PrimerNombreAuxiliar
        {
            get { return this._PrimerNombreAuxiliar; }
            set { this._PrimerNombreAuxiliar = value; }
        }

        public string SegundoNombreAuxiliar
        {
            get { return this._SegundoNombreAuxiliar; }
            set { this._SegundoNombreAuxiliar = value; }
        }

        public string CTipoDocumentoAuxiliar
        {
            get { return this._CTipoDocumentoAuxiliar; }
            set { this._CTipoDocumentoAuxiliar = value; }
        }

        public string FechaInscripcionSnpAuxiliar
        {
            get { return this._FechaInscripcionSnpAuxiliar; }
            set { this._FechaInscripcionSnpAuxiliar = value; }
        }

        public string CModoCompra
        {
            get { return this._CModoCompra; }
            set { this._CModoCompra = value; }
        }

        public string NModoCompra
        {
            get { return this._NModoCompra; }
            set { this._NModoCompra = value; }
        }

        public string CTipoCompra
        {
            get { return this._CTipoCompra; }
            set { this._CTipoCompra = value; }
        }

        public string NTipoCompra
        {
            get { return this._NTipoCompra; }
            set { this._NTipoCompra = value; }
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

        public string CTipoDocumentoRef
        {
            get { return this._CTipoDocumentoRef; }
            set { this._CTipoDocumentoRef = value; }
        }

        public string NTipoDocumentoRef
        {
            get { return this._NTipoDocumentoRef; }
            set { this._NTipoDocumentoRef = value; }
        }

        public string SerieDocumentoRef
        {
            get { return this._SerieDocumentoRef; }
            set { this._SerieDocumentoRef = value; }
        }

        public string NumeroDocumentoRef
        {
            get { return this._NumeroDocumentoRef; }
            set { this._NumeroDocumentoRef = value; }
        }

        public string FechaDocumentoRef
        {
            get { return this._FechaDocumentoRef; }
            set { this._FechaDocumentoRef = value; }
        }

        public string FechaVctoDocumentoRef
        {
            get { return this._FechaVctoDocumentoRef; }
            set { this._FechaVctoDocumentoRef = value; }
        }

        public string CMonedaDocumentoRef
        {
            get { return this._CMonedaDocumentoRef; }
            set { this._CMonedaDocumentoRef = value; }
        }

        public string NMonedaDocumentoRef
        {
            get { return this._NMonedaDocumentoRef; }
            set { this._NMonedaDocumentoRef = value; }
        }

        public decimal VentaTipoCambio
        {
            get { return this._VentaTipoCambio; }
            set { this._VentaTipoCambio = value; }
        }

        public decimal PorcentajeIgv
        {
            get { return this._PorcentajeIgv; }
            set { this._PorcentajeIgv = value; }
        }

        public string CAplicaIgv
        {
            get { return this._CAplicaIgv; }
            set { this._CAplicaIgv = value; }
        }

        public string NAplicaIgv
        {
            get { return this._NAplicaIgv; }
            set { this._NAplicaIgv = value; }
        }

        public string CAplicaInafecto
        {
            get { return this._CAplicaInafecto; }
            set { this._CAplicaInafecto = value; }
        }

        public string NAplicaInafecto
        {
            get { return this._NAplicaInafecto; }
            set { this._NAplicaInafecto = value; }
        }

        public decimal ValorVentaRegContabCabe
        {
            get { return this._ValorVentaRegContabCabe; }
            set { this._ValorVentaRegContabCabe = value; }
        }

        public decimal IgvRegContabCabe
        {
            get { return this._IgvRegContabCabe; }
            set { this._IgvRegContabCabe = value; }
        }

        public decimal ExoneradoRegContabCabe
        {
            get { return this._ExoneradoRegContabCabe; }
            set { this._ExoneradoRegContabCabe = value; }
        }

        public decimal InafectoRegContabCabe
        {
            get { return this._InafectoRegContabCabe; }
            set { this._InafectoRegContabCabe = value; }
        }

        public decimal PrecioVentaRegContabCabe
        {
            get { return this._PrecioVentaRegContabCabe; }
            set { this._PrecioVentaRegContabCabe = value; }
        }

        public decimal ValorVentaSolRegContabCabe
        {
            get { return this._ValorVentaSolRegContabCabe; }
            set { this._ValorVentaSolRegContabCabe = value; }
        }

        public decimal IgvSolRegContabCabe
        {
            get { return this._IgvSolRegContabCabe; }
            set { this._IgvSolRegContabCabe = value; }
        }

        public decimal ExoneradoSolRegContabCabe
        {
            get { return this._ExoneradoSolRegContabCabe; }
            set { this._ExoneradoSolRegContabCabe = value; }
        }

        public decimal InafectoSolRegContabCabe
        {
            get { return this._InafectoSolRegContabCabe; }
            set { this._InafectoSolRegContabCabe = value; }
        }

        public decimal PrecioVentaSolRegContabCabe
        {
            get { return this._PrecioVentaSolRegContabCabe; }
            set { this._PrecioVentaSolRegContabCabe = value; }
        }

        public string GlosaRegContabCabe
        {
            get { return this._GlosaRegContabCabe; }
            set { this._GlosaRegContabCabe = value; }
        }

        public string CAplicaDetraccion
        {
            get { return this._CAplicaDetraccion; }
            set { this._CAplicaDetraccion = value; }
        }

        public string NAplicaDetraccion
        {
            get { return this._NAplicaDetraccion; }
            set { this._NAplicaDetraccion = value; }
        }

        public string NumeroPapeletaDetraccion
        {
            get { return this._NumeroPapeletaDetraccion; }
            set { this._NumeroPapeletaDetraccion = value; }
        }

        public string FechaDetraccion
        {
            get { return this._FechaDetraccion; }
            set { this._FechaDetraccion = value; }
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

        public string CMonedaCuenta
        {
            get { return this._CMonedaCuenta; }
            set { this._CMonedaCuenta = value; }
        }

        public string NMonedaCuenta
        {
            get { return this._NMonedaCuenta; }
            set { this._NMonedaCuenta = value; }
        }

        public string NumeroCuentaBanco
        {
            get { return this._NumeroCuentaBanco; }
            set { this._NumeroCuentaBanco = value; }
        }

        public string CAplicaRetencion
        {
            get { return this._CAplicaRetencion; }
            set { this._CAplicaRetencion = value; }
        }

        public string NAplicaRetencion
        {
            get { return this._NAplicaRetencion; }
            set { this._NAplicaRetencion = value; }
        }

        public decimal TotalHonorario
        {
            get { return this._TotalHonorario; }
            set { this._TotalHonorario = value; }
        }

        public decimal RetencionHonorario
        {
            get { return this._RetencionHonorario; }
            set { this._RetencionHonorario = value; }
        }

        public decimal PagoHonorario
        {
            get { return this._PagoHonorario; }
            set { this._PagoHonorario = value; }
        }

        public decimal ImporteRegContabCabe
        {
            get { return this._ImporteRegContabCabe; }
            set { this._ImporteRegContabCabe = value; }
        }

        public decimal ImporteSolRegContabCabe
        {
            get { return this._ImporteSolRegContabCabe; }
            set { this._ImporteSolRegContabCabe = value; }
        }

        public string CModoPago
        {
            get { return this._CModoPago; }
            set { this._CModoPago = value; }
        }

        public string NModoPago
        {
            get { return this._NModoPago; }
            set { this._NModoPago = value; }
        }

        public string GiradoPagoRegContabCabe
        {
            get { return this._GiradoPagoRegContabCabe; }
            set { this._GiradoPagoRegContabCabe = value; }
        }

        public string CartaRegContabCabe
        {
            get { return this._CartaRegContabCabe; }
            set { this._CartaRegContabCabe = value; }
        }

        public string ClaveIngresoRegContabCabe
        {
            get { return this._ClaveIngresoRegContabCabe; }
            set { this._ClaveIngresoRegContabCabe = value; }
        }

        public string CEstadoRegContabCabe
        {
            get { return this._CEstadoRegContabCabe; }
            set { this._CEstadoRegContabCabe = value; }
        }

        public string NEstadoRegContabCabe
        {
            get { return this._NEstadoRegContabCabe; }
            set { this._NEstadoRegContabCabe = value; }
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
