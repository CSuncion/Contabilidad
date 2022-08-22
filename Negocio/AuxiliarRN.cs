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
    public class AuxiliarRN
    {

        public static AuxiliarEN EnBlanco()
        {
            AuxiliarEN iAuxEN = new AuxiliarEN();
            return iAuxEN;
        }

        public static void AdicionarAuxiliar(AuxiliarEN pObj)
        {
            AuxiliarAD iPerAD = new AuxiliarAD();
            iPerAD.AgregarAuxiliar(pObj);
        }

        public static void AdicionarAuxiliar(List< AuxiliarEN> pLista)
        {
            AuxiliarAD iPerAD = new AuxiliarAD();
            iPerAD.AgregarAuxiliar(pLista);
        }

        public static void ModificarAuxiliar(AuxiliarEN pObj)
        {
            AuxiliarAD iPerAD = new AuxiliarAD();
            iPerAD.ModificarAuxiliar(pObj);
        }

        public static void EliminarAuxiliar(AuxiliarEN pObj)
        {
            AuxiliarAD iPerAD = new AuxiliarAD();
            iPerAD.EliminarAuxiliar(pObj);
        }

        public static List<AuxiliarEN> ListarAuxiliares(AuxiliarEN pObj)
        {
            AuxiliarAD iPerAD = new AuxiliarAD();
            return iPerAD.ListarAuxiliares(pObj);
        }

        public static AuxiliarEN BuscarAuxiliarXClave(AuxiliarEN pObj)
        {
            AuxiliarAD iPerAD = new AuxiliarAD();
            return iPerAD.BuscarAuxiliarXClave(pObj);
        }

        public static AuxiliarEN EsAuxiliarExistente(AuxiliarEN pObj)
        {
            //objeto resultado
            AuxiliarEN iAuxEN = new AuxiliarEN();

            //validar
            pObj.ClaveAuxiliar = AuxiliarRN.ObtenerClaveAuxiliar(pObj);
            iAuxEN = AuxiliarRN.BuscarAuxiliarXClave(pObj);
            if (iAuxEN.CodigoAuxiliar == string.Empty)
            {
                iAuxEN.Adicionales.EsVerdad = false;
                iAuxEN.Adicionales.Mensaje = "El Auxiliar de numero " + pObj.CodigoAuxiliar +
                                             " no existe";
                return iAuxEN;
            }

            //ok         
            return iAuxEN;
        }

        public static AuxiliarEN EsCodigoAuxiliarDisponible(AuxiliarEN pObj)
        {
            //objeto resultado
            AuxiliarEN iAuxEN = new AuxiliarEN();

            //valida cuando el codigo esta vacio
            if (pObj.CodigoAuxiliar == string.Empty) { return iAuxEN; }

            //valida cuando existe el codigo
            iAuxEN = AuxiliarRN.ValidaCuandoCodigoYaExiste(pObj);
            if (iAuxEN.Adicionales.EsVerdad == false) { return iAuxEN; }

            //ok          
            return iAuxEN;
        }

        public static AuxiliarEN ValidaCuandoCodigoYaExiste(AuxiliarEN pObj)
        {
            //objeto resultado
            AuxiliarEN iAuxEN = new AuxiliarEN();

            //validar     
            pObj.ClaveAuxiliar = AuxiliarRN.ObtenerClaveAuxiliar(pObj);
            iAuxEN = AuxiliarRN.BuscarAuxiliarXClave(pObj);
            if (iAuxEN.CodigoAuxiliar != string.Empty)
            {
                iAuxEN.Adicionales.EsVerdad = false;
                iAuxEN.Adicionales.Mensaje = "El Auxiliar de numero " + pObj.CodigoAuxiliar +
                                             " ya existe";
                return iAuxEN;
            }

            //ok
            iAuxEN.Adicionales.EsVerdad = true;
            return iAuxEN;
        }
        
        public static string ObtenerValorDeCampo(AuxiliarEN pObj, string pNombreCampo)
        {
            //valor resultado
            string iValor = string.Empty;

            //segun nombre campo
            switch (pNombreCampo)
            {
                case AuxiliarEN.ClaObj: return pObj.ClaveObjeto;
                case AuxiliarEN.ClaAux: return pObj.ClaveAuxiliar;
                case AuxiliarEN.CodEmp: return pObj.CodigoEmpresa;
                case AuxiliarEN.NomEmp: return pObj.NombreEmpresa;
                case AuxiliarEN.CodAux: return pObj.CodigoAuxiliar;
                case AuxiliarEN.ApePatAux: return pObj.ApellidoPaternoAuxiliar;
                case AuxiliarEN.ApeMatAux: return pObj.ApellidoMaternoAuxiliar;
                case AuxiliarEN.PriNomAux: return pObj.PrimerNombreAuxiliar;
                case AuxiliarEN.SegNomAux: return pObj.SegundoNombreAuxiliar;
                case AuxiliarEN.DesAux: return pObj.DescripcionAuxiliar;
                case AuxiliarEN.DirAux: return pObj.DireccionAuxiliar;
                case AuxiliarEN.TelAux: return pObj.TelefonoAuxiliar;
                case AuxiliarEN.CelAux: return pObj.CelularAuxiliar;
                case AuxiliarEN.CorAux: return pObj.CorreoAuxiliar;
                case AuxiliarEN.RefAux: return pObj.ReferenciaAuxiliar;
                case AuxiliarEN.CTipAux: return pObj.CTipoAuxiliar;
                case AuxiliarEN.NTipAux: return pObj.NTipoAuxiliar;
                case AuxiliarEN.CTipDocAux: return pObj.CTipoDocumentoAuxiliar;
                case AuxiliarEN.NTipDocAux: return pObj.NTipoDocumentoAuxiliar;
                case AuxiliarEN.CPaiNoDomAux: return pObj.CPaisNoDomiciliadoAuxiliar;
                case AuxiliarEN.NPaiNoDomAux: return pObj.NPaisNoDomiciliadoAuxiliar;
                case AuxiliarEN.FecInsSnpAux: return pObj.FechaInscripcionSnpAuxiliar;
                case AuxiliarEN.COriVenCre: return pObj.COrigenVentanaCreacion;
                case AuxiliarEN.NOriVenCre: return pObj.NOrigenVentanaCreacion;
                case AuxiliarEN.CEstAux: return pObj.CEstadoAuxiliar;
                case AuxiliarEN.NEstAux: return pObj.NEstadoAuxiliar;
                case AuxiliarEN.UsuAgr: return pObj.UsuarioAgrega;
                case AuxiliarEN.FecAgr: return pObj.FechaAgrega.ToString();
                case AuxiliarEN.UsuMod: return pObj.UsuarioModifica;
                case AuxiliarEN.FecMod: return pObj.FechaModifica.ToString();
            }

            //retorna
            return iValor;
        }

        public static List<AuxiliarEN> FiltrarAuxiliaresXTextoEnCualquierPosicion(List<AuxiliarEN> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<AuxiliarEN> iLisRes = new List<AuxiliarEN>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (AuxiliarEN xPer in pLista)
            {
                string iTexto = AuxiliarRN.ObtenerValorDeCampo(xPer, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xPer);
                }
            }

            //devolver
            return iLisRes;
        }

        public static List<AuxiliarEN> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<AuxiliarEN> pListaAuxiliares)
        {
            //lista resultado
            List<AuxiliarEN> iLisRes = new List<AuxiliarEN>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pListaAuxiliares; }

            //filtar la lista
            iLisRes = AuxiliarRN.FiltrarAuxiliaresXTextoEnCualquierPosicion(pListaAuxiliares, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }

        public static List<AuxiliarEN> ListarProveedores(AuxiliarEN pObj)
        {
            AuxiliarAD iPerAD = new AuxiliarAD();
            return iPerAD.ListarProveedores(pObj);
        }

        public static AuxiliarEN EsProveedorValido(AuxiliarEN pObj)
        {
            //objeto resultado
            AuxiliarEN iAuxEN = new AuxiliarEN();

            //valida cuando el codigo esta vacio
            if (pObj.CodigoAuxiliar == string.Empty) { return iAuxEN; }

            //valida cuando el codigo no existe
            iAuxEN = AuxiliarRN.EsAuxiliarExistente(pObj);
            if (iAuxEN.Adicionales.EsVerdad == false) { return iAuxEN; }

            //valida cuando no es proveedor o cliente/proveedor
            AuxiliarEN iAuxProEN = AuxiliarRN.ValidaCuandoNoEsProveedor(iAuxEN);
            if (iAuxProEN.Adicionales.EsVerdad == false) { return iAuxProEN; }

            //ok
            return iAuxEN;
        }

        public static AuxiliarEN ValidaCuandoNoEsProveedor(AuxiliarEN pObj)
        {
            //objeto resultado
            AuxiliarEN iAuxEN = new AuxiliarEN();

            //validar                 
            if (Cadena.ExisteValorEnConjuntoDeValores(pObj.CTipoAuxiliar,"1,2,3") == false)
            {
                iAuxEN.Adicionales.EsVerdad = false;
                iAuxEN.Adicionales.Mensaje = "El codigo " + pObj.CodigoAuxiliar + " no es de un proveedor";               
            }

            //ok           
            return iAuxEN;
        }

        public static AuxiliarEN EsActoModificarAuxiliar(AuxiliarEN pObj)
        {
            //objeto resultado
            AuxiliarEN iAuxEN = new AuxiliarEN();

            //validar si existe
            iAuxEN = AuxiliarRN.EsAuxiliarExistente(pObj);
            if (iAuxEN.Adicionales.EsVerdad == false) { return iAuxEN; }

            //ok            
            return iAuxEN;
        }

        public static AuxiliarEN EsActoEliminarAuxiliar(AuxiliarEN pObj)
        {
            //objeto resultado
            AuxiliarEN iAuxEN = new AuxiliarEN();

            //validar si existe
            iAuxEN = AuxiliarRN.EsAuxiliarExistente(pObj);
            if (iAuxEN.Adicionales.EsVerdad == false) { return iAuxEN; }

            //valida si existe este Personal en MovimientoCabe
            AuxiliarEN iAuxExiEN = AuxiliarRN.ValidaCuandoCodigoAuxiliarEstaEnMovimientoCabe(iAuxEN);
            if (iAuxExiEN.Adicionales.EsVerdad == false) { return iAuxExiEN; }

            //ok            
            return iAuxEN;
        }

        public static AuxiliarEN ValidaCuandoCodigoAuxiliarEstaEnMovimientoCabe(AuxiliarEN pObj)
        {
            //objeto resultado
            AuxiliarEN iAuxEN = new AuxiliarEN();

            ////valida
            //bool iExisten = MovimientoCabeRN.ExisteValorEnColumnaSinEmpresa(MovimientoCabeEN.CodAux, pObj.CodigoAuxiliar);
            //if (iExisten == true)
            //{
            //    iAuxEN.Adicionales.EsVerdad = false;
            //    iAuxEN.Adicionales.Mensaje = "Este Auxiliar tiene movimientos de Ingreso y/o Egresos, no se puede realizar la operacion";
            //    return iAuxEN;
            //}

            //ok
            return iAuxEN;
        }

        public static List<AuxiliarEN> ListarClientes(AuxiliarEN pObj)
        {
            AuxiliarAD iPerAD = new AuxiliarAD();
            return iPerAD.ListarClientes(pObj);
        }

        public static AuxiliarEN EsClienteValido(AuxiliarEN pObj)
        {
            //objeto resultado
            AuxiliarEN iAuxEN = new AuxiliarEN();

            //valida cuando el codigo esta vacio
            if (pObj.CodigoAuxiliar == string.Empty) { return iAuxEN; }

            //valida cuando el codigo no existe
            iAuxEN = AuxiliarRN.EsAuxiliarExistente(pObj);
            if (iAuxEN.Adicionales.EsVerdad == false) { return iAuxEN; }

            //valida cuando no es proveedor o cliente/proveedor
            AuxiliarEN iAuxProEN = AuxiliarRN.ValidaCuandoNoEsCliente(iAuxEN);
            if (iAuxProEN.Adicionales.EsVerdad == false) { return iAuxProEN; }

            //ok
            return iAuxEN;
        }

        public static AuxiliarEN ValidaCuandoNoEsCliente(AuxiliarEN pObj)
        {
            //objeto resultado
            AuxiliarEN iAuxEN = new AuxiliarEN();

            //validar                 
            if (Cadena.ExisteValorEnConjuntoDeValores(pObj.CTipoAuxiliar, "0,2") == false)
            {
                iAuxEN.Adicionales.EsVerdad = false;
                iAuxEN.Adicionales.Mensaje = "El codigo " + pObj.CodigoAuxiliar + " no es de un cliente";
                return iAuxEN;
            }

            //ok
            iAuxEN.Adicionales.EsVerdad = true;
            return iAuxEN;
        }

        public static string ObtenerClaveAuxiliar(AuxiliarEN pObj)
        {
            //valor resultado
            string iClave = string.Empty;

            //armar clave
            iClave += Universal.gCodigoEmpresa + "-";         
            iClave += pObj.CodigoAuxiliar;

            //retornar
            return iClave;
        }

        public static string ArmarDescripcionAuxiliar(AuxiliarEN pObj)
        {
            //segun clase
            if (pObj.CClaseAuxiliar == "0")//natural
            {
                string iDescripcion = string.Empty;
                iDescripcion += pObj.ApellidoPaternoAuxiliar + Cadena.Espacios(1);
                iDescripcion += pObj.ApellidoMaternoAuxiliar + Cadena.Espacios(1);
                iDescripcion += pObj.PrimerNombreAuxiliar + Cadena.Espacios(1);
                iDescripcion += pObj.SegundoNombreAuxiliar;
                return iDescripcion;
            }
            else
            {
                return pObj.DescripcionAuxiliar;
            }
        }

        public static List<AuxiliarEN> ListarAuxiliarsParaCopiarAEmpresa(string pCodigoEmpresaCopia, string pCodigoEmpresaGuarda)
        {
            //lista resultado
            List<AuxiliarEN> iLisRes = new List<AuxiliarEN>();

            //listar los Auxiliars de la empresa de donde se quiere copiar
            AuxiliarEN iAuxEN = new AuxiliarEN();
            iAuxEN.CodigoEmpresa = pCodigoEmpresaCopia;
            iAuxEN.Adicionales.CampoOrden = AuxiliarEN.CodAux;
            List<AuxiliarEN> iLisAuxCop = AuxiliarRN.ListarAuxiliarsDeEmpresa(iAuxEN);

            //listar los auxiliares de la empresa a donde se quiere copiar
            iAuxEN.CodigoEmpresa = pCodigoEmpresaGuarda;
            List<AuxiliarEN> iLisAuxGua = AuxiliarRN.ListarAuxiliarsDeEmpresa(iAuxEN);

            //obtener los Auxiliars que tiene la lista iLisAuxCop que no esten en iLisAuxGua
            iLisRes = AuxiliarRN.ObtenerDiferenciaAMenosB(iLisAuxCop, iLisAuxGua);

            //devolver
            return iLisRes;
        }

        public static List<AuxiliarEN> ListarAuxiliarsDeEmpresa(AuxiliarEN pObj)
        {
            AuxiliarAD iPerAD = new AuxiliarAD();
            return iPerAD.ListarAuxiliarsDeEmpresa(pObj);
        }

        public static List<AuxiliarEN> ObtenerDiferenciaAMenosB(List<AuxiliarEN> pLisAuxA, List<AuxiliarEN> pLisAuxB)
        {
            //lista resultado
            List<AuxiliarEN> iLisRes = new List<AuxiliarEN>();

            //recorrer cada objeto
            foreach (AuxiliarEN xAuxA in pLisAuxA)
            {
                //flag de encontrado
                int iEncontrado = 0;

                //recorre cada objeto
                foreach (AuxiliarEN xAuxB in pLisAuxB)
                {
                    if (xAuxA.CodigoAuxiliar == xAuxB.CodigoAuxiliar)
                    {
                        iEncontrado = 1;
                    }
                }

                //si no se encontro se agrega a la lista resultado
                if (iEncontrado == 0)
                {
                    iLisRes.Add(xAuxA);
                }
            }

            //devolver
            return iLisRes;
        }

        public static void ModificarVerdadFalsoAuxiliar(AuxiliarEN pObj, List<AuxiliarEN> pLista)
        {
            //lista actualizada
            List<AuxiliarEN> iLisAux = new List<AuxiliarEN>();

            //buscamos el objeto en la lista pLista
            foreach (AuxiliarEN xAux in pLista)
            {
                if (xAux.ClaveAuxiliar == pObj.ClaveAuxiliar)
                {
                    xAux.VerdadFalso = pObj.VerdadFalso;
                }
                iLisAux.Add(xAux);
            }

            //actualizamos a la lista principal
            pLista.Clear();
            pLista.AddRange(iLisAux);
        }

        public static AuxiliarEN HayObjetosMarcados(List<AuxiliarEN> pLista)
        {
            //objeto resultado
            AuxiliarEN iAuxEN = new AuxiliarEN();

            //sacar las cuotas solo marcadas
            List<AuxiliarEN> iLisAuxMar = AuxiliarRN.ListarAuxiliarsSoloMarcadas(pLista);

            //si la lista esta vacia entonces no hay marcados
            if (iLisAuxMar.Count == 0)
            {
                iAuxEN.Adicionales.EsVerdad = false;
                iAuxEN.Adicionales.Mensaje = "No hay auxiliares marcados, no se puede realizar la operacion";
                return iAuxEN;
            }
            //ok
            iAuxEN.Adicionales.EsVerdad = true;
            return iAuxEN;
        }

        public static List<AuxiliarEN> ListarAuxiliarsSoloMarcadas(List<AuxiliarEN> pLista)
        {
            //lista resultado
            List<AuxiliarEN> iLisRes = new List<AuxiliarEN>();

            //la lista tiene objetos para agregar y otros no, por eso solo
            //hay que sacar los chequeados
            foreach (AuxiliarEN xAux in pLista)
            {
                if (xAux.VerdadFalso == true)
                {
                    iLisRes.Add(xAux);
                }
            }
            return iLisRes;
        }

        public static void AdicionarAuxiliarsPorCopia(string pCodigoEmpresaGuarda, List<AuxiliarEN> pLisAuxMar, List<AuxiliarEN> pLisAuxVal)
        {
            //lista de Auxiliars para adicionar
            List<AuxiliarEN> iLisAuxAdi = new List<AuxiliarEN>();
            
            //recorrer cada objeto
            foreach (AuxiliarEN xAux in pLisAuxMar)
            {
                //para poder adicionar al objeto xAux, este debe existir en la lista de
                //Auxiliars que son validas a grabar en bd(pLisAuxVal)
                bool iExiste = AuxiliarRN.ExisteClaveAuxiliarEnLista(xAux.ClaveAuxiliar, pLisAuxVal);
                if (iExiste == false) { continue; }

                //modificar datos
                xAux.CodigoEmpresa = pCodigoEmpresaGuarda;
                xAux.ClaveAuxiliar = AuxiliarRN.ObtenerClaveAuxiliar(xAux);
                xAux.COrigenVentanaCreacion = "02";//Ventana copia
                
                //agregar a la lista resultado
                iLisAuxAdi.Add(xAux);                
            }

            //luego adicionamos todas las Auxiliars en bd
            AuxiliarRN.AdicionarAuxiliar(iLisAuxAdi);            
        }

        public static bool ExisteClaveAuxiliarEnLista(string pClaveAuxiliar, List<AuxiliarEN> pLista)
        {
            //recorrer cada objeto
            foreach (AuxiliarEN xAux in pLista)
            {
                if (pClaveAuxiliar == xAux.ClaveAuxiliar)
                {
                    return true;
                }
            }

            //devolver
            return false;
        }

        public static void MarcarTodos(List<AuxiliarEN> pLista, bool pVerdadFalso)
        {
            //lista actualizada
            List<AuxiliarEN> iLisAux = new List<AuxiliarEN>();

            //buscamos el objeto en la lista pLista
            foreach (AuxiliarEN xExi in pLista)
            {
                xExi.VerdadFalso = pVerdadFalso;
                iLisAux.Add(xExi);
            }

            //actualizamos a la lista principal
            pLista.Clear();
            pLista.AddRange(iLisAux);
        }

        public static AuxiliarEN EsActoEliminarCopiaAuxiliar()
        {
            //objeto resultado
            AuxiliarEN iAuxEN = new AuxiliarEN();

            //valida cuando no hay auxiliares copia
            iAuxEN = AuxiliarRN.ValidaCuandoNoHayAuxiliaresCopia();
            if (iAuxEN.Adicionales.EsVerdad == false) { return iAuxEN; }



            //ok            
            return iAuxEN;
        }

        public static List<AuxiliarEN> ListarAuxiliaresCopia(AuxiliarEN pObj)
        {
            AuxiliarAD iPerAD = new AuxiliarAD();
            return iPerAD.ListarAuxiliaresCopia(pObj);
        }

        public static List<AuxiliarEN> ListarAuxiliaresCopia()
        {
            //asignar parametros
            AuxiliarEN iAuxEN = new AuxiliarEN();
            iAuxEN.Adicionales.CampoOrden = AuxiliarEN.CodAux;

            //ejecutar metodo
            return AuxiliarRN.ListarAuxiliaresCopia(iAuxEN);
        }

        public static AuxiliarEN ValidaCuandoNoHayAuxiliaresCopia()
        {
            //objeto resultado
            AuxiliarEN iAuxEN = new AuxiliarEN();

            //validar
            List<AuxiliarEN> iLisAuxCop = AuxiliarRN.ListarAuxiliaresCopia();
            if (iLisAuxCop.Count == 0)
            {
                iAuxEN.Adicionales.EsVerdad = false;
                iAuxEN.Adicionales.Mensaje = "No hay auxiliares copiados en esta empresa";
                return iAuxEN;
            }

            //ok
            return iAuxEN;
        }

        public static List<AuxiliarEN> ListarAuxiliaresCopiaParaEliminar()
        {            
            return AuxiliarRN.ListarAuxiliaresCopia();//xxxxxxxxxxxxx
        }

        public static void EliminarAuxiliaresCopia()
        {
            AuxiliarAD iPerAD = new AuxiliarAD();
            iPerAD.EliminarAuxiliaresCopia();
        }

        public static List<string> ListarCodigosAuxiliares()
        {
            //lista resultado
            List<string> iLisRes = new List<string>();

            //traer a todos los auxiliares de la empresa de acceso
            List<AuxiliarEN> iLisAux = AuxiliarRN.ListarAuxiliares();

            //recorrer cada objeto auxiliar
            foreach (AuxiliarEN xAux in iLisAux)
            {
                iLisRes.Add(xAux.CodigoAuxiliar);
            }

            //devolver
            return iLisRes;
        }

        public static List<AuxiliarEN> ListarAuxiliares()
        {
            //asignar parametros
            AuxiliarEN iAuxEN = new AuxiliarEN();
            iAuxEN.Adicionales.CampoOrden = AuxiliarEN.CodAux;

            //ejecutar metodo
            return AuxiliarRN.ListarAuxiliares(iAuxEN);
        }

        public static AuxiliarEN EsActoEliminarImportacionAuxiliar()
        {
            //objeto resultado
            AuxiliarEN iAuxEN = new AuxiliarEN();

            //valida cuando no hay auxiliares importados
            iAuxEN = AuxiliarRN.ValidaCuandoNoHayAuxiliaresImportados();
            if (iAuxEN.Adicionales.EsVerdad == false) { return iAuxEN; }



            //ok            
            return iAuxEN;
        }

        public static List<AuxiliarEN> ListarAuxiliaresImportados(AuxiliarEN pObj)
        {
            AuxiliarAD iPerAD = new AuxiliarAD();
            return iPerAD.ListarAuxiliaresImportados(pObj);
        }

        public static List<AuxiliarEN> ListarAuxiliaresImportados()
        {
            //asignar parametros
            AuxiliarEN iAuxEN = new AuxiliarEN();
            iAuxEN.Adicionales.CampoOrden = AuxiliarEN.CodAux;

            //ejecutar metodo
            return AuxiliarRN.ListarAuxiliaresImportados(iAuxEN);
        }

        public static AuxiliarEN ValidaCuandoNoHayAuxiliaresImportados()
        {
            //objeto resultado
            AuxiliarEN iAuxEN = new AuxiliarEN();

            //validar
            List<AuxiliarEN> iLisAuxImp = AuxiliarRN.ListarAuxiliaresImportados();
            if (iLisAuxImp.Count == 0)
            {
                iAuxEN.Adicionales.EsVerdad = false;
                iAuxEN.Adicionales.Mensaje = "No hay auxiliares importados en esta empresa";
                return iAuxEN;
            }

            //ok
            return iAuxEN;
        }

        public static void EliminarAuxiliaresImportacion()
        {
            AuxiliarAD iPerAD = new AuxiliarAD();
            iPerAD.EliminarAuxiliaresImportacion();
        }

        public static void AdicionarAuxiliarsPorImportacionExcel(List<AuxiliarEN> pLista)
        {
            //lista de Auxiliars para adicionar
            List<AuxiliarEN> iLisAuxAdi = new List<AuxiliarEN>();

            //traer todos los auxiliares de la empresa
            List<AuxiliarEN> iLisAux = AuxiliarRN.ListarAuxiliares();

            //recorrer cada objeto
            foreach (AuxiliarEN xAux in pLista)
            {
                //para poder adicionar al objeto xAux, este no debe existir en la lista de
                //Auxiliars que son validas a grabar en bd(pLisAuxVal)
                bool iExiste = AuxiliarRN.ExisteClaveAuxiliarEnLista(xAux.ClaveAuxiliar, iLisAux);
                if (iExiste == true) { continue; }
                               
                //agregar a la lista resultado
                iLisAuxAdi.Add(xAux);
            }

            //luego adicionamos todas las Auxiliars en bd
            AuxiliarRN.AdicionarAuxiliar(iLisAuxAdi);
        }

        public static void ActualizarAuxiliaresImportacionExcelParaGrabar(List<AuxiliarEN> pLista)
        {
            //recorrer cada objeto
            foreach (AuxiliarEN xAux in pLista)
            {
                AuxiliarRN.ActualizarAuxiliarImportacionExcelParaGrabar(xAux);
            }
        }

        public static void ActualizarAuxiliarImportacionExcelParaGrabar(AuxiliarEN pAux)
        {
            //limpiando datos
            if (pAux.CClaseAuxiliar == "0")//natural
            {
                pAux.CPaisNoDomiciliadoAuxiliar = string.Empty;
                pAux.DescripcionAuxiliar = AuxiliarRN.ArmarDescripcionAuxiliar(pAux);
            }
            else
            {
                pAux.ApellidoPaternoAuxiliar = string.Empty;
                pAux.ApellidoMaternoAuxiliar = string.Empty;
                pAux.PrimerNombreAuxiliar = string.Empty;
                pAux.SegundoNombreAuxiliar = string.Empty;
            }
           
        }

        public static List<AuxiliarEN> ListarProveedoresActivos(AuxiliarEN pObj)
        {
            AuxiliarAD iPerAD = new AuxiliarAD();
            return iPerAD.ListarProveedoresActivos(pObj);
        }

        public static AuxiliarEN EsProveedorActivoValido(AuxiliarEN pObj)
        {
            //objeto resultado
            AuxiliarEN iAuxEN = new AuxiliarEN();

            //valida cuando el codigo esta vacio
            if (pObj.CodigoAuxiliar == string.Empty) { return iAuxEN; }

            //valida cuando el codigo no existe
            iAuxEN = AuxiliarRN.EsAuxiliarExistente(pObj);
            if (iAuxEN.Adicionales.EsVerdad == false) { return iAuxEN; }

            //valida cuando no es proveedor o cliente/proveedor o personal
            AuxiliarEN iAuxProEN = AuxiliarRN.ValidaCuandoNoEsProveedor(iAuxEN);
            if (iAuxProEN.Adicionales.EsVerdad == false) { return iAuxProEN; }

            //valida cuando esta desactivado
            AuxiliarEN iAuxDesEN = AuxiliarRN.ValidaCuandoProveedorEstaDesactivado(iAuxEN);
            if (iAuxDesEN.Adicionales.EsVerdad == false) { return iAuxDesEN; }

            //ok
            return iAuxEN;
        }

        public static AuxiliarEN ValidaCuandoProveedorEstaDesactivado(AuxiliarEN pObj)
        {
            //objeto resultado
            AuxiliarEN iAuxEN = new AuxiliarEN();

            //validar                 
            if (pObj.CEstadoAuxiliar == "0")//desactivado
            {
                iAuxEN.Adicionales.EsVerdad = false;
                iAuxEN.Adicionales.Mensaje = "El proveedor " + pObj.CodigoAuxiliar + " esta desactivado";               
            }

            //ok           
            return iAuxEN;
        }


    }
}
