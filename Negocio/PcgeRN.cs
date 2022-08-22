using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using Datos;
using Comun;
using Entidades.Adicionales;
using System.Windows.Forms;

namespace Negocio
{
    public class PcgeRN
    {

        public static PcgeEN EnBlanco()
        {
            PcgeEN iObjEN = new PcgeEN();
            return iObjEN;
        }

        public static void AdicionarPcge(List<PcgeEN> pLista)
        {
            PcgeAD iObjAD = new PcgeAD();
            iObjAD.AdicionarPcge(pLista);
        }

        public static void AdicionarPcge(PcgeEN pObj)
        {
            //Asignar parametros
            List<PcgeEN> iLisObj = new List<PcgeEN>();
            iLisObj.Add(pObj);

            //Ejecutar metodo
            PcgeRN.AdicionarPcge(iLisObj);
        }

        public static void ModificarPcge(List<PcgeEN> pLista)
        {
            PcgeAD iObjAD = new PcgeAD();
            iObjAD.ModificarPcge(pLista);
        }

        public static void ModificarPcge(PcgeEN pObj)
        {
            //Asignar parametros
            List<PcgeEN> iLisObj = new List<PcgeEN>();
            iLisObj.Add(pObj);

            //Ejecutar metodo
            PcgeRN.ModificarPcge(iLisObj);
        }

        public static void EliminarPcge(List<PcgeEN> pLista)
        {
            PcgeAD iObjAD = new PcgeAD();
            iObjAD.EliminarPcge(pLista);
        }

        public static void EliminarPcge(PcgeEN pObj)
        {
            //Asignar parametros
            List<PcgeEN> iLisObj = new List<PcgeEN>();
            iLisObj.Add(pObj);

            //Ejecutar metodo
            PcgeRN.EliminarPcge(iLisObj);
        }

        public static List<PcgeEN> ListarPcge(PcgeEN pObj)
        {
            PcgeAD iObjAD = new PcgeAD();
            return iObjAD.ListarPcge(pObj);
        }

        public static List<PcgeEN> ListarPcge()
        {
            //asignar parametros
            PcgeEN iObjEN = new PcgeEN();
            iObjEN.Adicionales.CampoOrden = PcgeEN.CodPcg;

            //ejecutar metodo
            return PcgeRN.ListarPcge(iObjEN);
        }

        public static PcgeEN BuscarPcgeXClave(PcgeEN pObj)
        {
            PcgeAD iObjAD = new PcgeAD();
            return iObjAD.BuscarPcgeXClave(pObj);
        }

        public static PcgeEN EsPcgeExistente(PcgeEN pObj)
        {
            //objeto resultado
            PcgeEN iObjEN = new PcgeEN();

            //validar si existe en b.d
            iObjEN = PcgeRN.BuscarPcgeXClave(pObj);
            if (iObjEN.CodigoPcge == string.Empty)
            {
                iObjEN.Adicionales.EsVerdad = false;
                iObjEN.Adicionales.Mensaje = "El Registro seleccionado no existe";
            }

            //ok  
            return iObjEN;
        }

        public static PcgeEN EsCodigoPcgeDisponible(PcgeEN pObj)
        {
            //objeto resultado
            PcgeEN iObjEN = new PcgeEN();

            //valida cuando esta vacio
            if (pObj.CodigoPcge == string.Empty) { return iObjEN; }

            //validar si existe
            iObjEN = PcgeRN.ValidaCuandoCodigoYaExiste(pObj);
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }

            //ok           
            return iObjEN;
        }

        public static PcgeEN ValidaCuandoCodigoYaExiste(PcgeEN pObj)
        {
            //objeto resultado
            PcgeEN iObjEN = new PcgeEN();

            //validar
            iObjEN = PcgeRN.BuscarPcgeXClave(pObj);
            if (iObjEN.CodigoPcge != string.Empty)
            {
                iObjEN.Adicionales.EsVerdad = false;
                iObjEN.Adicionales.Mensaje = "Este codigo ya existe";
            }

            //ok  
            return iObjEN;
        }

        public static string ObtenerValorDeCampo(PcgeEN pObj, string pNombreCampo)
        {
            //valor resultado
            string iValor = string.Empty;

            //segun nombre campo
            switch (pNombreCampo)
            {
                case PcgeEN.ClaObj: return pObj.ClaveObjeto;
                case PcgeEN.CodPcg: return pObj.CodigoPcge;
                case PcgeEN.DesPcg: return pObj.DescripcionPcge;

            }

            //retorna
            return iValor;
        }

        public static List<PcgeEN> FiltrarPcgeXTextoEnCualquierPosicion(List<PcgeEN> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<PcgeEN> iLisRes = new List<PcgeEN>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (PcgeEN xObj in pLista)
            {
                string iTexto = PcgeRN.ObtenerValorDeCampo(xObj, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xObj);
                }
            }

