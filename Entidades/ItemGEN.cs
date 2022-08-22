using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades.Adicionales;


namespace Entidades
{
    public class ItemGEN
    {
        #region Nombre Campos 

        public const string ClaObj = "ClaveObjeto";
        public const string ClaIteG = "ClaveItemG";
        public const string CodTab = "CodigoTabla";
        public const string NomTab = "NombreTabla";
        public const string CodIteG = "CodigoItemG";
        public const string NomIteG = "NombreItemG";
        public const string AbrIteG = "AbreviaItemG";
        public const string CEstIteG = "CEstadoItemG";
        public const string NEstIteG = "NEstadoItemG";
        public const string UsuAgr = "UsuarioAgrega";
        public const string FecAgr = "FechaAgrega";
        public const string UsuMod = "UsuarioModifica";
        public const string FecMod = "FechaModifica";

        #endregion

        #region Atributos

        private string _ClaveObjeto = string.Empty;
        private string _ClaveItemG = string.Empty;
        private string _CodigoTabla = string.Empty;
        private string _NombreTabla = string.Empty;
        private string _CodigoItemG = string.Empty;
        private string _NombreItemG = string.Empty;
        private string _AbreviaItemG = string.Empty;
        private string _CEstadoItemG = "1";//activado
        private string _NEstadoItemG = string.Empty;
        private string _UsuarioAgrega;
        private DateTime _FechaAgrega;
        private string _UsuarioModifica;
        private DateTime _FechaModifica;
        private Adicional _Adicionales = new Adicional();

        #endregion

        #region Propiedades


        public string ClaveObjeto
        {
            get { return this._ClaveObjeto; }
            set { this._ClaveObjeto = value; }
        }

        public string ClaveItemG
        {
            get { return this._ClaveItemG; }
            set { this._ClaveItemG = value; }
        }

        public string CodigoTabla
        {
            get { return this._CodigoTabla; }
            set { this._CodigoTabla = value; }
        }

        public string NombreTabla
        {
            get { return this._NombreTabla; }
            set { this._NombreTabla = value; }
        }

        public string CodigoItemG
        {
            get { return this._CodigoItemG; }
            set { this._CodigoItemG = value; }
        }

        public string NombreItemG
        {
            get { return this._NombreItemG; }
            set { this._NombreItemG = value; }
        }

        public string AbreviaItemG
        {
            get { return this._AbreviaItemG; }
            set { this._AbreviaItemG = value; }
        }

        public string CEstadoItemG
        {
            get { return this._CEstadoItemG; }
            set { this._CEstadoItemG = value; }
        }

        public string NEstadoItemG
        {
            get { return this._NEstadoItemG; }
            set { this._NEstadoItemG = value; }
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

        #region ValoresCampo

        #region items(DebeHaber)

        public const string DebeHaber_Debe = "0";
        public const string DebeHaber_Haber = "1";
        
        #endregion

        #region items(TipoLineaAsiento)

        public const string TipoLineaAsiento_Editado = "0";
        public const string TipoLineaAsiento_CompletaAsiento = "1";
        public const string TipoLineaAsiento_AsientoAutomatico = "2";         

        #endregion

        #region items(TipoNota)

        public const string TipoNota_Credito = "0";
        public const string TipoNota_Debito = "1";

        #endregion

        #region items(TipoCompra)

        public const string TipoCompra_Normal = "0";
        public const string TipoCompra_Especial = "1";

        #endregion

        #region items(Registro)

        public const string Registro_CompraPV = "0";
        public const string Registro_CompraVV = "1";
        public const string Registro_VentaPV = "2";
        public const string Registro_VentaVV = "3";

        #endregion

        #endregion

    }
}
