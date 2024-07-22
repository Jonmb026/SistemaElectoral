<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrarUsuario.aspx.cs" Inherits="SistemaElectoral.RegistrarUsuario" MasterPageFile="~/MasterPage.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="~/CSS/EstilosGenerales.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main-container">
        <h2>Registrar Usuario</h2>
        <!-- Remover la etiqueta <form> extra -->
        <label for="txtNombreUsuario">Nombre de Usuario:</label>
        <asp:TextBox ID="txtNombreUsuario" runat="server" />

        <label for="txtContraseña">Contraseña:</label>
        <asp:TextBox ID="txtContraseña" runat="server" TextMode="Password" />

        <label for="txtConfirmarContraseña">Confirmar Contraseña:</label>
        <asp:TextBox ID="txtConfirmarContraseña" runat="server" TextMode="Password" />

        <label for="txtNombreCompleto">Nombre Completo:</label>
        <asp:TextBox ID="txtNombreCompleto" runat="server" />

        <label for="txtPrimerApellido">Primer Apellido:</label>
        <asp:TextBox ID="txtPrimerApellido" runat="server" />

        <label for="txtSegundoApellido">Segundo Apellido:</label>
        <asp:TextBox ID="txtSegundoApellido" runat="server" />

        <label for="txtCorreoElectronico">Correo Electrónico:</label>
        <asp:TextBox ID="txtCorreoElectronico" runat="server" />

        <label for="txtTelefono">Teléfono (opcional):</label>
        <asp:TextBox ID="txtTelefono" runat="server" />

        <label for="ddlProvincia">Provincia:</label>
        <asp:DropDownList ID="ddlProvincia" runat="server">
            <asp:ListItem>San José</asp:ListItem>
            <asp:ListItem>Alajuela</asp:ListItem>
            <asp:ListItem>Cartago</asp:ListItem>
            <asp:ListItem>Heredia</asp:ListItem>
            <asp:ListItem>Guanacaste</asp:ListItem>
            <asp:ListItem>Puntarenas</asp:ListItem>
            <asp:ListItem>Limón</asp:ListItem>
        </asp:DropDownList>

        <label for="ddlRol">Rol:</label>
        <asp:DropDownList ID="ddlRol" runat="server">
            <asp:ListItem>Votante</asp:ListItem>
            <asp:ListItem>Admin</asp:ListItem>
        </asp:DropDownList>

        <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" OnClick="btnRegistrar_Click" />
        <asp:Label ID="lblMensaje" runat="server" ForeColor="Red" />
        <asp:Label ID="lblConexion" runat="server" Text="" CssClass="status" />
    </div>
</asp:Content>
