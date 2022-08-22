using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comun;
using Entidades;
using Datos;
using System.IO;

namespace Negocio
{
    public class ParametroRN
    {

        public static void ModificarParametro(ParametroEN pObj)
        {
            ParametroAD iParAD = new ParametroAD();
            iParAD.ModificarParametro(pObj);
        }

        public static ParametroEN BuscarParametro()
        {
            ParametroAD iIteAD = new ParametroAD();
            return iIteAD.BuscarParametro();
        }

        public static void ModificarCampoParametro(string pCampo, string pValor)
        {
            //traer al objeto parametro
            ParametroEN iParEN = new ParametroEN();
            iParEN = ParametroRN.BuscarParametro();

            //modificar solo el campo que biene como parametro
            //desde la ventana
            switch (pCampo)
            {
                case ParametroEN.RutLogEmp: { iParEN.RutaLogoEmpresa = pValor; break; }
                case ParametroEN.PorIgv: { iParEN.PorcentajeIgv = Convert.ToDecimal(pValor); break; }
                case ParametroEN.NomSol: { iParEN.NombreSoles = pValor; break; }
                case ParametroEN.NomDol: { iParEN.NombreDolares = pValor; break; }
                case ParametroEN.TipOpeTraIng: { iParEN.TipoOperacionTransferenciaIngreso = pValor; break; }
                case ParametroEN.TipOpeTraSal: { iParEN.TipoOperacionTransferenciaSalida = pValor; break; }
                case ParametroEN.TipOpeProSal: { iParEN.TipoOperacionProduccionSalida = pValor; break; }
                case ParametroEN.TipOpeProIng: { iParEN.TipoOperacionProduccionIngreso = pValor; break; }
                case ParametroEN.CenCosPro: { iParEN.CentroCostoProduccion = pValor; break; }
            }

            //modificar su valor
            ParametroRN.ModificarParametro(iParEN);
        }

    }
}
