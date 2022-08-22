using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades.Adicionales;

namespace Entidades
{
    public class CuentaCorrienteEN
    {

        //campos nombres
        public const string ClaObj = "ClaveObjeto";
        public const string ClaCtaCte = "ClaveCuentaCorriente";
        public const string ClaDocCtaCte = "ClaveDocumentoCuentaCorriente";
        public const string CodEmp = "CodigoEmpresa";
        public const string NomEmp = "NombreEmpresa";
        public const string PerRegConCab = "PeriodoRegContabCabe";
        public const string COri = "COrigen";
        public const string NOri = "NOrigen";
        public const string CFil = "CFile";
        public const string NFil = "NFile";
        public const string NumVouRegConCab = "NumeroVoucherRegContabCabe";
        public const string CodAux = "CodigoAuxiliar";
        public const string DesAux = "DescripcionAuxiliar";
        public const string CTipDoc = "CTipoDocumento";
        public const string NTipDoc = "NTipoDocumento";        
        public const string SerDoc = "SerieDocumento";
        public const string NumDoc = "NumeroDocumento";
        public const string FecDoc = "FechaDocumento";        
        public const string CMonDoc = "CMonedaDocumento";
        public const string NMonDoc = "NMonedaDocumento";
        public const string FecVctDoc = "FechaVctoDocumento";
        public const string VenTipCam = "VentaTipoCambio";
        public const string VenEurTipCam = "VentaEurTipoCambio";
        public const string PorIgv = "PorcentajeIgv";
        public const string ImpOriCtaCte = "ImporteOriginalCuentaCorriente";
        public const string ImpPagCtaCte = "ImportePagadoCuentaCorriente";
        public const string SalCtaCte = "SaldoCuentaCorriente";
        public const string CodCta = "CodigoCuenta";
        public const string DesCta = "DescripcionCuenta";
        public const string CEstCtaCte = "CEstadoCuentaCorriente";
        public const string NEstCtaCte = "NEstadoCuentaCorriente";
        public const string UsuAgr = "UsuarioAgrega";
        public const string FecAgr = "FechaAgrega";
        public const string UsuMod = "UsuarioModifica";
        public const string FecMod = "FechaModifica";

        //atributos
        private string _ClaveObjeto = string.Empty;
        private string _ClaveCuentaCorriente = string.Empty;
        private string _ClaveDocumentoCuentaCorriente = string.Empty;
        private string _CodigoEmpresa = string.Empty;
        private string _NombreEmpresa = string.Empty;
        private string _PeriodoRegContabCabe = string.Empty;
        private string _COrigen = string.Empty;
        private string _NOrigen = string.Empty;
        private string _CFile = string.Empty;
        private string _NFile = string.Empty;
        private string _NumeroVoucherRegContabCabe = string.Empty;         
        private string _CodigoAuxiliar = string.Empty;
        private string _DescripcionAuxiliar = string.Empty;        
        private string _CTipoDocumento = string.Empty;
        private string _NTipoDocumento = string.Empty;        
        private string _SerieDocumento = string.Empty;
        private string _NumeroDocumento = string.Empty;
        private string _FechaDocumento = string.Empty;        
        private string _CMonedaDocumento = string.Empty;
        private string _NMonedaDocumento = string.Empty;
        private string _FechaVctoDocumento = string.Empty;
        private decimal _VentaTipoCambio = 0;
        private decimal _VentaEurTipoCambio = 0;        
        private decimal _PorcentajeIgv = 0;
        private decimal _ImporteOriginalCuentaCorriente = 0;
        private decimal _ImportePagadoCuentaCorriente = 0;
        private decimal _SaldoCuentaCorriente = 0;
        private string _CodigoCuenta = string.Empty;
        private string _DescripcionCuenta = string.Empty;
        private string _CEstadoCuentaCorriente = "1";
        private string _NEstadoCuentaCorriente = "Activo";
        private string _UsuarioAgrega = string.Empty;
        private DateTime _FechaAgrega;
        private string _UsuarioModifica = string.Empty;
        private DateTime _FechaModifica;
        private Adicional _Adicionales = new Adicional();

        public string ClaveObjeto
        {
            get { return this._ClaveObjeto; }
            set { this._ClaveObjeto = value; }
        }

        public string ClaveCuentaCorriente
        {
            get { return this._ClaveCuentaCorriente; }
            set { this._ClaveCuentaCorriente = value; }
        }

        public string ClaveDocumentoCuentaCorriente
        {
            get { return this._ClaveDocumentoCuentaCorriente; }
            set { this._ClaveDocumentoCuentaCorriente = value; }
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

        public string NumeroVoucherRegContabCabe
        {
            get { return this._NumeroVoucherRegContabCabe; }
            set { this._NumeroVoucherRegContabCabe = value; }
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

        public string FechaVctoDocumento
        {
            get { return this._FechaVctoDocumento; }
            set { this._FechaVctoDocumento = value; }
        }

        public decimal VentaTipoCambio
        {
            get { return this._VentaTipoCambio; }
            set { this._VentaTipoCambio = value; }
        }

        public decimal VentaEurTipoCambio
        {
            get { return this._VentaEurTipoCambio; }
            set { this._VentaEurTipoCambio = value; }
        }

        public decimal PorcentajeIgv
        {
            get { return this._PorcentajeIgv; }
            set { this._PorcentajeIgv = value; }
        }

        public decimal ImporteOriginalCuentaCorriente
        {
            get { return this._ImporteOriginalCuentaCorriente; }
            set { this._ImporteOriginalCuentaCorriente = value; }
        }

        public decimal ImportePagadoCuentaCorriente
        {
            get { return this._ImportePagadoCuentaCorriente; }
            set { this._ImportePagadoCuentaCorriente = value; }
        }

        public decimal SaldoCuentaCorriente
        {
            get { return this._SaldoCuentaCorriente; }
            set { this._SaldoCuentaCorriente = value; }
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
        
        public string CEstadoCuentaCorriente
        {
            get { return this._CEstadoCuentaCorriente; }
            set { this._CEstadoCuentaCorriente = value; }
        }
        
        public string NEstadoCuentaCorriente
        {
            get { return this._NEstadoCuentaCorriente; }
            set { this._NEstadoCuentaCorriente = value; }
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



    }
}
