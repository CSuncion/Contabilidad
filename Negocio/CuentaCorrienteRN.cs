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
    public class CuentaCorrienteRN
    {

        public static CuentaCorrienteEN EnBlanco()
        {
            CuentaCorrienteEN iCtaCteEN = new CuentaCorrienteEN();
            return iCtaCteEN;
        }

        public static void AdicionarCuentaCorriente(CuentaCorrienteEN pObj)
        {
            CuentaCorrienteAD iCtaCteAD = new CuentaCorrienteAD();
            iCtaCteAD.AgregarCuentaCorriente(pObj);
        }

        public static void ModificarCuentaCorriente(CuentaCorrienteEN pObj)
        {
            CuentaCorrienteAD iCtaCteAD = new CuentaCorrienteAD();
            iCtaCteAD.ModificarCuentaCorriente(pObj);
        }

        public static void EliminarCuentaCorriente(CuentaCorrienteEN pObj)
        {
            CuentaCorrienteAD iCtaCteAD = new CuentaCorrienteAD();
            iCtaCteAD.EliminarCuentaCorriente(pObj);
        }

        public static List<CuentaCorrienteEN> ListarCuentaCorriente(CuentaCorrienteEN pObj)
        {
            CuentaCorrienteAD iCtaCteAD = new CuentaCorrienteAD();
            return iCtaCteAD.ListarCuentaCorriente(pObj);
        }

        public static CuentaCorrienteEN BuscarCuentaCorrienteXClave(CuentaCorrienteEN pObj)
        {
            CuentaCorrienteAD iCtaCteAD = new CuentaCorrienteAD();
            return iCtaCteAD.BuscarCuentaCorrienteXClave(pObj);
        }

        public static CuentaCorrienteEN EsCuentaCorrienteExistente(CuentaCorrienteEN pObj)
        {
            //objeto resultado
            CuentaCorrienteEN iCtaCte = new CuentaCorrienteEN();
            //validar si existe en b.d
            iCtaCte = CuentaCorrienteRN.BuscarCuentaCorrienteXClave(pObj);
            if (iCtaCte.ClaveCuentaCorriente == string.Empty)
            {
                iCtaCte.Adicionales.EsVerdad = false;
                iCtaCte.Adicionales.Mensaje = "La Cuenta Corriente " + pObj.ClaveCuentaCorriente + " no existe";
                return iCtaCte;
            }

            //ok
            iCtaCte.Adicionales.EsVerdad = true;
            return iCtaCte;
        }

        public static CuentaCorrienteEN EsCodigoCuentaCorrienteDisponible(CuentaCorrienteEN pObj)
        {
            //objeto resultado
            CuentaCorrienteEN iCtaCte = new CuentaCorrienteEN();

            //valida cuando esta vacio
            if (pObj.ClaveCuentaCorriente == string.Empty) { return iCtaCte; }

            //validar que los dos campos esten llenos
            iCtaCte = CuentaCorrienteRN.ValidaCuandoCodigoYaExiste(pObj);
            if (iCtaCte.Adicionales.EsVerdad == false) { return iCtaCte; }

            //ok           
            return iCtaCte;
        }

        public static CuentaCorrienteEN ValidaCuandoCodigoYaExiste(CuentaCorrienteEN pObj)
        {
            //objeto resultado
            CuentaCorrienteEN iCtaCte = new CuentaCorrienteEN();

            //validar     
            //iCtaCte = CuentaCorrienteRN.BuscarCuentaCorrienteXClave(pObj);
            if (iCtaCte.ClaveCuentaCorriente != string.Empty)
            {
                iCtaCte.Adicionales.EsVerdad = false;
                iCtaCte.Adicionales.Mensaje = "La Clave" + pObj.ClaveCuentaCorriente + " ya existe";
                return iCtaCte;
            }

            //ok
            iCtaCte.Adicionales.EsVerdad = true;
            return iCtaCte;
        }

        public static string ObtenerValorDeCampo(CuentaCorrienteEN pObj, string pNombreCampo)
        {
            //valor resultado
            string iValor = string.Empty;

            //segun nombre campo
            switch (pNombreCampo)
            {
                case CuentaCorrienteEN.ClaObj: return pObj.ClaveObjeto;
                case CuentaCorrienteEN.ClaCtaCte: return pObj.ClaveCuentaCorriente;
                case CuentaCorrienteEN.ClaDocCtaCte: return pObj.ClaveDocumentoCuentaCorriente;
                case CuentaCorrienteEN.CodEmp: return pObj.CodigoEmpresa;               
                case CuentaCorrienteEN.NEstCtaCte: return pObj.NEstadoCuentaCorriente;
                case CuentaCorrienteEN.UsuAgr: return pObj.UsuarioAgrega;
                case CuentaCorrienteEN.FecAgr: return pObj.FechaAgrega.ToString();
                case CuentaCorrienteEN.UsuMod: return pObj.UsuarioModifica;
                case CuentaCorrienteEN.FecMod: return pObj.FechaModifica.ToString();
            }

            //retorna
            return iValor;
        }

        public static List<CuentaCorrienteEN> FiltrarCuentaCorrienteXTextoEnCualquierPosicion(List<CuentaCorrienteEN> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<CuentaCorrienteEN> iLisRes = new List<CuentaCorrienteEN>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (CuentaCorrienteEN xPer in pLista)
            {
                string iTexto = CuentaCorrienteRN.ObtenerValorDeCampo(xPer, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xPer);
                }
            }

            //devolver
            return iLisRes;
        }

        public static List<CuentaCorrienteEN> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<CuentaCorrienteEN> pListaCuentaCorriente)
        {
            //lista resultado
            List<CuentaCorrienteEN> iLisRes = new List<CuentaCorrienteEN>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pListaCuentaCorriente; }

            //filtar la lista
            iLisRes = CuentaCorrienteRN.FiltrarCuentaCorrienteXTextoEnCualquierPosicion(pListaCuentaCorriente, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }

        public static string ObtenerClaveCuentaCorriente(CuentaCorrienteEN pPer)
        {
            //valor resultado
            string iClave = string.Empty;

            //armar clave
            iClave += Universal.gCodigoEmpresa + "-";
            iClave += pPer.PeriodoRegContabCabe + "-";
            iClave += pPer.COrigen + "-";
            iClave += pPer.CFile + "-";
            iClave += pPer.NumeroVoucherRegContabCabe;

            
            //retornar
            return iClave;
        }

        public static string ObtenerClaveDocumentoCuentaCorriente(CuentaCorrienteEN pPer)
        {
            //valor resultado
            string iClaveDoc = string.Empty;

            //armar clave
            iClaveDoc += Universal.gCodigoEmpresa + "-";
            iClaveDoc += pPer.CodigoAuxiliar + "-";
            iClaveDoc += pPer.CTipoDocumento + "-";
            iClaveDoc += pPer.SerieDocumento + "-";
            iClaveDoc += pPer.NumeroDocumento;


            //retornar
            return iClaveDoc;
        }

        public static CuentaCorrienteEN EsCuentaCorrienteValido(CuentaCorrienteEN pObj)
        {
            //objeto resultado
            CuentaCorrienteEN iCtaCte = new CuentaCorrienteEN();

            //valida cuando el codigo esta vacio
            if (pObj.ClaveCuentaCorriente == string.Empty) { return iCtaCte; }

            //valida cuando el codigo no existe
            iCtaCte = CuentaCorrienteRN.EsCuentaCorrienteExistente(pObj);
            if (iCtaCte.Adicionales.EsVerdad == false) { return iCtaCte; }
            
            //ok           
            return iCtaCte;
        }

        public static CuentaCorrienteEN EsActoModificarCuentaCorriente(CuentaCorrienteEN pObj)
        {
            //objeto resultado
            CuentaCorrienteEN iCtaCte = new CuentaCorrienteEN();

            //validar si existe
            //iCtaCte = CuentaCorrienteRN.EsCuentaCorrienteExistente(pObj);
            if (iCtaCte.Adicionales.EsVerdad == false) { return iCtaCte; }

            //ok            
            return iCtaCte;
        }

        public static CuentaCorrienteEN EsActoEliminarCuentaCorriente(CuentaCorrienteEN pObj)
        {
            //objeto resultado
            CuentaCorrienteEN iCtaCte = new CuentaCorrienteEN();

            //validar si existe
            iCtaCte = CuentaCorrienteRN.EsCuentaCorrienteExistente(pObj);
            if (iCtaCte.Adicionales.EsVerdad == false) { return iCtaCte; }

            //valida si existe este CentroCosto en MovimientoDeta
            CuentaCorrienteEN iCtaCteExiEN = CuentaCorrienteRN.ValidaCuandoCodigoCuentaCorrienteEstaEnMovimientoDeta(iCtaCte);
            if (iCtaCteExiEN.Adicionales.EsVerdad == false) { return iCtaCteExiEN; }

            //ok            
            return iCtaCte;
        }

        public static CuentaCorrienteEN ValidaCuandoCodigoCuentaCorrienteEstaEnMovimientoDeta(CuentaCorrienteEN pObj)
        {
            //objeto resultado
            CuentaCorrienteEN iCenCosEN = new CuentaCorrienteEN();

            ////valida
            //bool iExisten = MovimientoDetaRN.ExisteValorEnColumnaConEmpresa(MovimientoDetaEN.CodCenCos, pObj.CodigoCentroCosto);
            //if (iExisten == true)
            //{
            //    iCenCosEN.Adicionales.EsVerdad = false;
            //    iCenCosEN.Adicionales.Mensaje = "Este centro de costo tiene movimientos de Ingreso y/o Egresos, no se puede realizar la operacion";
            //    return iCenCosEN;
            //}

            //ok
            return iCenCosEN;
        }

        public static bool ExisteValorEnColumnaSinEmpresa(string pColumnaBusqueda, string pValorBusqueda)
        {
            CuentaCorrienteAD iPerAD = new CuentaCorrienteAD();
            return iPerAD.ExisteValorEnColumnaSinEmpresa(pColumnaBusqueda, pValorBusqueda);
        }

        public static bool ExisteValorEnColumnaConEmpresa(string pColumnaBusqueda, string pValorBusqueda)
        {
            CuentaCorrienteAD iPerAD = new CuentaCorrienteAD();
            return iPerAD.ExisteValorEnColumnaConEmpresa(pColumnaBusqueda, pValorBusqueda);
        }

        public static bool ExisteValorEnColumnaConEmpresa(string pColumnaBusqueda, string pValorBusqueda, string pColumnaCondicion1, string pValorCondicion1)
        {
            CuentaCorrienteAD iPerAD = new CuentaCorrienteAD();
            return iPerAD.ExisteValorEnColumnaConEmpresa(pColumnaBusqueda, pValorBusqueda, pColumnaCondicion1, pValorCondicion1);
        }

        public static CuentaCorrienteEN BuscarCuentaCorrienteXClaveDocumentoCuentaCorriente(CuentaCorrienteEN pObj)
        {
            //asignar parametro
            CuentaCorrienteAD iCenCosAD = new CuentaCorrienteAD();
            //iCenCosEN.ClaveCuentaCorriente = pob;
            //iCenCosEN.ClaveDocumentoCuentaCorriente = CuentaCorrienteRN.ObtenerClaveDocumentoCuentaCorriente(iCenCosEN);

            //ejecutar metodo
            return iCenCosAD.BuscarCuentaCorrienteXClaveDocumentoCuentaCorriente(pObj);
        }

        //public static CuentaCorrienteEN BuscarCuentaCorrienteProduccion()
        //{
        //    //objeto resultado
        //    CuentaCorrienteEN iCenCosEN = new CuentaCorrienteEN();

        //    //traer al objeto parametro
        //    ParametroEN iParEN = ParametroRN.BuscarParametro();

        //    //buscar a al centro costo produccion
        //    iCenCosEN = CuentaCorrienteRN.BuscarCuentaCorrienteXCodigo(iParEN.CentroCostoProduccion);

        //    //devolver
        //    return iCenCosEN;
        //}

        public static void EliminarCuentaCorrienteDeRegContabCabe(RegContabCabeEN pObj)
        {
            CuentaCorrienteAD iCtaCteAD = new CuentaCorrienteAD();
            iCtaCteAD.EliminarCuentaCorrienteDeRegContabCabe(pObj);
        }

        //public static CuentaCorrienteEN BuscarCuentaCorrienteXClave(CuentaCorrienteEN pObj)
        //{
        //    CuentaCorrienteAD iPerAD = new CuentaCorrienteAD();
        //    return iPerAD.BuscarCuentaCorrienteXClave(pObj);
        //}

    }
}
