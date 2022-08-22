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
    public class RegContabDetaRN
    {

        public static RegContabDetaEN EnBlanco()
        {
            RegContabDetaEN iObjEN = new RegContabDetaEN();
            return iObjEN;
        }

        public static void AdicionarRegContabDeta(List<RegContabDetaEN> pLista)
        {
            RegContabDetaAD iObjAD = new RegContabDetaAD();
            iObjAD.AdicionarRegContabDeta(pLista);
        }

        public static void AdicionarRegContabDeta(RegContabDetaEN pObj)
        {
            //Asignar parametros
            List<RegContabDetaEN> iLisObj = new List<RegContabDetaEN>();
            iLisObj.Add(pObj);

            //Ejecutar metodo
            RegContabDetaRN.AdicionarRegContabDeta(iLisObj);
        }

        public static void ModificarRegContabDeta(List<RegContabDetaEN> pLista)
        {
            RegContabDetaAD iObjAD = new RegContabDetaAD();
            iObjAD.ModificarRegContabDeta(pLista);
        }

        public static void ModificarRegContabDeta(RegContabDetaEN pObj)
        {
            //Asignar parametros
            List<RegContabDetaEN> iLisObj = new List<RegContabDetaEN>();
            iLisObj.Add(pObj);

            //Ejecutar metodo
            RegContabDetaRN.ModificarRegContabDeta(iLisObj);
        }

        public static void EliminarRegContabDeta(List<RegContabDetaEN> pLista)
        {
            RegContabDetaAD iObjAD = new RegContabDetaAD();
            iObjAD.EliminarRegContabDeta(pLista);
        }
                
        public static void EliminarRegContabDeta(RegContabDetaEN pObj)
        {
            //Asignar parametros
            List<RegContabDetaEN> iLisObj = new List<RegContabDetaEN>();
            iLisObj.Add(pObj);

            //Ejecutar metodo
            RegContabDetaRN.EliminarRegContabDeta(iLisObj);
        }

        public static void EliminarRegContabDetasDeClaveRegContabCabe(string pClaveRegContabCabe)
        {
            RegContabDetaAD iObjAD = new RegContabDetaAD();
            iObjAD.EliminarRegContabDetasDeClaveRegContabCabe(pClaveRegContabCabe);
        }

        public static List<RegContabDetaEN> ListarRegContabDeta(RegContabDetaEN pObj)
        {
            RegContabDetaAD iObjAD = new RegContabDetaAD();
            return iObjAD.ListarRegContabDeta(pObj);
        }

        public static List<RegContabDetaEN> ListarRegContabDeta()
        {
            //asignar parametros
            RegContabDetaEN iObjEN = new RegContabDetaEN();
            iObjEN.Adicionales.CampoOrden = RegContabDetaEN.ClaRegConDet;

            //ejecutar metodo
            return RegContabDetaRN.ListarRegContabDeta(iObjEN);
        }

        public static RegContabDetaEN BuscarRegContabDetaXClave(RegContabDetaEN pObj)
        {
            RegContabDetaAD iObjAD = new RegContabDetaAD();
            return iObjAD.BuscarRegContabDetaXClave(pObj);
        }

        public static RegContabDetaEN EsRegContabDetaExistente(RegContabDetaEN pObj)
        {
            //objeto resultado
            RegContabDetaEN iObjEN = new RegContabDetaEN();

            //validar si existe en b.d
            iObjEN = RegContabDetaRN.BuscarRegContabDetaXClave(pObj);
            if (iObjEN.ClaveRegContabDeta == string.Empty)
            {
                iObjEN.Adicionales.EsVerdad = false;
                iObjEN.Adicionales.Mensaje = "El Registro seleccionado no existe";
            }

            //ok  
            return iObjEN;
        }

        public static RegContabDetaEN EsCodigoRegContabDetaDisponible(RegContabDetaEN pObj)
        {
            //objeto resultado
            RegContabDetaEN iObjEN = new RegContabDetaEN();

            //valida cuando esta vacio
            if (pObj.PeriodoRegContabCabe == string.Empty) { return iObjEN; }

            //valida cuando esta vacio
            if (pObj.COrigen == string.Empty) { return iObjEN; }

            //valida cuando esta vacio
            if (pObj.CFile == string.Empty) { return iObjEN; }

            //valida cuando esta vacio
            if (pObj.CorrelativoRegContabCabe == string.Empty) { return iObjEN; }

            //valida cuando esta vacio
            if (pObj.CorrelativoRegContabDeta == string.Empty) { return iObjEN; }

            //validar si existe
            iObjEN = RegContabDetaRN.ValidaCuandoCodigoYaExiste(pObj);
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }

            //ok           
            return iObjEN;
        }

        public static RegContabDetaEN ValidaCuandoCodigoYaExiste(RegContabDetaEN pObj)
        {
            //objeto resultado
            RegContabDetaEN iObjEN = new RegContabDetaEN();

            //validar
            iObjEN = RegContabDetaRN.BuscarRegContabDetaXClave(pObj);
            if (iObjEN.ClaveRegContabDeta != string.Empty)
            {
                iObjEN.Adicionales.EsVerdad = false;
                iObjEN.Adicionales.Mensaje = "Este codigo ya existe";
            }

            //ok  
            return iObjEN;
        }

        public static List<RegContabDetaEN> FiltrarRegContabDetaXTextoEnCualquierPosicion(List<RegContabDetaEN> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<RegContabDetaEN> iLisRes = new List<RegContabDetaEN>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (RegContabDetaEN xObj in pLista)
            {
                string iTexto = ObjetoG.ObtenerTexto<RegContabDetaEN>(xObj, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xObj);
                }
            }

            //devolver
            return iLisRes;
        }

        public static List<RegContabDetaEN> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<RegContabDetaEN> pLista)
        {
            //lista resultado
            List<RegContabDetaEN> iLisRes = new List<RegContabDetaEN>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pLista; }

            //filtar la lista
            iLisRes = RegContabDetaRN.FiltrarRegContabDetaXTextoEnCualquierPosicion(pLista, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }

        public static string ObtenerClaveRegContabDeta(RegContabDetaEN pObj)
        {
            //valor resultado
            string iClave = string.Empty;

            //armar clave
            iClave += Universal.gCodigoEmpresa + "-";
            iClave += pObj.PeriodoRegContabCabe + "-";
            iClave += pObj.COrigen + "-";
            iClave += pObj.CFile + "-";
            iClave += pObj.CorrelativoRegContabCabe + "-";
            iClave += pObj.CorrelativoRegContabDeta;

            //retornar
            return iClave;
        }

        public static RegContabDetaEN EsRegContabDetaValido(RegContabDetaEN pObj)
        {
            //objeto resultado
            RegContabDetaEN iObjEN = new RegContabDetaEN();

            //valida cuando esta vacio
            if (pObj.PeriodoRegContabCabe == string.Empty) { return iObjEN; }

            //valida cuando esta vacio
            if (pObj.COrigen == string.Empty) { return iObjEN; }

            //valida cuando esta vacio
            if (pObj.CFile == string.Empty) { return iObjEN; }

            //valida cuando esta vacio
            if (pObj.CorrelativoRegContabCabe == string.Empty) { return iObjEN; }

            //valida cuando esta vacio
            if (pObj.CorrelativoRegContabDeta == string.Empty) { return iObjEN; }

            //valida cuando el codigo no existe
            iObjEN = RegContabDetaRN.EsRegContabDetaExistente(pObj);
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }

            //ok           
            return iObjEN;
        }

        public static RegContabDetaEN EsRegContabDetaActivoValido(RegContabDetaEN pObj)
        {
            //objeto resultado
            RegContabDetaEN iObjEN = new RegContabDetaEN();

            //valida cuando esta vacio
            if (pObj.PeriodoRegContabCabe == string.Empty) { return iObjEN; }

            //valida cuando esta vacio
            if (pObj.COrigen == string.Empty) { return iObjEN; }

            //valida cuando esta vacio
            if (pObj.CFile == string.Empty) { return iObjEN; }

            //valida cuando esta vacio
            if (pObj.CorrelativoRegContabCabe == string.Empty) { return iObjEN; }

            //valida cuando esta vacio
            if (pObj.CorrelativoRegContabDeta == string.Empty) { return iObjEN; }

            //valida cuando el codigo no existe
            iObjEN = RegContabDetaRN.EsRegContabDetaExistente(pObj);
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }

            //valida cuando esta desactivada
            RegContabDetaEN iObjDesEN = RegContabDetaRN.ValidaCuandoEstaDesactivada(iObjEN);
            if (iObjDesEN.Adicionales.EsVerdad == false) { return iObjDesEN; }

            //ok           
            return iObjEN;
        }

        public static RegContabDetaEN ValidaCuandoEstaDesactivada(RegContabDetaEN pObj)
        {
            //objeto resultado
            RegContabDetaEN iObjEN = new RegContabDetaEN();

            //validar                 
            if (pObj.CEstadoRegContabDeta == "0")//desactivado
            {
                iObjEN.Adicionales.EsVerdad = false;
                iObjEN.Adicionales.Mensaje = "El(La) RegContabDeta esta desactivada";
            }

            //ok
            return iObjEN;
        }

        public static bool ExisteValorEnColumna(string pColumnaBusqueda, string pValorBusqueda)
        {
            RegContabDetaAD iObjAD = new RegContabDetaAD();
            return iObjAD.ExisteValorEnColumna(pColumnaBusqueda, pValorBusqueda);
        }

        public static bool ExisteValorEnColumna(string pColumnaBusqueda, string pValorBusqueda, string pColumnaCondicion1, string pValorCondicion1)
        {
            RegContabDetaAD iObjAD = new RegContabDetaAD();
            return iObjAD.ExisteValorEnColumna(pColumnaBusqueda, pValorBusqueda, pColumnaCondicion1, pValorCondicion1);
        }

        public static bool ExisteValorEnColumna(string pColumnaBusqueda, string pValorBusqueda, string pColumnaCondicion1, string pValorCondicion1, string pColumnaCondicion2, string pValorCondicion2)
        {
            RegContabDetaAD iObjAD = new RegContabDetaAD();
            return iObjAD.ExisteValorEnColumna(pColumnaBusqueda, pValorBusqueda, pColumnaCondicion1, pValorCondicion1, pColumnaCondicion2, pValorCondicion2);
        }

        public static string ObtenerMaximoValorEnColumna(string pColumnaBusqueda)
        {
            RegContabDetaAD iObjAD = new RegContabDetaAD();
            return iObjAD.ObtenerMaximoValorEnColumna(pColumnaBusqueda);
        }

        public static string ObtenerMaximoValorEnColumna(string pColumnaBusqueda, string pColumnaCondicion1, string pValorCondicion1)
        {
            RegContabDetaAD iObjAD = new RegContabDetaAD();
            return iObjAD.ObtenerMaximoValorEnColumna(pColumnaBusqueda, pColumnaCondicion1, pValorCondicion1);
        }

        public static string ObtenerMaximoValorEnColumna(string pColumnaBusqueda, string pColumnaCondicion1, string pValorCondicion1, string pColumnaCondicion2, string pValorCondicion2)
        {
            RegContabDetaAD iObjAD = new RegContabDetaAD();
            return iObjAD.ObtenerMaximoValorEnColumna(pColumnaBusqueda, pColumnaCondicion1, pValorCondicion1, pColumnaCondicion2, pValorCondicion2);
        }

        public static string ObtenerNuevoNumeroRegContabDetaAutogenerado(RegContabDetaEN pObj)
        {
            //valor resultado
            string iNumero = string.Empty;

            //obtener el ultimo codigo que hay en la b.d
            string iUltimoCodigo = RegContabDetaRN.ObtenerMaximoValorEnColumna("CampoDondeBuscar");

            //obtener el siguiente codigo
            iNumero = Numero.IncrementarCorrelativoNumerico(iUltimoCodigo, 6);

            //devuelve
            return iNumero;
        }

        public static RegContabDetaEN EsActoAdicionarRegContabDeta(RegContabDetaEN pObj)
        {
            //objeto resultado
            RegContabDetaEN iObjEN = new RegContabDetaEN();

            //ok          
            return iObjEN;
        }

        public static RegContabDetaEN EsActoModificarRegContabDeta(RegContabDetaEN pObj)
        {
            //objeto resultado
            RegContabDetaEN iObjEN = new RegContabDetaEN();

            //valida cuando el codigo no existe
            iObjEN = RegContabDetaRN.EsRegContabDetaExistente(pObj);
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }

            //ok          
            return iObjEN;
        }

        public static RegContabDetaEN EsActoEliminarRegContabDeta(RegContabDetaEN pObj)
        {
            //objeto resultado
            RegContabDetaEN iObjEN = new RegContabDetaEN();

            //valida cuando el codigo no existe
            iObjEN = RegContabDetaRN.EsRegContabDetaExistente(pObj);
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }

            //ok          
            return iObjEN;
        }

        public static List<RegContabDetaEN> ListarRegContabDetaXClaveRegContabCabe(RegContabDetaEN pObj)
        {
            RegContabDetaAD iObjAD = new RegContabDetaAD();
            return iObjAD.ListarRegContabDetaXClaveRegContabCabe(pObj);
        }

        public static void AdicionarRegContabDeta(List<RegContabDetaEN> pLis, RegContabDetaEN pObj)
        {
            //obtener siguiente correlativo
            pObj.CorrelativoRegContabDeta = ObtenerSiguienteCorrelativo(pLis);
            pObj.ClaveObjeto = ObtenerClaveRegContabDeta(pObj);
            pLis.Add(pObj);
        }

        public static string ObtenerSiguienteCorrelativo(List<RegContabDetaEN> pLis)
        {
            //obtener el ultimo correlativo de la lista
            string iUltimoCorrelativo = "0000";

            //solo si hay objetos
            if (pLis.Count != 0)
            {
                iUltimoCorrelativo = pLis[pLis.Count - 1].CorrelativoRegContabDeta;
            }

            //obtener el siguiente correlativo
            return Numero.IncrementarCorrelativoNumerico(iUltimoCorrelativo);
        }

        public static bool EsDigitableCentroCosto(RegContabDetaEN pObj)
        {
            //devolver
            return Conversion.CadenaABoolean(pObj.CCentroCostoCuenta, false);
        }

        public static bool EsDigitableArea(RegContabDetaEN pObj)
        {
            //devolver
            return Conversion.CadenaABoolean(pObj.CAreaCuenta, false);
        }

        public static bool EsDigitableAlmacen(RegContabDetaEN pObj)
        {
            //devolver
            return Conversion.CadenaABoolean(pObj.CAlmacen, false);
        }

        public static bool EsDigitableAuxiliar(RegContabDetaEN pObj)
        {
            //devolver
            return Conversion.CadenaABoolean(pObj.CAuxiliar, false);
        }

        public static bool EsDigitableDocumento(RegContabDetaEN pObj)
        {
            //devolver
            return Conversion.CadenaABoolean(pObj.CDocumento, false);
        }
    
        public static string ObtenerCodigoDebeHaberSegunTipoDocumentoEnCompra(RegContabDetaEN pObj)
        {
            if (pObj.CTipoNota == ItemGEN.TipoNota_Credito)//credito
            {
                return ItemGEN.DebeHaber_Haber;//Haber
            }
            else
            {
                return ItemGEN.DebeHaber_Debe;//Debe
            }
        }

        public static decimal ObtenerTotalDebeSoles(List<RegContabDetaEN> pLisRegConDet)
        {
            //valor resultado
            decimal iValor = 0;

            //filtrar solo los que son debe
            List<RegContabDetaEN> iLisRegConDet = ListaG.Filtrar<RegContabDetaEN>(pLisRegConDet, RegContabDetaEN.CDebHab, 
                ItemGEN.DebeHaber_Debe);

            //sumar
            iValor = ListaG.Sumar<RegContabDetaEN>(iLisRegConDet, RegContabDetaEN.ImpSolRegConDet);

            //devolver
            return iValor;
        }

        public static decimal ObtenerTotalHaberSoles(List<RegContabDetaEN> pLisRegConDet)
        {
            //valor resultado
            decimal iValor = 0;

            //filtrar solo los que son debe
            List<RegContabDetaEN> iLisRegConDet = ListaG.Filtrar<RegContabDetaEN>(pLisRegConDet, RegContabDetaEN.CDebHab, 
                ItemGEN.DebeHaber_Haber);

            //sumar
            iValor = ListaG.Sumar<RegContabDetaEN>(iLisRegConDet, RegContabDetaEN.ImpSolRegConDet);

            //devolver
            return iValor;
        }
               
        public static void AdicionarRegContabDetasParaCompra(RegContabCabeEN pRegConCab, List<RegContabDetaEN> pLisRegConDetEdi)
        {
            //sino hay regConDetEditadas, entonces termina el proceso
            if (pLisRegConDetEdi.Count == 0) { return; }

            //segun el tipo de compra
            if (pRegConCab.CTipoCompra == ItemGEN.TipoCompra_Normal)
            {
                AdicionarRegContabDetasParaCompraNormal(pRegConCab, pLisRegConDetEdi);
            }
            else
            {
                AdicionarRegContabDetasParaCompraEspecial(pRegConCab, pLisRegConDetEdi);
            }
        }
                
        public static void AdicionarRegContabDetasParaCompraNormal(RegContabCabeEN pRegConCab, List<RegContabDetaEN> pLisRegConDetEdi)
        {
            //primero listar el asiento completo de compra normal
            List<RegContabDetaEN> iLisRegConDet = ArmarAsientoTotalParaCompraNormal(pRegConCab, pLisRegConDetEdi);

            //grabar en bd
            AdicionarRegContabDeta(iLisRegConDet);
        }
                
        public static void AdicionarRegContabDetasParaCompraEspecial(RegContabCabeEN pRegConCab, List<RegContabDetaEN> pLisRegConDetEdi)
        {
            //primero listar el asiento completo de compra normal
            List<RegContabDetaEN> iLisRegConDet = ArmarAsientoTotalParaCompraEspecial(pRegConCab, pLisRegConDetEdi);

            //grabar en bd
            AdicionarRegContabDeta(iLisRegConDet);
        }
                
        public static List<RegContabDetaEN> ArmarAsientoTotalParaCompraNormal(RegContabCabeEN pRegConCab, CuentaEN pCuePV, List<RegContabDetaEN> pLisRegConDetEdi,
            CuentaEN pCueIGV, List<CuentaEN> pLisCueAut)
        {
            //lista resultado
            List<RegContabDetaEN> iLisRes = new List<RegContabDetaEN>();

            //agregar a la lista resultado(linea precio venta)            
            iLisRes.Add(CrearRegContabDetaPrecioVenta(pRegConCab, pCuePV, pLisRegConDetEdi));

            //agregar a la lista resultado(lineas editadas por el usuario)
            iLisRes.AddRange(pLisRegConDetEdi);

            //validar si aplica la linea de igv
            if (pRegConCab.CAplicaIgv == "1")//si aplica
            {
                //agregar a la lista resultado(linea igv)
                iLisRes.Add(CrearRegContabDetaIgv(pRegConCab, pCueIGV, pLisRegConDetEdi));
            }

            //crear las lineas automaticas
            iLisRes.AddRange(CrearAsientosAutomaticos(iLisRes, pLisCueAut));

            //enumerar los correlativos deta y actualizar sus claveRegContabDeta
            EnumerarCorrelativoDetaYNuevaClaveRegConDeta(iLisRes);

            //devolver
            return iLisRes;
        }

        public static List<RegContabDetaEN> ArmarAsientoTotalParaCompraEspecial(RegContabCabeEN pRegConCab, List<RegContabDetaEN> pLisRegConDetEdi
            , List<CuentaEN> pLisCueAut)
        {
            //lista resultado
            List<RegContabDetaEN> iLisRes = new List<RegContabDetaEN>();
            
            //agregar a la lista resultado(lineas editadas por el usuario)
            iLisRes.AddRange(pLisRegConDetEdi);
            
            //crear las lineas automaticas
            iLisRes.AddRange(CrearAsientosAutomaticos(iLisRes, pLisCueAut));

            //enumerar los correlativos deta y actualizar sus claveRegContabDeta
            EnumerarCorrelativoDetaYNuevaClaveRegConDeta(iLisRes);

            //devolver
            return iLisRes;
        }

        public static void EnumerarCorrelativoDetaYNuevaClaveRegConDeta(List<RegContabDetaEN> pLis)
        {
            string iCorrelativo = "0000";
            foreach (RegContabDetaEN xRegConDet in pLis)
            {
                xRegConDet.CorrelativoRegContabDeta = Numero.IncrementarCorrelativoNumerico(ref iCorrelativo);
                xRegConDet.ClaveRegContabDeta = ObtenerClaveRegContabDeta(xRegConDet);
            }
        }

        public static List<RegContabDetaEN> ArmarAsientoTotalParaCompraNormal(RegContabCabeEN pRegConCab, List<RegContabDetaEN> pLisRegConDetEdi)
        {
            //lista resultado
            List<RegContabDetaEN> iLisRes = new List<RegContabDetaEN>();

            //valida si la lista editada esta vacia
            if (pLisRegConDetEdi.Count == 0) { return iLisRes; }

            //traer todas las cuentas analiticas de la empresa de acceso
            List<CuentaEN> iLisCueAna = CuentaRN.ListarCuentaAnalitica();

            //asignar parametros
            CuentaEN iCuePvEN = ListaG.Buscar<CuentaEN>(iLisCueAna, CuentaEN.CodCue, pRegConCab.CodigoCuenta);
            CuentaEN iCueIgvEN = CuentaRN.ObtenerCuentaIGVDeEmpresaAcceso();

            //ejecutar metodo
            iLisRes = ArmarAsientoTotalParaCompraNormal(pRegConCab, iCuePvEN, pLisRegConDetEdi, iCueIgvEN, iLisCueAna);

            //devolver
            return iLisRes;
        }

        public static List<RegContabDetaEN> ArmarAsientoTotalParaCompraEspecial(RegContabCabeEN pRegConCab, List<RegContabDetaEN> pLisRegConDetEdi)
        {
            //lista resultado
            List<RegContabDetaEN> iLisRes = new List<RegContabDetaEN>();

            //valida si la lista editada esta vacia
            if (pLisRegConDetEdi.Count == 0) { return iLisRes; }

            //traer todas las cuentas analiticas de la empresa de acceso
            List<CuentaEN> iLisCueAna = CuentaRN.ListarCuentaAnalitica();
            
            //ejecutar metodo
            iLisRes = ArmarAsientoTotalParaCompraEspecial(pRegConCab, pLisRegConDetEdi, iLisCueAna);

            //devolver
            return iLisRes;
        }

        public static RegContabDetaEN CrearRegContabDetaIgv(RegContabCabeEN pRegConCab, CuentaEN pCueIGV, List<RegContabDetaEN> pLisRegConDetEdi)
        {
            //asignar parametros            
            string iDebeHaber = pLisRegConDetEdi[0].CDebeHaber;

            //ejecutar metodo
            return CrearRegContabDeta(pRegConCab, pCueIGV, iDebeHaber, pRegConCab.IgvSolRegContabCabe,string.Empty, ItemGEN.TipoLineaAsiento_CompletaAsiento);
        }

        public static RegContabDetaEN CrearRegContabDetaPrecioVenta(RegContabCabeEN pRegConCab, CuentaEN pCuePV, List<RegContabDetaEN> pLisRegConDetEdi)
        {
            //asignar parametros            
            string iDebeHaber = ObtenerOpuestoDebeHaber(pLisRegConDetEdi[0].CDebeHaber);

            //ejecutar metodo
            return CrearRegContabDeta(pRegConCab, pCuePV, iDebeHaber, pRegConCab.PrecioVentaSolRegContabCabe,string.Empty, ItemGEN.TipoLineaAsiento_CompletaAsiento);
        }

        public static RegContabDetaEN CrearRegContabDeta(RegContabCabeEN pRegConCab, CuentaEN pCue, string pFlagDebeHaber, decimal pImporteSol,
            string pCIngresoEgreso, string pTipoLineaAsiento)
        {
            //objeto resultado
            RegContabDetaEN iRegConDetEN = new RegContabDetaEN();

            //pasamos datos de la cabecera(hay muchos datos en el detalle que vienen de la cabecera)
            PasarDatosDeRegContabCabe(iRegConDetEN, pRegConCab);

            //creamos 
            iRegConDetEN = CrearRegContabDeta(iRegConDetEN, pCue, pFlagDebeHaber, pImporteSol, pCIngresoEgreso, pTipoLineaAsiento);

            //devolver
            return iRegConDetEN;
        }

        public static RegContabDetaEN CrearRegContabDeta(RegContabDetaEN pRegConDet, CuentaEN pCue, string pFlagDebeHaber, decimal pImporteSol,
            string pCIngresoEgreso, string pTipoLineaAsiento)
        {
            //objeto resultado(clonamos al objeto pRegConDet)
            RegContabDetaEN iRegConDetEN = ObjetoG.Clonar<RegContabDetaEN>(pRegConDet);
            
            //pasamos datos de cuenta
            PasarDatosDeCuenta(iRegConDetEN, pCue);

            //pasamos los datos faltantes
            iRegConDetEN.CDebeHaber = pFlagDebeHaber;
            iRegConDetEN.ImporteSolRegContabDeta = pImporteSol;
            iRegConDetEN.CIngresoEgreso = pCIngresoEgreso;
            iRegConDetEN.CTipoLineaAsiento = pTipoLineaAsiento;

            //actualizar datos segun flags de cuenta
            ActualizarDatosSegunFlagsCuenta(iRegConDetEN);

            //devolver
            return iRegConDetEN;
        }

        public static void PasarDatosDeRegContabCabe(RegContabDetaEN pRegConDet, RegContabCabeEN pRegConCab)
        {
            //pasando datos al objeto pRegConDet
            pRegConDet.CodigoEmpresa = pRegConCab.CodigoEmpresa;
            pRegConDet.PeriodoRegContabCabe = pRegConCab.PeriodoRegContabCabe;
            pRegConDet.COrigen = pRegConCab.COrigen;
            pRegConDet.CFile = pRegConCab.CFile;
            pRegConDet.CorrelativoRegContabCabe = pRegConCab.CorrelativoRegContabCabe;
            pRegConDet.ClaveRegContabCabe = pRegConCab.ClaveRegContabCabe;
            pRegConDet.VentaTipoCambio = pRegConCab.VentaTipoCambio;
            pRegConDet.CodigoAuxiliar = pRegConCab.CodigoAuxiliar;
            pRegConDet.DescripcionAuxiliar = pRegConCab.DescripcionAuxiliar;
            pRegConDet.CTipoDocumento = pRegConCab.CTipoDocumento;
            pRegConDet.NTipoDocumento = pRegConCab.NTipoDocumento;
            pRegConDet.SerieDocumento = pRegConCab.SerieDocumento;
            pRegConDet.NumeroDocumento = pRegConCab.NumeroDocumento;
            pRegConDet.CMonedaDocumento = pRegConCab.CMonedaDocumento;
            pRegConDet.FechaDocumento = pRegConCab.FechaDocumento;
            pRegConDet.FechaVctoDocumento = pRegConCab.FechaVctoDocumento;
            pRegConDet.GlosaRegContabDeta = pRegConCab.GlosaRegContabCabe;           
        }
        
        public static void PasarDatosDeRegContabCabe(List<RegContabDetaEN> pLisRegConDet, RegContabCabeEN pRegConCab)
        {
            //recorrer cada objeto RegContabDeta
            foreach (RegContabDetaEN xRegConDet in pLisRegConDet)
            {
                //pasamos los datos de RegConCab a xRegConDet
                PasarDatosDeRegContabCabe(xRegConDet, pRegConCab);
            }
        }

        public static void PasarDatosDeCuenta(RegContabDetaEN pRegConDet, CuentaEN pCue)
        {
            pRegConDet.CodigoCuenta = pCue.CodigoCuenta;
            pRegConDet.DescripcionCuenta = pCue.DescripcionCuenta;
            pRegConDet.CCentroCostoCuenta = pCue.CCentroCosto;
            pRegConDet.CAlmacen = pCue.CAlmacen;
            pRegConDet.CAreaCuenta = pCue.CArea;
            pRegConDet.CAuxiliar = pCue.CAuxiliar;
            pRegConDet.CDocumento = pCue.CDocumento;
            pRegConDet.CAutomatica = pCue.CAutomatica;
            pRegConDet.CodigoCuentaAutomatica1 = pCue.CodigoCuentaAutomatica1;
            pRegConDet.CodigoCuentaAutomatica2 = pCue.CodigoCuentaAutomatica2;
        }

        public static void ActualizarDatosSegunFlagsCuenta(RegContabDetaEN pRegConDet)
        {
            if (EsDigitableAuxiliar(pRegConDet) == false)
            {
                pRegConDet.CodigoAuxiliar = string.Empty;
                pRegConDet.DescripcionAuxiliar = string.Empty;
            }

            if (EsDigitableDocumento(pRegConDet) == false)
            {
                pRegConDet.CTipoDocumento = string.Empty;
                pRegConDet.NTipoDocumento = string.Empty;
                pRegConDet.SerieDocumento = string.Empty;
                pRegConDet.NumeroDocumento = string.Empty;
                pRegConDet.CMonedaDocumento = string.Empty;
                pRegConDet.FechaDocumento = string.Empty;
                pRegConDet.FechaVctoDocumento = string.Empty;
            }

            if (EsDigitableCentroCosto(pRegConDet) == false)
            {
                pRegConDet.CCentroCosto = string.Empty;
                pRegConDet.NCentroCosto = string.Empty;
            }

            if (EsDigitableArea(pRegConDet) == false)
            {
                pRegConDet.CArea = string.Empty;
                pRegConDet.NArea = string.Empty;
            }

            if (EsDigitableAlmacen(pRegConDet) == false)
            {
                pRegConDet.CodigoAlmacen = string.Empty;
                pRegConDet.DescripcionAlmacen = string.Empty;
                pRegConDet.CodigoItemAlmacen = string.Empty;
                pRegConDet.DescripcionItemAlmacen = string.Empty;
                pRegConDet.CantidadItemAlmacen = 0;
            }
        }

        public static void ActualizarDatosSegunFlagsCuenta(List<RegContabDetaEN> pLisRegConDet)
        {
            //recorrer cada objeto RegContabDeta
            foreach (RegContabDetaEN xRegConDet in pLisRegConDet)
            {
                //actualizar
                ActualizarDatosSegunFlagsCuenta(xRegConDet);
            }
        }

        public static List<RegContabDetaEN> CrearAsientosAutomaticos(List<RegContabDetaEN> pLisRegConDet, List<CuentaEN> pLisCue)
        {
            //lista resultado
            List<RegContabDetaEN> iLisRes = new List<RegContabDetaEN>();

            //----------------------------------------------------------------------------------
            //en esta funcion se asume que los datos necesarios ya estan en el objeto xRegConDet
            //----------------------------------------------------------------------------------
            //recorrer cada RegConDet
            foreach (RegContabDetaEN xRegConDet in pLisRegConDet)
            {
                //si la cuenta de pRegConDet no aplica para generar automatica,entonces pasa al siguiente objeto
                if (xRegConDet.CAutomatica == "0") { continue; }

                //asignar parametros
                CuentaEN iCueAut1EN = ListaG.Buscar<CuentaEN>(pLisCue, CuentaEN.CodCue, xRegConDet.CodigoCuentaAutomatica1);
                CuentaEN iCueAut2EN = ListaG.Buscar<CuentaEN>(pLisCue, CuentaEN.CodCue, xRegConDet.CodigoCuentaAutomatica2);

                //ejecutar metodo y pasar a lista resultado
                iLisRes.AddRange(CrearAsientosAutomaticos(xRegConDet, iCueAut1EN, iCueAut2EN));
            }

            //devolver
            return iLisRes;
        }

        public static List<RegContabDetaEN> CrearAsientosAutomaticos(RegContabDetaEN pRegConDet, CuentaEN pCueAut1, CuentaEN pCueAut2)
        {
            //lista resultado
            List<RegContabDetaEN> iLisRes = new List<RegContabDetaEN>();

            //si la cuenta de pRegConDet no aplica para generar automatica,entonces devuelve la lista vacia
            if (pRegConDet.CAutomatica == "0") { return iLisRes; }

            //----------------------------------------
            //crear la linea de la cuenta automatica 1
            //----------------------------------------
            //creamos el nuevo objeto a partir de pRegConDet
            RegContabDetaEN iRegConDet1EN = CrearRegContabDeta(pRegConDet, pCueAut1, pRegConDet.CDebeHaber, pRegConDet.ImporteSolRegContabDeta,
                string.Empty, ItemGEN.TipoLineaAsiento_AsientoAutomatico);
                        
            //agregar a la lista resultado
            iLisRes.Add(iRegConDet1EN);

            //----------------------------------------
            //crear la linea de la cuenta automatica 2
            //----------------------------------------
            //creamos el nuevo objeto a partir de pRegConDet
            RegContabDetaEN iRegConDet2EN = CrearRegContabDeta(pRegConDet, pCueAut2, ObtenerOpuestoDebeHaber(pRegConDet.CDebeHaber),
                pRegConDet.ImporteSolRegContabDeta, string.Empty, ItemGEN.TipoLineaAsiento_AsientoAutomatico);
                        
            //agregar a la lista resultado
            iLisRes.Add(iRegConDet2EN);

            //devolver
            return iLisRes;
        }

        public static string ObtenerOpuestoDebeHaber(string pCDebeHaber)
        {
            if (pCDebeHaber == ItemGEN.DebeHaber_Haber)
            {
                return ItemGEN.DebeHaber_Debe;
            }
            if (pCDebeHaber == ItemGEN.DebeHaber_Debe)
            {
                return ItemGEN.DebeHaber_Haber;
            }
            return string.Empty;
        }

        public static List<RegContabDetaEN> CrearListaRegContabDetaActualizadaSoloDatosCabecera(RegContabCabeEN pRegConCab, List<RegContabDetaEN> pLisRegConDetEditada)
        {
            //lista resultado
            List<RegContabDetaEN> iLisRes = new List<RegContabDetaEN>();

            //primero pasamos todos los datos de la cabecera a los detalles
            PasarDatosDeRegContabCabe(pLisRegConDetEditada, pRegConCab);

            //segundo actualizamos los datos segun los flag de la cuenta
            ActualizarDatosSegunFlagsCuenta(pLisRegConDetEditada);

            //agregamos a la lista resultado
            iLisRes.AddRange(pLisRegConDetEditada);

            //devolver
            return iLisRes;
        }

        public static List<RegContabDetaEN> ListarRegContabDetaXClaveRegContabCabeYTipoLineaAsiento(RegContabDetaEN pObj)
        {
            RegContabDetaAD iObjAD = new RegContabDetaAD();
            return iObjAD.ListarRegContabDetaXClaveRegContabCabeYTipoLineaAsiento(pObj);
        }

        public static List<RegContabDetaEN> ListarRegContabDetaXClaveRegContabCabeYTipoLineaAsientoCompleto(RegContabDetaEN pObj)
        {
            RegContabDetaAD iObjAD = new RegContabDetaAD();
            return iObjAD.ListarRegContabDetaXClaveRegContabCabeYTipoLineaAsientoCompleto(pObj);
        }

        public static RegContabDetaEN EsActoParaEditarNuevoRegContabDeta(RegContabCabeEN pRegConCab, List<RegContabDetaEN> pLisRegConDet)
        {
            //objeto resultado
            RegContabDetaEN iRegConDetEN = new RegContabDetaEN();
            
            //segun tipo compra
            if (pRegConCab.CTipoCompra == ItemGEN.TipoCompra_Normal)
            {
                return EsActoParaEditarNuevoRegContabDetaNormal(pRegConCab, pLisRegConDet);
            }
            else
            {
                return EsActoParaEditarNuevoRegContabDetaEspecial(pRegConCab, pLisRegConDet);
            }
        }

        public static RegContabDetaEN EsActoParaEditarNuevoRegContabDetaNormal(RegContabCabeEN pRegConCab, List<RegContabDetaEN> pLisRegConDet)
        {
            //objeto resultado
            RegContabDetaEN iRegConDetEN = new RegContabDetaEN();

            //valida cuando no hay nada que distribuir
            iRegConDetEN = ValidaCuandoNoHayNadaQueDistribuir(pRegConCab);
            if (iRegConDetEN.Adicionales.EsVerdad == false) { return iRegConDetEN; }

            //valida cuando el saldo a distribuir es menor o igual a cero
            iRegConDetEN = ValidaCuandoSaldoDistribuirNoEsPositivo(pRegConCab, pLisRegConDet);
            if (iRegConDetEN.Adicionales.EsVerdad == false) { return iRegConDetEN; }

            //ok
            return iRegConDetEN;
        }

        public static RegContabDetaEN ValidaCuandoNoHayNadaQueDistribuir(RegContabCabeEN pRegConCab)
        {
            //objeto resultado
            RegContabDetaEN iRegConDetEN = new RegContabDetaEN();

            //validar
            if (RegContabCabeRN.ObtenerImporteTotalSolesDistribucion(pRegConCab) == 0)
            {
                iRegConDetEN.Adicionales.EsVerdad = false;
                iRegConDetEN.Adicionales.Mensaje = "El importe total soles es cero, " + Universal.ErrorMensaje();
            }

            //devolver
            return iRegConDetEN;
        }

        public static RegContabDetaEN ValidaCuandoSaldoDistribuirNoEsPositivo(RegContabCabeEN pRegConCab, List<RegContabDetaEN> pLisRegConDet)
        {
            //asignar parametros
            decimal iSaldoDistribuir = RegContabCabeRN.ObtenerSaldoSolesDistribucion(pRegConCab, pLisRegConDet);

            //devolver
            return ValidaCuandoSaldoDistribuirNoEsPositivo(iSaldoDistribuir);
        }

        public static RegContabDetaEN ValidaCuandoSaldoDistribuirNoEsPositivo(decimal pSaldoDistribuir)
        {
            //objeto resultado
            RegContabDetaEN iRegConDetEN = new RegContabDetaEN();

            //validar
            if (pSaldoDistribuir <= 0)
            {
                iRegConDetEN.Adicionales.EsVerdad = false;
                iRegConDetEN.Adicionales.Mensaje = "El saldo tiene que ser positivo, " + Universal.ErrorMensaje();
            }

            //devolver
            return iRegConDetEN;
        }

        public static RegContabDetaEN EsActoParaEditarNuevoRegContabDetaEspecial(RegContabCabeEN pRegConCab, List<RegContabDetaEN> pLisRegConDet)
        {
            //objeto resultado
            RegContabDetaEN iRegConDetEN = new RegContabDetaEN();

            //valida cuando no hay nada que distribuir
            iRegConDetEN = ValidaCuandoNoHayNadaQueDistribuir(pRegConCab);
            if (iRegConDetEN.Adicionales.EsVerdad == false) { return iRegConDetEN; }

            //valida cuando el debe y haber ya esta cuadrado con el monto a distribuir
            iRegConDetEN = ValidaCuandoTotalSolesDistribuirEsIgualATotalesDebeYHaber(pRegConCab, pLisRegConDet);
            if (iRegConDetEN.Adicionales.EsVerdad == false) { return iRegConDetEN; }

            //valida cuando el debe y haber han sobrepasado el monto a distribuir
            iRegConDetEN = ValidaCuandoTotalSolesDistribuirEsMenorATotalesDebeOHaber(pRegConCab, pLisRegConDet);
            if (iRegConDetEN.Adicionales.EsVerdad == false) { return iRegConDetEN; }

            //ok
            return iRegConDetEN;
        }

        public static RegContabDetaEN ValidaCuandoTotalSolesDistribuirEsIgualATotalesDebeYHaber(decimal pTotalSolesDistribuir,decimal pTotalDebe,
            decimal pTotalHaber)
        {
            //objeto resultado
            RegContabDetaEN iRegConDetEN = new RegContabDetaEN();

            //validar
            if (pTotalSolesDistribuir == pTotalDebe && pTotalSolesDistribuir == pTotalHaber)
            {
                iRegConDetEN.Adicionales.EsVerdad = false;
                iRegConDetEN.Adicionales.Mensaje = "Los importes debe y haber ya estan distribuidos completamente, " + Universal.ErrorMensaje();
            }

            //devolver
            return iRegConDetEN;
        }

        public static RegContabDetaEN ValidaCuandoTotalSolesDistribuirEsMenorATotalesDebeOHaber(decimal pTotalSolesDistribuir, decimal pTotalDebe,
            decimal pTotalHaber)
        {
            //objeto resultado
            RegContabDetaEN iRegConDetEN = new RegContabDetaEN();

            //validar
            if (pTotalSolesDistribuir < pTotalDebe || pTotalSolesDistribuir < pTotalHaber)
            {
                iRegConDetEN.Adicionales.EsVerdad = false;
                iRegConDetEN.Adicionales.Mensaje = "Los importes debe o haber estan sobrepasados al monto a distribuir, " + Universal.ErrorMensaje();
            }

            //devolver
            return iRegConDetEN;
        }

        public static RegContabDetaEN ValidaCuandoTotalSolesDistribuirEsIgualATotalesDebeYHaber(RegContabCabeEN pRegConCab, List<RegContabDetaEN> pLisRegConDet)
        {
            //asignar parametros
            decimal iTotalSolesDistribuir = RegContabCabeRN.ObtenerImporteTotalSolesDistribucion(pRegConCab);
            decimal iTotalDebe = ObtenerTotalDebeSoles(pLisRegConDet);
            decimal iTotalHaber = ObtenerTotalHaberSoles(pLisRegConDet);

            //devolver
            return ValidaCuandoTotalSolesDistribuirEsIgualATotalesDebeYHaber(iTotalSolesDistribuir, iTotalDebe, iTotalHaber);
        }

        public static RegContabDetaEN ValidaCuandoTotalSolesDistribuirEsMenorATotalesDebeOHaber(RegContabCabeEN pRegConCab, List<RegContabDetaEN> pLisRegConDet)
        {
            //asignar parametros
            decimal iTotalSolesDistribuir = RegContabCabeRN.ObtenerImporteTotalSolesDistribucion(pRegConCab);
            decimal iTotalDebe = ObtenerTotalDebeSoles(pLisRegConDet);
            decimal iTotalHaber = ObtenerTotalHaberSoles(pLisRegConDet);

            //devolver
            return ValidaCuandoTotalSolesDistribuirEsMenorATotalesDebeOHaber(iTotalSolesDistribuir, iTotalDebe, iTotalHaber);
        }

        public static decimal ObtenerImporteSolSugerido(String pCDebHab, RegContabCabeEN pRegConCab, List<RegContabDetaEN> pLisRegConDet)
        {
            //segun tipo compra
            if (pCDebHab == ItemGEN.TipoCompra_Normal)
            {
                return ObtenerImporteSolSugeridoNormal(pRegConCab, pLisRegConDet);
            }
            else
            {
                return ObtenerImporteSolSugeridoEspecial(pCDebHab, pRegConCab, pLisRegConDet);
            }

        }

        public static decimal ObtenerImporteSolSugeridoNormal(RegContabCabeEN pRegConCab, List<RegContabDetaEN> pLisRegConDet)
        {
            return RegContabCabeRN.ObtenerSaldoSolesDistribucion(pRegConCab, pLisRegConDet);
        }

        public static decimal ObtenerImporteSolSugeridoEspecial(String pCDebHab, RegContabCabeEN pRegConCab, List<RegContabDetaEN> pLisRegConDet)
        {
            //valor resultado
            decimal iValor = 0;

            //calcular
            //segun debe o haber
            if (pCDebHab == ItemGEN.DebeHaber_Debe)
            {
                //obtener total soles distribucion
                decimal iTotalSolDist = RegContabCabeRN.ObtenerImporteTotalSolesDistribucion(pRegConCab);

                //obtener total debe
                decimal iTotalDebe = ObtenerTotalDebeSoles(pLisRegConDet);
                MessageBox.Show("debe");
                //restar
                iValor = iTotalSolDist - iTotalDebe;
            }
            else
            {
                //obtener total soles distribucion
                decimal iTotalSolDist = RegContabCabeRN.ObtenerImporteTotalSolesDistribucion(pRegConCab);

                //obtener total haber
                decimal iTotalHaber = ObtenerTotalHaberSoles(pLisRegConDet);
                MessageBox.Show("haber");
                //restar
                iValor = iTotalSolDist - iTotalHaber;
            }

            //devoler
            return iValor;
        }
        public static List<RegContabDetaEN> RefrescarListaRegContabDeta(List<RegContabDetaEN> pLis)
        {
            List<RegContabDetaEN> iLisRes = new List<RegContabDetaEN>();
            foreach (RegContabDetaEN xMovDet in pLis)
            {
                iLisRes.Add(xMovDet);
            }
            return iLisRes;
        }

    }
}
