<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BIGDATA.aspx.cs" Inherits="NOVEDADES_FA.VISUAL.FORM.BIGDATA" %>

<!DOCTYPE html>

<link rel="stylesheet" type="text/css" href="VISUAL\CSS\PRINCIPAL.css">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
   <%--  <style>
      /* Estilos para centrar el contenido */
      html,
      body {
        height: 100%;
        font-family: "Helvetica Neue", Helvetica, Arial, sans-serif;
      }
      body {
        display: flex;
        justify-content: center;
        align-items: center;
        background-color: #f7f7f7;
      }
      /* Estilos para el contenedor de los controles */
      .container {
        text-align: center;
        background-color: white;
        padding: 30px;
        border-radius: 5px;
        box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.1);
      }
      /* Estilos para los controles */
      .form-control {
        margin-bottom: 10px;
        padding: 10px;
        border-radius: 5px;
        border: 1px solid #ccc;
      }
      .btn {
        background-color: #007bff;
        color: white;
        border: none;
        border-radius: 5px;
        padding: 10px 20px;
        cursor: pointer;
      }
      .btn:hover {
        background-color: #0062cc;
      }
      .grid-view {
        margin-top: 20px;
      }
    </style>--%>


</head>
<body>
    <form id="form1" runat="server">
        <div>


            <div>
                <h1>Cargar Excel</h1>

            </div>

            <div>
                <asp:FileUpload ID="FileUpload1" runat="server" />
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">actualizar tabla</asp:LinkButton>
                <asp:Button ID="Button1" runat="server" Text="REGISTRAR NUEVA BASE DE DATOS" OnClick="Button1_Click1" />
                <asp:GridView ID="GridView1" runat="server"></asp:GridView>

            </div>



        </div>
    </form>
</body>
</html>
