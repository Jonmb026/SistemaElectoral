<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="SistemaElectoral.Inicio" MasterPageFile="~/MasterPage.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="~/CSS/EstilosGenerales.css" rel="stylesheet" />
    <style>
        .container {
            display: flex;
            justify-content: space-between;
            align-items: center;
            margin-top: 20px;
        }

        .box {
            width: 25%;
            padding: 20px;
            border-radius: 10px;
            background-color: rgba(255, 182, 193, 0.7); /* Rojo semi-transparente */
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
            transition: transform 0.3s, box-shadow 0.3s, background-color 0.3s;
        }

        .box:hover {
            transform: scale(1.05);
            box-shadow: 0 8px 16px rgba(0, 0, 0, 0.3);
            background-color: rgba(255, 160, 122, 0.7); /* Cambio de color */
        }

        .box.vision {
            background-color: rgba(135, 206, 250, 0.7); /* Azul cielo semi-transparente */
        }

        .box.vision:hover {
            background-color: rgba(70, 130, 180, 0.7); /* Cambio de color */
        }

        .box h3 {
            margin-bottom: 10px;
            color: #1845ad;
        }

        .box p {
            font-size: 16px;
            line-height: 1.5;
            color: #333;
        }

        .image {
            width: 50%;
            max-width: 800px;
        }

        .image img {
            width: 100%;
            border-radius: 10px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
        }

        .content {
            text-align: center;
            margin-top: 20px;
        }

        .content h2 {
            margin-top: 20px;
            color: #1845ad;
        }

        .content p {
            font-size: 18px;
            line-height: 1.6;
            text-align: justify;
            margin: 20px 0;
        }

        .status {
            position: fixed;
            bottom: 10px;
            left: 10px;
        }

        .main-container {
            border: 2px solid rgba(0, 0, 0, 0.3);
            border-radius: 15px;
            padding: 20px;
            background-color: rgba(255, 255, 255, 0.8); /* Fondo semi-transparente */
            box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main-container">
        <div class="container">
            <div class="box">
                <h3>Misión</h3>
                <p>Promover y garantizar la participación ciudadana en el proceso electoral, asegurando transparencia, equidad y acceso a todos los costarricenses para fortalecer nuestra democracia.</p>
            </div>
            <div class="image">
                <img src="<%= ResolveUrl("~/images/votacioncr.jpg") %>" alt="Votación en Costa Rica" />
            </div>
            <div class="box vision">
                <h3>Visión</h3>
                <p>Ser el referente en procesos electorales transparentes y justos, donde cada ciudadano costarricense tenga plena confianza en la integridad y efectividad de nuestro sistema electoral.</p>
            </div>
        </div>
        <div class="content">
            <h2>¿Por qué es importante votar?</h2>
            <p>Votar es un derecho fundamental. Nos brinda la oportunidad de participar en la construcción de nuestra democracia, elegir a nuestros representantes y expresar nuestras opiniones sobre los temas que más nos importan.</p>
            <p>En cada elección, los costarricenses tienen la posibilidad de influir en la dirección del país, participando en un proceso transparente y justo. Votar no solo fortalece nuestras instituciones democráticas, sino que también nos permite ser parte activa de la comunidad nacional.</p>
            <p>Desde elegir a nuestros líderes locales hasta participar en decisiones nacionales importantes, cada voto cuenta y cada voz importa. La democracia en Costa Rica es un reflejo de nuestro compromiso colectivo con la justicia, la igualdad y el progreso.</p>
        </div>
        <div class="status">
            <asp:Label ID="lblConexion" runat="server" Text="" />
        </div>
    </div>
</asp:Content>
