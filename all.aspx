<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="all.aspx.vb" Inherits="Project_sav.all" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;    <asp:Label ID="Label1" runat="server" Text="Video Page" Font-Size="Large"></asp:Label>
<br />
        <asp:DropDownList ID="DropDownList1" runat="server" DataValueField="ID" DataTextField ="Nome"  AutoPostBack="true">
        </asp:DropDownList>
<br />
<br />
<asp:DataList ID="DataList1" runat="server" DataKeyField="ID" DataSourceID="Conexao" RepeatColumns="2" RepeatDirection="Horizontal" ShowFooter="False" ShowHeader="False" Width="523px" BorderWidth="1px" GridLines="Both" Height="88px">
    <ItemTemplate>
        ID:
        <asp:Label ID="IDLabel" runat="server" Text='<%# Eval("ID") %>' />
        <br />
        Nome:
        <asp:Label ID="NomeLabel" runat="server" Text='<%# Eval("Nome") %>' />
        <br />
        autor:
        <asp:Label ID="autorLabel" runat="server" Text='<%# Eval("autor") %>' />
        <br />
        videolink:
        <asp:Label ID="videolinkLabel" runat="server" Text='<%# Eval("videolink") %>' />
        <br />
<br />
    </ItemTemplate>
</asp:DataList>
    <asp:SqlDataSource ID="SqlDataSource" runat="server"></asp:SqlDataSource>
    <asp:SqlDataSource ID="Conexao" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [videodata]"></asp:SqlDataSource>
<br />
<br />
        <asp:Label ID="Label3" runat="server" Text="Nome"></asp:Label>
        <asp:TextBox ID="Textnome" runat="server"></asp:TextBox>
    <br />
        <asp:Label ID="Label2" runat="server" Text="Autor"></asp:Label>
        <asp:TextBox ID="Textautor" runat="server"></asp:TextBox>
    <br />
        <asp:Button ID="Button2" runat="server" Text="Actualizar" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="apagar" runat="server" Text="Apagar" />
<br />
<br />
<br />
<br />
<br />
<br />
<br />
</asp:Content>

