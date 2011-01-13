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
    <table class="contentList">
        <tr>
        <%if (Request.IsAuthenticated){%>
            <th class="link"></th>
        <%} %>
            <th id="listTitle"><%: ResourceName.Title%></th>
            <th id="listContent"><%: ResourceName.Content%></th>
        </tr>
        <% foreach (var item in Model)
           { %>
        <tr>
        <%if (Request.IsAuthenticated) {%>
            <td class="link"><%: Html.ActionLink(ResourceString.Edit, "Edit", new { id=item.Id }) %></td>
        <%}%>
            <td class="title"><%: Html.ActionLink(item.Title, "Details", new { id = item.Id })%></td>
            <td class="content"><%: item.Content %></td>
        </tr>
        <% } %>
    </table>
</asp:Content>
