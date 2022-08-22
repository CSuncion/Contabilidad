using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades.Adicionales;

namespace Entidades
{
    public class TipoCambioEN
    {

        //campos nombres
        public const string ClaObj = "ClaveObjeto";
        public const string FecTipCam = "FechaTipoCambio";
        public const string AñoTipCam = "AñoTipoCambio";
        public const string CMesTipCam = "CMesTipoCambio";
        public const string NMesTipCam = "NMesTipoCambio";
        public const string PerTipCam = "PeriodoTipoCambio";
        public const string ComUsTipCam = "CompraUsTipoCambio";
        public const string VenUsTipCam = "VentaUsTipoCambio";
        public const string ComCadTipCam = "CompraCadTipoCambio";
        public const string VenCadTipCam = "VentaCadTipoCambio";
        public const string ComEurTipCam = "CompraEurTipoCambio";
        public const string VenEurTipCam = "VentaEurTipoCambio";
        public const string CEstTipCam = "CEstadoTipoCambio";
        public const string NEstTipCam = "NEstadoTipoCambio";
        public const string UsuAgr = "UsuarioAgrega";
        public const string FecAgr = "FechaAgrega";
        public const string UsuMod = "UsuarioModifica";
        public const string FecMod = "FechaModifica";

        //atributos
        private string _ClaveObjeto = string.Empty;
        private string _FechaTipoCambio = string.Empty;
        private string _AñoTipoCambio = string.Empty;
        private string _CMesTipoCambio = string.Empty;
        private string _NMesTipoCambio = string.Empty;
        private string _PeriodoTipoCambio = string.Empty;
        private decimal _CompraUsTipoCambio = 0;
        private decimal _VentaUsTipoCambio = 0;
        private decimal _CompraCadTipoCambio = 0;
        private decimal _VentaCadTipoCambio = 0;
        private decimal _CompraEurTipoCambio = 0;
        private decimal _VentaEurTipoCambio = 0;
        private string _CEstadoTipoCambio = "1";
        private string _NEstadoTipoCambio = "Activo";
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

        public string FechaTipoCambio
        {
            get { return this._FechaTipoCambio; }
            set { this._FechaTipoCambio = value; }
        }

        public string AñoTipoCambio
        {
            get { return this._AñoTipoCambio; }
            set { this._AñoTipoCambio = value; }
        }

        public string CMesTipoCambio
        {
            get { return this._CMesTipoCambio; }
            set { this._CMesTipoCambio = value; }
        }
        
        public string NMesTipoCambio
        {
            get { return this._NMesTipoCambio; }
            set { this._NMesTipoCambio = value; }
        }

        public string PeriodoTipoCambio
        {
            get { return this._PeriodoTipoCambio; }
            set { this._PeriodoTipoCambio = value; }
        }

        public decimal CompraUsTipoCambio
        {
            get { return this._CompraUsTipoCambio; }
            set { this._CompraUsTipoCambio = value; }
        }

        public decimal VentaUsTipoCambio
        {
            get { return this._VentaUsTipoCambio; }
            set { this._VentaUsTipoCambio = value; }
        }

        public decimal CompraCadTipoCambio
        {
            get { return this._CompraCadTipoCambio; }
            set { this._CompraCadTipoCambio = value; }
        }

        public decimal VentaCadTipoCambio
        {
            get { return this._VentaCadTipoCambio; }
            set { this._VentaCadTipoCambio = value; }
        }

        public decimal CompraEurTipoCambio
        {
            get { return this._CompraEurTipoCambio; }
            set { this._CompraEurTipoCambio = value; }
        }

        public decimal VentaEurTipoCambio
        {
            get { return this._VentaEurTipoCambio; }
            set { this._VentaEurTipoCambio = value; }
        }

        public string CEstadoTipoCambio
        {
            get { return this._CEstadoTipoCambio; }
            set { this._CEstadoTipoCambio = value; }
        }
        
        public string NEstadoTipoCambio
        {
            get { return this._NEstadoTipoCambio; }
            set { this._NEstadoTipoCambio = value; }
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
