<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateDenuncia.aspx.cs" Inherits="DgtWeb.CreateDenuncia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin-top:30px;">

        <div class="panel panel-primary" style="width:50%">
          <div class="panel-heading">Crear Denuncia</div>
          <div class="panel-body">
              <div style="margin-left:10px;">
              
                <div class="form-group row">
                    <asp:Label ID="lComplaintType" runat="server" Text="Tipo de denuncia*" Font-Bold="true"></asp:Label>
                    <asp:DropDownList ID="ddlComplaintType" runat="server"  CssClass="form-control"></asp:DropDownList>
                </div>

                <div class="form-group row">
                    <asp:Label ID="lDetails" runat="server" Text="Detalles de la denuncia*" Font-Bold="true"></asp:Label>
                    <asp:TextBox ID="txtDetails" runat="server" CssClass="form-control" TextMode="MultiLine" Height="100px"></asp:TextBox>
                </div>

                <div class="form-group row">
                    <asp:Label ID="lEmail" runat="server" Text="Correo electrónico*" Font-Bold="true"></asp:Label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="form-group row">
                    <asp:Label ID="lPhone" runat="server" Text="Teléfono de contacto" Font-Bold="true"></asp:Label>
                    <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="form-group row">
                    <asp:Label ID="lAddress" runat="server" Text="Dirección*" Font-Bold="true" ></asp:Label>
                    <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="form-group row">
                    <asp:Button ID="bSendComplaint" runat="server" Text="Eviar denuncia" CssClass="btn btn-primary"/>                    
                </div>
                  </div>
          </div>
        </div>
        
    </div>
</asp:Content>
