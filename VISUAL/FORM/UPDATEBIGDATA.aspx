<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UPDATEBIGDATA.aspx.cs" Inherits="NOVEDADES_FA.VISUAL.FORM.UPDATEBIGDATA" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <h1>ACTUALIZAR CODIGOS DE BENEFICIARIOS </h1>
        <div>
            <asp:FileUpload ID="FileUpload1" runat="server" /><asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Actualizar Tabla</asp:LinkButton><asp:Button ID="Button1" runat="server" Text="Actualziar datos" OnClick="Button1_Click" />
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
        </div>
    </form>
 </body>
</html>
