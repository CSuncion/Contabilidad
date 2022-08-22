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
    public class ItemAlmacenRN
    {

        public static ItemAlmacenEN EnBlanco()
        {
            ItemAlmacenEN iObjEN = new ItemAlmacenEN();
            return iObjEN;
        }

        public static void AdicionarItemAlmacen(List<ItemAlmacenEN> pLista)
        {
            ItemAlmacenAD iObjAD = new ItemAlmacenAD();
            iObjAD.AdicionarItemAlmacen(pLista);
        }

        public static void AdicionarItemAlmacen(ItemAlmacenEN pObj)
        {
            //Asignar parametros
            List<ItemAlmacenEN> iLisObj = new List<ItemAlmacenEN>();
            iLisObj.Add(pObj);

            //Ejecutar metodo
            ItemAlmacenRN.AdicionarItemAlmacen(iLisObj);
        }

        public static void ModificarItemAlmacen(List<ItemAlmacenEN> pLista)
        {
            ItemAlmacenAD iObjAD = new ItemAlmacenAD();
            iObjAD.ModificarItemAlmacen(pLista);
        }

        public static void ModificarItemAlmacen(ItemAlmacenEN pObj)
        {
            //Asignar parametros
            List<ItemAlmacenEN> iLisObj = new List<ItemAlmacenEN>();
            iLisObj.Add(pObj);

            //Ejecutar metodo
            ItemAlmacenRN.ModificarItemAlmacen(iLisObj);
        }

        public static void EliminarItemAlmacen(List<ItemAlmacenEN> pLista)
        {
            ItemAlmacenAD iObjAD = new ItemAlmacenAD();
            iObjAD.EliminarItemAlmacen(pLista);
        }

        public static void EliminarItemAlmacen(ItemAlmacenEN pObj)
        {
            //Asignar parametros
            List<ItemAlmacenEN> iLisObj = new List<ItemAlmacenEN>();
            iLisObj.Add(pObj);

            //Ejecutar metodo
            ItemAlmacenRN.EliminarItemAlmacen(iLisObj);
        }

        public static List<ItemAlmacenEN> ListarItemAlmacen(ItemAlmacenEN pObj)
        {
            ItemAlmacenAD iObjAD = new ItemAlmacenAD();
            return iObjAD.ListarItemAlmacen(pObj);
        }

        public static List<ItemAlmacenEN> ListarItemAlmacen()
        {
            //asignar parametros
            ItemAlmacenEN iObjEN = new ItemAlmacenEN();
            iObjEN.Adicionales.CampoOrden = ItemAlmacenEN.ClaIteAlm;

            //ejecutar metodo
            return ItemAlmacenRN.ListarItemAlmacen(iObjEN);
        }

        public static ItemAlmacenEN BuscarItemAlmacenXClave(ItemAlmacenEN pObj)
        {
            ItemAlmacenAD iObjAD = new ItemAlmacenAD();
            return iObjAD.BuscarItemAlmacenXClave(pObj);
        }

        public static ItemAlmacenEN EsItemAlmacenExistente(ItemAlmacenEN pObj)
        {
            //objeto resultado
            ItemAlmacenEN iObjEN = new ItemAlmacenEN();

            //validar si existe en b.d
            iObjEN = ItemAlmacenRN.BuscarItemAlmacenXClave(pObj);
            if (iObjEN.ClaveItemAlmacen == string.Empty)
            {
                iObjEN.Adicionales.EsVerdad = false;
                iObjEN.Adicionales.Mensaje = "El Registro seleccionado no existe";
            }

            //ok  
            return iObjEN;
        }

        public static ItemAlmacenEN EsCodigoItemAlmacenDisponible(ItemAlmacenEN pObj)
        {
            //objeto resultado
            ItemAlmacenEN iObjEN = new ItemAlmacenEN();

            //valida cuando esta vacio
            if (pObj.CodigoAlmacen == string.Empty) { return iObjEN; }

            //valida cuando esta vacio
            if (pObj.CodigoItemAlmacen == string.Empty) { return iObjEN; }

            //validar si existe
            iObjEN = ItemAlmacenRN.ValidaCuandoCodigoYaExiste(pObj);
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }

            //ok           
            return iObjEN;
        }

        public static ItemAlmacenEN ValidaCuandoCodigoYaExiste(ItemAlmacenEN pObj)
        {
            //objeto resultado
            ItemAlmacenEN iObjEN = new ItemAlmacenEN();

            //validar
            iObjEN = ItemAlmacenRN.BuscarItemAlmacenXClave(pObj);
            if (iObjEN.ClaveItemAlmacen != string.Empty)
            {
                iObjEN.Adicionales.EsVerdad = false;
                iObjEN.Adicionales.Mensaje = "Este codigo ya existe";
            }

            //ok  
            return iObjEN;
        }

        public static string ObtenerValorDeCampo(ItemAlmacenEN pObj, string pNombreCampo)
        {
            //valor resultado
            string iValor = string.Empty;

            //segun nombre campo
            switch (pNombreCampo)
            {
                case ItemAlmacenEN.ClaObj: return pObj.ClaveObjeto;
                case ItemAlmacenEN.ClaIteAlm: return pObj.ClaveItemAlmacen;
                case ItemAlmacenEN.CodEmp: return pObj.CodigoEmpresa;
                case ItemAlmacenEN.NomEmp: return pObj.NombreEmpresa;
                case ItemAlmacenEN.CodAlm: return pObj.CodigoAlmacen;
                case ItemAlmacenEN.DesAlm: return pObj.DescripcionAlmacen;
                case ItemAlmacenEN.CodIteAlm: return pObj.CodigoItemAlmacen;
                case ItemAlmacenEN.DesIteAlm: return pObj.DescripcionItemAlmacen;
                case ItemAlmacenEN.CUniMed: return pObj.CUnidadMedida;
                case ItemAlmacenEN.NUniMed: return pObj.NUnidadMedida;
                case ItemAlmacenEN.CEstIteAlm: return pObj.CEstadoItemAlmacen;
                case ItemAlmacenEN.NEstIteAlm: return pObj.NEstadoItemAlmacen;
                case ItemAlmacenEN.UsuAgr: return pObj.UsuarioAgrega;
                case ItemAlmacenEN.FecAgr: return pObj.FechaAgrega.ToString();
                case ItemAlmacenEN.UsuMod: return pObj.UsuarioModifica;
                case ItemAlmacenEN.FecMod: return pObj.FechaModifica.ToString();

            }

            //retorna
            return iValor;
        }

        public static List<ItemAlmacenEN> FiltrarItemAlmacenXTextoEnCualquierPosicion(List<ItemAlmacenEN> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<ItemAlmacenEN> iLisRes = new List<ItemAlmacenEN>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (ItemAlmacenEN xObj in pLista)
            {
                string iTexto = ItemAlmacenRN.ObtenerValorDeCampo(xObj, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xObj);
                }
            }

            //devolver
            return iLisRes;
        }

        public static List<ItemAlmacenEN> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<ItemAlmacenEN> pLista)
        {
            //lista resultado
            List<ItemAlmacenEN> iLisRes = new List<ItemAlmacenEN>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pLista; }

            //filtar la lista
            iLisRes = ItemAlmacenRN.FiltrarItemAlmacenXTextoEnCualquierPosicion(pLista, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }

        public static string ObtenerClaveItemAlmacen(ItemAlmacenEN pObj)
        {
            //valor resultado
            string iClave = string.Empty;

            //armar clave
            iClave += Universal.gCodigoEmpresa + "-";
            iClave += pObj.CodigoAlmacen + "-";
            iClave += pObj.CodigoItemAlmacen;

            //retornar
            return iClave;
        }

        public static ItemAlmacenEN EsItemAlmacenValido(ItemAlmacenEN pObj)
        {
            //objeto resultado
            ItemAlmacenEN iObjEN = new ItemAlmacenEN();

            //valida cuando esta vacio
            if (pObj.CodigoAlmacen == string.Empty) { return iObjEN; }

            //valida cuando esta vacio
            if (pObj.CodigoItemAlmacen == string.Empty) { return iObjEN; }

            //valida cuando el codigo no existe
            iObjEN = ItemAlmacenRN.EsItemAlmacenExistente(pObj);
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }

            //ok           
            return iObjEN;
        }

        public static ItemAlmacenEN EsItemAlmacenActivoValido(ItemAlmacenEN pObj)
        {
            //objeto resultado
            ItemAlmacenEN iObjEN = new ItemAlmacenEN();

            //valida cuando esta vacio
            if (pObj.CodigoAlmacen == string.Empty) { return iObjEN; }

            //valida cuando esta vacio
            if (pObj.CodigoItemAlmacen == string.Empty) { return iObjEN; }

            //valida cuando el codigo no existe
            iObjEN = ItemAlmacenRN.EsItemAlmacenExistente(pObj);
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }

            //valida cuando esta desactivada
            ItemAlmacenEN iObjDesEN = ItemAlmacenRN.ValidaCuandoEstaDesactivada(iObjEN);
            if (iObjDesEN.Adicionales.EsVerdad == false) { return iObjDesEN; }

            //ok           
            return iObjEN;
        }

        public static ItemAlmacenEN ValidaCuandoEstaDesactivada(ItemAlmacenEN pObj)
        {
            //objeto resultado
            ItemAlmacenEN iObjEN = new ItemAlmacenEN();

            //validar                 
            if (pObj.CEstadoItemAlmacen == "0")//desactivado
            {
                iObjEN.Adicionales.EsVerdad = false;
                iObjEN.Adicionales.Mensaje = "El(La) ItemAlmacen esta desactivada";
            }

            //ok
            return iObjEN;
        }

        public static bool ExisteValorEnColumna(string pColumnaBusqueda, string pValorBusqueda)
        {
            ItemAlmacenAD iObjAD = new ItemAlmacenAD();
            return iObjAD.ExisteValorEnColumna(pColumnaBusqueda, pValorBusqueda);
        }

        public static bool ExisteValorEnColumna(string pColumnaBusqueda, string pValorBusqueda, string pColumnaCondicion1, string pValorCondicion1)
        {
            ItemAlmacenAD iObjAD = new ItemAlmacenAD();
            return iObjAD.ExisteValorEnColumna(pColumnaBusqueda, pValorBusqueda, pColumnaCondicion1, pValorCondicion1);
        }

        public static bool ExisteValorEnColumna(string pColumnaBusqueda, string pValorBusqueda, string pColumnaCondicion1, string pValorCondicion1, string pColumnaCondicion2, string pValorCondicion2)
        {
            ItemAlmacenAD iObjAD = new ItemAlmacenAD();
            return iObjAD.ExisteValorEnColumna(pColumnaBusqueda, pValorBusqueda, pColumnaCondicion1, pValorCondicion1, pColumnaCondicion2, pValorCondicion2);
        }

        public static string ObtenerMaximoValorEnColumna(string pColumnaBusqueda)
        {
            ItemAlmacenAD iObjAD = new ItemAlmacenAD();
            return iObjAD.ObtenerMaximoValorEnColumna(pColumnaBusqueda);
        }

        public static string ObtenerMaximoValorEnColumna(string pColumnaBusqueda, string pColumnaCondicion1, string pValorCondicion1)
        {
            ItemAlmacenAD iObjAD = new ItemAlmacenAD();
            return iObjAD.ObtenerMaximoValorEnColumna(pColumnaBusqueda, pColumnaCondicion1, pValorCondicion1);
        }

        public static string ObtenerMaximoValorEnColumna(string pColumnaBusqueda, string pColumnaCondicion1, string pValorCondicion1, string pColumnaCondicion2, string pValorCondicion2)
        {
            ItemAlmacenAD iObjAD = new ItemAlmacenAD();
            return iObjAD.ObtenerMaximoValorEnColumna(pColumnaBusqueda, pColumnaCondicion1, pValorCondicion1, pColumnaCondicion2, pValorCondicion2);
        }

        public static string ObtenerNuevoNumeroItemAlmacenAutogenerado(ItemAlmacenEN pObj)
        {
            //valor resultado
            string iNumero = string.Empty;

            //obtener el ultimo codigo que hay en la b.d
            string iUltimoCodigo = ItemAlmacenRN.ObtenerMaximoValorEnColumna("CampoDondeBuscar");

            //obtener el siguiente codigo
            iNumero = Numero.IncrementarCorrelativoNumerico(iUltimoCodigo, 6);

            //devuelve
            return iNumero;
        }

        public static ItemAlmacenEN EsActoAdicionarItemAlmacen(ItemAlmacenEN pObj)
        {
            //objeto resultado
            ItemAlmacenEN iObjEN = new ItemAlmacenEN();

            //ok          
            return iObjEN;
        }

        public static ItemAlmacenEN EsActoModificarItemAlmacen(ItemAlmacenEN pObj)
        {
            //objeto resultado
            ItemAlmacenEN iObjEN = new ItemAlmacenEN();

            //valida cuando el codigo no existe
            iObjEN = ItemAlmacenRN.EsItemAlmacenExistente(pObj);
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }

            //ok          
            return iObjEN;
        }

        public static ItemAlmacenEN EsActoEliminarItemAlmacen(ItemAlmacenEN pObj)
        {
            //objeto resultado
            ItemAlmacenEN iObjEN = new ItemAlmacenEN();

            //valida cuando el codigo no existe
            iObjEN = ItemAlmacenRN.EsItemAlmacenExistente(pObj);
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }

            //ok          
            return iObjEN;
        }

        public static ItemAlmacenEN BuscarItemAlmacen(string pCampo, string pValor, List<ItemAlmacenEN> pLista)
        {
            //objeto resultaddo
            ItemAlmacenEN iObjEN = new ItemAlmacenEN();

            //recorrer cada objeto
            foreach (ItemAlmacenEN xObj in pLista)
            {
                if (ItemAlmacenRN.ObtenerValorDeCampo(xObj, pCampo) == pValor)
                {
                    return xObj;
                }
            }

            //devolver
            return iObjEN;
        }

        public static List<ItemAlmacenEN> ListarItemAlmacenParaCopiarAEmpresa(string pCodigoEmpresaCopia, string pCodigoEmpresaGuarda)
        {
            //lista resultado
            List<ItemAlmacenEN> iLisRes = new List<ItemAlmacenEN>();

            //listar los ItemAlmacen de la empresa de donde se quiere copiar
            ItemAlmacenEN iIteAlmEN = new ItemAlmacenEN();
            iIteAlmEN.CodigoEmpresa = pCodigoEmpresaCopia;
            iIteAlmEN.Adicionales.CampoOrden = ItemAlmacenEN.CodIteAlm;
            List<ItemAlmacenEN> iLisIteAlmCop = ItemAlmacenRN.ListarItemAlmacenDeEmpresa(iIteAlmEN);

            //listar los ItemAlmacen de la empresa a donde se quiere copiar
            iIteAlmEN.CodigoEmpresa = pCodigoEmpresaGuarda;
            List<ItemAlmacenEN> iLisIteAlmGua = ItemAlmacenRN.ListarItemAlmacenDeEmpresa(iIteAlmEN);

            //obtener los Auxiliars que tiene la lista iLisAuxCop que no esten en iLisAuxGua
            iLisRes = ItemAlmacenRN.ObtenerDiferenciaAMenosB(iLisIteAlmCop, iLisIteAlmGua);

            //devolver
            return iLisRes;
        }

        public static List<ItemAlmacenEN> ListarItemAlmacenDeEmpresa(ItemAlmacenEN pObj)
        {
            ItemAlmacenAD iPerAD = new ItemAlmacenAD();
            return iPerAD.ListarItemAlmacenDeEmpresa(pObj);
        }

        public static List<ItemAlmacenEN> ObtenerDiferenciaAMenosB(List<ItemAlmacenEN> pLisIteAlmA, List<ItemAlmacenEN> pLisIteAlmB)
        {
            //lista resultado
            List<ItemAlmacenEN> iLisRes = new List<ItemAlmacenEN>();

            //recorrer cada objeto
            foreach (ItemAlmacenEN xIteAlmA in pLisIteAlmA)
            {
                //flag de encontrado
                int iEncontrado = 0;

                //recorre cada objeto
                foreach (ItemAlmacenEN xIteAlmB in pLisIteAlmB)
                {
                    if (xIteAlmA.CodigoItemAlmacen == xIteAlmB.CodigoItemAlmacen)
                    {
                        iEncontrado = 1;
                    }
                }

                //si no se encontro se agrega a la lista resultado
                if (iEncontrado == 0)
                {
                    iLisRes.Add(xIteAlmA);
                }
            }

            //devolver
            return iLisRes;
        }

        public static void ModificarVerdadFalsoItemAlmacen(ItemAlmacenEN pObj, List<ItemAlmacenEN> pLista)
        {
            //lista actualizada
            List<ItemAlmacenEN> iLisIteAlm = new List<ItemAlmacenEN>();

            //buscamos el objeto en la lista pLista
            foreach (ItemAlmacenEN xIteAlm in pLista)
            {
                if (xIteAlm.ClaveItemAlmacen == pObj.ClaveItemAlmacen)
                {
                    xIteAlm.VerdadFalso = pObj.VerdadFalso;
                }
                iLisIteAlm.Add(xIteAlm);
            }

            //actualizamos a la lista principal
            pLista.Clear();
            pLista.AddRange(iLisIteAlm);
        }

        public static ItemAlmacenEN HayObjetosMarcados(List<ItemAlmacenEN> pLista)
        {
            //objeto resultado
            ItemAlmacenEN iIteAlmEN = new ItemAlmacenEN();

            //sacar las cuotas solo marcadas
            List<ItemAlmacenEN> iLisIteAlmMar = ItemAlmacenRN.ListarItemAlmacenSoloMarcadas(pLista);

            //si la lista esta vacia entonces no hay marcados
            if (iLisIteAlmMar.Count == 0)
            {
                iIteAlmEN.Adicionales.EsVerdad = false;
                iIteAlmEN.Adicionales.Mensaje = "No hay Items Almacen marcados, no se puede realizar la operacion";
            }

            //ok           
            return iIteAlmEN;
        }

        public static List<ItemAlmacenEN> ListarItemAlmacenSoloMarcadas(List<ItemAlmacenEN> pLista)
        {
            //lista resultado
            List<ItemAlmacenEN> iLisRes = new List<ItemAlmacenEN>();

            //la lista tiene objetos para agregar y otros no, por eso solo
            //hay que sacar los chequeados
            foreach (ItemAlmacenEN xIteAlm in pLista)
            {
                if (xIteAlm.VerdadFalso == true)
                {
                    iLisRes.Add(xIteAlm);
                }
            }
            return iLisRes;
        }

        public static void AdicionarItemAlmacenPorCopia(string pCodigoEmpresaGuarda, List<ItemAlmacenEN> pLisIteAlmMar, List<ItemAlmacenEN> pLisIteAlmVal)
        {
            //lista de Auxiliars para adicionar
            List<ItemAlmacenEN> iLisIteAlmAdi = new List<ItemAlmacenEN>();

            //recorrer cada objeto
            foreach (ItemAlmacenEN xIteAlm in pLisIteAlmMar)
            {
                //para poder adicionar al objeto xAux, este debe existir en la lista de
                //Auxiliars que son validas a grabar en bd(pLisAuxVal)
                bool iExiste = ItemAlmacenRN.ExisteClaveItemAlmacenEnLista(xIteAlm.ClaveItemAlmacen, pLisIteAlmVal);
                if (iExiste == false) { continue; }

                //modificar datos
                xIteAlm.CodigoEmpresa = pCodigoEmpresaGuarda;
                xIteAlm.ClaveItemAlmacen = ItemAlmacenRN.ObtenerClaveItemAlmacen(xIteAlm);
                xIteAlm.COrigenVentanaCreacion = "02";//Ventana copia

                //agregar a la lista resultado
                iLisIteAlmAdi.Add(xIteAlm);
            }

            //luego adicionamos todas las Auxiliars en bd
            ItemAlmacenRN.AdicionarItemAlmacen(iLisIteAlmAdi);
        }

        public static bool ExisteClaveItemAlmacenEnLista(string pClaveItemAlmacen, List<ItemAlmacenEN> pLista)
        {
            //recorrer cada objeto
            foreach (ItemAlmacenEN xIteAlm in pLista)
            {
                if (pClaveItemAlmacen == xIteAlm.ClaveItemAlmacen)
                {
                    return true;
                }
            }

            //devolver
            return false;
        }

        public static void MarcarTodos(List<ItemAlmacenEN> pLista, bool pVerdadFalso)
        {
            //lista actualizada
            List<ItemAlmacenEN> iLisIteAlm = new List<ItemAlmacenEN>();

            //buscamos el objeto en la lista pLista
            foreach (ItemAlmacenEN xExi in pLista)
            {
                xExi.VerdadFalso = pVerdadFalso;
                iLisIteAlm.Add(xExi);
            }

            //actualizamos a la lista principal
            pLista.Clear();
            pLista.AddRange(iLisIteAlm);
        }

        public static ItemAlmacenEN EsActoEliminarCopiaItemAlmacen()
        {
            //objeto resultado
            ItemAlmacenEN iIteAlmEN = new ItemAlmacenEN();

            //valida cuando no hay auxiliares copia
            iIteAlmEN = ItemAlmacenRN.ValidaCuandoNoHayItemAlmacenCopia();
            if (iIteAlmEN.Adicionales.EsVerdad == false) { return iIteAlmEN; }

            //valida cuando no se puede eliminar ningun formato contable copia
            iIteAlmEN = ItemAlmacenRN.ValidaCuandoTodosLosItemAlmacenCopiaSonUtilizados();
            if (iIteAlmEN.Adicionales.EsVerdad == false) { return iIteAlmEN; }

            //ok            
            return iIteAlmEN;
        }

        public static ItemAlmacenEN ValidaCuandoNoHayItemAlmacenCopia()
        {
            //objeto resultado
            ItemAlmacenEN iIteAlmEN = new ItemAlmacenEN();

            //validar
            bool iHayValor = ItemAlmacenRN.ExisteValorEnColumna(ItemAlmacenEN.COriVenCre, "02", ItemAlmacenEN.CodEmp, Universal.gCodigoEmpresa);
            if (iHayValor == false)
            {
                iIteAlmEN.Adicionales.EsVerdad = false;
                iIteAlmEN.Adicionales.Mensaje = "No hay Items Almacen copiados en esta empresa";
            }

            //ok
            return iIteAlmEN;
        }

        public static ItemAlmacenEN ValidaCuandoTodosLosItemAlmacenCopiaSonUtilizados()
        {
            //objeto resultado
            ItemAlmacenEN iIteAlmEN = new ItemAlmacenEN();

            //validar
            List<ItemAlmacenEN> iLisIteAlmEli = ItemAlmacenRN.ListarItemAlmacenCopiaParaEliminar();
            if (iLisIteAlmEli.Count == 0)
            {
                iIteAlmEN.Adicionales.EsVerdad = false;
                iIteAlmEN.Adicionales.Mensaje = "Todos los Items Almacen copiados en esta empresa estan referenciados en los Registros contables";
            }

            //ok
            return iIteAlmEN;
        }

        public static List<ItemAlmacenEN> ListarItemAlmacenCopiaParaEliminar()
        {
            ItemAlmacenAD iPerAD = new ItemAlmacenAD();
            return iPerAD.ListarItemAlmacenCopiaParaEliminar();
        }

        public static void EliminarItemAlmacenCopia()
        {
            //listar los formatos contables copia actos para eliminar
            List<ItemAlmacenEN> iLisIteAlm = ItemAlmacenRN.ListarItemAlmacenCopiaParaEliminar();

            //eliminar
            ItemAlmacenRN.EliminarItemAlmacen(iLisIteAlm);
        }

        public static void AdicionarItemAlmacenPorImportacionExcel(List<ItemAlmacenEN> pLista)
        {
            //lista de Auxiliars para adicionar
            List<ItemAlmacenEN> iLisIteAlmAdi = new List<ItemAlmacenEN>();

            //traer todos los Items Almacen de la empresa actual
            List<ItemAlmacenEN> iLisIteAlm = ItemAlmacenRN.ListarItemAlmacen();

            //recorrer cada objeto
            foreach (ItemAlmacenEN xIteAlm in pLista)
            {
                //para poder adicionar al objeto xAux, este no debe existir en la lista de
                //Formatos contables que son validas a grabar en bd(pLisAuxVal)
                bool iExiste = ItemAlmacenRN.ExisteClaveItemAlmacenEnLista(xIteAlm.ClaveItemAlmacen, iLisIteAlm);
                if (iExiste == true) { continue; }

                //agregar a la lista resultado
                iLisIteAlmAdi.Add(xIteAlm);
            }

            //luego adicionamos todas las Auxiliars en bd
            ItemAlmacenRN.AdicionarItemAlmacen(iLisIteAlmAdi);
        }

        public static List<string> ListarCodigosItemAlmacen()
        {
            //lista resultado
            List<string> iLisRes = new List<string>();

            //traer la lista de todos los itemAlmacen de la empresa de b.d
            List<ItemAlmacenEN> iLisIteAlm = ItemAlmacenRN.ListarItemAlmacen();

            //recorrer cada objeto
            foreach (ItemAlmacenEN xIteAlm in iLisIteAlm)
            {
                iLisRes.Add(xIteAlm.CodigoAlmacen + "-" + xIteAlm.CodigoItemAlmacen);
            }

            //devolver
            return iLisRes;
        }

        public static List<ItemAlmacenEN> ListarItemAlmacenActivos(ItemAlmacenEN pObj)
        {
            ItemAlmacenAD iObjAD = new ItemAlmacenAD();
            return iObjAD.ListarItemAlmacenActivos(pObj);
        }

        public static List<ItemAlmacenEN> ListarItemAlmacenActivosDeAlmacen(ItemAlmacenEN pObj)
        {
            ItemAlmacenAD iObjAD = new ItemAlmacenAD();
            return iObjAD.ListarItemAlmacenActivosDeAlmacen(pObj);
        }


    }
}
