using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using Datos;
using Comun;
using Entidades.Adicionales;


namespace Negocio
{
    public class TipoDocumentoRN
    {

        public static TipoDocumentoEN EnBlanco()
        {
            TipoDocumentoEN iObjEN = new TipoDocumentoEN();
            return iObjEN;
        }

        public static void AdicionarTipoDocumento(List<TipoDocumentoEN> pLista)
        {
            TipoDocumentoAD iObjAD = new TipoDocumentoAD();
            iObjAD.AdicionarTipoDocumento(pLista);
        }

        public static void AdicionarTipoDocumento(TipoDocumentoEN pObj)
        {
            //Asignar parametros
            List<TipoDocumentoEN> iLisObj = new List<TipoDocumentoEN>();
            iLisObj.Add(pObj);

            //Ejecutar metodo
            TipoDocumentoRN.AdicionarTipoDocumento(iLisObj);
        }

        public static void ModificarTipoDocumento(List<TipoDocumentoEN> pLista)
        {
            TipoDocumentoAD iObjAD = new TipoDocumentoAD();
            iObjAD.ModificarTipoDocumento(pLista);
        }

        public static void ModificarTipoDocumento(TipoDocumentoEN pObj)
        {
            //Asignar parametros
            List<TipoDocumentoEN> iLisObj = new List<TipoDocumentoEN>();
            iLisObj.Add(pObj);

            //Ejecutar metodo
            TipoDocumentoRN.ModificarTipoDocumento(iLisObj);
        }

        public static void EliminarTipoDocumento(List<TipoDocumentoEN> pLista)
        {
            TipoDocumentoAD iObjAD = new TipoDocumentoAD();
            iObjAD.EliminarTipoDocumento(pLista);
        }

        public static void EliminarTipoDocumento(TipoDocumentoEN pObj)
        {
            //Asignar parametros
            List<TipoDocumentoEN> iLisObj = new List<TipoDocumentoEN>();
            iLisObj.Add(pObj);

            //Ejecutar metodo
            TipoDocumentoRN.EliminarTipoDocumento(iLisObj);
        }

        public static List<TipoDocumentoEN> ListarTipoDocumento(TipoDocumentoEN pObj)
        {
            TipoDocumentoAD iObjAD = new TipoDocumentoAD();
            return iObjAD.ListarTipoDocumento(pObj);
        }

        public static List<TipoDocumentoEN> ListarTipoDocumento()
        {
            //asignar parametros
            TipoDocumentoEN iObjEN = new TipoDocumentoEN();
            iObjEN.Adicionales.CampoOrden = TipoDocumentoEN.CodTipDoc;

            //ejecutar metodo
            return TipoDocumentoRN.ListarTipoDocumento(iObjEN);
        }

        public static TipoDocumentoEN BuscarTipoDocumentoXCodigo(TipoDocumentoEN pObj)
        {
            TipoDocumentoAD iObjAD = new TipoDocumentoAD();
            return iObjAD.BuscarTipoDocumentoXClave(pObj);
        }

        public static TipoDocumentoEN EsTipoDocumentoExistente(TipoDocumentoEN pObj)
        {
            //objeto resultado
            TipoDocumentoEN iObjEN = new TipoDocumentoEN();

            //validar si existe en b.d
            iObjEN = TipoDocumentoRN.BuscarTipoDocumentoXCodigo(pObj);
            if (iObjEN.CodigoTipoDocumento == string.Empty)
            {
                iObjEN.Adicionales.EsVerdad = false;
                iObjEN.Adicionales.Mensaje = "El Registro seleccionado no existe";
            }

            //ok  
            return iObjEN;
        }

        public static TipoDocumentoEN EsCodigoTipoDocumentoDisponible(TipoDocumentoEN pObj)
        {
            //objeto resultado
            TipoDocumentoEN iObjEN = new TipoDocumentoEN();

            //valida cuando esta vacio
            if (pObj.CodigoTipoDocumento == string.Empty) { return iObjEN; }

            //validar si existe
            iObjEN = TipoDocumentoRN.ValidaCuandoCodigoYaExiste(pObj);
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }

            //ok           
            return iObjEN;
        }

