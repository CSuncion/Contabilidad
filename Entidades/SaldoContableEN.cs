using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades.Adicionales;

namespace Entidades
{
    public class SaldoContableEN
    {

        #region Nombre Campos

        public const string ClaObj = "ClaveObjeto";
        public const string ClaSalCon = "ClaveSaldoContable";
        public const string CodEmp = "CodigoEmpresa";
        public const string NomEmp = "NombreEmpresa";
        public const string AñoSalCon = "AñoSaldoContable";
        public const string CodCue = "CodigoCuenta";
        public const string DesCue = "DescripcionCuenta";
        public const string NumDigAna = "NumeroDigitosAnalitica";
        public const string CodForCon = "CodigoFormatoContable";
        public const string DesForCon = "DescripcionFormatoContable";
        public const string DebSol00 = "DebeSol00";
        public const string HabSol00 = "HaberSol00";
        public const string DebSol01 = "DebeSol01";
        public const string HabSol01 = "HaberSol01";
        public const string DebSol02 = "DebeSol02";
        public const string HabSol02 = "HaberSol02";
        public const string DebSol03 = "DebeSol03";
        public const string HabSol03 = "HaberSol03";
        public const string DebSol04 = "DebeSol04";
        public const string HabSol04 = "HaberSol04";
        public const string DebSol05 = "DebeSol05";
        public const string HabSol05 = "HaberSol05";
        public const string DebSol06 = "DebeSol06";
        public const string HabSol06 = "HaberSol06";
        public const string DebSol07 = "DebeSol07";
        public const string HabSol07 = "HaberSol07";
        public const string DebSol08 = "DebeSol08";
        public const string HabSol08 = "HaberSol08";
        public const string DebSol09 = "DebeSol09";
        public const string HabSol09 = "HaberSol09";
        public const string DebSol10 = "DebeSol10";
        public const string HabSol10 = "HaberSol10";
        public const string DebSol11 = "DebeSol11";
        public const string HabSol11 = "HaberSol11";
        public const string DebSol12 = "DebeSol12";
        public const string HabSol12 = "HaberSol12";
        public const string DebSol13 = "DebeSol13";
        public const string HabSol13 = "HaberSol13";
        public const string DebDol00 = "DebeDol00";
        public const string HabDol00 = "HaberDol00";
        public const string DebDol01 = "DebeDol01";
        public const string HabDol01 = "HaberDol01";
        public const string DebDol02 = "DebeDol02";
        public const string HabDol02 = "HaberDol02";
        public const string DebDol03 = "DebeDol03";
        public const string HabDol03 = "HaberDol03";
        public const string DebDol04 = "DebeDol04";
        public const string HabDol04 = "HaberDol04";
        public const string DebDol05 = "DebeDol05";
        public const string HabDol05 = "HaberDol05";
        public const string DebDol06 = "DebeDol06";
        public const string HabDol06 = "HaberDol06";
        public const string DebDol07 = "DebeDol07";
        public const string HabDol07 = "HaberDol07";
        public const string DebDol08 = "DebeDol08";
        public const string HabDol08 = "HaberDol08";
        public const string DebDol09 = "DebeDol09";
        public const string HabDol09 = "HaberDol09";
        public const string DebDol10 = "DebeDol10";
        public const string HabDol10 = "HaberDol10";
        public const string DebDol11 = "DebeDol11";
        public const string HabDol11 = "HaberDol11";
        public const string DebDol12 = "DebeDol12";
        public const string HabDol12 = "HaberDol12";
        public const string DebDol13 = "DebeDol13";
        public const string HabDol13 = "HaberDol13";
        public const string UsuAgr = "UsuarioAgrega";
        public const string FecAgr = "FechaAgrega";
        public const string UsuMod = "UsuarioModifica";
        public const string FecMod = "FechaModifica";

        #endregion

        #region Atributos