            //devolver
            return iLisRes;
        }

        public static List<PcgeEN> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<PcgeEN> pLista)
        {
            //lista resultado
            List<PcgeEN> iLisRes = new List<PcgeEN>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pLista; }

            //filtar la lista
            iLisRes = PcgeRN.FiltrarPcgeXTextoEnCualquierPosicion(pLista, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }

        public static string ObtenerClavePcge(PcgeEN pObj)
        {
            //valor resultado
            string iClave = string.Empty;

            //armar clave
            iClave += pObj.CodigoPcge;

            //retornar
            return iClave;
        }

        public static PcgeEN EsPcgeValido(PcgeEN pObj)
        {
            //objeto resultado
            PcgeEN iObjEN = new PcgeEN();

            //valida cuando esta vacio
            if (pObj.CodigoPcge == string.Empty) { return iObjEN; }

            //valida cuando el codigo no existe
            iObjEN = PcgeRN.EsPcgeExistente(pObj);
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }

            //ok           
            return iObjEN;
        }
              
        public static bool ExisteValorEnColumna(string pColumnaBusqueda, string pValorBusqueda)
        {
            PcgeAD iObjAD = new PcgeAD();
            return iObjAD.ExisteValorEnColumna(pColumnaBusqueda, pValorBusqueda);
        }

        public static bool ExisteValorEnColumna(string pColumnaBusqueda, string pValorBusqueda, string pColumnaCondicion1, string pValorCondicion1)
        {
            PcgeAD iObjAD = new PcgeAD();
            return iObjAD.ExisteValorEnColumna(pColumnaBusqueda, pValorBusqueda, pColumnaCondicion1, pValorCondicion1);
        }

        public static bool ExisteValorEnColumna(string pColumnaBusqueda, string pValorBusqueda, string pColumnaCondicion1, string pValorCondicion1, string pColumnaCondicion2, string pValorCondicion2)
        {
            PcgeAD iObjAD = new PcgeAD();
            return iObjAD.ExisteValorEnColumna(pColumnaBusqueda, pValorBusqueda, pColumnaCondicion1, pValorCondicion1, pColumnaCondicion2, pValorCondicion2);
        }

        public static string ObtenerMaximoValorEnColumna(string pColumnaBusqueda)
        {
            PcgeAD iObjAD = new PcgeAD();
            return iObjAD.ObtenerMaximoValorEnColumna(pColumnaBusqueda);
        }

        public static string ObtenerMaximoValorEnColumna(string pColumnaBusqueda, string pColumnaCondicion1, string pValorCondicion1)
        {
            PcgeAD iObjAD = new PcgeAD();
            return iObjAD.ObtenerMaximoValorEnColumna(pColumnaBusqueda, pColumnaCondicion1, pValorCondicion1);
        }

        public static string ObtenerMaximoValorEnColumna(string pColumnaBusqueda, string pColumnaCondicion1, string pValorCondicion1, string pColumnaCondicion2, string pValorCondicion2)
        {
            PcgeAD iObjAD = new PcgeAD();
            return iObjAD.ObtenerMaximoValorEnColumna(pColumnaBusqueda, pColumnaCondicion1, pValorCondicion1, pColumnaCondicion2, pValorCondicion2);
        }

        public static string ObtenerNuevoNumeroPcgeAutogenerado(PcgeEN pObj)
        {
            //valor resultado
            string iNumero = string.Empty;

            //obtener el ultimo codigo que hay en la b.d
            string iUltimoCodigo = PcgeRN.ObtenerMaximoValorEnColumna("CampoDondeBuscar");

            //obtener el siguiente codigo
            iNumero = Numero.IncrementarCorrelativoNumerico(iUltimoCodigo, 6);

            //devuelve
            return iNumero;
        }

        public static PcgeEN EsActoAdicionarPcge(PcgeEN pObj)
        {
            //objeto resultado
            PcgeEN iObjEN = new PcgeEN();

            //ok          
            return iObjEN;
        }

        public static PcgeEN EsActoModificarPcge(PcgeEN pObj)
        {
            //objeto resultado
            PcgeEN iObjEN = new PcgeEN();

            //valida cuando el codigo no existe
            iObjEN = PcgeRN.EsPcgeExistente(pObj);
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }

            //ok          
            return iObjEN;
        }

        public static PcgeEN EsActoEliminarPcge(PcgeEN pObj)
        {
            //objeto resultado
            PcgeEN iObjEN = new PcgeEN();

            //valida cuando el codigo no existe
            iObjEN = PcgeRN.EsPcgeExistente(pObj);
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }

            //ok          
            return iObjEN;
        }

        public static PcgeEN BuscarPcge(string pCampo, string pValor, List<PcgeEN> pLista)
        {
            //objeto resultaddo
            PcgeEN iObjEN = new PcgeEN();

            //recorrer cada objeto
            foreach (PcgeEN xObj in pLista)
            {
                if (PcgeRN.ObtenerValorDeCampo(xObj, pCampo) == pValor)
                {
                    return xObj;
                }
            }

            //devolver
            return iObjEN;
        }

    }
}