        public static TipoDocumentoEN ValidaCuandoCodigoYaExiste(TipoDocumentoEN pObj)
        {
            //objeto resultado
            TipoDocumentoEN iObjEN = new TipoDocumentoEN();

            //validar
            iObjEN = TipoDocumentoRN.BuscarTipoDocumentoXCodigo(pObj);
            if (iObjEN.CodigoTipoDocumento != string.Empty)
            {
                iObjEN.Adicionales.EsVerdad = false;
                iObjEN.Adicionales.Mensaje = "Este codigo ya existe";
            }

            //ok  
            return iObjEN;
        }

        public static List<TipoDocumentoEN> FiltrarTipoDocumentoXTextoEnCualquierPosicion(List<TipoDocumentoEN> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<TipoDocumentoEN> iLisRes = new List<TipoDocumentoEN>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (TipoDocumentoEN xObj in pLista)
            {
                string iTexto = ObjetoG.ObtenerTexto<TipoDocumentoEN>(xObj, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xObj);
                }
            }

            //devolver
            return iLisRes;
        }

        public static List<TipoDocumentoEN> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<TipoDocumentoEN> pLista)
        {
            //lista resultado
            List<TipoDocumentoEN> iLisRes = new List<TipoDocumentoEN>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pLista; }

            //filtar la lista
            iLisRes = TipoDocumentoRN.FiltrarTipoDocumentoXTextoEnCualquierPosicion(pLista, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }

        public static TipoDocumentoEN EsTipoDocumentoValido(TipoDocumentoEN pObj)
        {
            //objeto resultado
            TipoDocumentoEN iObjEN = new TipoDocumentoEN();

            //valida cuando esta vacio
            if (pObj.CodigoTipoDocumento == string.Empty) { return iObjEN; }

            //valida cuando el codigo no existe
            iObjEN = TipoDocumentoRN.EsTipoDocumentoExistente(pObj);
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }

            //ok           
            return iObjEN;
        }

        public static TipoDocumentoEN EsTipoDocumentoActivoValido(TipoDocumentoEN pObj)
        {
            //objeto resultado
            TipoDocumentoEN iObjEN = new TipoDocumentoEN();

            //valida cuando esta vacio
            if (pObj.CodigoTipoDocumento == string.Empty) { return iObjEN; }

            //valida cuando el codigo no existe
            iObjEN = TipoDocumentoRN.EsTipoDocumentoExistente(pObj);
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }

            //valida cuando esta desactivada
            TipoDocumentoEN iObjDesEN = TipoDocumentoRN.ValidaCuandoEstaDesactivada(iObjEN);
            if (iObjDesEN.Adicionales.EsVerdad == false) { return iObjDesEN; }

            //ok           
            return iObjEN;
        }

        public static TipoDocumentoEN ValidaCuandoEstaDesactivada(TipoDocumentoEN pObj)
        {
            //objeto resultado
            TipoDocumentoEN iObjEN = new TipoDocumentoEN();

            //validar                 
            if (pObj.CEstadoTipoDocumento == "0")//desactivado
            {
                iObjEN.Adicionales.EsVerdad = false;
                iObjEN.Adicionales.Mensaje = "El(La) TipoDocumento esta desactivada";
            }

            //ok
            return iObjEN;
        }

        public static bool ExisteValorEnColumna(string pColumnaBusqueda, string pValorBusqueda)
        {
            TipoDocumentoAD iObjAD = new TipoDocumentoAD();
            return iObjAD.ExisteValorEnColumna(pColumnaBusqueda, pValorBusqueda);
        }

        public static bool ExisteValorEnColumna(string pColumnaBusqueda, string pValorBusqueda, string pColumnaCondicion1, string pValorCondicion1)
        {
            TipoDocumentoAD iObjAD = new TipoDocumentoAD();
            return iObjAD.ExisteValorEnColumna(pColumnaBusqueda, pValorBusqueda, pColumnaCondicion1, pValorCondicion1);
        }

        public static bool ExisteValorEnColumna(string pColumnaBusqueda, string pValorBusqueda, string pColumnaCondicion1, string pValorCondicion1, string pColumnaCondicion2, string pValorCondicion2)
        {
            TipoDocumentoAD iObjAD = new TipoDocumentoAD();
            return iObjAD.ExisteValorEnColumna(pColumnaBusqueda, pValorBusqueda, pColumnaCondicion1, pValorCondicion1, pColumnaCondicion2, pValorCondicion2);
        }

        public static string ObtenerMaximoValorEnColumna(string pColumnaBusqueda)
        {
            TipoDocumentoAD iObjAD = new TipoDocumentoAD();
            return iObjAD.ObtenerMaximoValorEnColumna(pColumnaBusqueda);
        }

        public static string ObtenerMaximoValorEnColumna(string pColumnaBusqueda, string pColumnaCondicion1, string pValorCondicion1)
        {
            TipoDocumentoAD iObjAD = new TipoDocumentoAD();
            return iObjAD.ObtenerMaximoValorEnColumna(pColumnaBusqueda, pColumnaCondicion1, pValorCondicion1);
        }

        public static string ObtenerMaximoValorEnColumna(string pColumnaBusqueda, string pColumnaCondicion1, string pValorCondicion1, string pColumnaCondicion2, string pValorCondicion2)
        {
            TipoDocumentoAD iObjAD = new TipoDocumentoAD();
            return iObjAD.ObtenerMaximoValorEnColumna(pColumnaBusqueda, pColumnaCondicion1, pValorCondicion1, pColumnaCondicion2, pValorCondicion2);
        }

        public static TipoDocumentoEN EsActoAdicionarTipoDocumento(TipoDocumentoEN pObj)
        {
            //objeto resultado
            TipoDocumentoEN iObjEN = new TipoDocumentoEN();

            //ok          
            return iObjEN;
        }

        public static TipoDocumentoEN EsActoModificarTipoDocumento(TipoDocumentoEN pObj)
        {
            //objeto resultado
            TipoDocumentoEN iObjEN = new TipoDocumentoEN();

            //valida cuando el codigo no existe
            iObjEN = TipoDocumentoRN.EsTipoDocumentoExistente(pObj);
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }

            //ok          
            return iObjEN;
        }

        public static TipoDocumentoEN EsActoEliminarTipoDocumento(TipoDocumentoEN pObj)
        {
            //objeto resultado
            TipoDocumentoEN iObjEN = new TipoDocumentoEN();

            //valida cuando el codigo no existe
            iObjEN = TipoDocumentoRN.EsTipoDocumentoExistente(pObj);
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }

            //ok          
            return iObjEN;
        }

        public static List<TipoDocumentoEN> ListarTipoDocumentoParaComprasActivo(TipoDocumentoEN pObj)
        {
            TipoDocumentoAD iObjAD = new TipoDocumentoAD();
            return iObjAD.ListarTipoDocumentoParaComprasActivo(pObj);
        }

        public static TipoDocumentoEN EsTipoDocumentoParaCompraActivoValido(TipoDocumentoEN pObj)
        {
            //objeto resultado
            TipoDocumentoEN iObjEN = new TipoDocumentoEN();

            //valida cuando esta vacio
            if (pObj.CodigoTipoDocumento == string.Empty) { return iObjEN; }

            //valida cuando el codigo no existe
            iObjEN = TipoDocumentoRN.EsTipoDocumentoExistente(pObj);
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }

            //valida cuando no es de compra
            TipoDocumentoEN iObjComEN = TipoDocumentoRN.ValidaCuandoNoEsParaCompra(iObjEN);
            if (iObjComEN.Adicionales.EsVerdad == false) { return iObjComEN; }

            //valida cuando esta desactivada
            TipoDocumentoEN iObjDesEN = TipoDocumentoRN.ValidaCuandoEstaDesactivada(iObjEN);
            if (iObjDesEN.Adicionales.EsVerdad == false) { return iObjDesEN; }

            //ok           
            return iObjEN;
        }

        public static TipoDocumentoEN ValidaCuandoNoEsParaCompra(TipoDocumentoEN pObj)
        {
            //objeto resultado
            TipoDocumentoEN iObjEN = new TipoDocumentoEN();

            //validar                 
            if (Cadena.ExisteValorEnConjuntoDeValores(pObj.CAplicaEnRegistro, "0,2") == false)
            {
                iObjEN.Adicionales.EsVerdad = false;
                iObjEN.Adicionales.Mensaje = "El(La) Tipo Documento no es para compras";
            }

            //ok
            return iObjEN;
        }

    }
}
