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
    public class TipoCambioRN
    {

        public static TipoCambioEN EnBlanco()
        {
            TipoCambioEN iPerEN = new TipoCambioEN();
            return iPerEN;
        }

        public static void AdicionarTipoCambio(TipoCambioEN pObj)
        {
            TipoCambioAD iPerAD = new TipoCambioAD();
            iPerAD.AgregarTipoCambio(pObj);
        }

        public static void ModificarTipoCambio(TipoCambioEN pObj)
        {
            TipoCambioAD iPerAD = new TipoCambioAD();
            iPerAD.ModificarTipoCambio(pObj);
        }

        public static void EliminarTipoCambio(TipoCambioEN pObj)
        {
            TipoCambioAD iPerAD = new TipoCambioAD();
            iPerAD.EliminarTipoCambio(pObj);
        }

        public static List<TipoCambioEN> ListarTipoCambios(TipoCambioEN pObj)
        {
            TipoCambioAD iPerAD = new TipoCambioAD();
            return iPerAD.ListarTipoCambios(pObj);
        }

        public static TipoCambioEN BuscarTipoCambioXFecha(TipoCambioEN pObj)
        {
            TipoCambioAD iPerAD = new TipoCambioAD();
            return iPerAD.BuscarTipoCambioXFecha(pObj);
        }

        public static TipoCambioEN EsTipoCambioExistente(TipoCambioEN pObj)
        {
            //objeto resultado
            TipoCambioEN iPerEN = new TipoCambioEN();

            //validar si existe en b.d
            iPerEN = TipoCambioRN.BuscarTipoCambioXFecha(pObj);
            if (iPerEN.FechaTipoCambio == string.Empty)
            {
                iPerEN.Adicionales.EsVerdad = false;
                iPerEN.Adicionales.Mensaje = "El Tipo de cambio de " + pObj.FechaTipoCambio  + " no existe";
                return iPerEN;
            }

            //ok
            iPerEN.Adicionales.EsVerdad = true;
            return iPerEN;
        }

        public static TipoCambioEN EsCodigoTipoCambioDisponible(TipoCambioEN pObj)
        {
            //objeto resultado
            TipoCambioEN iPerEN = new TipoCambioEN();
            
            //validar que los dos campos esten llenos
            iPerEN = TipoCambioRN.ValidaCuandoCodigoYaExiste(pObj);
            if (iPerEN.Adicionales.EsVerdad == false) { return iPerEN; }

            //ok           
            return iPerEN;
        }

        public static TipoCambioEN ValidaCuandoCodigoYaExiste(TipoCambioEN pObj)
        {
            //objeto resultado
            TipoCambioEN iPerEN = new TipoCambioEN();

            //validar     
            iPerEN = TipoCambioRN.BuscarTipoCambioXFecha(pObj);
            if (iPerEN.FechaTipoCambio != string.Empty)
            {
                iPerEN.Adicionales.EsVerdad = false;
                iPerEN.Adicionales.Mensaje = "El Tipo de cambio de " + pObj.FechaTipoCambio + " ya existe";
                return iPerEN;
            }

            //ok
            iPerEN.Adicionales.EsVerdad = true;
            return iPerEN;
        }

        public static string ObtenerValorDeCampo(TipoCambioEN pObj, string pNombreCampo)
        {
            //valor resultado
            string iValor = string.Empty;

            //segun nombre campo
            switch (pNombreCampo)
            {
                case TipoCambioEN.ClaObj: return pObj.ClaveObjeto;
                case TipoCambioEN.FecTipCam: return pObj.FechaTipoCambio;
                case TipoCambioEN.AñoTipCam: return pObj.AñoTipoCambio;
                case TipoCambioEN.CMesTipCam: return pObj.CMesTipoCambio;
                case TipoCambioEN.NMesTipCam: return pObj.NMesTipoCambio;
                case TipoCambioEN.PerTipCam: return pObj.PeriodoTipoCambio;
                case TipoCambioEN.ComUsTipCam: return pObj.CompraUsTipoCambio.ToString();
                case TipoCambioEN.VenUsTipCam: return pObj.VentaUsTipoCambio.ToString();
                case TipoCambioEN.ComCadTipCam: return pObj.CompraCadTipoCambio.ToString();
                case TipoCambioEN.VenCadTipCam: return pObj.VentaCadTipoCambio.ToString();
                case TipoCambioEN.ComEurTipCam: return pObj.CompraEurTipoCambio.ToString();
                case TipoCambioEN.VenEurTipCam: return pObj.VentaEurTipoCambio.ToString();
                case TipoCambioEN.CEstTipCam: return pObj.CEstadoTipoCambio;
                case TipoCambioEN.NEstTipCam: return pObj.NEstadoTipoCambio;
                case TipoCambioEN.UsuAgr: return pObj.UsuarioAgrega;
                case TipoCambioEN.FecAgr: return pObj.FechaAgrega.ToString();
                case TipoCambioEN.UsuMod: return pObj.UsuarioModifica;
                case TipoCambioEN.FecMod: return pObj.FechaModifica.ToString();
            }

            //retorna
            return iValor;
        }

        public static List<TipoCambioEN> FiltrarTipoCambiosXTextoEnCualquierPosicion(List<TipoCambioEN> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<TipoCambioEN> iLisRes = new List<TipoCambioEN>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (TipoCambioEN xPer in pLista)
            {
                string iTexto = TipoCambioRN.ObtenerValorDeCampo(xPer, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xPer);
                }
            }

            //devolver
            return iLisRes;
        }

        public static List<TipoCambioEN> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<TipoCambioEN> pListaTipoCambios)
        {
            //lista resultado
            List<TipoCambioEN> iLisRes = new List<TipoCambioEN>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pListaTipoCambios; }

            //filtar la lista
            iLisRes = TipoCambioRN.FiltrarTipoCambiosXTextoEnCualquierPosicion(pListaTipoCambios, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }

        public static TipoCambioEN EsActoModificarTipoCambio(TipoCambioEN pObj)
        {
            //objeto resultado
            TipoCambioEN iCenCosEN = new TipoCambioEN();

            //validar si existe
            iCenCosEN = TipoCambioRN.EsTipoCambioExistente(pObj);
            if (iCenCosEN.Adicionales.EsVerdad == false) { return iCenCosEN; }

            //ok            
            return iCenCosEN;
        }

        public static TipoCambioEN EsActoEliminarTipoCambio(TipoCambioEN pObj)
        {
            //objeto resultado
            TipoCambioEN iCenCosEN = new TipoCambioEN();

            //validar si existe
            iCenCosEN = TipoCambioRN.EsTipoCambioExistente(pObj);
            if (iCenCosEN.Adicionales.EsVerdad == false) { return iCenCosEN; }

            //ok            
            return iCenCosEN;
        }

        public static bool ExisteValorEnColumnaSinEmpresa(string pColumnaBusqueda, string pValorBusqueda)
        {
            TipoCambioAD iPerAD = new TipoCambioAD();
            return iPerAD.ExisteValorEnColumnaSinEmpresa(pColumnaBusqueda, pValorBusqueda);
        }

        public static decimal ObtenerVentaTipoCambio(TipoCambioEN pObj, string pCMoneda)
        {
            //valor resultado
            decimal iValor = 0;

            //segun moneda
            switch (pCMoneda)
            {
                case "0": { iValor = pObj.VentaUsTipoCambio;break; }
                case "1": { iValor = pObj.VentaUsTipoCambio; break; }
                case "2": { iValor = pObj.VentaCadTipoCambio; break; }
                case "3": { iValor = pObj.VentaEurTipoCambio; break; }
            }

            //devolver
            return iValor;
        }

    }
}
