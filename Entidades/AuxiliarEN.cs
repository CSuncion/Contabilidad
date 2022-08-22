using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades.Adicionales;

namespace Entidades
{
    public class AuxiliarEN
    {

        //campos nombres
        public const string ClaObj = "ClaveObjeto";
        public const string ClaAux = "ClaveAuxiliar";
        public const string CodEmp = "CodigoEmpresa";
        public const string NomEmp = "NombreEmpresa";
        public const string CodAux = "CodigoAuxiliar";
        public const string ApePatAux = "ApellidoPaternoAuxiliar";
        public const string ApeMatAux = "ApellidoMaternoAuxiliar";
        public const string PriNomAux = "PrimerNombreAuxiliar";
        public const string SegNomAux = "SegundoNombreAuxiliar";
        public const string DesAux = "DescripcionAuxiliar";
        public const string DirAux = "DireccionAuxiliar";
        public const string TelAux = "TelefonoAuxiliar";
        public const string CelAux = "CelularAuxiliar";
        public const string CorAux = "CorreoAuxiliar";
        public const string RefAux = "ReferenciaAuxiliar";
        public const string CClaAux = "CClaseAuxiliar";
        public const string NClaAux = "NClaseAuxiliar";
        public const string CTipAux = "CTipoAuxiliar";
        public const string NTipAux = "NTipoAuxiliar";
        public const string CTipDocAux = "CTipoDocumentoAuxiliar";
        public const string NTipDocAux = "NTipoDocumentoAuxiliar";
        public const string CPaiNoDomAux = "CPaisNoDomiciliadoAuxiliar";
        public const string NPaiNoDomAux = "NPaisNoDomiciliadoAuxiliar";
        public const string FecInsSnpAux = "FechaInscripcionSnpAuxiliar";
        public const string VerFal = "VerdadFalso";
        public const string COriVenCre = "COrigenVentanaCreacion";
        public const string NOriVenCre = "NOrigenVentanaCreacion";
        public const string CEstAux = "CEstadoAuxiliar";
        public const string NEstAux = "NEstadoAuxiliar";
        public const string UsuAgr = "UsuarioAgrega";
        public const string FecAgr = "FechaAgrega";
        public const string UsuMod = "UsuarioModifica";
        public const string FecMod = "FechaModifica";

        //atributos
        private string _ClaveObjeto = string.Empty;
        private string _ClaveAuxiliar = string.Empty;
        private string _CodigoEmpresa = string.Empty;
        private string _NombreEmpresa = string.Empty;
        private string _CodigoAuxiliar = string.Empty;
        private string _ApellidoPaternoAuxiliar = string.Empty;
        private string _ApellidoMaternoAuxiliar = string.Empty;
        private string _PrimerNombreAuxiliar = string.Empty;
        private string _SegundoNombreAuxiliar = string.Empty;
        private string _DescripcionAuxiliar = string.Empty;
        private string _DireccionAuxiliar = string.Empty;
        private string _TelefonoAuxiliar = string.Empty;
        private string _CelularAuxiliar = string.Empty;
        private string _CorreoAuxiliar = string.Empty;
        private string _ReferenciaAuxiliar = string.Empty;
        private string _CClaseAuxiliar = "1";
        private string _NClaseAuxiliar = "JURIDICO";
        private string _CTipoAuxiliar = "0";
        private string _NTipoAuxiliar = "CLIENTE";
        private string _CTipoDocumentoAuxiliar = "6";
        private string _NTipoDocumentoAuxiliar = "RUC";
        private string _CPaisNoDomiciliadoAuxiliar = string.Empty;
        private string _NPaisNoDomiciliadoAuxiliar = string.Empty;
        private string _FechaInscripcionSnpAuxiliar = string.Empty;
        private bool _VerdadFalso = false;
        private string _COrigenVentanaCreacion = "01";
        private string _NOrigenVentanaCreacion = "Ventana Editar";
        private string _CEstadoAuxiliar = "1";
        private string _NEstadoAuxiliar = "Activo";
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

        public string ClaveAuxiliar
        {
            get { return this._ClaveAuxiliar; }
            set { this._ClaveAuxiliar = value; }
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

        public string CodigoAuxiliar
        {
            get { return this._CodigoAuxiliar; }
            set { this._CodigoAuxiliar = value; }
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

        public string DescripcionAuxiliar
        {
            get { return this._DescripcionAuxiliar; }
            set { this._DescripcionAuxiliar = value; }
        }

        public string DireccionAuxiliar
        {
            get { return this._DireccionAuxiliar; }
            set { this._DireccionAuxiliar = value; }
        }

        public string TelefonoAuxiliar
        {
            get { return this._TelefonoAuxiliar; }
            set { this._TelefonoAuxiliar = value; }
        }

        public string CelularAuxiliar
        {
            get { return this._CelularAuxiliar; }
            set { this._CelularAuxiliar = value; }
        }

        public string CorreoAuxiliar
        {
            get { return this._CorreoAuxiliar; }
            set { this._CorreoAuxiliar = value; }
        }

        public string ReferenciaAuxiliar
        {
            get { return this._ReferenciaAuxiliar; }
            set { this._ReferenciaAuxiliar = value; }
        }

        public string CClaseAuxiliar
        {
            get { return this._CClaseAuxiliar; }
            set { this._CClaseAuxiliar = value; }
        }

        public string NClaseAuxiliar
        {
            get { return this._NClaseAuxiliar; }
            set { this._NClaseAuxiliar = value; }
        }

        public string CTipoAuxiliar
        {
            get { return this._CTipoAuxiliar; }
            set { this._CTipoAuxiliar = value; }
        }

        public string NTipoAuxiliar
        {
            get { return this._NTipoAuxiliar; }
            set { this._NTipoAuxiliar = value; }
        }

        public string CTipoDocumentoAuxiliar
        {
            get { return this._CTipoDocumentoAuxiliar; }
            set { this._CTipoDocumentoAuxiliar = value; }
        }

        public string NTipoDocumentoAuxiliar
        {
            get { return this._NTipoDocumentoAuxiliar; }
            set { this._NTipoDocumentoAuxiliar = value; }
        }

        public string CPaisNoDomiciliadoAuxiliar
        {
            get { return this._CPaisNoDomiciliadoAuxiliar; }
            set { this._CPaisNoDomiciliadoAuxiliar = value; }
        }

        public string NPaisNoDomiciliadoAuxiliar
        {
            get { return this._NPaisNoDomiciliadoAuxiliar; }
            set { this._NPaisNoDomiciliadoAuxiliar = value; }
        }

        public string FechaInscripcionSnpAuxiliar
        {
            get { return this._FechaInscripcionSnpAuxiliar; }
            set { this._FechaInscripcionSnpAuxiliar = value; }
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

        public string CEstadoAuxiliar
        {
            get { return this._CEstadoAuxiliar; }
            set { this._CEstadoAuxiliar = value; }
        }

        public string NEstadoAuxiliar
        {
            get { return this._NEstadoAuxiliar; }
            set { this._NEstadoAuxiliar = value; }
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
