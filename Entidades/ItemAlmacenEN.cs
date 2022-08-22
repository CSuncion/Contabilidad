using Entidades.Adicionales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ItemAlmacenEN
    {

        #region Nombre Campos

        public const string ClaObj = "ClaveObjeto";
        public const string ClaIteAlm = "ClaveItemAlmacen";
        public const string CodEmp = "CodigoEmpresa";
        public const string NomEmp = "NombreEmpresa";
        public const string CodAlm = "CodigoAlmacen";
        public const string DesAlm = "DescripcionAlmacen";
        public const string CodIteAlm = "CodigoItemAlmacen";
        public const string DesIteAlm = "DescripcionItemAlmacen";
        public const string CUniMed = "CUnidadMedida";
        public const string NUniMed = "NUnidadMedida";
        public const string VerFal = "VerdadFalso";
        public const string COriVenCre = "COrigenVentanaCreacion";
        public const string NOriVenCre = "NOrigenVentanaCreacion";
        public const string CEstIteAlm = "CEstadoItemAlmacen";
        public const string NEstIteAlm = "NEstadoItemAlmacen";
        public const string UsuAgr = "UsuarioAgrega";
        public const string FecAgr = "FechaAgrega";
        public const string UsuMod = "UsuarioModifica";
        public const string FecMod = "FechaModifica";

        #endregion

        #region Atributos

        private string _ClaveObjeto = string.Empty;
        private string _ClaveItemAlmacen = string.Empty;
        private string _CodigoEmpresa = string.Empty;
        private string _NombreEmpresa = string.Empty;
        private string _CodigoAlmacen = string.Empty;
        private string _DescripcionAlmacen = string.Empty;
        private string _CodigoItemAlmacen = string.Empty;
        private string _DescripcionItemAlmacen = string.Empty;
        private string _CUnidadMedida = string.Empty;
        private string _NUnidadMedida = string.Empty;
        private bool _VerdadFalso = false;
        private string _COrigenVentanaCreacion = "01";
        private string _NOrigenVentanaCreacion = "Ventana Editar";
        private string _CEstadoItemAlmacen ="1";
        private string _NEstadoItemAlmacen = string.Empty;
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

        public string ClaveItemAlmacen
        {
            get { return this._ClaveItemAlmacen; }
            set { this._ClaveItemAlmacen = value; }
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

        public string CUnidadMedida
        {
            get { return this._CUnidadMedida; }
            set { this._CUnidadMedida = value; }
        }

        public string NUnidadMedida
        {
            get { return this._NUnidadMedida; }
            set { this._NUnidadMedida = value; }
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

        public string CEstadoItemAlmacen
        {
            get { return this._CEstadoItemAlmacen; }
            set { this._CEstadoItemAlmacen = value; }
        }

        public string NEstadoItemAlmacen
        {
            get { return this._NEstadoItemAlmacen; }
            set { this._NEstadoItemAlmacen = value; }
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
