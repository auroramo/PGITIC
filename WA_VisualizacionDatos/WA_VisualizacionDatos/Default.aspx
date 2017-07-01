<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WA_VisualizacionDatos._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <img src="Assets/cloudVineyards.png" height="167" width="200" />
        <h1>Cloud Vineyands</h1>
        <p class="lead">Sistema de seguimiento y control de viñedos por medio del análisis de datos de estaciones de sensores inalámbricas</p>
        
    </div>

    
        <div class="col-md-4">
            
        </div>

    <div class="media">
        <h2>Monitor de estaciones</h2>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Timer ID="Timer1" runat="server" Interval="30000" ontick="Timer1_Tick"></asp:Timer>
                <asp:GridView ID="GridView1" runat="server" OnRowDataBound="GridView1_RowDataBound"></asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
    </div>

</asp:Content>
