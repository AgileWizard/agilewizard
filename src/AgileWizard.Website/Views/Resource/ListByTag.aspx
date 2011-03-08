<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IList<AgileWizard.Website.Models.ResourceListViewModel>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <%: ResourceString.Resources%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <%: ResourceString.Resources%></h2>
        <%if (Request.IsAuthenticated) {%>
        <p>
        <%: Html.ActionLink(ResourceString.CreateResourceLink, "Create", null, new { @class="link", @id="create_link"})%>
        </p>
        <%}%>
    <%: Html.Partial("ResourceList", Model) %>
</asp:Content>