using NOVEDADES_FA.CONTROLADORES;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExcelDataReader;
using NOVEDADES_FA.BD;
using System.Configuration;
using System.Data.SqlClient;


namespace NOVEDADES_FA.VISUAL.FORM
{
    public partial class BIGDATA : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                string filepatch = Server.MapPath("~/BD/" + filename);
                FileUpload1.SaveAs(filepatch);

                cargardatosdeexcel(filepatch, ".xlsx", "yes");
            }
        }

        public void cargardatosdeexcel(string fpath, string extension, string hdr)
        {
            string con = ConfigurationManager.ConnectionStrings["excelcon"].ConnectionString;
            con = string.Format(con, fpath, hdr);
            OleDbConnection excelcon = new OleDbConnection(con);
            excelcon.Open();
            DataTable exceldta = excelcon.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            string excelsheetname = exceldta.Rows[0]["TABLE_NAME"].ToString();
            OleDbCommand selectcomman = new OleDbCommand("Select * From [" + excelsheetname + "]", excelcon);
            OleDbDataAdapter da = new OleDbDataAdapter(selectcomman);
            DataTable dt = new DataTable();
            da.Fill(dt);
            excelcon.Close();

            GridView1.DataSource = dt;
            GridView1.DataBind();

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            //REGISTROS reg = new REGISTROS();
            //foreach (GridViewRow row in GridView1.Rows)
            //{
            //    string nombre = row.Cells[5].Text;
            //    Int64 cedula = Convert.ToInt64(row.Cells[0].Text);
            //    //int codigo = Convert.ToInt32(row.Cells[2].Text);
            //    //string barrio = row.Cells[1].Text;
            //    //string vereda = row.Cells[0].Text;
            //    //Int64 celular = Convert.ToInt64(row.Cells[3].Text);
            //    int codigo = Convert.ToInt32(row.Cells[0].Text);

            //    string RTA = reg.Registrar_BIGDATA(nombre, cedula, codigo);

            //    if (RTA == "SI")
            //    {
            //        string mss = "REGISTRO REALIZADO ";
            //        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mss + "');", true);
            //    }


            //}
        }

    }
}