<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AGREGARTRASLADO.aspx.cs" Inherits="NOVEDADES_FA.VISUAL.FORM.AGREGARTRASLADO" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %> 
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
       <table>  
    <tr>  
    <td>  
    <asp:Label ID="Label1" runat="server" CssClass="lbl" Text="Nombre Completo"></asp:Label>  
    </td>  
    <td>  
    <asp:TextBox ID="TextBox1" runat="server" Font-Size="14px" ></asp:TextBox>  
    </td>  
    </tr>  
    <tr>  
    <td>  
    <asp:Label ID="Label2" runat="server" CssClass="lbl" Text="Documento"></asp:Label>  
    </td>  
    <td>  
    <asp:TextBox ID="TextBox2" runat="server" Font-Size="14px" ></asp:TextBox>  
    </td>  
    </tr>  
    <tr>  
    <td>  
    <asp:Label ID="Label3" runat="server" CssClass="lbl" Text="Barrio"></asp:Label>  
    </td>  
    <td>  
    <asp:TextBox ID="TextBox3" runat="server" Font-Size="14px" ></asp:TextBox>  
    </td>  
    </tr>  
    <tr>  
    <td>  
    <asp:Label ID="Label4" runat="server" CssClass="lbl" Text="Vereda"></asp:Label>  
    </td>  
    <td>  
    <asp:TextBox ID="TextBox4" runat="server" Font-Size="14px" ></asp:TextBox>  
    </td>  
    </tr>  
    <tr>  
    <td>  
    <asp:Label ID="Label5" runat="server" CssClass="lbl" Text="Codigo"></asp:Label>  
    </td>  
    <td>  
    <asp:TextBox ID="TextBox5" runat="server" Font-Size="14px" ></asp:TextBox>  
    </td>  
    </tr>  
    <tr>  
    <td>  
    <asp:Label ID="Label6" runat="server" CssClass="lbl" Text="Celular"></asp:Label>  
    </td>  
    <td>  
    <asp:TextBox ID="TextBox6" runat="server" Font-Size="14px" ></asp:TextBox>  
    </td>  
    </tr>  
     <td>
         <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Guardar" />
     </td>
    </table>  
    </form>
</body>
</html>
