using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Datos.Config
{
    public class SqlDatos
    {

        SqlConnection cn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();


        public enum Bd
        {
            Alfisa_Contabilidad = 0,
            Presupuesto_Glass
        }


        public void Conectar(SqlDatos.Bd pBaseDatos)
        {
            StringBuilder xCadenaConexion = new System.Text.StringBuilder();
            switch (pBaseDatos)
            {
                case SqlDatos.Bd.Alfisa_Contabilidad:
                    {
                        //xCadenaConexion.Append(" Data Source=LAPTOP-5JT8A13O;");
                        //xCadenaConexion.Append(" Data Source=LAPTOP-0ANI50G4\\SQL2016;");
                        //xCadenaConexion.Append(" Data Source=Lenovo-Pc\\Sql2016;");
                        xCadenaConexion.Append(" Data Source=DESKTOP-VQ0I0E0\\SQLEXPRESS;");
                        //xCadenaConexion.Append(" Data Source=ARES\\MENORCA1;");
                        xCadenaConexion.Append(" Initial Catalog=" + SqlDatos.Bd.Alfisa_Contabilidad.ToString() + ";");
                        xCadenaConexion.Append(" User Id=sa;");
                        xCadenaConexion.Append(" Password=.;");
                        //xCadenaConexion.Append(" Password=Menorca01;");
                        this.cn.ConnectionString = xCadenaConexion.ToString();
                        break;
                    }

            }
            //abrir conexion
            this.cn.Open();

        }

        public void ComandoProcedimientoAlmacenado(string pPa)
        {
            this.cmd.Connection = this.cn;
            this.cmd.CommandType = System.Data.CommandType.StoredProcedure;
            this.cmd.CommandText = pPa;
        }

        public void ComandoTexto(string pTexto)
        {
            this.cmd.Connection = this.cn;
            this.cmd.CommandType = System.Data.CommandType.Text;
            this.cmd.CommandText = pTexto;
        }

        public void AsignarParametro(SqlParameter pPar, object pValor)
        {
            pPar.Value = pValor;
            this.cmd.Parameters.Add(pPar);
        }

        public DataTable ObtenerTablaRegistro()
        {
            DataTable xDt = new DataTable();
            xDt.Load(this.cmd.ExecuteReader());
            return xDt;
        }

        public void EjecutarSinResultado()
        {
            this.cmd.ExecuteNonQuery();
        }

        public IDataReader ObtenerIdr()
        {
            IDataReader xDr;
            xDr = this.cmd.ExecuteReader();
            return xDr;
        }

        public string ObtenerValor()
        {
            string xValor;
            if (this.cmd.ExecuteScalar() == null)
            {
                xValor = string.Empty;
            }
            else
            {
                xValor = this.cmd.ExecuteScalar().ToString();
            }
            return xValor;
        }

        public void Desconectar()
        {
            this.cn.Dispose();
            this.cn.Close();
            this.cmd.Dispose();
        }


    }
}
