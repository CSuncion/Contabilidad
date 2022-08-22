using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades.Adicionales;

namespace Entidades
{
    public class ParametroEN
    {
        //campo nombres     
        public const string RutLogEmp = "RutaLogoEmpresa";
        public const string PorIgv = "PorcentajeIgv";       
        public const string NomSol = "NombreSoles";
        public const string NomDol = "NombreDolares";
        public const string TipOpeTraIng = "TipoOperacionTransferenciaIngreso";
        public const string TipOpeTraSal = "TipoOperacionTransferenciaSalida";
        public const string TipOpeProSal = "TipoOperacionProduccionSalida";
        public const string TipOpeProIng = "TipoOperacionProduccionIngreso";
        public const string CenCosPro = "CentroCostoProduccion";
        public const string UsuAgr = "UsuarioAgrega";
        public const string FecAgr = "FechaAgrega";
        public const string UsuMod = "UsuarioModifica";
        public const string FecMod = "FechaModifica";

        //atributos      
        private string _RutaLogoEmpresa = string.Empty;
        private decimal _PorcentajeIgv = 0;       
        private string _NombreSoles = string.Empty;
        private string _NombreDolares = string.Empty;
        private string _TipoOperacionTransferenciaIngreso = string.Empty;
        private string _TipoOperacionTransferenciaSalida = string.Empty;
        private string _TipoOperacionProduccionSalida = string.Empty;
        private string _TipoOperacionProduccionIngreso = string.Empty;
        private string _CentroCostoProduccion = string.Empty;
        private string _UsuarioAgrega;
        private DateTime _FechaAgrega;
        private string _UsuarioModifica;
        private DateTime _FechaModifica;
        private Adicional _Adicionales = new Adicional();

        //propiedades
      
        public string RutaLogoEmpresa
        {
            get { return this._RutaLogoEmpresa; }
            set { this._RutaLogoEmpresa = value; }
        }

        public decimal PorcentajeIgv
        {
            get { return this._PorcentajeIgv; }
            set { this._PorcentajeIgv = value; }
        }

        public string NombreSoles
        {
            get { return this._NombreSoles; }
            set { this._NombreSoles = value; }
        }

        public string NombreDolares
        {
            get { return this._NombreDolares; }
            set { this._NombreDolares = value; }
        }

        public string TipoOperacionTransferenciaIngreso
        {
            get { return this._TipoOperacionTransferenciaIngreso; }
            set { this._TipoOperacionTransferenciaIngreso = value; }
        }

        public string TipoOperacionTransferenciaSalida
        {
            get { return this._TipoOperacionTransferenciaSalida; }
            set { this._TipoOperacionTransferenciaSalida = value; }
        }

        public string TipoOperacionProduccionSalida
        {
            get { return this._TipoOperacionProduccionSalida; }
            set { this._TipoOperacionProduccionSalida = value; }
        }

        public string TipoOperacionProduccionIngreso
        {
            get { return this._TipoOperacionProduccionIngreso; }
            set { this._TipoOperacionProduccionIngreso = value; }
        }

        public string CentroCostoProduccion
        {
            get { return this._CentroCostoProduccion; }
            set { this._CentroCostoProduccion = value; }
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
