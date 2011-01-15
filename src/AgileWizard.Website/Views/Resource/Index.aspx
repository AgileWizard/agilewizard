<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<AgileWizard.Website.Models.ResourceList>" %>

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

    <p>
        <span class="display-label">
            <%: ResourceString.TotalResourceCount %></span> <span id="total_count" class="totalResourceCount">
                <%: Model.TotalCount %></span>
    </p>
    <div><%: Html.Partial("ResourceList", Model) %></div>
</asp:Content>
