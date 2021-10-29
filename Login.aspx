<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="Login.aspx.vb" Inherits="Project_sav.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
    &nbsp;</p>
<p>
    <asp:Label ID="Label1" runat="server" Text="Utilizador"></asp:Label>
    <asp:TextBox ID="TextUtilizador" runat="server"></asp:TextBox>
</p>
<p>
    <asp:Label ID="Label2" runat="server" Text="login"></asp:Label>
    <asp:TextBox ID="Textlogin" runat="server" TextMode="Password"></asp:TextBox>
</p>
    <p>
        &nbsp;</p>
<p>
    <asp:Button ID="Bentrar" runat="server" Text="Entrar" Width="56px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Button ID="Inserir" runat="server" Text="Inserir" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </p>
<p>
    &nbsp;</p>
<p>
    <br />
</p>
</asp:Content>
