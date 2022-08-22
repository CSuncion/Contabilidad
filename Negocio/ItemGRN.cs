using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comun;
using Entidades;
using Datos;

namespace Negocio
{
    public class ItemGRN
    {

        public static ItemGEN EnBlanco( )
        {
            ItemGEN iIteEN = new ItemGEN( );           
            return iIteEN;
        }
        
        public static void AdicionarItemG( ItemGEN pObj )
        {
            ItemGAD iIteAD = new ItemGAD( );
            iIteAD.AgregarItemG( pObj );
        }
        
        public static void ModificarItemG( ItemGEN pObj )
        {
            ItemGAD iIteAD = new ItemGAD( );
            iIteAD.ModificarItemG( pObj );
        }
        
        public static void EliminarItemG( ItemGEN pObj )
        {
            ItemGAD iIteAD = new ItemGAD( );
            iIteAD.EliminarItemG( pObj );
        }
        
        public static List<ItemGEN> ListarItemsGXTabla( ItemGEN pObj )
        {
            ItemGAD iIteAD = new ItemGAD( );
            return iIteAD.ListarItemsGXTabla( pObj );
        }
        
        public static List<ItemGEN> ListarItemsGActivosXTabla( ItemGEN pObj )
        {
            ItemGAD iIteAD = new ItemGAD( );           
            return iIteAD.ListarItemsGActivosXTabla( pObj );
        }

        public static List<ItemGEN> ListarItemsGActivosXTablaYClase(ItemGEN pObj)
        {
            ItemGAD iIteAD = new ItemGAD();
            return iIteAD.ListarItemsGActivosXTablaYClase(pObj);
        }

        public static List<ItemGEN> ListarItemsGActivosXTablaYFiltroCodigo(ItemGEN pObj)
        {
            ItemGAD iIteAD = new ItemGAD();
            return iIteAD.ListarItemsGActivosXTablaYFiltroCodigo(pObj);
        }
        
        public static ItemGEN buscarItemGXClave( ItemGEN pObj )
        {
            ItemGAD iIteAD = new ItemGAD( );
            return iIteAD.BuscarItemGXClave( pObj );
        }
        
        public static List<ItemGEN> ListarItemsG( string pTabla )
        {           
            ItemGEN iTipUsuEN = new ItemGEN( );
            iTipUsuEN.CodigoTabla = pTabla;
            iTipUsuEN.Adicionales.CampoOrden = ItemGEN.CodIteG;
            return ItemGRN.ListarItemsGActivosXTabla(iTipUsuEN);        
        }
        
        public static ItemGEN EsItemGValido( ItemGEN pObj)
        {
            ItemGEN iIteEN = new ItemGEN( );

            //validar cuando hay codigo
            if (pObj.CodigoItemG != string.Empty)
            {
                //validar si existe
                iIteEN.ClaveItemG = ItemGRN.ObtenerClaveItemG(pObj);
                iIteEN = ItemGRN.buscarItemGXClave(iIteEN);
                if (iIteEN.CodigoItemG == string.Empty)
                {
                    iIteEN.Adicionales.EsVerdad = false;
                    iIteEN.Adicionales.Mensaje = "El Item" + Cadena.Espacios(1) + pObj.CodigoItemG + Cadena.Espacios(1) + "no existe";
                    return iIteEN;
                }

                //validar si esta dasctivado
                if (iIteEN.CEstadoItemG == "0") //desactivado
                {
                    iIteEN = ItemGRN.EnBlanco();
                    iIteEN.Adicionales.EsVerdad = false;
                    iIteEN.Adicionales.Mensaje = "El Item" + Cadena.Espacios(1) + pObj.CodigoItemG + Cadena.Espacios(1) + "esta desactivado";
                    return iIteEN;
                }
            }
      
            //ok
            iIteEN.Adicionales.EsVerdad = true;
            return iIteEN;
        }
        
