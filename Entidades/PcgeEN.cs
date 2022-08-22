using Entidades.Adicionales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class PcgeEN
    {

        #region Nombre Campos

        public const string ClaObj = "ClaveObjeto";
        public const string CodPcg = "CodigoPcge";
        public const string DesPcg = "DescripcionPcge";

        #endregion

        #region Atributos

        private string _ClaveObjeto = string.Empty;
        private string _CodigoPcge = string.Empty;
        private string _DescripcionPcge = string.Empty;
        private Adicional _Adicionales = new Adicional();

        #endregion

        #region Propiedades

        public string ClaveObjeto
        {
            get { return this._ClaveObjeto; }
            set { this._ClaveObjeto = value; }
        }

        public string CodigoPcge
        {
            get { return this._CodigoPcge; }
            set { this._CodigoPcge = value; }
        }

        public string DescripcionPcge
        {
            get { return this._DescripcionPcge; }
            set { this._DescripcionPcge = value; }
        }

        public Adicional Adicionales
        {
            get { return this._Adicionales; }
            set { this._Adicionales = value; }
        }

        #endregion


    }
}
