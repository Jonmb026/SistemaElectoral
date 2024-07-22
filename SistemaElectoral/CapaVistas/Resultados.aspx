<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Resultados.aspx.cs" Inherits="SistemaElectoral.Resultados" MasterPageFile="~/MasterPage.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="~/CSS/EstilosGenerales.css" rel="stylesheet" />
    <link href="~/CSS/EstilosResultados.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h2>Resultados de las Elecciones</h2>
        <asp:GridView ID="gvResultados" runat="server" AutoGenerateColumns="false" CssClass="table">
            <Columns>
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="PrimerApellido" HeaderText="Primer Apellido" />
                <asp:BoundField DataField="SegundoApellido" HeaderText="Segundo Apellido" />
                <asp:BoundField DataField="PartidoPolitico" HeaderText="Partido Político" />
                <asp:BoundField DataField="Votos" HeaderText="Votos" />
                <asp:BoundField DataField="PorcentajeVotos" HeaderText="Porcentaje de Votos" DataFormatString="{0:P2}" />
            </Columns>
        </asp:GridView>
        <asp:Button ID="btnResultadoFinal" runat="server" Text="Resultado Final" OnClick="btnResultadoFinal_Click" CssClass="btn btn-primary" />
        <asp:Label ID="lblGanador" runat="server" Text="" CssClass="resultado-final" />
    </div>
</asp:Content>
