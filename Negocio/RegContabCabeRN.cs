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
    public class RegContabCabeRN
    {

        public static RegContabCabeEN EnBlanco()
        {
            RegContabCabeEN iObjEN = new RegContabCabeEN();
            return iObjEN;
        }

        public static void AdicionarRegContabCabe(List<RegContabCabeEN> pLista)
        {
            RegContabCabeAD iObjAD = new RegContabCabeAD();
            iObjAD.AdicionarRegContabCabe(pLista);
        }

        public static void AdicionarRegContabCabe(RegContabCabeEN pObj)
        {
            //Asignar parametros
            List<RegContabCabeEN> iLisObj = new List<RegContabCabeEN>();
            ObtenerValoresEnSoles(pObj);
            iLisObj.Add(pObj);

            //Ejecutar metodo
            RegContabCabeRN.AdicionarRegContabCabe(iLisObj);
        }

        public static void ModificarRegContabCabe(List<RegContabCabeEN> pLista)
        {
            RegContabCabeAD iObjAD = new RegContabCabeAD();
            iObjAD.ModificarRegContabCabe(pLista);
        }

        public static void ModificarRegContabCabe(RegContabCabeEN pObj)
        {
            //Asignar parametros
            List<RegContabCabeEN> iLisObj = new List<RegContabCabeEN>();
            ObtenerValoresEnSoles(pObj);
            iLisObj.Add(pObj);

            //Ejecutar metodo
            RegContabCabeRN.ModificarRegContabCabe(iLisObj);
        }

        public static void EliminarRegContabCabe(List<RegContabCabeEN> pLista)
        {
            RegContabCabeAD iObjAD = new RegContabCabeAD();
            iObjAD.EliminarRegContabCabe(pLista);
        }

        public static void EliminarRegContabCabe(RegContabCabeEN pObj)
        {
            //Asignar parametros
            List<RegContabCabeEN> iLisObj = new List<RegContabCabeEN>();
            iLisObj.Add(pObj);

            //Ejecutar metodo
            RegContabCabeRN.EliminarRegContabCabe(iLisObj);
        }

        public static List<RegContabCabeEN> ListarRegContabCabe(RegContabCabeEN pObj)
        {
            RegContabCabeAD iObjAD = new RegContabCabeAD();
            return iObjAD.ListarRegContabCabe(pObj);
        }

        public static List<RegContabCabeEN> ListarRegContabCabe()
        {
            //asignar parametros
            RegContabCabeEN iObjEN = new RegContabCabeEN();
            iObjEN.Adicionales.CampoOrden = RegContabCabeEN.ClaRegConCab;

            //ejecutar metodo
            return RegContabCabeRN.ListarRegContabCabe(iObjEN);
        }

        public static RegContabCabeEN BuscarRegContabCabeXClave(RegContabCabeEN pObj)
        {
            RegContabCabeAD iObjAD = new RegContabCabeAD();
            return iObjAD.BuscarRegContabCabeXClave(pObj);
        }

        public static RegContabCabeEN BuscarRegContabCabeXClave(string pClaveRegContabCabe)
        {
            //asignar parametros
            RegContabCabeEN iRegConCabEN = new RegContabCabeEN();
            iRegConCabEN.ClaveRegContabCabe = pClaveRegContabCabe;

            //ejecutar metodo
            return BuscarRegContabCabeXClave(iRegConCabEN);
        }

        public static RegContabCabeEN EsRegContabCabeExistente(RegContabCabeEN pObj)
        {
            //objeto resultado
            RegContabCabeEN iObjEN = new RegContabCabeEN();

            //validar si existe en b.d
            iObjEN = RegContabCabeRN.BuscarRegContabCabeXClave(pObj);
            if (iObjEN.ClaveRegContabCabe == string.Empty)
            {
                iObjEN.Adicionales.EsVerdad = false;
                iObjEN.Adicionales.Mensaje = "El Registro seleccionado no existe";
            }

            //ok  
            return iObjEN;
        }

        public static RegContabCabeEN EsCodigoRegContabCabeDisponible(RegContabCabeEN pObj)
        {
            //objeto resultado
            RegContabCabeEN iObjEN = new RegContabCabeEN();

            //valida cuando esta vacio
            if (pObj.PeriodoRegContabCabe == string.Empty) { return iObjEN; }

            //valida cuando esta vacio
            if (pObj.COrigen == string.Empty) { return iObjEN; }

            //valida cuando esta vacio
            if (pObj.CFile == string.Empty) { return iObjEN; }

            //valida cuando esta vacio
            if (pObj.CorrelativoRegContabCabe == string.Empty) { return iObjEN; }

            //valida cuando correlativo es "00000"
            iObjEN = ValidaCuandoCorrelativoEsCeros(pObj);
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }

            //validar si existe
            iObjEN = RegContabCabeRN.ValidaCuandoCodigoYaExiste(pObj);
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }

            //ok           
            return iObjEN;
        }

        public static RegContabCabeEN ValidaCuandoCorrelativoEsCeros(RegContabCabeEN pObj)
        {
            //objeto resultado
            RegContabCabeEN iObjEN = new RegContabCabeEN();

            //validar            
            if (pObj.CorrelativoRegContabCabe == "00000")
            {
                iObjEN.Adicionales.EsVerdad = false;
                iObjEN.Adicionales.Mensaje = "El correlativo no puede ser 00000";
            }

            //ok  
            return iObjEN;
        }

        public static RegContabCabeEN ValidaCuandoCodigoYaExiste(RegContabCabeEN pObj)
        {
            //objeto resultado
            RegContabCabeEN iObjEN = new RegContabCabeEN();

            //validar
            iObjEN = RegContabCabeRN.BuscarRegContabCabeXClave(pObj);
            if (iObjEN.ClaveRegContabCabe != string.Empty)
            {
                iObjEN.Adicionales.EsVerdad = false;
                iObjEN.Adicionales.Mensaje = "Este codigo ya existe";
            }

            //ok  
            return iObjEN;
        }

        public static List<RegContabCabeEN> FiltrarRegContabCabeXTextoEnCualquierPosicion(List<RegContabCabeEN> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<RegContabCabeEN> iLisRes = new List<RegContabCabeEN>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (RegContabCabeEN xObj in pLista)
            {
                string iTexto = ObjetoG.ObtenerTexto<RegContabCabeEN>(xObj, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xObj);
                }
            }

            //devolver
            return iLisRes;
        }

        public static List<RegContabCabeEN> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<RegContabCabeEN> pLista)
        {
            //lista resultado
            List<RegContabCabeEN> iLisRes = new List<RegContabCabeEN>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pLista; }

            //filtar la lista
            iLisRes = RegContabCabeRN.FiltrarRegContabCabeXTextoEnCualquierPosicion(pLista, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }

        public static string ObtenerClaveRegContabCabe(RegContabCabeEN pObj)
        {
            //valor resultado
            string iClave = string.Empty;

            //armar clave
            iClave += Universal.gCodigoEmpresa + "-";
            iClave += pObj.PeriodoRegContabCabe + "-";
            iClave += pObj.COrigen + "-";
            iClave += pObj.CFile + "-";
            iClave += pObj.CorrelativoRegContabCabe;

            //retornar
            return iClave;
        }

        public static RegContabCabeEN EsRegContabCabeValido(RegContabCabeEN pObj)
        {
            //objeto resultado
            RegContabCabeEN iObjEN = new RegContabCabeEN();

            //valida cuando esta vacio
            if (pObj.PeriodoRegContabCabe == string.Empty) { return iObjEN; }

            //valida cuando esta vacio
            if (pObj.COrigen == string.Empty) { return iObjEN; }

            //valida cuando esta vacio
            if (pObj.CFile == string.Empty) { return iObjEN; }

            //valida cuando esta vacio
            if (pObj.CorrelativoRegContabCabe == string.Empty) { return iObjEN; }

            //valida cuando el codigo no existe
            iObjEN = RegContabCabeRN.EsRegContabCabeExistente(pObj);
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }

            //ok           
            return iObjEN;
        }

        public static RegContabCabeEN EsRegContabCabeActivoValido(RegContabCabeEN pObj)
        {
            //objeto resultado
            RegContabCabeEN iObjEN = new RegContabCabeEN();

            //valida cuando esta vacio
            if (pObj.PeriodoRegContabCabe == string.Empty) { return iObjEN; }

            //valida cuando esta vacio
            if (pObj.COrigen == string.Empty) { return iObjEN; }

            //valida cuando esta vacio
            if (pObj.CFile == string.Empty) { return iObjEN; }

            //valida cuando esta vacio
            if (pObj.CorrelativoRegContabCabe == string.Empty) { return iObjEN; }

            //valida cuando el codigo no existe
            iObjEN = RegContabCabeRN.EsRegContabCabeExistente(pObj);
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }

            //valida cuando esta desactivada
            RegContabCabeEN iObjDesEN = RegContabCabeRN.ValidaCuandoEstaDesactivada(iObjEN);
            if (iObjDesEN.Adicionales.EsVerdad == false) { return iObjDesEN; }

            //ok           
            return iObjEN;
        }

        public static RegContabCabeEN ValidaCuandoEstaDesactivada(RegContabCabeEN pObj)
        {
            //objeto resultado
            RegContabCabeEN iObjEN = new RegContabCabeEN();

            //validar                 
            if (pObj.CEstadoRegContabCabe == "0")//desactivado
            {
                iObjEN.Adicionales.EsVerdad = false;
                iObjEN.Adicionales.Mensaje = "El(La) RegContabCabe esta desactivada";
            }

            //ok
            return iObjEN;
        }

        public static bool ExisteValorEnColumna(string pColumnaBusqueda, string pValorBusqueda)
        {
            RegContabCabeAD iObjAD = new RegContabCabeAD();
            return iObjAD.ExisteValorEnColumna(pColumnaBusqueda, pValorBusqueda);
        }

        public static bool ExisteValorEnColumna(string pColumnaBusqueda, string pValorBusqueda, string pColumnaCondicion1, string pValorCondicion1)
        {
            RegContabCabeAD iObjAD = new RegContabCabeAD();
            return iObjAD.ExisteValorEnColumna(pColumnaBusqueda, pValorBusqueda, pColumnaCondicion1, pValorCondicion1);
        }

        public static bool ExisteValorEnColumna(string pColumnaBusqueda, string pValorBusqueda, string pColumnaCondicion1, string pValorCondicion1, string pColumnaCondicion2, string pValorCondicion2)
        {
            RegContabCabeAD iObjAD = new RegContabCabeAD();
            return iObjAD.ExisteValorEnColumna(pColumnaBusqueda, pValorBusqueda, pColumnaCondicion1, pValorCondicion1, pColumnaCondicion2, pValorCondicion2);
        }

        public static string ObtenerMaximoValorEnColumna(string pColumnaBusqueda)
        {
            RegContabCabeAD iObjAD = new RegContabCabeAD();
            return iObjAD.ObtenerMaximoValorEnColumna(pColumnaBusqueda);
        }

        public static string ObtenerMaximoValorEnColumna(string pColumnaBusqueda, string pColumnaCondicion1, string pValorCondicion1)
        {
            RegContabCabeAD iObjAD = new RegContabCabeAD();
            return iObjAD.ObtenerMaximoValorEnColumna(pColumnaBusqueda, pColumnaCondicion1, pValorCondicion1);
        }

        public static string ObtenerMaximoValorEnColumna(string pColumnaBusqueda, string pColumnaCondicion1, string pValorCondicion1, string pColumnaCondicion2, string pValorCondicion2)
        {
            RegContabCabeAD iObjAD = new RegContabCabeAD();
            return iObjAD.ObtenerMaximoValorEnColumna(pColumnaBusqueda, pColumnaCondicion1, pValorCondicion1, pColumnaCondicion2, pValorCondicion2);
        }
        
        public static string ObtenerNuevoCorrelativoRegContabCabeAutogenerado(RegContabCabeEN pObj)
        {
            //valor resultado
            string iNumero = string.Empty;

            //obtener el ultimo codigo que hay en la b.d
            string iUltimoCodigo = RegContabCabeRN.ObtenerMaximoValorEnColumna(RegContabCabeEN.CorRegConCab, RegContabCabeEN.PerRegConCab,
                pObj.PeriodoRegContabCabe, RegContabCabeEN.CFil, pObj.CFile);

            //obtener el siguiente codigo
            iNumero = Numero.IncrementarCorrelativoNumerico(iUltimoCodigo, 5);

            //devuelve
            return iNumero;
        }

        public static RegContabCabeEN EsActoAdicionarRegContabCabe(RegContabCabeEN pObj)
        {
            //objeto resultado
            RegContabCabeEN iRegConCabEN = new RegContabCabeEN();

            //valida cuando es no es acto registrar en este periodo
            iRegConCabEN = ValidaCuandoNoEsActoRegistrarEnPeriodo(pObj);
            if (iRegConCabEN.Adicionales.EsVerdad == false) { return iRegConCabEN; }

            //ok          
            return iRegConCabEN;
        }

        public static RegContabCabeEN ValidaCuandoNoEsActoRegistrarEnPeriodo(RegContabCabeEN pObj)
        {
            //objeto resultado
            RegContabCabeEN iRegConCabEN = new RegContabCabeEN();

            //validar
            PeriodoEN iPerEN = new PeriodoEN();
            iPerEN.CodigoPeriodo = pObj.PeriodoRegContabCabe;
            iPerEN = PeriodoRN.EsActoRegistrarEnEstePeriodo(iPerEN);

            //pasamos datos de la validacion
            iRegConCabEN.Adicionales.EsVerdad = iPerEN.Adicionales.EsVerdad;
            iRegConCabEN.Adicionales.Mensaje = iPerEN.Adicionales.Mensaje;

            //devolver
            return iRegConCabEN;
        }

        public static RegContabCabeEN EsActoModificarRegContabCabe(RegContabCabeEN pObj)
        {
            //objeto resultado
            RegContabCabeEN iObjEN = new RegContabCabeEN();

            //valida cuando el codigo no existe
            iObjEN = RegContabCabeRN.EsRegContabCabeExistente(pObj);
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }

            //ok          
            return iObjEN;
        }

        public static RegContabCabeEN EsActoEliminarRegContabCabe(RegContabCabeEN pObj)
        {
            //objeto resultado
            RegContabCabeEN iObjEN = new RegContabCabeEN();

            //valida cuando el codigo no existe
            iObjEN = RegContabCabeRN.EsRegContabCabeExistente(pObj);
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }

            //ok          
            return iObjEN;
        }

        public static List<RegContabCabeEN> ListarRegContabCabeXPeriodoYOrigen(RegContabCabeEN pObj)
        {
            RegContabCabeAD iObjAD = new RegContabCabeAD();
            return iObjAD.ListarRegContabCabeXPeriodoYOrigen(pObj);
        }

        public static string ObtenerFechaRegContabCabeSugerido(string pPeriodoRegistro, string pFechaRegContabCabeDtp)
        {
            //si la fecha movimiento dtp pertenece al periodo registro, entonces se devuleve esta misma fecha
            if (Periodo.EsFechaDePeriodo(pFechaRegContabCabeDtp, pPeriodoRegistro) == true) { return pFechaRegContabCabeDtp; }

            //aqui la fecha es de otro periodo, entonces formamos una fecha con el periodo parametro
            return Periodo.ObtenerFecha("01", pPeriodoRegistro);
        }

        public static string ArmarCorrelativoRegContabCabe(string pCorrelativoRegContabCabe)
        {
            //valor resultado
            string iValor = string.Empty;

            //si el parametro llega vacio,entonces devuelve vacio
            if (pCorrelativoRegContabCabe == string.Empty) { return iValor; }

            //armar el correlativo completando con ceros a la izquierda
            iValor = Cadena.CompletarCadena(pCorrelativoRegContabCabe, 5, "0", Cadena.Direccion.Izquierda);

            //devolver
            return iValor;
        }

        public static RegContabCabeEN ValidaCuandoFechaRegContabCabeNoEsDelPeriodoElegido(RegContabCabeEN pObj)
        {
            //objeto resultado
            RegContabCabeEN iRegConCabEN = new RegContabCabeEN();

            //validar
            bool iEsVerdad = Periodo.EsFechaDePeriodo(pObj.FechaRegContabCabe, pObj.PeriodoRegContabCabe);
            if (iEsVerdad == false)
            {
                iRegConCabEN.Adicionales.EsVerdad = false;
                iRegConCabEN.Adicionales.Mensaje = "La fecha " + pObj.FechaRegContabCabe + " debe ser del periodo " +
                                                Periodo.FormatoAñoYNombreMes(pObj.PeriodoRegContabCabe);                
            }

            //ok
            return iRegConCabEN;
        }

        public static string ArmarSerieDocumento(string pSerieDocumento)
        {
            //valor resultado
            string iValor = string.Empty;

            //si el parametro llega vacio,entonces devuelve vacio
            if (pSerieDocumento == string.Empty) { return iValor; }

            //obtener el primer caracter de esta serie
            string iPrimerCaracter = Cadena.CortarCadena(pSerieDocumento, 1);

            //si no es numerico,entonces termina proceso
            if(Validacion.CaracterDecimal(iPrimerCaracter) == false) { return pSerieDocumento; }

            //armar el correlativo completando con ceros a la izquierda
            iValor = Cadena.CompletarCadena(pSerieDocumento, 4, "0", Cadena.Direccion.Izquierda);

            //devolver
            return iValor;
        }

        public static string ArmarNumeroDocumento(string pNumeroDocumento)
        {
            //valor resultado
            string iValor = string.Empty;

            //si el parametro llega vacio,entonces devuelve vacio
            if (pNumeroDocumento == string.Empty) { return iValor; }
            
            //armar el correlativo completando con ceros a la izquierda
            iValor = Cadena.CompletarCadena(pNumeroDocumento, 15, "0", Cadena.Direccion.Izquierda);

            //devolver
            return iValor;
        }

        public static RegContabCabeEN EsDocumentoDisponible(RegContabCabeEN pObj)
        {
            //objeto resultado
            RegContabCabeEN iObjEN = new RegContabCabeEN();

            //valida cuando esta vacio
            if (pObj.CodigoAuxiliar == string.Empty) { return iObjEN; }

            //valida cuando esta vacio
            if (pObj.CTipoDocumento == string.Empty) { return iObjEN; }

            //valida cuando esta vacio
            if (pObj.SerieDocumento == string.Empty) { return iObjEN; }

            //valida cuando esta vacio
            if (pObj.NumeroDocumento == string.Empty) { return iObjEN; }
            
            //validar si existe
            iObjEN = RegContabCabeRN.ValidaCuandoCodigoYaExiste(pObj);
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }

            //ok           
            return iObjEN;
        }

        public static RegContabCabeEN ValidaCuandoDocumentoYaExiste(RegContabCabeEN pObj)
        {
            //objeto resultado
            RegContabCabeEN iObjEN = new RegContabCabeEN();

            //validar
            iObjEN = RegContabCabeRN.BuscarRegContabCabeXDocumento(pObj);            
            if (iObjEN.ClaveRegContabCabe != string.Empty)
            {
                if (iObjEN.ClaveRegContabCabe != pObj.ClaveRegContabCabe)
                {
                    iObjEN.Adicionales.EsVerdad = false;
                    iObjEN.Adicionales.Mensaje = "Este documento ya se registro en el voucher : " + iObjEN.ClaveRegContabCabe;
                }
            }
            
            //ok  
            return iObjEN;
        }

        public static RegContabCabeEN BuscarRegContabCabeXDocumento(RegContabCabeEN pObj)
        {
            RegContabCabeAD iObjAD = new RegContabCabeAD();
            return iObjAD.BuscarRegContabCabeXDocumento(pObj);
        }

        public static decimal ObtenerVentaTipoCambio(RegContabCabeEN pObj)
        {
            //valor resultado
            decimal iValor = 0;

            //obtener
            TipoCambioEN iTipCamEN = new TipoCambioEN();
            iTipCamEN.FechaTipoCambio = ObtenerFechaParaTipoCambio(pObj);
            iTipCamEN = TipoCambioRN.BuscarTipoCambioXFecha(iTipCamEN);

            //obtener el tipo de cambio segun moneda
            iValor = TipoCambioRN.ObtenerVentaTipoCambio(iTipCamEN, pObj.CMonedaDocumento);

            //devolver
            return iValor;
        }

        public static string ObtenerFechaParaTipoCambio(RegContabCabeEN pObj)
        {
            if (pObj.CAplicaDocumentoRef == "1")
            {
                return pObj.FechaDocumentoRef;
            }
            else
            {
                return pObj.FechaDocumento;
            }
        }

        public static void ActualizarMontosDocumento(RegContabCabeEN pObj,ParametroEN pPar)
        {
            //obtener la suma de exonerado + inafecto en un campo especial
            pObj.Adicionales.Numero = pObj.ExoneradoRegContabCabe + pObj.InafectoRegContabCabe;

            //actualizando montos
            pObj.PrecioVentaRegContabCabe = ObtenerPrecioVenta(pObj);
            pObj.ExoneradoRegContabCabe = ObtenerExonerado(pObj);
            pObj.InafectoRegContabCabe = ObtenerInafecto(pObj);
            pObj.IgvRegContabCabe = ObtenerIgv(pObj, pPar);
            pObj.ValorVentaRegContabCabe = ObtenerValorVenta(pObj);
        }

        public static decimal ObtenerPrecioVenta(RegContabCabeEN pObj)
        {
            //valor resultado
            decimal iValor = 0;

            //si es compra especial
            if (pObj.CTipoCompra == "1")
            {
                iValor = pObj.ExoneradoRegContabCabe + pObj.InafectoRegContabCabe + pObj.ValorVentaRegContabCabe + pObj.IgvRegContabCabe;
            }
            else
            {
                iValor = pObj.PrecioVentaRegContabCabe;
            }

            //devolver
            return iValor;
        }

        public static decimal ObtenerExonerado(RegContabCabeEN pObj)
        {
            //valor resultado
            decimal iValor = 0;                       

            //operar
            if (pObj.CTipoDocumento == "03")//boleta
            {
                //si es compra especial
                if (pObj.CTipoCompra == "0")
                {
                    //si aplica inafecto
                    if (pObj.CAplicaInafecto == "0")
                    {
                        iValor = pObj.PrecioVentaRegContabCabe;
                    }
                }
                else
                {
                    //si aplica inafecto
                    if (pObj.CAplicaInafecto == "0")
                    {
                        iValor = pObj.Adicionales.Numero;
                    }
                }
            }
            else
            {               
                //si aplica inafecto
                if (pObj.CAplicaInafecto == "0")
                {
                    iValor = pObj.Adicionales.Numero;
                }                  
            }

            //devolver
            return iValor;
        }

        public static decimal ObtenerInafecto(RegContabCabeEN pObj)
        {
            //valor resultado
            decimal iValor = 0;

            //operar            
            if (pObj.CTipoDocumento == "03")//boleta
            {
                //si es compra especial
                if (pObj.CTipoCompra == "0")
                {
                    //si aplica inafecto
                    if (pObj.CAplicaInafecto == "1")
                    {
                        iValor = pObj.PrecioVentaRegContabCabe;
                    }
                }
                else
                {
                    //si aplica inafecto
                    if (pObj.CAplicaInafecto == "1")
                    {
                        iValor = pObj.Adicionales.Numero;
                    }
                }               
            }
            else
            {
                //si aplica inafecto
                if (pObj.CAplicaInafecto == "1")
                {
                    iValor = pObj.Adicionales.Numero;
                }
            }

            //devolver
            return iValor;
        }

        public static decimal ObtenerIgv(RegContabCabeEN pObj, ParametroEN pPar)
        {
            //valor resultado
            decimal iValor = 0;

            //valida cuando es compra especial
            if (pObj.CTipoCompra == "1")
            {
                iValor = pObj.IgvRegContabCabe;
            }
            else
            {
                //calcular
                decimal iDividendo = pObj.PrecioVentaRegContabCabe - pObj.ExoneradoRegContabCabe - pObj.InafectoRegContabCabe;
                decimal iDivisor = Operador.DivisionDecimal(pPar.PorcentajeIgv, 100 + pPar.PorcentajeIgv);
                iValor = Math.Round(iDividendo * iDivisor, 2);
            }                

            //devolver
            return iValor;
        }

        public static decimal ObtenerValorVenta(RegContabCabeEN pObj)
        {
            //valor resultado
            decimal iValor = 0;

            //valida cuando es compra especial
            if (pObj.CTipoCompra == "1")
            {
                iValor = pObj.ValorVentaRegContabCabe;
            }
            else
            {
                //calcular
                iValor = pObj.PrecioVentaRegContabCabe - pObj.ExoneradoRegContabCabe - pObj.InafectoRegContabCabe - pObj.IgvRegContabCabe;
            }
            
            //devolver
            return iValor;
        }

        public static bool EsEditablePrecioVenta(RegContabCabeEN pObj)
        {
            //valor resultado
            bool iValor = true;

            //si es compra especial
            if (pObj.CTipoCompra == "1")
            {
                iValor = false;
            }
            
            //devolver
            return iValor;
        }

        public static bool EsEditableExonerado(RegContabCabeEN pObj)
        {
            //valor resultado
            bool iValor = true;

            //si es compra especial
            if (pObj.CTipoDocumento == "03")//boleta
            {
                //si es compra especial
                if (pObj.CTipoCompra == "1")
                {
                    //si aplica inafecto
                    if (pObj.CAplicaInafecto == "0")
                    {
                        iValor = true;
                    }
                    else
                    {
                        iValor = false;
                    }
                }
                else
                {
                    iValor = false;
                }                
            }
            else
            {
                //si aplica inafecto
                if (pObj.CAplicaInafecto == "0")
                {
                    iValor = true;
                }
                else
                {
                    iValor = false;
                }
            }

            //devolver
            return iValor;
        }

        public static bool EsEditableInafecto(RegContabCabeEN pObj)
        {
            //valor resultado
            bool iValor = true;

            //si es compra especial
            if (pObj.CTipoDocumento == "03")//boleta
            {
                //si es compra especial
                if (pObj.CTipoCompra == "1")
                {
                    //si aplica inafecto
                    if (pObj.CAplicaInafecto == "0")
                    {
                        iValor = false;
                    }
                    else
                    {
                        iValor = true;
                    }
                }
                else
                {
                    iValor = false;
                }
            }
            else
            {
                //si aplica inafecto
                if (pObj.CAplicaInafecto == "0")
                {
                    iValor = false;
                }
                else
                {
                    iValor = true;
                }
            }

            //devolver
            return iValor;
        }

        public static bool EsEditableIgv(RegContabCabeEN pObj)
        {
            //valor resultado
            bool iValor = false;

            //si es compra especial
            if (pObj.CTipoCompra == "1")
            {
                iValor = true;
            }

            //devolver
            return iValor;
        }

        public static bool EsEditableValorVenta(RegContabCabeEN pObj)
        {
            //valor resultado
            bool iValor = false;

            //si es compra especial
            if (pObj.CTipoCompra == "1")
            {
                iValor = true;
            }

            //devolver
            return iValor;
        }

        public static bool EsEditableAplicaIgv(RegContabCabeEN pObj)
        {
            //valor resultado
            bool iValor = false;

            //si es compra especial
            if (pObj.CTipoCompra == "1")
            {
                iValor = false;
            }
            else
            {
                if (pObj.IgvRegContabCabe != 0)
                {
                    iValor = true;
                }
            }

            //devolver
            return iValor;
        }

        public static RegContabCabeEN EsDocumentoReferenciaValido(RegContabCabeEN pObj)
        {
            //objeto resultado
            RegContabCabeEN iRegConCabEN = new RegContabCabeEN();

            //valida cuando esta vacio
            if (pObj.CTipoDocumentoRef == string.Empty) { return iRegConCabEN; }

            //valida cuando esta vacio
            if (pObj.SerieDocumentoRef == string.Empty) { return iRegConCabEN; }

            //valida cuando esta vacio
            if (pObj.NumeroDocumentoRef == string.Empty) { return iRegConCabEN; }

            //valida si existe
            iRegConCabEN = ValidaCuandoDocumentoReferenciaNoExiste(pObj);
            if (iRegConCabEN.Adicionales.EsVerdad == false) { return iRegConCabEN; }

            //ok
            return iRegConCabEN;
        }

        public static RegContabCabeEN ValidaCuandoDocumentoNoExiste(RegContabCabeEN pObj)
        {
            //objeto resultado
            RegContabCabeEN iObjEN = new RegContabCabeEN();

            //validar
            iObjEN = RegContabCabeRN.BuscarRegContabCabeXDocumento(pObj);
            if (iObjEN.ClaveRegContabCabe == string.Empty)
            {
                iObjEN.Adicionales.EsVerdad = false;
                iObjEN.Adicionales.Mensaje = "Este documento no existe";
            }

            //ok  
            return iObjEN;
        }

        public static RegContabCabeEN ValidaCuandoDocumentoReferenciaNoExiste(RegContabCabeEN pObj)
        {
            //asignar parametros
            RegContabCabeEN iObjEN = new RegContabCabeEN();            
            iObjEN.CodigoAuxiliar = pObj.CodigoAuxiliar;
            iObjEN.CTipoDocumento = pObj.CTipoDocumentoRef;
            iObjEN.SerieDocumento = pObj.SerieDocumentoRef;
            iObjEN.NumeroDocumento = pObj.NumeroDocumentoRef;
            
            //ejecutar metodo
            return ValidaCuandoDocumentoNoExiste(iObjEN);
        }

        public static void ObtenerValoresEnSoles(RegContabCabeEN pObj)
        {
            //saber de que moneda es el comprobante
            if (pObj.CMonedaDocumento == "0")//soles
            {
                pObj.ValorVentaSolRegContabCabe = pObj.ValorVentaRegContabCabe;
                pObj.IgvSolRegContabCabe = pObj.IgvRegContabCabe;
                pObj.PrecioVentaSolRegContabCabe = pObj.PrecioVentaRegContabCabe;
                pObj.ExoneradoSolRegContabCabe = pObj.ExoneradoRegContabCabe;
                pObj.InafectoSolRegContabCabe = pObj.InafectoRegContabCabe;
            }
            else
            {
                //otra moneda
                pObj.IgvSolRegContabCabe = Math.Round(pObj.IgvRegContabCabe * pObj.VentaTipoCambio, 2);
                pObj.PrecioVentaSolRegContabCabe = Math.Round(pObj.PrecioVentaRegContabCabe * pObj.VentaTipoCambio, 2);
                pObj.ExoneradoSolRegContabCabe = Math.Round(pObj.ExoneradoRegContabCabe * pObj.VentaTipoCambio, 2);
                pObj.InafectoSolRegContabCabe = Math.Round(pObj.InafectoRegContabCabe * pObj.VentaTipoCambio, 2);
                pObj.ValorVentaSolRegContabCabe = pObj.PrecioVentaSolRegContabCabe - pObj.ExoneradoSolRegContabCabe -
                    pObj.InafectoSolRegContabCabe - pObj.IgvSolRegContabCabe;
            }
        }

        public static decimal ObtenerImporteTotalDistribucion(RegContabCabeEN pObj)
        {
            //valor resultado
            decimal iValor = 0;

            //calcular
            if (pObj.IgvRegContabCabe != 0 && pObj.CAplicaIgv == "1")
            {
                iValor = pObj.PrecioVentaRegContabCabe - pObj.IgvRegContabCabe;
            }
            else
            {
                iValor = pObj.PrecioVentaRegContabCabe;
            }

            //devolver
            return iValor;
        }

        public static decimal ObtenerImporte1(RegContabCabeEN pObj, List<RegContabDetaEN> pLisRegConDet)
        {
            //segun tipo de compra
            if (pObj.CTipoCompra == ItemGEN.TipoCompra_Normal)//normal
            {
                return ObtenerImporteTotalSolesDistribucion(pObj);
            }
            else
            {
                //especial
                return RegContabDetaRN.ObtenerTotalDebeSoles(pLisRegConDet);
            }
        }
        
        public static decimal ObtenerImporteTotalSolesDistribucion(RegContabCabeEN pObj)
        {
            //valor resultado
            decimal iValor = 0;

            //calcular
            ObtenerValoresEnSoles(pObj);
            if (pObj.IgvSolRegContabCabe != 0 && pObj.CAplicaIgv == "1")
            {
                iValor = pObj.PrecioVentaSolRegContabCabe - pObj.IgvSolRegContabCabe;
            }
            else
            {
                iValor = pObj.PrecioVentaSolRegContabCabe;
            }

            //devolver
            return iValor;
        }

        public static decimal ObtenerImporte2(RegContabCabeEN pObj, decimal pImpTotSol, List<RegContabDetaEN> pLisRegConDet)
        {
            //segun tipo de compra
            if (pObj.CTipoCompra == ItemGEN.TipoCompra_Normal)//normal
            {
                return ObtenerSaldoSolesDistribucion(pImpTotSol,pLisRegConDet);
            }
            else
            {
                //especial
                return RegContabDetaRN.ObtenerTotalHaberSoles(pLisRegConDet);
            }
        }

        public static decimal ObtenerSaldoSolesDistribucion(decimal pImpTotSol, List<RegContabDetaEN> pLisRegConDet)
        {
            //valor resultado
            decimal iValor = 0;

            //calcular
            iValor = pImpTotSol - ListaG.Sumar<RegContabDetaEN>(pLisRegConDet, RegContabDetaEN.ImpSolRegConDet);

            //devolver
            return iValor;
        }

        public static decimal ObtenerSaldoSolesDistribucion(RegContabCabeEN pObj, List<RegContabDetaEN> pLisRegConDet)
        {
            //asignar parametros
            decimal iImporteTotalSoles = ObtenerImporteTotalSolesDistribucion(pObj);

            //ejecutar metodo
            return ObtenerSaldoSolesDistribucion(iImporteTotalSoles, pLisRegConDet);
        }

    }
}
