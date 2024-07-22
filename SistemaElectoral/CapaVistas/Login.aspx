<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SistemaElectoral.Login" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link href="~/CSS/EstilosLogin.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Login</h2>
            <asp:Label ID="lblUsuario" runat="server" Text="Usuario:" />
            <asp:TextBox ID="txtUsuario" runat="server" />
            <br />
            <asp:Label ID="lblContraseña" runat="server" Text="Contraseña:" />
            <asp:TextBox ID="txtContraseña" runat="server" TextMode="Password" />
            <br />
            <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
            <asp:Label ID="lblMensaje" runat="server" Text="" ForeColor="Red" />
        </div>
        <div style="position: fixed; bottom: 10px; left: 10px;">
            <asp:Label ID="lblConexion" runat="server" Text="" />
        </div>
    </form>
</body>
</html>