        public static ItemGEN EsItemGExistente( ItemGEN pObj )
        {
            ItemGEN iIteEN = new ItemGEN( );
            iIteEN = ItemGRN.buscarItemGXClave(pObj);
            if ( iIteEN.CodigoItemG == string.Empty )
            {
                iIteEN.Adicionales.EsVerdad = false;
                iIteEN.Adicionales.Mensaje = "El Item " + pObj.CodigoItemG + " no existe";
            }
            else
            {
                iIteEN.Adicionales.EsVerdad = true;

            }
            return iIteEN;
        }
        
        public static ItemGEN EsCodigoItemGDisponible( ItemGEN pObj , bool pVacio )
        {
            ItemGEN iIteEN = new ItemGEN( );

            if ( pVacio == true )
            {
                if ( pObj.CodigoItemG == string.Empty )
                {
                    iIteEN.Adicionales.EsVerdad = false;
                    iIteEN.Adicionales.Mensaje = "Debes ingresar un codigo Item";
                    return iIteEN;
                }

            }
            else
            {
                if ( pObj.CodigoItemG == string.Empty )
                {
                    iIteEN.Adicionales.EsVerdad = true;
                    iIteEN.Adicionales.Mensaje = "";
                    return iIteEN;
                }
            }

            iIteEN = ItemGRN.buscarItemGXClave(pObj);
            if ( iIteEN.CodigoItemG == string.Empty )
            {
                iIteEN.Adicionales.EsVerdad = true;
            }
            else
            {
                iIteEN.Adicionales.EsVerdad = false;
                iIteEN.Adicionales.Mensaje = "El codigo " + pObj.CodigoItemG + " ya le pertenece a otro registro";
            }
            return iIteEN;
        }

        public static string ObtenerClaveItemG(ItemGEN pObj)
        {
            //variavle resulatdo
            string iClave = string.Empty;
            iClave += pObj.CodigoTabla + "-";
            iClave += pObj.CodigoItemG;
            return iClave;
        }

        public static List<ItemGEN> ListarTiposAuxiliarParaJuridico( )
        {
            //lista resultado
            List<ItemGEN> iLisRes = new List<ItemGEN>();

            //traer todos los tipos de auxiliares
            List<ItemGEN> iLisTipAux = ItemGRN.ListarItemsG("TipAux");

            //recorre cada objeto
            foreach (ItemGEN xItem in iLisTipAux)
            {
                //de esta lista sacar el tipo de auxiliar(0 : personal) ya que 
                //ninguna empresa puede ser de este tipo
                if (xItem.CodigoItemG != "0")
                {
                    iLisRes.Add(xItem);
                }    
            }
            //retornar la lista actualizada
            return iLisRes;
        }

        public static ItemGEN buscarItemGXNombre(ItemGEN pObj,List<ItemGEN> pLista)
        {
            //objeto resultado
            ItemGEN iIteGEN = new ItemGEN();

            //si el nombre es M25 entonces sera el codigo de M2
            if (pObj.NombreItemG == "M25")
            {
                iIteGEN.CodigoItemG = "01";
                return iIteGEN;
            }

            //buscar en la lista
            foreach (ItemGEN xIte in pLista)
            {
                if (xIte.NombreItemG == pObj.NombreItemG)
                {
                    iIteGEN = xIte;
                    return iIteGEN;
                }
            }

            //sino hay nada devuelve vacio
            return iIteGEN;
        }

        public static List<ItemGEN> ListarClasesProductoExceptoTodos(ItemGEN pObj)
        {
            //lista resultado
            List<ItemGEN> iLisRes = new List<ItemGEN>();

            //traer a todos los items de clase de producto
            List<ItemGEN> iLisClaPro = ItemGRN.ListarItemsGActivosXTablaYFiltroCodigo(pObj);

            //pasar todos los item a exepcion de el item Todos
            foreach (ItemGEN xIte in iLisClaPro)
            {
                if (xIte.CodigoItemG.Substring(2) != "00")
                {
                    iLisRes.Add(xIte);
                }                
            }
            
            //devolver
            return iLisRes;
        }

