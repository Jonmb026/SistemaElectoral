<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrarCandidato.aspx.cs" Inherits="SistemaElectoral.RegistrarCandidato" MasterPageFile="~/MasterPage.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="~/CSS/EstilosGenerales.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h2>Registrar Candidato</h2>
        <asp:Label ID="lblNombre" runat="server" Text="Nombre:" />
        <asp:TextBox ID="txtNombre" runat="server" />
        <br />
        <asp:Label ID="lblPrimerApellido" runat="server" Text="Primer Apellido:" />
        <asp:TextBox ID="txtPrimerApellido" runat="server" />
        <br />
        <asp:Label ID="lblSegundoApellido" runat="server" Text="Segundo Apellido:" />
        <asp:TextBox ID="txtSegundoApellido" runat="server" />
        <br />
        <asp:Label ID="lblPartidoPolitico" runat="server" Text="Partido Político:" />
        <asp:TextBox ID="txtPartidoPolitico" runat="server" />
        <br />
        <asp:Label ID="lblPlataforma" runat="server" Text="Plataforma:" />
        <asp:TextBox ID="txtPlataforma" runat="server" />
        <br />
        <asp:Label ID="lblCargo" runat="server" Text="Cargo:" />
        <asp:DropDownList ID="ddlCargo" runat="server">
            <asp:ListItem Text="Presidente" Value="Presidente" />
            <asp:ListItem Text="Alcalde" Value="Alcalde" />
            <asp:ListItem Text="Diputado" Value="Diputado" />
        </asp:DropDownList>
        <br />
        <asp:Label ID="lblProvincia" runat="server" Text="Provincia:" />
        <asp:DropDownList ID="ddlProvincia" runat="server">
            <asp:ListItem Text="San José" Value="San José" />
            <asp:ListItem Text="Alajuela" Value="Alajuela" />
            <asp:ListItem Text="Cartago" Value="Cartago" />
            <asp:ListItem Text="Heredia" Value="Heredia" />
            <asp:ListItem Text="Guanacaste" Value="Guanacaste" />
            <asp:ListItem Text="Puntarenas" Value="Puntarenas" />
            <asp:ListItem Text="Limón" Value="Limón" />
        </asp:DropDownList>
        <br />
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
        <asp:Label ID="lblMensaje" runat="server" Text="" ForeColor="Red" />
    </div>
</asp:Content>
