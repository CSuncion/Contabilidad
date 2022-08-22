using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comun;
using Entidades;
using Datos;
using Entidades.Adicionales;

namespace Negocio
{
    public class EmpresaRN
    {
        public static object AlmacenRN { get; private set; }

        public static EmpresaEN EnBlanco()
        {
            EmpresaEN iEmpEN = new EmpresaEN();
            return iEmpEN;
        }
        
        public static void AdicionarEmpresa(EmpresaEN pObj)
        {
            EmpresaAD iEmpAD = new EmpresaAD();
            iEmpAD.AgregarEmpresa(pObj);
        }
        
        public static void ModificarEmpresa(EmpresaEN pObj)
        {
            EmpresaAD iEmpAD = new EmpresaAD();
            iEmpAD.ModificarEmpresa(pObj);
        }
        
        public static void EliminarEmpresa(EmpresaEN pObj)
        {
            EmpresaAD iEmpAD = new EmpresaAD();
            iEmpAD.EliminarEmpresa(pObj);
        }
        
        public static EmpresaEN BuscarEmpresaXCodigo(EmpresaEN pObj)
        {
            EmpresaAD iEmpAD = new EmpresaAD();
            return iEmpAD.BuscarEmpresaXCodigo(pObj);
        }

        public static EmpresaEN BuscarEmpresaXCodigo(string pCodigoEmpresa)
        {
            EmpresaEN iEmpEN = new EmpresaEN();
            iEmpEN.CodigoEmpresa = pCodigoEmpresa;
            return EmpresaRN.BuscarEmpresaXCodigo(iEmpEN);
        }

        public static List<EmpresaEN> ListarEmpresas(EmpresaEN pObj)
        {
            EmpresaAD iEmpAD = new EmpresaAD();
            return iEmpAD.ListarEmpresas(pObj);
        }
        
        public static EmpresaEN EsEmpresaExistente(EmpresaEN pObj)
        {
            EmpresaEN iEmpEN = new EmpresaEN();
            iEmpEN = EmpresaRN.BuscarEmpresaXCodigo(pObj);
            if (iEmpEN.CodigoEmpresa == string.Empty)
            {
                iEmpEN.Adicionales.EsVerdad = false;
                iEmpEN.Adicionales.Mensaje = "La Empresa " + pObj.CodigoEmpresa + " : " + pObj.NombreEmpresa + " no existe";
            }
            else
            {
                iEmpEN.Adicionales.EsVerdad = true;
            }
            return iEmpEN;
        }
        
        public static EmpresaEN EsCodigoEmpresaDisponible(EmpresaEN pObj)
        {
            //objeto resultado
            EmpresaEN iEmpEN = new EmpresaEN();

            //validar solo cuando hay codigo editado
            if (pObj.CodigoEmpresa != string.Empty)
            {
                //buscar en b.d si hay una empresa con este codigo
                iEmpEN = EmpresaRN.BuscarEmpresaXCodigo(pObj);

                //validar si ya esta registrado este codigo
                if (iEmpEN.CodigoEmpresa != string.Empty)
                {
                    iEmpEN.Adicionales.EsVerdad = false;
                    iEmpEN.Adicionales.Mensaje = "El codigo " + iEmpEN.CodigoEmpresa + " ya le pertenece a otra Empresa";
                    return iEmpEN;
                }
            }
           
            //ok
            iEmpEN.Adicionales.EsVerdad = true;
            return iEmpEN;
        }

        public  static EmpresaEN EsEmpresaValido(EmpresaEN pObj)
        {
            EmpresaEN iEmpEN = new EmpresaEN();

            //si el codigo esta vacio pasa true
            if (pObj.CodigoEmpresa == string.Empty)
            {
                iEmpEN.Adicionales.EsVerdad = true;
                iEmpEN.Adicionales.Mensaje = "";
                return iEmpEN;
            }

            //si Codigo no esta vacio
            iEmpEN = EmpresaRN.BuscarEmpresaXCodigo(pObj);
            if (iEmpEN.CodigoEmpresa == string.Empty)
            {
                iEmpEN.Adicionales.EsVerdad = false;
                iEmpEN.Adicionales.Mensaje = "La empresa" + Cadena.Espacios(1) + pObj.CodigoEmpresa + Cadena.Espacios(1) + "no existe";
                return iEmpEN;
            }
            //ok
            iEmpEN.Adicionales.EsVerdad = true;
            return iEmpEN;
        }