        public static string ObtenerValorDeCampo(ItemGEN pObj, string pNombreCampo)
        {
            //valor resultado
            string iValor = string.Empty;

            //segun nombre campo
            switch (pNombreCampo)
            {              
                case ItemGEN.CodIteG: return pObj.CodigoItemG;
                case ItemGEN.NomIteG: return pObj.NombreItemG;               
            }
            //retorna
            return iValor;
        }

        public static List<ItemGEN> FiltrarItemGsXTextoEnCualquierPosicion(List<ItemGEN> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<ItemGEN> iLisRes = new List<ItemGEN>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (ItemGEN xCli in pLista)
            {
                string iTexto = ItemGRN.ObtenerValorDeCampo(xCli, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xCli);
                }
            }

            //devolver
            return iLisRes;
        }

        public static List<ItemGEN> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<ItemGEN> pListaItemG)
        {
            //lista resultado
            List<ItemGEN> iLisRes = new List<ItemGEN>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pListaItemG; }

            //filtar la lista
            iLisRes = ItemGRN.FiltrarItemGsXTextoEnCualquierPosicion(pListaItemG, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }

        public static List<ItemGEN> ListarEstadosProformaParaSeparar()
        {
            ItemGAD iIteAD = new ItemGAD();
            return iIteAD.ListarEstadosProformaParaSeparar();
        }

        public static List<ItemGEN> ListarEstadosProformaParaVender()
        {
            ItemGAD iIteAD = new ItemGAD();
            return iIteAD.ListarEstadosProformaParaVender();
        }

        public static ItemGEN BuscarItemXCodigo(ItemGEN pObj, List<ItemGEN> pLista)
        {
            //objeto resultado
            ItemGEN iIteEN = new ItemGEN();

            //recorrer cada objeto
            foreach (ItemGEN xIte in pLista)
            {
                if (xIte.CodigoItemG == pObj.CodigoItemG)
                {
                    iIteEN = xIte;
                    return iIteEN;
                }
            }

            //devolver no encontrado
            return iIteEN;
        }

        public static List<ItemGEN> ListarItemsSoloNotas()
        {
            ItemGAD iIteAD = new ItemGAD();
            return iIteAD.ListarItemsSoloNotas();
        }

        public static void AgregarItemTodos(List<ItemGEN> pLista)
        {
            //creamos el item todos
            ItemGEN iIteGEN = new ItemGEN();
            iIteGEN.CodigoItemG = "";
            iIteGEN.NombreItemG = "Todos";
            pLista.Add(iIteGEN);        
        }

        public static List<ItemGEN> ListarItemsGMasItemTodos(string pTabla)
        {
            //lista resultado
            List<ItemGEN> iLisIteG = new List<ItemGEN>();

            //llenar con los items de la base de datos
            iLisIteG = ItemGRN.ListarItemsG(pTabla);

            //ahora insertamos al final el item "todos"
            ItemGRN.AgregarItemTodos(iLisIteG);
            
            //devolver
            return iLisIteG;
        }

        public static List<ItemGEN> ListarFormaPagoSoloTotal()
        {
            //lista resultado
            List<ItemGEN> iLisRes = new List<ItemGEN>();

            //creamos el item todos
            ItemGEN iIteGEN = new ItemGEN();
            iIteGEN.CodigoItemG = "0";
            iIteGEN.NombreItemG = "Total";

            //adicionar a la lista
            iLisRes.Add(iIteGEN);

            //devolver
            return iLisRes;
        }

        public static List<ItemGEN> ListarItemsMonedaPagoSinAmbos()
        {
            ItemGAD iIteAD = new ItemGAD();
            return iIteAD.ListarItemsMonedaPagoSinAmbos();
        }

        public static List<string> ListarCodigosItems(string pTabla)
        {
            //lista resultado
            List<string> iLisRes = new List<string>();

            //traer a todos los items de la tabla
            List<ItemGEN> iLisIte = ItemGRN.ListarItemsG(pTabla);

            //recorrer cada objeto auxiliar
            foreach (ItemGEN xIte in iLisIte)
            {
                iLisRes.Add(xIte.CodigoItemG);
            }

            //devolver
            return iLisRes;
        }

    }
}