        private string _ClaveObjeto = string.Empty;
        private string _ClaveSaldoContable = string.Empty;
        private string _CodigoEmpresa = string.Empty;
        private string _NombreEmpresa = string.Empty;
        private string _AñoSaldoContable = string.Empty;
        private string _CodigoCuenta = string.Empty;
        private string _DescripcionCuenta = string.Empty;
        private string _NumeroDigitosAnalitica = string.Empty;
        private string _CodigoFormatoContable = string.Empty;
        private string _DescripcionFormatoContable = string.Empty;
        private decimal _DebeSol00 = 0;
        private decimal _HaberSol00 = 0;
        private decimal _DebeSol01 = 0;
        private decimal _HaberSol01 = 0;
        private decimal _DebeSol02 = 0;
        private decimal _HaberSol02 = 0;
        private decimal _DebeSol03 = 0;
        private decimal _HaberSol03 = 0;
        private decimal _DebeSol04 = 0;
        private decimal _HaberSol04 = 0;
        private decimal _DebeSol05 = 0;
        private decimal _HaberSol05 = 0;
        private decimal _DebeSol06 = 0;
        private decimal _HaberSol06 = 0;
        private decimal _DebeSol07 = 0;
        private decimal _HaberSol07 = 0;
        private decimal _DebeSol08 = 0;
        private decimal _HaberSol08 = 0;
        private decimal _DebeSol09 = 0;
        private decimal _HaberSol09 = 0;
        private decimal _DebeSol10 = 0;
        private decimal _HaberSol10 = 0;
        private decimal _DebeSol11 = 0;
        private decimal _HaberSol11 = 0;
        private decimal _DebeSol12 = 0;
        private decimal _HaberSol12 = 0;
        private decimal _DebeSol13 = 0;
        private decimal _HaberSol13 = 0;
        private decimal _DebeDol00 = 0;
        private decimal _HaberDol00 = 0;
        private decimal _DebeDol01 = 0;
        private decimal _HaberDol01 = 0;
        private decimal _DebeDol02 = 0;
        private decimal _HaberDol02 = 0;
        private decimal _DebeDol03 = 0;
        private decimal _HaberDol03 = 0;
        private decimal _DebeDol04 = 0;
        private decimal _HaberDol04 = 0;
        private decimal _DebeDol05 = 0;
        private decimal _HaberDol05 = 0;
        private decimal _DebeDol06 = 0;
        private decimal _HaberDol06 = 0;
        private decimal _DebeDol07 = 0;
        private decimal _HaberDol07 = 0;
        private decimal _DebeDol08 = 0;
        private decimal _HaberDol08 = 0;
        private decimal _DebeDol09 = 0;
        private decimal _HaberDol09 = 0;
        private decimal _DebeDol10 = 0;
        private decimal _HaberDol10 = 0;
        private decimal _DebeDol11 = 0;
        private decimal _HaberDol11 = 0;
        private decimal _DebeDol12 = 0;
        private decimal _HaberDol12 = 0;
        private decimal _DebeDol13 = 0;
        private decimal _HaberDol13 = 0;
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

