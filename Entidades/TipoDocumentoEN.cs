using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades.Adicionales;

namespace Entidades
{
    public class TipoDocumentoEN
    {

        #region Nombre Campos

        public const string ClaObj = "ClaveObjeto";
        public const string CodTipDoc = "CodigoTipoDocumento";
        public const string DesTipDoc = "DescripcionTipoDocumento";
        public const string CAplEnReg = "CAplicaEnRegistro";
        public const string NAplEnReg = "NAplicaEnRegistro";
        public const string CAplDocRef = "CAplicaDocumentoRef";
        public const string NAplDocRef = "NAplicaDocumentoRef";
        public const string CTipNot = "CTipoNota";
        public const string NTipNot = "NTipoNota";
        public const string CEstTipDoc = "CEstadoTipoDocumento";
        public const string NEstTipDoc = "NEstadoTipoDocumento";
        public const string UsuAgr = "UsuarioAgrega";
        public const string FecAgr = "FechaAgrega";
        public const string UsuMod = "UsuarioModifica";
        public const string FecMod = "FechaModifica";

        #endregion

        #region Atributos

        private string _ClaveObjeto = string.Empty;
        private string _CodigoTipoDocumento = string.Empty;
        private string _DescripcionTipoDocumento = string.Empty;
        private string _CAplicaEnRegistro = string.Empty;
        private string _NAplicaEnRegistro = string.Empty;
        private string _CAplicaDocumentoRef = "0";
        private string _NAplicaDocumentoRef = "No";
        private string _CTipoNota = string.Empty;
        private string _NTipoNota = string.Empty;
        private string _CEstadoTipoDocumento = "1";
        private string _NEstadoTipoDocumento = "Activado";
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

        public string CodigoTipoDocumento
        {
            get { return this._CodigoTipoDocumento; }
            set { this._CodigoTipoDocumento = value; }
        }

        public string DescripcionTipoDocumento
        {
            get { return this._DescripcionTipoDocumento; }
            set { this._DescripcionTipoDocumento = value; }
        }

        public string CAplicaEnRegistro
        {
            get { return this._CAplicaEnRegistro; }
            set { this._CAplicaEnRegistro = value; }
        }

        public string NAplicaEnRegistro
        {
            get { return this._NAplicaEnRegistro; }
            set { this._NAplicaEnRegistro = value; }
        }

        public string CAplicaDocumentoRef
        {
            get { return this._CAplicaDocumentoRef; }
            set { this._CAplicaDocumentoRef = value; }
        }

        public string NAplicaDocumentoRef
        {
            get { return this._NAplicaDocumentoRef; }
            set { this._NAplicaDocumentoRef = value; }
        }

        public string CTipoNota
        {
            get { return this._CTipoNota; }
            set { this._CTipoNota = value; }
        }

        public string NTipoNota
        {
            get { return this._NTipoNota; }
            set { this._NTipoNota = value; }
        }

        public string CEstadoTipoDocumento
        {
            get { return this._CEstadoTipoDocumento; }
            set { this._CEstadoTipoDocumento = value; }
        }

        public string NEstadoTipoDocumento
        {
            get { return this._NEstadoTipoDocumento; }
            set { this._NEstadoTipoDocumento = value; }
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
