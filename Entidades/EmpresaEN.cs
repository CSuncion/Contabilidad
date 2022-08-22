using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades.Adicionales;

namespace Entidades
{
    public class EmpresaEN
    {
        //campos nombres   
        public const string ClaObj = "ClaveObjeto";
        public const string CodEmp = "CodigoEmpresa";
        public const string NomEmp = "NombreEmpresa";
        public const string CorEmp = "CorreoEmpresa";
        public const string RucEmp = "RucEmpresa";
        public const string DirEmp = "DireccionEmpresa";
        public const string TelFijEmp = "TelFijoEmpresa";
        public const string TelCelEmp = "TelCelularEmpresa";
        public const string NexEmp = "NextelEmpresa";
        public const string LogEmp = "LogoEmpresa";
        public const string NumDigAna = "NumeroDigitosAnalitica";
        public const string CueAut2 = "CuentaAutomatica2";
        public const string CueIgv = "CuentaIgv";
        public const string FilNotCreCom = "FileNotaCreditoCompra";
        public const string FilNotDebCom = "FileNotaDebitoCompra";
        public const string FilImpCom = "FileImportacionCompra";
        public const string FilDuaCom = "FileDuaCompra";
        public const string FilPerCom = "FilePercepcionCompra";
        public const string CEstEmp = "CEstadoEmpresa";
        public const string NEstEmp = "NEstadoEmpresa";        
        public const string UsuAgr = "UsuarioAgrega";
        public const string FecAgr = "FechaAgrega";
        public const string UsuMod = "UsuarioModifica";
        public const string FecMod = "FechaModifica";

        //atributos
        private string _ClaveObjeto = string.Empty;
        private string _CodigoEmpresa = string.Empty;
        private string _NombreEmpresa = string.Empty;
        private string _CorreoEmpresa = "hotmail.com";
        private string _RucEmpresa = string.Empty;
        private string _DireccionEmpresa = string.Empty;     
        private string _TelFijoEmpresa = string.Empty;
        private string _TelCelularEmpresa = string.Empty;
        private string _NextelEmpresa = string.Empty;
        private string _LogoEmpresa = string.Empty;
        private string _NumeroDigitosAnalitica = "0";
        private string _CuentaAutomatica2 = string.Empty;
        private string _CuentaIgv = string.Empty;
        private string _FileNotaCreditoCompra = string.Empty;
        private string _FileNotaDebitoCompra = string.Empty;
        private string _FileImportacionCompra = string.Empty;
        private string _FileDuaCompra = string.Empty;
        private string _FilePercepcionCompra = string.Empty;
        private string _CEstadoEmpresa = "1";
        private string _NEstadoEmpresa = "ACTIVADO";
        private string _UsuarioAgrega;
        private DateTime _FechaAgrega;
        private string _UsuarioModifica;
        private DateTime _FechaModifica;
        private Adicional _Adicionales = new Adicional();

        //propiedades

        public string ClaveObjeto
        {
            get { return this._ClaveObjeto; }
            set { this._ClaveObjeto = value; }
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

        public string CorreoEmpresa
        {
            get { return this._CorreoEmpresa; }
            set { this._CorreoEmpresa = value; }
        }
        
        public string RucEmpresa
        {
            get { return this._RucEmpresa; }
            set { this._RucEmpresa = value; }
        }
        
        public string DireccionEmpresa
        {
            get { return this._DireccionEmpresa; }
            set { this._DireccionEmpresa = value; }
        }
        
        public string TelFijoEmpresa
        {
            get { return this._TelFijoEmpresa; }
            set { this._TelFijoEmpresa = value; }
        }

        public string TelCelularEmpresa
        {
            get { return this._TelCelularEmpresa; }
            set { this._TelCelularEmpresa = value; }
        }

        public string NextelEmpresa
        {
            get { return this._NextelEmpresa; }
            set { this._NextelEmpresa = value; }
        }

        public string LogoEmpresa
        {
            get { return this._LogoEmpresa; }
            set { this._LogoEmpresa = value; }
        }

        public string NumeroDigitosAnalitica
        {
            get { return this._NumeroDigitosAnalitica; }
            set { this._NumeroDigitosAnalitica = value; }
        }

        public string CuentaAutomatica2
        {
            get { return this._CuentaAutomatica2; }
            set { this._CuentaAutomatica2 = value; }
        }

        public string CuentaIgv
        {
            get { return this._CuentaIgv; }
            set { this._CuentaIgv = value; }
        }

        public string FileNotaCreditoCompra
        {
            get { return this._FileNotaCreditoCompra; }
            set { this._FileNotaCreditoCompra = value; }
        }

        public string FileNotaDebitoCompra
        {
            get { return this._FileNotaDebitoCompra; }
            set { this._FileNotaDebitoCompra = value; }
        }

        public string FileImportacionCompra
        {
            get { return this._FileImportacionCompra; }
            set { this._FileImportacionCompra = value; }
        }

        public string FileDuaCompra
        {
            get { return this._FileDuaCompra; }
            set { this._FileDuaCompra = value; }
        }

        public string FilePercepcionCompra
        {
            get { return this._FilePercepcionCompra; }
            set { this._FilePercepcionCompra = value; }
        }
        
        public string CEstadoEmpresa
        {
            get { return this._CEstadoEmpresa; }
            set { this._CEstadoEmpresa = value; }
        }
        
        public string NEstadoEmpresa
        {
            get { return this._NEstadoEmpresa; }
            set { this._NEstadoEmpresa = value; }
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
