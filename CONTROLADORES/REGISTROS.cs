using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using NOVEDADES_FA.BD;



namespace NOVEDADES_FA.CONTROLADORES
{
    public class REGISTROS : conexBD
    {
        conexBD cbd = new conexBD();

        private string cedula;
        private string cedulanna;

        public REGISTROS()
        {
            cedula = string.Empty;
            this.sql = string.Empty;

            cedulanna = string.Empty;
            this.sql = string.Empty;
        }
        public string Cedula
        {
            get { return this.cedula; }
            set { this.cedula = value; }

        }
        public string CedulaNna
        {
            get { return this.cedulanna; }
            set { this.cedulanna = value; }

        }


        public DataTable FILTROS()
        {
            string sql = string.Format(@"SELECT ph.nombre_titular, ph.numero_documento, ph.barrio, ph.codigo, ph.veredad, ph.celular, ph.titualar_id  FROM NOVEDAD_PRINCIPAL AS ph INNER JOIN NOVEDAD_PRINCIPAL AS p ON ph.titualar_id = p.titualar_id  WHERE ph.numero_documento LIKE '{0}%'", this.cedula, " ORDER by ph.nombre_titular, ph.numero_documento, ph.codigo, ph.barrio, ph.veredad, ph.celular");
            DataTable tabla1 = cbd.Consultas(sql);
            return tabla1;
        }

        public DataTable FILTROSnna()
        {
            string sql = string.Format(@"SELECT ph.nombre_titular, ph.titualar_id FROM NOVEDAD_PRINCIPAL AS ph INNER JOIN NOVEDAD_PRINCIPAL AS p ON ph.titualar_id = p.titualar_id WHERE ph.numero_documento LIKE '{0}%'", this.cedulanna, "ORDER by ph.nombre_titular");
            DataTable tabla1 = cbd.Consultas(sql);
            return tabla1;
        }

        public string Registrar_BIGDATA(string nombre_titular, Int64 cedula, string veredad, string barrio, Int64 telefono, int codigo)
        {
            string sql = string.Format(@"INSERT INTO NOVEDAD_PRINCIPAL (nombre_titular,numero_documento,barrio,veredad,celular,codigo) values ('" + nombre_titular + "','" + cedula + "','" + barrio + "','" + veredad + "','" + telefono + "','" + codigo + "')");
            string tabla1 = cbd.CRUD(sql);
            return tabla1;
        }
    }
}