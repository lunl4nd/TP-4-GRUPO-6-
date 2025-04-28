<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ejercicio2.aspx.cs" Inherits="TP4_GRUPO_6.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 463px;
        }
        .auto-style3 {
            width: 463px;
            height: 29px;
        }
        .auto-style4 {
            height: 29px;
        }
        .auto-style5 {
            width: 463px;
            height: 22px;
        }
        .auto-style6 {
            height: 22px;
        }
        .auto-style7 {
            margin-bottom: 1px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="Label1" runat="server" Text="Id Producto:"></asp:Label>
&nbsp;&nbsp;
                        &nbsp;<asp:DropDownList ID="ddlProducto" runat="server">
                            <asp:ListItem Value="0">Igual a:</asp:ListItem>
                            <asp:ListItem Value="1">Mayor a:</asp:ListItem>
                            <asp:ListItem Value="2">Menor a:</asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox ID="txtProducto" runat="server" CssClass="auto-style7" MaxLength="4" ValidationGroup="grupo1"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtProducto" ErrorMessage="  Ingrese solo números" Font-Bold="True" ForeColor="Red" ValidationExpression="^\d{1,4}$" ValidationGroup="grupo1"></asp:RegularExpressionValidator>
                    </td>
                    <td class="auto-style4">&nbsp; <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtProducto" Font-Bold="True" ForeColor="Red" ValidationGroup="grupo1">Debe ingresar un id Producto</asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style4"></td>
                    <td class="auto-style4"></td>
                    <td class="auto-style4"></td>
                    <td class="auto-style4"></td>
                    <td class="auto-style4"></td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label2" runat="server" Text="Id Categoria:"></asp:Label>
&nbsp;
                        <asp:DropDownList ID="ddlCategoria" runat="server">
                            <asp:ListItem Value="0">Igual a:</asp:ListItem>
                            <asp:ListItem Value="1">Mayor a:</asp:ListItem>
                            <asp:ListItem Value="2">Menor a:</asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox ID="txtCategoria" runat="server" Height="22px" MaxLength="4" ValidationGroup="grupo2"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtCategoria" ErrorMessage="  Ingrese solo números" Font-Bold="True" ForeColor="Red" ValidationExpression="^\d{1,4}$" ValidationGroup="grupo2"></asp:RegularExpressionValidator>
                    </td>
                    <td>
                        &nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style5"></td>
                    <td class="auto-style6"></td>
                    <td class="auto-style6"></td>
                    <td class="auto-style6"></td>
                    <td class="auto-style6"></td>
                    <td class="auto-style6"></td>
                    <td class="auto-style6"></td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="filtrar" runat="server" OnClick="filtrar_Click" Text="Filtrar" ValidationGroup="grupo1" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="quitarFiltro" runat="server" Text="Quitar Filtro" OnClick="quitarFiltro_Click" />
                    </td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:GridView ID="grillaProductos" runat="server">
                        </asp:GridView>
                        <asp:Label ID="lblSinResultados" runat="server" Font-Bold="True" ForeColor="Red" Text="No se encontraron registros que coincidan con los criterios ingresados." Visible="False"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
