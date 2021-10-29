<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="livestream.aspx.vb" Inherits="Project_sav.livestream" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <link href="https://vjs.zencdn.net/7.8.3/video-js.css" rel="stylesheet" />

 <script src='https://vjs.zencdn.net/7.5.4/video.js'></script>

    <video width="320" height="240" controls="controls">

      <video id="player" class="video-js vjs-default-skin" width="800" height="440"  controls preload="none">
        <source src="http://192.168.1.87:8080/livestream/stream.m3u8" type="application/x-mpegURL" />
    </video>  
    
      <script>
        var player = videojs('#player')
    </script>
</asp:Content>

    