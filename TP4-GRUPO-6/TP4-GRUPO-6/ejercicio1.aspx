<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ejercicio1.aspx.cs" Inherits="TP4_GRUPO_6.ejercicio1" %>

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
            width: 106px;
        }
        .auto-style3 {
            text-decoration: underline;
        }
        .auto-style4 {
            width: 505px;
        }
        .auto-style5 {
            width: 106px;
            height: 30px;
        }
        .auto-style6 {
            width: 505px;
            height: 30px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="destinicio" runat="server" CssClass="auto-style3" Font-Overline="False" Font-Underline="True" Text="Destino Inicio:"></asp:Label>
                    </td>
                    <td class="auto-style4">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style5"><strong>
                        <asp:Label ID="provinciainicio" runat="server" Text="Provincia"></asp:Label>
                        </strong></td>
                    <td class="auto-style6">
                        <asp:DropDownList ID="listaProvinciaInicio" runat="server" AutoPostBack="True" Height="23px" Width="125px" OnSelectedIndexChanged="listaProvinciaInicio_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Localidad:"></asp:Label>
                    </td>
                    <td class="auto-style4">
                        <asp:DropDownList ID="listaLocalidadesInicio" runat="server" Height="23px" Width="125px" AutoPostBack="True">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="labelDestinoFinal" runat="server" Text="Destino final:"></asp:Label>
                    </td>
                    <td class="auto-style4">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2"><strong>
                        <asp:Label ID="labelProvinciaFinal" runat="server" Text="Provincia"></asp:Label>
                        </strong></td>
                    <td class="auto-style4">
                        <asp:DropDownList ID="ddlProvinciaFinal" runat="server" AutoPostBack="True" Height="23px" OnSelectedIndexChanged="ddlProvinciaFinal_SelectedIndexChanged" Width="125px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2"><strong>
                        <asp:Label ID="locafinal" runat="server" Text="Localidad"></asp:Label>
                        </strong></td>
                    <td class="auto-style4">
                        <asp:DropDownList ID="listLocalidadesFinal" runat="server" Height="23px" Width="125px" AutoPostBack="True">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
