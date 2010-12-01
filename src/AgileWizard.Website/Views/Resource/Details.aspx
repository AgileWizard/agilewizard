<%@ Page Title="" Language="C#" Inherits="System.Web.Mvc.ViewPage<AgileWizard.Website.Models.ResourceModel>" MasterPageFile="~/Views/Shared/Site.Master" %>
<asp:Content runat="server" ID="Title" ContentPlaceHolderID="TitleContent">
    <%: Model.Title %>
</asp:Content>
<asp:Content runat="server" ID="Main" ContentPlaceHolderID="MainContent">
    <h2 class="Title"><%: Model.Title %></h2>
    <span class="Content"><%=Model.Content %></span>
</asp:Content>
