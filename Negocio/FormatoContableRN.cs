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
    public class FormatoContableRN
    {

        public static FormatoContableEN EnBlanco()
        {
            FormatoContableEN iObjEN = new FormatoContableEN();
            return iObjEN;
        }

        public static void AdicionarFormatoContable(List<FormatoContableEN> pLista)
        {
            FormatoContableAD iObjAD = new FormatoContableAD();
            iObjAD.AdicionarFormatoContable(pLista);
        }

        public static void AdicionarFormatoContable(FormatoContableEN pObj)
        {
            //Asignar parametros
            List<FormatoContableEN> iLisObj = new List<FormatoContableEN>();
            iLisObj.Add(pObj);

            //Ejecutar metodo
            FormatoContableRN.AdicionarFormatoContable(iLisObj);
        }

        public static void ModificarFormatoContable(List<FormatoContableEN> pLista)
        {
            FormatoContableAD iObjAD = new FormatoContableAD();
            iObjAD.ModificarFormatoContable(pLista);
        }

        public static void ModificarFormatoContable(FormatoContableEN pObj)
        {
            //Asignar parametros
            List<FormatoContableEN> iLisObj = new List<FormatoContableEN>();
            iLisObj.Add(pObj);

            //Ejecutar metodo
            FormatoContableRN.ModificarFormatoContable(iLisObj);
        }

        public static void EliminarFormatoContable(List<FormatoContableEN> pLista)
        {
            FormatoContableAD iObjAD = new FormatoContableAD();
            iObjAD.EliminarFormatoContable(pLista);
        }

        public static void EliminarFormatoContable(FormatoContableEN pObj)
        {
            //Asignar parametros
            List<FormatoContableEN> iLisObj = new List<FormatoContableEN>();
            iLisObj.Add(pObj);

            //Ejecutar metodo
            FormatoContableRN.EliminarFormatoContable(iLisObj);
        }

        public static List<FormatoContableEN> ListarFormatoContable(FormatoContableEN pObj)
        {
            FormatoContableAD iObjAD = new FormatoContableAD();
            return iObjAD.ListarFormatoContable(pObj);
        }

        public static List<FormatoContableEN> ListarFormatoContable()
        {
            //asignar parametros
            FormatoContableEN iObjEN = new FormatoContableEN();
            iObjEN.Adicionales.CampoOrden = FormatoContableEN.ClaForCon;

            //ejecutar metodo
            return FormatoContableRN.ListarFormatoContable(iObjEN);
        }

        public static FormatoContableEN BuscarFormatoContableXClave(FormatoContableEN pObj)
        {
            FormatoContableAD iObjAD = new FormatoContableAD();
            return iObjAD.BuscarFormatoContableXClave(pObj);
        }

        public static FormatoContableEN EsFormatoContableExistente(FormatoContableEN pObj)
        {
            //objeto resultado
            FormatoContableEN iObjEN = new FormatoContableEN();

            //validar si existe en b.d
            iObjEN = FormatoContableRN.BuscarFormatoContableXClave(pObj);
            if (iObjEN.ClaveFormatoContable == string.Empty)
            {
                iObjEN.Adicionales.EsVerdad = false;
                iObjEN.Adicionales.Mensaje = "El Registro seleccionado no existe";
            }

            //ok  
            return iObjEN;
        }

        public static FormatoContableEN EsCodigoFormatoContableDisponible(FormatoContableEN pObj)
        {
            //objeto resultado
            FormatoContableEN iObjEN = new FormatoContableEN();

            //valida cuando esta vacio
            if (pObj.CodigoFormatoContable == string.Empty) { return iObjEN; }

            //validar si existe
            iObjEN = FormatoContableRN.ValidaCuandoCodigoYaExiste(pObj);
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }

            //ok           
            return iObjEN;
        }

        public static FormatoContableEN ValidaCuandoCodigoYaExiste(FormatoContableEN pObj)
        {
            //objeto resultado
            FormatoContableEN iObjEN = new FormatoContableEN();

            //validar
            iObjEN = FormatoContableRN.BuscarFormatoContableXClave(pObj);
            if (iObjEN.ClaveFormatoContable != string.Empty)
            {
                iObjEN.Adicionales.EsVerdad = false;
                iObjEN.Adicionales.Mensaje = "Este codigo ya existe";
            }

            //ok  
            return iObjEN;
        }

        public static string ObtenerValorDeCampo(FormatoContableEN pObj, string pNombreCampo)
        {
            //valor resultado
            string iValor = string.Empty;

            //segun nombre campo
            switch (pNombreCampo)
            {
                case FormatoContableEN.ClaObj: return pObj.ClaveObjeto;
                case FormatoContableEN.ClaForCon: return pObj.ClaveFormatoContable;
                case FormatoContableEN.CodEmp: return pObj.CodigoEmpresa;
                case FormatoContableEN.NomEmp: return pObj.NombreEmpresa;
                case FormatoContableEN.CodForCon: return pObj.CodigoFormatoContable;
                case FormatoContableEN.DesForCon: return pObj.DescripcionFormatoContable;
                case FormatoContableEN.DesAltForCon: return pObj.DescripcionAlternaFormatoContable;
                case FormatoContableEN.CGru: return pObj.CGrupo;
                case FormatoContableEN.NGru: return pObj.NGrupo;
                case FormatoContableEN.CNat: return pObj.CNaturaleza;
                case FormatoContableEN.NNat: return pObj.NNaturaleza;
                case FormatoContableEN.CEstForCon: return pObj.CEstadoFormatoContable;
                case FormatoContableEN.NEstForCon: return pObj.NEstadoFormatoContable;
                case FormatoContableEN.UsuAgr: return pObj.UsuarioAgrega;
                case FormatoContableEN.FecAgr: return pObj.FechaAgrega.ToString();
                case FormatoContableEN.UsuMod: return pObj.UsuarioModifica;
                case FormatoContableEN.FecMod: return pObj.FechaModifica;

            }

            //retorna
            return iValor;
        }

        public static List<FormatoContableEN> FiltrarFormatoContableXTextoEnCualquierPosicion(List<FormatoContableEN> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<FormatoContableEN> iLisRes = new List<FormatoContableEN>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (FormatoContableEN xObj in pLista)
            {
                string iTexto = FormatoContableRN.ObtenerValorDeCampo(xObj, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xObj);
                }
            }

            //devolver
            return iLisRes;
        }

        public static List<FormatoContableEN> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<FormatoContableEN> pLista)
        {
            //lista resultado
            List<FormatoContableEN> iLisRes = new List<FormatoContableEN>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pLista; }

            //filtar la lista
            iLisRes = FormatoContableRN.FiltrarFormatoContableXTextoEnCualquierPosicion(pLista, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }

        public static string ObtenerClaveFormatoContable(FormatoContableEN pObj)
        {
            //valor resultado
            string iClave = string.Empty;

            //armar clave
            iClave += Universal.gCodigoEmpresa + "-";
            iClave += pObj.CodigoFormatoContable;

            //retornar
            return iClave;
        }

        public static FormatoContableEN EsFormatoContableValido(FormatoContableEN pObj)
        {
            //objeto resultado
            FormatoContableEN iObjEN = new FormatoContableEN();

            //valida cuando esta vacio
            if (pObj.CodigoFormatoContable == string.Empty) { return iObjEN; }

            //valida cuando el codigo no existe
            iObjEN = FormatoContableRN.EsFormatoContableExistente(pObj);
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }

            //ok           
            return iObjEN;
        }

        public static FormatoContableEN EsFormatoContableActivoValido(FormatoContableEN pObj)
        {
            //objeto resultado
            FormatoContableEN iObjEN = new FormatoContableEN();

            //valida cuando esta vacio
            if (pObj.CodigoFormatoContable == string.Empty) { return iObjEN; }

            //valida cuando el codigo no existe
            iObjEN = FormatoContableRN.EsFormatoContableExistente(pObj);
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }

            //valida cuando esta desactivada
            FormatoContableEN iObjDesEN = FormatoContableRN.ValidaCuandoEstaDesactivada(iObjEN);
            if (iObjDesEN.Adicionales.EsVerdad == false) { return iObjDesEN; }

            //ok           
            return iObjEN;
        }

        public static FormatoContableEN ValidaCuandoEstaDesactivada(FormatoContableEN pObj)
        {
            //objeto resultado
            FormatoContableEN iObjEN = new FormatoContableEN();

            //validar                 
            if (pObj.CEstadoFormatoContable == "0")//desactivado
            {
                iObjEN.Adicionales.EsVerdad = false;
                iObjEN.Adicionales.Mensaje = "El(La) FormatoContable esta desactivada";
            }

            //ok
            return iObjEN;
        }

        public static bool ExisteValorEnColumna(string pColumnaBusqueda, string pValorBusqueda)
        {
            FormatoContableAD iObjAD = new FormatoContableAD();
            return iObjAD.ExisteValorEnColumna(pColumnaBusqueda, pValorBusqueda);
        }

        public static bool ExisteValorEnColumna(string pColumnaBusqueda, string pValorBusqueda, string pColumnaCondicion1, string pValorCondicion1)
        {
            FormatoContableAD iObjAD = new FormatoContableAD();
            return iObjAD.ExisteValorEnColumna(pColumnaBusqueda, pValorBusqueda, pColumnaCondicion1, pValorCondicion1);
        }

        public static bool ExisteValorEnColumna(string pColumnaBusqueda, string pValorBusqueda, string pColumnaCondicion1, string pValorCondicion1, string pColumnaCondicion2, string pValorCondicion2)
        {
            FormatoContableAD iObjAD = new FormatoContableAD();
            return iObjAD.ExisteValorEnColumna(pColumnaBusqueda, pValorBusqueda, pColumnaCondicion1, pValorCondicion1, pColumnaCondicion2, pValorCondicion2);
        }

        public static string ObtenerMaximoValorEnColumna(string pColumnaBusqueda)
        {
            FormatoContableAD iObjAD = new FormatoContableAD();
            return iObjAD.ObtenerMaximoValorEnColumna(pColumnaBusqueda);
        }

        public static string ObtenerMaximoValorEnColumna(string pColumnaBusqueda, string pColumnaCondicion1, string pValorCondicion1)
        {
            FormatoContableAD iObjAD = new FormatoContableAD();
            return iObjAD.ObtenerMaximoValorEnColumna(pColumnaBusqueda, pColumnaCondicion1, pValorCondicion1);
        }

        public static string ObtenerMaximoValorEnColumna(string pColumnaBusqueda, string pColumnaCondicion1, string pValorCondicion1, string pColumnaCondicion2, string pValorCondicion2)
        {
            FormatoContableAD iObjAD = new FormatoContableAD();
            return iObjAD.ObtenerMaximoValorEnColumna(pColumnaBusqueda, pColumnaCondicion1, pValorCondicion1, pColumnaCondicion2, pValorCondicion2);
        }

        public static string ObtenerNuevoNumeroFormatoContableAutogenerado(FormatoContableEN pObj)
        {
            //valor resultado
            string iNumero = string.Empty;

            //obtener el ultimo codigo que hay en la b.d
            string iUltimoCodigo = FormatoContableRN.ObtenerMaximoValorEnColumna("CampoDondeBuscar");

            //obtener el siguiente codigo
            iNumero = Numero.IncrementarCorrelativoNumerico(iUltimoCodigo, 6);

            //devuelve
            return iNumero;
        }

        public static FormatoContableEN EsActoAdicionarFormatoContable(FormatoContableEN pObj)
        {
            //objeto resultado
            FormatoContableEN iObjEN = new FormatoContableEN();

            //ok          
            return iObjEN;
        }

        public static FormatoContableEN EsActoModificarFormatoContable(FormatoContableEN pObj)
        {
            //objeto resultado
            FormatoContableEN iObjEN = new FormatoContableEN();

            //valida cuando el codigo no existe
            iObjEN = FormatoContableRN.EsFormatoContableExistente(pObj);
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }

            //ok          
            return iObjEN;
        }

        public static FormatoContableEN EsActoEliminarFormatoContable(FormatoContableEN pObj)
        {
            //objeto resultado
            FormatoContableEN iObjEN = new FormatoContableEN();

            //valida cuando el codigo no existe
            iObjEN = FormatoContableRN.EsFormatoContableExistente(pObj);
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }

            //valida cuando este formato contable ya esta en cuentas
            FormatoContableEN iObjCueEN = FormatoContableRN.ValidaCuandoCodigoFormatoContableEstaEnCuenta(iObjEN);
            if (iObjCueEN.Adicionales.EsVerdad == false) { return iObjCueEN; }

            //ok          
            return iObjEN;
        }

        public static FormatoContableEN BuscarFormatoContable(string pCampo, string pValor, List<FormatoContableEN> pLista)
        {
            //objeto resultaddo
            FormatoContableEN iObjEN = new FormatoContableEN();

            //recorrer cada objeto
            foreach (FormatoContableEN xObj in pLista)
            {
                if (FormatoContableRN.ObtenerValorDeCampo(xObj, pCampo) == pValor)
                {
                    return xObj;
                }
            }

            //devolver
            return iObjEN;
        }

        public static List<FormatoContableEN> ListarFormatoContableXEstado(FormatoContableEN pObj)
        {
            FormatoContableAD iObjAD = new FormatoContableAD();
            return iObjAD.ListarFormatoContableXEstado(pObj);
        }

        public static List<FormatoContableEN> ListarFormatoContableActivos(FormatoContableEN pObj)
        {
            //asignar parametros
            FormatoContableEN iForConEN = new FormatoContableEN();
            iForConEN.CEstadoFormatoContable = "1";//activos
            iForConEN.Adicionales.CampoOrden = pObj.Adicionales.CampoOrden;

            //ejecutar metodo
            return FormatoContableRN.ListarFormatoContableXEstado(iForConEN);
        }

        public static FormatoContableEN ValidaCuandoCodigoFormatoContableEstaEnCuenta(FormatoContableEN pObj)
        {
            //objeto resultado
            FormatoContableEN iObjEN = new FormatoContableEN();

            //valida
            bool iExisten = CuentaRN.ExisteValorEnColumna(CuentaEN.CodForCon, pObj.CodigoFormatoContable, CuentaEN.CodEmp, Universal.gCodigoEmpresa);
            if (iExisten == true)
            {
                iObjEN.Adicionales.EsVerdad = false;
                iObjEN.Adicionales.Mensaje = "Este Formato contable ya se utilizo en algunas cuentas";                
            }

            //ok
            return iObjEN;
        }

        public static List<FormatoContableEN> ListarFormatoContablesParaCopiarAEmpresa(string pCodigoEmpresaCopia, string pCodigoEmpresaGuarda)
        {
            //lista resultado
            List<FormatoContableEN> iLisRes = new List<FormatoContableEN>();

            //listar los FormatoContables de la empresa de donde se quiere copiar
            FormatoContableEN iForConEN = new FormatoContableEN();
            iForConEN.CodigoEmpresa = pCodigoEmpresaCopia;
            iForConEN.Adicionales.CampoOrden = FormatoContableEN.CodForCon;
            List<FormatoContableEN> iLisForConCop = FormatoContableRN.ListarFormatoContablesDeEmpresa(iForConEN);

            //listar losFormatoContables de la empresa a donde se quiere copiar
            iForConEN.CodigoEmpresa = pCodigoEmpresaGuarda;
            List<FormatoContableEN> iLisForConGua = FormatoContableRN.ListarFormatoContablesDeEmpresa(iForConEN);

            //obtener los Auxiliars que tiene la lista iLisAuxCop que no esten en iLisAuxGua
            iLisRes = FormatoContableRN.ObtenerDiferenciaAMenosB(iLisForConCop, iLisForConGua);

            //devolver
            return iLisRes;
        }

        public static List<FormatoContableEN> ListarFormatoContablesDeEmpresa(FormatoContableEN pObj)
        {
            FormatoContableAD iPerAD = new FormatoContableAD();
            return iPerAD.ListarFormatoContablesDeEmpresa(pObj);
        }

        public static List<FormatoContableEN> ObtenerDiferenciaAMenosB(List<FormatoContableEN> pLisForConA, List<FormatoContableEN> pLisForConB)
        {
            //lista resultado
            List<FormatoContableEN> iLisRes = new List<FormatoContableEN>();

            //recorrer cada objeto
            foreach (FormatoContableEN xForConA in pLisForConA)
            {
                //flag de encontrado
                int iEncontrado = 0;

                //recorre cada objeto
                foreach (FormatoContableEN xForConB in pLisForConB)
                {
                    if (xForConA.CodigoFormatoContable == xForConB.CodigoFormatoContable)
                    {
                        iEncontrado = 1;
                    }
                }

                //si no se encontro se agrega a la lista resultado
                if (iEncontrado == 0)
                {
                    iLisRes.Add(xForConA);
                }
            }

            //devolver
            return iLisRes;
        }

        public static void ModificarVerdadFalsoFormatoContable(FormatoContableEN pObj, List<FormatoContableEN> pLista)
        {
            //lista actualizada
            List<FormatoContableEN> iLisForCon = new List<FormatoContableEN>();

            //buscamos el objeto en la lista pLista
            foreach (FormatoContableEN xForCon in pLista)
            {
                if (xForCon.ClaveFormatoContable == pObj.ClaveFormatoContable)
                {
                    xForCon.VerdadFalso = pObj.VerdadFalso;
                }
                iLisForCon.Add(xForCon);
            }

            //actualizamos a la lista principal
            pLista.Clear();
            pLista.AddRange(iLisForCon);
        }

        public static FormatoContableEN HayObjetosMarcados(List<FormatoContableEN> pLista)
        {
            //objeto resultado
            FormatoContableEN iForConEN = new FormatoContableEN();

            //sacar las cuotas solo marcadas
            List<FormatoContableEN> iLisForConMar = FormatoContableRN.ListarFormatoContablesSoloMarcadas(pLista);

            //si la lista esta vacia entonces no hay marcados
            if (iLisForConMar.Count == 0)
            {
                iForConEN.Adicionales.EsVerdad = false;
                iForConEN.Adicionales.Mensaje = "No hay Formato Contables marcados, no se puede realizar la operacion";              
            }

            //ok           
            return iForConEN;
        }

        public static List<FormatoContableEN> ListarFormatoContablesSoloMarcadas(List<FormatoContableEN> pLista)
        {
            //lista resultado
            List<FormatoContableEN> iLisRes = new List<FormatoContableEN>();

            //la lista tiene objetos para agregar y otros no, por eso solo
            //hay que sacar los chequeados
            foreach (FormatoContableEN xForCon in pLista)
            {
                if (xForCon.VerdadFalso == true)
                {
                    iLisRes.Add(xForCon);
                }
            }
            return iLisRes;
        }

        public static void AdicionarFormatoContablesPorCopia(string pCodigoEmpresaGuarda, List<FormatoContableEN> pLisForConMar, List<FormatoContableEN> pLisForConVal)
        {
            //lista de Auxiliars para adicionar
            List<FormatoContableEN> iLisForConAdi = new List<FormatoContableEN>();

            //recorrer cada objeto
            foreach (FormatoContableEN xForCon in pLisForConMar)
            {
                //para poder adicionar al objeto xAux, este debe existir en la lista de
                //Auxiliars que son validas a grabar en bd(pLisAuxVal)
                bool iExiste = FormatoContableRN.ExisteClaveFormatoContableEnLista(xForCon.ClaveFormatoContable, pLisForConVal);
                if (iExiste == false) { continue; }

                //modificar datos
                xForCon.CodigoEmpresa = pCodigoEmpresaGuarda;
                xForCon.ClaveFormatoContable = FormatoContableRN.ObtenerClaveFormatoContable(xForCon);
                xForCon.COrigenVentanaCreacion = "02";//Ventana copia

                //agregar a la lista resultado
                iLisForConAdi.Add(xForCon);
            }

            //luego adicionamos todas las Auxiliars en bd
            FormatoContableRN.AdicionarFormatoContable(iLisForConAdi);
        }

        public static bool ExisteClaveFormatoContableEnLista(string pClaveFormatoContable, List<FormatoContableEN> pLista)
        {
            //recorrer cada objeto
            foreach (FormatoContableEN xForCon in pLista)
            {
                if (pClaveFormatoContable == xForCon.ClaveFormatoContable)
                {
                    return true;
                }
            }

            //devolver
            return false;
        }

        public static void MarcarTodos(List<FormatoContableEN> pLista, bool pVerdadFalso)
        {
            //lista actualizada
            List<FormatoContableEN> iLisForCon = new List<FormatoContableEN>();

            //buscamos el objeto en la lista pLista
            foreach (FormatoContableEN xExi in pLista)
            {
                xExi.VerdadFalso = pVerdadFalso;
                iLisForCon.Add(xExi);
            }

            //actualizamos a la lista principal
            pLista.Clear();
            pLista.AddRange(iLisForCon);
        }

        public static FormatoContableEN EsActoEliminarCopiaFormatoContable()
        {
            //objeto resultado
            FormatoContableEN iForConEN = new FormatoContableEN();

            //valida cuando no hay auxiliares copia
            iForConEN = FormatoContableRN.ValidaCuandoNoHayFormatoContablesCopia();
            if (iForConEN.Adicionales.EsVerdad == false) { return iForConEN; }

            //valida cuando no se puede eliminar ningun formato contable copia
            iForConEN = FormatoContableRN.ValidaCuandoTodosLosFormatoContablesCopiaSonUtilizados();
            if (iForConEN.Adicionales.EsVerdad == false) { return iForConEN; }

            //ok            
            return iForConEN;
        }

        public static List<FormatoContableEN> ListarFormatoContablesCopia(FormatoContableEN pObj)
        {
            FormatoContableAD iPerAD = new FormatoContableAD();
            return iPerAD.ListarFormatoContablesCopia(pObj);
        }

        public static List<FormatoContableEN> ListarFormatoContablesCopia()
        {
            //asignar parametros
            FormatoContableEN iForConEN = new FormatoContableEN();
            iForConEN.Adicionales.CampoOrden = FormatoContableEN.CodForCon;

            //ejecutar metodo
            return FormatoContableRN.ListarFormatoContablesCopia(iForConEN);
        }

        public static FormatoContableEN ValidaCuandoNoHayFormatoContablesCopia()
        {
            //objeto resultado
            FormatoContableEN iForConEN = new FormatoContableEN();

            //validar
            bool iHayValor = FormatoContableRN.ExisteValorEnColumna(FormatoContableEN.COriVenCre, "02", CuentaEN.CodEmp, Universal.gCodigoEmpresa);
            if (iHayValor == false)
            {
                iForConEN.Adicionales.EsVerdad = false;
                iForConEN.Adicionales.Mensaje = "No hay Formatos Contables copiados en esta empresa";                
            }

            //ok
            return iForConEN;
        }

        public static FormatoContableEN ValidaCuandoTodosLosFormatoContablesCopiaSonUtilizados()
        {
            //objeto resultado
            FormatoContableEN iForConEN = new FormatoContableEN();

            //validar
            List<FormatoContableEN> iLisForConEli = FormatoContableRN.ListarFormatoContablesCopiaParaEliminar();
            if (iLisForConEli.Count==0)
            {
                iForConEN.Adicionales.EsVerdad = false;
                iForConEN.Adicionales.Mensaje = "Todos los Formatos Contables copiados en esta empresa estan referenciados en las cuentas";
            }

            //ok
            return iForConEN;
        }

        public static List<FormatoContableEN> ListarFormatoContablesCopiaParaEliminar()
        {
            FormatoContableAD iPerAD = new FormatoContableAD();
            return iPerAD.ListarFormatoContablesCopiaParaEliminar();
        }

        public static void EliminarFormatoContablesCopia()
        {
            //listar los formatos contables copia actos para eliminar
            List<FormatoContableEN> iLisForCon = FormatoContableRN.ListarFormatoContablesCopiaParaEliminar();

            //eliminar
            FormatoContableRN.EliminarFormatoContable(iLisForCon);
        }

        public static List<string> ListarCodigosFormatoContables()
        {
            //lista resultado
            List<string> iLisRes = new List<string>();

            //traer a todos los auxiliares de la empresa de acceso
            List<FormatoContableEN> iLisForCon = FormatoContableRN.ListarFormatoContable();

            //recorrer cada objeto auxiliar
            foreach (FormatoContableEN xForCon in iLisForCon)
            {
                iLisRes.Add(xForCon.CodigoFormatoContable);
            }

            //devolver
            return iLisRes;
        }

        public static FormatoContableEN EsActoEliminarImportacionFormatoContable()
        {
            //objeto resultado
            FormatoContableEN iForConEN = new FormatoContableEN();

            //valida cuando no hay auxiliares importados
            iForConEN = FormatoContableRN.ValidaCuandoNoHayFormatoContablesImportados();
            if (iForConEN.Adicionales.EsVerdad == false) { return iForConEN; }

            //valida cuando todos los formatos contables importados estan siendo utilizados
            iForConEN = FormatoContableRN.ValidaCuandoTodosLosFormatoContablesImportadosSonUtilizados();
            if (iForConEN.Adicionales.EsVerdad == false) { return iForConEN; }

            //ok            
            return iForConEN;
        }

        public static List<FormatoContableEN> ListarFormatoContablesImportadosParaEliminar()
        {
            FormatoContableAD iPerAD = new FormatoContableAD();
            return iPerAD.ListarFormatoContablesImportadosParaEliminar();
        }

        public static FormatoContableEN ValidaCuandoTodosLosFormatoContablesImportadosSonUtilizados()
        {
            //objeto resultado
            FormatoContableEN iForConEN = new FormatoContableEN();

            //validar
            List<FormatoContableEN> iLisForConEli = FormatoContableRN.ListarFormatoContablesImportadosParaEliminar();
            if (iLisForConEli.Count == 0)
            {
                iForConEN.Adicionales.EsVerdad = false;
                iForConEN.Adicionales.Mensaje = "Todos los Formatos Contables importados del excel en esta empresa estan referenciados en las cuentas";
            }

            //ok
            return iForConEN;
        }

        public static List<FormatoContableEN> ListarFormatoContablesImportados(FormatoContableEN pObj)
        {
            FormatoContableAD iPerAD = new FormatoContableAD();
            return iPerAD.ListarFormatoContablesImportados(pObj);
        }

        public static List<FormatoContableEN> ListarFormatoContablesImportados()
        {
            //asignar parametros
            FormatoContableEN iForConEN = new FormatoContableEN();
            iForConEN.Adicionales.CampoOrden = FormatoContableEN.CodForCon;

            //ejecutar metodo
            return FormatoContableRN.ListarFormatoContablesImportados(iForConEN);
        }

        public static FormatoContableEN ValidaCuandoNoHayFormatoContablesImportados()
        {
            //objeto resultado
            FormatoContableEN iForConEN = new FormatoContableEN();

            //validar
            bool iHayValor = FormatoContableRN.ExisteValorEnColumna(FormatoContableEN.COriVenCre, "03", CuentaEN.CodEmp, Universal.gCodigoEmpresa);
            if (iHayValor == false)
            {
                iForConEN.Adicionales.EsVerdad = false;
                iForConEN.Adicionales.Mensaje = "No hay Formatos contables importados en esta empresa";              
            }

            //ok
            return iForConEN;
        }

        public static void EliminarFormatoContablesImportacion()
        {
            //listar los formatos contables importados actos para eliminar
            List<FormatoContableEN> iLisForCon = FormatoContableRN.ListarFormatoContablesImportadosParaEliminar();

            //eliminar
            FormatoContableRN.EliminarFormatoContable(iLisForCon);
        }

        public static void AdicionarFormatoContablesPorImportacionExcel(List<FormatoContableEN> pLista)
        {
            //lista de Auxiliars para adicionar
            List<FormatoContableEN> iLisForConAdi = new List<FormatoContableEN>();

            //traer todos los formatos contables de la empresa actual
            List<FormatoContableEN> iLisForCon = FormatoContableRN.ListarFormatoContable();

            //recorrer cada objeto
            foreach (FormatoContableEN xForCon in pLista)
            {
                //para poder adicionar al objeto xAux, este no debe existir en la lista de
                //Formatos contables que son validas a grabar en bd(pLisAuxVal)
                bool iExiste = FormatoContableRN.ExisteClaveFormatoContableEnLista(xForCon.ClaveFormatoContable, iLisForCon);
                if (iExiste == true) { continue; }

                //agregar a la lista resultado
                iLisForConAdi.Add(xForCon);
            }

            //luego adicionamos todas las Auxiliars en bd
            FormatoContableRN.AdicionarFormatoContable(iLisForConAdi);
        }

    }
}
