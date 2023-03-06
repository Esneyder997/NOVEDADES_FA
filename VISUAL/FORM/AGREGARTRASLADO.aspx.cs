using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Win32;
using NOVEDADES_FA.CONTROLADORES;


namespace NOVEDADES_FA.VISUAL.FORM
{
    public partial class AGREGARTRASLADO : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            REGISTROS reg = new REGISTROS();

            string nombre = TextBox1.Text;
            Int64 cedula = Convert.ToInt64(TextBox2.Text);
            //int codigo = Convert.ToInt32(row.Cells[2].Text);
            string barrio = TextBox3.Text;
            string vereda = TextBox4.Text;
            Int64 celular = Convert.ToInt64(TextBox6.Text);
            int codigo = Convert.ToInt32(TextBox5.Text);

            string RTA = reg.Registrar_BIGDATA(nombre, cedula, codigo);

            if (RTA == "SI")
            {

                string mss = "SE GUARDO EXITOSAMENTE EL NUEVO BENEFICIARIO";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mss + "');", true);
                TextBox1.Text = "";
                TextBox2.Text = "";
                TextBox3.Text = "";
                TextBox4.Text = "";
                TextBox5.Text = "";
                TextBox6.Text = "";
                Page.Response.Redirect(Page.Request.Url.ToString(), true);
            }
        }
    }
}