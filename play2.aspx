<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="play2.aspx.vb" Inherits="Project_sav.play2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
    <br />
        <asp:Label ID="Label1" runat="server" Text="Titulo video"></asp:Label>
    </p>
<p>
        <asp:TextBox ID="Textitulo" runat="server"></asp:TextBox>
    </p>
<p>
        <asp:Label ID="sinopse" runat="server" Text="Sinopse"></asp:Label>
    </p>
<p>
        <asp:TextBox ID="TextSinopse" runat="server"></asp:TextBox>
    </p>
<p>
        <asp:FileUpload ID="FileUpload1" runat="server" />
    </p>
<p>
        <asp:Label ID="resultado" runat="server"></asp:Label>
    </p>
<p>
        <asp:Button ID="Inserir" runat="server" Text="Inserir" BackColor="#00FFCC" BorderColor="#00FF99" />
    </p>
<p>
</p>
<p>
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/all.aspx">Ver todos videos</asp:HyperLink>
</p>
<p>
</p>
<p>
</p>
</asp:Content>

