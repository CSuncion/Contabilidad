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
    public class ItemERN
    {

        public static ItemEEN EnBlanco()
        {
            ItemEEN iIteEN = new ItemEEN();
            return iIteEN;
        }

        public static void AdicionarItemE(ItemEEN pObj)
        {
            ItemEAD iIteAD = new ItemEAD();
            iIteAD.AgregarItemE(pObj);
        }

        public static void ModificarItemE(ItemEEN pObj)
        {
            ItemEAD iIteAD = new ItemEAD();
            iIteAD.ModificarItemE(pObj);
        }

        public static void EliminarItemE(ItemEEN pObj)
        {
            ItemEAD iIteAD = new ItemEAD();
            iIteAD.EliminarItemE(pObj);
        }

        public static List<ItemEEN> ListarItemsEXTabla(ItemEEN pObj)
        {
            ItemEAD iIteAD = new ItemEAD();
            return iIteAD.ListarItemsEXTabla(pObj);
        }

        public static List<ItemEEN> ListarItemsEActivosXTabla(ItemEEN pObj)
        {
            ItemEAD iIteAD = new ItemEAD();
            return iIteAD.ListarItemsEActivosXTabla(pObj);
        }

        public static List<ItemEEN> ListarItemsEActivosXTablaYFiltroCodigo(ItemEEN pObj)
        {
            ItemEAD iIteAD = new ItemEAD();
            return iIteAD.ListarItemsEActivosXTablaYFiltroCodigo(pObj);
        }

        public static ItemEEN buscarItemEXClave(ItemEEN pObj)
        {
            ItemEAD iIteAD = new ItemEAD();
            return iIteAD.BuscarItemEXClave(pObj);
        }

        public static List<ItemEEN> ListarItemsE(string pTabla)
        {
            ItemEEN iTipUsuEN = new ItemEEN();
            iTipUsuEN.CodigoTabla = pTabla;
            iTipUsuEN.Adicionales.CampoOrden = ItemEEN.CodIteE;
            return ItemERN.ListarItemsEActivosXTabla(iTipUsuEN);
        }

        public static ItemEEN EsItemEValido(ItemEEN pObj)
        {
            ItemEEN iIteEN = new ItemEEN();

            //validar cuando hay codigo
            if (pObj.CodigoItemE != string.Empty)
            {
                //validar si existe
                iIteEN.ClaveItemE = ItemERN.ObtenerClaveItemE(pObj);
                iIteEN = ItemERN.buscarItemEXClave(iIteEN);
                if (iIteEN.CodigoItemE == string.Empty)
                {
                    iIteEN.Adicionales.EsVerdad = false;
                    iIteEN.Adicionales.Mensaje = "El Item" + Cadena.Espacios(1) + pObj.CodigoItemE + Cadena.Espacios(1) + "no existe";
                    return iIteEN;
                }

                //validar si esta dasctivado
                if (iIteEN.CEstadoItemE == "0") //desactivado
                {
                    iIteEN = ItemERN.EnBlanco();
                    iIteEN.Adicionales.EsVerdad = false;
                    iIteEN.Adicionales.Mensaje = "El Item" + Cadena.Espacios(1) + pObj.CodigoItemE + Cadena.Espacios(1) + "esta desactivado";
                    return iIteEN;
                }
            }

            //ok
            iIteEN.Adicionales.EsVerdad = true;
            return iIteEN;
        }

        public static ItemEEN EsItemEExistente(ItemEEN pObj)
        {
            //objeto resultado
            ItemEEN iIteEN = new ItemEEN();

            //valida
            iIteEN = ItemERN.buscarItemEXClave(pObj);
            if (iIteEN.CodigoItemE == string.Empty)
            {
                iIteEN.Adicionales.EsVerdad = false;
                iIteEN.Adicionales.Mensaje = "El Item " + pObj.CodigoItemE + " no existe";
                return iIteEN;
            }

            //ok
            return iIteEN;
        }

        public static ItemEEN EsCodigoItemEDisponible(ItemEEN pObj)
        {
            //objeto resultado
            ItemEEN iIteEN = new ItemEEN();

            //valida cuando esta vacio
            if (pObj.CodigoItemE == string.Empty) { return iIteEN; }

            //validar cuando codigo ya existe
            iIteEN = ItemERN.ValidaCuandoCodigoYaExiste(pObj);
            if (iIteEN.Adicionales.EsVerdad == false) { return iIteEN; }

            //ok
            return iIteEN;
        }

        public static ItemEEN ValidaCuandoCodigoYaExiste(ItemEEN pObj)
        {
            //objeto resultado
            ItemEEN iPerEN = new ItemEEN();

            //validar     
            iPerEN = ItemERN.buscarItemEXClave(pObj);
            if (iPerEN.CodigoItemE != string.Empty)
            {
                iPerEN.Adicionales.EsVerdad = false;
                iPerEN.Adicionales.Mensaje = "El codigo " + pObj.CodigoItemE + " ya existe";
                return iPerEN;
            }

            //ok          
            return iPerEN;
        }

        public static string ObtenerClaveItemE(ItemEEN pObj)
        {
            //variavle resulatdo
            string iClave = string.Empty;
            iClave += Universal.gCodigoEmpresa + "-";
            iClave += pObj.CodigoTabla + "-";
            iClave += pObj.CodigoItemE;
            return iClave;
        }

        public static List<ItemEEN> ListarTiposAuxiliarParaJuridico()
        {
            //lista resultado
            List<ItemEEN> iLisRes = new List<ItemEEN>();

            //traer todos los tipos de auxiliares
            List<ItemEEN> iLisTipAux = ItemERN.ListarItemsE("TipAux");

            //recorre cada objeto
            foreach (ItemEEN xItem in iLisTipAux)
            {
                //de esta lista sacar el tipo de auxiliar(0 : personal) ya que 
                //ninguna empresa puede ser de este tipo
                if (xItem.CodigoItemE != "0")
                {
                    iLisRes.Add(xItem);
                }
            }
            //retornar la lista actualizada
            return iLisRes;
        }

        public static ItemEEN buscarItemEXNombre(ItemEEN pObj, List<ItemEEN> pLista)
        {
            //objeto resultado
            ItemEEN iIteGEN = new ItemEEN();

            //buscar en la lista
            foreach (ItemEEN xIte in pLista)
            {
                if (xIte.NombreItemE == pObj.NombreItemE)
                {
                    iIteGEN = xIte;
                    return iIteGEN;
                }
            }

            //sino hay nada devuelve vacio
            return iIteGEN;
        }

        public static string ObtenerValorDeCampo(ItemEEN pObj, string pNombreCampo)
        {
            //valor resultado
            string iValor = string.Empty;

            //segun nombre campo
            switch (pNombreCampo)
            {
                case ItemEEN.CodIteE: return pObj.CodigoItemE;
                case ItemEEN.NomIteE: return pObj.NombreItemE;
            }
            //retorna
            return iValor;
        }

        public static List<ItemEEN> FiltrarItemEsXTextoEnCualquierPosicion(List<ItemEEN> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<ItemEEN> iLisRes = new List<ItemEEN>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (ItemEEN xCli in pLista)
            {
                string iTexto = ItemERN.ObtenerValorDeCampo(xCli, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xCli);
                }
            }

            //devolver
            return iLisRes;
        }

        public static List<ItemEEN> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<ItemEEN> pListaItemE)
        {
            //lista resultado
            List<ItemEEN> iLisRes = new List<ItemEEN>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pListaItemE; }

            //filtar la lista
            iLisRes = ItemERN.FiltrarItemEsXTextoEnCualquierPosicion(pListaItemE, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }

        public static ItemEEN BuscarItemXCodigo(ItemEEN pObj, List<ItemEEN> pLista)
        {
            //objeto resultado
            ItemEEN iIteEN = new ItemEEN();

            //recorrer cada objeto
            foreach (ItemEEN xIte in pLista)
            {
                if (xIte.CodigoItemE == pObj.CodigoItemE)
                {
                    iIteEN = xIte;
                    return iIteEN;
                }
            }

            //devolver no encontrado
            return iIteEN;
        }

        public static void AgregarItemTodos(List<ItemEEN> pLista)
        {
            //creamos el item todos
            ItemEEN iIteGEN = new ItemEEN();
            iIteGEN.CodigoItemE = "";
            iIteGEN.NombreItemE = "Todos";
            pLista.Add(iIteGEN);
        }

        public static List<ItemEEN> ListarItemsEMasItemTodos(string pTabla)
        {
            //lista resultado
            List<ItemEEN> iLisIteG = new List<ItemEEN>();

            //llenar con los items de la base de datos
            iLisIteG = ItemERN.ListarItemsE(pTabla);

            //ahora insertamos al final el item "todos"
            ItemERN.AgregarItemTodos(iLisIteG);

            //devolver
            return iLisIteG;
        }

        public static bool ExisteValorEnColumnaSinEmpresa(string pColumnaBusqueda, string pValorBusqueda)
        {
            ItemEAD iPerAD = new ItemEAD();
            return iPerAD.ExisteValorEnColumnaSinEmpresa(pColumnaBusqueda, pValorBusqueda);
        }

        public static bool ExisteValorEnColumnaConEmpresa(string pColumnaBusqueda, string pValorBusqueda)
        {
            ItemEAD iPerAD = new ItemEAD();
            return iPerAD.ExisteValorEnColumnaConEmpresa(pColumnaBusqueda, pValorBusqueda);
        }

        public static bool ExisteValorEnColumnaConEmpresa(string pColumnaBusqueda, string pValorBusqueda, string pColumnaCondicion1, string pValorCondicion1)
        {
            ItemEAD iPerAD = new ItemEAD();
            return iPerAD.ExisteValorEnColumnaConEmpresa(pColumnaBusqueda, pValorBusqueda, pColumnaCondicion1, pValorCondicion1);
        }

        public static List<string> ListarCodigosItems(string pTabla)
        {
            //lista resultado
            List<string> iLisRes = new List<string>();

            //traer a todos los items de la tabla
            List<ItemEEN> iLisIte = ItemERN.ListarItemsE(pTabla);

            //recorrer cada objeto auxiliar
            foreach (ItemEEN xIte in iLisIte)
            {
                iLisRes.Add(xIte.CodigoItemE);
            }

            //devolver
            return iLisRes;
        }

        public static ItemEEN EsItemEActivoValido(ItemEEN pObj)
        {
            ItemEEN iIteEN = new ItemEEN();

            //validar cuando codigo esta vacio
            if (pObj.CodigoItemE == string.Empty) { return iIteEN; }

            //valida cuando no existe
            iIteEN = ItemERN.EsItemEExistente(pObj);
            if (iIteEN.Adicionales.EsVerdad == false) { return iIteEN; }

            //valida cuando esta desactivado
            ItemEEN iIteDesEN = ItemERN.ValidaCuandoEstaDesactivado(iIteEN);
            if (iIteDesEN.Adicionales.EsVerdad == false) { return iIteDesEN; }

            //ok         
            return iIteEN;
        }

        public static ItemEEN ValidaCuandoEstaDesactivado(ItemEEN pObj)
        {
            //objeto resultado
            ItemEEN iPerEN = new ItemEEN();

            //validar                 
            if (pObj.CEstadoItemE == "0")//desactivado
            {
                iPerEN.Adicionales.EsVerdad = false;
                iPerEN.Adicionales.Mensaje = "El item " + pObj.CodigoItemE + " esta desactivado";
            }

            //ok          
            return iPerEN;
        }

        public static ItemEEN EsItemEActivoXFiltroCodigoValido(ItemEEN pObj, string pFiltroCodigo)
        {
            ItemEEN iIteEN = new ItemEEN();

            //validar cuando codigo esta vacio
            if (pObj.CodigoItemE == string.Empty) { return iIteEN; }

            //valida cuando no existe
            iIteEN = ItemERN.EsItemEExistente(pObj);
            if (iIteEN.Adicionales.EsVerdad == false) { return iIteEN; }

            //valida cuando esta desactivado
            ItemEEN iIteDesEN = ValidaCuandoEstaDesactivado(iIteEN);
            if (iIteDesEN.Adicionales.EsVerdad == false) { return iIteDesEN; }

            //valida cuando no es del origen
            ItemEEN iIteOriEN = ValidaCuandoCodigoNoEmpiezaCon(iIteEN, pFiltroCodigo);
            if (iIteOriEN.Adicionales.EsVerdad == false) { return iIteOriEN; }

            //ok         
            return iIteEN;
        }

        public static ItemEEN ValidaCuandoCodigoNoEmpiezaCon(ItemEEN pObj, string pCaracterEmpieza)
        {
            //objeto resultado
            ItemEEN iPerEN = new ItemEEN();

            //validar                 
            if (Cadena.CortarCadena(pObj.CodigoItemE, 1) != pCaracterEmpieza)
            {
                iPerEN.Adicionales.EsVerdad = false;
                iPerEN.Adicionales.Mensaje = "El item " + pObj.CodigoItemE + " no se puede usar";
            }

            //ok          
            return iPerEN;
        }


    }
}
