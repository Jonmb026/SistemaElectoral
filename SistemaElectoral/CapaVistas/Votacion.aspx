<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Votacion.aspx.cs" Inherits="SistemaElectoral.Votacion" MasterPageFile="~/MasterPage.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="~/CSS/EstilosGenerales.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h2>Votación</h2>
        <asp:Label ID="lblCandidatos" runat="server" Text="Candidatos:" />
        <asp:DropDownList ID="ddlCandidatos" runat="server"></asp:DropDownList>
        <br />
        <asp:Button ID="btnVotar" runat="server" Text="Votar" OnClick="btnVotar_Click" />
        <asp:Label ID="lblMensaje" runat="server" Text="" ForeColor="Red" />
    </div>
</asp:Content>
