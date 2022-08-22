using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades.Adicionales;

namespace Entidades
{
    public class FormatoContableEN
    {

        #region Nombre Campos

        public const string ClaObj = "ClaveObjeto";
        public const string ClaForCon = "ClaveFormatoContable";
        public const string CodEmp = "CodigoEmpresa";
        public const string NomEmp = "NombreEmpresa";
        public const string CodForCon = "CodigoFormatoContable";
        public const string DesForCon = "DescripcionFormatoContable";
        public const string DesAltForCon = "DescripcionAlternaFormatoContable";
        public const string CGru = "CGrupo";
        public const string NGru = "NGrupo";
        public const string CNat = "CNaturaleza";
        public const string NNat = "NNaturaleza";
        public const string VerFal = "VerdadFalso";
        public const string COriVenCre = "COrigenVentanaCreacion";
        public const string NOriVenCre = "NOrigenVentanaCreacion";
        public const string CEstForCon = "CEstadoFormatoContable";
        public const string NEstForCon = "NEstadoFormatoContable";
        public const string UsuAgr = "UsuarioAgrega";
        public const string FecAgr = "FechaAgrega";
        public const string UsuMod = "UsuarioModifica";
        public const string FecMod = "FechaModifica";

        #endregion

        #region Atributos

        private string _ClaveObjeto = string.Empty;
        private string _ClaveFormatoContable = string.Empty;
        private string _CodigoEmpresa = string.Empty;
        private string _NombreEmpresa = string.Empty;
        private string _CodigoFormatoContable = string.Empty;
        private string _DescripcionFormatoContable = string.Empty;
        private string _DescripcionAlternaFormatoContable = string.Empty;
        private string _CGrupo = string.Empty;
        private string _NGrupo = string.Empty;
        private string _CNaturaleza = string.Empty;
        private string _NNaturaleza = string.Empty;
        private bool _VerdadFalso = false;
        private string _COrigenVentanaCreacion = "01";
        private string _NOrigenVentanaCreacion = "Ventana Editar";
        private string _CEstadoFormatoContable = "1";
        private string _NEstadoFormatoContable = "Activo";
        private string _UsuarioAgrega = string.Empty;
        private DateTime _FechaAgrega = DateTime.Now;
        private string _UsuarioModifica = string.Empty;
        private string _FechaModifica = string.Empty;
        private Adicional _Adicionales = new Adicional();

        #endregion

        #region Propiedades

        public string ClaveObjeto
        {
            get { return this._ClaveObjeto; }
            set { this._ClaveObjeto = value; }
        }

        public string ClaveFormatoContable
        {
            get { return this._ClaveFormatoContable; }
            set { this._ClaveFormatoContable = value; }
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

        public string DescripcionAlternaFormatoContable
        {
            get { return this._DescripcionAlternaFormatoContable; }
            set { this._DescripcionAlternaFormatoContable = value; }
        }

        public string CGrupo
        {
            get { return this._CGrupo; }
            set { this._CGrupo = value; }
        }

        public string NGrupo
        {
            get { return this._NGrupo; }
            set { this._NGrupo = value; }
        }

        public string CNaturaleza
        {
            get { return this._CNaturaleza; }
            set { this._CNaturaleza = value; }
        }

        public string NNaturaleza
        {
            get { return this._NNaturaleza; }
            set { this._NNaturaleza = value; }
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

        public string CEstadoFormatoContable
        {
            get { return this._CEstadoFormatoContable; }
            set { this._CEstadoFormatoContable = value; }
        }

        public string NEstadoFormatoContable
        {
            get { return this._NEstadoFormatoContable; }
            set { this._NEstadoFormatoContable = value; }
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

        public string FechaModifica
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