        public static List<EmpresaEN> ListarEmpresasExceptoLaActual(EmpresaEN pObj)
        {
            EmpresaAD iEmpAD = new EmpresaAD();
            return iEmpAD.ListarEmpresasExceptoLaActual(pObj);
        }

        public static EmpresaEN EsActoEliminarEmpresa(EmpresaEN pObj)
        {
            //objeto de retorno
            EmpresaEN iEmpEN = new EmpresaEN();

            //validar si la empresa existe
            iEmpEN = EmpresaRN.EsEmpresaExistente(pObj);
            if (iEmpEN.Adicionales.EsVerdad == false) { return iEmpEN; }

            //validar cuando se quiere eliminar a la empresa de acceso
            EmpresaEN iEmpAccEN = EmpresaRN.ValidaCuandoEliminaEmpresaAcceso(iEmpEN);
            if (iEmpAccEN.Adicionales.EsVerdad == false) { return iEmpAccEN; }

            //valida si existe este empresa en centro de costo
            EmpresaEN iEmpCenCosExiEN = EmpresaRN.ValidaCuandoCodigoEmpresaEstaEnCentroCosto(iEmpEN);
            if (iEmpCenCosExiEN.Adicionales.EsVerdad == false) { return iEmpCenCosExiEN; }

            //valida si existe esta empresa en almacen
            EmpresaEN iEmpAlmExiEN = EmpresaRN.ValidaCuandoCodigoEmpresaEstaEnAlmacen(iEmpEN);
            if (iEmpAlmExiEN.Adicionales.EsVerdad == false) { return iEmpAlmExiEN; }

            //ok            
            return iEmpEN;
        }

        public static EmpresaEN ValidaCuandoEliminaEmpresaAcceso(EmpresaEN pObj)
        {
            //objeto resultado
            EmpresaEN iEmpEN = new EmpresaEN();

            //valida
            if (pObj.CodigoEmpresa == Universal.gCodigoEmpresa)
            {
                iEmpEN.Adicionales.EsVerdad = false;
                iEmpEN.Adicionales.Mensaje = "No se puede eliminar la empresa de acceso";
                return iEmpEN;
            }

            //ok
            return iEmpEN;
        }

        public static EmpresaEN ValidaCuandoCodigoEmpresaEstaEnCentroCosto(EmpresaEN pObj)
        {
            //objeto resultado
            EmpresaEN iEmpEN = new EmpresaEN();

            //valida
            bool iExisten = ItemERN.ExisteValorEnColumnaSinEmpresa(ItemEEN.CodEmp, pObj.CodigoEmpresa);
            if (iExisten == true)
            {
                iEmpEN.Adicionales.EsVerdad = false;
                iEmpEN.Adicionales.Mensaje = "Hay centros de costos generados en esta empresa, no se puede realizar la operacion";
                return iEmpEN;
            }

            //ok
            return iEmpEN;
        }

        public static EmpresaEN ValidaCuandoCodigoEmpresaEstaEnAlmacen(EmpresaEN pObj)
        {
            //objeto resultado
            EmpresaEN iEmpEN = new EmpresaEN();

            ////valida
            //bool iExisten = AlmacenRN.ExisteValorEnColumnaSinEmpresa(AlmacenEN.CodEmp, pObj.CodigoEmpresa);
            //if (iExisten == true)
            //{
            //    iEmpEN.Adicionales.EsVerdad = false;
            //    iEmpEN.Adicionales.Mensaje = "Hay almacenes generados en esta empresa, no se puede realizar la operacion";
            //    return iEmpEN;
            //}

            //ok
            return iEmpEN;
        }

