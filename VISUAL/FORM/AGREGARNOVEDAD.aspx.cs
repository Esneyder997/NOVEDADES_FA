using NOVEDADES_FA.CONTROLADORES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Odbc;
using System.Runtime.Remoting.Contexts;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data.SqlClient;
using PROYECTOGRADO2023.CONTROLADORES;

namespace NOVEDADES_FA.VISUAL.FORM
{
    public partial class AGREGARNOVEDAD : System.Web.UI.Page
    {
        private static DataTable dtBUSCA = new DataTable();


        private static DataTable dt = new DataTable();
        private DataSet ds = new DataSet();

        private static DataTable dtt = new DataTable();
        private DataSet dss = new DataSet();


        MODIFICAR control = new MODIFICAR();
        REGISTROS consult = new REGISTROS();




        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable tpN = new DataTable();
                tpN = consult.cargarNOVEDADES();
               
                DropDownList1.AppendDataBoundItems = true;
                DropDownList1.Items.Insert(0, new ListItem("SELECCIONE UNA OPCION", "0"));
                DropDownList1.DataValueField = "id";
                DropDownList1.DataTextField = "nombre_novedad";
                DropDownList1.DataSource = tpN;
                DropDownList1.DataBind();
            }
        }

        public void nombreglobal()
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {

            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook sheet = excel.Workbooks.Open("Z:\\FAMILIAS EN ACCION SISTEMA\\FORMATO_NOVEDAD_NO_BORRAR\\NOVEDADES_FA.xlsx");
            Microsoft.Office.Interop.Excel.Worksheet x = excel.ActiveSheet as Microsoft.Office.Interop.Excel.Worksheet;


            CheckBox checka;
            CheckBox checkanna;
            string nombre = "";
            Int64 numero_documento = 0;
            string barrio = "";
            string vereda = "";
            int codigo = 0;
            Int64 telefono = 0;
            string nombrenna = "";

           


            if (DropDownList1.SelectedItem.Text == "SELECCIONE UNA OPCION")
            {
                string mss = "SELECCIONE TIPO DE NOVEDAD";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mss + "');", true);
            }
            else
            {
                foreach (GridViewRow grid in GridView1.Rows)
                {

                    if (grid.RowType == DataControlRowType.DataRow)
                    {

                        checka = (CheckBox)grid.FindControl("CheckBox2");

                        if (checka.Checked)
                        {

                            nombre = ((Label)(grid.Cells[2].Controls[1])).Text;
                            numero_documento = Convert.ToInt64(((Label)(grid.Cells[3].Controls[1])).Text);
                            barrio = ((Label)(grid.Cells[4].Controls[1])).Text;
                            vereda = ((Label)(grid.Cells[5].Controls[1])).Text;
                            codigo = Convert.ToInt32(((Label)(grid.Cells[6].Controls[1])).Text);
                            telefono = Convert.ToInt64(((Label)(grid.Cells[7].Controls[1])).Text);

                            Excel.Range userRange = x.UsedRange;
                            int counrecords = userRange.Rows.Count;
                            int add = counrecords + 1;

                            x.Cells[6, 4] = nombre;
                            x.Cells[39, 4] = nombre;
                            x.Cells[7, 7] = numero_documento;
                            x.Cells[40, 7] = numero_documento;

                            if (vereda == "SIN VEREDA")
                            {

                                x.Cells[9, 2] = barrio;
                                x.Cells[42, 2] = barrio;
                                x.Cells[42, 1] = "BARRIO:";

                            }
                            else
                            {

                                x.Cells[9, 2] = vereda;
                                x.Cells[42, 2] = vereda;
                                x.Cells[42, 1] = "VEREDA:";

                            }

                            if (codigo == 0)
                            {

                                string mss = "Te falto actualizar el codigo";
                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mss + "');", true);

                            }
                            else
                            {

                                x.Cells[40, 9] = codigo;
                                x.Cells[7, 9] = codigo;

                                x.Cells[9, 7] = telefono;
                                x.Cells[42, 7] = telefono;

                                DateTime hoy = DateTime.Now;
                                string fecha_hoy = hoy.ToString("dd/MM/yyyy");
                                x.Cells[8, 10] = fecha_hoy;
                                x.Cells[41, 10] = fecha_hoy;

                                if (DropDownList1.SelectedItem.Text == "CAMBIO DE TITULAR")
                                {

                                    Microsoft.Office.Interop.Excel.Application excelcambiotitular = new Microsoft.Office.Interop.Excel.Application();
                                    Microsoft.Office.Interop.Excel.Workbook sheetcambiotitular = excelcambiotitular.Workbooks.Open("Z:\\FAMILIAS EN ACCION SISTEMA\\OFICIOS\\cambio de titular.xlsx");
                                    Microsoft.Office.Interop.Excel.Worksheet xcambiotitular = excelcambiotitular.ActiveSheet as Microsoft.Office.Interop.Excel.Worksheet;

                                    x.Cells[13, 6] = "CAMBIO DE TITULAR POR SOLICITUD DEL TITULAR " + nombre;
                                    x.Cells[44, 1] = "CAMBIO DE TITULAR ";
                                    sheetcambiotitular.SaveAs("Z:\\FAMILIAS EN ACCION SISTEMA\\OFICIOS GENERADS\\"+ numero_documento + "");
                                    sheetcambiotitular.Close(true, Type.Missing, Type.Missing);
                                    excelcambiotitular.Quit();

                                }
                                else if (DropDownList1.SelectedItem.Text == "CAMBIO DE GRUPO PROBLACIONAL")
                                {

                                    Microsoft.Office.Interop.Excel.Application excelcambiogrupos = new Microsoft.Office.Interop.Excel.Application();
                                    Microsoft.Office.Interop.Excel.Workbook sheetcambiogrupoblacional = excelcambiogrupos.Workbooks.Open("Z:\\FAMILIAS EN ACCION SISTEMA\\OFICIOS\\cambiogrupopoblacional.xlsx");
                                    Microsoft.Office.Interop.Excel.Worksheet xcambiogrupos = excelcambiogrupos.ActiveSheet as Microsoft.Office.Interop.Excel.Worksheet;

                                    x.Cells[14, 6] = "CAMBIO DE GRUPO POBLACIONAL POR SOLICITUD DEL TITULAR " + nombre;
                                    x.Cells[44, 1] = "CAMBIO DE GRUPO POBLACIONAL";

                                    sheetcambiogrupoblacional.SaveAs("Z:\\FAMILIAS EN ACCION SISTEMA\\OFICIOS GENERADS\\cambio_grupo_poblacional");
                                    sheetcambiogrupoblacional.Close(true, Type.Missing, Type.Missing);
                                    excelcambiogrupos.Quit();
                                }
                                else if (DropDownList1.SelectedItem.Text == "TRASLADO DE MUNICIPIO")
                                {
                                    Microsoft.Office.Interop.Excel.Application exceltraslados = new Microsoft.Office.Interop.Excel.Application();
                                    Microsoft.Office.Interop.Excel.Workbook sheettraslados = exceltraslados.Workbooks.Open("Z:\\FAMILIAS EN ACCION SISTEMA\\OFICIOS\\traslado.xlsx");
                                    Microsoft.Office.Interop.Excel.Worksheet xtraslados = exceltraslados.ActiveSheet as Microsoft.Office.Interop.Excel.Worksheet;

                                    Excel.Range userRangetraslados = xtraslados.UsedRange;
                                    int counrecordstraslados = userRangetraslados.Rows.Count;
                                    int addtraslados = counrecordstraslados + 1;


                                    x.Cells[15, 6] = "TRASLADO DE MUNICIPIO DE (" + TextBox9.Text + ") A BELEN DE LOS ANDAQUIES POR SOLICITUD DEL TITULAR";
                                    x.Cells[44, 1] = "TRASLADO DE MUNICIPIO";

                                    xtraslados.Cells[6, 6] = fecha_hoy;
                                    xtraslados.Cells[15, 3] = "TRASLADO DE MUNICIPIO POR SOLICITUD DEL TITULAR";
                                    xtraslados.Cells[21, 4] = nombre;
                                    xtraslados.Cells[22, 4] = numero_documento;
                                    xtraslados.Cells[23, 4] = codigo;
                                    xtraslados.Cells[24, 4] = TextBox9.Text;
                                    xtraslados.Cells[27, 3] = TextBox12.Text;
                                    xtraslados.Cells[27, 7] = telefono;
                                    xtraslados.Cells[38, 3] = numero_documento;
                                    xtraslados.Cells[39, 3] = telefono;

                                    if (vereda == "SIN VEREDA")
                                    {

                                        xtraslados.Cells[27, 5] = barrio;

                                    }
                                    else
                                    {

                                        xtraslados.Cells[27, 5] = vereda;

                                    }

                                    sheettraslados.SaveAs("Z:\\FAMILIAS EN ACCION SISTEMA\\OFICIOS GENERADS\\" + numero_documento + "");
                                    sheettraslados.Close(true, Type.Missing, Type.Missing);
                                    exceltraslados.Quit();
                                }

                                if (DropDownList1.SelectedItem.Text == "CAMBIO EN DATOS PERSONALES" || DropDownList1.SelectedItem.Text == "RETIRO_DE_BENEFICIARIO")
                                {
                                    foreach (GridViewRow gridnna in GridView2.Rows)
                                    {
                                        if (gridnna.RowType == DataControlRowType.DataRow)
                                        {
                                            checkanna = (CheckBox)gridnna.FindControl("CheckBox4");
                                            if (checkanna.Checked)
                                            {
                                                nombrenna = ((Label)(gridnna.Cells[1].Controls[1])).Text;
                                                if (DropDownList2.SelectedItem.Text == "CAMBIO_FECHA_DE_NACIMIENTO")
                                                {
                                                    x.Cells[17, 5] = "x";
                                                    x.Cells[17, 6] = "CAMBIO FECHA DE NACIMIENTO POR SOLICITUD DEL TITULAR:" + nombrenna;
                                                    x.Cells[44, 1] = "CAMBIO FECHA DE NACIMIENTO" + nombrenna;
                                                    x.Cells[44, 7] = nombrenna;

                                                }
                                                else if (DropDownList2.SelectedItem.Text == "CAMBIO_DOCUMENTO")
                                                {
                                                    x.Cells[17, 5] = "x";
                                                    x.Cells[17, 6] = "CAMBIO DE DOCUMENTO DE IDENTIDAD POR SOLICITUD DEL TITULAR:" + nombrenna;
                                                    x.Cells[44, 1] = "CAMBIO DOCUMENTO DE IDENTIDAD";
                                                    x.Cells[44, 7] = nombrenna;

                                                }
                                                else if (DropDownList2.SelectedItem.Text == "CAMBIO_DE_APELLIDOS")
                                                {
                                                    x.Cells[17, 5] = "x";
                                                    x.Cells[17, 6] = "CAMBIO DE APELLIDOS POR SOLICITUD DEL TITULAR:" + nombrenna;
                                                    x.Cells[44, 1] = "CAMBIO DE APELLIDOS";
                                                    x.Cells[44, 7] = nombrenna;

                                                }

                                                if (DropDownList1.SelectedItem.Text == "RETIRO DE BENEFICIARIO")
                                                {
                                                    Microsoft.Office.Interop.Excel.Application excelretiros = new Microsoft.Office.Interop.Excel.Application();
                                                    Microsoft.Office.Interop.Excel.Workbook sheetretiros = excelretiros.Workbooks.Open("Z:\\FAMILIAS EN ACCION SISTEMA\\OFICIOS\\retiros.xlsx");
                                                    Microsoft.Office.Interop.Excel.Worksheet xretiros = excelretiros.ActiveSheet as Microsoft.Office.Interop.Excel.Worksheet;

                                                    x.Cells[19, 5] = "X";
                                                    x.Cells[19, 6] = "RETIRO DE BENEFICIARIO POR SOLICITUD DEL TITULAR:" + nombrenna;
                                                    x.Cells[44, 1] = "RETIRO DE BENEFICIARIO";
                                                    x.Cells[44, 7] = nombrenna;

                                                    xretiros.Cells[6, 6] = fecha_hoy;
                                                    xretiros.Cells[21, 4] = nombre;
                                                    xretiros.Cells[22, 4] = numero_documento;
                                                    xretiros.Cells[23, 4] = codigo;
                                                    xretiros.Cells[38, 3] = numero_documento;
                                                    xretiros.Cells[39, 3] = telefono;
                                                    xretiros.Cells[24, 4] = nombrenna;

                                                    sheetretiros.SaveAs("Z:\\FAMILIAS EN ACCION SISTEMA\\OFICIOS GENERADS\\" + numero_documento + "");
                                                    sheetretiros.Close(true, Type.Missing, Type.Missing);
                                                    excelretiros.Quit();

                                                }
                                            }
                                        }
                                    }
                                }

                                if (DropDownList1.SelectedItem.Text == "RETIRO DE FAMILIA")
                                {

                                    Microsoft.Office.Interop.Excel.Application excelretirosnucleo = new Microsoft.Office.Interop.Excel.Application();
                                    Microsoft.Office.Interop.Excel.Workbook sheetretirosnucleo = excelretirosnucleo.Workbooks.Open("Z:\\FAMILIAS EN ACCION SISTEMA\\OFICIOS\\retiros nucleo.xlsx");
                                    Microsoft.Office.Interop.Excel.Worksheet xretirosnucleo = excelretirosnucleo.ActiveSheet as Microsoft.Office.Interop.Excel.Worksheet;

                                    x.Cells[20, 5] = "X";
                                    x.Cells[20, 6] = "RETIRO NUCLEO DE FAMILIA POR SOLICITUD DEL TITULAR:" + nombre;
                                    x.Cells[44, 1] = "RETIRO DE FAMILIA";
                                    x.Cells[44, 7] = nombre;

                                    xretirosnucleo.Cells[6, 6] = fecha_hoy;
                                    xretirosnucleo.Cells[21, 4] = nombre;
                                    xretirosnucleo.Cells[22, 4] = numero_documento;
                                    xretirosnucleo.Cells[23, 4] = codigo;
                                    xretirosnucleo.Cells[38, 3] = numero_documento;
                                    xretirosnucleo.Cells[39, 3] = telefono;

                                    sheetretirosnucleo.SaveAs("Z:\\FAMILIAS EN ACCION SISTEMA\\OFICIOS GENERADS\\" + numero_documento + "");
                                    sheetretirosnucleo.Close(true, Type.Missing, Type.Missing);
                                    excelretirosnucleo.Quit();
                                }

                                sheet.SaveAs("Z:\\FAMILIAS EN ACCION SISTEMA\\NOVEDADES\\" + numero_documento + "");
                                sheet.Close(true, Type.Missing, Type.Missing);

                                excel.Quit();
                            }
                        }
                    }
                }
            }
        }
        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            consult.Cedula = this.TextBox1.Text;
            DataTable tabla1 = consult.FILTROS();

            if (tabla1.Rows.Count > 0)
            {
                cargarFILTRO();
            }
        }
        public void cargarFILTRO()
        {
            dt = consult.FILTROS();
            ds.Tables.Add(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }


        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            DataTable ds = (DataTable)Session["NOVEDAD_PRINCIPAL"];
            GridViewRow row = GridView1.Rows[e.RowIndex];

            string nombre = ((TextBox)(row.Cells[2].Controls[1])).Text;
            int numero_doc = Convert.ToInt32(((TextBox)(row.Cells[3].Controls[1])).Text);
            string barrio = ((TextBox)(row.Cells[4].Controls[1])).Text;
            string veredad = ((TextBox)(row.Cells[5].Controls[1])).Text;
            int codigo = Convert.ToInt32(((TextBox)(row.Cells[6].Controls[1])).Text);
            Int64 celular = Convert.ToInt64(((TextBox)(row.Cells[7].Controls[1])).Text);
            int id_codigo = Convert.ToInt32(((TextBox)(row.Cells[8].Controls[1])).Text);

            string RTA = control.MODIFICAR_usuariogrid(nombre, numero_doc, barrio, veredad, celular, codigo, id_codigo);
            if (RTA == "SI")
            {

                GridView1.EditIndex = -1;
                DataBind();

                consult.Cedula = this.TextBox1.Text;
                DataTable tabla1 = consult.FILTROS();
                if (tabla1.Rows.Count > 0)
                {

                    cargarFILTRO();

                }
            }
        }
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            DataBind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            DataBind();
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
        }

        protected void Button2_Click1(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Application exceltraslados = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Application excelcambiotitular = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Application excelcambiogrupos = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Application excelretiros = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Application excelretirosnucleo = new Microsoft.Office.Interop.Excel.Application();

            CheckBox checka;

            foreach (GridViewRow grid in GridView1.Rows)
            {

                if (grid.RowType == DataControlRowType.DataRow)
                {

                    checka = (CheckBox)grid.FindControl("CheckBox2");

                    if (checka.Checked)
                    {
                        Int64 numero_documento = Convert.ToInt64(((Label)(grid.Cells[3].Controls[1])).Text);
                        Microsoft.Office.Interop.Excel.Workbook sheet = excel.Workbooks.Open("Z:\\FAMILIAS EN ACCION SISTEMA\\NOVEDADES\\" + numero_documento + ".xlsx");
                        Microsoft.Office.Interop.Excel.Worksheet x = excel.ActiveSheet as Microsoft.Office.Interop.Excel.Worksheet;

                        if (DropDownList1.SelectedItem.Text == "CAMBIO DE GRUPO POBLACIONAL")
                        {
                            Microsoft.Office.Interop.Excel.Workbook sheetcambiogrupoblacional = excelcambiogrupos.Workbooks.Open("Z:\\FAMILIAS EN ACCION SISTEMA\\OFICIOS GENERADS\\cambio_grupo_poblacional.xlsx");
                            Microsoft.Office.Interop.Excel.Worksheet xcambiogrupo = excelcambiogrupos.ActiveSheet as Microsoft.Office.Interop.Excel.Worksheet;
                            xcambiogrupo.PrintOut(1, true);
                            excelcambiogrupos.Quit();
                            Page.Response.Redirect(Page.Request.Url.ToString(), true);
                            //xcambiogrupo.PrintPreview();
                            cerrarSEGUNDOPLANO();
                        }
                        else if (DropDownList1.SelectedItem.Text == "CAMBIO DE TITULAR")
                        {
                            Microsoft.Office.Interop.Excel.Workbook sheettitular = excelcambiotitular.Workbooks.Open("Z:\\FAMILIAS EN ACCION SISTEMA\\OFICIOS GENERADS\\" + numero_documento + ".xlsx");
                            Microsoft.Office.Interop.Excel.Worksheet xcambiotitular = excelcambiotitular.ActiveSheet as Microsoft.Office.Interop.Excel.Worksheet;
                            xcambiotitular.PrintOut(1, true);
                            excelcambiotitular.Quit();
                            cerrarSEGUNDOPLANO();
                            Page.Response.Redirect(Page.Request.Url.ToString(), true);
                            //xcambiotitular.PrintPreview();
                            
                        }
                        else if (DropDownList1.SelectedItem.Text == "RETIRO DE BENEFICIARIO")
                        {
                            Microsoft.Office.Interop.Excel.Workbook sheetretiros = excelretiros.Workbooks.Open("Z:\\FAMILIAS EN ACCION SISTEMA\\OFICIOS GENERADS\\" + numero_documento + ".xlsx");
                            Microsoft.Office.Interop.Excel.Worksheet xcambioretiros = excelretiros.ActiveSheet as Microsoft.Office.Interop.Excel.Worksheet;
                            xcambioretiros.PrintOut(1, true);
                            x.PrintOut(1, true);


                            //x.PrintPreview();
                            excel.Quit();
                            excelretiros.Quit();
                            cerrarSEGUNDOPLANO();
                            Page.Response.Redirect(Page.Request.Url.ToString(), true);
                            

                        }
                        else if (DropDownList1.SelectedItem.Text == "RETIRO DE FAMILIA")
                        {

                            Microsoft.Office.Interop.Excel.Workbook sheetretirosnucleo = excelretirosnucleo.Workbooks.Open("Z:\\FAMILIAS EN ACCION SISTEMA\\OFICIOS GENERADS\\" + numero_documento + ".xlsx");
                            Microsoft.Office.Interop.Excel.Worksheet xcambioretirosnucleo = excelretirosnucleo.ActiveSheet as Microsoft.Office.Interop.Excel.Worksheet;
                            xcambioretirosnucleo.PrintOut(1, true);
                            excelretirosnucleo.Quit(); x.PrintOut(1, true);
                            cerrarSEGUNDOPLANO();
                            Page.Response.Redirect(Page.Request.Url.ToString(), true);


                            //xcambioretirosnucleo.PrintPreview();
                            
                        }
                        else if (DropDownList1.SelectedItem.Text == "TRASLADO DE MUNICIPIO")
                        {

                            Microsoft.Office.Interop.Excel.Workbook sheettraslados = exceltraslados.Workbooks.Open("Z:\\FAMILIAS EN ACCION SISTEMA\\OFICIOS GENERADS\\" + numero_documento + ".xlsx");
                            Microsoft.Office.Interop.Excel.Worksheet xtraslados = exceltraslados.ActiveSheet as Microsoft.Office.Interop.Excel.Worksheet;
                            xtraslados.PrintOut(1, true);
                            x.PrintOut(1, true);
                            exceltraslados.Quit();
                            cerrarSEGUNDOPLANO();
                            Page.Response.Redirect(Page.Request.Url.ToString(), true);
                            
                        }

                        x.PrintOut(1, true);

                        Page.Response.Redirect(Page.Request.Url.ToString(), true);
                        //x.PrintPreview();
                        cerrarSEGUNDOPLANO();

                    }
                }
            }
        }

        public void cerrarSEGUNDOPLANO()
        {
            //Process[]
            //processes = Process.GetProcessesByName("EXCEL.EXE");

            //// Cerrar el proceso
            //foreach (Process process in processes)
            //{
            //    process.Kill();
            //}

            // Buscar todos los procesos de Excel que estén en ejecución
            Process[] processes = Process.GetProcessesByName("EXCEL.EXE");

               // Cerrar los procesos de Excel
               foreach (Process process in processes)
               {
                  try 
                  {
                    process.CloseMainWindow();
                    process.WaitForExit();
                    process.Dispose();
                  }
                  catch (Exception ex) 
                  {
                    // Manejar cualquier excepción que pueda ocurrir
                    Console.WriteLine(ex.Message);
                  }
               }
        }

        protected void TextBox10_TextChanged(object sender, EventArgs e)
        {
            consult.CedulaNna = this.TextBox10.Text;
            DataTable tabla1 = consult.FILTROSnna();

            if (tabla1.Rows.Count > 0)
            {
                cargarFILTROnna();
            }
        }
        public void cargarFILTROnna()
        {
            dtt = consult.FILTROSnna();
            dss.Tables.Add(dtt);
            GridView2.DataSource = dtt;
            GridView2.DataBind();
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedItem.Text == "CAMBIO EN DATOS PERSONALES")

            {

                Label11.Visible = true;
                TextBox10.Visible = true;
                Label10.Visible = true;
                DropDownList2.Visible = true;
                GridView2.Visible = true;
                Label9.Visible = false;
                TextBox9.Visible = false;
                Label14.Visible = false;
                TextBox12.Visible = false;

            }
            else if (DropDownList1.SelectedItem.Text == "TRASLADO DE MUNICIPIO")
            {
                Label9.Visible = true;
                Label14.Visible = true;
                TextBox9.Visible = true;
                TextBox12.Visible = true;
                Label11.Visible = false;
                TextBox10.Visible = false;

                Label10.Visible = false;
                DropDownList2.Visible = false;
            }
            else if (DropDownList1.SelectedItem.Text == "RETIRO DE BENEFICIARIO")

            {
                Label11.Visible = true;
                TextBox10.Visible = true;
                Label10.Visible = true;
                DropDownList2.Visible = true;
                GridView2.Visible = true;

                Label9.Visible = false;
                Label14.Visible = false;
                TextBox9.Visible = false;
                TextBox12.Visible = false;
            }
            else
            {
                Label11.Visible = false;
                Label9.Visible = false;
                TextBox10.Visible = false;
                TextBox12.Visible = false;
                TextBox9.Visible = false;
                Label10.Visible = false;
                Label14.Visible = false;
                DropDownList2.Visible = false;
                GridView2.Visible = false;
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            cargarFILTRO();
            Page.Response.Redirect(Page.Request.Url.ToString(), true);

        }

        protected void Button3_Click(object sender, EventArgs e)
        {

            cargarFILTRO();
        }
    }

}