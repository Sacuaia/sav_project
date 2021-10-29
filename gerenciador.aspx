<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="gerenciador.aspx.vb" Inherits="Project_sav.gerenciador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <br />
    </p>
    <p>
        <asp:DropDownList ID="DropDownList1" runat="server" DataValueField="ID" DataTextField ="Nome"  AutoPostBack="true">
        </asp:DropDownList>
    </p>
    <p>
        <asp:Label ID="Label1" runat="server" Text="Nome"></asp:Label>
        <asp:TextBox ID="Textnome" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
        <asp:TextBox ID="TextPass" runat="server"></asp:TextBox>
    </p>
    <p>
    </p>
    <p>
        <asp:Button ID="Button2" runat="server" Text="Actualizar" />
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="apagar" runat="server" Text="Apagar" />
    </p>
    <p class="auto-style5">
        <asp:Button ID="Button1" runat="server" Text="Sair" />
    </p>
    <p>
    </p>
</asp:Content>