        public static void ModificarCampoParametro(string pCampo, string pValor,string pCodigoEmpresa)
        {
            //traer al objeto Empresa
            EmpresaEN iEmpEN = new EmpresaEN();
            iEmpEN.CodigoEmpresa = pCodigoEmpresa;
            iEmpEN = EmpresaRN.BuscarEmpresaXCodigo(iEmpEN);

            //modificar solo el campo que biene como parametro
            //desde la ventana
            switch (pCampo)
            {
               
                case EmpresaEN.LogEmp: { iEmpEN.LogoEmpresa = pValor; break; }
                case EmpresaEN.NumDigAna: { iEmpEN.NumeroDigitosAnalitica = pValor; break; }
                case EmpresaEN.CueAut2: { iEmpEN.CuentaAutomatica2 = pValor; break; }
            }

            //modificar su valor
            EmpresaRN.ModificarEmpresa(iEmpEN);
        }

        public static EmpresaEN EsNumeroDocumentoAutogeneradoCorrecto(EmpresaEN pEmp)
        { 
            //objeto resultado
            EmpresaEN iEmpEN = new EmpresaEN();

            //traemos a la empresa
            pEmp = EmpresaRN.BuscarEmpresaXCodigo(pEmp);

            //obtener el numero documento actual
            string iNumeroDocumento ="";

            //le sumamos uno
            iNumeroDocumento = Numero.IncrementarCorrelativoNumerico(iNumeroDocumento, 7);

            //si este numero sobrepaso los 7 digitos
            if (iNumeroDocumento.Length > 7)
            {
                iEmpEN.Adicionales.EsVerdad = false;
                iEmpEN.Adicionales.Mensaje = "El numero no puede sobrepasar a: 9999999, No se puede realizar la operacion";
            }
            else
            {
                //aqui  el numero si es correcto entonces modificamos a la empresa
                //pEmp.NumeroDocumento = iNumeroDocumento;
                EmpresaRN.ModificarEmpresa(pEmp);

                //pasamos el nuevo numero
                //iEmpEN.NumeroDocumento = iNumeroDocumento;
                iEmpEN.Adicionales.EsVerdad = true;
            }
            return iEmpEN;
        }

        public static string ObtenerValorDeCampo(EmpresaEN pObj, string pNombreCampo)
        {
            //valor resultado
            string iValor = string.Empty;

            //segun nombre campo
            switch (pNombreCampo)
            {
                case EmpresaEN.ClaObj: return pObj.ClaveObjeto;
                case EmpresaEN.CodEmp: return pObj.CodigoEmpresa;
                case EmpresaEN.NomEmp: return pObj.NombreEmpresa;
                case EmpresaEN.DirEmp: return pObj.DireccionEmpresa;
                case EmpresaEN.RucEmp: return pObj.RucEmpresa;
                case EmpresaEN.TelFijEmp: return pObj.TelFijoEmpresa;
                case EmpresaEN.TelCelEmp: return pObj.TelCelularEmpresa;
                case EmpresaEN.CorEmp: return pObj.CorreoEmpresa;
                case EmpresaEN.NumDigAna: return pObj.NumeroDigitosAnalitica;
                case EmpresaEN.CueAut2: return pObj.CuentaAutomatica2;
                case EmpresaEN.NEstEmp: return pObj.NEstadoEmpresa;
                case EmpresaEN.UsuAgr: return pObj.UsuarioAgrega;
                case EmpresaEN.FecAgr: return pObj.FechaAgrega.ToString();
                case EmpresaEN.UsuMod: return pObj.UsuarioModifica;
                case EmpresaEN.FecMod: return pObj.FechaModifica.ToString();
            }

            //retorna
            return iValor;
        }

        public static List<EmpresaEN> FiltrarEmpresasXTextoEnCualquierPosicion(List<EmpresaEN> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<EmpresaEN> iLisRes = new List<EmpresaEN>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (EmpresaEN xEmp in pLista)
            {
                string iTexto = EmpresaRN.ObtenerValorDeCampo(xEmp, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xEmp);
                }
            }

            //devolver
            return iLisRes;
        }

