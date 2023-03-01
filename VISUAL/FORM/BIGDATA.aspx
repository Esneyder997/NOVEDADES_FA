<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BIGDATA.aspx.cs" Inherits="NOVEDADES_FA.VISUAL.FORM.BIGDATA" %>

<!DOCTYPE html>

<link rel="stylesheet" type="text/css" href="VISUAL\CSS\PRINCIPAL.css">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>



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
