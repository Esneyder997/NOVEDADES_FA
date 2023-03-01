using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using NOVEDADES_FA.BD;

namespace PROYECTOGRADO2023.CONTROLADORES
{
    public class MODIFICAR
    {
        conexBD cbd = new conexBD();

        public string MODIFICAR_usuario(string nombre_titular, Int64 cedula, string veredad, string barrio, Int64 telefono, int codigo, int id_titular)
        {
            string sql = "UPDATE NOVEDAD_PRINCIPAL SET nombre_titular = '" + nombre_titular + "', numero_documento = '" + cedula + "', barrio = '" + veredad + "', veredad = '" + barrio + "', codigo = '" + codigo + "', celular = '" + telefono + "' WHERE titualar_id = " + id_titular + "";
            string tb_usuario = cbd.CRUD(sql);
            return tb_usuario;
        }

        public string Actualizar_codigos(int codigo, Int64 cedula)
        {
            string sql = "UPDATE NOVEDAD_PRINCIPAL SET codigo = '" + codigo + "' WHERE numero_documento = " + cedula + "";
            string tb_usuario = cbd.CRUD(sql);
            return tb_usuario;
        }
    }
}