        public static List<EmpresaEN> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<EmpresaEN> pListaEmpresas)
        {
            //lista resultado
            List<EmpresaEN> iLisRes = new List<EmpresaEN>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pListaEmpresas; }

            //filtar la lista
            iLisRes = EmpresaRN.FiltrarEmpresasXTextoEnCualquierPosicion(pListaEmpresas, pCampoBusqueda, pValorBusqueda);
        
            //retornar
            return iLisRes;
        }

        public static EmpresaEN BuscarEmpresaXCodigo(EmpresaEN pObj, List<EmpresaEN> pLista)
        {
            //objeto resultado
            EmpresaEN iEmpEN = new EmpresaEN();

            //recorrer cada objeto
            foreach (EmpresaEN xEmp in pLista)
            {
                if (xEmp.CodigoEmpresa == pObj.CodigoEmpresa)
                {
                    iEmpEN = xEmp;
                    return iEmpEN;
                }
            }

            //devolver no encontrado
            return iEmpEN;
        }

        public static EmpresaEN EsActoModificarEmpresa(EmpresaEN pEmp)
        {
            //objeto resultado
            EmpresaEN iEmpEN = new EmpresaEN();

            //validar si existe
            iEmpEN = EmpresaRN.EsEmpresaExistente(pEmp);
            if (iEmpEN.Adicionales.EsVerdad == false) { return iEmpEN; }

            //validar que no se pueda desactivar la empresa de acceso
            if (pEmp.CEstadoEmpresa == "0")//desactivada
            {
                if (iEmpEN.CodigoEmpresa == Universal.gCodigoEmpresa)
                {
                    iEmpEN.Adicionales.EsVerdad = false;
                    iEmpEN.Adicionales.Mensaje = "No se puede desactivar la empresa de acceso";
                    return iEmpEN;
                }
            }

            //ok
            iEmpEN.Adicionales.EsVerdad = true;
            return iEmpEN;
        }

        public static EmpresaEN BuscarEmpresaDeAcceso()
        {
            EmpresaEN iEmpEN = new EmpresaEN();
            iEmpEN.CodigoEmpresa = Universal.gCodigoEmpresa;
            return EmpresaRN.BuscarEmpresaXCodigo(iEmpEN);
        }

        public static string ObtenerRucEmpresaDeAcceso()
        {
            //traer a la empresa de acceso
            EmpresaEN iEmpEN = EmpresaRN.BuscarEmpresaDeAcceso();

            //devolver
            return iEmpEN.RucEmpresa;
        }

        public static List<EmpresaEN> ListarEmpresasExceptoUno(EmpresaEN pObj)
        {
            //lista resultado
            List<EmpresaEN> iLisRes = new List<EmpresaEN>();

            //traemos todos los almacenes de la empresa
            List<EmpresaEN> iLisEmp = EmpresaRN.ListarEmpresas(pObj);

            //recorrer cada objeto
            foreach (EmpresaEN xEmp in iLisEmp)
            {
                //si la Empresa es diferente de la Empresa que no debe pasar,entonces se agrega a la lista
                if (xEmp.CodigoEmpresa != pObj.CodigoEmpresa)
                {
                    iLisRes.Add(xEmp);
                }
            }

            //devolver
            return iLisRes;
        }

        public static EmpresaEN EsEmpresaValido(EmpresaEN pObj, string pCodigoEmpresaExcepcion)
        {
            //objeto resultado
            EmpresaEN iEmpEN = new EmpresaEN();

            //valida cuando el codigo esta vacio
            if (pObj.CodigoEmpresa == string.Empty) { return iEmpEN; }

            //valida cuando el codigo no existe
            iEmpEN = EmpresaRN.EsEmpresaExistente(pObj);
            if (iEmpEN.Adicionales.EsVerdad == false) { return iEmpEN; }

            //valida cuando sea el codigo Empresa de excepcion
            EmpresaEN iEmpExcEN = EmpresaRN.ValidaCuandoCodigoEmpresaEsIgualACodigoExcepcion(iEmpEN, pCodigoEmpresaExcepcion);
            if (iEmpExcEN.Adicionales.EsVerdad == false) { return iEmpExcEN; }

            //ok           
            return iEmpEN;
        }

        public static EmpresaEN ValidaCuandoCodigoEmpresaEsIgualACodigoExcepcion(EmpresaEN pObj, string pCodigoEmpresaExcepcion)
        {
            //objeto resultado
            EmpresaEN iEmpEN = new EmpresaEN();

            //valida            
            if (pCodigoEmpresaExcepcion != string.Empty && pObj.CodigoEmpresa == pCodigoEmpresaExcepcion)
            {
                iEmpEN.Adicionales.EsVerdad = false;
                iEmpEN.Adicionales.Mensaje = "Debes elegir otra empresa, no se puede realizar la operacion";
                return iEmpEN;
            }

            //ok
            return iEmpEN;
        }

        public static EmpresaEN EsActoModificarNumeroDigitosAnalitica(EmpresaEN pObj)
        {
            //objeto resultado
            EmpresaEN iObjEN = new EmpresaEN();

            //validar el maximo numero de digitos que se puede editar
            EmpresaEN iObjMaxEN = EmpresaRN.ValidaLaLongitudNumeroDigitosAnalitica(pObj);
            if (iObjMaxEN.Adicionales.EsVerdad == false) { return iObjMaxEN; }

            //valida cuando el numero editado es diferente del actual en b.d
            EmpresaEN iObjDifEN = EmpresaRN.ValidaCuandoNumeroDigitosAnaliticaEditadoEsDiferenteABD(pObj);
            if (iObjDifEN.Adicionales.EsVerdad == true) { return iObjDifEN; }

            //valida si hay cuentas analiticas grabadas con el numero de digitos anterior
            EmpresaEN iObjCreEN = EmpresaRN.ValidaCuandoHayCuentasCreadasConNumeroDigitosAnaliticaBD(pObj);
            if (iObjCreEN.Adicionales.EsVerdad == false) { return iObjCreEN; }

            //devoler
            return iObjEN;
        }

        public static EmpresaEN ValidaLaLongitudNumeroDigitosAnalitica(EmpresaEN pObj)
        {
            //objeto resultado
            EmpresaEN iEmpEN = new EmpresaEN();

            //valida            
            int iNumeroDigitosAnaliticaEditado = Conversion.AInt(pObj.NumeroDigitosAnalitica, 0);           
            int iNumeroDigitosAnaliticaMaximo = 11;
            if ( iNumeroDigitosAnaliticaEditado > iNumeroDigitosAnaliticaMaximo)
            {
                iEmpEN.Adicionales.EsVerdad = false;
                iEmpEN.Adicionales.Mensaje = "El numero de digitos para las cuentas analiticas no puede ser mayor a 11";             
            }

            //ok
            return iEmpEN;
        }

        public static EmpresaEN ValidaCuandoNumeroDigitosAnaliticaEditadoEsDiferenteABD(EmpresaEN pObj)
        {
            //objeto resultado
            EmpresaEN iEmpEN = new EmpresaEN();

            //valida            
            EmpresaEN iObjAccEN = EmpresaRN.BuscarEmpresaXCodigo(pObj);
            if (pObj.NumeroDigitosAnalitica != iObjAccEN.NumeroDigitosAnalitica)
            {
                iEmpEN.Adicionales.EsVerdad = false;               
            }

            //ok
            return iEmpEN;
        }

        public static EmpresaEN ValidaCuandoHayCuentasCreadasConNumeroDigitosAnaliticaBD(EmpresaEN pObj)
        {
            //objeto resultado
            EmpresaEN iEmpEN = new EmpresaEN();

            //valida            
            EmpresaEN iObjAccEN = EmpresaRN.BuscarEmpresaXCodigo(pObj);
            CuentaEN iCueEN = new CuentaEN();
            iCueEN.CodigoEmpresa = iObjAccEN.CodigoEmpresa;
            iCueEN.NumeroDigitosAnalitica = iObjAccEN.NumeroDigitosAnalitica;
            iCueEN.Adicionales.CampoOrden = CuentaEN.CodCue;
            List<CuentaEN> iLisCue = CuentaRN.ListarCuentaXEmpresaXNroDigitosXEstadoYAnalitica(iCueEN);
            if (iLisCue.Count!=0)
            {
                iEmpEN.Adicionales.EsVerdad = false;
                iEmpEN.Adicionales.Mensaje = "Hay cuentas analiticas registradas con el anterior numero de digitos";            
            }

            //ok
            return iEmpEN;
        }

        public static int ObtenerNumeroDigitosAnaliticaEmpresaDeAcceso()
        {
            //traer a la empresa de acceso
            EmpresaEN iEmpEN = EmpresaRN.BuscarEmpresaDeAcceso();

            //devolver
            return Conversion.AInt(iEmpEN.NumeroDigitosAnalitica, 11);
        }

    }
}
