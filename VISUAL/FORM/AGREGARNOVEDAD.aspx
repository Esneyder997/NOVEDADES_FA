<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AGREGARNOVEDAD.aspx.cs" Inherits="NOVEDADES_FA.VISUAL.FORM.AGREGARNOVEDAD" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>
<link rel="stylesheet" type="text/css" href="\VISUAL\CSS\PRINCIPAL.css">
<link rel="stylesheet" type="text/css" href="\VISUAL\CSS\menuscroll.css">
<script src="\VISUAL\CSS\menuscroll.js" language="javascript" type="text/javascript"></script>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style type="text/css">  
        .Background  
        {  
           /* background-color: Black;  
            filter: alpha(opacity=90);  
            opacity: 0.8;  */
        }  
        .Popup  
        {  
            background-color: #FFFFFF;  
            border-width: 3px;  
            border-style: solid;  
            border-color: black;  
            padding-top: 10px;  
            padding-left: 10px;  
            width: 400px;  
            height: 350px;  
        }  
        .lbl  
        {  
            font-size:16px;  
            font-style:italic;  
            font-weight:bold;  
        }  
    </style>  
</head>
<body>

          <div id="menu">
                <div class="hamburger">
                    <div class="line"></div>
                    <div class="line"></div>
                    <div class="line"></div>
                </div>
                <div class="menu-inner">

                    <ul>
                        <li><a href="/VISUAL/FORM/BIGDATA.aspx" color="black">REGISTO BIGDATA</a></li>
                        <li><a href="/VISUAL/FORM/UPDATEBIGDATA.aspx" color="black">ACTUALIZACION CODIGO</a></li>
                    </ul>
                </div>--%>

                <svg version="1.1" id="blob" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink">
                    <path id="blob-path" d="M60,500H0V0h60c0,0,20,172,20,250S60,900,60,500z" />
                </svg>
            </div>
            <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js"></script>
            <script src="\VISUAL\CSS\menuscroll.js" language="javascript" type="text/javascript"></script>
            <h2>By: Esneyder Figueroa Sanchez<small> 2022 </small></h2>



    <div class="container">
        
        <form id="form1" runat="server">

            <h1>CREAR NOVEDAD FAMILIAS EN ACCION  </h1>
           
            <div class="group">
                <asp:Label ID="Label12" runat="server" Text="SELECCIONE TIPO DE NOVEDAD"></asp:Label>
                  <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                    <asp:ListItem>__SELECCIONE_LA_NOVEDAD__</asp:ListItem>
                    <asp:ListItem>CAMBIO_TITULAR</asp:ListItem>
                    <asp:ListItem>CAMBIO_GRUPO_POBLACIONAL</asp:ListItem>
                    <asp:ListItem>TRASLADO_DE_MUNICIPIO</asp:ListItem>
                    <asp:ListItem>CAMBIO_EN_DATOS_PERSONALES</asp:ListItem>
                    <asp:ListItem>ENTRADA_DE_BENEFICIARIO</asp:ListItem>
                    <asp:ListItem>RETIRO_DE_BENEFICIARIO</asp:ListItem>
                    <asp:ListItem>RETIRO_DE_FAMILIA_O_BENEFICIARIO</asp:ListItem>
                    <asp:ListItem>NOVEDADES_SALUD</asp:ListItem>
                </asp:DropDownList>
                </div>

            <div class="group">
                <asp:Label ID="Label10" runat="server" Text="QUE DATOS SOLICITA CAMBIAR" Visible="False"></asp:Label>
                <asp:DropDownList ID="DropDownList2" runat="server" Visible="False" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                    <asp:ListItem>__SELECCIONE CAMBIO__</asp:ListItem>
                    <asp:ListItem>CAMBIO_DOCUMENTO</asp:ListItem>
                    <asp:ListItem>CAMBIO_FECHA_DE_NACIMIENTO</asp:ListItem>
                    <asp:ListItem>CAMBIO_DE_APELLIDOS</asp:ListItem>
                </asp:DropDownList>
                </div>

                <div class="group">
                   <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged" ReadOnly="False" AutoPostBack="True"></asp:TextBox> 
                <span class="highlight"></span>
                <span class="bar"></span>
                    <asp:Label ID="Label1" runat="server" Text="BUSCAR CEDULA"></asp:Label>
                 </div>

            <div class="group">
                <asp:TextBox ID="TextBox10" runat="server" Visible="false" OnTextChanged="TextBox10_TextChanged" AutoPostBack="True"></asp:TextBox>
                <span class="highlight"></span>
                <span class="bar"></span>
                 <asp:Label ID="Label11" runat="server" Text="DOCUMENTO_NNA" Visible="false"></asp:Label>
                </div>

            <div class="group">
                <asp:TextBox ID="TextBox9" runat="server" Visible="False"></asp:TextBox>
                <span class="highlight"></span>
                <span class="bar"></span>
                <asp:Label ID="Label9" runat="server" Text="REGISTRE LA CIUDA DE ORIGEN" Visible="False"></asp:Label>
                </div>

            <div class="group">
                <asp:TextBox ID="TextBox12" runat="server" Visible="False"></asp:TextBox>
                <span class="highlight"></span>
                <span class="bar"></span>
                <asp:Label ID="Label14" runat="server" Text="DIRECCION" Visible="False"></asp:Label>
            </div>

        

            <div class="group">
                
                <asp:GridView ID="GridView1" runat="server" OnRowEditing="GridView1_RowEditing" OnRowCancelingEdit="GridView1_RowCancelingEdit" AutoGenerateColumns="False" OnRowUpdating="GridView1_RowUpdating"  Font-Size="Small">
                    <Columns>
                        <asp:TemplateField ControlStyle-Height="30px" ControlStyle-Width="30" HeaderText="SELECCIONE">
                            <EditItemTemplate>
                                <asp:CheckBox runat="server" ID="CheckBox1"></asp:CheckBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:CheckBox runat="server" ID="CheckBox2"></asp:CheckBox>
                            </ItemTemplate>
                            <ControlStyle Font-Underline="False" />
                            <FooterStyle VerticalAlign="Middle" />
                            <ItemStyle HorizontalAlign="Justify" />
                        </asp:TemplateField>
                        <asp:CommandField ShowEditButton="True" ButtonType="Button" >
                        <ControlStyle Width="80px" />
                        <HeaderStyle Width="50px" />
                        </asp:CommandField>
                        <asp:TemplateField HeaderText="nombre_titular">
                            <EditItemTemplate>
                                <asp:TextBox runat="server" Text='<%# Bind("nombre_titular") %>' ID="TextBox2"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Bind("nombre_titular") %>' ID="Label2"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="numero_documento">
                            <EditItemTemplate>
                                <asp:TextBox runat="server" Text='<%# Bind("numero_documento") %>' ID="TextBox3"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Bind("numero_documento") %>' ID="Label3"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="barrio">
                            <EditItemTemplate>
                                <asp:TextBox runat="server" Text='<%# Bind("barrio") %>' ID="TextBox4"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Bind("barrio") %>' ID="Label4"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="veredad">
                            <EditItemTemplate>
                                <asp:TextBox runat="server" Text='<%# Bind("veredad") %>' ID="TextBox5"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Bind("veredad") %>' ID="Label5"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="codigo">
                            <EditItemTemplate>
                                <asp:TextBox runat="server" Text='<%# Bind("codigo") %>' ID="TextBox6"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Bind("codigo") %>' ID="Label6"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="celular">
                            <EditItemTemplate>
                                <asp:TextBox runat="server" Text='<%# Bind("celular") %>' ID="TextBox7"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Bind("celular") %>' ID="Label7"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="titualar_id">
                            <EditItemTemplate>
                                <asp:TextBox runat="server" Text='<%# Bind("titualar_id") %>' ID="TextBox8"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Bind("titualar_id") %>' ID="Label8"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>

            <div class="group">
               
                <asp:GridView ID="GridView2" runat="server" Visible="false" AutoGenerateColumns="False">
                    <Columns>
                        <asp:TemplateField>
                            <EditItemTemplate>
                                <asp:CheckBox ID="CheckBox3" runat="server" />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBox4" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="nombre_nna">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox11" runat="server" Text='<%# Bind("nombre_titular") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label13" runat="server" Text='<%# Bind("nombre_titular") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="titualar_id" HeaderText="titualar_id" />
                    </Columns>
                </asp:GridView>

            </div>
            

            
            <div class="group">
             <asp:ScriptManager ID="ScriptManager1" runat="server">
		     </asp:ScriptManager>
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="INGRESAR TITULAR" />

		    <cc1:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panl1" TargetControlID="Button3"
			CancelControlID="Button4" BackgroundCssClass="Background">
		    </cc1:ModalPopupExtender>
		    <asp:Panel ID="Panl1" runat="server" CssClass="Popup" align="center" Style="display: none">
			<iframe style="width: 350px; height: 300px;" id="irm1" src="\VISUAL\FORM\AGREGARTRASLADO.aspx" runat="server"></iframe>
			<br />
            <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Cancelar" />
		    </asp:Panel>

                 <asp:Button ID="Button1" runat="server" Text="GENERAR_NOVEDAD " OnClick="Button1_Click"  Style="height: 29px" />

                 <asp:Button ID="Button2" runat="server" Text="IMPRIMIR NOVEDAD" OnClick="Button2_Click1" />
            </div>

        
        </form>    
    </div>
</body>
</html>
