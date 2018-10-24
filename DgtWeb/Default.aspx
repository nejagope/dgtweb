<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DgtWeb._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        
        <asp:Image ID="Image1" runat="server" ImageUrl="images/portada.png" style="width:100%"/>
        <p><a runat="server" href="~/CreateDenuncia">Denuncie aquí
            <img src="images/denuncie_aqui.png" /></a></p>
    </div>
    
</asp:Content>