        public string ClaveSaldoContable
        {
            get { return this._ClaveSaldoContable; }
            set { this._ClaveSaldoContable = value; }
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

        public string AñoSaldoContable
        {
            get { return this._AñoSaldoContable; }
            set { this._AñoSaldoContable = value; }
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

        public string NumeroDigitosAnalitica
        {
            get { return this._NumeroDigitosAnalitica; }
            set { this._NumeroDigitosAnalitica = value; }
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

        public decimal DebeSol00
        {
            get { return this._DebeSol00; }
            set { this._DebeSol00 = value; }
        }

        public decimal HaberSol00
        {
            get { return this._HaberSol00; }
            set { this._HaberSol00 = value; }
        }

        public decimal DebeSol01
        {
            get { return this._DebeSol01; }
            set { this._DebeSol01 = value; }
        }

        public decimal HaberSol01
        {
            get { return this._HaberSol01; }
            set { this._HaberSol01 = value; }
        }

        public decimal DebeSol02
        {
            get { return this._DebeSol02; }
            set { this._DebeSol02 = value; }
        }

        public decimal HaberSol02
        {
            get { return this._HaberSol02; }
            set { this._HaberSol02 = value; }
        }

        public decimal DebeSol03
        {
            get { return this._DebeSol03; }
            set { this._DebeSol03 = value; }
        }

        public decimal HaberSol03
        {
            get { return this._HaberSol03; }
            set { this._HaberSol03 = value; }
        }

        public decimal DebeSol04
        {
            get { return this._DebeSol04; }
            set { this._DebeSol04 = value; }
        }

        public decimal HaberSol04
        {
            get { return this._HaberSol04; }
            set { this._HaberSol04 = value; }
        }

        public decimal DebeSol05
        {
            get { return this._DebeSol05; }
            set { this._DebeSol05 = value; }
        }

        public decimal HaberSol05
        {
            get { return this._HaberSol05; }
            set { this._HaberSol05 = value; }
        }

        public decimal DebeSol06
        {
            get { return this._DebeSol06; }
            set { this._DebeSol06 = value; }
        }

        public decimal HaberSol06
        {
            get { return this._HaberSol06; }
            set { this._HaberSol06 = value; }
        }

        public decimal DebeSol07
        {
            get { return this._DebeSol07; }
            set { this._DebeSol07 = value; }
        }

        public decimal HaberSol07
        {
            get { return this._HaberSol07; }
            set { this._HaberSol07 = value; }
        }

        public decimal DebeSol08
        {
            get { return this._DebeSol08; }
            set { this._DebeSol08 = value; }
        }

        public decimal HaberSol08
        {
            get { return this._HaberSol08; }
            set { this._HaberSol08 = value; }
        }

        public decimal DebeSol09
        {
            get { return this._DebeSol09; }
            set { this._DebeSol09 = value; }
        }

        public decimal HaberSol09
        {
            get { return this._HaberSol09; }
            set { this._HaberSol09 = value; }
        }

        public decimal DebeSol10
        {
            get { return this._DebeSol10; }
            set { this._DebeSol10 = value; }
        }

        public decimal HaberSol10
        {
            get { return this._HaberSol10; }
            set { this._HaberSol10 = value; }
        }

        public decimal DebeSol11
        {
            get { return this._DebeSol11; }
            set { this._DebeSol11 = value; }
        }

        public decimal HaberSol11
        {
            get { return this._HaberSol11; }
            set { this._HaberSol11 = value; }
        }

        public decimal DebeSol12
        {
            get { return this._DebeSol12; }
            set { this._DebeSol12 = value; }
        }

        public decimal HaberSol12
        {
            get { return this._HaberSol12; }
            set { this._HaberSol12 = value; }
        }

        public decimal DebeSol13
        {
            get { return this._DebeSol13; }
            set { this._DebeSol13 = value; }
        }

        public decimal HaberSol13
        {
            get { return this._HaberSol13; }
            set { this._HaberSol13 = value; }
        }

        public decimal DebeDol00
        {
            get { return this._DebeDol00; }
            set { this._DebeDol00 = value; }
        }

        public decimal HaberDol00
        {
            get { return this._HaberDol00; }
            set { this._HaberDol00 = value; }
        }

        public decimal DebeDol01
        {
            get { return this._DebeDol01; }
            set { this._DebeDol01 = value; }
        }

        public decimal HaberDol01
        {
            get { return this._HaberDol01; }
            set { this._HaberDol01 = value; }
        }

        public decimal DebeDol02
        {
            get { return this._DebeDol02; }
            set { this._DebeDol02 = value; }
        }

        public decimal HaberDol02
        {
            get { return this._HaberDol02; }
            set { this._HaberDol02 = value; }
        }

        public decimal DebeDol03
        {
            get { return this._DebeDol03; }
            set { this._DebeDol03 = value; }
        }

        public decimal HaberDol03
        {
            get { return this._HaberDol03; }
            set { this._HaberDol03 = value; }
        }

        public decimal DebeDol04
        {
            get { return this._DebeDol04; }
            set { this._DebeDol04 = value; }
        }

        public decimal HaberDol04
        {
            get { return this._HaberDol04; }
            set { this._HaberDol04 = value; }
        }

        public decimal DebeDol05
        {
            get { return this._DebeDol05; }
            set { this._DebeDol05 = value; }
        }

        public decimal HaberDol05
        {
            get { return this._HaberDol05; }
            set { this._HaberDol05 = value; }
        }

        public decimal DebeDol06
        {
            get { return this._DebeDol06; }
            set { this._DebeDol06 = value; }
        }

        public decimal HaberDol06
        {
            get { return this._HaberDol06; }
            set { this._HaberDol06 = value; }
        }

        public decimal DebeDol07
        {
            get { return this._DebeDol07; }
            set { this._DebeDol07 = value; }
        }

        public decimal HaberDol07
        {
            get { return this._HaberDol07; }
            set { this._HaberDol07 = value; }
        }

        public decimal DebeDol08
        {
            get { return this._DebeDol08; }
            set { this._DebeDol08 = value; }
        }

        public decimal HaberDol08
        {
            get { return this._HaberDol08; }
            set { this._HaberDol08 = value; }
        }

        public decimal DebeDol09
        {
            get { return this._DebeDol09; }
            set { this._DebeDol09 = value; }
        }

        public decimal HaberDol09
        {
            get { return this._HaberDol09; }
            set { this._HaberDol09 = value; }
        }

        public decimal DebeDol10
        {
            get { return this._DebeDol10; }
            set { this._DebeDol10 = value; }
        }

        public decimal HaberDol10
        {
            get { return this._HaberDol10; }
            set { this._HaberDol10 = value; }
        }

        public decimal DebeDol11
        {
            get { return this._DebeDol11; }
            set { this._DebeDol11 = value; }
        }

        public decimal HaberDol11
        {
            get { return this._HaberDol11; }
            set { this._HaberDol11 = value; }
        }

        public decimal DebeDol12
        {
            get { return this._DebeDol12; }
            set { this._DebeDol12 = value; }
        }

        public decimal HaberDol12
        {
            get { return this._HaberDol12; }
            set { this._HaberDol12 = value; }
        }

        public decimal DebeDol13
        {
            get { return this._DebeDol13; }
            set { this._DebeDol13 = value; }
        }

        public decimal HaberDol13
        {
            get { return this._HaberDol13; }
            set { this._HaberDol13 = value; }
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
