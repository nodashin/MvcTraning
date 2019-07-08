<%@ Page Language="C#" Title="About" MasterPageFile="~/Views/Shared/_Layout.master"
    Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <h3><%:ViewBag.Message%></h3>
  <p>Use this area to provide additional information.</p>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ScriptsContent" runat="server">
</asp:Content>

