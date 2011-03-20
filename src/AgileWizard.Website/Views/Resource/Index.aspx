<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IList<AgileWizard.Website.Models.ResourceListViewModel>>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <%: ResourceString.Resources%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   <div id="resource-paging-list-container"><%: Html.Partial("ResourcePagingList", Model) %></div>
</asp:Content>
